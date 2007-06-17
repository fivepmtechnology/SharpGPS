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
	/// Geographic position, Latitude and Longitude
	/// </summary>
	public class GPGLL
	{
		/// <summary>
		/// Initializes the NMEA Geographic position, Latitude and Longitude
		/// </summary>
		public GPGLL()
		{
		}

		/// <summary>
		/// Initializes the NMEA Geographic position, Latitude and Longitude and parses an NMEA sentence
		/// </summary>
		/// <param name="NMEAsentence"></param>
		public GPGLL(string NMEAsentence)
		{
			try
			{
				//Split into an array of strings.
				string[] split = NMEAsentence.Split(new Char[] { ',' });

				try
				{
					_position = new Coordinate(GPSHandler.GPSToDecimalDegrees(split[3], split[4]),
												GPSHandler.GPSToDecimalDegrees(split[1], split[2]));
				}
				catch { _position = null; }

				try
				{
					_timeOfSolution = new TimeSpan(int.Parse(split[5].Substring(0, 2)),
													int.Parse(split[5].Substring(2, 2)),
													int.Parse(split[5].Substring(4)));	
				}
				catch
				{
					_timeOfSolution = null; // TimeSpan.Zero;
				}
				_dataValid = (split[6] == "A");
			}
			catch { }
		}

		#region Properties

		private Coordinate _position ;
		private TimeSpan? _timeOfSolution;
		private bool _dataValid;

		/// <summary>
		/// Current position
		/// </summary>
		public Coordinate Position
		{
			get { return _position; }
			//set { _position = value; }
		}

		/// <summary>
		/// UTC Of Position Solution
		/// </summary>
		public TimeSpan? TimeOfSolution
		{
			get { return _timeOfSolution; }
			//set { _timeOfSolution = value; }
		}

		/// <summary>
		/// Data valid (true for valid or false for data invalid).
		/// </summary>
		public bool DataValid
		{
			get { return _dataValid; }
			//set { _dataValid = value; }
		}
	
		#endregion
	}
}