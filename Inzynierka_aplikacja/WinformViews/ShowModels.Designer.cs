namespace Inzynierka_aplikacja.WinformViews
{
    partial class ShowModels
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
            this.linklblEdit = new System.Windows.Forms.LinkLabel();
            this.linklblFind = new System.Windows.Forms.LinkLabel();
            this.linklblAdd = new System.Windows.Forms.LinkLabel();
            this.dgvModels = new System.Windows.Forms.DataGridView();
            this.lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(463, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(128, 24);
            this.btnFind.TabIndex = 17;
            this.btnFind.Text = "Znajdź następny";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            // 
            // tbxFind
            // 
            this.tbxFind.Location = new System.Drawing.Point(282, 21);
            this.tbxFind.Name = "tbxFind";
            this.tbxFind.Size = new System.Drawing.Size(175, 20);
            this.tbxFind.TabIndex = 16;
            this.tbxFind.Visible = false;
            // 
            // linklblEdit
            // 
            this.linklblEdit.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblEdit.AutoSize = true;
            this.linklblEdit.LinkColor = System.Drawing.Color.Black;
            this.linklblEdit.Location = new System.Drawing.Point(424, 60);
            this.linklblEdit.Name = "linklblEdit";
            this.linklblEdit.Size = new System.Drawing.Size(43, 13);
            this.linklblEdit.TabIndex = 15;
            this.linklblEdit.TabStop = true;
            this.linklblEdit.Text = "Popraw";
            this.linklblEdit.Visible = false;
            this.linklblEdit.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblEdit_LinkClicked);
            // 
            // linklblFind
            // 
            this.linklblFind.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblFind.AutoSize = true;
            this.linklblFind.LinkColor = System.Drawing.Color.Black;
            this.linklblFind.Location = new System.Drawing.Point(490, 60);
            this.linklblFind.Name = "linklblFind";
            this.linklblFind.Size = new System.Drawing.Size(53, 13);
            this.linklblFind.TabIndex = 14;
            this.linklblFind.TabStop = true;
            this.linklblFind.Text = "Wyszukaj";
            this.linklblFind.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // linklblAdd
            // 
            this.linklblAdd.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblAdd.AutoSize = true;
            this.linklblAdd.LinkColor = System.Drawing.Color.Black;
            this.linklblAdd.Location = new System.Drawing.Point(365, 60);
            this.linklblAdd.Name = "linklblAdd";
            this.linklblAdd.Size = new System.Drawing.Size(35, 13);
            this.linklblAdd.TabIndex = 13;
            this.linklblAdd.TabStop = true;
            this.linklblAdd.Text = "Dodaj";
            this.linklblAdd.Visible = false;
            this.linklblAdd.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblAdd_LinkClicked);
            // 
            // dgvModels
            // 
            this.dgvModels.AllowUserToAddRows = false;
            this.dgvModels.AllowUserToDeleteRows = false;
            this.dgvModels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvModels.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModels.Location = new System.Drawing.Point(3, 92);
            this.dgvModels.MultiSelect = false;
            this.dgvModels.Name = "dgvModels";
            this.dgvModels.ReadOnly = true;
            this.dgvModels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModels.Size = new System.Drawing.Size(588, 293);
            this.dgvModels.TabIndex = 12;
            this.dgvModels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModels_CellClick);
            this.dgvModels.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvModels_DataBindingComplete);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl.Location = new System.Drawing.Point(3, 10);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(236, 31);
            this.lbl.TabIndex = 11;
            this.lbl.Text = "Modele urządzeń";
            // 
            // ShowModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbxFind);
            this.Controls.Add(this.linklblEdit);
            this.Controls.Add(this.linklblFind);
            this.Controls.Add(this.linklblAdd);
            this.Controls.Add(this.dgvModels);
            this.Controls.Add(this.lbl);
            this.Name = "ShowModels";
            this.Size = new System.Drawing.Size(594, 385);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbxFind;
        private System.Windows.Forms.LinkLabel linklblEdit;
        private System.Windows.Forms.LinkLabel linklblFind;
        private System.Windows.Forms.LinkLabel linklblAdd;
        public System.Windows.Forms.DataGridView dgvModels;
        private System.Windows.Forms.Label lbl;
    }
}
