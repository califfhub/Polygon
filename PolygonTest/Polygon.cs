using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonTest
{
	// Class represents a polygon with a number of vertices.
	class Polygon
	{
		public Polygon()
		{
			mVertices = new List<DPoint>();
		}

		public Polygon(List<DPoint> vertices)
		{
			mVertices = new List<DPoint>(vertices);
			mIsValid = CheckValid();
		}

		// Adds a new vertex to polygon
		public void AddVertice(DPoint point)
		{
			DPoint dp = mVertices.FirstOrDefault(p => p.x == point.x && p.y == point.y);
			if (dp.x == 0.0 && dp.y == 0.0)
			{
				mVertices.Add(point);
				mIsValid = CheckValid();
			}
		}

		// Removes the last polygon vertex, if any
		public void RemoveLastVertex()
		{
			if (mVertices.Count > 0)
				mVertices.RemoveAt(mVertices.Count - 1);
		}

		
		// Returns true is point is inside of the polygon formed from vertices.
		// This is the standard implementation of the algorithm for counting crossing points of a ray from the point.
		public bool isPointInside(DPoint point)
		{
			if (isValid()) 
			{
				int counter = 0; // counts crossings
				int n = mVertices.Count; // number of vertices

				// the algorithm requires the last element to loop back to the first element
				mVertices.Add(mVertices[0]);

				for (int i = 0; i < n; i++)
				{
					if (((mVertices[i].y <= point.y) && (mVertices[i + 1].y >  point.y)) ||  // an upward crossing
						((mVertices[i].y > point.y) && (mVertices[i + 1].y <= point.y)))  // a downward crossing
					{
						// compute  the actual edge-ray intersect x-coordinate
						double vt = (double)((point.y - mVertices[i].y) / (mVertices[i + 1].y - mVertices[i].y));

						if (point.x < (mVertices[i].x + vt * (mVertices[i + 1].x - mVertices[i].x))) // point.x < intersect
							++counter;   // a valid crossing of y=point.y right of point.x
					}
				}
				mVertices.RemoveAt(n); // remove the cycle to revert the vector to the original state.
				return (counter & 1) != 0;
			}	
			return false; // the polygon is not valid.
		}


		// Determines if the polygon is valid.
		// There could be many validity criterias, I just pick simple ones,
		// e.g. number of vertices should be greater than 2, 
		// there should be no vertices with the same coordinates..
		public bool isValid()
		{
			return mIsValid;
		}

		// checks validity of the polygon upon construction.
		private bool CheckValid() 
		{
			if (mVertices.Count > 2) 
			{
				List<DPoint> temp = new List<DPoint>(mVertices);				
				if (temp.Distinct().Count() == mVertices.Count) 
				{
					// TODO: more checks here
					return true; // all checks passed.
				}
			}
			return false; // not valid.
		}

		public int VerticesCount { 
			get { return mVertices.Count; }
			private set {} 
		}

		public IList<DPoint> Vertices
		{
			get { return mVertices; }
		}

		private bool mIsValid;
		private List<DPoint> mVertices;

		
	}
}
