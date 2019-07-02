namespace Fapwad
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbQuit = new System.Windows.Forms.PictureBox();
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.pbPause = new System.Windows.Forms.PictureBox();
            this.pbNewGame = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.pbVictory = new System.Windows.Forms.PictureBox();
            this.lblVictory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVictory)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 16;
            // 
            // pbQuit
            // 
            this.pbQuit.Image = global::Fapwad.Properties.Resources.quit;
            this.pbQuit.Location = new System.Drawing.Point(828, 909);
            this.pbQuit.Name = "pbQuit";
            this.pbQuit.Size = new System.Drawing.Size(144, 47);
            this.pbQuit.TabIndex = 2;
            this.pbQuit.TabStop = false;
            this.pbQuit.Click += new System.EventHandler(this.pbQuit_Click);
            // 
            // pbLoad
            // 
            this.pbLoad.Image = global::Fapwad.Properties.Resources.load;
            this.pbLoad.Location = new System.Drawing.Point(828, 840);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(144, 40);
            this.pbLoad.TabIndex = 2;
            this.pbLoad.TabStop = false;
            this.pbLoad.Click += new System.EventHandler(this.pbLoad_Click);
            // 
            // pbSave
            // 
            this.pbSave.Image = global::Fapwad.Properties.Resources.save;
            this.pbSave.Location = new System.Drawing.Point(828, 760);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(144, 50);
            this.pbSave.TabIndex = 2;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbPause
            // 
            this.pbPause.Image = global::Fapwad.Properties.Resources.pause;
            this.pbPause.Location = new System.Drawing.Point(818, 686);
            this.pbPause.Name = "pbPause";
            this.pbPause.Size = new System.Drawing.Size(170, 44);
            this.pbPause.TabIndex = 2;
            this.pbPause.TabStop = false;
            this.pbPause.Click += new System.EventHandler(this.pbPause_Click);
            // 
            // pbNewGame
            // 
            this.pbNewGame.Image = global::Fapwad.Properties.Resources.newGame;
            this.pbNewGame.Location = new System.Drawing.Point(809, 604);
            this.pbNewGame.Name = "pbNewGame";
            this.pbNewGame.Size = new System.Drawing.Size(181, 50);
            this.pbNewGame.TabIndex = 1;
            this.pbNewGame.TabStop = false;
            this.pbNewGame.Click += new System.EventHandler(this.pbNewGame_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Fapwad.Properties.Resources.Level1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 1080);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(797, 989);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(35, 13);
            this.lblGrade.TabIndex = 3;
            this.lblGrade.Text = "label1";
            // 
            // pbVictory
            // 
            this.pbVictory.Location = new System.Drawing.Point(124, 36);
            this.pbVictory.Name = "pbVictory";
            this.pbVictory.Size = new System.Drawing.Size(550, 120);
            this.pbVictory.TabIndex = 4;
            this.pbVictory.TabStop = false;
            this.pbVictory.Visible = false;
            // 
            // lblVictory
            // 
            this.lblVictory.AutoSize = true;
            this.lblVictory.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblVictory.ForeColor = System.Drawing.Color.Red;
            this.lblVictory.Location = new System.Drawing.Point(171, 186);
            this.lblVictory.Name = "lblVictory";
            this.lblVictory.Size = new System.Drawing.Size(35, 13);
            this.lblVictory.TabIndex = 5;
            this.lblVictory.Text = "label1";
            this.lblVictory.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1000, 1080);
            this.Controls.Add(this.lblVictory);
            this.Controls.Add(this.pbVictory);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.pbQuit);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.pbSave);
            this.Controls.Add(this.pbPause);
            this.Controls.Add(this.pbNewGame);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVictory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbNewGame;
        private System.Windows.Forms.PictureBox pbPause;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.PictureBox pbLoad;
        private System.Windows.Forms.PictureBox pbQuit;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.PictureBox pbVictory;
        private System.Windows.Forms.Label lblVictory;
    }
}

