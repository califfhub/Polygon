using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonTest
{
	// this is a vector point with double coordinates for computations only.
	// When rendered on a screen it is rounded and converted into DrawablePoint.
	public struct DPoint
	{
		
		public DPoint(double _x, double _y)
		{
			this.x = _x;
			this.y = _y;
		}

		// data members
		public double x;
		public double y;
	}
}
