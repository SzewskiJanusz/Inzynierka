namespace Inzynierka_aplikacja.WinformViews
{
    partial class ShowRegistryService
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
            this.label1 = new System.Windows.Forms.Label();
            this.linklblShowAll = new System.Windows.Forms.LinkLabel();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbxFind = new System.Windows.Forms.TextBox();
            this.linklblFind = new System.Windows.Forms.LinkLabel();
            this.linklblShow = new System.Windows.Forms.LinkLabel();
            this.dgvRegistry = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistry)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wykonane usługi";
            // 
            // linklblShowAll
            // 
            this.linklblShowAll.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblShowAll.AutoSize = true;
            this.linklblShowAll.LinkColor = System.Drawing.Color.Black;
            this.linklblShowAll.Location = new System.Drawing.Point(468, 66);
            this.linklblShowAll.Name = "linklblShowAll";
            this.linklblShowAll.Size = new System.Drawing.Size(95, 13);
            this.linklblShowAll.TabIndex = 18;
            this.linklblShowAll.TabStop = true;
            this.linklblShowAll.Text = "Wyświetl wszystko";
            this.linklblShowAll.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblShowAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowAll_LinkClicked);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(471, 24);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(128, 24);
            this.btnFind.TabIndex = 17;
            this.btnFind.Text = "Znajdź następny";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            // 
            // tbxFind
            // 
            this.tbxFind.Location = new System.Drawing.Point(290, 24);
            this.tbxFind.Name = "tbxFind";
            this.tbxFind.Size = new System.Drawing.Size(175, 20);
            this.tbxFind.TabIndex = 16;
            this.tbxFind.Visible = false;
            // 
            // linklblFind
            // 
            this.linklblFind.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblFind.AutoSize = true;
            this.linklblFind.LinkColor = System.Drawing.Color.Black;
            this.linklblFind.Location = new System.Drawing.Point(386, 66);
            this.linklblFind.Name = "linklblFind";
            this.linklblFind.Size = new System.Drawing.Size(53, 13);
            this.linklblFind.TabIndex = 15;
            this.linklblFind.TabStop = true;
            this.linklblFind.Text = "Wyszukaj";
            this.linklblFind.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // linklblShow
            // 
            this.linklblShow.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblShow.AutoSize = true;
            this.linklblShow.LinkColor = System.Drawing.Color.Black;
            this.linklblShow.Location = new System.Drawing.Point(8, 66);
            this.linklblShow.Name = "linklblShow";
            this.linklblShow.Size = new System.Drawing.Size(100, 13);
            this.linklblShow.TabIndex = 14;
            this.linklblShow.TabStop = true;
            this.linklblShow.Text = "Wyświetl szczegóły";
            this.linklblShow.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblShow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShow_LinkClicked);
            // 
            // dgvRegistry
            // 
            this.dgvRegistry.AllowUserToAddRows = false;
            this.dgvRegistry.AllowUserToDeleteRows = false;
            this.dgvRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegistry.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRegistry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistry.Location = new System.Drawing.Point(3, 97);
            this.dgvRegistry.MultiSelect = false;
            this.dgvRegistry.Name = "dgvRegistry";
            this.dgvRegistry.ReadOnly = true;
            this.dgvRegistry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistry.Size = new System.Drawing.Size(595, 260);
            this.dgvRegistry.TabIndex = 19;
            this.dgvRegistry.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistry_CellClick);
            this.dgvRegistry.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRegistry_DataBindingComplete);
            // 
            // ShowRegistryService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvRegistry);
            this.Controls.Add(this.linklblShowAll);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbxFind);
            this.Controls.Add(this.linklblFind);
            this.Controls.Add(this.linklblShow);
            this.Controls.Add(this.label1);
            this.Name = "ShowRegistryService";
            this.Size = new System.Drawing.Size(601, 360);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linklblShowAll;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbxFind;
        private System.Windows.Forms.LinkLabel linklblFind;
        private System.Windows.Forms.LinkLabel linklblShow;
        private System.Windows.Forms.DataGridView dgvRegistry;
    }
}
