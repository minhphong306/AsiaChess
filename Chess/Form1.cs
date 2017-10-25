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
        private ChessBoardManager chessBoardManager;

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


        private void Form1_Load(object sender, EventArgs e) {
            chessBoardManager = new ChessBoardManager(this);
            chessBoardManager.lbGameMode = lbMode;
            chessBoardManager.lbTurn = lbTurn;
            chessBoardManager.lbChessNumber = lbChessNumber;

            chessBoardManager.DrawChessPanel();
            chessBoardManager.DrawChess();
            chessBoardManager.chessPanel.Enabled = false;
            
        }

        private void btnNewGame_Click(object sender, EventArgs e) {
            chessBoardManager.NewGame(Cons.GM_TWO_PLAYER);
            btnNewGame.BackColor = Color.Red;
            btnAIGame.BackColor = Color.Gray;

        }

        private void btnAIGame_Click(object sender, EventArgs e) {
            chessBoardManager.NewGame(Cons.GM_AI);
            btnNewGame.BackColor = Color.Gray;
            btnAIGame.BackColor = Color.Red;
        }
    }
}
