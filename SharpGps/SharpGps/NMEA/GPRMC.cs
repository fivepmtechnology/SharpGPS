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
	/// Recommended minimum specific GPS/Transit data
	/// </summary>
	public class GPRMC
	{
		/// <summary>
		/// Enum for the Receiver Status information.
		/// </summary>
		public enum StatusEnum
		{
			/// <summary>
			/// Fix warning
			/// </summary>
			Warning,
			/// <summary>
			/// Fix OK
			/// </summary>
			OK,
			/// <summary>
			/// Bad fix
			/// </summary>
			BadFix,
			/// <summary>
			/// GPS fix
			/// </summary>
			GPS,
			/// <summary>
			/// Differential GPS fix
			/// </summary>
			DGPS
		}

		/// <summary>
		/// Initializes the NMEA Recommended minimum specific GPS/Transit data
		/// </summary>
		public GPRMC()
		{
			_position = new Coordinate();
		}

		/// <summary>
		/// Initializes the NMEA Recommended minimum specific GPS/Transit data and parses an NMEA sentence
		/// </summary>
		/// <param name="NMEAsentence"></param>
		public GPRMC(string NMEAsentence)
		{
			try
			{
				//Split into an array of strings.
				string[] split = NMEAsentence.Split(new Char[] { ',' });

				//Extract date/time
				try
				{
					string[] DateTimeFormats = { "ddMMyyHHmmss", "ddMMyy", "ddMMyyHHmmss.FFFFFF" };
					if (split[9].Length >= 6) { //Require at least the date to be present 
						string time = split[9] + split[1]; // +" 0";
						_timeOfFix = DateTime.ParseExact(time, DateTimeFormats, GPSHandler.numberFormat_EnUS, System.Globalization.DateTimeStyles.AssumeUniversal);
					}
					else
						_timeOfFix = new DateTime();
				}
				catch { _timeOfFix = new DateTime(); }

				if (split[2] == "A")
					_status = StatusEnum.OK;
				else
					_status = StatusEnum.Warning;

				_position = new Coordinate(	GPSHandler.GPSToDecimalDegrees(split[5], split[6]),
											GPSHandler.GPSToDecimalDegrees(split[3], split[4]));

				GPSHandler.dblTryParse(split[7], out _speed);
				GPSHandler.dblTryParse(split[8], out _course);
				GPSHandler.dblTryParse(split[10], out _magneticVariation);
			}
			catch { }
		}

		#region Properties

		private Coordinate _position;
		private StatusEnum _status;
		private DateTime _timeOfFix;
		private double _speed;
		private double _course;
		private double _magneticVariation;
		//private string _magneticVariationDirection;

		/// <summary>
		/// Indicates the current status of the GPS receiver.
		/// </summary>
		public StatusEnum Status
		{
			get { return _status; }
			//set { _status = value; }
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
		/// Groundspeed in knots.
		/// </summary>
		public double Speed
		{
			get { return _speed; }
			//set { _speed = value; }
		}
	
		/// <summary>
		/// Course (true, not magnetic) in decimal degrees.
		/// </summary>
		public double Course
		{
			get { return _course; }
			//set { _course = value; }
		}

		/// <summary>
		/// MagneticVariation in decimal degrees.
		/// </summary>
		public double MagneticVariation
		{
			get { return _magneticVariation; }
			//set { _magneticVariation = value; }
		}
	
		///// <summary>
		///// The direction of the magnetic variation.
		///// </summary>
		//public string MagneticVariationDirection
		//{
		//    get { return _magneticVariationDirection; }
		//    //set { _magneticVariationDirections = value; }
		//}

		/// <summary>
		/// Date and Time of fix - Greenwich mean time.
		/// </summary>
		public DateTime TimeOfFix
		{
			get { return _timeOfFix; }
			//set { _timeOfFix = value; }
		}
#endregion
	}
}
