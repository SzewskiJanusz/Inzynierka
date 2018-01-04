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
            this.linklblEdit = new System.Windows.Forms.LinkLabel();
            this.linklblFind = new System.Windows.Forms.LinkLabel();
            this.linklblAdd = new System.Windows.Forms.LinkLabel();
            this.lbl = new System.Windows.Forms.Label();
            this.dgvPlaces = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(396, 60);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(128, 24);
            this.btnFind.TabIndex = 21;
            this.btnFind.Text = "Znajdź następny";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            // 
            // tbxFind
            // 
            this.tbxFind.Location = new System.Drawing.Point(215, 60);
            this.tbxFind.Name = "tbxFind";
            this.tbxFind.Size = new System.Drawing.Size(175, 20);
            this.tbxFind.TabIndex = 20;
            this.tbxFind.Visible = false;
            // 
            // linklblEdit
            // 
            this.linklblEdit.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblEdit.AutoSize = true;
            this.linklblEdit.LinkColor = System.Drawing.Color.Black;
            this.linklblEdit.Location = new System.Drawing.Point(71, 60);
            this.linklblEdit.Name = "linklblEdit";
            this.linklblEdit.Size = new System.Drawing.Size(43, 13);
            this.linklblEdit.TabIndex = 19;
            this.linklblEdit.TabStop = true;
            this.linklblEdit.Text = "Popraw";
            this.linklblEdit.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // linklblFind
            // 
            this.linklblFind.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblFind.AutoSize = true;
            this.linklblFind.LinkColor = System.Drawing.Color.Black;
            this.linklblFind.Location = new System.Drawing.Point(137, 60);
            this.linklblFind.Name = "linklblFind";
            this.linklblFind.Size = new System.Drawing.Size(53, 13);
            this.linklblFind.TabIndex = 18;
            this.linklblFind.TabStop = true;
            this.linklblFind.Text = "Wyszukaj";
            this.linklblFind.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // linklblAdd
            // 
            this.linklblAdd.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblAdd.AutoSize = true;
            this.linklblAdd.LinkColor = System.Drawing.Color.Black;
            this.linklblAdd.Location = new System.Drawing.Point(12, 60);
            this.linklblAdd.Name = "linklblAdd";
            this.linklblAdd.Size = new System.Drawing.Size(35, 13);
            this.linklblAdd.TabIndex = 17;
            this.linklblAdd.TabStop = true;
            this.linklblAdd.Text = "Dodaj";
            this.linklblAdd.VisitedLinkColor = System.Drawing.Color.Black;
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
            this.dgvPlaces.Location = new System.Drawing.Point(3, 86);
            this.dgvPlaces.MultiSelect = false;
            this.dgvPlaces.Name = "dgvPlaces";
            this.dgvPlaces.ReadOnly = true;
            this.dgvPlaces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlaces.Size = new System.Drawing.Size(522, 416);
            this.dgvPlaces.TabIndex = 15;
            // 
            // ShowPlaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbxFind);
            this.Controls.Add(this.linklblEdit);
            this.Controls.Add(this.linklblFind);
            this.Controls.Add(this.linklblAdd);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgvPlaces);
            this.Name = "ShowPlaces";
            this.Size = new System.Drawing.Size(525, 505);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbxFind;
        private System.Windows.Forms.LinkLabel linklblEdit;
        private System.Windows.Forms.LinkLabel linklblFind;
        private System.Windows.Forms.LinkLabel linklblAdd;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.DataGridView dgvPlaces;
    }
}
