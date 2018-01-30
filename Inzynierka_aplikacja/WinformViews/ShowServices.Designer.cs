namespace Inzynierka_aplikacja.WinformViews
{
    partial class ShowServices
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
            this.linklblShow = new System.Windows.Forms.LinkLabel();
            this.linklblFind = new System.Windows.Forms.LinkLabel();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbxFind = new System.Windows.Forms.TextBox();
            this.linklblShowAll = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Najbliższe przeglądy";
            // 
            // linklblShow
            // 
            this.linklblShow.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblShow.AutoSize = true;
            this.linklblShow.LinkColor = System.Drawing.Color.Black;
            this.linklblShow.Location = new System.Drawing.Point(3, 54);
            this.linklblShow.Name = "linklblShow";
            this.linklblShow.Size = new System.Drawing.Size(100, 13);
            this.linklblShow.TabIndex = 6;
            this.linklblShow.TabStop = true;
            this.linklblShow.Text = "Wyświetl szczegóły";
            this.linklblShow.Visible = false;
            this.linklblShow.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblShow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShow_LinkClicked);
            // 
            // linklblFind
            // 
            this.linklblFind.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblFind.AutoSize = true;
            this.linklblFind.LinkColor = System.Drawing.Color.Black;
            this.linklblFind.Location = new System.Drawing.Point(379, 54);
            this.linklblFind.Name = "linklblFind";
            this.linklblFind.Size = new System.Drawing.Size(53, 13);
            this.linklblFind.TabIndex = 9;
            this.linklblFind.TabStop = true;
            this.linklblFind.Text = "Wyszukaj";
            this.linklblFind.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblFind.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblFind_LinkClicked);
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServices.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new System.Drawing.Point(6, 95);
            this.dgvServices.MultiSelect = false;
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.Size = new System.Drawing.Size(585, 262);
            this.dgvServices.TabIndex = 10;
            this.dgvServices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvService_CellClick);
            this.dgvServices.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvServices_DataBindingComplete);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(466, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(128, 24);
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "Znajdź następny";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tbxFind
            // 
            this.tbxFind.Location = new System.Drawing.Point(285, 12);
            this.tbxFind.Name = "tbxFind";
            this.tbxFind.Size = new System.Drawing.Size(175, 20);
            this.tbxFind.TabIndex = 11;
            this.tbxFind.Visible = false;
            this.tbxFind.TextChanged += new System.EventHandler(this.tbxFind_TextChanged);
            // 
            // linklblShowAll
            // 
            this.linklblShowAll.ActiveLinkColor = System.Drawing.Color.Black;
            this.linklblShowAll.AutoSize = true;
            this.linklblShowAll.LinkColor = System.Drawing.Color.Black;
            this.linklblShowAll.Location = new System.Drawing.Point(463, 54);
            this.linklblShowAll.Name = "linklblShowAll";
            this.linklblShowAll.Size = new System.Drawing.Size(129, 13);
            this.linklblShowAll.TabIndex = 13;
            this.linklblShowAll.TabStop = true;
            this.linklblShowAll.Text = "Wyświetl wszystkie usługi";
            this.linklblShowAll.VisitedLinkColor = System.Drawing.Color.Black;
            this.linklblShowAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowAll_LinkClicked);
            // 
            // ShowServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linklblShowAll);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbxFind);
            this.Controls.Add(this.dgvServices);
            this.Controls.Add(this.linklblFind);
            this.Controls.Add(this.linklblShow);
            this.Controls.Add(this.label1);
            this.Name = "ShowServices";
            this.Size = new System.Drawing.Size(594, 360);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linklblShow;
        private System.Windows.Forms.LinkLabel linklblFind;
        public System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbxFind;
        private System.Windows.Forms.LinkLabel linklblShowAll;
    }
}
