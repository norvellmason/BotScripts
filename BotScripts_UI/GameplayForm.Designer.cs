namespace BotScripts_UI
{
    partial class GameplayForm
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
            this.playerCodePanel = new System.Windows.Forms.Panel();
            this.PlayerInputTexBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.botCodePanel = new System.Windows.Forms.Panel();
            this.AITexBox = new System.Windows.Forms.TextBox();
            this.gamePanel = new BotScripts_UI.DoubleBufferedPanel();
            this.playerCodePanel.SuspendLayout();
            this.botCodePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerCodePanel
            // 
            this.playerCodePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.playerCodePanel.Controls.Add(this.PlayerInputTexBox);
            this.playerCodePanel.Controls.Add(this.startButton);
            this.playerCodePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.playerCodePanel.Location = new System.Drawing.Point(0, 0);
            this.playerCodePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playerCodePanel.Name = "playerCodePanel";
            this.playerCodePanel.Size = new System.Drawing.Size(141, 664);
            this.playerCodePanel.TabIndex = 0;
            // 
            // PlayerInputTexBox
            // 
            this.PlayerInputTexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerInputTexBox.Location = new System.Drawing.Point(0, 0);
            this.PlayerInputTexBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PlayerInputTexBox.Multiline = true;
            this.PlayerInputTexBox.Name = "PlayerInputTexBox";
            this.PlayerInputTexBox.Size = new System.Drawing.Size(141, 546);
            this.PlayerInputTexBox.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(0, 546);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(141, 118);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Fight";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // botCodePanel
            // 
            this.botCodePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.botCodePanel.Controls.Add(this.AITexBox);
            this.botCodePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.botCodePanel.Location = new System.Drawing.Point(1147, 0);
            this.botCodePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botCodePanel.Name = "botCodePanel";
            this.botCodePanel.Size = new System.Drawing.Size(111, 664);
            this.botCodePanel.TabIndex = 1;
            // 
            // AITexBox
            // 
            this.AITexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AITexBox.Location = new System.Drawing.Point(0, 0);
            this.AITexBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AITexBox.Multiline = true;
            this.AITexBox.Name = "AITexBox";
            this.AITexBox.ReadOnly = true;
            this.AITexBox.Size = new System.Drawing.Size(111, 664);
            this.AITexBox.TabIndex = 0;
            // 
            // gamePanel
            // 
            this.gamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePanel.Location = new System.Drawing.Point(141, 0);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(1006, 664);
            this.gamePanel.TabIndex = 2;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            // 
            // GameplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.botCodePanel);
            this.Controls.Add(this.playerCodePanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GameplayForm";
            this.Text = "BotScripts";
            this.Resize += new System.EventHandler(this.GameplayForm_Resize);
            this.playerCodePanel.ResumeLayout(false);
            this.playerCodePanel.PerformLayout();
            this.botCodePanel.ResumeLayout(false);
            this.botCodePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel playerCodePanel;
        private System.Windows.Forms.Panel botCodePanel;
        private System.Windows.Forms.TextBox PlayerInputTexBox;
        private System.Windows.Forms.TextBox AITexBox;
        private System.Windows.Forms.Button startButton;
        private DoubleBufferedPanel gamePanel;
    }
}

