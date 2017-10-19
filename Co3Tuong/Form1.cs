using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Co3Tuong {
    public partial class Form1 : Form {

        private CheckMove checker = new CheckMove();
        private QuanCo currentChess = new QuanCo();
        private List<QuanCo> a = new List<QuanCo>();
        private Point buff = new Point();
        public Form1() {
            InitializeComponent();
            DrawChess();

            // Set width, heigh screen suitable
            int bonus_size = 100;
            int minWidth = Cons.MARGIN + Cons.CELL_SIZE * Cons.MAX_COL + bonus_size;
            int minHeigh = Cons.MARGIN + Cons.CELL_SIZE * (Cons.MAX_ROW + Cons.SMALL_DIAMON_HEIGH) + bonus_size;

            int formWidth = this.Width;
            int formHeigh = this.Height;

            if (formWidth < minWidth) {
                this.Width = minWidth;
            }
            if (formHeigh < minHeigh) {
                this.Height = minHeigh;
            }
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        #region Draw Function
        private void drawBoard(PaintEventArgs e) {
            Pen pen = new Pen(Color.Black, 1);
            Point firstPoint, lastPoint;
            Point midTop, midBottom, midRight, midLeft;

            // Draw horizontal line
            for (int i = 0; i <= Cons.MAX_ROW; i++) {
                firstPoint = new Point(Cons.MARGIN, Cons.MARGIN + i * Cons.CELL_SIZE);
                lastPoint = new Point(Cons.MARGIN + Cons.MAX_COL * Cons.CELL_SIZE, Cons.MARGIN + i * Cons.CELL_SIZE);

                e.Graphics.DrawLine(pen, firstPoint, lastPoint);
            }

            // Draw vertical line
            for (int i = 0; i <= Cons.MAX_COL; i++) {
                firstPoint = new Point(Cons.MARGIN + i * Cons.CELL_SIZE, Cons.MARGIN);
                lastPoint = new Point(Cons.MARGIN + i * Cons.CELL_SIZE, Cons.MARGIN + Cons.MAX_ROW * Cons.CELL_SIZE);

                e.Graphics.DrawLine(pen, firstPoint, lastPoint);
            }

            // Draw main diagonal
            firstPoint = new Point(Cons.MARGIN, Cons.MARGIN);
            lastPoint = new Point(Cons.MARGIN + Cons.MAX_COL * Cons.CELL_SIZE, Cons.MARGIN + Cons.MAX_ROW * Cons.CELL_SIZE);
            e.Graphics.DrawLine(pen, firstPoint, lastPoint);

            // Draw assistance diagonal
            firstPoint = new Point(Cons.MARGIN + Cons.MAX_COL * Cons.CELL_SIZE, Cons.MARGIN);
            lastPoint = new Point(Cons.MARGIN, Cons.MARGIN + Cons.MAX_ROW * Cons.CELL_SIZE);
            e.Graphics.DrawLine(pen, firstPoint, lastPoint);

            // Draw big diamon
            midTop = new Point(Cons.MARGIN + (Cons.MAX_COL * Cons.CELL_SIZE) / 2, Cons.MARGIN);
            midBottom = new Point(Cons.MARGIN + (Cons.MAX_COL * Cons.CELL_SIZE) / 2, Cons.MARGIN + Cons.CELL_SIZE * Cons.MAX_ROW);

            midLeft = new Point(Cons.MARGIN, Cons.MARGIN + (Cons.MAX_ROW * Cons.CELL_SIZE) / 2);
            midRight = new Point(Cons.MARGIN + Cons.CELL_SIZE * Cons.MAX_COL, Cons.MARGIN + (Cons.CELL_SIZE * Cons.MAX_ROW) / 2);

            e.Graphics.DrawLine(pen, midTop, midLeft);
            e.Graphics.DrawLine(pen, midTop, midRight);
            e.Graphics.DrawLine(pen, midBottom, midLeft);
            e.Graphics.DrawLine(pen, midBottom, midRight);

            // Draw small diamon
            midTop = new Point(Cons.MARGIN + (Cons.MAX_COL * Cons.CELL_SIZE) / 2, Cons.MARGIN + Cons.CELL_SIZE * Cons.MAX_ROW);
            midBottom = new Point(Cons.MARGIN + (Cons.MAX_COL * Cons.CELL_SIZE) / 2, Cons.MARGIN + Cons.CELL_SIZE * (Cons.MAX_ROW + Cons.SMALL_DIAMON_WIDTH));
            midLeft = new Point(Cons.MARGIN + Cons.SMALL_DIAMON_WIDTH / 2 * Cons.CELL_SIZE, Cons.MARGIN + Cons.CELL_SIZE * (Cons.MAX_ROW + Cons.SMALL_DIAMON_HEIGH / 2));
            midRight = new Point(Cons.MARGIN + (Cons.MAX_COL - Cons.SMALL_DIAMON_WIDTH / 2) * Cons.CELL_SIZE, Cons.MARGIN + Cons.CELL_SIZE * (Cons.MAX_ROW + Cons.SMALL_DIAMON_HEIGH / 2));
            e.Graphics.DrawLine(pen, midTop, midLeft);
            e.Graphics.DrawLine(pen, midTop, midRight);
            e.Graphics.DrawLine(pen, midBottom, midLeft);
            e.Graphics.DrawLine(pen, midBottom, midRight);

            // Draw inner diamon
            e.Graphics.DrawLine(pen, midTop, midBottom);
            e.Graphics.DrawLine(pen, midLeft, midRight);

        }

        private void DrawChess() {
            Point location;

            for (int i = 0; i <= Cons.MAX_COL + Cons.SMALL_DIAMON_HEIGH; i++) {
                for (int j = 0; j <= Cons.MAX_ROW; j++) {
                    // Swap i, j to normal because it's nature
                    location = new Point(Cons.MARGIN + j * Cons.CELL_SIZE - Cons.CHESS_SIZE / 2, Cons.MARGIN + i * Cons.CELL_SIZE - Cons.CHESS_SIZE / 2);
                    //QuanCo chess = new QuanCo() {
                    //    Location = location,
                    //    Size = new Size(Cons.CHESS_SIZE, Cons.CHESS_SIZE),

                    //};
                    if (Cons.map[i, j] == Cons.CHESS_VALUE) {
                        QuanCo chess = new QuanCo() {
                            Location = location,
                            Text = "Tốt",
                            Size = new Size(Cons.CHESS_SIZE, Cons.CHESS_SIZE),
                            ForeColor = Color.Blue
                        };
                        this.Controls.Add(chess);
                        chess.Click += Quan_Click;
                    }
                    else if (Cons.map[i, j] == 2) {
                        QuanCo tuong = new QuanCo() {
                            Location = location,
                            Text = "Tướng",
                            Size = new Size(Cons.CHESS_SIZE, Cons.CHESS_SIZE),
                            BackColor = Color.Red
                        };
                        this.Controls.Add(tuong);
                        tuong.Click += Tuong_Click;

                    }
                }
            }
        }

        #endregion

        #region Paint event
        private void Form1_Paint(object sender, PaintEventArgs e) {
            drawBoard(e);
        }

        #endregion

        private void Tuong_Click(object sender, EventArgs e) {
            QuanCo tuong = sender as QuanCo;
            tuong.FlatAppearance.BorderColor = Color.Red;
            tuong.FlatAppearance.BorderSize = 2;
            currentChess = tuong;

            int i, j;
            i = (tuong.Location.Y - 15) / 100;
            j = (tuong.Location.X - 15) / 100;

            Cons.map[i, j] = 0;

            List<Point> list = checker.getListMove(i, j);
            Point nextMove = list[0];


            Point p = new Point(15 + nextMove.Y * 100, 15 + nextMove.X * 100);
            foreach (var item in this.Controls) {
                if (item.GetType() == typeof(QuanCo)) {
                    QuanCo c = (QuanCo)item;
                    if (c.Location.X == p.X && c.Location.Y == p.Y && c.Text == "Tốt")
                        this.Controls.Remove(c);
                }
            }

            tuong.Location = new Point(15 + nextMove.Y * 100, 15 + nextMove.X * 100);

            Cons.map[nextMove.X, nextMove.Y] = 2;

            //tuong.Location = new Point(15 + 2 * 100, 15 + 3 * 100);

            //this.Controls.Remove()
        }

        private void Quan_Click(object sender, EventArgs e) {

            QuanCo tot = sender as QuanCo;
            if (currentChess.Text.Equals("Tướng")) {
                Cons.map[(currentChess.Location.Y - 15) / 100, (currentChess.Location.X - 15) / 100] = 2;
                Cons.map[(tot.Location.Y - 15) / 100, (tot.Location.X - 15) / 100] = 0;
                currentChess.Location = tot.Location;
                this.Controls.Remove(tot);
            }
            currentChess = tot;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            int x = (e.X - 15) / Cons.CELL_SIZE;
            int y = (e.Y - 15) / Cons.CELL_SIZE;
            Console.WriteLine(x + "  " + y + "  " + Cons.map[y, x]);
            if (Cons.map[y, x] == 0 && Check(new Point(y, x), new Point((currentChess.Location.Y - 15) / Cons.CELL_SIZE, (currentChess.Location.X - 15) / Cons.CELL_SIZE))) {
                Cons.map[y, x] = currentChess.Text.Equals("Tướng") ? 2 : 1;
                Cons.map[(currentChess.Location.Y - 15) / Cons.CELL_SIZE, (currentChess.Location.X - 15) / Cons.CELL_SIZE] = 0;
                buff = new Point(15 + x * Cons.CELL_SIZE, 15 + y * Cons.CELL_SIZE);
                currentChess.Location = buff;
            }


        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private bool Check(Point first, Point last) {
            if ((first.X + first.Y) % 2 != 0 && (last.X + last.Y) % 2 != 0) {
                return false;
            }
            return true;
        }

        private void t() {
            for (int i = 0; i < 7; i++) {

            }
        }
    }
}
