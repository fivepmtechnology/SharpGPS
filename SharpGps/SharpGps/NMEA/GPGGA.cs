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
using System.Text;

namespace SharpGis.SharpGps.NMEA
{
	/// <summary>
	/// Global Positioning System Fix Data
	/// </summary>
	public class GPGGA
	{
		/// <summary>
		/// Initializes the NMEA Global Positioning System Fix Data
		/// </summary>
		public GPGGA()
		{
			_position = new Coordinate();
		}

		/// <summary>
		/// Initializes the NMEA Global Positioning System Fix Data and parses an NMEA sentence
		/// </summary>
		/// <param name="NMEAsentence"></param>
		public GPGGA(string NMEAsentence)
		{
			try
			{
				if (NMEAsentence.IndexOf('*') > 0)
					NMEAsentence = NMEAsentence.Substring(0, NMEAsentence.IndexOf('*'));
				//Split into an array of strings.
				string[] split = NMEAsentence.Split(new Char[] { ',' });
				if (split[1].Length >= 6)
				{
					TimeSpan t = new TimeSpan(GPSHandler.intTryParse(split[1].Substring(0, 2)),
						GPSHandler.intTryParse(split[1].Substring(2, 2)), GPSHandler.intTryParse(split[1].Substring(4, 2)));
					DateTime nowutc = DateTime.UtcNow;
					nowutc = nowutc.Add(-nowutc.TimeOfDay);
					_timeOfFix = nowutc.Add(t);
					
				}
				
				_position = new Coordinate(GPSHandler.GPSToDecimalDegrees(split[4], split[5]),
										   GPSHandler.GPSToDecimalDegrees(split[2], split[3]));
				if (split[6] == "1")
					_fixQuality = FixQualityEnum.GPS;
				else if (split[6] == "2")
					_fixQuality = FixQualityEnum.DGPS;
				else
					_fixQuality = FixQualityEnum.Invalid;
				_noOfSats = Convert.ToByte(split[7]);
				GPSHandler.dblTryParse(split[8], out _dilution);
				GPSHandler.dblTryParse(split[9], out _altitude);
				_altitudeUnits = split[10][0];
				GPSHandler.dblTryParse(split[11], out _heightOfGeoid);
				GPSHandler.intTryParse(split[13], out _dGPSUpdate);
				_dGPSStationID = split[14];
			}
			catch { }
		}

		/// <summary>
		/// Enum for the GGA Fix Quality.
		/// </summary>
		public enum FixQualityEnum
		{
			/// <summary>
			/// Invalid fix
			/// </summary>
			Invalid = 0,
			/// <summary>
			/// GPS fix
			/// </summary>
			GPS = 1,
			/// <summary>
			/// DGPS fix
			/// </summary>
			DGPS = 2
		}

		#region Properties

		private DateTime _timeOfFix;
		private Coordinate _position;
		private FixQualityEnum _fixQuality;
		private byte _noOfSats;
		private double _altitude;
		private char _altitudeUnits;
		private double _dilution;
		private double _heightOfGeoid;
		private int _dGPSUpdate;
		private string _dGPSStationID;

		/// <summary>
		/// time of fix (hhmmss).
		/// </summary>
		public DateTime TimeOfFix
		{
			get { return _timeOfFix; }
			//set { _timeOfFix = value; }
		}

		/// <summary>
		/// Coordinate of recieved position
		/// </summary>
		public Coordinate Position
		{
			get { return _position; }
			//set { _position = value; }
		}

		/// <summary>
		/// Fix quality (0=invalid, 1=GPS fix, 2=DGPS fix)
		/// </summary>
		public FixQualityEnum FixQuality
		{
			get { return _fixQuality; }
			internal set { _fixQuality = value; }
		}

		/// <summary>
		/// number of satellites being tracked.
		/// </summary>
		public byte NoOfSats
		{
			get { return _noOfSats; }
			//set { _noOfSats = value; }
		}

		/// <summary>
		/// Altitude above sea level.
		/// </summary>
		public double Altitude
		{
			get { return _altitude; }
			//set { _altitude = value; }
		}

		/// <summary>
		/// Altitude Units - M (meters).
		/// </summary>
		public char AltitudeUnits
		{
			get { return _altitudeUnits; }
			//set { _altitudeUnits = value; }
		}

		/// <summary>
		/// Horizontal dilution of position (HDOP).
		/// </summary>
		public double Dilution
		{
			get { return _dilution; }
			//set { _dilution = value; }
		}

		/// <summary>
		/// Height of geoid (mean sea level) above WGS84 ellipsoid.
		/// </summary>
		public double HeightOfGeoid
		{
			get { return _heightOfGeoid; }
			//set { _heightOfGeoid = value; }
		}

		/// <summary>
		/// Time in seconds since last DGPS update.
		/// </summary>
		public int DGPSUpdate
		{
			get { return _dGPSUpdate; }
			//set { _dGPSUpdate = value; }
		}

		/// <summary>
		/// DGPS station ID number.
		/// </summary>
		public string DGPSStationID
		{
			get { return _dGPSStationID; }
			//set { _dGPSStationID = value; }
		}
		#endregion
	}
}