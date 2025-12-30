/*
 * Created by SharpDevelop.
 * User: Advan
 * Date: 21/11/2025
 * Time: 19.52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace antrian_loket
{
	partial class etiket_antrian
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCetakPengaduan;
		private System.Windows.Forms.Button btnCetakSlik;
		private System.Windows.Forms.PictureBox pcLogoOJK;
		private System.Windows.Forms.Label txtTime;
		private System.Windows.Forms.Label txtTanggal;
		private System.Windows.Forms.Timer timer1;
		private System.Drawing.Printing.PrintDocument pd;
		private System.Windows.Forms.Button btnPrinter;
		private System.Windows.Forms.ToolTip toolTipPrinter;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.ToolTip toolTipAbout;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(etiket_antrian));
			this.label1 = new System.Windows.Forms.Label();
			this.btnCetakPengaduan = new System.Windows.Forms.Button();
			this.btnCetakSlik = new System.Windows.Forms.Button();
			this.pcLogoOJK = new System.Windows.Forms.PictureBox();
			this.txtTime = new System.Windows.Forms.Label();
			this.txtTanggal = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pd = new System.Drawing.Printing.PrintDocument();
			this.btnPrinter = new System.Windows.Forms.Button();
			this.toolTipPrinter = new System.Windows.Forms.ToolTip(this.components);
			this.btnAbout = new System.Windows.Forms.Button();
			this.toolTipAbout = new System.Windows.Forms.ToolTip(this.components);
			this.labelFooter = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.panelLoketSlikB = new System.Windows.Forms.Panel();
			this.panelLoketPengaduan = new System.Windows.Forms.Panel();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.lblStatus = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pcLogoOJK)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.panelLoketSlikB.SuspendLayout();
			this.panelLoketPengaduan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 247);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(1900, 199);
			this.label1.TabIndex = 0;
			this.label1.Text = "SELAMAT DATANG DI E-TIKET ANTRIAN CONSOLE\r\nOJK SULSELBAR";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnCetakPengaduan
			// 
			this.btnCetakPengaduan.BackColor = System.Drawing.Color.DarkRed;
			this.btnCetakPengaduan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCetakPengaduan.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCetakPengaduan.ForeColor = System.Drawing.Color.White;
			this.btnCetakPengaduan.Location = new System.Drawing.Point(0, 0);
			this.btnCetakPengaduan.Name = "btnCetakPengaduan";
			this.btnCetakPengaduan.Size = new System.Drawing.Size(1526, 179);
			this.btnCetakPengaduan.TabIndex = 1;
			this.btnCetakPengaduan.Text = "LOKET PENGADUAN (A)   ";
			this.btnCetakPengaduan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCetakPengaduan.UseVisualStyleBackColor = false;
			this.btnCetakPengaduan.Click += new System.EventHandler(this.BtnCetakPengaduanClick);
			// 
			// btnCetakSlik
			// 
			this.btnCetakSlik.BackColor = System.Drawing.Color.DarkRed;
			this.btnCetakSlik.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCetakSlik.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCetakSlik.ForeColor = System.Drawing.Color.White;
			this.btnCetakSlik.Location = new System.Drawing.Point(0, 0);
			this.btnCetakSlik.Name = "btnCetakSlik";
			this.btnCetakSlik.Size = new System.Drawing.Size(1526, 175);
			this.btnCetakSlik.TabIndex = 2;
			this.btnCetakSlik.Text = "LOKET SLIK (B)   ";
			this.btnCetakSlik.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCetakSlik.UseVisualStyleBackColor = false;
			this.btnCetakSlik.Click += new System.EventHandler(this.BtnCetakSlikClick);
			// 
			// pcLogoOJK
			// 
			this.pcLogoOJK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.pcLogoOJK.Image = ((System.Drawing.Image)(resources.GetObject("pcLogoOJK.Image")));
			this.pcLogoOJK.Location = new System.Drawing.Point(12, 12);
			this.pcLogoOJK.Name = "pcLogoOJK";
			this.pcLogoOJK.Size = new System.Drawing.Size(1900, 232);
			this.pcLogoOJK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pcLogoOJK.TabIndex = 21;
			this.pcLogoOJK.TabStop = false;
			// 
			// txtTime
			// 
			this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTime.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTime.Location = new System.Drawing.Point(943, 996);
			this.txtTime.Name = "txtTime";
			this.txtTime.Size = new System.Drawing.Size(969, 93);
			this.txtTime.TabIndex = 26;
			this.txtTime.Text = "[[Time.Now]]";
			this.txtTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtTanggal
			// 
			this.txtTanggal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTanggal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTanggal.Location = new System.Drawing.Point(943, 930);
			this.txtTanggal.Name = "txtTanggal";
			this.txtTanggal.Size = new System.Drawing.Size(969, 66);
			this.txtTanggal.TabIndex = 25;
			this.txtTanggal.Text = "[[Date.Now]]";
			this.txtTanggal.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// btnPrinter
			// 
			this.btnPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrinter.BackColor = System.Drawing.Color.LightGray;
			this.btnPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnPrinter.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPrinter.ForeColor = System.Drawing.Color.DarkRed;
			this.btnPrinter.Location = new System.Drawing.Point(1817, 1092);
			this.btnPrinter.Name = "btnPrinter";
			this.btnPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnPrinter.Size = new System.Drawing.Size(95, 66);
			this.btnPrinter.TabIndex = 27;
			this.btnPrinter.Text = "";
			this.toolTipPrinter.SetToolTip(this.btnPrinter, "Choose Your Printer Default");
			this.btnPrinter.UseVisualStyleBackColor = false;
			this.btnPrinter.Click += new System.EventHandler(this.BtnPrinterClick);
			// 
			// toolTipPrinter
			// 
			this.toolTipPrinter.BackColor = System.Drawing.Color.DarkRed;
			this.toolTipPrinter.ForeColor = System.Drawing.Color.White;
			this.toolTipPrinter.IsBalloon = true;
			this.toolTipPrinter.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.toolTipPrinter.ToolTipTitle = "Select Printer";
			// 
			// btnAbout
			// 
			this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAbout.BackColor = System.Drawing.Color.DarkRed;
			this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAbout.Font = new System.Drawing.Font("Segoe UI Symbol", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAbout.ForeColor = System.Drawing.Color.White;
			this.btnAbout.Location = new System.Drawing.Point(1732, 1092);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(79, 66);
			this.btnAbout.TabIndex = 28;
			this.btnAbout.Text = "";
			this.toolTipAbout.SetToolTip(this.btnAbout, "About This Apps Developer");
			this.btnAbout.UseVisualStyleBackColor = false;
			this.btnAbout.Click += new System.EventHandler(this.BtnAboutClick);
			// 
			// toolTipAbout
			// 
			this.toolTipAbout.BackColor = System.Drawing.Color.DarkRed;
			this.toolTipAbout.ForeColor = System.Drawing.Color.White;
			this.toolTipAbout.IsBalloon = true;
			this.toolTipAbout.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.toolTipAbout.ToolTipTitle = "About Us";
			// 
			// labelFooter
			// 
			this.labelFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelFooter.AutoSize = true;
			this.labelFooter.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFooter.ForeColor = System.Drawing.Color.DarkRed;
			this.labelFooter.Location = new System.Drawing.Point(12, 1120);
			this.labelFooter.Name = "labelFooter";
			this.labelFooter.Size = new System.Drawing.Size(1120, 38);
			this.labelFooter.TabIndex = 29;
			this.labelFooter.Text = "© 2024 Otoritas Jasa Keuangan Kantor Provinsi Sulawesi Selatan dan Sulawesi Barat" +
	"";
			this.labelFooter.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.BackColor = System.Drawing.Color.DarkRed;
			this.buttonClose.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonClose.ForeColor = System.Drawing.SystemColors.Control;
			this.buttonClose.Location = new System.Drawing.Point(1849, 12);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(63, 64);
			this.buttonClose.TabIndex = 30;
			this.buttonClose.Text = "⏻";
			this.buttonClose.UseVisualStyleBackColor = false;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.pictureBox1.BackColor = System.Drawing.Color.DarkRed;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(17, 18);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(144, 137);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 31;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.pictureBox2.BackColor = System.Drawing.Color.DarkRed;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(17, 19);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(144, 138);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 32;
			this.pictureBox2.TabStop = false;
			// 
			// panelLoketSlikB
			// 
			this.panelLoketSlikB.Controls.Add(this.pictureBox2);
			this.panelLoketSlikB.Controls.Add(this.btnCetakSlik);
			this.panelLoketSlikB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLoketSlikB.Location = new System.Drawing.Point(0, 0);
			this.panelLoketSlikB.Name = "panelLoketSlikB";
			this.panelLoketSlikB.Size = new System.Drawing.Size(1526, 175);
			this.panelLoketSlikB.TabIndex = 33;
			// 
			// panelLoketPengaduan
			// 
			this.panelLoketPengaduan.Controls.Add(this.pictureBox1);
			this.panelLoketPengaduan.Controls.Add(this.btnCetakPengaduan);
			this.panelLoketPengaduan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLoketPengaduan.Location = new System.Drawing.Point(0, 0);
			this.panelLoketPengaduan.Name = "panelLoketPengaduan";
			this.panelLoketPengaduan.Size = new System.Drawing.Size(1526, 179);
			this.panelLoketPengaduan.TabIndex = 34;
			// 
			// splitContainer
			// 
			this.splitContainer.Location = new System.Drawing.Point(119, 487);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.panelLoketPengaduan);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.panelLoketSlikB);
			this.splitContainer.Size = new System.Drawing.Size(1526, 358);
			this.splitContainer.SplitterDistance = 179;
			this.splitContainer.TabIndex = 35;
			// 
			// lblStatus
			// 
			this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(12, 12);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(522, 36);
			this.lblStatus.TabIndex = 36;
			this.lblStatus.Text = "Status : Lokal";
			// 
			// etiket_antrian
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 1170);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.labelFooter);
			this.Controls.Add(this.btnAbout);
			this.Controls.Add(this.btnPrinter);
			this.Controls.Add(this.pcLogoOJK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtTanggal);
			this.Controls.Add(this.txtTime);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1015, 686);
			this.Name = "etiket_antrian";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "E-TIKET ANTRIAN CONSOLE";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Etiket_antrianLoad);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShortcutKey);
			((System.ComponentModel.ISupportInitialize)(this.pcLogoOJK)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.panelLoketSlikB.ResumeLayout(false);
			this.panelLoketPengaduan.ResumeLayout(false);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        private System.Windows.Forms.Label labelFooter;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelLoketSlikB;
        private System.Windows.Forms.Panel panelLoketPengaduan;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblStatus;
    }
}
