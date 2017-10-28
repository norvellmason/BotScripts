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
            this.PlayerPanel = new System.Windows.Forms.Panel();
            this.BotPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PlayerPanel
            // 
            this.PlayerPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PlayerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PlayerPanel.Location = new System.Drawing.Point(0, 0);
            this.PlayerPanel.Name = "PlayerPanel";
            this.PlayerPanel.Size = new System.Drawing.Size(200, 673);
            this.PlayerPanel.TabIndex = 0;
            // 
            // BotPanel
            // 
            this.BotPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BotPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BotPanel.Location = new System.Drawing.Point(1062, 0);
            this.BotPanel.Name = "BotPanel";
            this.BotPanel.Size = new System.Drawing.Size(200, 673);
            this.BotPanel.TabIndex = 1;
            // 
            // GameplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.BotPanel);
            this.Controls.Add(this.PlayerPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameplayForm";
            this.Text = "BotScripts";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameplayForm_Paint);
            this.Resize += new System.EventHandler(this.GameplayForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlayerPanel;
        private System.Windows.Forms.Panel BotPanel;
    }
}

