﻿using System;
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
        public Label lbGameMode { get; set; }
        public Label lbTurn { get; set; }
        public Label lbChessNumber { get; set; }


        public AsiaChessButton selected_chess;
        public AsiaChessButton[,] chessMatrix;
        public List<AsiaChessButton> hintChesses;
        public List<AsiaChessButton> hintEatChesses;
        public List<AsiaChessButton> justMoveChesses;

        private int GAME_MODE;
        private int GAME_TURN;
        private int CHESS_NUMBER;
        private int TOTAL_CHESS_NUMBER = 19;

        public ChessBoardManager(Form _mainForm) {
            mainForm = _mainForm;

        }

        public void NewGame(int GameMode) {
            GAME_MODE = GameMode;
            chessPanel.Controls.Clear();
            // Draw
            DrawChess();
            chessPanel.Enabled = true;
            GAME_TURN = Cons.BOSS_TURN;
            CHESS_NUMBER = 19;

            switch (GameMode) {
                case Cons.GM_AI:
                    lbGameMode.Text = "Người và máy";
                    break;
                case Cons.GM_TWO_PLAYER:
                    lbGameMode.Text = "Hai người chơi";
                    break;
                default:
                    break;
            }

            lbTurn.Text = Cons.BOSS_TURN_STR;
            lbChessNumber.Text = CHESS_NUMBER + "/" + TOTAL_CHESS_NUMBER;
        }

        #region Draw function
        public void DrawChessPanel() {
            hintChesses = new List<AsiaChessButton>();
            hintEatChesses = new List<AsiaChessButton>();
            justMoveChesses = new List<AsiaChessButton>();
            selected_chess = null;

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
                        chess.ChessValue = Cons.INVALID_VALUE;
                    }

                    // Handle click
                    chess.RowIndex = i;
                    chess.ColIndex = j;
                    chessMatrix[i, j] = chess;

                    if (Cons.map[i, j] == Cons.INVALID_VALUE) {
                        continue;
                    }
                    chess.Click += Chess_Click;
                    this.chessPanel.Controls.Add(chess);

                }
            }
        }

        #endregion

        #region Util function: getEmptyChess, changeTurn, PaintHintChess, PaintEatHintChess, RemoveAllHint, removeAllJustMove
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

        public void ChangeTurn() {
            GAME_TURN = (GAME_TURN == Cons.BOSS_TURN ? Cons.CHESS_TURN : Cons.BOSS_TURN);
        }

        public void PaintHintChess(int MODE) {
            switch (MODE) {
                case Cons.SHOW_HINT:
                    foreach (var chess in hintChesses) {
                        chess.BackColor = Cons.HINT_COLOR;
                    }
                    break;
                case Cons.REMOVE_HINT:
                    foreach (var chess in hintChesses) {
                        chess.BackColor = chess.MyOriginColor;
                    }
                    break;
            }

        }

        public void PaintHintEatChess(int MODE) {
            switch (MODE) {
                case Cons.SHOW_HINT:
                    foreach (var chess in hintEatChesses) {
                        chess.BackColor = Cons.HINT_EAT_COLOR;
                    }
                    break;
                case Cons.REMOVE_HINT:
                    foreach (var chess in hintEatChesses) {
                        chess.BackColor = chess.MyOriginColor;
                    }
                    break;
            }

        }

        public void RemoveAllHint() {
            hintChesses.Clear();
            hintEatChesses.Clear();
        }

        public void RemoveAllJustMove() {
            foreach (var chess in justMoveChesses) {
                chess.BackColor = chess.MyOriginColor;
            }

            justMoveChesses.Clear();
        }
        #endregion

        #region Check move function: getListMove, getListEat
        private bool checkValidMove(Point first, Point last) {
            if ((first.X + first.Y) % 2 != 0 && (last.X + last.Y) % 2 != 0) {
                return false;
            }
            return true;
        }

        public List<AsiaChessButton> getListMove(int i, int j) {
            List<AsiaChessButton> moves = new List<AsiaChessButton>();

            #region Find Blank Moves
            // Move to main top diagonal
            if ((i - 1 >= 0) && (j - 1) >= 0
                && checkValidMove(new Point(i, j), new Point(i - 1, j - 1))
                && chessMatrix[i - 1, j - 1].isEmptyChess()) {
                moves.Add(chessMatrix[i - 1, j - 1]);
            }

            // Move to main down diagonal
            if ((i + 1 < 7) && (j + 1) < 5
                && checkValidMove(new Point(i, j), new Point(i + 1, j + 1))
                && chessMatrix[i + 1, j + 1].isEmptyChess()) {
                moves.Add(chessMatrix[i + 1, j + 1]);
            }

            // Move to top diagonal
            if ((i - 1 >= 0) && (j + 1) < 5
                && checkValidMove(new Point(i, j), new Point(i - 1, j + 1))
                && chessMatrix[i - 1, j + 1].isEmptyChess()) {
                moves.Add(chessMatrix[i - 1, j + 1]);
            }

            // Move to down diagonal
            if ((i + 1 < 7) && (j - 1) >= 0
                && checkValidMove(new Point(i, j), new Point(i + 1, j - 1))
                && chessMatrix[i + 1, j - 1].isEmptyChess()) {
                moves.Add(chessMatrix[i + 1, j - 1]);
            }

            // Move to left
            if ((j - 1 >= 0) && chessMatrix[i, j - 1].isEmptyChess())
                moves.Add(chessMatrix[i, j - 1]);
            // Move to right
            if ((j + 1 < 5) && chessMatrix[i, j + 1].isEmptyChess())
                moves.Add(chessMatrix[i, j + 1]);
            // Move to top
            if ((i - 1 >= 0) && chessMatrix[i - 1, j].isEmptyChess())
                moves.Add(chessMatrix[i - 1, j]);
            // Move to bottom
            if ((i + 1 < 7) && chessMatrix[i + 1, j].isEmptyChess())
                moves.Add(chessMatrix[i + 1, j]);
            #endregion

            return moves;
        }

        public List<AsiaChessButton> getListEat(int i, int j) {
            List<AsiaChessButton> eats = new List<AsiaChessButton>();
            foreach (var chess in hintChesses) {
                int a1 = chess.RowIndex - i;
                int a2 = chess.ColIndex - j;

                if ((chess.RowIndex + a1 < 7) && (chess.RowIndex + a1 >= 0)
                    && (chess.ColIndex + a2 < 5) && (chess.ColIndex + a2 >= 0)
                    && chessMatrix[chess.RowIndex + a1, chess.ColIndex + a2].isChess())

                    eats.Add(chessMatrix[chess.RowIndex + a1, chess.ColIndex + a2]);
            }
            return eats;
        }
        #endregion

        private void Chess_Click(object sender, EventArgs e) {
            AsiaChessButton current_chess = sender as AsiaChessButton;

            #region Check valid turn
            if (
                (current_chess.isBoss() && GAME_TURN != Cons.BOSS_TURN)
            || (current_chess.isChess() && GAME_TURN != Cons.CHESS_TURN)
                ) {
                return;
            }
            #endregion

            #region First click on empty chess
            if (selected_chess == null && current_chess.isEmptyChess()) {
                return;
            }
            #endregion

            #region Select a chess
            if (selected_chess == null && !current_chess.isEmptyChess()) {
                selected_chess = current_chess;
                selected_chess.BackColor = Cons.SELECTED_COLOR;
                int i = selected_chess.RowIndex;
                int j = selected_chess.ColIndex;
                hintChesses = getListMove(i, j);
                PaintHintChess(Cons.SHOW_HINT);

                if (current_chess.isBoss()) {
                    hintEatChesses = getListEat(i, j);
                    PaintHintEatChess(Cons.SHOW_HINT);
                }

                return;
            }
            #endregion

            #region  Re-click chess (unselected)
            if (selected_chess == current_chess) {
                selected_chess.BackColor = selected_chess.MyOriginColor;
                selected_chess = null;
                PaintHintChess(Cons.REMOVE_HINT);

                if (current_chess.isBoss()) {
                    PaintHintEatChess(Cons.REMOVE_HINT);
                }
                return;
            }
            #endregion

            #region Change selected
            if (selected_chess.ChessValue == current_chess.ChessValue) {
                PaintHintChess(Cons.REMOVE_HINT);
                PaintHintEatChess(Cons.REMOVE_HINT);
                RemoveAllHint();

                selected_chess.BackColor = selected_chess.MyOriginColor;
                selected_chess = current_chess;
                selected_chess.BackColor = Cons.SELECTED_COLOR;

                int i = selected_chess.RowIndex;
                int j = selected_chess.ColIndex;
                hintChesses = getListMove(i, j);
                PaintHintChess(Cons.SHOW_HINT);

                if (current_chess.isBoss()) {
                    hintEatChesses = getListEat(i, j);
                    PaintHintEatChess(Cons.SHOW_HINT);
                }
                return;
            }
            #endregion

            #region Move chess
            if (!selected_chess.isEmptyChess() && current_chess.isEmptyChess() && hintChesses.Contains(current_chess)) {
                // Only move if in hint list
                PaintHintChess(Cons.REMOVE_HINT);
                PaintHintEatChess(Cons.REMOVE_HINT);
                RemoveAllJustMove();
                justMoveChesses.Add(selected_chess);

                if (selected_chess.isBoss()) {
                    current_chess.ChessValue = Cons.BOSS_VALUE;
                    current_chess.MyOriginColor = Cons.BOSS_COLOR;
                    current_chess.BackColor = Cons.BOSS_COLOR;
                }
                else {
                    current_chess.ChessValue = Cons.CHESS_VALUE;
                    current_chess.MyOriginColor = Cons.CHESS_COLOR;
                    current_chess.BackColor = Cons.CHESS_COLOR;
                }

                selected_chess.ChessValue = Cons.EMPTY_VALUE;
                selected_chess.BackColor = Cons.JUST_MOVE_COLOR;
                selected_chess.MyOriginColor = Cons.EMPTY_COLOR;

                selected_chess = null;
                ChangeTurn();
                return;
            }
            #endregion

            #region Eat chess
            if (selected_chess.isBoss() && current_chess.isChess() && hintEatChesses.Contains(current_chess)) {
                PaintHintChess(Cons.REMOVE_HINT);
                PaintHintEatChess(Cons.REMOVE_HINT);
                RemoveAllHint();

                // Selected --> empty
                selected_chess.ChessValue = Cons.EMPTY_VALUE;
                selected_chess.MyOriginColor = Cons.EMPTY_COLOR;
                selected_chess.BackColor = Cons.JUST_MOVE_COLOR;

                // current --> boss
                current_chess.ChessValue = Cons.BOSS_VALUE;
                current_chess.MyOriginColor = Cons.BOSS_COLOR;
                current_chess.BackColor = Cons.BOSS_COLOR;

                selected_chess = null;
                ChangeTurn();
                return;
            }
            #endregion


        }
    }
}
