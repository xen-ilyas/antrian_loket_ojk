using System;
using System.Windows.Forms;
using System.Globalization;

namespace antrian_loket
{
	public partial class MainForm : Form
	{
		etiket_antrian consoleForm;
		public MainForm() 
		{ 
			InitializeComponent();

            //* -- aktifkan khusus jika langsung ingin menampilkan display -- *//
            //display_antrian dp = new display_antrian(this);
            //this.Hide(); // aktifkan jika aplikasi sudah final beres
            //dp.ShowDialog(); // aktifkan jika aplikasi sudah final beres

            //* -- aktifkan khusus jika ingin langsung ke console e-tiket --*//
			//consoleForm = new etiket_antrian();
			//this.Hide();
			//consoleForm.ShowDialog();
			
		}
		public void BtnDisplayClick(object sender, EventArgs e)
		{
			display_antrian dp = new display_antrian(this);
			this.Hide(); // aktifkan jika aplikasi sudah final beres
			dp.ShowDialog(); // aktifkan jika aplikasi sudah final beres
			
		}
		void BtnConsoleClick(object sender, EventArgs e)
		{
			consoleForm = new etiket_antrian();
		    consoleForm.ShowDialog();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			var lokal = new CultureInfo("id-ID");
			string tanggal = DateTime.Now.ToString("dddd, dd MMMM yyyy",lokal);
			string jamDigital = DateTime.Now.ToString("HH:mm:ss", lokal); // format 24 jam
			txtTanggal.Text = tanggal;
			txtTime.Text = jamDigital;
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			timer1.Start();
		}

        private void administratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
			administrator admin = new administrator();
			admin.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
			AboutUs about = new AboutUs();
			about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }
    }
}
