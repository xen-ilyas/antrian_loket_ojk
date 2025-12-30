/*
 * Created by SharpDevelop.
 * User: Advan
 * Date: 11/11/2025
 * Time: 20.58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace antrian_loket
{
	partial class display_antrian
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblNumLoket;
		private System.Windows.Forms.Button btnCallLok1;
		private System.Windows.Forms.Button btnCallLok2;
		private System.Windows.Forms.Button btnCallLok3;
		private System.Windows.Forms.Button btnNextLok1;
		private System.Windows.Forms.Button btnNextLok2;
		private System.Windows.Forms.Button btnNextLok3;
		private System.Windows.Forms.Button btnBackLok3;
		private System.Windows.Forms.Button btnBackLok2;
		private System.Windows.Forms.Button btnBackLok1;
		private System.Windows.Forms.Label lblNumAntrianLok1;
		private System.Windows.Forms.Label lblNumAntrianLok2;
		private System.Windows.Forms.Label lblNumAntrianLok3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblNumAntrian;
		private System.Windows.Forms.PictureBox pcLogoOJK;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label txtTanggal;
		private System.Windows.Forms.Label txtTime;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel Mainpanel;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(display_antrian));
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumLoket = new System.Windows.Forms.Label();
            this.btnCallLok1 = new System.Windows.Forms.Button();
            this.btnCallLok2 = new System.Windows.Forms.Button();
            this.btnCallLok3 = new System.Windows.Forms.Button();
            this.btnNextLok1 = new System.Windows.Forms.Button();
            this.btnNextLok2 = new System.Windows.Forms.Button();
            this.btnNextLok3 = new System.Windows.Forms.Button();
            this.btnBackLok3 = new System.Windows.Forms.Button();
            this.btnBackLok2 = new System.Windows.Forms.Button();
            this.btnBackLok1 = new System.Windows.Forms.Button();
            this.lblNumAntrianLok1 = new System.Windows.Forms.Label();
            this.lblNumAntrianLok2 = new System.Windows.Forms.Label();
            this.lblNumAntrianLok3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNumAntrian = new System.Windows.Forms.Label();
            this.pcLogoOJK = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTanggal = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Mainpanel = new System.Windows.Forms.Panel();
            this.WMPPlayer = new LibVLCSharp.WinForms.VideoView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.setVolume = new System.Windows.Forms.TrackBar();
            this.buttonClose = new System.Windows.Forms.Button();
            this.lblRun = new System.Windows.Forms.Label();
            this.timerMarquee = new System.Windows.Forms.Timer(this.components);
            this.panelRunText = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogoOJK)).BeginInit();
            this.Mainpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WMPPlayer)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setVolume)).BeginInit();
            this.panelRunText.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1365, 798);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 47);
            this.label3.TabIndex = 3;
            this.label3.Text = "KE LOKET";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNumLoket
            // 
            this.lblNumLoket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumLoket.BackColor = System.Drawing.Color.Transparent;
            this.lblNumLoket.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumLoket.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNumLoket.Location = new System.Drawing.Point(576, 845);
            this.lblNumLoket.Name = "lblNumLoket";
            this.lblNumLoket.Size = new System.Drawing.Size(1078, 147);
            this.lblNumLoket.TabIndex = 4;
            this.lblNumLoket.Text = "...";
            this.lblNumLoket.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCallLok1
            // 
            this.btnCallLok1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCallLok1.BackColor = System.Drawing.Color.Yellow;
            this.btnCallLok1.Font = new System.Drawing.Font("Segoe Fluent Icons", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallLok1.Location = new System.Drawing.Point(123, 1017);
            this.btnCallLok1.Name = "btnCallLok1";
            this.btnCallLok1.Size = new System.Drawing.Size(83, 69);
            this.btnCallLok1.TabIndex = 5;
            this.btnCallLok1.Text = "";
            this.btnCallLok1.UseVisualStyleBackColor = false;
            this.btnCallLok1.Click += new System.EventHandler(this.BtnCallLok1Click);
            // 
            // btnCallLok2
            // 
            this.btnCallLok2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCallLok2.BackColor = System.Drawing.Color.Yellow;
            this.btnCallLok2.Font = new System.Drawing.Font("Segoe Fluent Icons", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallLok2.Location = new System.Drawing.Point(478, 1017);
            this.btnCallLok2.Name = "btnCallLok2";
            this.btnCallLok2.Size = new System.Drawing.Size(83, 69);
            this.btnCallLok2.TabIndex = 6;
            this.btnCallLok2.Text = "";
            this.btnCallLok2.UseVisualStyleBackColor = false;
            this.btnCallLok2.Click += new System.EventHandler(this.BtnCallLok2Click);
            // 
            // btnCallLok3
            // 
            this.btnCallLok3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCallLok3.BackColor = System.Drawing.Color.Yellow;
            this.btnCallLok3.Font = new System.Drawing.Font("Segoe Fluent Icons", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallLok3.Location = new System.Drawing.Point(774, 1017);
            this.btnCallLok3.Name = "btnCallLok3";
            this.btnCallLok3.Size = new System.Drawing.Size(83, 69);
            this.btnCallLok3.TabIndex = 7;
            this.btnCallLok3.Text = "";
            this.btnCallLok3.UseVisualStyleBackColor = false;
            this.btnCallLok3.Click += new System.EventHandler(this.BtnCallLok3Click);
            // 
            // btnNextLok1
            // 
            this.btnNextLok1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNextLok1.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNextLok1.Font = new System.Drawing.Font("Segoe Fluent Icons", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextLok1.Location = new System.Drawing.Point(212, 1017);
            this.btnNextLok1.Name = "btnNextLok1";
            this.btnNextLok1.Size = new System.Drawing.Size(100, 69);
            this.btnNextLok1.TabIndex = 8;
            this.btnNextLok1.Text = "";
            this.btnNextLok1.UseVisualStyleBackColor = false;
            this.btnNextLok1.Click += new System.EventHandler(this.BtnNextLok1Click);
            // 
            // btnNextLok2
            // 
            this.btnNextLok2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNextLok2.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNextLok2.Font = new System.Drawing.Font("Segoe Fluent Icons", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextLok2.Location = new System.Drawing.Point(567, 1017);
            this.btnNextLok2.Name = "btnNextLok2";
            this.btnNextLok2.Size = new System.Drawing.Size(100, 69);
            this.btnNextLok2.TabIndex = 9;
            this.btnNextLok2.Text = "";
            this.btnNextLok2.UseVisualStyleBackColor = false;
            this.btnNextLok2.Click += new System.EventHandler(this.BtnNextLok2Click);
            // 
            // btnNextLok3
            // 
            this.btnNextLok3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNextLok3.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNextLok3.Font = new System.Drawing.Font("Segoe Fluent Icons", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextLok3.Location = new System.Drawing.Point(863, 1017);
            this.btnNextLok3.Name = "btnNextLok3";
            this.btnNextLok3.Size = new System.Drawing.Size(100, 69);
            this.btnNextLok3.TabIndex = 10;
            this.btnNextLok3.Text = "";
            this.btnNextLok3.UseVisualStyleBackColor = false;
            this.btnNextLok3.Click += new System.EventHandler(this.BtnNextLok3Click);
            // 
            // btnBackLok3
            // 
            this.btnBackLok3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackLok3.BackColor = System.Drawing.Color.Red;
            this.btnBackLok3.Font = new System.Drawing.Font("Segoe Fluent Icons", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackLok3.ForeColor = System.Drawing.Color.White;
            this.btnBackLok3.Location = new System.Drawing.Point(673, 1017);
            this.btnBackLok3.Name = "btnBackLok3";
            this.btnBackLok3.Size = new System.Drawing.Size(95, 69);
            this.btnBackLok3.TabIndex = 13;
            this.btnBackLok3.Text = "";
            this.btnBackLok3.UseVisualStyleBackColor = false;
            this.btnBackLok3.Click += new System.EventHandler(this.BtnBackLok3Click);
            // 
            // btnBackLok2
            // 
            this.btnBackLok2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackLok2.BackColor = System.Drawing.Color.Red;
            this.btnBackLok2.Font = new System.Drawing.Font("Segoe Fluent Icons", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackLok2.ForeColor = System.Drawing.Color.White;
            this.btnBackLok2.Location = new System.Drawing.Point(377, 1017);
            this.btnBackLok2.Name = "btnBackLok2";
            this.btnBackLok2.Size = new System.Drawing.Size(95, 69);
            this.btnBackLok2.TabIndex = 12;
            this.btnBackLok2.Text = "";
            this.btnBackLok2.UseVisualStyleBackColor = false;
            this.btnBackLok2.Click += new System.EventHandler(this.BtnBackLok2Click);
            // 
            // btnBackLok1
            // 
            this.btnBackLok1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackLok1.BackColor = System.Drawing.Color.Red;
            this.btnBackLok1.Font = new System.Drawing.Font("Segoe Fluent Icons", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackLok1.ForeColor = System.Drawing.Color.White;
            this.btnBackLok1.Location = new System.Drawing.Point(22, 1017);
            this.btnBackLok1.Name = "btnBackLok1";
            this.btnBackLok1.Size = new System.Drawing.Size(95, 69);
            this.btnBackLok1.TabIndex = 11;
            this.btnBackLok1.Text = "";
            this.btnBackLok1.UseVisualStyleBackColor = false;
            this.btnBackLok1.Click += new System.EventHandler(this.BtnBackLok1Click);
            // 
            // lblNumAntrianLok1
            // 
            this.lblNumAntrianLok1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumAntrianLok1.BackColor = System.Drawing.Color.Red;
            this.lblNumAntrianLok1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNumAntrianLok1.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumAntrianLok1.ForeColor = System.Drawing.Color.White;
            this.lblNumAntrianLok1.Location = new System.Drawing.Point(22, 873);
            this.lblNumAntrianLok1.Name = "lblNumAntrianLok1";
            this.lblNumAntrianLok1.Size = new System.Drawing.Size(290, 213);
            this.lblNumAntrianLok1.TabIndex = 14;
            this.lblNumAntrianLok1.Text = "A001";
            this.lblNumAntrianLok1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumAntrianLok2
            // 
            this.lblNumAntrianLok2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumAntrianLok2.BackColor = System.Drawing.Color.Silver;
            this.lblNumAntrianLok2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNumAntrianLok2.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumAntrianLok2.Location = new System.Drawing.Point(377, 873);
            this.lblNumAntrianLok2.Name = "lblNumAntrianLok2";
            this.lblNumAntrianLok2.Size = new System.Drawing.Size(290, 213);
            this.lblNumAntrianLok2.TabIndex = 15;
            this.lblNumAntrianLok2.Text = "B001";
            this.lblNumAntrianLok2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumAntrianLok3
            // 
            this.lblNumAntrianLok3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumAntrianLok3.BackColor = System.Drawing.Color.Silver;
            this.lblNumAntrianLok3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNumAntrianLok3.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumAntrianLok3.Location = new System.Drawing.Point(673, 873);
            this.lblNumAntrianLok3.Name = "lblNumAntrianLok3";
            this.lblNumAntrianLok3.Size = new System.Drawing.Size(290, 213);
            this.lblNumAntrianLok3.TabIndex = 16;
            this.lblNumAntrianLok3.Text = "B001";
            this.lblNumAntrianLok3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 798);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 75);
            this.label6.TabIndex = 17;
            this.label6.Text = "LOKET\r\nPENGADUAN";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(379, 798);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(288, 75);
            this.label7.TabIndex = 18;
            this.label7.Text = "LOKET SLIK 1";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumAntrian
            // 
            this.lblNumAntrian.BackColor = System.Drawing.Color.Crimson;
            this.lblNumAntrian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumAntrian.Font = new System.Drawing.Font("Segoe UI", 130F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumAntrian.ForeColor = System.Drawing.Color.White;
            this.lblNumAntrian.Location = new System.Drawing.Point(3, 99);
            this.lblNumAntrian.Name = "lblNumAntrian";
            this.lblNumAntrian.Size = new System.Drawing.Size(846, 466);
            this.lblNumAntrian.TabIndex = 19;
            this.lblNumAntrian.Text = "A000";
            this.lblNumAntrian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pcLogoOJK
            // 
            this.pcLogoOJK.Image = ((System.Drawing.Image)(resources.GetObject("pcLogoOJK.Image")));
            this.pcLogoOJK.Location = new System.Drawing.Point(22, 9);
            this.pcLogoOJK.Name = "pcLogoOJK";
            this.pcLogoOJK.Size = new System.Drawing.Size(277, 116);
            this.pcLogoOJK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcLogoOJK.TabIndex = 20;
            this.pcLogoOJK.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(491, 80);
            this.label2.TabIndex = 21;
            this.label2.Text = "Kantor Provinsi\r\nSulawesi Selatan dan Sulawesi Barat";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(305, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(518, 36);
            this.label4.TabIndex = 22;
            this.label4.Text = "Jalan Sultan Hasanuddin No. 3-5, Makassar";
            // 
            // txtTanggal
            // 
            this.txtTanggal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTanggal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTanggal.Location = new System.Drawing.Point(800, 9);
            this.txtTanggal.Name = "txtTanggal";
            this.txtTanggal.Size = new System.Drawing.Size(854, 54);
            this.txtTanggal.TabIndex = 23;
            this.txtTanggal.Text = "[[Date.Now]]";
            this.txtTanggal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTime
            // 
            this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime.BackColor = System.Drawing.Color.Transparent;
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(802, 63);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(852, 101);
            this.txtTime.TabIndex = 24;
            this.txtTime.Text = "[[Time.Now]]";
            this.txtTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // Mainpanel
            // 
            this.Mainpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Mainpanel.BackColor = System.Drawing.Color.White;
            this.Mainpanel.Controls.Add(this.WMPPlayer);
            this.Mainpanel.Location = new System.Drawing.Point(22, 227);
            this.Mainpanel.Name = "Mainpanel";
            this.Mainpanel.Size = new System.Drawing.Size(772, 568);
            this.Mainpanel.TabIndex = 26;
            // 
            // WMPPlayer
            // 
            this.WMPPlayer.BackColor = System.Drawing.Color.Black;
            this.WMPPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WMPPlayer.Location = new System.Drawing.Point(0, 0);
            this.WMPPlayer.MediaPlayer = null;
            this.WMPPlayer.Name = "WMPPlayer";
            this.WMPPlayer.Size = new System.Drawing.Size(772, 568);
            this.WMPPlayer.TabIndex = 0;
            this.WMPPlayer.Text = "videoView";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(675, 798);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(288, 75);
            this.label5.TabIndex = 27;
            this.label5.Text = "LOKET SLIK 2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.BackColor = System.Drawing.Color.DarkRed;
            this.groupBox.Controls.Add(this.setVolume);
            this.groupBox.Controls.Add(this.lblNumAntrian);
            this.groupBox.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.ForeColor = System.Drawing.Color.White;
            this.groupBox.Location = new System.Drawing.Point(802, 227);
            this.groupBox.Name = "groupBox";
            this.groupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox.Size = new System.Drawing.Size(852, 568);
            this.groupBox.TabIndex = 28;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "NOMOR ANTRIAN";
            // 
            // setVolume
            // 
            this.setVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setVolume.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.setVolume.Location = new System.Drawing.Point(6, 424);
            this.setVolume.Maximum = 100;
            this.setVolume.Name = "setVolume";
            this.setVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.setVolume.Size = new System.Drawing.Size(69, 138);
            this.setVolume.TabIndex = 1;
            this.setVolume.TickFrequency = 10;
            this.setVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.setVolume.Scroll += new System.EventHandler(this.SetVolumeScroll);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.DarkRed;
            this.buttonClose.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonClose.Location = new System.Drawing.Point(1588, 1089);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(63, 64);
            this.buttonClose.TabIndex = 31;
            this.buttonClose.Text = "⏻";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // lblRun
            // 
            this.lblRun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRun.AutoSize = true;
            this.lblRun.BackColor = System.Drawing.Color.Crimson;
            this.lblRun.Font = new System.Drawing.Font("Segoe UI Semibold", 23F, System.Drawing.FontStyle.Bold);
            this.lblRun.ForeColor = System.Drawing.Color.White;
            this.lblRun.Location = new System.Drawing.Point(0, 2);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(2415, 62);
            this.lblRun.TabIndex = 32;
            this.lblRun.Text = "SELAMAT DATANG DI OTORITAS JASA KEUANGAN KANTOR PROVINSI SULAWESI SELATAN DAN SUL" +
    "AWESI BARAT";
            // 
            // timerMarquee
            // 
            this.timerMarquee.Tick += new System.EventHandler(this.TimerMarqueeTick);
            // 
            // panelRunText
            // 
            this.panelRunText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRunText.BackColor = System.Drawing.Color.Crimson;
            this.panelRunText.Controls.Add(this.lblRun);
            this.panelRunText.Location = new System.Drawing.Point(22, 1092);
            this.panelRunText.Name = "panelRunText";
            this.panelRunText.Size = new System.Drawing.Size(1560, 66);
            this.panelRunText.TabIndex = 33;
            // 
            // display_antrian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1666, 1170);
            this.Controls.Add(this.panelRunText);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Mainpanel);
            this.Controls.Add(this.txtTanggal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pcLogoOJK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblNumAntrianLok3);
            this.Controls.Add(this.lblNumAntrianLok2);
            this.Controls.Add(this.lblNumAntrianLok1);
            this.Controls.Add(this.btnBackLok3);
            this.Controls.Add(this.btnBackLok2);
            this.Controls.Add(this.btnBackLok1);
            this.Controls.Add(this.btnNextLok3);
            this.Controls.Add(this.btnNextLok2);
            this.Controls.Add(this.btnNextLok1);
            this.Controls.Add(this.btnCallLok3);
            this.Controls.Add(this.btnCallLok2);
            this.Controls.Add(this.btnCallLok1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNumLoket);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "display_antrian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANTRIAN DISPLAY";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisplayFormClosing);
            this.Load += new System.EventHandler(this.DisplayLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisplayKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pcLogoOJK)).EndInit();
            this.Mainpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WMPPlayer)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setVolume)).EndInit();
            this.panelRunText.ResumeLayout(false);
            this.panelRunText.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.Label label5;
        private LibVLCSharp.WinForms.VideoView WMPPlayer;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TrackBar setVolume;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.Timer timerMarquee;
        private System.Windows.Forms.Panel panelRunText;
    }
}
