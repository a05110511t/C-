namespace Arknoid_pratice_2
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
            this.button1 = new System.Windows.Forms.Button();
            this.blue3 = new System.Windows.Forms.PictureBox();
            this.move_board = new System.Windows.Forms.PictureBox();
            this.blue2 = new System.Windows.Forms.PictureBox();
            this.blue1 = new System.Windows.Forms.PictureBox();
            this.Score = new System.Windows.Forms.Label();
            this.points_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_label = new System.Windows.Forms.Label();
            this.gameover = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.blue3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.move_board)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // blue3
            // 
            this.blue3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blue3.BackColor = System.Drawing.Color.Blue;
            this.blue3.Cursor = System.Windows.Forms.Cursors.Default;
            this.blue3.Location = new System.Drawing.Point(316, 80);
            this.blue3.Name = "blue3";
            this.blue3.Size = new System.Drawing.Size(100, 50);
            this.blue3.TabIndex = 7;
            this.blue3.TabStop = false;
            // 
            // move_board
            // 
            this.move_board.BackColor = System.Drawing.Color.Black;
            this.move_board.Location = new System.Drawing.Point(119, 323);
            this.move_board.Name = "move_board";
            this.move_board.Size = new System.Drawing.Size(171, 28);
            this.move_board.TabIndex = 10;
            this.move_board.TabStop = false;
            // 
            // blue2
            // 
            this.blue2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blue2.BackColor = System.Drawing.Color.Blue;
            this.blue2.Location = new System.Drawing.Point(164, 163);
            this.blue2.Name = "blue2";
            this.blue2.Size = new System.Drawing.Size(79, 84);
            this.blue2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.blue2.TabIndex = 8;
            this.blue2.TabStop = false;
            // 
            // blue1
            // 
            this.blue1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blue1.BackColor = System.Drawing.Color.Blue;
            this.blue1.Location = new System.Drawing.Point(44, 46);
            this.blue1.Name = "blue1";
            this.blue1.Size = new System.Drawing.Size(67, 63);
            this.blue1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.blue1.TabIndex = 9;
            this.blue1.TabStop = false;
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Location = new System.Drawing.Point(339, 9);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(31, 12);
            this.Score.TabIndex = 11;
            this.Score.Text = "Score";
            // 
            // points_label
            // 
            this.points_label.AutoSize = true;
            this.points_label.Location = new System.Drawing.Point(376, 9);
            this.points_label.Name = "points_label";
            this.points_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.points_label.Size = new System.Drawing.Size(11, 12);
            this.points_label.TabIndex = 12;
            this.points_label.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Times";
            // 
            // timer_label
            // 
            this.timer_label.AutoSize = true;
            this.timer_label.Location = new System.Drawing.Point(376, 33);
            this.timer_label.Name = "timer_label";
            this.timer_label.Size = new System.Drawing.Size(11, 12);
            this.timer_label.TabIndex = 14;
            this.timer_label.Text = "0";
            // 
            // gameover
            // 
            this.gameover.AutoSize = true;
            this.gameover.Font = new System.Drawing.Font("PMingLiU", 30F);
            this.gameover.Location = new System.Drawing.Point(112, 250);
            this.gameover.Name = "gameover";
            this.gameover.Size = new System.Drawing.Size(0, 40);
            this.gameover.TabIndex = 15;
            this.gameover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameover.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "connected:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 390);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gameover);
            this.Controls.Add(this.timer_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.points_label);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.blue1);
            this.Controls.Add(this.blue2);
            this.Controls.Add(this.move_board);
            this.Controls.Add(this.blue3);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.blue3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.move_board)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox blue3;
        private System.Windows.Forms.PictureBox move_board;
        private System.Windows.Forms.PictureBox blue2;
        private System.Windows.Forms.PictureBox blue1;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label points_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timer_label;
        private System.Windows.Forms.Label gameover;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

