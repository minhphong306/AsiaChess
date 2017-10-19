using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsiaChess {
    public partial class Form1 : Form {
        static int current = 0;
        private Panel chessPanel;
        public Form1() {
            InitializeComponent();
            // Set width, heigh screen suitable
            int bonus_size = 100;
            int minWidth = Cons.MARGIN + Cons.CELL_SIZE * Cons.MAX_COL + bonus_size + 300;
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

        private void DrawChessPanel() {
            chessPanel = new Panel();
            int boardwidth = 2 * Cons.MARGIN + Cons.CELL_SIZE * Cons.MAX_COL;
            int boardHeight = 2 * Cons.MARGIN + Cons.CELL_SIZE * (Cons.MAX_ROW + Cons.SMALL_DIAMON_HEIGH);
            chessPanel.Width = boardwidth;
            chessPanel.Height = boardHeight;
            chessPanel.Location = new Point(20, 20);
            chessPanel.Paint += ChessPanel_Paint;

            Controls.Add(chessPanel);
        }

        private void ChessPanel_Paint(object sender, PaintEventArgs e) {
            Console.WriteLine(current++);
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
                    AsiaChessButton chess = new AsiaChessButton() {
                        Location = location,
                        Size = new Size(Cons.CHESS_SIZE, Cons.CHESS_SIZE),
                        FlatStyle = FlatStyle.Popup,
                        BackColor = Color.Transparent
                       
                    };

                    if (Cons.map[i, j] == Cons.CHESS_VALUE) {
                        chess.Text = "Tot";
                    }
                    else if (Cons.map[i, j] == Cons.BOSS_VALUE) {
                        chess.Text = "Tuong";
                    }
                    else if (Cons.map[i, j] == Cons.EMPTY_VALUE) {
                        
                    }
                    else {
                        continue;
                    }
                    this.chessPanel.Controls.Add(chess);

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            DrawChessPanel();
            DrawChess();
        }
    }
}
