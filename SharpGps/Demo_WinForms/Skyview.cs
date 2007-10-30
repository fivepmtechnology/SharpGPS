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

namespace Demo_WinForms
{
	public partial class SkyView : UserControl
	{
		private static System.Drawing.Color[] Colors = { Color.Blue , Color.Red , Color.Green, Color.Yellow, Color.Cyan, Color.Orange,
											  Color.Gold , Color.Violet, Color.YellowGreen, Color.Brown, Color.GreenYellow,
											  Color.Blue , Color.Red , Color.Green, Color.Yellow, Color.Aqua, Color.Orange};
		public SkyView()
		{
			InitializeComponent();
		}
		
		public void DrawGSV(SharpGis.SharpGps.NMEA.GPGSV gpgsv, SharpGis.SharpGps.NMEA.GPGSA gpgsa)
		{
			Pen penBlack = new Pen(Color.Black, 1);
			Pen penGray = new Pen(Color.LightGray, 1);
			int iMargin = 4; //Distance to edge of image
			
			StringFormat sFormat = new StringFormat();
			//Generate sky view
			Bitmap imgSkyview = new Bitmap(picGSVSkyview.Width, picGSVSkyview.Height);
			using (Graphics g = Graphics.FromImage(imgSkyview))
			{
				g.Clear(Color.Transparent);
				g.FillEllipse(Brushes.White, 0, 0, imgSkyview.Width - 1, imgSkyview.Height - 1);
				g.DrawEllipse(penGray, 0, 0, imgSkyview.Width - 1, imgSkyview.Height - 1);
				g.DrawEllipse(penGray, imgSkyview.Width / 4, imgSkyview.Height / 4, imgSkyview.Width / 2, imgSkyview.Height / 2);
				g.DrawLine(penGray, imgSkyview.Width / 2, 0, imgSkyview.Width / 2, imgSkyview.Height);
				g.DrawLine(penGray, 0, imgSkyview.Height / 2, imgSkyview.Width, imgSkyview.Height / 2);
				sFormat.LineAlignment = StringAlignment.Near;
				sFormat.Alignment = StringAlignment.Near;
				float radius = 6f;
				for (int i = 0; i < gpgsv.Satellites.Count; i++)
				{
					SharpGis.SharpGps.NMEA.GPGSV.Satellite sat = gpgsv.Satellites[i];
					double ang = 90.0 - sat.Azimuth;
					ang = ang / 180.0 * Math.PI;
					int x = imgSkyview.Width / 2 + (int)Math.Round((Math.Cos(ang) * ((90.0 - sat.Elevation) / 90.0) * (imgSkyview.Width / 2.0 - iMargin)));
					int y = imgSkyview.Height / 2 - (int)Math.Round((Math.Sin(ang) * ((90.0 - sat.Elevation) / 90.0) * (imgSkyview.Height / 2.0 - iMargin)));
					g.FillEllipse(new System.Drawing.SolidBrush(Colors[i]), x - radius * 0.5f, y - radius * 0.5f, radius, radius);

					if (gpgsa.PRNInSolution.Contains(sat.PRN))
					{
						g.DrawEllipse(penBlack, x - radius * 0.5f, y - radius * 0.5f, radius, radius);
						g.DrawString(sat.PRN, new Font("Verdana", 9, FontStyle.Bold), new System.Drawing.SolidBrush(Color.Black), x, y, sFormat);
					}
					else
						g.DrawString(sat.PRN, new Font("Verdana", 8, FontStyle.Italic), new System.Drawing.SolidBrush(Color.Gray), x, y, sFormat);
				}
			}
			picGSVSkyview.Image = imgSkyview;
		}
	}
}
