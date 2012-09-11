namespace SharpGPS.Demo
{
	partial class GpsSignalLevelChart
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.picGSVSignals = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picGSVSignals)).BeginInit();
			this.SuspendLayout();
			// 
			// picGSVSignals
			// 
			this.picGSVSignals.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picGSVSignals.Location = new System.Drawing.Point(0, 0);
			this.picGSVSignals.Name = "picGSVSignals";
			this.picGSVSignals.Size = new System.Drawing.Size(150, 150);
			this.picGSVSignals.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picGSVSignals.TabIndex = 0;
			this.picGSVSignals.TabStop = false;
			// 
			// GpsSignalLevelChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.picGSVSignals);
			this.Name = "GpsSignalLevelChart";
			((System.ComponentModel.ISupportInitialize)(this.picGSVSignals)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picGSVSignals;
	}
}
