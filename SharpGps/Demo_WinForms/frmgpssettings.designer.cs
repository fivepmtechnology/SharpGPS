// Copyright 2005 - Morten Nielsen (www.iter.dk)
//
// This file is part of PocketGpsLib.
// PocketGpsLib is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// PocketGpsLib is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with PocketGpsLib; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

namespace Demo_WinForms
{
	partial class FrmGpsSettings
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
			this.cmbPorts = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbBaudRate = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cmbPorts
			// 
			this.cmbPorts.Location = new System.Drawing.Point(115, 24);
			this.cmbPorts.Name = "cmbPorts";
			this.cmbPorts.Size = new System.Drawing.Size(100, 21);
			this.cmbPorts.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "Serial port";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Baudrate";
			// 
			// tbBaudRate
			// 
			this.tbBaudRate.Location = new System.Drawing.Point(115, 53);
			this.tbBaudRate.Name = "tbBaudRate";
			this.tbBaudRate.Size = new System.Drawing.Size(100, 20);
			this.tbBaudRate.TabIndex = 3;
			this.tbBaudRate.Text = "4800";
			// 
			// FrmGpsSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(228, 87);
			this.Controls.Add(this.tbBaudRate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbPorts);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(244, 123);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(244, 123);
			this.Name = "FrmGpsSettings";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GPS Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbPorts;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbBaudRate;
	}
}