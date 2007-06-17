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
	/// Estimated Position Error
	/// The following are Garmin proprietary sentences.  "P" denotes
	/// proprietary, "GRM" is Garmin's manufacturer code.
	/// </summary>
	public class GPRME
	{
		/// <summary>
		/// Initializes the NMEA Estimated Position Error
		/// </summary>
		public GPRME()
		{
		}

		/// <summary>
		/// Initializes the NMEA Estimated Position Error and parses an NMEA sentence
		/// </summary>
		/// <param name="NMEAsentence"></param>
		public GPRME(string NMEAsentence)
		{
			try
			{
				//Split into an array of strings.
				string[] split = NMEAsentence.Split(new Char[] { ',' });
				GPSHandler.dblTryParse(split[1], out _estHorisontalError);
				GPSHandler.dblTryParse(split[3], out _estVerticalError);
				GPSHandler.dblTryParse(split[5], out _estSphericalError);
			}
			catch { }
		}

		#region Properties

		private double _estHorisontalError;
		private double _estVerticalError;
		private double _estSphericalError;

		/// <summary>
		/// Estimated horizontal position error in metres (HPE)
		/// </summary>
		public double EstHorisontalError
		{
			get { return _estHorisontalError; }
			//set { _estHorisontalError = value; }
		}

		/// <summary>
		/// Estimated vertical error (VPE) in metres
		/// </summary>
		public double EstVerticalError
		{
			get { return _estVerticalError; }
			//set { _estVerticalError = value; }
		}

		/// <summary>
		/// Overall spherical equivalent position error
		/// </summary>
		public double EstSphericalError
		{
			get { return _estSphericalError; }
			//set { _estSphericalError = value; }
		}
		#endregion
	}
}