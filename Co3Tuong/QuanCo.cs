using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Co3Tuong
{
    class QuanCo : Button
    {

        private Rectangle borderRectangle;
        private bool active ;
        private StringFormat stringFormat = new StringFormat();

        public QuanCo()
        {
            this.Paint += QuanCo_Paint;
        }
        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2;
            GraphicsPath graphicsPath = new GraphicsPath();

            graphicsPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            graphicsPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);

            graphicsPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            graphicsPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);

            graphicsPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            graphicsPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);

            graphicsPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            graphicsPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y - 2);

            graphicsPath.CloseFigure();
            return graphicsPath;
        }
        private void QuanCo_Paint(object sender, PaintEventArgs e)
        {
            borderRectangle = new Rectangle(0, 0, Width, Height);
            RectangleF rect = new RectangleF(0, 0, this.Width, this.Height);
            GraphicsPath graphicsPath = GetRoundPath(rect, 50);
            this.Region = new Region(graphicsPath);
            using (Pen pen = new Pen(Color.CadetBlue, 1.75f))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(pen, graphicsPath);
            }


            // Create a GraphicsPath object.
            GraphicsPath myPath = new GraphicsPath();

            // Set up all the string parameters.
            FontFamily family = new FontFamily("Segoe UI");
            int fontStyle = (int)FontStyle.Regular;
            int emSize = 16;
            StringFormat format = new StringFormat();

            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;


            // Add the string to the path.
            myPath.AddString(this.Text,
                family,
                fontStyle,
                emSize,
                new Point(25, 25),
                format);

            //Draw the path to the screen.
            //e.Graphics.FillPath(Brushes.Red, myPath);
        }

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //    active = true;
        //    base.BackColor = Color.Blue;
        //}
        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    base.OnMouseUp(e);
        //    base.BackColor = active ? Color.Red : Color.Blue;
        //    Console.WriteLine(active ? 1 : 2);
        //    active = active ? false : true;
        //}

        //protected override void OnClick(EventArgs e)
        //{
        //    base.OnClick(e);
        //    base.BackColor = Color.Blue;
        //}
    }
}
