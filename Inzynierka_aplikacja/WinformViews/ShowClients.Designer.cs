﻿namespace Inzynierka_aplikacja.WinformViews
{
    partial class ShowClients
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
            this.lbl = new System.Windows.Forms.Label();
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.linklblShowClientDevices = new System.Windows.Forms.LinkLabel();
            this.linklblAdd = new System.Windows.Forms.LinkLabel();
            this.linklblFind = new System.Windows.Forms.LinkLabel();
            this.linklblEdit = new System.Windows.Forms.LinkLabel();
            this.tbxFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl.Location = new System.Drawing.Point(-6, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(170, 31);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "Kontrahenci";
            // 
            // dgvClient
            // 
            this.dgvClient.AllowUserToAddRows = false;
            this.dgvClient.AllowUserToDeleteRows = false;
            this.dgvClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClient.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClient.Location = new System.Drawing.Point(3, 82);
            this.dgvClient.MultiSelect = false;
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.ReadOnly = true;
            this.dgvClient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClient.Size = new System.Drawing.Size(531, 248);
            this.dgvClient.TabIndex = 3;
            this.dgvClient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClient_CellClick);
            this.dgvClient.Sorted += new System.EventHandler(this.tbxFind_TextChanged);
            // 
            // linklblShowClientDevices
            // 
            this.linklblShowClientDevices.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblShowClientDevices.AutoSize = true;
            this.linklblShowClientDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linklblShowClientDevices.LinkColor = System.Drawing.Color.Black;
            this.linklblShowClientDevices.Location = new System.Drawing.Point(3, 50);
            this.linklblShowClientDevices.Name = "linklblShowClientDevices";
            this.linklblShowClientDevices.Size = new System.Drawing.Size(121, 17);
            this.linklblShowClientDevices.TabIndex = 4;
            this.linklblShowClientDevices.TabStop = true;
            this.linklblShowClientDevices.Text = "Pokaż urządzenia";
            this.linklblShowClientDevices.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblShowClientDevices.Click += new System.EventHandler(this.btnShowDevices_Click);
            // 
            // linklblAdd
            // 
            this.linklblAdd.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblAdd.AutoSize = true;
            this.linklblAdd.LinkColor = System.Drawing.Color.Black;
            this.linklblAdd.Location = new System.Drawing.Point(204, 54);
            this.linklblAdd.Name = "linklblAdd";
            this.linklblAdd.Size = new System.Drawing.Size(35, 13);
            this.linklblAdd.TabIndex = 5;
            this.linklblAdd.TabStop = true;
            this.linklblAdd.Text = "Dodaj";
            this.linklblAdd.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblAdd_LinkClicked);
            // 
            // linklblFind
            // 
            this.linklblFind.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblFind.AutoSize = true;
            this.linklblFind.LinkColor = System.Drawing.Color.Black;
            this.linklblFind.Location = new System.Drawing.Point(329, 54);
            this.linklblFind.Name = "linklblFind";
            this.linklblFind.Size = new System.Drawing.Size(53, 13);
            this.linklblFind.TabIndex = 6;
            this.linklblFind.TabStop = true;
            this.linklblFind.Text = "Wyszukaj";
            this.linklblFind.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblFind.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblFind_LinkClicked);
            // 
            // linklblEdit
            // 
            this.linklblEdit.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblEdit.AutoSize = true;
            this.linklblEdit.LinkColor = System.Drawing.Color.Black;
            this.linklblEdit.Location = new System.Drawing.Point(263, 54);
            this.linklblEdit.Name = "linklblEdit";
            this.linklblEdit.Size = new System.Drawing.Size(43, 13);
            this.linklblEdit.TabIndex = 7;
            this.linklblEdit.TabStop = true;
            this.linklblEdit.Text = "Popraw";
            this.linklblEdit.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblEdit_LinkClicked);
            // 
            // tbxFind
            // 
            this.tbxFind.Location = new System.Drawing.Point(207, 12);
            this.tbxFind.Name = "tbxFind";
            this.tbxFind.Size = new System.Drawing.Size(175, 20);
            this.tbxFind.TabIndex = 8;
            this.tbxFind.Visible = false;
            this.tbxFind.TextChanged += new System.EventHandler(this.tbxFind_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(406, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(128, 24);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Znajdź następny";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ShowClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbxFind);
            this.Controls.Add(this.linklblEdit);
            this.Controls.Add(this.linklblFind);
            this.Controls.Add(this.linklblAdd);
            this.Controls.Add(this.linklblShowClientDevices);
            this.Controls.Add(this.dgvClient);
            this.Controls.Add(this.lbl);
            this.Name = "ShowClients";
            this.Size = new System.Drawing.Size(537, 333);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl;
        public System.Windows.Forms.DataGridView dgvClient;
        private System.Windows.Forms.LinkLabel linklblShowClientDevices;
        private System.Windows.Forms.LinkLabel linklblAdd;
        private System.Windows.Forms.LinkLabel linklblFind;
        private System.Windows.Forms.LinkLabel linklblEdit;
        private System.Windows.Forms.TextBox tbxFind;
        private System.Windows.Forms.Button btnFind;
    }
}
