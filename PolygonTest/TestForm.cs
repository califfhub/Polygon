using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonTest
{
	public partial class TestForm : Form
	{
		public TestForm()
		{
			InitializeComponent();
		}

		public void testFixedInput()
		{
			Polygon polygon = new Polygon();
			polygon.AddVertice(new DPoint(1.0, 8.0));
			polygon.AddVertice(new DPoint(4.0, 10.0)); 
			polygon.AddVertice(new DPoint(7.0, 9.0));
			polygon.AddVertice(new DPoint(8.0, 4.0));
			polygon.AddVertice(new DPoint(3.0, 0.0));

			List<DPoint> testPoints = new List<DPoint>() {
				 new DPoint(2.0, 3.0), 
				 new DPoint(2.0, 9.0), 
				 new DPoint(2.75, 7.0),
				 new DPoint(5.0, 4.0), 
				 new DPoint(8.0, 7.0), 
				 new DPoint(8.0, 1.0) 
			};

			StringBuilder sb = new StringBuilder();

			if (polygon.isValid()) {
				sb.Append("Polygon:").Append(Environment.NewLine);
				foreach(var vertex in polygon.Vertices) {
					sb.Append("(").Append(vertex.x).Append(",").Append(vertex.y).Append(")").Append(Environment.NewLine);
				}
				sb.Append("Testing Input Points:").Append(Environment.NewLine);
				foreach(var point in testPoints) {
					sb.Append("Point (").Append(point.x).Append(",").Append(point.y).Append(")");
					sb.Append( (polygon.isPointInside(point)) ? ": Inside" : ": Outside");
					sb.Append(Environment.NewLine);
				}
			}
			else
			{
				sb.Append("Polygon Failed validity test").Append(Environment.NewLine);
			}

			ctrlTestOutput.Text = sb.ToString();
			ctrlTestOutput.Select(0, 0);
		}

		private void OnTestLoad(object sender, EventArgs e)
		{
			testFixedInput();
		}
	}
}
