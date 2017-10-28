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
            this.botCodePanel = new System.Windows.Forms.Panel();
            this.AITexBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
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
            this.playerCodePanel.Name = "playerCodePanel";
            this.playerCodePanel.Size = new System.Drawing.Size(125, 531);
            this.playerCodePanel.TabIndex = 0;
            // 
            // PlayerInputTexBox
            // 
            this.PlayerInputTexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerInputTexBox.Location = new System.Drawing.Point(0, 0);
            this.PlayerInputTexBox.Multiline = true;
            this.PlayerInputTexBox.Name = "PlayerInputTexBox";
            this.PlayerInputTexBox.Size = new System.Drawing.Size(125, 437);
            this.PlayerInputTexBox.TabIndex = 0;
            // 
            // botCodePanel
            // 
            this.botCodePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.botCodePanel.Controls.Add(this.AITexBox);
            this.botCodePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.botCodePanel.Location = new System.Drawing.Point(1019, 0);
            this.botCodePanel.Name = "botCodePanel";
            this.botCodePanel.Size = new System.Drawing.Size(99, 531);
            this.botCodePanel.TabIndex = 1;
            // 
            // AITexBox
            // 
            this.AITexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AITexBox.Location = new System.Drawing.Point(0, 0);
            this.AITexBox.Multiline = true;
            this.AITexBox.Name = "AITexBox";
            this.AITexBox.ReadOnly = true;
            this.AITexBox.Size = new System.Drawing.Size(99, 531);
            this.AITexBox.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(125, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 531);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.GameplayForm_Paint);
            // 
            // startButton
            // 
            this.startButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(0, 437);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(125, 94);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Fight";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // GameplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 531);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botCodePanel);
            this.Controls.Add(this.playerCodePanel);
            this.DoubleBuffered = true;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox PlayerInputTexBox;
        private System.Windows.Forms.TextBox AITexBox;
        private System.Windows.Forms.Button startButton;
    }
}

