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
            this.botCodePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // playerCodePanel
            // 
            this.playerCodePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.playerCodePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.playerCodePanel.Location = new System.Drawing.Point(0, 0);
            this.playerCodePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playerCodePanel.Name = "playerCodePanel";
            this.playerCodePanel.Size = new System.Drawing.Size(141, 664);
            this.playerCodePanel.TabIndex = 0;
            // 
            // botCodePanel
            // 
            this.botCodePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.botCodePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.botCodePanel.Location = new System.Drawing.Point(1147, 0);
            this.botCodePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.botCodePanel.Name = "botCodePanel";
            this.botCodePanel.Size = new System.Drawing.Size(111, 664);
            this.botCodePanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(141, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 664);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.GameplayForm_Paint);
            // 
            // GameplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botCodePanel);
            this.Controls.Add(this.playerCodePanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GameplayForm";
            this.Text = "BotScripts";
            this.Resize += new System.EventHandler(this.GameplayForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel playerCodePanel;
        private System.Windows.Forms.Panel botCodePanel;
        private System.Windows.Forms.Panel panel1;
    }
}

