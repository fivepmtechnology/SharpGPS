// Copyright 2007 - Morten Nielsen
//
// This file is part of SharpGps.
// SharpGps is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// SharpGps is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with SharpGps; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SharpGPS.Demo
{
	public partial class GpsSignalLevelChart : UserControl
	{
		private static System.Drawing.Color[] Colors = { Color.Blue , Color.Red , Color.Green, Color.Yellow, Color.Cyan, Color.Orange,
											  Color.Gold , Color.Violet, Color.YellowGreen, Color.Brown, Color.GreenYellow,
											  Color.Blue , Color.Red , Color.Green, Color.Yellow, Color.Aqua, Color.Orange};
		public GpsSignalLevelChart()
		{
			InitializeComponent();
		}
		public void DrawSignals(SharpGPS.NMEA.GPGSV gpgsv, SharpGPS.NMEA.GPGSA gpgsa)
		{
			//Generate signal level readout
			int SatCount = gpgsv.SatsInView;
			Bitmap imgSignals = new Bitmap(picGSVSignals.Width, picGSVSignals.Height);
			using (Graphics g = Graphics.FromImage(imgSignals))
			{
				g.Clear(Color.White);
				Pen penBlack = new Pen(Color.Black, 1);
				Pen penGray = new Pen(Color.LightGray, 1);
				int iMargin = 4; //Distance to edge of image
				int iPadding = 4; //Distance between signal bars
				g.DrawRectangle(penBlack, 0, 0, imgSignals.Width - 1, imgSignals.Height - 1);

				StringFormat sFormat = new StringFormat();
				int barWidth = 1;
				if (SatCount > 0)
					barWidth = (imgSignals.Width - 2 * iMargin - iPadding * (SatCount - 1)) / SatCount;

				//Draw horisontal lines
				for (int i = imgSignals.Height - 15; i > iMargin; i -= (imgSignals.Height - 15 - iMargin) / 5)
					g.DrawLine(penGray, 1, i, imgSignals.Width - 2, i);
				sFormat.Alignment = StringAlignment.Center;
				//Draw satellites
				for (int i = 0; i < SatCount; i++)
				{
					SharpGPS.NMEA.GPGSV.Satellite sat = gpgsv.Satellites[i];
					int startx = i * (barWidth + iPadding) + iMargin;
					int starty = imgSignals.Height - 15;
					int height = (imgSignals.Height - 15 - iMargin) / 50 * sat.SNR;
					g.FillRectangle(new System.Drawing.SolidBrush(Colors[i]), startx, starty - height, barWidth, height + 1);
					if (gpgsa.PRNInSolution.Contains(sat.PRN))
						g.DrawRectangle(penBlack, startx, starty - height, barWidth, height);

					sFormat.LineAlignment = StringAlignment.Near;
					g.DrawString(sat.PRN, new Font("Verdana", 9, FontStyle.Regular), new System.Drawing.SolidBrush(Color.Black), startx + barWidth / 2, imgSignals.Height - 15, sFormat);
					sFormat.LineAlignment = StringAlignment.Far;
					g.DrawString(sat.SNR.ToString(), new Font("Verdana", 9, FontStyle.Regular), new System.Drawing.SolidBrush(Color.Black), startx + barWidth / 2, starty - height, sFormat);
				}
			}
			picGSVSignals.Image = imgSignals;
		}
	}
}
