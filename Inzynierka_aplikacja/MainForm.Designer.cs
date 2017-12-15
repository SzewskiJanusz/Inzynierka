namespace Inzynierka_aplikacja
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.użytkownikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemUsername = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.wylogujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmieńHasłoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zakończToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.panelClients = new System.Windows.Forms.Panel();
            this.pbClient = new System.Windows.Forms.PictureBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.panelClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClient)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.użytkownikToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(663, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // użytkownikToolStripMenuItem
            // 
            this.użytkownikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemUsername,
            this.mItemPosition,
            this.toolStripSeparator1,
            this.wylogujToolStripMenuItem,
            this.zmieńHasłoToolStripMenuItem,
            this.toolStripSeparator2,
            this.zakończToolStripMenuItem});
            this.użytkownikToolStripMenuItem.Name = "użytkownikToolStripMenuItem";
            this.użytkownikToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.użytkownikToolStripMenuItem.Text = "Użytkownik";
            // 
            // mItemUsername
            // 
            this.mItemUsername.Name = "mItemUsername";
            this.mItemUsername.Size = new System.Drawing.Size(139, 22);
            // 
            // mItemPosition
            // 
            this.mItemPosition.Name = "mItemPosition";
            this.mItemPosition.Size = new System.Drawing.Size(139, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // wylogujToolStripMenuItem
            // 
            this.wylogujToolStripMenuItem.Name = "wylogujToolStripMenuItem";
            this.wylogujToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.wylogujToolStripMenuItem.Text = "Wyloguj";
            this.wylogujToolStripMenuItem.Click += new System.EventHandler(this.wylogujToolStripMenuItem_Click);
            // 
            // zmieńHasłoToolStripMenuItem
            // 
            this.zmieńHasłoToolStripMenuItem.Name = "zmieńHasłoToolStripMenuItem";
            this.zmieńHasłoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.zmieńHasłoToolStripMenuItem.Text = "Zmień hasło";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(136, 6);
            // 
            // zakończToolStripMenuItem
            // 
            this.zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            this.zakończToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.zakończToolStripMenuItem.Text = "Zakończ";
            // 
            // toolStrip
            // 
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(663, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // leftPanel
            // 
            this.leftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftPanel.BackColor = System.Drawing.Color.Red;
            this.leftPanel.Controls.Add(this.panelClients);
            this.leftPanel.Location = new System.Drawing.Point(0, 52);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(173, 379);
            this.leftPanel.TabIndex = 2;
            // 
            // panelClients
            // 
            this.panelClients.Controls.Add(this.pbClient);
            this.panelClients.Controls.Add(this.lblClient);
            this.panelClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelClients.Location = new System.Drawing.Point(0, 3);
            this.panelClients.Name = "panelClients";
            this.panelClients.Size = new System.Drawing.Size(170, 77);
            this.panelClients.TabIndex = 0;
            this.panelClients.Click += new System.EventHandler(this.panelClients_Click);
            // 
            // pbClient
            // 
            this.pbClient.Image = ((System.Drawing.Image)(resources.GetObject("pbClient.Image")));
            this.pbClient.Location = new System.Drawing.Point(60, 3);
            this.pbClient.Name = "pbClient";
            this.pbClient.Size = new System.Drawing.Size(43, 42);
            this.pbClient.TabIndex = 0;
            this.pbClient.TabStop = false;
            this.pbClient.Click += new System.EventHandler(this.pbClient_Click);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblClient.Location = new System.Drawing.Point(32, 45);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(108, 26);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Podatnicy";
            this.lblClient.Click += new System.EventHandler(this.lblClient_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Location = new System.Drawing.Point(179, 52);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(484, 379);
            this.contentPanel.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.Location = new System.Drawing.Point(0, 437);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(663, 19);
            this.panel3.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 454);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Aplikacja";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.panelClients.ResumeLayout(false);
            this.panelClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem użytkownikToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem wylogujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmieńHasłoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem zakończToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItemUsername;
        private System.Windows.Forms.ToolStripMenuItem mItemPosition;
        private System.Windows.Forms.PictureBox pbClient;
        private System.Windows.Forms.Panel panelClients;
        private System.Windows.Forms.Label lblClient;
    }
}