namespace PolygonTest
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mCanvas = new System.Windows.Forms.PictureBox();
			this.newPolygon = new System.Windows.Forms.Button();
			this.ctrlAddPolygonPoints = new System.Windows.Forms.CheckBox();
			this.addFreePoints = new System.Windows.Forms.CheckBox();
			this.ctrlUndo = new System.Windows.Forms.Button();
			this.btnUnitTest = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.mCanvas)).BeginInit();
			this.SuspendLayout();
			// 
			// mCanvas
			// 
			this.mCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mCanvas.BackColor = System.Drawing.Color.White;
			this.mCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mCanvas.Location = new System.Drawing.Point(1, 67);
			this.mCanvas.Name = "mCanvas";
			this.mCanvas.Size = new System.Drawing.Size(752, 462);
			this.mCanvas.TabIndex = 0;
			this.mCanvas.TabStop = false;
			this.mCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseClickDrawing);
			// 
			// newPolygon
			// 
			this.newPolygon.Location = new System.Drawing.Point(1, 13);
			this.newPolygon.Name = "newPolygon";
			this.newPolygon.Size = new System.Drawing.Size(111, 22);
			this.newPolygon.TabIndex = 1;
			this.newPolygon.Text = "New";
			this.newPolygon.UseVisualStyleBackColor = true;
			this.newPolygon.Click += new System.EventHandler(this.NewPolygon_Click);
			// 
			// ctrlAddPolygonPoints
			// 
			this.ctrlAddPolygonPoints.Appearance = System.Windows.Forms.Appearance.Button;
			this.ctrlAddPolygonPoints.AutoSize = true;
			this.ctrlAddPolygonPoints.Location = new System.Drawing.Point(118, 12);
			this.ctrlAddPolygonPoints.Name = "ctrlAddPolygonPoints";
			this.ctrlAddPolygonPoints.Size = new System.Drawing.Size(109, 23);
			this.ctrlAddPolygonPoints.TabIndex = 3;
			this.ctrlAddPolygonPoints.Text = "Add Polygon Points";
			this.ctrlAddPolygonPoints.UseVisualStyleBackColor = true;
			this.ctrlAddPolygonPoints.CheckStateChanged += new System.EventHandler(this.OnAddPolygonPointsChanged);
			// 
			// addFreePoints
			// 
			this.addFreePoints.Appearance = System.Windows.Forms.Appearance.Button;
			this.addFreePoints.AutoSize = true;
			this.addFreePoints.Location = new System.Drawing.Point(233, 12);
			this.addFreePoints.Name = "addFreePoints";
			this.addFreePoints.Size = new System.Drawing.Size(92, 23);
			this.addFreePoints.TabIndex = 4;
			this.addFreePoints.Text = "Add Free Points";
			this.addFreePoints.UseVisualStyleBackColor = true;
			this.addFreePoints.CheckStateChanged += new System.EventHandler(this.OnAddFreePointsChanged);
			// 
			// ctrlUndo
			// 
			this.ctrlUndo.Location = new System.Drawing.Point(356, 12);
			this.ctrlUndo.Name = "ctrlUndo";
			this.ctrlUndo.Size = new System.Drawing.Size(107, 23);
			this.ctrlUndo.TabIndex = 5;
			this.ctrlUndo.Text = "Undo Last Action";
			this.ctrlUndo.UseVisualStyleBackColor = true;
			this.ctrlUndo.Click += new System.EventHandler(this.ctrlUndo_Click);
			// 
			// btnUnitTest
			// 
			this.btnUnitTest.Location = new System.Drawing.Point(667, 13);
			this.btnUnitTest.Name = "btnUnitTest";
			this.btnUnitTest.Size = new System.Drawing.Size(75, 23);
			this.btnUnitTest.TabIndex = 6;
			this.btnUnitTest.Text = "UnitTest";
			this.btnUnitTest.UseVisualStyleBackColor = true;
			this.btnUnitTest.Click += new System.EventHandler(this.onUnitTest);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(754, 529);
			this.Controls.Add(this.btnUnitTest);
			this.Controls.Add(this.ctrlUndo);
			this.Controls.Add(this.addFreePoints);
			this.Controls.Add(this.ctrlAddPolygonPoints);
			this.Controls.Add(this.newPolygon);
			this.Controls.Add(this.mCanvas);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.OnFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.mCanvas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox mCanvas;
		private System.Windows.Forms.Button newPolygon;
		private System.Windows.Forms.CheckBox ctrlAddPolygonPoints;
		private System.Windows.Forms.CheckBox addFreePoints;
		private System.Windows.Forms.Button ctrlUndo;
		private System.Windows.Forms.Button btnUnitTest;
	}
}

