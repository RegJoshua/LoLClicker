namespace LoLClicker
{
    partial class Results
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
            this.clickLabel = new System.Windows.Forms.Label();
            this.tLabel = new System.Windows.Forms.Label();
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clickLabel
            // 
            this.clickLabel.AutoSize = true;
            this.clickLabel.Location = new System.Drawing.Point(143, 79);
            this.clickLabel.Name = "clickLabel";
            this.clickLabel.Size = new System.Drawing.Size(57, 13);
            this.clickLabel.TabIndex = 0;
            this.clickLabel.Text = "# of Clicks";
            // 
            // tLabel
            // 
            this.tLabel.AutoSize = true;
            this.tLabel.Location = new System.Drawing.Point(143, 136);
            this.tLabel.Name = "tLabel";
            this.tLabel.Size = new System.Drawing.Size(36, 13);
            this.tLabel.TabIndex = 1;
            this.tLabel.Text = "Time: ";
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.Location = new System.Drawing.Point(146, 286);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(75, 23);
            this.mainMenuButton.TabIndex = 2;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = true;
            this.mainMenuButton.Click += new System.EventHandler(this.mainMenuButton_Click);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 321);
            this.Controls.Add(this.mainMenuButton);
            this.Controls.Add(this.tLabel);
            this.Controls.Add(this.clickLabel);
            this.Name = "Results";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Results_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clickLabel;
        private System.Windows.Forms.Label tLabel;
        private System.Windows.Forms.Button mainMenuButton;
    }
}