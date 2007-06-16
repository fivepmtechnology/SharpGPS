namespace Demo_WinForms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.NMEAtabs = new System.Windows.Forms.TabControl();
			this.tabGPRMC = new System.Windows.Forms.TabPage();
			this.label35 = new System.Windows.Forms.Label();
			this.lbRMCPositionUTM = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lbRMCMagneticVariation = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lbRMCTimeOfFix = new System.Windows.Forms.Label();
			this.lbRMCSpeed = new System.Windows.Forms.Label();
			this.lbRMCCourse = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lbRMCPosition = new System.Windows.Forms.Label();
			this.tabGPGGA = new System.Windows.Forms.TabPage();
			this.label12 = new System.Windows.Forms.Label();
			this.lbGGADGPSID = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.lbGGADGPSupdate = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.lbGGAGeoidHeight = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.lbGGAHDOP = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lbGGAAltitude = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.lbGGANoOfSats = new System.Windows.Forms.Label();
			this.lbGGAFixQuality = new System.Windows.Forms.Label();
			this.lbGGATimeOfFix = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.lbGGAPosition = new System.Windows.Forms.Label();
			this.tabGPGLL = new System.Windows.Forms.TabPage();
			this.label30 = new System.Windows.Forms.Label();
			this.lbGLLDataValid = new System.Windows.Forms.Label();
			this.lbGLLTimeOfSolution = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.lbGLLPosition = new System.Windows.Forms.Label();
			this.tabGPGSA = new System.Windows.Forms.TabPage();
			this.label32 = new System.Windows.Forms.Label();
			this.lbGSAHDOP = new System.Windows.Forms.Label();
			this.lbGSAVDOP = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lbGSAPDOP = new System.Windows.Forms.Label();
			this.lbGSAPRNs = new System.Windows.Forms.Label();
			this.lbGSAFixMode = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.lbGSAMode = new System.Windows.Forms.Label();
			this.tabGPGSV = new System.Windows.Forms.TabPage();
			this.picGSVSignals = new System.Windows.Forms.PictureBox();
			this.picGSVSkyview = new System.Windows.Forms.PictureBox();
			this.label33 = new System.Windows.Forms.Label();
			this.tabPGRME = new System.Windows.Forms.TabPage();
			this.label31 = new System.Windows.Forms.Label();
			this.lbRMESphericalError = new System.Windows.Forms.Label();
			this.lbRMEVerError = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.lbRMEHorError = new System.Windows.Forms.Label();
			this.tabRaw = new System.Windows.Forms.TabPage();
			this.tbRawLog = new System.Windows.Forms.TextBox();
			this.tabNTRIP = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgNTRIPNetworks = new System.Windows.Forms.DataGrid();
			this.dgNTRIPCasters = new System.Windows.Forms.DataGrid();
			this.tbNTRIPPort = new System.Windows.Forms.TextBox();
			this.tbNTRIPServerIP = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnNTRIPGetSourceTable = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem_File_Exit = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItemGPS_Start = new System.Windows.Forms.MenuItem();
			this.menuItemGPS_Settings = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.NMEAtabs.SuspendLayout();
			this.tabGPRMC.SuspendLayout();
			this.tabGPGGA.SuspendLayout();
			this.tabGPGLL.SuspendLayout();
			this.tabGPGSA.SuspendLayout();
			this.tabGPGSV.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picGSVSignals)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picGSVSkyview)).BeginInit();
			this.tabPGRME.SuspendLayout();
			this.tabRaw.SuspendLayout();
			this.tabNTRIP.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgNTRIPNetworks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgNTRIPCasters)).BeginInit();
			this.SuspendLayout();
			// 
			// NMEAtabs
			// 
			this.NMEAtabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NMEAtabs.Controls.Add(this.tabGPRMC);
			this.NMEAtabs.Controls.Add(this.tabGPGGA);
			this.NMEAtabs.Controls.Add(this.tabGPGLL);
			this.NMEAtabs.Controls.Add(this.tabGPGSA);
			this.NMEAtabs.Controls.Add(this.tabGPGSV);
			this.NMEAtabs.Controls.Add(this.tabPGRME);
			this.NMEAtabs.Controls.Add(this.tabRaw);
			this.NMEAtabs.Controls.Add(this.tabNTRIP);
			this.NMEAtabs.Location = new System.Drawing.Point(0, 0);
			this.NMEAtabs.Name = "NMEAtabs";
			this.NMEAtabs.SelectedIndex = 0;
			this.NMEAtabs.Size = new System.Drawing.Size(387, 368);
			this.NMEAtabs.TabIndex = 1;
			this.NMEAtabs.SelectedIndexChanged += new System.EventHandler(this.NMEAtabs_SelectedIndexChanged);
			// 
			// tabGPRMC
			// 
			this.tabGPRMC.AutoScroll = true;
			this.tabGPRMC.Controls.Add(this.label35);
			this.tabGPRMC.Controls.Add(this.lbRMCPositionUTM);
			this.tabGPRMC.Controls.Add(this.label5);
			this.tabGPRMC.Controls.Add(this.lbRMCMagneticVariation);
			this.tabGPRMC.Controls.Add(this.label6);
			this.tabGPRMC.Controls.Add(this.lbRMCTimeOfFix);
			this.tabGPRMC.Controls.Add(this.lbRMCSpeed);
			this.tabGPRMC.Controls.Add(this.lbRMCCourse);
			this.tabGPRMC.Controls.Add(this.label4);
			this.tabGPRMC.Controls.Add(this.label3);
			this.tabGPRMC.Controls.Add(this.label2);
			this.tabGPRMC.Controls.Add(this.label1);
			this.tabGPRMC.Controls.Add(this.lbRMCPosition);
			this.tabGPRMC.Location = new System.Drawing.Point(4, 22);
			this.tabGPRMC.Name = "tabGPRMC";
			this.tabGPRMC.Size = new System.Drawing.Size(379, 342);
			this.tabGPRMC.TabIndex = 0;
			this.tabGPRMC.Text = "GPRMC";
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(7, 161);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(78, 20);
			this.label35.TabIndex = 11;
			this.label35.Text = "UTM Position";
			// 
			// lbRMCPositionUTM
			// 
			this.lbRMCPositionUTM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbRMCPositionUTM.Location = new System.Drawing.Point(75, 161);
			this.lbRMCPositionUTM.Name = "lbRMCPositionUTM";
			this.lbRMCPositionUTM.Size = new System.Drawing.Size(296, 20);
			this.lbRMCPositionUTM.TabIndex = 12;
			this.lbRMCPositionUTM.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(7, 4);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(225, 20);
			this.label5.TabIndex = 0;
			this.label5.Text = "GPS/Transit data";
			// 
			// lbRMCMagneticVariation
			// 
			this.lbRMCMagneticVariation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbRMCMagneticVariation.Location = new System.Drawing.Point(125, 104);
			this.lbRMCMagneticVariation.Name = "lbRMCMagneticVariation";
			this.lbRMCMagneticVariation.Size = new System.Drawing.Size(246, 20);
			this.lbRMCMagneticVariation.TabIndex = 1;
			this.lbRMCMagneticVariation.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(111, 20);
			this.label6.TabIndex = 2;
			this.label6.Text = "Magnetic Variation";
			// 
			// lbRMCTimeOfFix
			// 
			this.lbRMCTimeOfFix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbRMCTimeOfFix.Location = new System.Drawing.Point(102, 84);
			this.lbRMCTimeOfFix.Name = "lbRMCTimeOfFix";
			this.lbRMCTimeOfFix.Size = new System.Drawing.Size(269, 20);
			this.lbRMCTimeOfFix.TabIndex = 3;
			this.lbRMCTimeOfFix.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbRMCSpeed
			// 
			this.lbRMCSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbRMCSpeed.Location = new System.Drawing.Point(102, 64);
			this.lbRMCSpeed.Name = "lbRMCSpeed";
			this.lbRMCSpeed.Size = new System.Drawing.Size(269, 20);
			this.lbRMCSpeed.TabIndex = 4;
			this.lbRMCSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbRMCCourse
			// 
			this.lbRMCCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbRMCCourse.Location = new System.Drawing.Point(102, 44);
			this.lbRMCCourse.Name = "lbRMCCourse";
			this.lbRMCCourse.Size = new System.Drawing.Size(269, 20);
			this.lbRMCCourse.TabIndex = 5;
			this.lbRMCCourse.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Time of fix";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Speed";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "Course";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 20);
			this.label1.TabIndex = 9;
			this.label1.Text = "Position";
			// 
			// lbRMCPosition
			// 
			this.lbRMCPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbRMCPosition.Location = new System.Drawing.Point(72, 24);
			this.lbRMCPosition.Name = "lbRMCPosition";
			this.lbRMCPosition.Size = new System.Drawing.Size(299, 20);
			this.lbRMCPosition.TabIndex = 10;
			this.lbRMCPosition.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tabGPGGA
			// 
			this.tabGPGGA.AutoScroll = true;
			this.tabGPGGA.Controls.Add(this.label12);
			this.tabGPGGA.Controls.Add(this.lbGGADGPSID);
			this.tabGPGGA.Controls.Add(this.label24);
			this.tabGPGGA.Controls.Add(this.lbGGADGPSupdate);
			this.tabGPGGA.Controls.Add(this.label22);
			this.tabGPGGA.Controls.Add(this.lbGGAGeoidHeight);
			this.tabGPGGA.Controls.Add(this.label20);
			this.tabGPGGA.Controls.Add(this.lbGGAHDOP);
			this.tabGPGGA.Controls.Add(this.label7);
			this.tabGPGGA.Controls.Add(this.lbGGAAltitude);
			this.tabGPGGA.Controls.Add(this.label10);
			this.tabGPGGA.Controls.Add(this.lbGGANoOfSats);
			this.tabGPGGA.Controls.Add(this.lbGGAFixQuality);
			this.tabGPGGA.Controls.Add(this.lbGGATimeOfFix);
			this.tabGPGGA.Controls.Add(this.label14);
			this.tabGPGGA.Controls.Add(this.label15);
			this.tabGPGGA.Controls.Add(this.label16);
			this.tabGPGGA.Controls.Add(this.label17);
			this.tabGPGGA.Controls.Add(this.lbGGAPosition);
			this.tabGPGGA.Location = new System.Drawing.Point(4, 22);
			this.tabGPGGA.Name = "tabGPGGA";
			this.tabGPGGA.Size = new System.Drawing.Size(379, 342);
			this.tabGPGGA.TabIndex = 1;
			this.tabGPGGA.Text = "GPGGA";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label12.Location = new System.Drawing.Point(7, 4);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(225, 20);
			this.label12.TabIndex = 0;
			this.label12.Text = "Global Positioning System Fix Data";
			// 
			// lbGGADGPSID
			// 
			this.lbGGADGPSID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGGADGPSID.Location = new System.Drawing.Point(113, 184);
			this.lbGGADGPSID.Name = "lbGGADGPSID";
			this.lbGGADGPSID.Size = new System.Drawing.Size(258, 20);
			this.lbGGADGPSID.TabIndex = 1;
			this.lbGGADGPSID.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(7, 184);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(99, 20);
			this.label24.TabIndex = 2;
			this.label24.Text = "DGPS Station ID";
			// 
			// lbGGADGPSupdate
			// 
			this.lbGGADGPSupdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGGADGPSupdate.Location = new System.Drawing.Point(113, 164);
			this.lbGGADGPSupdate.Name = "lbGGADGPSupdate";
			this.lbGGADGPSupdate.Size = new System.Drawing.Size(258, 20);
			this.lbGGADGPSupdate.TabIndex = 3;
			this.lbGGADGPSupdate.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(7, 164);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(99, 20);
			this.label22.TabIndex = 4;
			this.label22.Text = "DGPS update";
			// 
			// lbGGAGeoidHeight
			// 
			this.lbGGAGeoidHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGGAGeoidHeight.Location = new System.Drawing.Point(113, 144);
			this.lbGGAGeoidHeight.Name = "lbGGAGeoidHeight";
			this.lbGGAGeoidHeight.Size = new System.Drawing.Size(258, 20);
			this.lbGGAGeoidHeight.TabIndex = 5;
			this.lbGGAGeoidHeight.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(7, 144);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(99, 20);
			this.label20.TabIndex = 6;
			this.label20.Text = "Height of Geoid";
			// 
			// lbGGAHDOP
			// 
			this.lbGGAHDOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGGAHDOP.Location = new System.Drawing.Point(125, 124);
			this.lbGGAHDOP.Name = "lbGGAHDOP";
			this.lbGGAHDOP.Size = new System.Drawing.Size(246, 20);
			this.lbGGAHDOP.TabIndex = 7;
			this.lbGGAHDOP.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(7, 124);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(111, 20);
			this.label7.TabIndex = 8;
			this.label7.Text = "HDOP";
			// 
			// lbGGAAltitude
			// 
			this.lbGGAAltitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGGAAltitude.Location = new System.Drawing.Point(125, 104);
			this.lbGGAAltitude.Name = "lbGGAAltitude";
			this.lbGGAAltitude.Size = new System.Drawing.Size(246, 20);
			this.lbGGAAltitude.TabIndex = 9;
			this.lbGGAAltitude.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(7, 104);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(111, 20);
			this.label10.TabIndex = 10;
			this.label10.Text = "Altitude";
			// 
			// lbGGANoOfSats
			// 
			this.lbGGANoOfSats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGGANoOfSats.Location = new System.Drawing.Point(125, 84);
			this.lbGGANoOfSats.Name = "lbGGANoOfSats";
			this.lbGGANoOfSats.Size = new System.Drawing.Size(246, 20);
			this.lbGGANoOfSats.TabIndex = 11;
			this.lbGGANoOfSats.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbGGAFixQuality
			// 
			this.lbGGAFixQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGGAFixQuality.Location = new System.Drawing.Point(102, 64);
			this.lbGGAFixQuality.Name = "lbGGAFixQuality";
			this.lbGGAFixQuality.Size = new System.Drawing.Size(269, 20);
			this.lbGGAFixQuality.TabIndex = 12;
			this.lbGGAFixQuality.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbGGATimeOfFix
			// 
			this.lbGGATimeOfFix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGGATimeOfFix.Location = new System.Drawing.Point(102, 44);
			this.lbGGATimeOfFix.Name = "lbGGATimeOfFix";
			this.lbGGATimeOfFix.Size = new System.Drawing.Size(269, 20);
			this.lbGGATimeOfFix.TabIndex = 13;
			this.lbGGATimeOfFix.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(7, 84);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(111, 20);
			this.label14.TabIndex = 14;
			this.label14.Text = "Tracked satellites";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(7, 64);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(89, 20);
			this.label15.TabIndex = 15;
			this.label15.Text = "Fix quality";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(7, 44);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(89, 20);
			this.label16.TabIndex = 16;
			this.label16.Text = "Time of Fix";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(7, 24);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(58, 20);
			this.label17.TabIndex = 17;
			this.label17.Text = "Position";
			// 
			// lbGGAPosition
			// 
			this.lbGGAPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGGAPosition.Location = new System.Drawing.Point(72, 24);
			this.lbGGAPosition.Name = "lbGGAPosition";
			this.lbGGAPosition.Size = new System.Drawing.Size(299, 20);
			this.lbGGAPosition.TabIndex = 18;
			this.lbGGAPosition.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tabGPGLL
			// 
			this.tabGPGLL.AutoScroll = true;
			this.tabGPGLL.Controls.Add(this.label30);
			this.tabGPGLL.Controls.Add(this.lbGLLDataValid);
			this.tabGPGLL.Controls.Add(this.lbGLLTimeOfSolution);
			this.tabGPGLL.Controls.Add(this.label13);
			this.tabGPGLL.Controls.Add(this.label18);
			this.tabGPGLL.Controls.Add(this.label19);
			this.tabGPGLL.Controls.Add(this.lbGLLPosition);
			this.tabGPGLL.Location = new System.Drawing.Point(4, 22);
			this.tabGPGLL.Name = "tabGPGLL";
			this.tabGPGLL.Size = new System.Drawing.Size(379, 342);
			this.tabGPGLL.TabIndex = 2;
			this.tabGPGLL.Text = "GPGLL";
			// 
			// label30
			// 
			this.label30.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label30.Location = new System.Drawing.Point(7, 4);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(225, 20);
			this.label30.TabIndex = 0;
			this.label30.Text = "Geographic position";
			// 
			// lbGLLDataValid
			// 
			this.lbGLLDataValid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGLLDataValid.Location = new System.Drawing.Point(102, 64);
			this.lbGLLDataValid.Name = "lbGLLDataValid";
			this.lbGLLDataValid.Size = new System.Drawing.Size(269, 20);
			this.lbGLLDataValid.TabIndex = 1;
			this.lbGLLDataValid.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbGLLTimeOfSolution
			// 
			this.lbGLLTimeOfSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGLLTimeOfSolution.Location = new System.Drawing.Point(116, 44);
			this.lbGLLTimeOfSolution.Name = "lbGLLTimeOfSolution";
			this.lbGLLTimeOfSolution.Size = new System.Drawing.Size(255, 20);
			this.lbGLLTimeOfSolution.TabIndex = 2;
			this.lbGLLTimeOfSolution.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(7, 64);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(89, 20);
			this.label13.TabIndex = 3;
			this.label13.Text = "Data valid";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(7, 44);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(102, 20);
			this.label18.TabIndex = 4;
			this.label18.Text = "Time of solution";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(7, 24);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(58, 20);
			this.label19.TabIndex = 5;
			this.label19.Text = "Position";
			// 
			// lbGLLPosition
			// 
			this.lbGLLPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGLLPosition.Location = new System.Drawing.Point(72, 24);
			this.lbGLLPosition.Name = "lbGLLPosition";
			this.lbGLLPosition.Size = new System.Drawing.Size(299, 20);
			this.lbGLLPosition.TabIndex = 6;
			this.lbGLLPosition.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tabGPGSA
			// 
			this.tabGPGSA.AutoScroll = true;
			this.tabGPGSA.Controls.Add(this.label32);
			this.tabGPGSA.Controls.Add(this.lbGSAHDOP);
			this.tabGPGSA.Controls.Add(this.lbGSAVDOP);
			this.tabGPGSA.Controls.Add(this.label9);
			this.tabGPGSA.Controls.Add(this.label11);
			this.tabGPGSA.Controls.Add(this.lbGSAPDOP);
			this.tabGPGSA.Controls.Add(this.lbGSAPRNs);
			this.tabGPGSA.Controls.Add(this.lbGSAFixMode);
			this.tabGPGSA.Controls.Add(this.label25);
			this.tabGPGSA.Controls.Add(this.label26);
			this.tabGPGSA.Controls.Add(this.label27);
			this.tabGPGSA.Controls.Add(this.label28);
			this.tabGPGSA.Controls.Add(this.lbGSAMode);
			this.tabGPGSA.Location = new System.Drawing.Point(4, 22);
			this.tabGPGSA.Name = "tabGPGSA";
			this.tabGPGSA.Size = new System.Drawing.Size(379, 342);
			this.tabGPGSA.TabIndex = 3;
			this.tabGPGSA.Text = "GPGSA";
			// 
			// label32
			// 
			this.label32.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label32.Location = new System.Drawing.Point(7, 4);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(225, 20);
			this.label32.TabIndex = 0;
			this.label32.Text = "GPS DOP and active satellites";
			// 
			// lbGSAHDOP
			// 
			this.lbGSAHDOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGSAHDOP.Location = new System.Drawing.Point(125, 104);
			this.lbGSAHDOP.Name = "lbGSAHDOP";
			this.lbGSAHDOP.Size = new System.Drawing.Size(246, 20);
			this.lbGSAHDOP.TabIndex = 1;
			this.lbGSAHDOP.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbGSAVDOP
			// 
			this.lbGSAVDOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGSAVDOP.Location = new System.Drawing.Point(125, 124);
			this.lbGSAVDOP.Name = "lbGSAVDOP";
			this.lbGSAVDOP.Size = new System.Drawing.Size(246, 20);
			this.lbGSAVDOP.TabIndex = 2;
			this.lbGSAVDOP.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(7, 124);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(111, 20);
			this.label9.TabIndex = 3;
			this.label9.Text = "VDOP";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(7, 104);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(111, 20);
			this.label11.TabIndex = 4;
			this.label11.Text = "HDOP";
			// 
			// lbGSAPDOP
			// 
			this.lbGSAPDOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGSAPDOP.Location = new System.Drawing.Point(125, 84);
			this.lbGSAPDOP.Name = "lbGSAPDOP";
			this.lbGSAPDOP.Size = new System.Drawing.Size(246, 20);
			this.lbGSAPDOP.TabIndex = 5;
			this.lbGSAPDOP.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbGSAPRNs
			// 
			this.lbGSAPRNs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGSAPRNs.Location = new System.Drawing.Point(112, 64);
			this.lbGSAPRNs.Name = "lbGSAPRNs";
			this.lbGSAPRNs.Size = new System.Drawing.Size(259, 20);
			this.lbGSAPRNs.TabIndex = 6;
			this.lbGSAPRNs.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbGSAFixMode
			// 
			this.lbGSAFixMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGSAFixMode.Location = new System.Drawing.Point(73, 44);
			this.lbGSAFixMode.Name = "lbGSAFixMode";
			this.lbGSAFixMode.Size = new System.Drawing.Size(298, 20);
			this.lbGSAFixMode.TabIndex = 7;
			this.lbGSAFixMode.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(7, 84);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(111, 20);
			this.label25.TabIndex = 8;
			this.label25.Text = "PDOP";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(7, 64);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(99, 20);
			this.label26.TabIndex = 9;
			this.label26.Text = "PRNs in solution";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(7, 44);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(59, 20);
			this.label27.TabIndex = 10;
			this.label27.Text = "Fix mode";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(7, 24);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(58, 20);
			this.label28.TabIndex = 11;
			this.label28.Text = "Mode";
			// 
			// lbGSAMode
			// 
			this.lbGSAMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbGSAMode.Location = new System.Drawing.Point(72, 24);
			this.lbGSAMode.Name = "lbGSAMode";
			this.lbGSAMode.Size = new System.Drawing.Size(299, 20);
			this.lbGSAMode.TabIndex = 12;
			this.lbGSAMode.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tabGPGSV
			// 
			this.tabGPGSV.Controls.Add(this.picGSVSignals);
			this.tabGPGSV.Controls.Add(this.picGSVSkyview);
			this.tabGPGSV.Controls.Add(this.label33);
			this.tabGPGSV.Location = new System.Drawing.Point(4, 22);
			this.tabGPGSV.Name = "tabGPGSV";
			this.tabGPGSV.Size = new System.Drawing.Size(379, 342);
			this.tabGPGSV.TabIndex = 4;
			this.tabGPGSV.Text = "GPGSV";
			// 
			// picGSVSignals
			// 
			this.picGSVSignals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.picGSVSignals.Location = new System.Drawing.Point(8, 193);
			this.picGSVSignals.Name = "picGSVSignals";
			this.picGSVSignals.Size = new System.Drawing.Size(363, 129);
			this.picGSVSignals.TabIndex = 0;
			this.picGSVSignals.TabStop = false;
			// 
			// picGSVSkyview
			// 
			this.picGSVSkyview.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.picGSVSkyview.Location = new System.Drawing.Point(103, 17);
			this.picGSVSkyview.Name = "picGSVSkyview";
			this.picGSVSkyview.Size = new System.Drawing.Size(170, 170);
			this.picGSVSkyview.TabIndex = 1;
			this.picGSVSkyview.TabStop = false;
			// 
			// label33
			// 
			this.label33.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label33.Location = new System.Drawing.Point(7, 4);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(225, 20);
			this.label33.TabIndex = 2;
			this.label33.Text = "Satellites in view";
			// 
			// tabPGRME
			// 
			this.tabPGRME.AutoScroll = true;
			this.tabPGRME.Controls.Add(this.label31);
			this.tabPGRME.Controls.Add(this.lbRMESphericalError);
			this.tabPGRME.Controls.Add(this.lbRMEVerError);
			this.tabPGRME.Controls.Add(this.label21);
			this.tabPGRME.Controls.Add(this.label23);
			this.tabPGRME.Controls.Add(this.label29);
			this.tabPGRME.Controls.Add(this.lbRMEHorError);
			this.tabPGRME.Location = new System.Drawing.Point(4, 22);
			this.tabPGRME.Name = "tabPGRME";
			this.tabPGRME.Size = new System.Drawing.Size(379, 342);
			this.tabPGRME.TabIndex = 5;
			this.tabPGRME.Text = "PGRME";
			// 
			// label31
			// 
			this.label31.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label31.Location = new System.Drawing.Point(7, 4);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(225, 20);
			this.label31.TabIndex = 0;
			this.label31.Text = "Garmin Proprietary Sentences";
			// 
			// lbRMESphericalError
			// 
			this.lbRMESphericalError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbRMESphericalError.Location = new System.Drawing.Point(160, 64);
			this.lbRMESphericalError.Name = "lbRMESphericalError";
			this.lbRMESphericalError.Size = new System.Drawing.Size(211, 20);
			this.lbRMESphericalError.TabIndex = 1;
			this.lbRMESphericalError.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbRMEVerError
			// 
			this.lbRMEVerError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbRMEVerError.Location = new System.Drawing.Point(160, 44);
			this.lbRMEVerError.Name = "lbRMEVerError";
			this.lbRMEVerError.Size = new System.Drawing.Size(211, 20);
			this.lbRMEVerError.TabIndex = 2;
			this.lbRMEVerError.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(7, 64);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(147, 20);
			this.label21.TabIndex = 3;
			this.label21.Text = "Estimated Spherical Error";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(7, 44);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(155, 20);
			this.label23.TabIndex = 4;
			this.label23.Text = "Estimated vertical error";
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(7, 24);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(155, 20);
			this.label29.TabIndex = 5;
			this.label29.Text = "Extimated Horisontal error";
			// 
			// lbRMEHorError
			// 
			this.lbRMEHorError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbRMEHorError.Location = new System.Drawing.Point(160, 24);
			this.lbRMEHorError.Name = "lbRMEHorError";
			this.lbRMEHorError.Size = new System.Drawing.Size(211, 20);
			this.lbRMEHorError.TabIndex = 6;
			this.lbRMEHorError.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tabRaw
			// 
			this.tabRaw.Controls.Add(this.tbRawLog);
			this.tabRaw.Location = new System.Drawing.Point(4, 22);
			this.tabRaw.Name = "tabRaw";
			this.tabRaw.Size = new System.Drawing.Size(379, 342);
			this.tabRaw.TabIndex = 6;
			this.tabRaw.Text = "Raw";
			// 
			// tbRawLog
			// 
			this.tbRawLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbRawLog.Location = new System.Drawing.Point(0, 0);
			this.tbRawLog.Multiline = true;
			this.tbRawLog.Name = "tbRawLog";
			this.tbRawLog.ReadOnly = true;
			this.tbRawLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbRawLog.Size = new System.Drawing.Size(379, 342);
			this.tbRawLog.TabIndex = 0;
			this.tbRawLog.WordWrap = false;
			// 
			// tabNTRIP
			// 
			this.tabNTRIP.AutoScroll = true;
			this.tabNTRIP.Controls.Add(this.panel1);
			this.tabNTRIP.Controls.Add(this.tbNTRIPPort);
			this.tabNTRIP.Controls.Add(this.tbNTRIPServerIP);
			this.tabNTRIP.Controls.Add(this.label34);
			this.tabNTRIP.Controls.Add(this.label8);
			this.tabNTRIP.Controls.Add(this.btnNTRIPGetSourceTable);
			this.tabNTRIP.Location = new System.Drawing.Point(4, 22);
			this.tabNTRIP.Name = "tabNTRIP";
			this.tabNTRIP.Size = new System.Drawing.Size(379, 342);
			this.tabNTRIP.TabIndex = 7;
			this.tabNTRIP.Text = "NTRIP";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.dgNTRIPNetworks);
			this.panel1.Controls.Add(this.dgNTRIPCasters);
			this.panel1.Location = new System.Drawing.Point(9, 79);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(366, 315);
			this.panel1.TabIndex = 0;
			// 
			// dgNTRIPNetworks
			// 
			this.dgNTRIPNetworks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgNTRIPNetworks.DataMember = "";
			this.dgNTRIPNetworks.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgNTRIPNetworks.Location = new System.Drawing.Point(4, 108);
			this.dgNTRIPNetworks.Name = "dgNTRIPNetworks";
			this.dgNTRIPNetworks.Size = new System.Drawing.Size(359, 204);
			this.dgNTRIPNetworks.TabIndex = 1;
			// 
			// dgNTRIPCasters
			// 
			this.dgNTRIPCasters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgNTRIPCasters.DataMember = "";
			this.dgNTRIPCasters.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgNTRIPCasters.Location = new System.Drawing.Point(4, 4);
			this.dgNTRIPCasters.Name = "dgNTRIPCasters";
			this.dgNTRIPCasters.Size = new System.Drawing.Size(362, 97);
			this.dgNTRIPCasters.TabIndex = 0;
			// 
			// tbNTRIPPort
			// 
			this.tbNTRIPPort.Location = new System.Drawing.Point(183, 24);
			this.tbNTRIPPort.Name = "tbNTRIPPort";
			this.tbNTRIPPort.Size = new System.Drawing.Size(33, 20);
			this.tbNTRIPPort.TabIndex = 2;
			this.tbNTRIPPort.Text = "80";
			// 
			// tbNTRIPServerIP
			// 
			this.tbNTRIPServerIP.Location = new System.Drawing.Point(9, 25);
			this.tbNTRIPServerIP.Name = "tbNTRIPServerIP";
			this.tbNTRIPServerIP.Size = new System.Drawing.Size(151, 20);
			this.tbNTRIPServerIP.TabIndex = 1;
			this.tbNTRIPServerIP.Text = "213.20.239.197";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(183, 8);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(33, 20);
			this.label34.TabIndex = 3;
			this.label34.Text = "Port";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(9, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(151, 20);
			this.label8.TabIndex = 4;
			this.label8.Text = "NTRIP Server IP";
			// 
			// btnNTRIPGetSourceTable
			// 
			this.btnNTRIPGetSourceTable.Enabled = false;
			this.btnNTRIPGetSourceTable.Location = new System.Drawing.Point(9, 52);
			this.btnNTRIPGetSourceTable.Name = "btnNTRIPGetSourceTable";
			this.btnNTRIPGetSourceTable.Size = new System.Drawing.Size(110, 20);
			this.btnNTRIPGetSourceTable.TabIndex = 0;
			this.btnNTRIPGetSourceTable.Text = "Get Sourcetable";
			this.btnNTRIPGetSourceTable.Click += new System.EventHandler(this.btnNTRIPGetSourceTable_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 367);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(387, 22);
			this.statusBar1.TabIndex = 0;
			this.statusBar1.Text = "GPS Offline";
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3,
            this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_File_Exit});
			this.menuItem1.Text = "&File";
			// 
			// menuItem_File_Exit
			// 
			this.menuItem_File_Exit.Index = 0;
			this.menuItem_File_Exit.Text = "E&xit";
			this.menuItem_File_Exit.Click += new System.EventHandler(this.menuItem_File_Exit_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemGPS_Start,
            this.menuItemGPS_Settings});
			this.menuItem3.Text = "&GPS";
			// 
			// menuItemGPS_Start
			// 
			this.menuItemGPS_Start.Index = 0;
			this.menuItemGPS_Start.Text = "&Start";
			this.menuItemGPS_Start.Click += new System.EventHandler(this.menuItemGPS_Start_Click);
			// 
			// menuItemGPS_Settings
			// 
			this.menuItemGPS_Settings.Index = 1;
			this.menuItemGPS_Settings.Text = "Settings...";
			this.menuItemGPS_Settings.Click += new System.EventHandler(this.menuItemGPS_Settings_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4});
			this.menuItem2.Text = "NTRIP";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "Settings...";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(387, 389);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.NMEAtabs);
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "SharpGps Test";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.NMEAtabs.ResumeLayout(false);
			this.tabGPRMC.ResumeLayout(false);
			this.tabGPGGA.ResumeLayout(false);
			this.tabGPGLL.ResumeLayout(false);
			this.tabGPGSA.ResumeLayout(false);
			this.tabGPGSV.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picGSVSignals)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picGSVSkyview)).EndInit();
			this.tabPGRME.ResumeLayout(false);
			this.tabRaw.ResumeLayout(false);
			this.tabRaw.PerformLayout();
			this.tabNTRIP.ResumeLayout(false);
			this.tabNTRIP.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgNTRIPNetworks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgNTRIPCasters)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl NMEAtabs;
		private System.Windows.Forms.TabPage tabGPRMC;
		private System.Windows.Forms.TabPage tabGPGGA;
		private System.Windows.Forms.Label lbRMCPosition;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem_File_Exit;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItemGPS_Start;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabGPGLL;
		private System.Windows.Forms.TabPage tabGPGSA;
		private System.Windows.Forms.TabPage tabGPGSV;
		private System.Windows.Forms.TabPage tabPGRME;
		private System.Windows.Forms.TabPage tabRaw;
		private System.Windows.Forms.TextBox tbRawLog;
		private System.Windows.Forms.Label lbRMCTimeOfFix;
		private System.Windows.Forms.Label lbRMCSpeed;
		private System.Windows.Forms.Label lbRMCCourse;
		private System.Windows.Forms.Label lbRMCMagneticVariation;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbGGAGeoidHeight;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label lbGGAHDOP;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lbGGAAltitude;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lbGGANoOfSats;
		private System.Windows.Forms.Label lbGGAFixQuality;
		private System.Windows.Forms.Label lbGGATimeOfFix;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label lbGGAPosition;
		private System.Windows.Forms.Label lbGGADGPSID;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label lbGGADGPSupdate;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label lbGLLDataValid;
		private System.Windows.Forms.Label lbGLLTimeOfSolution;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label lbGLLPosition;
		private System.Windows.Forms.Label lbGSAVDOP;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lbGSAPDOP;
		private System.Windows.Forms.Label lbGSAPRNs;
		private System.Windows.Forms.Label lbGSAFixMode;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label lbGSAMode;
		private System.Windows.Forms.Label lbGSAHDOP;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label lbRMESphericalError;
		private System.Windows.Forms.Label lbRMEVerError;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label lbRMEHorError;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.PictureBox picGSVSignals;
		private System.Windows.Forms.PictureBox picGSVSkyview;
		private System.Windows.Forms.MenuItem menuItemGPS_Settings;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.TabPage tabNTRIP;
		private System.Windows.Forms.Button btnNTRIPGetSourceTable;
		private System.Windows.Forms.TextBox tbNTRIPPort;
		private System.Windows.Forms.TextBox tbNTRIPServerIP;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGrid dgNTRIPCasters;
		private System.Windows.Forms.DataGrid dgNTRIPNetworks;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label lbRMCPositionUTM;
		//private System.Windows.Forms.MainMenu mainMenu1;
		//private System.Windows.Forms.MenuItem menuItem4;
		//private System.Windows.Forms.MenuItem menuItem_File_Exit;

	}
}

