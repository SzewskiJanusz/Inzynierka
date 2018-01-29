namespace Inzynierka_aplikacja.WinformViews
{
    partial class ShowPlaces
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFind = new System.Windows.Forms.Button();
            this.tbxFind = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.dgvPlaces = new System.Windows.Forms.DataGridView();
            this.linklblShowClientDevices = new System.Windows.Forms.LinkLabel();
            this.linklblFind = new System.Windows.Forms.LinkLabel();
            this.lblClient = new System.Windows.Forms.Label();
            this.linkAddDevice = new System.Windows.Forms.LinkLabel();
            this.linkEditDevice = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(579, 94);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(100, 24);
            this.btnFind.TabIndex = 21;
            this.btnFind.Text = "Znajdź następny";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tbxFind
            // 
            this.tbxFind.Location = new System.Drawing.Point(398, 94);
            this.tbxFind.Name = "tbxFind";
            this.tbxFind.Size = new System.Drawing.Size(175, 20);
            this.tbxFind.TabIndex = 20;
            this.tbxFind.Visible = false;
            this.tbxFind.TextChanged += new System.EventHandler(this.tbxFind_TextChanged);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl.Location = new System.Drawing.Point(3, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(416, 31);
            this.lbl.TabIndex = 16;
            this.lbl.Text = "Miejsca instalacji kontrahenta: ";
            // 
            // dgvPlaces
            // 
            this.dgvPlaces.AllowUserToAddRows = false;
            this.dgvPlaces.AllowUserToDeleteRows = false;
            this.dgvPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlaces.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPlaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaces.Location = new System.Drawing.Point(3, 123);
            this.dgvPlaces.MultiSelect = false;
            this.dgvPlaces.Name = "dgvPlaces";
            this.dgvPlaces.ReadOnly = true;
            this.dgvPlaces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlaces.Size = new System.Drawing.Size(679, 379);
            this.dgvPlaces.TabIndex = 15;
            this.dgvPlaces.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlaces_CellClick);
            this.dgvPlaces.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPlaces_DataBindingComplete);
            // 
            // linklblShowClientDevices
            // 
            this.linklblShowClientDevices.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblShowClientDevices.AutoSize = true;
            this.linklblShowClientDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linklblShowClientDevices.LinkColor = System.Drawing.Color.Black;
            this.linklblShowClientDevices.Location = new System.Drawing.Point(6, 93);
            this.linklblShowClientDevices.Name = "linklblShowClientDevices";
            this.linklblShowClientDevices.Size = new System.Drawing.Size(121, 17);
            this.linklblShowClientDevices.TabIndex = 22;
            this.linklblShowClientDevices.TabStop = true;
            this.linklblShowClientDevices.Text = "Pokaż urządzenia";
            this.linklblShowClientDevices.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblShowClientDevices.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowClientDevices_LinkClicked);
            // 
            // linklblFind
            // 
            this.linklblFind.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblFind.AutoSize = true;
            this.linklblFind.LinkColor = System.Drawing.Color.Black;
            this.linklblFind.Location = new System.Drawing.Point(320, 97);
            this.linklblFind.Name = "linklblFind";
            this.linklblFind.Size = new System.Drawing.Size(53, 13);
            this.linklblFind.TabIndex = 18;
            this.linklblFind.TabStop = true;
            this.linklblFind.Text = "Wyszukaj";
            this.linklblFind.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblFind.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblFind_LinkClicked);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblClient.Location = new System.Drawing.Point(3, 40);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(59, 31);
            this.lblClient.TabIndex = 23;
            this.lblClient.Text = "test";
            // 
            // linkAddDevice
            // 
            this.linkAddDevice.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkAddDevice.AutoSize = true;
            this.linkAddDevice.LinkColor = System.Drawing.Color.Black;
            this.linkAddDevice.Location = new System.Drawing.Point(223, 97);
            this.linkAddDevice.Name = "linkAddDevice";
            this.linkAddDevice.Size = new System.Drawing.Size(64, 13);
            this.linkAddDevice.TabIndex = 24;
            this.linkAddDevice.TabStop = true;
            this.linkAddDevice.Text = "Dodaj nowe";
            this.linkAddDevice.Visible = false;
            this.linkAddDevice.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkAddDevice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddDevice_LinkClicked);
            // 
            // linkEditDevice
            // 
            this.linkEditDevice.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkEditDevice.AutoSize = true;
            this.linkEditDevice.LinkColor = System.Drawing.Color.Black;
            this.linkEditDevice.Location = new System.Drawing.Point(152, 97);
            this.linkEditDevice.Name = "linkEditDevice";
            this.linkEditDevice.Size = new System.Drawing.Size(36, 13);
            this.linkEditDevice.TabIndex = 25;
            this.linkEditDevice.TabStop = true;
            this.linkEditDevice.Text = "Edytuj";
            this.linkEditDevice.Visible = false;
            this.linkEditDevice.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkEditDevice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditDevice_LinkClicked);
            // 
            // ShowPlaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkEditDevice);
            this.Controls.Add(this.linkAddDevice);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.linklblShowClientDevices);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbxFind);
            this.Controls.Add(this.linklblFind);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgvPlaces);
            this.Name = "ShowPlaces";
            this.Size = new System.Drawing.Size(682, 505);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbxFind;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.DataGridView dgvPlaces;
        private System.Windows.Forms.LinkLabel linklblShowClientDevices;
        private System.Windows.Forms.LinkLabel linklblFind;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.LinkLabel linkAddDevice;
        private System.Windows.Forms.LinkLabel linkEditDevice;
    }
}
