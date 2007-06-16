using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGis.SharpGps.Coordinates
{
	public interface ICoordinate
	{
		double X { get; set; }
		double Y { get; set; }
		string ToString();
	}
}
