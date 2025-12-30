using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Globalization;
using Newtonsoft.Json;

namespace antrian_loket
{
	public partial class etiket_antrian : Form
	{
		
		//aktifkan ini jika file database antriannya standalone atau lokal di satu PC
		readonly string stateFile = Path.Combine(Application.StartupPath, "state.json");
		
		//aktifkan ini jika file databasenya berada di PC lain pada satu jaringan yang sama
		//readonly string stateFile = @"\\DESKTOP-LRKI6GJ\Documents\antrian_loket\bin\Release\state.json";

		
		readonly string printerFile = Path.Combine(Application.StartupPath, "printer.cfg");
		AntrianState state;
		string selectedPrinter;    
        int lastA;
		int lastB;
		int lastCallA;
		int lastCallB1;
		int lastCallB2;
		int lastTicketA;
		int lastTicketB;
		string nomorCetak;
		Image logoCetak;
		
		public etiket_antrian()
		{
			InitializeComponent();
			LoadState();
			this.KeyPreview = true;
			LoadPrinterConfig();	
		}
		
		void CheckConnection()
		{
		    try
		    {
		        // coba akses shared file
		        if (File.Exists(stateFile))
		        {
		            lblStatus.Text = "Status : Online";
		            lblStatus.ForeColor = Color.LimeGreen;
		            btnCetakSlik.Enabled = true;
		            btnCetakPengaduan.Enabled = true;
		        }
		        else
		        {
		            lblStatus.Text = "Status : Offline";
		            lblStatus.ForeColor = Color.Red;
		            btnCetakSlik.Enabled = false;
		            btnCetakPengaduan.Enabled = false;
		        }
		    }
		    catch
		    {
		        lblStatus.Text = "Status : Offline";
		        lblStatus.ForeColor = Color.Red;
		        btnCetakSlik.Enabled = false;
		        btnCetakPengaduan.Enabled = false;
		    }
		}

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
		private void LoadState()
	    {
	        try
	        {
	            if (File.Exists(stateFile))
	            {
	                string json = File.ReadAllText(stateFile);
	                state = JsonConvert.DeserializeObject<AntrianState>(json);
	            }
	            else { state = new AntrianState(); }
	        }
	        catch { state = new AntrianState();}// fallback aman
	
	        string today = DateTime.Now.ToString("yyyy-MM-dd");
			// Reset harian
	        if (state.LastUpdatedDate != today)
	        {
	            state.LastUpdatedDate = today;
	            state.LastA = 1;
	            state.LastB = 1;
	            state.LastCallA = 1;
	            state.LastCallB1 = 1;
	            state.LastCallB2 = 0;
	            state.LastTicketA = 0;
	            state.LastTicketB = 0;
	            SaveState();
	        }
	    }
		void SaveOnlyTicket()
		{
		    try
		    {
		        var fileState = File.Exists(stateFile)
		            ? JsonConvert.DeserializeObject<AntrianState>(File.ReadAllText(stateFile))
		            : new AntrianState();
		        // hanya update ini
		        fileState.LastTicketA = state.LastTicketA;
		        fileState.LastTicketB = state.LastTicketB;
		        // tulis kembali
		        File.WriteAllText(stateFile, JsonConvert.SerializeObject(fileState, Formatting.Indented));
		    }
		    catch { }
		}

		void SaveState()
	    {
	        try
	        {
	            string json = JsonConvert.SerializeObject(state, Formatting.Indented);
	            File.WriteAllText(stateFile, json);
	        }
	        catch { }
	    }
		void Timer1Tick(object sender, EventArgs e)
		{
			var lokal = new CultureInfo("id-ID");
			string tanggal = DateTime.Now.ToString("dddd, dd MMMM yyyy", lokal);
			string jamDigital = DateTime.Now.ToString("HH:mm:ss", lokal); // format 24 jam
			string tahun = DateTime.Now.ToString("yyyy");
			txtTanggal.Text = tanggal;
			txtTime.Text = jamDigital;
			labelFooter.Text = "© "+tahun+" Otoritas Jasa Keuangan Kantor Provinsi Sulawesi Selatan dan Sulawesi Barat";
			//aktifkan jika mau gunakan fitur antar PC via LAN
			CheckConnection();
		}
		void Etiket_antrianLoad(object sender, EventArgs e)
		{
			timer1.Start(); // menampilkan jam real-time saat pengambilan karcis e-tiket
		}
		void BtnCetakSlikClick(object sender, EventArgs e)
		{
			state.LastTicketB++;   // isi karcis terakhir diambil
			SaveOnlyTicket();
		    string nomor = "B" + state.LastTicketB.ToString("000");
		    CetakTiket(nomor);
		}
		void BtnCetakPengaduanClick(object sender, EventArgs e)
		{
			state.LastTicketA++;   // isi karcis terakhir diambil
			SaveOnlyTicket();
		    string nomor = "A" + state.LastTicketA.ToString("000");
		    CetakTiket(nomor);
		}
		void CetakTiket(string nomor)
		{
			if (string.IsNullOrEmpty(selectedPrinter))
            {
                MessageBox.Show("Please Select Your Printer Device!", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
			var lokal = new CultureInfo("id-ID");
		    Image logo = pcLogoOJK.Image;
		    PrintDocument pd = new PrintDocument();
		    pd.PrinterSettings.PrinterName = selectedPrinter;
		    LoadState();
		    
		    int sisaA = state.LastTicketA - state.LastCallA;
			int sisaB = state.LastTicketB - Math.Max(state.LastCallB1, state.LastCallB2);
		
		    pd.PrintPage += (s, e) =>
		    {
		        Graphics g = e.Graphics;
		
		        // Fonts
		        Font fontAlamat = new Font("Arial", 7, FontStyle.Regular);
		        Font fontHeader = new Font("Arial", 16, FontStyle.Bold);
		        Font fontNomor = new Font("Arial", 48, FontStyle.Bold);
		        Font fontInfo = new Font("Arial", 10, FontStyle.Regular);
		
		        float y = 10;
		        float pageWidth = e.PageBounds.Width;
		
		        // Format center align
		        StringFormat center = new StringFormat();
		        center.Alignment = StringAlignment.Center;
		
		        // 1. Logo (center)
		        if (logo != null)
		        {
		            int logoWidth = 120;
		            int logoHeight = (int)(((float)logo.Height / logo.Width) * logoWidth);
		            int posX = (int)((pageWidth - logoWidth) / 2);
		
		            g.DrawImage(logo, new Rectangle(posX, (int)y, logoWidth, logoHeight));
		            y += logoHeight + 10;
		        }
		
		        // 2. Alamat
		        string alamat =
		            "Kantor Provinsi Sulawesi Selatan dan Sulawesi Barat\n" +
		            "Jalan Sultan Hasanuddin No. 3-5, Makassar";
		
		        g.DrawString(alamat, fontAlamat, Brushes.Black, new RectangleF(0, y, pageWidth, 30), center);
		        y += 40;
		
		        // 3. Header
		        g.DrawString("NOMOR ANTRIAN", fontHeader, Brushes.Black, 
		            new RectangleF(0, y, pageWidth, 30), center);
		        y += 45;
		
		        // 4. Nomor besar
		        g.DrawString(nomor, fontNomor, Brushes.Black,
		            new RectangleF(0, y, pageWidth, 60), center);
		        y += 80;
		
		        // 5. Tanggal
		        g.DrawString(DateTime.Now.ToString("dddd, dd MMMM yyyy", lokal), fontInfo, Brushes.Black,
		            new RectangleF(0, y, pageWidth, 20), center);
		        y += 20;
		
		        // 6. Waktu
		        g.DrawString(DateTime.Now.ToString("HH:mm:ss", lokal), fontInfo, Brushes.Black,
		            new RectangleF(0, y, pageWidth, 20), center);
		        // 7. Footer sisa antrian
				string footer = "";
				
				if (nomor.StartsWith("A"))
				{
				    footer = "Sisa nomor antrian yang belum dilayani: "+sisaA+" orang";
				}
				else if (nomor.StartsWith("B"))
				{
				    footer = "Sisa nomor antrian yang belum dilayani: "+sisaB+" orang";
				}
				
				y += 25;
				g.DrawString(footer, fontAlamat, Brushes.Black,
				    new RectangleF(0, y, pageWidth, 20), center);
				
				string dukungan = "Powered by PT. Ersal Integra Karya";
				
				y += 25;
				g.DrawString(dukungan, fontAlamat, Brushes.Black,
				    new RectangleF(0, y, pageWidth, 20), center);
			}; pd.Print();
		    //SaveOnlyTicket();
		}
		void ShortcutKey(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) buttonClose.PerformClick();
		}
		void BtnPrinterClick(object sender, EventArgs e)
		{
			using (var frm = new printer()) { frm.ShowDialog(); }
			LoadPrinterConfig();
		}
		void LoadPrinterConfig()
		{
		    selectedPrinter = "";
		
		    if (!File.Exists(printerFile))
		        return;
		    try
		    {
		        string[] lines = File.ReadAllLines(printerFile);
		
		        foreach (string line in lines)
		        {
		            if (line.StartsWith("SelectedPrinter="))
		            {
		                selectedPrinter = line.Substring("SelectedPrinter=".Length).Trim();
		            }
		        }
		    }
		    catch
		    {
		        selectedPrinter = "";
		    }
		}
		void BtnAboutClick(object sender, EventArgs e)
		{
			AboutUs about = new AboutUs();
			about.ShowDialog();
		}
		void ButtonCloseClick(object sender, EventArgs e)  {
			//Application.Exit();
			this.Close(); // aktifkan jika berada di mode aplikasi utama (MainForm)
		}
	}
}