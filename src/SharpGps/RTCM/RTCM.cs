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

namespace SharpGPS
{
	class RTCM
	{
		private const byte _PREAMBLE_ = 198; //01100110;
		private const int n = 32;
		private const int k = 24;
		private const int d = 4;
		private enum MessageType : int
		{
			DifferentialGPScorrections = 1,
			DeltaDifferentialCorrections = 2,
			ReferenceStationsParameters = 3,
			HighRateDifferentialCorrections = 9
		}
		public static void DecodeRTCM(byte[] RtcmData)
		{
			//System.Collections.BitArray bits = new System.Collections.BitArray(RtcmData);
			
		}
	}
}
