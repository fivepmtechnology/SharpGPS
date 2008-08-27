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

namespace Demo_WinForms
{
	public partial class MainForm : Form
	{
		//TODO: Change this to be set from settings
		//public const string ActiveSerialPort = "COM3";
		//public const int SerialPortSpeed = 4800;

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
					//GPS.EnableEmulate(@"..\Bristol_Nottingham.txt"); //Uncomment this and change filepath to valid NMEA log file for emulating GPS data
					
					GPS.Start(frmGpsSettings.SerialPort, frmGpsSettings.BaudRate); //Open serial port
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
			if (tbRawLog.Text.Length > 20 * 1024 * 1024) //20Kb maximum - prevents crash
			{
				tbRawLog.Text = tbRawLog.Text.Substring(10 * 1024 * 1024);
			}
			tbRawLog.ScrollToCaret(); //Scroll to bottom
			
			switch (e.TypeOfEvent)
			{
				case GPSEventType.GPRMC:  //Recommended minimum specific GPS/Transit data
					if (GPS.HasGPSFix) //Is a GPS fix available?
					{
						//lbRMCPosition.Text = GPS.GPRMC.Position.ToString("#.000000");
						lbRMCPosition.Text = GPS.GPRMC.Position.ToString("DMS");
						double[] utmpos = TransformToUTM(GPS.GPRMC.Position);
						lbRMCPositionUTM.Text = utmpos[0].ToString("#.0N ") + utmpos[0].ToString("#.0E") + " (Zone: " + utmpos[2] + ")";
						lbRMCCourse.Text = GPS.GPRMC.Course.ToString();
						lbRMCSpeed.Text = GPS.GPRMC.Speed.ToString() + " mph";
						lbRMCTimeOfFix.Text = GPS.GPRMC.TimeOfFix.ToString("F");
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
					if(GPS.GPGGA.Position!=null)
						lbGGAPosition.Text = GPS.GPGGA.Position.ToString("DM");
					else
						lbGGAPosition.Text = "";
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
					lbGSAPDOP.Text = GPS.GPGSA.PDOP.ToString() + " (" + DOPtoWord(GPS.GPGSA.PDOP) +")";
					lbGSAHDOP.Text = GPS.GPGSA.HDOP.ToString() + " (" + DOPtoWord(GPS.GPGSA.HDOP) + ")";
					lbGSAVDOP.Text = GPS.GPGSA.VDOP.ToString() + " (" + DOPtoWord(GPS.GPGSA.VDOP) + ")";
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
					/*notification1.Caption = "GPS Serialport timeout";
					notification1.InitialDuration = 5;
					notification1.Text = "Check your settings and connection";
					notification1.Critical = false;
					notification1.Visible = true;
					 */
					break;
			}
		}
		private double[] TransformToUTM(SharpGis.SharpGps.Coordinate p)
		{
			//For fun, let's use the SharpMap transformation library and display the position in UTM
			int zone = (int)Math.Floor((p.Longitude+183)/6.0);			
			SharpMap.CoordinateSystems.ProjectedCoordinateSystem proj = SharpMap.CoordinateSystems.ProjectedCoordinateSystem.WGS84_UTM(zone, (p.Latitude>=0));
			SharpMap.CoordinateSystems.Transformations.ICoordinateTransformation trans =
				new SharpMap.CoordinateSystems.Transformations.CoordinateTransformationFactory().CreateFromCoordinateSystems(proj.GeographicCoordinateSystem, proj);
			double[] result = trans.MathTransform.Transform(new double[] { p.Longitude, p.Latitude });
			return new double[] { result[0], result[1], zone };
		}
		private string DOPtoWord(double dop)
		{
			if (dop < 1.5) return "Ideal";
			else if (dop < 3) return "Excellent";
			else if (dop < 6) return "Good";
			else if (dop < 8) return "Moderate";
			else if (dop < 20) return "Fair";
			else return "Poor";
		}
		private void DrawGSV()
		{
			gpsSignalLevelChart1.DrawSignals(GPS.GPGSV, GPS.GPGSA);
			skyview1.DrawGSV(GPS.GPGSV, GPS.GPGSA);
		}

		private void menuItem_File_Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void menuItemGPS_Settings_Click(object sender, EventArgs e)
		{
			if (GPS.IsPortOpen) frmGpsSettings.DisableConfig();
			else frmGpsSettings.EnableConfig();

			frmGpsSettings.Show();
		}

		private void NMEAtabs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (NMEAtabs.TabPages[NMEAtabs.SelectedIndex].Text == "GPGSV")
				DrawGSV();
		}
				
		private void btnNTRIPGetSourceTable_Click(object sender, EventArgs e)
		{
			SharpGis.SharpGps.NTRIP.NTRIPClient ntrip = new SharpGis.SharpGps.NTRIP.NTRIPClient(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(tbNTRIPServerIP.Text.Trim()), int.Parse(tbNTRIPPort.Text)), GPS);
			// http://igs.ifag.de/root_ftp/misc/ntrip/streamlist_euref-ip.htm
				
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
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			GPS.Dispose();  //Closes serial port and cleans up. This is important !
		}
	}
}