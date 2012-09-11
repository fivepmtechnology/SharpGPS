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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SharpGis.SharpGps;

namespace Demo_cs
{
	public partial class MainForm : Form
	{
		public static FrmGpsSettings frmGpsSettings;

		public MainForm()
		{
			InitializeComponent();

			GPS = new GPSHandler(this); //Initialize GPS handler
			GPS.TimeOut = 5; //Set timeout to 5 seconds
			GPS.NewGPSFix += new GPSHandler.NewGPSFixHandler(this.GPSEventHandler); //Hook up GPS data events to a handler
			frmGpsSettings = new FrmGpsSettings();
		}
		public static GPSHandler GPS;

		private void menuItemGPS_Start_Click(object sender, EventArgs e)
		{
			
			
			if (!GPS.IsPortOpen)
			{
				try
				{
					GPS.Start("COM1", 4800); //Open serial port 1 at 4800baud
					menuItemGPS_Start.Text = "Stop";
				}
				catch (System.Exception ex)
				{
					MessageBox.Show("An error occured when trying to open port: " + ex.Message);
				}
			}
			else
			{
				GPS.Stop(); //Close serial port
				menuItemGPS_Start.Text = "Start";
			}	
		}

		/// <summary>
		/// Responds to sentence events from GPS receiver
		/// </summary>
		private void GPSEventHandler(object sender, GPSHandler.GPSEventArgs e)
		{
			tbRawLog.Text += e.Sentence + "\r\n";
			//tbRawLog.Text.Substring(tbRawLog.Text.Length - 2000); //only show last 2000 characters
			tbRawLog.ScrollToCaret(); //Scroll to bottom
			
			switch (e.TypeOfEvent)
			{
				case GPSEventType.GPRMC:  //Recommended minimum specific GPS/Transit data
					if (GPS.HasGPSFix) //Is a GPS fix available?
					{
						lbRMCPosition.Text = GPS.GPRMC.Position.ToString();
						lbRMCCourse.Text = GPS.GPRMC.Course.ToString();
						lbRMCSpeed.Text = GPS.GPRMC.Speed.ToString() + " mph";
						lbRMCTimeOfFix.Text = GPS.GPRMC.TimeOfFix.ToString();
						lbRMCMagneticVariation.Text = GPS.GPRMC.MagneticVariation.ToString();
					}
					else
					{
						statusBar1.Text = "No fix";
						lbRMCCourse.Text = "N/A";
						lbRMCSpeed.Text = "N/A";
						lbRMCTimeOfFix.Text = GPS.GPRMC.TimeOfFix.ToString();
					}
					break;
				case GPSEventType.GPGGA: //Global Positioning System Fix Data
					lbGGAPosition.Text = GPS.GPGGA.Position.ToString();
					lbGGATimeOfFix.Text = GPS.GPGGA.TimeOfFix.Hour.ToString() + ":" + GPS.GPGGA.TimeOfFix.Minute.ToString() + ":" + GPS.GPGGA.TimeOfFix.Second.ToString();
					lbGGAFixQuality.Text = GPS.GPGGA.FixQuality.ToString();
					lbGGANoOfSats.Text = GPS.GPGGA.NoOfSats.ToString();
					lbGGAAltitude.Text = GPS.GPGGA.Altitude.ToString() + " " + GPS.GPGGA.AltitudeUnits;
					lbGGAHDOP.Text = GPS.GPGGA.Dilution.ToString();
					lbGGAGeoidHeight.Text = GPS.GPGGA.HeightOfGeoid.ToString();
					lbGGADGPSupdate.Text = GPS.GPGGA.DGPSUpdate.ToString();
					lbGGADGPSID.Text = GPS.GPGGA.DGPSStationID;
					break;
				case GPSEventType.GPGLL: //Geographic position, Latitude and Longitude
					lbGLLPosition.Text = GPS.GPGLL.Position.ToString();
					lbGLLTimeOfSolution.Text = (GPS.GPGLL.TimeOfSolution.HasValue ? GPS.GPGLL.TimeOfSolution.Value.Hours.ToString() + ":" + GPS.GPGLL.TimeOfSolution.Value.Minutes.ToString() + ":" + GPS.GPGLL.TimeOfSolution.Value.Seconds.ToString() : "");
					lbGLLDataValid.Text = GPS.GPGLL.DataValid.ToString();
					break;
				case GPSEventType.GPGSA: //GPS DOP and active satellites
					if (GPS.GPGSA.Mode == 'A')
						lbGSAMode.Text = "Auto";
					else if (GPS.GPGSA.Mode == 'M')
						lbGSAMode.Text = "Manual";
					else lbGSAMode.Text = "";
					lbGSAFixMode.Text = GPS.GPGSA.FixMode.ToString();
					lbGSAPRNs.Text = "";
					if(GPS.GPGSA.PRNInSolution.Count>0)
						foreach (string prn in GPS.GPGSA.PRNInSolution)
							lbGSAPRNs.Text += prn + " ";
					else
						lbGSAPRNs.Text += "none";
					lbGSAPDOP.Text = GPS.GPGSA.PDOP.ToString();
					lbGSAHDOP.Text = GPS.GPGSA.HDOP.ToString();
					lbGSAVDOP.Text = GPS.GPGSA.VDOP.ToString();
					break;
				case GPSEventType.GPGSV: //Satellites in view
					if (NMEAtabs.TabPages[NMEAtabs.SelectedIndex].Text == "GPGSV") //Only update this tab when it is active
						DrawGSV();
					break;
				case GPSEventType.PGRME: //Garmin proprietary sentences.
					lbRMEHorError.Text = GPS.PGRME.EstHorisontalError.ToString();
					lbRMEVerError.Text = GPS.PGRME.EstVerticalError.ToString();
					lbRMESphericalError.Text = GPS.PGRME.EstSphericalError.ToString();
					break;
				case GPSEventType.TimeOut: //Serialport timeout.
					statusBar1.Text = "Serialport timeout";
					notification1.Caption = "GPS Serialport timeout";
					notification1.InitialDuration = 5;
					notification1.Text = "Check your settings and connection";
					notification1.Critical = false;
					notification1.Visible = true;
					break;
			}
		}
		private void DrawGSV()
		{
			System.Drawing.Color[] Colors = { Color.Blue , Color.Red , Color.Green, Color.Yellow, Color.Aqua, Color.Orange,
											  Color.Blue , Color.Red , Color.Green, Color.Yellow, Color.Aqua, Color.Orange,
											  Color.Blue , Color.Red , Color.Green, Color.Yellow, Color.Aqua, Color.Orange};
			//Generate signal level readout
			int SatCount = GPS.GPGSV.SatsInView;
			Bitmap imgSignals = new Bitmap(picGSVSignals.Width, picGSVSignals.Height);
			Graphics g = Graphics.FromImage(imgSignals);
			g.Clear(Color.White);
			Pen penBlack = new Pen(Color.Black, 1);
			Pen penGray = new Pen(Color.LightGray, 1);
			int iMargin = 4; //Distance to edge of image
			int iPadding = 4; //Distance between signal bars
			g.DrawRectangle(penBlack, 0, 0, imgSignals.Width - 1, imgSignals.Height - 1);
			
			StringFormat sFormat =	new StringFormat();
			int barWidth = 1;
			if(SatCount>0)
				barWidth = (imgSignals.Width - 2 * iMargin-iPadding*(SatCount-1)) / SatCount;

			//Draw horisontal lines
			for (int i = imgSignals.Height - 15; i > iMargin; i -= (imgSignals.Height - 15 - iMargin) / 5)
				g.DrawLine(penGray, 1, i, imgSignals.Width - 2, i);
			sFormat.Alignment = StringAlignment.Center;
			//Draw satellites
			for (int i = 0; i < SatCount; i++)
			{
				SharpGis.SharpGps.NMEA.GPGSV.Satellite sat = GPS.GPGSV.Satellites[i];
				int startx = i * (barWidth + iPadding)+iMargin;
				int starty = imgSignals.Height - 15;
				int height = (imgSignals.Height - 15 - iMargin)/50*sat.SNR;
				g.FillRectangle(new System.Drawing.SolidBrush(Colors[i]), startx, starty, barWidth, -height + 1);
				if (GPS.GPGSA.PRNInSolution.Contains(sat.PRN))
					g.DrawRectangle(penBlack, startx, starty, barWidth, -height);

				sFormat.LineAlignment = StringAlignment.Near;
				g.DrawString(sat.PRN,new Font("Verdana",9,FontStyle.Regular),new System.Drawing.SolidBrush(Color.Black),startx+barWidth/2,imgSignals.Height-15,sFormat);
				sFormat.LineAlignment = StringAlignment.Far;
				g.DrawString(sat.SNR.ToString(), new Font("Verdana", 9, FontStyle.Regular), new System.Drawing.SolidBrush(Color.Black), startx + barWidth / 2, starty-height, sFormat);
			}
			picGSVSignals.Image = imgSignals;

			//Generate sky view
			Bitmap imgSkyview = new Bitmap(picGSVSkyview.Width, picGSVSkyview.Height);
			g = Graphics.FromImage(imgSkyview);
			g.Clear(Color.White);
			g.DrawEllipse(penGray, 0, 0, imgSkyview.Width - 1, imgSkyview.Height - 1);
			g.DrawEllipse(penGray, imgSkyview.Width / 4, imgSkyview.Height / 4, imgSkyview.Width / 2, imgSkyview.Height / 2);
			g.DrawLine(penGray, imgSkyview.Width / 2, 0, imgSkyview.Width / 2, imgSkyview.Height);
			g.DrawLine(penGray, 0, imgSkyview.Height / 2, imgSkyview.Width, imgSkyview.Height / 2);
			sFormat.LineAlignment = StringAlignment.Near;
			sFormat.Alignment = StringAlignment.Near;
			for (int i = 0; i < SatCount; i++)
			{
				SharpGis.SharpGps.NMEA.GPGSV.Satellite sat = GPS.GPGSV.Satellites[i];
				double ang = 90.0-sat.Azimuth;
				ang = ang/180.0*Math.PI;
				int x = imgSkyview.Width/2 + (int)Math.Round((Math.Cos(ang) * ((90.0 - sat.Elevation)/90.0)*(imgSkyview.Width/2.0-iMargin)));
				int y = imgSkyview.Height/2 - (int)Math.Round((Math.Sin(ang) * ((90.0 - sat.Elevation) / 90.0) * (imgSkyview.Height / 2.0-iMargin)));
				g.FillEllipse(new System.Drawing.SolidBrush(Colors[i]), x - 1, y - 1, 3, 3);
				g.DrawString(sat.PRN, new Font("Verdana", 9, FontStyle.Regular), new System.Drawing.SolidBrush(Color.Black), x,y, sFormat);
			}
			picGSVSkyview.Image = imgSkyview;
		}

		private void menuItem_File_Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void menuItemGPS_Settings_Click(object sender, EventArgs e)
		{
			frmGpsSettings.Show();
		}

		private void NMEAtabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (NMEAtabs.TabPages[NMEAtabs.SelectedIndex].Text == "GPGSV")
				DrawGSV();
			else if (NMEAtabs.TabPages[NMEAtabs.SelectedIndex].Text == "Map")
			{
				DrawMap();
			}
		}

		private void DrawMap()
		{
			//CreateSHP();
			//CreateDBF();
		}

		private void btnNTRIPGetSourceTable_Click(object sender, EventArgs e)
		{
			SharpGis.SharpGps.NTRIP.NTRIPClient ntrip = new SharpGis.SharpGps.NTRIP.NTRIPClient(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(tbNTRIPServerIP.Text.Trim()), int.Parse(tbNTRIPPort.Text)));
			// http://igs.ifag.de/root_ftp/misc/ntrip/streamlist_euref-ip.htm
				
			//ntrip.UserName = "user28";
			//ntrip.Password = "hfjfkp";
			SharpGis.SharpGps.NTRIP.SourceTable table = ntrip.GetSourceTable();
			if (table != null)
			{
				dgNTRIPCasters.DataSource = table.Casters;
				dgNTRIPNetworks.DataSource = table.Networks;
				if (table.DataStreams.Count > 0)
					//ntrip.StartNTRIP(table.DataStreams[0].MountPoint);
					ntrip.StartNTRIP("FFMJ2");
					
				else
					MessageBox.Show("Sourcetable doesn't contain any datastreams");
			}
			else
				MessageBox.Show("Failed to request or parse the DataSource Table");
			//MessageBox.Show(table.DataStreams.Count.ToString());

		}

		private void MainForm_Closing(object sender, CancelEventArgs e)
		{
			GPS.Dispose();  //Closes serial port and cleans up. This is important !
		}
	}
}