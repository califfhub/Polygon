using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonTest
{
	/// <summary>
	/// Represents a point with coordinates that could be rendered on screen.
	/// </summary>
	struct DrawablePoint
	{
		public DrawablePoint(DPoint pt)
		{
			x = (int)(pt.x + 0.5);
			y = (int)(pt.y + 0.5);
			color = System.Drawing.Color.Black;
		}

		public DrawablePoint(DPoint pt, System.Drawing.Color col) {
			x = (int)pt.x;
			y = (int)pt.y;
			color = col;
		}

		public int x;
		public int y;
		public System.Drawing.Color color;
	}
}
