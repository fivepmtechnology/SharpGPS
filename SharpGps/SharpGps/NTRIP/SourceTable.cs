using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGis.SharpGps.NTRIP
{
	public class SourceTable
	{
		public List<NTRIPDataStream> DataStreams;
		public List<NTRIPCaster> Casters;
		public List<NTRIPNetwork> Networks;

		public SourceTable()
		{
			DataStreams = new List<NTRIPDataStream>();
			Casters = new List<NTRIPCaster>();
			Networks = new List<NTRIPNetwork>();
		}

		/// <summary>
		/// Data streams
		/// </summary>
		public struct NTRIPDataStream
		{
			/// <summary>
			/// Caster mountpoint
			/// </summary>
			public string MountPoint;
			/// <summary>
			/// Source identifier, e.g. name of city next to source location
			/// </summary>
			public string Identifier;
			/// <summary>
			/// Data format RTCM, RAW, etc.
			/// </summary>
			public string Format;
			/// <summary>
			/// E.g. RTCM message types or RAW data format etc., update rates in parenthesis in seconds
			/// </summary>
			public string FormatDetails;
			/// <summary>
			/// Data stream contains carrier phase information<br/>
			/// 0 = No (e.g. for DGPS)<br/>
			/// 1 = Yes, L1 (e.g. for RTK)<br/>
			/// 2 = Yes, L1 &amp; L2 (e.g. for RTK)<br/>
			/// </summary>
			public int Carrier;
			/// <summary>
			/// Navigation system(s)
			/// <remarks>Examples: GPS, GPS+GLO, EGNOS</remarks>
			/// </summary>
			public string NavSystem;
			/// <summary>
			/// Network. Example: EUREF, IGS, IGLOS, SAPOS, GREF, Misc
			/// </summary>
			public string NetWork;
			/// <summary>
			/// Three character country code in ISO 3166
			/// </summary>
			public string Country;
			/// <summary>
			/// Position, latitude, north (approximate position in case of nmea = 1)
			/// </summary>
			public float Latitude;
			/// <summary>
			/// Position, longitude, east (approximate position in case of nmea = 1)
			/// </summary>
			public float Longitude;
			/// <summary>
			/// Necessity for Client to send NMEA message with approximate position to Caster.<br/>
			/// 0 = Client must not send NMEA message with approximate position to Caster.<br/>
			/// 1 = Client must send NMEA GGA message with approximate position to Caster.<br/>
			/// </summary>
			public int NMEA;
			/// <summary>
			/// Stream generated from single reference station or from networked reference stations.<br/>
			/// 0 = Single base, 1 = Network
			/// </summary>
			public int Solution;
			/// <summary>
			/// Hard- or software generating data stream
			/// </summary>
			public string Generator;
			/// <summary>
			/// Compression algorithm
			/// </summary>
			public string Compression;
			/// <summary>
			/// Access protection for this particular data stream<br/>
			/// </summary>
			public AuthenticationType Authentication;
			/// <summary>
			/// User fee required for receiving this particular data stream<br/>
			/// false = No user fee<br/>
			/// true = Usage is charged
			/// </summary>
			public bool Fee;
			/// <summary>
			/// Bitrate of data stream, bits per second 
			/// </summary>
			public int BitRate;
			/// <summary>
			/// Miscellaneous information
			/// </summary>
			public string Miscellanous;

			public static NTRIPDataStream ParseFromString(string line)
			{
				string[] strData = line.Trim().Split(';');
				NTRIPDataStream data = new NTRIPDataStream();
				data.MountPoint = strData[1];
				data.Identifier = strData[2];
				data.Format = strData[3];
				data.FormatDetails = strData[4];
				data.Carrier = int.Parse(strData[5]);
				data.NavSystem = strData[6];
				data.NetWork = strData[7];
				data.Country = strData[8];
				data.Latitude = float.Parse(strData[9]);
				data.Longitude = float.Parse(strData[10]);
				data.NMEA = int.Parse(strData[11]);
				data.Solution = int.Parse(strData[12]);
				data.Generator = strData[13];
				data.Compression = strData[14];
				if (strData[15] == "B")
					data.Authentication = AuthenticationType.Basic;
				else if (strData[15] == "D")
					data.Authentication = AuthenticationType.Digest;
				else
					data.Authentication = AuthenticationType.None;
				if(strData.Length>16)
					data.Fee = (strData[16] == "Y");
				data.BitRate = int.Parse(strData[17]);
				data.Miscellanous = strData[18];
				return data;
			}
		}

		/// <summary>
		/// The NtripCaster is basically an HTTP server supporting a subset of HTTP request/response
		/// messages and adjusted to low-bandwidth streaming data (from 50 up to 500 Bytes/sec per
		/// stream). The NtripCaster accepts request-messages on a single port from either the NtripServer
		/// or the NtripClient. Depending on these messages, the NtripCaster decides whether there is
		/// streaming data to receive or to send.
		/// </summary>
		public struct NTRIPCaster
		{
			/// <summary>
			/// Caster Internet host domain name or IP address
			/// </summary>
			public System.Net.IPEndPoint Host;
			/// <summary>
			/// Caster identifier, e.g. name of provider
			/// </summary>
			public string Identifier;
			/// <summary>
			/// Name of institution / agency / company operating the Caster
			/// </summary>
			public string Operator;
			/// <summary>
			/// Capability of Caster to receive NMEA message with approximate position from Client
			/// </summary>
			/// <remarks>
			/// false = Caster is not able to handle incoming NMEA message with approximate position from Client<br/>
			/// true = Caster is able to handle incoming NMEA GGA message with approximate position from Client
			/// </remarks>
			public bool NMEA;
			/// <summary>
			/// Three character country code in ISO 3166
			/// </summary>
			public string Country;
			/// <summary>
			/// Position, latitude, north
			/// </summary>
			public double Latitude;
			/// <summary>
			/// Position, longitude, east
			/// </summary>
			public double Longitude;
			/// <summary>
			/// Fallback Caster IP address
			/// </summary>
			public string FallbackHost;

			public static NTRIPCaster ParseFromString(string line)
			{
				string[] strData = line.Trim().Split(';');
				NTRIPCaster data = new NTRIPCaster();
				data.Host = new System.Net.IPEndPoint(System.Net.Dns.GetHostByName(strData[1]).AddressList[0], int.Parse(strData[2]));
				//data.Host = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(strData[1]),int.Parse(strData[2]));
				data.Identifier = strData[3];
				data.Operator = strData[4];
				data.NMEA = (strData[5] == "1");
				data.Country = strData[6];
				SharpGps.GPSHandler.dblTryParse(strData[7], out data.Latitude);
				SharpGps.GPSHandler.dblTryParse(strData[8], out data.Longitude);
				if(strData.Length>9)
					data.FallbackHost = strData[9];
				return data;
			}
		}

		/// <summary>
		/// Networks of data streams
		/// </summary>
		public struct NTRIPNetwork
		{
			/// <summary>
			/// Network identifier, e.g. name of a network of GNSS permanent reference stations
			/// </summary>
			public string Identifier;
			/// <summary>
			/// Name of institution / agency / company operating the network
			/// </summary>
			public string Operator;
			/// <summary>
			/// Access protection for data streams of the network<br/>
			/// </summary>
			public AuthenticationType Authentication;
			/// <summary>
			/// Specifies whether a user fee is required for receiving data streams from this network
			/// </summary>
			public bool Fee;
			/// <summary>
			/// Web-address for network information
			/// </summary>
			public Uri WebAddress;
			/// <summary>
			/// Web-address for stream information
			/// </summary>
			public Uri WebStream;
			/// <summary>
			/// Web address or mail address for registration
			/// </summary>
			public Uri WebRegistration;

			public static NTRIPNetwork ParseFromString(string line)
			{
				string[] strData = line.Trim().Split(';');
				NTRIPNetwork data = new NTRIPNetwork();
				data.Identifier = strData[1];
				data.Operator = strData[2];
				if (strData[3] == "B")
					data.Authentication = AuthenticationType.Basic;
				else if (strData[3] == "D")
					data.Authentication = AuthenticationType.Digest;
				else
					data.Authentication = AuthenticationType.None;

				data.Fee = (strData[4] == "Y");
				try { data.WebAddress = new Uri(strData[5]); }
				catch { }
				try { data.WebStream = new Uri(strData[6]); }
				catch { }
				try { data.WebRegistration = new Uri(strData[7]); }
				catch { }
				return data;
			}
		}

		/// <summary>
		/// Type of Authentication required
		/// </summary>
		public enum AuthenticationType
		{
			None = 0,
			Basic = 1,
			Digest = 2
		}
	}
}
