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
            this.wylogujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmieńHasłoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zakończToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.panelRegistry = new System.Windows.Forms.Panel();
            this.pbRegistry = new System.Windows.Forms.PictureBox();
            this.lblRegistry = new System.Windows.Forms.Label();
            this.panelDevices = new System.Windows.Forms.Panel();
            this.pbDevice = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelClients = new System.Windows.Forms.Panel();
            this.pbClient = new System.Windows.Forms.PictureBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelPrzeglad = new System.Windows.Forms.Panel();
            this.pbPrzeglad = new System.Windows.Forms.PictureBox();
            this.lblPrzeglad = new System.Windows.Forms.Label();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.narzędziaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLogged = new System.Windows.Forms.Label();
            this.lblTodaysDate = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.panelRegistry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRegistry)).BeginInit();
            this.panelDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDevice)).BeginInit();
            this.panelClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClient)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelPrzeglad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrzeglad)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.użytkownikToolStripMenuItem,
            this.widokToolStripMenuItem,
            this.dodajToolStripMenuItem,
            this.narzędziaToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(663, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // użytkownikToolStripMenuItem
            // 
            this.użytkownikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wylogujToolStripMenuItem,
            this.toolStripSeparator1,
            this.zmieńHasłoToolStripMenuItem,
            this.zakończToolStripMenuItem});
            this.użytkownikToolStripMenuItem.Name = "użytkownikToolStripMenuItem";
            this.użytkownikToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.użytkownikToolStripMenuItem.Text = "Użytkownik";
            // 
            // wylogujToolStripMenuItem
            // 
            this.wylogujToolStripMenuItem.Name = "wylogujToolStripMenuItem";
            this.wylogujToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wylogujToolStripMenuItem.Text = "Wyloguj";
            this.wylogujToolStripMenuItem.Click += new System.EventHandler(this.wylogujToolStripMenuItem_Click);
            // 
            // zmieńHasłoToolStripMenuItem
            // 
            this.zmieńHasłoToolStripMenuItem.Name = "zmieńHasłoToolStripMenuItem";
            this.zmieńHasłoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zmieńHasłoToolStripMenuItem.Text = "Zmień hasło";
            // 
            // zakończToolStripMenuItem
            // 
            this.zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            this.zakończToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zakończToolStripMenuItem.Text = "Zakończ";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
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
            this.leftPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.leftPanel.Controls.Add(this.panelPrzeglad);
            this.leftPanel.Controls.Add(this.panelRegistry);
            this.leftPanel.Controls.Add(this.panelDevices);
            this.leftPanel.Controls.Add(this.panelClients);
            this.leftPanel.Location = new System.Drawing.Point(0, 52);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(173, 379);
            this.leftPanel.TabIndex = 2;
            // 
            // panelRegistry
            // 
            this.panelRegistry.Controls.Add(this.pbRegistry);
            this.panelRegistry.Controls.Add(this.lblRegistry);
            this.panelRegistry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelRegistry.Location = new System.Drawing.Point(1, 151);
            this.panelRegistry.Name = "panelRegistry";
            this.panelRegistry.Size = new System.Drawing.Size(170, 77);
            this.panelRegistry.TabIndex = 2;
            this.panelRegistry.Click += new System.EventHandler(this.ShowRegistry_Click);
            // 
            // pbRegistry
            // 
            this.pbRegistry.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbRegistry.ErrorImage")));
            this.pbRegistry.Image = ((System.Drawing.Image)(resources.GetObject("pbRegistry.Image")));
            this.pbRegistry.Location = new System.Drawing.Point(60, 3);
            this.pbRegistry.Name = "pbRegistry";
            this.pbRegistry.Size = new System.Drawing.Size(43, 42);
            this.pbRegistry.TabIndex = 0;
            this.pbRegistry.TabStop = false;
            this.pbRegistry.Click += new System.EventHandler(this.ShowRegistry_Click);
            // 
            // lblRegistry
            // 
            this.lblRegistry.AutoSize = true;
            this.lblRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRegistry.Location = new System.Drawing.Point(21, 48);
            this.lblRegistry.Name = "lblRegistry";
            this.lblRegistry.Size = new System.Drawing.Size(130, 20);
            this.lblRegistry.TabIndex = 1;
            this.lblRegistry.Text = "Wykonane usługi";
            this.lblRegistry.Click += new System.EventHandler(this.ShowRegistry_Click);
            // 
            // panelDevices
            // 
            this.panelDevices.Controls.Add(this.pbDevice);
            this.panelDevices.Controls.Add(this.label1);
            this.panelDevices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelDevices.Location = new System.Drawing.Point(0, 77);
            this.panelDevices.Name = "panelDevices";
            this.panelDevices.Size = new System.Drawing.Size(170, 77);
            this.panelDevices.TabIndex = 1;
            this.panelDevices.Click += new System.EventHandler(this.panelDevices_Click);
            // 
            // pbDevice
            // 
            this.pbDevice.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbDevice.ErrorImage")));
            this.pbDevice.Image = ((System.Drawing.Image)(resources.GetObject("pbDevice.Image")));
            this.pbDevice.Location = new System.Drawing.Point(60, 3);
            this.pbDevice.Name = "pbDevice";
            this.pbDevice.Size = new System.Drawing.Size(43, 42);
            this.pbDevice.TabIndex = 0;
            this.pbDevice.TabStop = false;
            this.pbDevice.Click += new System.EventHandler(this.panelDevices_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wszystkie urządzenia";
            this.label1.Click += new System.EventHandler(this.panelDevices_Click);
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
            this.panelClients.Click += new System.EventHandler(this.ShowUsersClick);
            // 
            // pbClient
            // 
            this.pbClient.Image = ((System.Drawing.Image)(resources.GetObject("pbClient.Image")));
            this.pbClient.Location = new System.Drawing.Point(60, 3);
            this.pbClient.Name = "pbClient";
            this.pbClient.Size = new System.Drawing.Size(43, 42);
            this.pbClient.TabIndex = 0;
            this.pbClient.TabStop = false;
            this.pbClient.Click += new System.EventHandler(this.ShowUsersClick);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblClient.Location = new System.Drawing.Point(37, 48);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(94, 20);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Kontrahenci";
            this.lblClient.Click += new System.EventHandler(this.ShowUsersClick);
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
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.lblLogged);
            this.panel3.Controls.Add(this.lblTodaysDate);
            this.panel3.Location = new System.Drawing.Point(0, 437);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(663, 19);
            this.panel3.TabIndex = 4;
            // 
            // panelPrzeglad
            // 
            this.panelPrzeglad.Controls.Add(this.pbPrzeglad);
            this.panelPrzeglad.Controls.Add(this.lblPrzeglad);
            this.panelPrzeglad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelPrzeglad.Location = new System.Drawing.Point(1, 222);
            this.panelPrzeglad.Name = "panelPrzeglad";
            this.panelPrzeglad.Size = new System.Drawing.Size(170, 77);
            this.panelPrzeglad.TabIndex = 3;
            // 
            // pbPrzeglad
            // 
            this.pbPrzeglad.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbPrzeglad.ErrorImage")));
            this.pbPrzeglad.Image = ((System.Drawing.Image)(resources.GetObject("pbPrzeglad.Image")));
            this.pbPrzeglad.Location = new System.Drawing.Point(60, 3);
            this.pbPrzeglad.Name = "pbPrzeglad";
            this.pbPrzeglad.Size = new System.Drawing.Size(43, 42);
            this.pbPrzeglad.TabIndex = 0;
            this.pbPrzeglad.TabStop = false;
            // 
            // lblPrzeglad
            // 
            this.lblPrzeglad.AutoSize = true;
            this.lblPrzeglad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPrzeglad.Location = new System.Drawing.Point(15, 48);
            this.lblPrzeglad.Name = "lblPrzeglad";
            this.lblPrzeglad.Size = new System.Drawing.Size(152, 20);
            this.lblPrzeglad.TabIndex = 1;
            this.lblPrzeglad.Text = "Najbliższe przeglądy";
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            // 
            // narzędziaToolStripMenuItem
            // 
            this.narzędziaToolStripMenuItem.Name = "narzędziaToolStripMenuItem";
            this.narzędziaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.narzędziaToolStripMenuItem.Text = "Narzędzia";
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // lblLogged
            // 
            this.lblLogged.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogged.AutoSize = true;
            this.lblLogged.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLogged.Location = new System.Drawing.Point(457, 0);
            this.lblLogged.Name = "lblLogged";
            this.lblLogged.Size = new System.Drawing.Size(24, 13);
            this.lblLogged.TabIndex = 0;
            this.lblLogged.Text = "test";
            // 
            // lblTodaysDate
            // 
            this.lblTodaysDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTodaysDate.AutoSize = true;
            this.lblTodaysDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTodaysDate.Location = new System.Drawing.Point(576, 0);
            this.lblTodaysDate.Name = "lblTodaysDate";
            this.lblTodaysDate.Size = new System.Drawing.Size(24, 13);
            this.lblTodaysDate.TabIndex = 0;
            this.lblTodaysDate.Text = "test";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
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
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.panelRegistry.ResumeLayout(false);
            this.panelRegistry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRegistry)).EndInit();
            this.panelDevices.ResumeLayout(false);
            this.panelDevices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDevice)).EndInit();
            this.panelClients.ResumeLayout(false);
            this.panelClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClient)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelPrzeglad.ResumeLayout(false);
            this.panelPrzeglad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrzeglad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem użytkownikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wylogujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmieńHasłoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zakończToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbClient;
        private System.Windows.Forms.Panel panelClients;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Panel panelDevices;
        private System.Windows.Forms.PictureBox pbDevice;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel panelRegistry;
        private System.Windows.Forms.PictureBox pbRegistry;
        private System.Windows.Forms.Label lblRegistry;
        private System.Windows.Forms.Panel panelPrzeglad;
        private System.Windows.Forms.PictureBox pbPrzeglad;
        private System.Windows.Forms.Label lblPrzeglad;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem narzędziaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.Label lblLogged;
        private System.Windows.Forms.Label lblTodaysDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}