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
            this.SimpleScriptExampleButton = new System.Windows.Forms.Button();
            this.AcceptedInputsButton = new System.Windows.Forms.Button();
            this.IntroButton = new System.Windows.Forms.Button();
            this.AITexBox = new System.Windows.Forms.TextBox();
            this.gamePanel = new BotScripts_UI.DoubleBufferedPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.playerCodePanel.SuspendLayout();
            this.botCodePanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            // botCodePanel
            // 
            this.botCodePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.botCodePanel.Controls.Add(this.tableLayoutPanel1);
            this.botCodePanel.Controls.Add(this.AITexBox);
            this.botCodePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.botCodePanel.Location = new System.Drawing.Point(858, 0);
            this.botCodePanel.Name = "botCodePanel";
            this.botCodePanel.Size = new System.Drawing.Size(260, 531);
            this.botCodePanel.TabIndex = 1;
            // 
            // SimpleScriptExampleButton
            // 
            this.SimpleScriptExampleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SimpleScriptExampleButton.Location = new System.Drawing.Point(177, 3);
            this.SimpleScriptExampleButton.Name = "SimpleScriptExampleButton";
            this.SimpleScriptExampleButton.Size = new System.Drawing.Size(80, 94);
            this.SimpleScriptExampleButton.TabIndex = 2;
            this.SimpleScriptExampleButton.Text = "Simple Script Example";
            this.SimpleScriptExampleButton.UseVisualStyleBackColor = true;
            // 
            // AcceptedInputsButton
            // 
            this.AcceptedInputsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AcceptedInputsButton.Location = new System.Drawing.Point(81, 3);
            this.AcceptedInputsButton.Name = "AcceptedInputsButton";
            this.AcceptedInputsButton.Size = new System.Drawing.Size(90, 94);
            this.AcceptedInputsButton.TabIndex = 1;
            this.AcceptedInputsButton.Text = "Accepted Inputs";
            this.AcceptedInputsButton.UseVisualStyleBackColor = true;
            // 
            // IntroButton
            // 
            this.IntroButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IntroButton.Location = new System.Drawing.Point(3, 3);
            this.IntroButton.Name = "IntroButton";
            this.IntroButton.Size = new System.Drawing.Size(72, 94);
            this.IntroButton.TabIndex = 0;
            this.IntroButton.Text = "Intro";
            this.IntroButton.UseVisualStyleBackColor = true;
            // 
            // AITexBox
            // 
            this.AITexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AITexBox.Location = new System.Drawing.Point(0, 0);
            this.AITexBox.Multiline = true;
            this.AITexBox.Name = "AITexBox";
            this.AITexBox.ReadOnly = true;
            this.AITexBox.Size = new System.Drawing.Size(260, 531);
            this.AITexBox.TabIndex = 0;
            // 
            // gamePanel
            // 
            this.gamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePanel.Location = new System.Drawing.Point(125, 0);
            this.gamePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(733, 531);
            this.gamePanel.TabIndex = 2;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.87805F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.12195F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.Controls.Add(this.SimpleScriptExampleButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.IntroButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AcceptedInputsButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // GameplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 531);
            this.Controls.Add(this.gamePanel);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel playerCodePanel;
        private System.Windows.Forms.Panel botCodePanel;
        private System.Windows.Forms.TextBox PlayerInputTexBox;
        private System.Windows.Forms.TextBox AITexBox;
        private System.Windows.Forms.Button startButton;
        private DoubleBufferedPanel gamePanel;
        private System.Windows.Forms.Button IntroButton;
        private System.Windows.Forms.Button SimpleScriptExampleButton;
        private System.Windows.Forms.Button AcceptedInputsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

