namespace CodeParserInteractive
{
    partial class CodeParserInteractive
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
            if(disposing && (components != null))
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.variableInput = new System.Windows.Forms.TextBox();
            this.variableOutput = new System.Windows.Forms.TextBox();
            this.codeInput = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.codeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.botGenerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // variableInput
            // 
            this.variableInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.variableInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.variableInput.Location = new System.Drawing.Point(0, 33);
            this.variableInput.Multiline = true;
            this.variableInput.Name = "variableInput";
            this.variableInput.Size = new System.Drawing.Size(393, 1080);
            this.variableInput.TabIndex = 1;
            // 
            // variableOutput
            // 
            this.variableOutput.Dock = System.Windows.Forms.DockStyle.Right;
            this.variableOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.variableOutput.Location = new System.Drawing.Point(1353, 33);
            this.variableOutput.Multiline = true;
            this.variableOutput.Name = "variableOutput";
            this.variableOutput.Size = new System.Drawing.Size(340, 1080);
            this.variableOutput.TabIndex = 2;
            // 
            // codeInput
            // 
            this.codeInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.codeInput.Location = new System.Drawing.Point(393, 33);
            this.codeInput.Multiline = true;
            this.codeInput.Name = "codeInput";
            this.codeInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codeInput.Size = new System.Drawing.Size(960, 1080);
            this.codeInput.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1693, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // codeToolStripMenuItem
            // 
            this.codeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.botGenerateToolStripMenuItem});
            this.codeToolStripMenuItem.Name = "codeToolStripMenuItem";
            this.codeToolStripMenuItem.Size = new System.Drawing.Size(66, 29);
            this.codeToolStripMenuItem.Text = "Code";
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(259, 30);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(259, 30);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // botGenerateToolStripMenuItem
            // 
            this.botGenerateToolStripMenuItem.Name = "botGenerateToolStripMenuItem";
            this.botGenerateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.botGenerateToolStripMenuItem.Size = new System.Drawing.Size(259, 30);
            this.botGenerateToolStripMenuItem.Text = "Bot Generate";
            this.botGenerateToolStripMenuItem.Click += new System.EventHandler(this.botGenerateToolStripMenuItem_Click);
            // 
            // CodeParserInteractive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1693, 1113);
            this.Controls.Add(this.codeInput);
            this.Controls.Add(this.variableOutput);
            this.Controls.Add(this.variableInput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CodeParserInteractive";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox variableInput;
        private System.Windows.Forms.TextBox variableOutput;
        private System.Windows.Forms.TextBox codeInput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem codeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem botGenerateToolStripMenuItem;
    }
}

