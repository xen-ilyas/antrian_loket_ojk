using System;
using System.IO;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace antrian_loket
{
	public partial class printer : Form
	{
		string configPath = "printer.cfg";
	    public class PrinterConfig
	    {
	        public string SelectedPrinter { get; set; }
	    }
		public printer()
		{
			InitializeComponent();
			LoadPrinters();
        	LoadConfig();
		}
		void LoadPrinters()
	    {
	        cmbPrinters.Items.Clear();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cmbPrinters.Items.Add(printer);
            }
	    }
		void LoadConfig()
	    {
	        if (!File.Exists(configPath)) return;

            try
            {
                string line = File.ReadAllText(configPath).Trim();

                if (line.StartsWith("SelectedPrinter="))
                {
                    string selected = line.Substring("SelectedPrinter=".Length).Trim();

                    if (!string.IsNullOrEmpty(selected))
                    {
                        cmbPrinters.SelectedItem = selected;
                    }
                }
            }
            catch
            {
            	
            }
	    }
		void SaveConfig()
	    {
	        string selected = cmbPrinters.SelectedItem != null
                ? cmbPrinters.SelectedItem.ToString()
                : "";

            string content = "SelectedPrinter=" + selected;

            File.WriteAllText(configPath, content);
	    }
		void BtnAcceptClick(object sender, EventArgs e)
		{
			if (cmbPrinters.SelectedItem == null)
	        {
	            MessageBox.Show("Silakan pilih printer dulu.");
	            return;
	        }
	
	        SaveConfig();
	        DialogResult = DialogResult.OK;
	        Close();
		}
		void BtnCancelClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
        	Close();
		}
	}
}
