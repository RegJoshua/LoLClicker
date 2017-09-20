namespace LoLClicker
{
    partial class mainMenuForm
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
            this.playButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lolPictureBox = new System.Windows.Forms.PictureBox();
            this.songLabel = new System.Windows.Forms.Label();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lolPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Gray;
            this.playButton.Location = new System.Drawing.Point(208, 151);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(104, 32);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play Game!";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.Gray;
            this.helpButton.Location = new System.Drawing.Point(208, 189);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(104, 32);
            this.helpButton.TabIndex = 1;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lolPictureBox
            // 
            this.lolPictureBox.Location = new System.Drawing.Point(110, 42);
            this.lolPictureBox.Name = "lolPictureBox";
            this.lolPictureBox.Size = new System.Drawing.Size(311, 103);
            this.lolPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lolPictureBox.TabIndex = 2;
            this.lolPictureBox.TabStop = false;
            // 
            // songLabel
            // 
            this.songLabel.AutoSize = true;
            this.songLabel.Location = new System.Drawing.Point(208, 453);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(100, 13);
            this.songLabel.TabIndex = 3;
            this.songLabel.Text = "Song - Now Playing";
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Location = new System.Drawing.Point(57, 295);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(416, 130);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPictureBox.TabIndex = 4;
            this.mainPictureBox.TabStop = false;
            // 
            // mainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(535, 478);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.songLabel);
            this.Controls.Add(this.lolPictureBox);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.playButton);
            this.Name = "mainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoLClicker - Main Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainMenuForm_FormClosing);
            this.Load += new System.EventHandler(this.mainMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lolPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox lolPictureBox;
        private System.Windows.Forms.Label songLabel;
        private System.Windows.Forms.PictureBox mainPictureBox;
    }
}

