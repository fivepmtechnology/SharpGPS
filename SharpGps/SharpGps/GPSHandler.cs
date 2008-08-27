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

// History:
// 2005-05-22:	Several bugs in NMEA parsing corrected.
//				DateTime properties is now in UTC.
// 2005-05-14:	Now using .NET 2.0 SerialPort classes
//				Time- and Date values are changed from String to DateTime and Timespan types
// 2005-02-16:	Corrected a problem with ToDouble conversion. (some countries
//				use ',' as decimal seperator) Thanks to Arne Madsen for pointing
//				this out.
// 2005-01-22:	First official OpenSource release

using System;
using System.Threading;

namespace SharpGis.SharpGps
{
	/// <summary>
	/// GPS Handler - GPS Library for Pocket PC
	/// Released under GNU Lesser General Public License
	/// </summary>
	public class GPSHandler : IDisposable
	{
		internal SerialPort GpsPort;
		private ThreadStart clThreadStart;
		private Thread clThread;
		//private static bool portopen = false;
		private System.Windows.Forms.Control _Parent;
		private bool disposed = false;
		//Ensure that we are interpreting '.' as decimal seperator
		internal static System.Globalization.NumberFormatInfo numberFormat_EnUS = new System.Globalization.CultureInfo( "en-US", false ).NumberFormat;

		/// <summary>
		/// Recommended minimum specific GPS/Transit data
		/// </summary>
		public NMEA.GPRMC GPRMC;
		/// <summary>
		/// Global Positioning System Fix Data
		/// </summary>
		public NMEA.GPGGA GPGGA;
		/// <summary>
		/// Satellites in view
		/// </summary>
		public NMEA.GPGSV GPGSV;
		/// <summary>
		/// GPS DOP and active satellites
		/// </summary>
		public NMEA.GPGSA GPGSA;
		/// <summary>
		/// Geographic position, Latitude and Longitude
		/// </summary>
		public NMEA.GPGLL GPGLL;
		/// <summary>
		/// Estimated Position Error - Garmin proprietary sentence(!)
		/// </summary>
		public NMEA.GPRME PGRME;

		/// <summary>
		/// A delegate type for hooking up change notifications.
		/// </summary>
		public delegate void NewGPSFixHandler(object sender, GPSEventArgs e);
		
		/// <summary>
		/// Overridden. Fires when the GpsHandler has received data from the GPS device.
		/// </summary>
		public event NewGPSFixHandler NewGPSFix;
		
		/// <summary>
		/// Event fired whenever new GPS data has been processed. Runs in GPS thread
		/// </summary>
		private event NewGPSFixHandler _NewGPSFix;

		/// <summary>
		/// Initializes a GpsHandler for communication with GPS receiver.
		/// The GpsHandler is used for communication with the GPS device and process information from the GPS revice.
		/// </summary>
		/// <param name="Parent">Parent form which callbacks should be directed to.</param>
		/// <example>
		/// The following example demonstrates how to create an GpsHandler instance that reacts to GPS position events.
		/// <code>
		/// [C#]
		/// public class Form1 : System.Windows.Forms.Form
		/// {
		/// 	public static GPSHandler GPS;
		/// 	public Form1()
		/// 	{
		/// 	InitializeComponent();
		/// 	//Initialize GPS handler
		/// 	GPS = new GPSHandler(this); 
		/// 	//Hook up GPS data events to a handler
		/// 	GPS.NewGPSFix += new GPSHandler.NewGPSFixHandler(this.GPSEventHandler);
		/// }
		/// 
		/// public void ExitApp()
		/// {
		/// 	GPS.Dispose();  //Closes serial port and cleans up
		/// 	Application.Exit();
		/// }
		/// 
		/// private void GPSEventHandler(object sender, GPSHandler.GPSEventArgs e)
		/// {
		/// 	switch (e.TypeOfEvent)
		/// 	{
		/// 		case GPSEventType.GPRMC:  //Recommended minimum specific GPS/Transit data
		/// 			if(GPS.HasGPSFix) //Is a GPS fix available?
		/// 			{
		/// 				lbPosition.Text = GPS.RMC.Longitude.ToString() + "," + GPS.RMC.Latitude.ToString();
		/// 				lbHeading.Text = GPS.RMC.Course.ToString();
		/// 				lbSpeed.Text = GPS.RMC.Speed.ToString() + " mph";
		/// 				lbTimeOfFix.Text = GPS.RMC.TimeOfFix + " - " + GPS.RMC.DateOfFix;
		/// 			}
		/// 			else
		/// 			{
		/// 				lbPosition.Text = "No fix";
		/// 				lbHeading.Text = "N/A";
		/// 				lbSpeed.Text = "N/A";
		/// 				lbTimeOfFix.Text = "N/A";
		/// 			}
		/// 			break;
		/// 	}
		/// }
		/// 
		/// private void btnStartGPS_Click(object sender, System.EventArgs e)
		/// {
		/// 	if(!GPS.IsPortOpen) 
		/// 	{
		/// 		try
		/// 		{
		/// 			//Open serial port 1 at 4800baud               
		/// 			GPS.Start("COM1",4800);
		/// 		}
		/// 		catch(System.Exception ex) 
		/// 		{
		/// 			MessageBox.Show("An error occured when trying to open port: " + ex.Message);
		/// 		}
		/// 	}
		/// }
		/// </code>
		/// </example>
		public GPSHandler(System.Windows.Forms.Control Parent)
		{
			GpsPort = new SerialPort();
			_Parent = Parent;
			disposed = false;
			this._NewGPSFix += new NewGPSFixHandler(this.GPSEventHandler);
			
			//Link event from GPS receiver to process data function
			GpsPort.NewGPSData += new SharpGps.SerialPort.NewGPSDataHandler(this.GPSDataEventHandler);
			this.GPRMC = new SharpGps.NMEA.GPRMC();
			this.GPGGA = new SharpGps.NMEA.GPGGA();
			this.GPGSA = new SharpGps.NMEA.GPGSA();
			this.GPRMC = new SharpGps.NMEA.GPRMC();
			this.PGRME = new SharpGps.NMEA.GPRME();
			this.GPGSV = new SharpGps.NMEA.GPGSV();
		}
		
		/// <summary>
		/// Gets a boolean stating whether the port to the GPS device is open.
		/// </summary>
		public bool IsPortOpen 
		{
			get { return GpsPort.IsPortOpen; }
		}
		
		/// <summary>
		/// Get a boolean stating whether the GPS device has a fix or not.
		/// </summary>
		public bool HasGPSFix
		{
			get 
			{
				return (GPGGA.FixQuality != NMEA.GPGGA.FixQualityEnum.Invalid);
			}
		}

		/// <summary>
		/// Parse event from GPS thread to parent thread
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">GPSEventArgs</param>
		private void GPSEventHandler(object sender, GPSEventArgs e)
		{
			ControlInvoker controlInvoker;
			controlInvoker = new ControlInvoker(this._Parent);
			controlInvoker.Invoke (new MethodCallInvoker (ReturnEvent), e); //Send event to parent thread
		}

		private void ReturnEvent(Object[] arguments) 
		{
			GPSEventArgs e = (GPSEventArgs) arguments[0];
			NewGPSFix(this, e); //Fire event back to main application
		}

		/// <summary>
		/// Eventtype invoked when a new message is received from the GPS.
		/// String GPSEventArgs.TypeOfEvent specifies eventtype.
		/// </summary>
		public class GPSEventArgs:EventArgs
		{
			/// <summary>
			/// Type of event
			/// </summary>
			public GPSEventType TypeOfEvent;
			/// <summary>
			/// Full NMEA sentence
			/// </summary>
			public string Sentence;
		}

		/// <summary>
		/// Returns Garmin estimated horisontal error. This is Garmin proprietary message and may not function with all GPS devices.
		/// </summary>
		public double GPSAccuracy 
		{
			get 
			{ 
				return PGRME.EstHorisontalError;
			}
		}

		/// <summary>
		/// Indicates whether NMEA input is emulated from file
		/// </summary>
		/// <returns>true of emulate is on</returns>
		public bool Emulate
		{
			get { return _emulate; }
			set
			{
				if(value)
					if (!System.IO.File.Exists(_NMEAInputFile))
						throw(new System.Exception("Error. File not set or not found"));
				_emulate = value;
			}
		}
		private bool _emulate;
		internal static string _NMEAInputFile;
		
		/// <summary>
		/// Turns on NMEA emulation
		/// </summary>
		/// <param name="FileName">File to read NMEA sentences from. Set to null or empty to disable emulation</param>
		public void EnableEmulate(string FileName)
		{
			if (String.IsNullOrEmpty(FileName))
			{
				_emulate = false;
				_NMEAInputFile = null;
			}
			else
			{
				_emulate = true;
				if (System.IO.File.Exists(FileName))
					_NMEAInputFile = FileName;
				else
					throw (new System.Exception("Error. File not found"));
			}
		}

		/// <summary>
		/// Starts the GPS thread and opens the port.
		/// </summary>
		/// <param name="BaudRate">Baudrate (usually 4800).</param>
		/// <param name="serialPort">Serialport number where GPS receiver is connected (ie. "COM1").</param>
		public void Start(string serialPort, int BaudRate)
		{
			GpsPort.Port = serialPort;
			GpsPort.BaudRate = BaudRate;
			//this.comport.Open();
			if(!_emulate)
				this.clThreadStart = new ThreadStart(GpsPort.Start);
			else
				this.clThreadStart = new ThreadStart(new SharpGps.GPSHandler.NMEAEmulator(new SharpGps.SerialPort.NewGPSDataHandler(this.GPSDataEventHandler)).Emulator);
			this.clThread = new Thread(this.clThreadStart);
			
			try 
			{
				this.clThread.Start();
			}
			catch(System.Exception ex) 
			{
				throw(ex);
			}
		}

		/// <summary>
		/// Writes data to the GPS device. For instance RTCM data for Differential GPS.
		/// </summary>
		/// <param name="buffer">RTCM or control data to send to GPS</param>
		public void WriteToGPS(byte[] buffer) 
		{
			GpsPort.Write(buffer);
		}

		/// <summary>
		/// Method called when a GPS event occured.
		/// This is where we call the methods that parses each kind of NMEA sentence
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GPSDataEventHandler(object sender, SerialPort.GPSEventArgs e) 
		{
			switch (e.TypeOfEvent)
			{
				case GPSEventType.GPRMC: 
					ParseRMC(e.Sentence);
					break;
				case GPSEventType.GPGGA:
					ParseGGA(e.Sentence);
					break;
				case GPSEventType.GPGLL:
					ParseGLL(e.Sentence);
					break;
				case GPSEventType.GPGSA:
					ParseGSA(e.Sentence);
					break;
				case GPSEventType.GPGSV:
					ParseGSV(e.Sentence);
					break;
				case GPSEventType.PGRME:
					ParseRME(e.Sentence);
					break;
				case GPSEventType.TimeOut:
					FireTimeOut();
					break;
				case GPSEventType.Unknown:
					GPSEventArgs e2 = new GPSEventArgs();
					e2.TypeOfEvent = e.TypeOfEvent;
					e2.Sentence = e.Sentence;
					_NewGPSFix(this, e2);
					break;
				default: break;
			}
		}

		/// <summary>
		/// Stops the GPS thread and closes the port.
		/// </summary>
		public void Stop()
		{
			GPGGA.FixQuality = NMEA.GPGGA.FixQualityEnum.Invalid;
			if(this.clThread!=null)
				this.clThread.Abort();
			GpsPort.Stop();
			this.clThread = null;
			this.clThreadStart = null;
		}

		/// <summary>
		/// Disposes the GpsHandler and if nessesary calls Stop()
		/// </summary>
		public void Dispose() 
		{
			if (!disposed)
			{
				Stop();
				GpsPort.Dispose();
				this.GPGGA = null;
				this.GPGLL = null;
				this.GPGSA = null;
				this.GPRMC = null;
				this.PGRME = null;
				GpsPort = null;
				//this.GPGSV = null;
				disposed = true;
			}
			GC.SuppressFinalize(this);
		}
		/// <summary>
		/// Finalizer
		/// </summary>
		~GPSHandler()
		{
			Dispose();
		}

		/// <summary>
		/// Gets or sets the GpsHandler TimeOut (default: 5 seconds).
		/// </summary>
		public int TimeOut 
		{
			get { return GpsPort.TimeOut; }
			set { GpsPort.TimeOut = value; }
		}

		/// <summary>
		/// Private method for Firing a serialport timeout event
		/// </summary>
		private void FireTimeOut() 
		{
			GPGGA.FixQuality = NMEA.GPGGA.FixQualityEnum.Invalid;
			GPSEventArgs e = new GPSEventArgs();
			e.TypeOfEvent = GPSEventType.TimeOut;
			_NewGPSFix(this, e);
		}

		/// <summary>
		/// Private method for parsing the GPGLL NMEA sentence
		/// </summary>
		/// <param name="strGLL">GPGLL sentence</param>
		private void ParseGLL(string strGLL)
		{
			GPGLL = new NMEA.GPGLL(strGLL);
			GPSEventArgs e = new GPSEventArgs();
			e.TypeOfEvent = GPSEventType.GPGLL;
			e.Sentence = strGLL;
			_NewGPSFix(this, e);
		}

		/// <summary>
		/// Private method for parsing the GPGSV NMEA sentence
		/// GPGSV is a bit different, since it if usually made from several NMEA sentences
		/// </summary>
		/// <param name="strGSV">GPGSV sentence</param>
		private void ParseGSV(string strGSV)
		{
			//fire the event if last GSV message.
			if(GPGSV.AddSentence(strGSV)) 
			{
				GPSEventArgs e = new GPSEventArgs();
				e.TypeOfEvent = GPSEventType.GPGSV;
				e.Sentence = strGSV;
				_NewGPSFix(this, e);
			}
		}

		/// <summary>
		/// Private method for parsing the GPGSA NMEA sentence
		/// </summary>
		/// <param name="strGSA">GPGSA sentence</param>
		private void ParseGSA(string strGSA)
		{
			GPGSA = new NMEA.GPGSA(strGSA);
			//fire the event.
			GPSEventArgs e = new GPSEventArgs();
			e.TypeOfEvent = GPSEventType.GPGSA;
			e.Sentence = strGSA;
			_NewGPSFix(this, e);
		}

		/// <summary>
		/// Private method for parsing the GPGGA NMEA sentence
		/// </summary>
		/// <param name="strGGA">GPGGA sentence</param>
		private void ParseGGA(string strGGA)
		{
			GPGGA = new NMEA.GPGGA(strGGA);
			//fire the event.
			GPSEventArgs e = new GPSEventArgs();
			e.TypeOfEvent = GPSEventType.GPGGA;
			e.Sentence = strGGA;
			_NewGPSFix(this, e);
		}
							
		/// <summary>
		/// Private method for parsing the GPRMC NMEA sentence
		/// </summary>
		/// <param name="strRMC">GPRMC sentence</param>
		private void ParseRMC(string strRMC)
		{
			this.GPRMC = new SharpGps.NMEA.GPRMC(strRMC);

			//fire the event.
			GPSEventArgs e = new GPSEventArgs();
			e.TypeOfEvent = GPSEventType.GPRMC;
			e.Sentence = strRMC;
			_NewGPSFix(this, e);
		}

		/// <summary>
		/// Private method for parsing the PGRME NMEA sentence
		/// </summary>
		/// <param name="strRME">GPRMC sentence</param>
		private void ParseRME(string strRME)
		{
			this.PGRME = new SharpGps.NMEA.GPRME(strRME);
			//fire the event.
			GPSEventArgs e = new GPSEventArgs();
			e.TypeOfEvent = GPSEventType.PGRME;
			e.Sentence = strRME;
			_NewGPSFix(this, e);
		}
		
		/// <summary>
		/// Converts GPS position in d"dd.ddd' to decimal degrees ddd.ddddd
		/// </summary>
		/// <param name="DM"></param>
		/// <param name="Dir"></param>
		/// <returns></returns>
		internal static double GPSToDecimalDegrees(string DM, string Dir)
		{
			try
			{
				if (DM == "" || Dir == "")
				{
					return 0.0;
				}
				//Get the fractional part of minutes
				//DM = '5512.45',  Dir='N'
				//DM = '12311.12', Dir='E'

				string t = DM.Substring(DM.IndexOf("."));
				double FM = double.Parse(DM.Substring(DM.IndexOf(".")),GPSHandler.numberFormat_EnUS);

				//Get the minutes.
				t = DM.Substring(DM.IndexOf(".") - 2, 2);
				double Min = double.Parse(DM.Substring(DM.IndexOf(".") - 2, 2), GPSHandler.numberFormat_EnUS);

				//Degrees
				t = DM.Substring(0, DM.IndexOf(".")-2);
				double Deg = double.Parse(DM.Substring(0, DM.IndexOf(".") - 2), GPSHandler.numberFormat_EnUS);
				
				if (Dir == "S" || Dir == "W")
					Deg = -(Deg + (Min + FM) / 60);
				else
					Deg = Deg + (Min + FM) / 60;
				return Deg;
			}
			catch
			{
				return 0.0;
			}
		}

		/// <summary>
		/// Internal class for parsing doubles. This replaces the Double.TryParse() method that isn't supported by CF.
		/// </summary>
		/// <remarks>Uses EN-us format for parsing doubles</remarks>
		/// <param name="str">string to parse</param>
		/// <param name="result">Output result. 0 if parse failed</param>
		/// <returns>true if parse was succesfull</returns>
		internal static bool dblTryParse(string str, out double result)
		{
			try
			{
				result = double.Parse(str, GPSHandler.numberFormat_EnUS);
				return true;
			}
			catch
			{
				result = 0;
				return false;
			}
		}

		internal static bool intTryParse(string str, out int result)
		{
			try
			{
				result = int.Parse(str, GPSHandler.numberFormat_EnUS);
				return true;
			}
			catch
			{
				result = 0;
				return false;
			}
		}
		internal static int intTryParse(string str)
		{
			try { return int.Parse(str, GPSHandler.numberFormat_EnUS); }
			catch { return 0; }
		}



		internal class NMEAEmulator : IDisposable
		{
			public event SharpGps.SerialPort.NewGPSDataHandler NewGPSData;
			private System.IO.StreamReader file;
			SharpGps.SerialPort.NewGPSDataHandler gpsdatahandler;
			public NMEAEmulator(SharpGps.SerialPort.NewGPSDataHandler handler)
			{
				gpsdatahandler = handler;
			}
			public void Emulator()
			{
				NewGPSData += new SharpGps.SerialPort.NewGPSDataHandler(gpsdatahandler);
				file = new System.IO.StreamReader(GPSHandler._NMEAInputFile);
				while (file!=null)
				{
					if (file.EndOfStream)
					{
						//Start from beginning of file
						file.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
					}
					string line = file.ReadLine();
					SharpGps.SerialPort.GPSEventArgs e = new SharpGps.SerialPort.GPSEventArgs();
					e.TypeOfEvent = GPSHandler.String2Eventtype(line);
					e.Sentence = line;
					NewGPSData(this, e);
					System.Threading.Thread.Sleep(150);
				}
			}
			public void Dispose()
			{
				file.Close();
				file = null;
			}
		}

		/// <summary>
		/// Analyzes a NMEA sentence and returns the corresponding NMEA sentence type
		/// </summary>
		/// <param name="strData">NMEA Sentence</param>
		/// <returns>Sentence type</returns>
		internal static GPSEventType String2Eventtype(string strData)
		{
			if (strData.StartsWith("$" + GPSEventType.GPGGA.ToString()))
				return GPSEventType.GPGGA;
			else if (strData.StartsWith("$" + GPSEventType.GPGLL.ToString()))
				return GPSEventType.GPGLL;
			else if (strData.StartsWith("$" + GPSEventType.GPGSA.ToString()))
				return GPSEventType.GPGSA;
			else if (strData.StartsWith("$" + GPSEventType.GPGSV.ToString()))
				return GPSEventType.GPGSV;
			else if (strData.StartsWith("$" + GPSEventType.GPRMC.ToString()))
				return GPSEventType.GPRMC;
			else if (strData.StartsWith("$" + GPSEventType.PGRME.ToString()))
				return GPSEventType.PGRME;
			else
				return GPSEventType.Unknown;
		}

	}
}
