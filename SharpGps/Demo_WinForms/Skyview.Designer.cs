namespace Demo_WinForms
{
	partial class SkyView
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
			this.picGSVSkyview = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picGSVSkyview)).BeginInit();
			this.SuspendLayout();
			// 
			// picGSVSkyview
			// 
			this.picGSVSkyview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picGSVSkyview.Location = new System.Drawing.Point(0, 0);
			this.picGSVSkyview.Name = "picGSVSkyview";
			this.picGSVSkyview.Size = new System.Drawing.Size(150, 150);
			this.picGSVSkyview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picGSVSkyview.TabIndex = 0;
			this.picGSVSkyview.TabStop = false;
			// 
			// SkyView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.picGSVSkyview);
			this.Name = "SkyView";
			((System.ComponentModel.ISupportInitialize)(this.picGSVSkyview)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picGSVSkyview;
	}
}
