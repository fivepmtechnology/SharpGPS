using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGis.SharpGps.Coordinates
{
	public class Coordinate : ICoordinate
	{

		public Coordinate(double x, double y)
		{
			_X = x;
			_Y = y;
		}

		#region ICoordinate Members

			private double _X;
		private double _Y;

		public double X
		{
			get { return _X; }
			set { _X = value; }
		}

		
		public double Y
		{
			get { return _Y; }
			set { _Y = value; }
		}
		#endregion
	}
}
