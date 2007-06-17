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
	/// GPS DOP and active satellites
	/// </summary>
	public class GPGSA
	{

		/// <summary>
		/// Enum for the GSA Fix mode
		/// </summary>
		public enum GSAFixModeEnum
		{
			/// <summary>
			/// No fix available
			/// </summary>
			FixNotAvailable = 0,
			/// <summary>
			/// Horisontal fix only
			/// </summary>
			_2D = 2,
			/// <summary>
			/// 3D fix
			/// </summary>
			_3D = 3
		}

		/// <summary>
		/// Initializes the NMEA GPS DOP and active satellites
		/// </summary>
		public GPGSA()
		{
			_pRNInSolution = new List<string>();
		}

		/// <summary>
		///  GPS DOP and active satellites and parses an NMEA sentence
		/// </summary>
		/// <param name="NMEAsentence"></param>
		public GPGSA(string NMEAsentence)
		{
			_pRNInSolution = new List<string>(); 
			try
			{
				if (NMEAsentence.IndexOf('*') > 0)
					NMEAsentence = NMEAsentence.Substring(0, NMEAsentence.IndexOf('*'));
				//Split into an array of strings.
				string[] split = NMEAsentence.Split(new Char[] { ',' });
				if (split[1].Length > 0)
					_mode = split[1][0];
				else
					_mode = ' ';
				if (split[2].Length > 0)
				{
					switch (split[2])
					{
						case "2": _fixMode = GSAFixModeEnum._2D; break;
						case "3": _fixMode = GSAFixModeEnum._3D; break;
						default: _fixMode = GSAFixModeEnum.FixNotAvailable; break;
					}
				}
				_pRNInSolution.Clear();
				for (int i = 0; i <= 11; i++)
					if(split[i + 3]!="")
						_pRNInSolution.Add(split[i + 3]);
				GPSHandler.dblTryParse(split[15], out _pdop);
				GPSHandler.dblTryParse(split[16], out _hdop);
				GPSHandler.dblTryParse(split[17], out _vdop);
			}
			catch { }
		}



		#region Properties

		private char _mode;
		private GSAFixModeEnum _fixMode;
		private System.Collections.Generic.List<string> _pRNInSolution;
		private double _pdop;
		private double _hdop;
		private double _vdop;

		/// <summary>
		/// Mode. M=Manuel, A=Auto (forced/not forced to operate in 2D or 3D mode)
		/// </summary>
		public char Mode
		{
			get { return _mode; }
			//set { _mode = value; }
		}

		/// <summary>
		/// Fix not available / 2D / 3D
		/// </summary>
		public GSAFixModeEnum FixMode
		{
			get { return _fixMode; }
			//set { _fixMode = value; }
		}

		/// <summary>
		/// PRN Numbers used in solution
		/// </summary>
		public System.Collections.Generic.List<string> PRNInSolution
		{
			get { return _pRNInSolution; }
			//set { _pRNInSolution = value; }
		}

		/// <summary>
		/// Point Dilution of Precision
		/// </summary>
		public double PDOP
		{
			get { return _pdop; }
			//set { _pdop = value; }
		}

		/// <summary>
		/// Horisontal Dilution of Precision
		/// </summary>
		public double HDOP
		{
			get { return _hdop; }
			//set { _hdop = value; }
		}

		/// <summary>
		/// Vertical Dilution of Precision
		/// </summary>
		public double VDOP
		{
			get { return _vdop; }
			//set { _vdop = value; }
		}
		#endregion
	}
}
