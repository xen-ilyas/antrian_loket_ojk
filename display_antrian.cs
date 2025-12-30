using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Media;
using System.Globalization;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using LibVLCSharp.Shared;

namespace antrian_loket
{
	
    public partial class display_antrian : Form
    {
        MainForm mainForm;
        string settingsFile = Path.Combine(Application.StartupPath, "settings.cfg");
		AppSettings settings;
		BlockingCollection<Action> soundQueue = new BlockingCollection<Action>();
		bool audioWorkerStarted = false;
		LibVLC libVLC;
		
		int marqueeSpeed = 2;
		int marqueeX;

		int globalLastA;   // A series (Loket 1)
		int globalLastB;   // B series (Loket 2 & 3)
		
		int lastCallA;
		int lastCallB1;
		int lastCallB2;
		
		int lastTicketA;
		int lastTicketB;

		readonly string stateFile = Path.Combine(Application.StartupPath, "state.json");
		AntrianState state = new AntrianState();
		public class AntrianState
		{
		    public string LastUpdatedDate { get; set; }
		    public int LastA { get; set; }
		    public int LastB { get; set; }
		    public int LastCallA { get; set; }
		    public int LastCallB1 { get; set; }
		    public int LastCallB2 { get; set; }
		    public int LastTicketA { get; set; }
		    public int LastTicketB { get; set; }
		}
		
		void DisplayKeyDown(object sender, KeyEventArgs e)
		{
			//Shortcut Keyboard di Loket Pengaduan
				//Button Back
			if (e.KeyCode == Keys.Q || e.KeyCode == Keys.NumPad7) btnBackLok1.PerformClick();
				//Button Recall
			if (e.KeyCode == Keys.W || e.KeyCode == Keys.NumPad8) btnCallLok1.PerformClick();
				//Button Next			
			if (e.KeyCode == Keys.E || e.KeyCode == Keys.NumPad9) btnNextLok1.PerformClick();		
			//Shortcut Keyboard di Loket Pelayanan Slik 1
				//Button Back
			if (e.KeyCode == Keys.A || e.KeyCode == Keys.NumPad4) btnBackLok2.PerformClick();
				//Button Recall			
			if (e.KeyCode == Keys.S || e.KeyCode == Keys.NumPad5) btnCallLok2.PerformClick();
				//Button Next			
			if (e.KeyCode == Keys.D || e.KeyCode == Keys.NumPad6) btnNextLok2.PerformClick();			
			//Shortcut Keyboard di Loket Pelayanan Slik 2
				//Button Back
			if (e.KeyCode == Keys.Z || e.KeyCode == Keys.NumPad1) btnBackLok3.PerformClick(); 
				//Button Recall
			if (e.KeyCode == Keys.X || e.KeyCode == Keys.NumPad2) btnCallLok3.PerformClick();
				//Button Next
			if (e.KeyCode == Keys.C || e.KeyCode == Keys.NumPad3) btnNextLok3.PerformClick();
				//Button Exit Display Module
			if (e.KeyCode == Keys.Escape) this.Close();
		}
        public display_antrian(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            this.KeyPreview = true;
            DisabledZeroNumberAntrian();
            StartAudioWorker();
            LoadState();
            CheckLimitButtons();
			Core.Initialize();
			libVLC = new LibVLC();
			WMPPlayer.MediaPlayer = new MediaPlayer(libVLC);
			lblNumAntrian.Text = lblNumAntrianLok1.Text;
			
			//buat Teks Berjalan
			this.DoubleBuffered = true;
		    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		    this.UpdateStyles();
		    
		    RunningText();
		}

		void SaveState()
		{
		    var state = new
		    {
		        LastUpdatedDate = DateTime.Now.ToString("yyyy-MM-dd"),
		        LastA = globalLastA,
		        LastB = globalLastB,
		        LastCallA = lastCallA,
		        LastCallB1 = lastCallB1,
		        LastCallB2 = lastCallB2,
		        LastTicketA = lastTicketA,
		        LastTicketB = lastTicketB
		    };
		
		    string json = JsonConvert.SerializeObject(state, Formatting.Indented);
		    File.WriteAllText("state.json", json);
		}

        void LoadState()
		{
		    if (!File.Exists("state.json")) {  ResetState(); return; }
			string json = File.ReadAllText("state.json");
		    dynamic state = JsonConvert.DeserializeObject(json);
		
		    string savedDate = state.LastUpdatedDate;
		    string today = DateTime.Now.ToString("yyyy-MM-dd");
		
		    if (savedDate != today) { ResetState(); return;} // Hari sudah berganti, reset nomor
		    globalLastA = (int)state.LastA;
		    globalLastB = (int)state.LastB;
		
		    lastCallA = (int)state.LastCallA;
		    lastCallB1 = (int)state.LastCallB1;
		    lastCallB2 = (int)state.LastCallB2;
		    lastTicketA = state.LastTicketA != null ? (int)state.LastTicketA : 0;
			lastTicketB = state.LastTicketB != null ? (int)state.LastTicketB : 0;

		    
		    //mengembalikan fungsi button recall ketika force close
		    if (lastCallA != 0){ btnCallLok1.Enabled = true; }
		    if (lastCallB1 != 0){ btnCallLok2.Enabled = true; }
		    if (lastCallB2 != 0){ btnCallLok2.Enabled = true; }
		    
		    /* 
  			menampilkan kembali nomor antrian terakhir apabila terjadi Force Close();
		    */
		    lblNumAntrianLok1.Text = "A"+lastCallA.ToString("000");
		    lblNumAntrianLok2.Text = "B"+lastCallB1.ToString("000");
		    lblNumAntrianLok3.Text = "B"+lastCallB2.ToString("000");
		}
        void CheckLimitButtons()
		{
        	// A
		    btnNextLok1.Enabled = globalLastA < lastTicketA;
			 // B
		    bool allowB = globalLastB < lastTicketB;
		    btnNextLok2.Enabled = allowB;
		    btnNextLok3.Enabled = allowB;
		}
        
		void ResetState()
		{
			globalLastA = 1;
			globalLastB = 1;

			lastCallA = 1;
			lastCallB1 = 1;
			lastCallB2 = 0;
			lastTicketA = 0;
			lastTicketB = 0;

			SaveState();
		}
        
        void StartAudioWorker()
		{
		    if (audioWorkerStarted) return;
			audioWorkerStarted = true;
		
		    Task.Run(() =>
		    {
		        foreach (var job in soundQueue.GetConsumingEnumerable())
		        {
		            try {job();} catch {}
		        }
		    });
		}

        void DisabledZeroNumberAntrian()
		{
		    // Loket A1
		    string aText = lblNumAntrianLok1.Text;   // contoh "A003"
		    int aNum = 0;
		    if (aText.StartsWith("A")) int.TryParse(aText.Substring(1), out aNum);
		    btnBackLok1.Enabled = aNum > 1;
		    btnCallLok1.Enabled = aNum >= 1;
		
		    // Loket B1
		    string b1Text = lblNumAntrianLok2.Text;  // contoh "B005"
		    int b1Num = 0;
		    if (b1Text.StartsWith("B")) int.TryParse(b1Text.Substring(1), out b1Num);
		    btnBackLok2.Enabled = b1Num > 1;
		    btnCallLok2.Enabled = b1Num >= 1;
		
		    // Loket B2
		    string b2Text = lblNumAntrianLok3.Text;
		    int b2Num = 0;
		    if (b2Text.StartsWith("B"))  int.TryParse(b2Text.Substring(1), out b2Num);
		    btnBackLok3.Enabled = b2Num > 1;
		    btnCallLok3.Enabled = b2Num >= 1;
		}

        void PlayBell_InSound()
        {
            var asm = Assembly.GetExecutingAssembly();
            var stream = asm.GetManifestResourceStream("antrian_loket.audio.bell_in.wav");
            new SoundPlayer(stream).PlaySync();
        }

		void PlayBell_Sound()
		{
			var asm = Assembly.GetExecutingAssembly();
			var stream = asm.GetManifestResourceStream("antrian_loket.audio.bell.wav");
			new SoundPlayer(stream).PlaySync();
		}

		void PlayBell_OutSound()
        {
            var asm = Assembly.GetExecutingAssembly();
            var stream = asm.GetManifestResourceStream("antrian_loket.audio.bell_out.wav");
            new SoundPlayer(stream).PlaySync();
        }
        
        void PlayWav(string name)
        {
            var asm = Assembly.GetExecutingAssembly();
            var stream = asm.GetManifestResourceStream("antrian_loket.audio." + name);
            if (stream == null) return;
            new SoundPlayer(stream).PlaySync();
        }

        void PlayNumber(int angka)
        {
            if (angka <= 0 || angka > 999) return;
		    // 1. 1–19 langsung
		    if (angka < 20) { PlayWav(angka + ".wav"); return;  }
		    // 2. 20–99
		    if (angka < 100)
		    {
		        int puluhan = angka / 10 * 10;
		        int satuan = angka % 10;
		        PlayWav(puluhan + ".wav");
		        if (satuan != 0) PlayWav(satuan + ".wav"); return;
		    }	
		    // 3. 100–999
		    int ratusan = angka / 100 * 100;   // contoh 432 → 400
		    int sisa = angka % 100;
		    PlayWav(ratusan + ".wav");         // 100.wav, 200.wav dll
		    if (sisa == 0)  return;
		    // sisa 1–19
		    if (sisa < 20)  { PlayWav(sisa + ".wav");  return; }
		    // sisa 20–99
		    int puluh = sisa / 10 * 10;
		    int satu = sisa % 10;
		    PlayWav(puluh + ".wav");
		    if (satu != 0) PlayWav(satu + ".wav");
        }
        
        void PlayCallA1(int nomorAntrian ,int nomorLoket) // LOKET PENGADUAN
        {
        	PlayWav("antrian.wav");
        	PlayWav("a.wav");
            PlayNumber(nomorAntrian);
            PlayWav("loket_pengaduan.wav");
        }
        void PlayCallB1(int nomorAntrian, int nomorLoket) // LOKET PELAYANAN SLIK 1
        {
        	PlayWav("antrian.wav");
        	PlayWav("b.wav");
            PlayNumber(nomorAntrian);
            PlayWav("loket_slik.wav");
            PlayNumber(nomorLoket);
        }
        void PlayCallB2(int nomorAntrian, int nomorLoket) // LOKET PELAYANAN SLIK 2
        {
        	PlayWav("antrian.wav");
        	PlayWav("b.wav");
            PlayNumber(nomorAntrian);
            PlayWav("loket_slik.wav");
            PlayNumber(nomorLoket);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            mainForm.Show();
        }

        // -------------------------
        // NEXT PER LOKET
        // -------------------------
		
        void BtnNextLok1Click(object sender, EventArgs e) //LOKET A Bagian Pengaduan
        {
            globalLastA++;
		    lastCallA = globalLastA; 
		    string nomorA = "A" + globalLastA.ToString("000");
		    lblNumAntrianLok1.Text = nomorA;
		    SetFontAntrianDefault();
		    lblNumAntrian.Text = nomorA;
		    lblNumLoket.Text = "PENGADUAN";
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = true));
			});
			//soundQueue.Add(() => PlayBell_InSound());
			soundQueue.Add(() => PlayBell_Sound());
			soundQueue.Add(() => PlayCallA1(globalLastA, 1));
		    //soundQueue.Add(() => PlayBell_OutSound());
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = false));
			});
			DisabledZeroNumberAntrian();
		    SaveState();
		    CheckLimitButtons();
		    lblNumAntrianLok1.BackColor = Color.Red;
		    lblNumAntrianLok2.BackColor = Color.Silver;
		    lblNumAntrianLok3.BackColor = Color.Silver;
		    lblNumAntrianLok1.ForeColor = Color.White;
		    lblNumAntrianLok2.ForeColor = Color.Black;
		    lblNumAntrianLok3.ForeColor = Color.Black;
        }

        void BtnNextLok2Click(object sender, EventArgs e) // LOKET B1
        {
            globalLastB++;
		    lastCallB1 = globalLastB;
		    string nomorB = "B" + globalLastB.ToString("000");
		    lblNumAntrianLok2.Text = nomorB;
		    SetFontAntrianDefault();
		    lblNumAntrian.Text = nomorB;
		    lblNumLoket.Text = "PELAYANAN SLIK 1";
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = true));
			});
			//soundQueue.Add(() => PlayBell_InSound());
			soundQueue.Add(() => PlayBell_Sound());
			soundQueue.Add(() => PlayCallB1(globalLastB, 1));
		    //soundQueue.Add(() => PlayBell_OutSound());
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = false));
			});
			DisabledZeroNumberAntrian();
		    SaveState();
		    CheckLimitButtons();
		    lblNumAntrianLok1.BackColor = Color.Silver;
		    lblNumAntrianLok2.BackColor = Color.Red;
		    lblNumAntrianLok3.BackColor = Color.Silver;
		    lblNumAntrianLok1.ForeColor = Color.Black;
		    lblNumAntrianLok2.ForeColor = Color.White;
		    lblNumAntrianLok3.ForeColor = Color.Black;
        }

        void BtnNextLok3Click(object sender, EventArgs e) // LOKET B2
        {
            globalLastB++;
		    lastCallB2 = globalLastB;
		    string nomorB = "B" + globalLastB.ToString("000");
		    lblNumAntrianLok3.Text = nomorB;
		    SetFontAntrianDefault();
		    lblNumAntrian.Text = nomorB;
		    lblNumLoket.Text = "PELAYANAN SLIK 2";
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = true));
			});
			//soundQueue.Add(() => PlayBell_InSound());
			soundQueue.Add(() => PlayBell_Sound());
			soundQueue.Add(() => PlayCallB2(globalLastB, 2));
		    //soundQueue.Add(() => PlayBell_OutSound());
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = false));
			});
			DisabledZeroNumberAntrian();
		    SaveState();
		    CheckLimitButtons();
		    lblNumAntrianLok1.BackColor = Color.Silver;
		    lblNumAntrianLok2.BackColor = Color.Silver;
		    lblNumAntrianLok3.BackColor = Color.Red;
		    lblNumAntrianLok1.ForeColor = Color.Black;
		    lblNumAntrianLok2.ForeColor = Color.Black;
		    lblNumAntrianLok3.ForeColor = Color.White;
        }

        // -------------------------
        // BACK PER LOKET
        // -------------------------

        void BtnBackLok1Click(object sender, EventArgs e) // LOKET A Bag. Pengaduan
        {
            if (lastCallA <= 1) return;

		    lastCallA--;
		    globalLastA = lastCallA;
		    string nomorA = "A" + lastCallA.ToString("000");
		    lblNumAntrianLok1.Text = nomorA;
		    SetFontAntrianDefault();
		    lblNumAntrian.Text = nomorA;
		    lblNumLoket.Text = "PENGADUAN";
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = true));
			});
			//soundQueue.Add(() => PlayBell_InSound());
			soundQueue.Add(() => PlayBell_Sound());
			soundQueue.Add(() => PlayCallA1(lastCallA, 1));
		    //soundQueue.Add(() => PlayBell_OutSound());
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = false));
			});
			DisabledZeroNumberAntrian();
		    SaveState();
		    CheckLimitButtons();
		    lblNumAntrianLok1.BackColor = Color.Red;
		    lblNumAntrianLok2.BackColor = Color.Silver;
		    lblNumAntrianLok3.BackColor = Color.Silver;
		    lblNumAntrianLok1.ForeColor = Color.White;
		    lblNumAntrianLok2.ForeColor = Color.Black;
		    lblNumAntrianLok3.ForeColor = Color.Black;
        }

        void BtnBackLok2Click(object sender, EventArgs e) // LOKET B1
        {
            if (lastCallB1 <= 1) return;
		    lastCallB1--;
		    globalLastB = Math.Max(lastCallB1, lastCallB2);
		    string nomorB = "B" + lastCallB1.ToString("000");
		    lblNumAntrianLok2.Text = nomorB;
		    SetFontAntrianDefault();
		    lblNumAntrian.Text = nomorB;
		    lblNumLoket.Text = "PELAYANAN SLIK 1";
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = true));
			});
			//soundQueue.Add(() => PlayBell_InSound());
			soundQueue.Add(() => PlayBell_Sound());
			soundQueue.Add(() => PlayCallB1(lastCallB1, 1));
		    //soundQueue.Add(() => PlayBell_OutSound());
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = false));
			});
			DisabledZeroNumberAntrian();
		    SaveState();
		    CheckLimitButtons();
		    lblNumAntrianLok1.BackColor = Color.Silver;
		    lblNumAntrianLok2.BackColor = Color.Red;
		    lblNumAntrianLok3.BackColor = Color.Silver;
		    lblNumAntrianLok1.ForeColor = Color.Black;
		    lblNumAntrianLok2.ForeColor = Color.White;
		    lblNumAntrianLok3.ForeColor = Color.Black;
        }

        void BtnBackLok3Click(object sender, EventArgs e) // LOKET B2
        {
            if (lastCallB2 <= 1) return;
		    lastCallB2--;
		    globalLastB = Math.Max(lastCallB1, lastCallB2);
		    string nomorB = "B" + lastCallB2.ToString("000");
		    lblNumAntrianLok3.Text = nomorB;
		    SetFontAntrianDefault();
		    lblNumAntrian.Text = nomorB;
		    lblNumLoket.Text = "PELAYANAN SLIK 2";
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = true));
			});
			//soundQueue.Add(() => PlayBell_InSound());
			soundQueue.Add(() => PlayBell_Sound());
			soundQueue.Add(() => PlayCallB2(lastCallB2, 2));
		    //soundQueue.Add(() => PlayBell_OutSound());
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = false));
			});
			DisabledZeroNumberAntrian();
		    SaveState();
		    CheckLimitButtons();
		    lblNumAntrianLok1.BackColor = Color.Silver;
		    lblNumAntrianLok2.BackColor = Color.Silver;
		    lblNumAntrianLok3.BackColor = Color.Red;
		    lblNumAntrianLok1.ForeColor = Color.Black;
		    lblNumAntrianLok2.ForeColor = Color.Black;
		    lblNumAntrianLok3.ForeColor = Color.Silver;
        }

        // -------------------------
        // RECALL PER LOKET
        // -------------------------

        void BtnCallLok1Click(object sender, EventArgs e) // LOKET A / Pengaduan
        {
            int no = lastCallA;
            SetFontAntrianDefault();
		    lblNumAntrian.Text = "A" + no.ToString("000");
		    lblNumLoket.Text = "PENGADUAN";
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = true));
			});
			//soundQueue.Add(() => PlayBell_InSound());
			soundQueue.Add(() => PlayBell_Sound());
			soundQueue.Add(() => PlayCallA1(no, 1));
		    //soundQueue.Add(() => PlayBell_OutSound());
		    soundQueue.Add(() => {Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = false));
			});
			DisabledZeroNumberAntrian();
		    SaveState();
		    CheckLimitButtons();
		    lblNumAntrianLok1.BackColor = Color.Red;
		    lblNumAntrianLok2.BackColor = Color.Silver;
		    lblNumAntrianLok3.BackColor = Color.Silver;
		    lblNumAntrianLok1.ForeColor = Color.White;
		    lblNumAntrianLok2.ForeColor = Color.Black;
		    lblNumAntrianLok3.ForeColor = Color.Black;
        }

        void BtnCallLok2Click(object sender, EventArgs e) //LOKET B1
        {
            int no = lastCallB1;
            SetFontAntrianDefault();
		    lblNumAntrian.Text = "B" + no.ToString("000");
		    lblNumLoket.Text = "PELAYANAN SLIK 1";
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = true));
			});
			//soundQueue.Add(() => PlayBell_InSound());
			soundQueue.Add(() => PlayBell_Sound());
			soundQueue.Add(() => PlayCallB1(no, 1));
		    //soundQueue.Add(() => PlayBell_OutSound());
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = false));
			});
			DisabledZeroNumberAntrian();
		    SaveState();
		    CheckLimitButtons();
		    lblNumAntrianLok1.BackColor = Color.Silver;
		    lblNumAntrianLok2.BackColor = Color.Red;
		    lblNumAntrianLok3.BackColor = Color.Silver;
		    lblNumAntrianLok1.ForeColor = Color.Black;
		    lblNumAntrianLok2.ForeColor = Color.White;
		    lblNumAntrianLok3.ForeColor = Color.Black;
        }

        void BtnCallLok3Click(object sender, EventArgs e) //LOKET B2
        {
            int no = lastCallB2;
            SetFontAntrianDefault();
		    lblNumAntrian.Text = "B" + no.ToString("000");
		    lblNumLoket.Text = "PELAYANAN SLIK 2";
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = true));
			});
			//soundQueue.Add(() => PlayBell_InSound());
			soundQueue.Add(() => PlayBell_Sound());
			soundQueue.Add(() => PlayCallB2(no, 2));
		    //soundQueue.Add(() => PlayBell_OutSound());
			soundQueue.Add(() => {
				this.Invoke(new Action(() => WMPPlayer.MediaPlayer.Mute = false));
			});
			DisabledZeroNumberAntrian();
		    SaveState();
		    CheckLimitButtons();
		    lblNumAntrianLok1.BackColor = Color.Silver;
		    lblNumAntrianLok2.BackColor = Color.Silver;
		    lblNumAntrianLok3.BackColor = Color.Red;
		    lblNumAntrianLok1.ForeColor = Color.Black;
		    lblNumAntrianLok2.ForeColor = Color.Black;
		    lblNumAntrianLok3.ForeColor = Color.White;
        }
		void Timer1Tick(object sender, EventArgs e)
		{
			var lokal = new CultureInfo("id-ID");
			string tanggal = DateTime.Now.ToString("dddd, dd MMMM yyyy",lokal);
			string jamDigital = DateTime.Now.ToString("HH:mm:ss", lokal); // format 24 jam
			TimeSpan now = DateTime.Now.TimeOfDay;
		    // Jika jam 12 siang
		    if (now >= TimeSpan.Parse("08:00:00") && now < TimeSpan.Parse("12:00:00")){
		    	lblRun.Text = "SELAMAT PAGI DAN SELAMAT DATANG DI OTORITAS JASA KEUANGAN KANTOR PROVINSI SULAWESI SELATAN DAN SULAWESI BARAT";
		    }
		    else if (now >= TimeSpan.Parse("12:00:00") && now < TimeSpan.Parse("13:30:00"))
		    {
		    	lblNumAntrian.Text = "LOKET SEDANG ISTIRAHAT";
		    	lblNumAntrian.Font = new Font(lblNumAntrian.Font.FontFamily, 30, FontStyle.Bold);
		    	btnNextLok1.Enabled = false;
		        btnNextLok2.Enabled = false;
		        btnNextLok3.Enabled = false;
		        lblRun.Text = "PELAYANAN LOKET SAAT INI SEDANG ISTIRAHAT, " +
		        	"TERIMA KASIH ATAS PERHATIANNYA, SILAHKAN KEMBALI LAGI KETIKA JAM ISTIRAHAT BERAKHIR";
		    }
		    else if (now >= TimeSpan.Parse("13:30:00") && now < TimeSpan.Parse("15:00:00")){
		    	lblRun.Text = "SELAMAT SIANG DAN SELAMAT DATANG DI OTORITAS JASA KEUANGAN KANTOR PROVINSI SULAWESI SELATAN DAN SULAWESI BARAT";
		    	SetFontAntrianDefault();
		    }
		    else if (now >= TimeSpan.Parse("15:00:00") && now < TimeSpan.Parse("18:00:00")){
		    	lblRun.Text = "SELAMAT SORE DAN SELAMAT DATANG DI OTORITAS JASA KEUANGAN KANTOR PROVINSI SULAWESI SELATAN DAN SULAWESI BARAT";
		    	SetFontAntrianDefault();
		    }
		    else if (now >= TimeSpan.Parse("18:00:00") && now < TimeSpan.Parse("21:00:00")){
		    	lblRun.Text = "SELAMAT MALAM DAN SELAMAT DATANG DI OTORITAS JASA KEUANGAN KANTOR PROVINSI SULAWESI SELATAN DAN SULAWESI BARAT";
		    	SetFontAntrianDefault();
		    }
			txtTanggal.Text = tanggal;
			txtTime.Text = jamDigital;
			RefreshState();
		}
		void RefreshState()
		{
		    try
		    {
		        if (!File.Exists(stateFile)) return;
		        string json = File.ReadAllText(stateFile);
		        var diskState = JsonConvert.DeserializeObject<AntrianState>(json) ?? new AntrianState();
		        // ambil nilai dari file (guard null dengan 0)
		        int fileLastA = diskState.LastA;
		        int fileLastB = diskState.LastB;
		        int fileLastCallA = diskState.LastCallA;
		        int fileLastCallB1 = diskState.LastCallB1;
		        int fileLastCallB2 = diskState.LastCallB2;
		        int fileLastTicketA = diskState.LastTicketA;
		        int fileLastTicketB = diskState.LastTicketB;
		        // update variabel lokal (jangan overwrite file dengan nol, hanya assign dari file)
		        globalLastA = fileLastA;
		        globalLastB = fileLastB;
		        lastCallA = fileLastCallA;
		        lastCallB1 = fileLastCallB1;
		        lastCallB2 = fileLastCallB2;
		        lastTicketA = fileLastTicketA;
		        lastTicketB = fileLastTicketB;
		        // update UI di thread UI
		        this.BeginInvoke((Action)(() =>
		        {
		            lblNumAntrianLok1.Text = "A" + lastCallA.ToString("000");
		            lblNumAntrianLok2.Text = "B" + lastCallB1.ToString("000");
		            lblNumAntrianLok3.Text = "B" + lastCallB2.ToString("000");
		            DisabledZeroNumberAntrian();
		            CheckLimitButtons();
		        }));
		    }
		    catch {}
		}
		void DisplayLoad(object sender, EventArgs e)
		{
			setVolume.Value = 50;
			WMPPlayer.MediaPlayer.Volume = 50;
			timer1.Interval = 1000;    // sekian detik (atur sendiri: 1000..10000)
		    timer1.Tick += (s, ev) =>
		    {
		        RefreshState();      // baca file dan update UI
		        CheckLimitButtons(); // dipanggil di RefreshState via BeginInvoke
		    };
		    timer1.Start();
		    LoadSettings();
			if (!string.IsNullOrEmpty(settings.VideoURL))
			{
				var media = new Media(libVLC, settings.VideoURL);
				media.AddOption(":input-repeat=65535"); // opsi loop praktis infinite
				WMPPlayer.MediaPlayer.Play(media);
			}
			WMPPlayer.MediaPlayer.Mute = false;
		}
		void LoadSettings()
		{
			settings = new AppSettings();
		    if (!File.Exists(settingsFile)) return;
		    try
		    {
		        string[] lines = File.ReadAllLines(settingsFile);
		        foreach (string line in lines)
		        {
		            if (line.StartsWith("VideoURL=")) settings.VideoURL = line.Substring("VideoURL=".Length).Trim();
		        }
		    }
		    catch{}
		}
		void DisplayFormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (WMPPlayer.MediaPlayer != null)
				{
					WMPPlayer.MediaPlayer.Stop();
					WMPPlayer.MediaPlayer.Dispose();
					soundQueue.Dispose();
				}
			}
			catch {}
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void SetVolumeScroll(object sender, EventArgs e)
		{
			try
			{
				if (WMPPlayer != null && WMPPlayer.MediaPlayer !=null){
					WMPPlayer.MediaPlayer.Volume = setVolume.Value;
				}
			}
			catch{}
		}
		void SetFontAntrianDefault(){
			lblNumAntrian.Font = new Font(lblNumAntrian.Font.FontFamily, 130, FontStyle.Bold);
			btnNextLok1.Enabled = true;
		    btnNextLok2.Enabled = true;
		    btnNextLok3.Enabled = true;
		}
		void RunningText(){
			marqueeX = this.Width; // mulai dari luar kanan form
		    lblRun.Left = marqueeX;
		    timerMarquee.Interval = 15; // lumayan smooth
		    timerMarquee.Start();
		}
		void TimerMarqueeTick(object sender, EventArgs e)
		{
			marqueeX -= marqueeSpeed;
		    lblRun.Left = marqueeX;
		    // kalau sudah hilang dari layar, ulang lagi dari kanan
		    if (lblRun.Right < 0)
		    {
		        marqueeX = Width;
		    }
		}	
    }
}