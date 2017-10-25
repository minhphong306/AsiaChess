namespace AsiaChess {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnNewGame = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAIGame = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTurn = new System.Windows.Forms.Label();
            this.lbMode = new System.Windows.Forms.Label();
            this.lbChessNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.asiaChessButton6 = new AsiaChess.AsiaChessButton();
            this.asiaChessButton5 = new AsiaChess.AsiaChessButton();
            this.asiaChessButton4 = new AsiaChess.AsiaChessButton();
            this.asiaChessButton3 = new AsiaChess.AsiaChessButton();
            this.asiaChessButton2 = new AsiaChess.AsiaChessButton();
            this.asiaChessButton1 = new AsiaChess.AsiaChessButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.Location = new System.Drawing.Point(27, 55);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(182, 43);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAIGame);
            this.groupBox1.Controls.Add(this.btnNewGame);
            this.groupBox1.Font = new System.Drawing.Font("UTM Facebook", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(629, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 149);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game controller";
            // 
            // btnAIGame
            // 
            this.btnAIGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAIGame.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAIGame.Location = new System.Drawing.Point(265, 55);
            this.btnAIGame.Name = "btnAIGame";
            this.btnAIGame.Size = new System.Drawing.Size(197, 43);
            this.btnAIGame.TabIndex = 0;
            this.btnAIGame.Text = "New AI Game";
            this.btnAIGame.UseVisualStyleBackColor = true;
            this.btnAIGame.Click += new System.EventHandler(this.btnAIGame_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbTurn);
            this.groupBox2.Controls.Add(this.lbMode);
            this.groupBox2.Controls.Add(this.lbChessNumber);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("UTM Facebook", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(629, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(543, 459);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game info";
            // 
            // lbTurn
            // 
            this.lbTurn.Font = new System.Drawing.Font("UTM Facebook", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbTurn.Location = new System.Drawing.Point(0, 38);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Size = new System.Drawing.Size(488, 59);
            this.lbTurn.TabIndex = 3;
            this.lbTurn.Text = "Vui lòng chọn chế độ";
            this.lbTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.Location = new System.Drawing.Point(175, 117);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(0, 35);
            this.lbMode.TabIndex = 3;
            // 
            // lbChessNumber
            // 
            this.lbChessNumber.AutoSize = true;
            this.lbChessNumber.Location = new System.Drawing.Point(175, 172);
            this.lbChessNumber.Name = "lbChessNumber";
            this.lbChessNumber.Size = new System.Drawing.Size(0, 35);
            this.lbChessNumber.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 35);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số quân";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chế độ";
            // 
            // asiaChessButton6
            // 
            this.asiaChessButton6.BackColor = System.Drawing.Color.Black;
            this.asiaChessButton6.ChessValue = 0;
            this.asiaChessButton6.ColIndex = 0;
            this.asiaChessButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.asiaChessButton6.ForeColor = System.Drawing.Color.White;
            this.asiaChessButton6.Location = new System.Drawing.Point(537, 489);
            this.asiaChessButton6.MyOriginColor = System.Drawing.Color.Empty;
            this.asiaChessButton6.Name = "asiaChessButton6";
            this.asiaChessButton6.RowIndex = 0;
            this.asiaChessButton6.Size = new System.Drawing.Size(67, 60);
            this.asiaChessButton6.TabIndex = 1;
            this.asiaChessButton6.Text = "Gợi ý";
            this.asiaChessButton6.UseVisualStyleBackColor = false;
            // 
            // asiaChessButton5
            // 
            this.asiaChessButton5.BackColor = System.Drawing.Color.Yellow;
            this.asiaChessButton5.ChessValue = 0;
            this.asiaChessButton5.ColIndex = 0;
            this.asiaChessButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.asiaChessButton5.Location = new System.Drawing.Point(537, 409);
            this.asiaChessButton5.MyOriginColor = System.Drawing.Color.Empty;
            this.asiaChessButton5.Name = "asiaChessButton5";
            this.asiaChessButton5.RowIndex = 0;
            this.asiaChessButton5.Size = new System.Drawing.Size(67, 60);
            this.asiaChessButton5.TabIndex = 1;
            this.asiaChessButton5.Text = "Gợi ý";
            this.asiaChessButton5.UseVisualStyleBackColor = false;
            // 
            // asiaChessButton4
            // 
            this.asiaChessButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.asiaChessButton4.ChessValue = 0;
            this.asiaChessButton4.ColIndex = 0;
            this.asiaChessButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.asiaChessButton4.Location = new System.Drawing.Point(537, 332);
            this.asiaChessButton4.MyOriginColor = System.Drawing.Color.Empty;
            this.asiaChessButton4.Name = "asiaChessButton4";
            this.asiaChessButton4.RowIndex = 0;
            this.asiaChessButton4.Size = new System.Drawing.Size(67, 60);
            this.asiaChessButton4.TabIndex = 1;
            this.asiaChessButton4.Text = "Vừa đánh";
            this.asiaChessButton4.UseVisualStyleBackColor = false;
            // 
            // asiaChessButton3
            // 
            this.asiaChessButton3.BackColor = System.Drawing.Color.Blue;
            this.asiaChessButton3.ChessValue = 0;
            this.asiaChessButton3.ColIndex = 0;
            this.asiaChessButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.asiaChessButton3.ForeColor = System.Drawing.Color.Yellow;
            this.asiaChessButton3.Location = new System.Drawing.Point(537, 258);
            this.asiaChessButton3.MyOriginColor = System.Drawing.Color.Empty;
            this.asiaChessButton3.Name = "asiaChessButton3";
            this.asiaChessButton3.RowIndex = 0;
            this.asiaChessButton3.Size = new System.Drawing.Size(67, 60);
            this.asiaChessButton3.TabIndex = 1;
            this.asiaChessButton3.Text = "Quân";
            this.asiaChessButton3.UseVisualStyleBackColor = false;
            // 
            // asiaChessButton2
            // 
            this.asiaChessButton2.BackColor = System.Drawing.Color.Red;
            this.asiaChessButton2.ChessValue = 0;
            this.asiaChessButton2.ColIndex = 0;
            this.asiaChessButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.asiaChessButton2.ForeColor = System.Drawing.Color.Yellow;
            this.asiaChessButton2.Location = new System.Drawing.Point(537, 182);
            this.asiaChessButton2.MyOriginColor = System.Drawing.Color.Empty;
            this.asiaChessButton2.Name = "asiaChessButton2";
            this.asiaChessButton2.RowIndex = 0;
            this.asiaChessButton2.Size = new System.Drawing.Size(67, 60);
            this.asiaChessButton2.TabIndex = 1;
            this.asiaChessButton2.Text = "Tướng";
            this.asiaChessButton2.UseVisualStyleBackColor = false;
            // 
            // asiaChessButton1
            // 
            this.asiaChessButton1.ChessValue = 0;
            this.asiaChessButton1.ColIndex = 0;
            this.asiaChessButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.asiaChessButton1.Location = new System.Drawing.Point(537, 110);
            this.asiaChessButton1.MyOriginColor = System.Drawing.Color.Empty;
            this.asiaChessButton1.Name = "asiaChessButton1";
            this.asiaChessButton1.RowIndex = 0;
            this.asiaChessButton1.Size = new System.Drawing.Size(67, 60);
            this.asiaChessButton1.TabIndex = 1;
            this.asiaChessButton1.Text = "Quân trống";
            this.asiaChessButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 638);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.asiaChessButton6);
            this.Controls.Add(this.asiaChessButton5);
            this.Controls.Add(this.asiaChessButton4);
            this.Controls.Add(this.asiaChessButton3);
            this.Controls.Add(this.asiaChessButton2);
            this.Controls.Add(this.asiaChessButton1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewGame;
        private AsiaChessButton asiaChessButton1;
        private AsiaChessButton asiaChessButton2;
        private AsiaChessButton asiaChessButton3;
        private AsiaChessButton asiaChessButton4;
        private AsiaChessButton asiaChessButton5;
        private AsiaChessButton asiaChessButton6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAIGame;
        private System.Windows.Forms.Label lbTurn;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.Label lbChessNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

