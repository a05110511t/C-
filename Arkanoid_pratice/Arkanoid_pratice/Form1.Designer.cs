namespace Arkanoid_pratice
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
            this.components = new System.ComponentModel.Container();
            this.Start = new System.Windows.Forms.Button();
            this.playground = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.racket2 = new System.Windows.Forms.PictureBox();
            this.racket1 = new System.Windows.Forms.PictureBox();
            this.racket3 = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Score_label = new System.Windows.Forms.Label();
            this.Points_label = new System.Windows.Forms.Label();
            this.gameover_label = new System.Windows.Forms.Label();
            this.playground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(305, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // playground
            // 
            this.playground.Controls.Add(this.gameover_label);
            this.playground.Controls.Add(this.Points_label);
            this.playground.Controls.Add(this.Score_label);
            this.playground.Controls.Add(this.ball);
            this.playground.Controls.Add(this.pictureBox4);
            this.playground.Controls.Add(this.racket2);
            this.playground.Controls.Add(this.racket1);
            this.playground.Controls.Add(this.racket3);
            this.playground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playground.Location = new System.Drawing.Point(0, 0);
            this.playground.Name = "playground";
            this.playground.Size = new System.Drawing.Size(391, 370);
            this.playground.TabIndex = 5;
            this.playground.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox4.Location = new System.Drawing.Point(144, 325);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(84, 18);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click_1);
            // 
            // racket2
            // 
            this.racket2.BackColor = System.Drawing.SystemColors.Highlight;
            this.racket2.Location = new System.Drawing.Point(144, 113);
            this.racket2.Name = "racket2";
            this.racket2.Size = new System.Drawing.Size(99, 71);
            this.racket2.TabIndex = 7;
            this.racket2.TabStop = false;
            this.racket2.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // racket1
            // 
            this.racket1.BackColor = System.Drawing.SystemColors.Highlight;
            this.racket1.Location = new System.Drawing.Point(27, 60);
            this.racket1.Name = "racket1";
            this.racket1.Size = new System.Drawing.Size(52, 33);
            this.racket1.TabIndex = 6;
            this.racket1.TabStop = false;
            this.racket1.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // racket3
            // 
            this.racket3.BackColor = System.Drawing.SystemColors.Highlight;
            this.racket3.Location = new System.Drawing.Point(289, 60);
            this.racket3.Name = "racket3";
            this.racket3.Size = new System.Drawing.Size(76, 57);
            this.racket3.TabIndex = 5;
            this.racket3.TabStop = false;
            this.racket3.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Red;
            this.ball.Location = new System.Drawing.Point(67, 216);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(25, 25);
            this.ball.TabIndex = 9;
            this.ball.TabStop = false;
            this.ball.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Score_label
            // 
            this.Score_label.AutoSize = true;
            this.Score_label.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Score_label.Location = new System.Drawing.Point(301, 9);
            this.Score_label.Name = "Score_label";
            this.Score_label.Size = new System.Drawing.Size(47, 19);
            this.Score_label.TabIndex = 6;
            this.Score_label.Text = "Score";
            this.Score_label.Click += new System.EventHandler(this.Score_label_Click);
            // 
            // Points_label
            // 
            this.Points_label.AutoSize = true;
            this.Points_label.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Points_label.Location = new System.Drawing.Point(354, 12);
            this.Points_label.Name = "Points_label";
            this.Points_label.Size = new System.Drawing.Size(15, 16);
            this.Points_label.TabIndex = 10;
            this.Points_label.Text = "0";
            // 
            // gameover_label
            // 
            this.gameover_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameover_label.AutoSize = true;
            this.gameover_label.Location = new System.Drawing.Point(3, 2);
            this.gameover_label.Name = "gameover_label";
            this.gameover_label.Size = new System.Drawing.Size(87, 36);
            this.gameover_label.TabIndex = 11;
            this.gameover_label.Text = "Game Over!\r\nPress F1 = Restart\r\nPress Esc = Exit";
            this.gameover_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameover_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 370);
            this.Controls.Add(this.playground);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.playground.ResumeLayout(false);
            this.playground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button Start;
        private System.Windows.Forms.Panel playground;
        private System.Windows.Forms.Label Points_label;
        private System.Windows.Forms.Label Score_label;
        public System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox racket2;
        private System.Windows.Forms.PictureBox racket1;
        private System.Windows.Forms.PictureBox racket3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label gameover_label;


    }
}

