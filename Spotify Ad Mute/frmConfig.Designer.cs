namespace Spotify_Ad_Mute
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.timerCheckSpotify = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuNotifyIconItemEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuNotifyIconItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStripItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuNotifyIcon.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerCheckSpotify
            // 
            this.timerCheckSpotify.Enabled = true;
            this.timerCheckSpotify.Interval = 1000;
            this.timerCheckSpotify.Tick += new System.EventHandler(this.timerCheckSpotify_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Spotify Ad Mute";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuNotifyIcon
            // 
            this.contextMenuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuNotifyIconItemEnabled,
            this.contextMenuNotifyIconItemExit});
            this.contextMenuNotifyIcon.Name = "contextMenuNotifyIcon";
            this.contextMenuNotifyIcon.Size = new System.Drawing.Size(117, 48);
            // 
            // contextMenuNotifyIconItemEnabled
            // 
            this.contextMenuNotifyIconItemEnabled.Checked = true;
            this.contextMenuNotifyIconItemEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.contextMenuNotifyIconItemEnabled.Name = "contextMenuNotifyIconItemEnabled";
            this.contextMenuNotifyIconItemEnabled.Size = new System.Drawing.Size(116, 22);
            this.contextMenuNotifyIconItemEnabled.Text = "Enabled";
            this.contextMenuNotifyIconItemEnabled.Click += new System.EventHandler(this.contextMenuNotifyIconItemEnabled_Click);
            // 
            // contextMenuNotifyIconItemExit
            // 
            this.contextMenuNotifyIconItemExit.Name = "contextMenuNotifyIconItemExit";
            this.contextMenuNotifyIconItemExit.Size = new System.Drawing.Size(116, 22);
            this.contextMenuNotifyIconItemExit.Text = "Exit";
            this.contextMenuNotifyIconItemExit.Click += new System.EventHandler(this.contextMenuNotifyIconItemExit_Click);
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.Location = new System.Drawing.Point(0, 24);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(569, 271);
            this.listBoxOutput.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripItemExit,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(569, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStripItemExit
            // 
            this.menuStripItemExit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStripItemExit.Name = "menuStripItemExit";
            this.menuStripItemExit.Size = new System.Drawing.Size(37, 20);
            this.menuStripItemExit.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripItemAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // menuStripItemAbout
            // 
            this.menuStripItemAbout.Name = "menuStripItemAbout";
            this.menuStripItemAbout.Size = new System.Drawing.Size(152, 22);
            this.menuStripItemAbout.Text = "About";
            this.menuStripItemAbout.Click += new System.EventHandler(this.menuStripItemAbout_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 295);
            this.Controls.Add(this.listBoxOutput);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmConfig";
            this.Text = "Spotify Ad Mute";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.Shown += new System.EventHandler(this.frmConfig_Shown);
            this.contextMenuNotifyIcon.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerCheckSpotify;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem contextMenuNotifyIconItemEnabled;
        private System.Windows.Forms.ToolStripMenuItem contextMenuNotifyIconItemExit;
        private System.Windows.Forms.ListBox listBoxOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemExit;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemAbout;
    }
}

