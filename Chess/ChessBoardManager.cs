using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsiaChess {
    public class ChessBoardManager {
        public Form mainForm { get; set; }
        public Panel chessPanel { get; set; }

        public AsiaChessButton selected_chess;
        public AsiaChessButton[,] chessMatrix;
        private int GAME_MODE;

        public ChessBoardManager(Form _mainForm) {
            mainForm = _mainForm;
        }

        public void NewGame(int GameMode) {
            GAME_MODE = GameMode;
            chessPanel.Controls.Clear();
            // Draw
            DrawChess();
            //chessPanel.Enabled = true;
        }

        #region Draw function
        public void DrawChessPanel() {

            chessPanel = new Panel();
            //chessPanel.Enabled = false;
            chessPanel.BorderStyle = BorderStyle.Fixed3D;
            int boardwidth = 2 * Cons.MARGIN + Cons.CELL_SIZE * Cons.MAX_COL;
            int boardHeight = 2 * Cons.MARGIN + Cons.CELL_SIZE * (Cons.MAX_ROW + Cons.SMALL_DIAMON_HEIGH);
            chessPanel.Width = boardwidth;
            chessPanel.Height = boardHeight;
            chessPanel.Location = new Point(20, 20);
            chessPanel.Paint += ChessPanel_Paint;

            mainForm.Controls.Add(chessPanel);
        }

        private void ChessPanel_Paint(object sender, PaintEventArgs e) {
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

        public void DrawChess() {
            chessMatrix = new AsiaChessButton[Cons.BOARD_HEIGH, Cons.BOARD_WIDTH];

            Point location;

            for (int i = 0; i < Cons.BOARD_HEIGH; i++) {
                for (int j = 0; j < Cons.BOARD_WIDTH; j++) {
                    // Swap i, j to normal because it's nature
                    location = new Point(Cons.MARGIN + j * Cons.CELL_SIZE - Cons.CHESS_SIZE / 2, Cons.MARGIN + i * Cons.CELL_SIZE - Cons.CHESS_SIZE / 2);
                    AsiaChessButton chess = new AsiaChessButton() {
                        Location = location,
                        Size = new Size(Cons.CHESS_SIZE, Cons.CHESS_SIZE),
                        FlatStyle = FlatStyle.Popup

                    };


                    if (Cons.map[i, j] == Cons.CHESS_VALUE) {
                        chess.BackColor = Cons.CHESS_COLOR;
                        chess.MyOriginColor = Cons.CHESS_COLOR;
                        chess.ChessValue = Cons.CHESS_VALUE;

                    }
                    else if (Cons.map[i, j] == Cons.BOSS_VALUE) {
                        chess.BackColor = Cons.BOSS_COLOR;
                        chess.MyOriginColor = Cons.BOSS_COLOR;
                        chess.ChessValue = Cons.BOSS_VALUE;
                    }
                    else if (Cons.map[i, j] == Cons.EMPTY_VALUE) {
                        //chess.FlatAppearance.BorderSize = 0;
                        chess.BackColor = Cons.EMPTY_COLOR;
                        chess.MyOriginColor = Cons.EMPTY_COLOR;
                        chess.ChessValue = Cons.EMPTY_VALUE;
                    }
                    else {
                        continue;
                    }

                    // Handle click
                    chess.Click += Chess_Click;
                    this.chessPanel.Controls.Add(chess);

                    chess.RowIndex = i;
                    chess.ColIndex = j;
                    chessMatrix[i, j] = chess;
                }
            }
        }

        #endregion

        #region Util function: getEmptyChess
        public AsiaChessButton getEmptyChess(int rowIndex, int colIndex) {
            Point location = new Point(Cons.MARGIN + colIndex * Cons.CELL_SIZE - Cons.CHESS_SIZE / 2, Cons.MARGIN + rowIndex * Cons.CELL_SIZE - Cons.CHESS_SIZE / 2);
            AsiaChessButton chess = new AsiaChessButton() {
                Location = location,
                Size = new Size(Cons.CHESS_SIZE, Cons.CHESS_SIZE),
                FlatStyle = FlatStyle.Popup

            };
            chess.BackColor = Cons.EMPTY_COLOR;
            chess.MyOriginColor = Cons.EMPTY_COLOR;
            chess.ChessValue = Cons.EMPTY_VALUE;
            return chess;
        }
        #endregion

        private void Chess_Click(object sender, EventArgs e) {
            AsiaChessButton current_chess = sender as AsiaChessButton;

            // First click on empty chess
            if (selected_chess == null && current_chess.isEmptyChess()) {
                return;
            }

            // First click on boss or chess
            if (selected_chess == null && !current_chess.isEmptyChess()) {
                selected_chess = current_chess;
                selected_chess.BackColor = Cons.SELECTED_COLOR;
                return;
            }

            // Click two empty chess
            if (selected_chess.isEmptyChess() && current_chess.isEmptyChess()) {
                return;
            }

            // Re-click chess (unselected)
            if (selected_chess == current_chess) {
                selected_chess.BackColor = selected_chess.MyOriginColor;
                selected_chess = null;
                return;
            }

            // Change selected
            if (selected_chess.ChessValue == current_chess.ChessValue) {
                selected_chess.BackColor = selected_chess.MyOriginColor;
                selected_chess = current_chess;
                selected_chess.BackColor = Cons.SELECTED_COLOR;
            }

            // Move chess
            if (!selected_chess.isEmptyChess() && current_chess.isEmptyChess()) {
                //AsiaChessButton tmp_chess = selected_chess;
                //current_chess = selected_chess;
                //int rowIndex = selected_chess.RowIndex;
                //int colIndex = selected_chess.ColIndex;

                //AsiaChessButton empty_chess = getEmptyChess(rowIndex, colIndex);
                //selected_chess.Dispose();
                //chessPanel.Controls.Add(empty_chess);

                if (selected_chess.isBoss()) {
                    current_chess.ChessValue = Cons.BOSS_VALUE;
                    current_chess.BackColor = Cons.BOSS_COLOR;
                   // current_chess.changeToBoss();
                }
                else {
                    current_chess.ChessValue = Cons.CHESS_VALUE;
                    current_chess.BackColor = Cons.CHESS_COLOR;
                    //current_chess.changeToChess();
                }
                selected_chess.ChessValue = Cons.EMPTY_VALUE;
                selected_chess.BackColor = Cons.EMPTY_COLOR;
                //selected_chess.changeToEmpty();
                
            }
            #region Old code
            //if (selected_chess == null) {
            //    selected_chess = current_chess;
            //    selected_chess.BackColor = Color.Purple;
            //    return;
            //}

            //if (selected_chess == current_chess) {
            //    selected_chess = null;
            //    switch (current_chess.ChessValue) {
            //        case Cons.CHESS_VALUE:
            //            current_chess.BackColor = Cons.CHESS_COLOR;
            //            break;
            //        case Cons.BOSS_VALUE:
            //            current_chess.BackColor = Cons.BOSS_COLOR;
            //            break;

            //    }
            //    return;
            //}

            //if (selected_chess.ChessValue == current_chess.ChessValue) {
            //    switch (selected_chess.ChessValue) {
            //        case Cons.CHESS_VALUE:
            //            selected_chess.BackColor = Cons.CHESS_COLOR;
            //            break;
            //        case Cons.BOSS_VALUE:
            //            selected_chess.BackColor = Cons.BOSS_COLOR;
            //            break;

            //    }
            //    current_chess.BackColor = Cons.SELECTED_COLOR;
            //    selected_chess = current_chess;
            //}

            //if (selected_chess.ChessValue != Cons.EMPTY_VALUE && current_chess.ChessValue == Cons.EMPTY_VALUE) {
            //    switch (selected_chess.ChessValue) {
            //        case Cons.CHESS_VALUE:
            //            current_chess.BackColor = Cons.CHESS_COLOR;
            //            break;
            //        case Cons.BOSS_VALUE:
            //            current_chess.BackColor = Cons.BOSS_COLOR;
            //            break;

            //    }
            //    selected_chess.BackColor = Color.Transparent;

            //}
            #endregion

        }
    }
}
