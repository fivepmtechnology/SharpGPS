// Copyright 2005 - Morten Nielsen (www.iter.dk)
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

//
// 2005-05-22: Added checksum checking
//


using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace SharpGis.SharpGps
{
	/// <summary>
	/// Class for handling serial communications with the GPS receiver
	/// </summary>
	internal class SerialPort : IDisposable
	{
		private int _TimeOut = 5; //Set default timeout to 5 seconds
		private long TimeSinceLastEvent;
		private bool HasTimedOut;
		private const int _receivedBytesThreshold = 200;
		private System.IO.Ports.SerialPort com;
		private bool disposed = false;
		
		/// <summary>
		/// Initilializes the serialport
		/// </summary>
		public SerialPort()
		{
			com = new System.IO.Ports.SerialPort();
			disposed = false;
		}
		public SerialPort(string SerialPort, int BaudRate)
		{
			com = new System.IO.Ports.SerialPort(SerialPort, BaudRate);
			disposed = false;
		}

		public void Dispose()
		{
			if (!this.disposed)
			{
				this.Stop();
				com = null;
			}
			disposed = true;

			// Take yourself off the Finalization queue 
			// to prevent finalization code for this object
			// from executing a second time.
			GC.SuppressFinalize(this);
		}
		/// <summary>
		/// Finalizer
		/// </summary>
		~SerialPort()
		{
			Dispose();
		}

		/// <summary>
		/// Gets or sets the timeout in seconds.
		/// <remarks>5 second default</remarks>
		/// </summary>
		internal int TimeOut 
		{
			get { return _TimeOut; }
			set { _TimeOut = value; }
		}

		/// <summary>
		/// Serial port
		/// </summary>
		internal string Port
		{
			get { return com.PortName; }
			set { com.PortName = value; }
		}

		/// <summary>
		/// BaudRate
		/// </summary>
		internal int BaudRate
		{
			get { return com.BaudRate; }
			set { com.BaudRate = value; }
		}

		/// <summary>
		/// Opens the GPS port ans starts parsing data
		/// </summary>
		private void Open() 
		{
			TimeSinceLastEvent = DateTime.Now.Ticks;
			HasTimedOut = false;
			//com.DataReceived += new SerialDataReceivedEventHandler(this.Read);
			try
			{
				com.Open();
			}
			catch (System.IO.IOException ex)
			{
				//Some devices (like iPAQ H4100 among others) throws an IOException for no reason
				//Lets just ignore it and run along
				//Thanks to Shaun O'Callaghan for pointing this out
			}
			catch (System.Exception ex)
			{
				throw new ApplicationException("Could not open com port", ex);
			}
		}

		/// <summary>
		/// Species whether the serialport is open or not
		/// </summary>
		internal bool IsPortOpen
		{
			get { return com.IsOpen; }
		}

		/// <summary>
		/// Opens the serial port and starts parsing NMEA data. Returns when the port is closed.
		/// </summary>
		internal void Start()
		{
			Read();
		}

		/// <summary>
		/// Check the serial port for data. If data is available, data is read and parsed.
		/// This is a loop the keeps running until the port is closed.
		/// </summary>
		private void Read()
		{
			int MilliSecondsWait = 10;
			string strData = "";
			this.Open();

			while (com.IsOpen)
			{
				int nBytes = com.BytesToRead;
				byte[] BufBytes;
				BufBytes = new byte[nBytes];

				com.Read(BufBytes, 0, nBytes);

				strData += Encoding.GetEncoding("ASCII").GetString(BufBytes, 0, nBytes);

				string temp = "";
				while (strData != temp)
				{
					temp = strData;
					strData = GetNmeaString(strData);
				}

				Thread.Sleep(MilliSecondsWait);

				if (DateTime.Now.Ticks - TimeSinceLastEvent > 10000000 * _TimeOut && !HasTimedOut)
				{
					HasTimedOut = true;
					FireEvent(GPSEventType.TimeOut, "");
				}
			}
		}
		
		/// <summary>
		/// Writes data to serial port. This is useful for sending DGPS data to the device.
		/// </summary>
		/// <param name="BufBytes">Data to write to serial port</param>
		internal void Write(byte[] BufBytes)
		{
			com.Write(BufBytes, 0, BufBytes.Length);
		}

		/// <summary>
		/// Fires a NewGPSFix event
		/// </summary>
		/// <param name="type">Type of GPS event (GPGGA, GPGSA, etx...)</param>
		/// <param name="sentence">NMEA Sentence</param>
		private void FireEvent(GPSEventType type, string sentence) 
		{
			GPSEventArgs e = new GPSEventArgs();
			e.TypeOfEvent = type;
			e.Sentence = sentence;
			NewGPSData(this, e);
		}
		/// <summary>
		/// Delegate type for hooking up change notifications.
		/// </summary>
 		public delegate void NewGPSDataHandler(object sender, GPSEventArgs e);
		/// <summary>
		/// Event fired whenever new GPS data is acquired from the receiver.
		/// </summary>
		internal event NewGPSDataHandler NewGPSData;

		/// <summary>
		/// Eventtype parsed when GPS sends a sentence
		/// </summary>
		internal class GPSEventArgs : EventArgs
		{
			/// <summary>
			/// Type of event that occured, specied by NMEA type (GPRMC, GPGGA, GPGSA, GPGLL, GPGSV or PGRME)
			/// </summary>
			public GPSEventType TypeOfEvent;
			/// <summary>
			/// The complete NMEA sentence received
			/// </summary>
			public string Sentence;
		}

		/// <summary>
		/// Closes the port and ends the thread.
		/// </summary>
		internal void Stop() 
		{
			if(com!=null)
				if(com.IsOpen)
					com.Close();
		}

		/// <summary>
		/// Extracts a full NMEA string from the data recieved on the serialport, and parses this.
		/// The remaining and unparsed NMEA string is returned.
		/// </summary>
		/// <param name="strNMEA">NMEA ASCII data</param>
		/// <returns>Unparsed NMEA data</returns>
		private string GetNmeaString(string strNMEA) 
		{
			strNMEA = strNMEA.Replace("\n", "").Replace("\r", ""); //Remove linefeeds

			int nStart = strNMEA.IndexOf("$"); //Position of first NMEA data
			if (nStart < 0 || nStart==strNMEA.Length-2)
				return strNMEA;

			//This will never pass the last NMEA sentence, before the next one arrives
			//The following should instead stop at the end of the line. 
			int nStop = strNMEA.IndexOf("$",nStart+1); //Position of next NMEA sentence

			if (nStop>-1)
			{
				string strData;
				strData = strNMEA.Substring(nStart, nStop-nStart).Trim();
				if (strData.StartsWith("$"))
				{
					HasTimedOut = false;
					TimeSinceLastEvent = DateTime.Now.Ticks;
					if(CheckSentence(strData))
						FireEvent(GPSHandler.String2Eventtype(strData), strData);
				}
				return strNMEA.Substring(nStop);
			}
			else
				return strNMEA;
		}

		/// <summary>
		/// Checks the checksum of a NMEA sentence
		/// </summary>
		/// <remarks>
		/// The optional checksum field consists of a "*" and two hex digits 
		/// representing the exclusive OR of all characters between, but not
		/// including, the "$" and "*".  A checksum is required on some
		/// sentences.
		/// </remarks>
		/// <param name="strSentence">NMEA Sentence</param>
		/// <returns>'true' of checksum is correct</returns>
		private bool CheckSentence(string strSentence)
		{
			int iStart = strSentence.IndexOf('$');
			int iEnd = strSentence.IndexOf('*');
			//If start/stop isn't found it probably doesn't contain a checksum,
			//or there is no checksum after *. In such cases just return true.
			if (iStart >= iEnd || iEnd+3>strSentence.Length)
				return true;
			byte result = 0;
			for (int i = iStart + 1; i < iEnd; i++)
				result ^= (byte)strSentence[i];
			return (result.ToString("X") == strSentence.Substring(iEnd+1, 2));
		}

	}
}
