using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonTest
{
	public partial class Form1 : Form
	{
		private Polygon mPolygon = new Polygon();
		private List<DrawablePoint> mFreePoints = new List<DrawablePoint>();

		private enum Mode { InsertPolygonNode, InsertFreePoint };
		private Mode mCurrentMode = Mode.InsertPolygonNode;

		private enum ActionType { VerticeAdded, PointAdded };
		private Stack<ActionType> mUndoStack = new Stack<ActionType>();

		private Pen sBlackPen = new Pen(Color.Black, 2);

		// some constants that define colors
		private readonly Color sColorPointInsidePolygon = Color.Green;
		private readonly Color sColorPointOutsidePolygon = Color.Red;
		
		public Form1()
		{
			InitializeComponent();
		}

		// Draws all entities
		private void DrawObjects()
		{
			
			Bitmap canvas = new Bitmap(mCanvas.Width, mCanvas.Height);
			Graphics g = Graphics.FromImage(canvas);
			if (mPolygon.VerticesCount > 0)
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				if (mPolygon.VerticesCount == 1)
				{
					DrawPoint(g, new DrawablePoint(mPolygon.Vertices[0]));
				}
				else
				{
					var path = new GraphicsPath();
					if (path != null)
					{
						for (var i = 0; i < mPolygon.VerticesCount - 1; ++i)
						{
							Point pt1 = new Point((int)(mPolygon.Vertices[i].x + 0.5), (int)(mPolygon.Vertices[i].y + 0.5));
							Point pt2 = new Point((int)(mPolygon.Vertices[i + 1].x +0.5), (int)(mPolygon.Vertices[i + 1].y + 0.5));
							path.AddLine(pt1, pt2);
						}
						if (mPolygon.VerticesCount > 2)
						{
							Point ptLast = new Point((int)(mPolygon.Vertices[mPolygon.VerticesCount - 1].x + 0.5), (int)(mPolygon.Vertices[mPolygon.VerticesCount - 1].y + 0.5));
							Point ptFirst = new Point((int)(mPolygon.Vertices[0].x + .5), (int)(mPolygon.Vertices[0].y + .5));
							path.AddLine(ptFirst, ptLast);
						}

						g.DrawPath(sBlackPen, path);
						
						// Draw vertices on top of the path to make a better visual appearance
						DrawVertices(g);
					}
				}

				// draw all free points on top of the polygon with correct colors
				DrawPoints(g);
			}

			mCanvas.Image = canvas;
			mCanvas.Invalidate();

		}

		// Draws all points from FreePoints collection
		private void DrawPoints(Graphics g)
		{
			foreach (DrawablePoint dp in mFreePoints)
				DrawPoint(g, dp);
		}

		// Draws a single point
		private void DrawPoint(Graphics g, DrawablePoint pt)
		{
			Pen pen = new Pen(pt.color, 2);
			Point pt1 = new Point(pt.x - 2, pt.y - 2);
			Rectangle r = new Rectangle(pt1, new Size(4, 4));
			g.DrawRectangle(pen, r);
		}

		// Draws all vertices in the polygon
		private void DrawVertices(Graphics g)
		{
			foreach (DPoint dp in mPolygon.Vertices)
			{
				DrawablePoint drawable = new DrawablePoint(dp);
				DrawPoint(g, drawable);
			}
		}

		// Updates the free point state if polygon's vertices change
		private void UpdateFreePointState() 
		{
			for(int i=0; i< mFreePoints.Count; ++i)
			{
				DrawablePoint drawable = mFreePoints[i];
				DPoint dp = new DPoint(drawable.x, drawable.y);
				drawable.color = (mPolygon.isPointInside(dp)) ?
					sColorPointInsidePolygon:
					sColorPointOutsidePolygon;
			}
		}

		// ------------------------------------------------------------
		// Event handlers
		// ------------------------------------------------------------

		private void OnFormLoad(object sender, EventArgs e)
		{
			ctrlAddPolygonPoints.Checked = true;
			this.ActiveControl = ctrlAddPolygonPoints;
		}

	
		private void NewPolygon_Click(object sender, EventArgs e)
		{
			mPolygon = new Polygon();
			mFreePoints = new List<DrawablePoint>();
			ctrlAddPolygonPoints.Checked = true;
			mCurrentMode = Mode.InsertPolygonNode;
			DrawObjects();
		}


		private void OnMouseClickDrawing(object sender, MouseEventArgs e)
		{
			DPoint pt = new DPoint((double)e.X, (double)e.Y);
			if (mCurrentMode == Mode.InsertPolygonNode)
			{
				mPolygon.AddVertice(pt);
				UpdateFreePointState();
				mUndoStack.Push(ActionType.VerticeAdded);
			}
			else
			{
				Color color = (mPolygon.isPointInside(pt)) ? sColorPointInsidePolygon : sColorPointOutsidePolygon;
				DrawablePoint dp = new DrawablePoint(pt, color);
				mFreePoints.Add(dp);
				mUndoStack.Push(ActionType.PointAdded);
			}
			DrawObjects();
		}


		private void OnAddPolygonPointsChanged(object sender, EventArgs e)
		{
			CheckBox cbox = sender as CheckBox;
			if (cbox.Checked == true) {
				addFreePoints.Checked = false;
				mCurrentMode = Mode.InsertPolygonNode;
			}
			else
			{
				addFreePoints.Checked = true;
				mCurrentMode = Mode.InsertFreePoint;
			}
		}


		private void OnAddFreePointsChanged(object sender, EventArgs e)
		{
			CheckBox cbox = sender as CheckBox;
			if (cbox.Checked == true)
			{
				ctrlAddPolygonPoints.Checked = false;
				mCurrentMode = Mode.InsertFreePoint;
			}
			else
			{
				ctrlAddPolygonPoints.Checked = true;
				mCurrentMode = Mode.InsertPolygonNode;
			}
		}
		
		private void ctrlUndo_Click(object sender, EventArgs e)
		{
			if (mUndoStack.Count > 0)
			{
				ActionType action = mUndoStack.Pop();
				if (action == ActionType.PointAdded)
				{
					if (mFreePoints.Count > 0)
						mFreePoints.RemoveAt(mFreePoints.Count - 1);
				}
				else
				{
					mPolygon.RemoveLastVertex();
					UpdateFreePointState(); // polygon configuration has changed, need to update the state of the free points
				}
				DrawObjects();
			}
		}

		private void onUnitTest(object sender, EventArgs e)
		{
			TestForm testDialog = new TestForm();
			testDialog.ShowDialog(this);
		}


	} // class
}
