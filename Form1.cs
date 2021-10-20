#define FFIG34
#define FFIG34
#define FFIG1

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using HexBlock;

namespace howto_hexagonal_grid
{
    public partial class Form1 : Form
    {
        public Form1(Board board)
        {
            InitializeComponent();
            Board = board;
            HexHeight = Board.GetSize() == 11 ? 50 : Board.GetSize() == 13 ? 40 : 30;
        }

        // The height of a hexagon.
        private static float HexHeight;

        // Selected hexagons.
        private List<PointF> Hexagons = new List<PointF>();

#if FIG34
        // The selected Hexagons search the rectangle.
        // They are used to draw the Figures 3 and 4.
        private List<RectangleF> TestRects = new List<RectangleF>();
#endif
        public static HexBlock.Board Board;

        // Redraw the grid.
        private void picGrid_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int hexColores = 0;

            // Draw the selected hexagons.
            foreach (PointF point in Hexagons)
            {
                //Color_Outline(e);
                if (hexColores % 2 == 0)
                {
                    e.Graphics.FillPolygon(Brushes.Red,
                        HexToPoints(HexHeight, point.X, point.Y));
                }

                else if (hexColores % 2 != 0)
                {
                    e.Graphics.FillPolygon(Brushes.Blue,
                        HexToPoints(HexHeight, point.X, point.Y));
                }


                hexColores++;
               

            }

            // Draw the grid.
            DrawHexGrid(e.Graphics, Pens.Black,
                1, (picGrid.ClientSize.Width+1),
                1, (picGrid.ClientSize.Height+1),
                HexHeight);
            Color_Outline(e);


#if FIG34
            // Draw the selected rectangles for Figures 3 and 4.
            using (Pen pen = new Pen(Color.Red, 3))
            {
                pen.DashStyle = DashStyle.Dash;
                foreach (RectangleF rect in TestRects)
                {
                    e.Graphics.DrawRectangle(pen, Rectangle.Round(rect));
                }
            }
#endif
        }

        

        // Draw a hexagonal grid for the indicated area.
        private void DrawHexGrid(Graphics gr, Pen pen,
            float xmin, float xmax, float ymin, float ymax,
            float height)
        {
            // Loop until a hexagon won't fit.
            for (int row = 8; row < 19; row++)
            {

                // Get the points for the row's first hexagon.
                PointF[] points = HexToPoints(height, row, 2);

                // If it doesn't fit, It's Good
                if (points[1].Y > ymax) break;

                // Draw the row.
                for (int col = 8; col < 19; col++)

                {
                    // Get the points for the row's next hexagon.
                    points = HexToPoints(height, row, col);

                    // If it doesn't fit horizontally,
                    // the row is done
                    if (points[5].X > xmax) break;

                    // If it fits vertically, draw it.
                    if (points[0].Y <= ymax)
                    {
                        gr.DrawPolygon(pen, points);



#if FIG1
                        // Label the hexagon (for Figure 1).
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            float x = (points[1].X + points[5].X) / 2;
                            float y = (points[0].Y + points[3].Y) / 2;
                            string label = "(" + row.ToString() + ", " +
                                col.ToString() + ")";
                            gr.DrawString(label, this.Font,
                                Brushes.Black, x, y, sf);
                        }
#endif
                    }
                }
            }
        }

        private void picGrid_Resize(object sender, EventArgs e)
        {
            picGrid.Refresh();
        }

        // Display the row and column under the mouse.
        private void picGrid_MouseMove(object sender, MouseEventArgs e)
        {
            int row, col;
            PointToHex(e.X, e.Y, HexHeight, out row, out col);
            if (row < 19 && col < 19 && row >= 8 && col >= 8)
            {
                this.Text = $"( {row-8} , {col-8} )";
            }
            else this.Text = null;

        }

        // Add the clicked hexagon to the Hexagons list.
        private void picGrid_MouseClick(object sender, MouseEventArgs e)
        {

            int row, col;
            PointToHex(e.X, e.Y, HexHeight, out row, out col);
            if (Board.Play((row-8, col-8)))
            {
                Hexagons.Add(new PointF(row, col));

            }

#if FIG34
            // Used to draw Figures 3 and 4.
            PointF[] points = HexToPoints(HexHeight, row, col);
            if (row < 12 && col < 12 && row >= 1 && col >= 1)
            {
                TestRects.Add(new RectangleF(
                    points[1].X, points[0].Y,
                    points[5].X - points[1].X,
                    0.75f * (points[3].Y - points[0].Y)));
            }
#endif

            picGrid.Refresh();
        }

        // Return the width of a hexagon.
        private float HexWidth(float height)
        {
            return (float)(4 * (height / 2 / Math.Sqrt(3)));
        }

        // Return the row and column of the hexagon at this point.
        private void PointToHex(float x, float y, float height,
            out int row, out int col)
        {
            // Find the test rectangle containing the point.
            float width = HexWidth(height);
            row = (int)Math.Floor(y / (width * 0.75f));

            col = (int)((x + row * height / 2) / height) - row;
            
            // if (row < 11 )
            // {

            // Find the test area.
            float testy = row * width * 0.75f;
            float testx = col * height + row * height / 2;

            // See if the point is at the left or
            // at the right of the test hexagon on the upper edge.
            bool is_left = false, is_right = false;
            float dy = y - testy;
            if (dy < width / 4)
            {
                float dx = x - (testx + row * height / 2);
                if (dy < 0.001)
                {
                    // The point is on the upper edge of the test rectangle.
                    if (dx < 0) is_left = true;
                    if (dx > 0) is_right = true;
                }
                else if (dx < 0)
                {
                    // See if the point is left of the test hexagon.
                    if (-dx / dy > Math.Sqrt(3)) is_left = true;
                }
                else
                {
                    // See if the point is right of the test hexagon.
                    if (dx / dy > Math.Sqrt(3)) is_right = true;
                }
            }

            //Adjust the row and column if necessary.
            if (is_left)
            {
                row--;
            }
            else if (is_right)
            {
                row--;
                col++;
            }
            //}
        }

        // Return the points that define the indicated hexagon.
        private PointF[] HexToPoints(float height, float row, float col)
        {
            // Start with the leftmost corner of the upper left hexagon.
            float width = HexWidth(height);
            float y = height / 2 - width / 2;
            float x = height / 2;

            // Move down the required number of rows.
            y += (row * width * 0.75f);

            // Move over for the column number.
            x += col * (height) + (row * width / 2 * 0.87f);


            // Generate the points.
            return new PointF[]
            {
                new PointF(x, y),
                new PointF(x - height / 2, y + width * 0.25f),
                new PointF(x - height / 2, y + width * 0.75f),
                new PointF(x, y + width),
                new PointF(x + height / 2, y + width * 0.75f),
                new PointF(x + height / 2, y + width * 0.25f),
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private object Color_Outline(PaintEventArgs e)
        {
            int colMax = 19;
            int rowMax = 19;
            for (int col = 8; col < colMax; col++)
            {
                e.Graphics.FillPolygon(Brushes.Red,
                    HexToPoints(HexHeight, 19, col));
            }
            for (int col = 8; col < colMax; col++)
            {
                e.Graphics.FillPolygon(Brushes.Red,
                    HexToPoints(HexHeight, 7, col));
            }
            for (int row = 8; row < rowMax; row++)
            {
                e.Graphics.FillPolygon(Brushes.Blue,
                    HexToPoints(HexHeight, row, 19));
            }
            for (int row = 8; row < rowMax; row++)
            {
                e.Graphics.FillPolygon(Brushes.Blue,
                    HexToPoints(HexHeight, row, 7));
            }


            return e.Graphics;
        }
    }
}