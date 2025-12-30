using System;
using System.Linq;
using System.Windows.Forms;

namespace antrian_loket
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
            timer1.Start();
        }
		void Timer1Tick(object sender, EventArgs e)
		{
			string tahun = DateTime.Now.ToString("yyyy");
			label1.Text = "Hak Cipta © 2024-"+tahun+" Otoritas Jasa Keuangan \nDikembangkan oleh PT. Ersal Integra Karya ";
		}
		void Exit(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) this.Close();
		}
    }
}
