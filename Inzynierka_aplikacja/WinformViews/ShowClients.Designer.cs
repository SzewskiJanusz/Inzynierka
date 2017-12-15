namespace Inzynierka_aplikacja.WinformViews
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
            this.components = new System.ComponentModel.Container();
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.btnShowDevices = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.imieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazwiskoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wojewodztwoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miastoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ulicaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kodpocztowyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsClient = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClient)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClient
            // 
            this.dgvClient.AllowUserToOrderColumns = true;
            this.dgvClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClient.AutoGenerateColumns = false;
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imieDataGridViewTextBoxColumn,
            this.nazwiskoDataGridViewTextBoxColumn,
            this.nipDataGridViewTextBoxColumn,
            this.wojewodztwoDataGridViewTextBoxColumn,
            this.miastoDataGridViewTextBoxColumn,
            this.ulicaDataGridViewTextBoxColumn,
            this.kodpocztowyDataGridViewTextBoxColumn,
            this.telefonDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dgvClient.DataSource = this.bsClient;
            this.dgvClient.Location = new System.Drawing.Point(0, 82);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.Size = new System.Drawing.Size(397, 251);
            this.dgvClient.TabIndex = 0;
            this.dgvClient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClient_CellClick);
            // 
            // btnShowDevices
            // 
            this.btnShowDevices.Location = new System.Drawing.Point(0, 53);
            this.btnShowDevices.Name = "btnShowDevices";
            this.btnShowDevices.Size = new System.Drawing.Size(118, 23);
            this.btnShowDevices.TabIndex = 1;
            this.btnShowDevices.Text = "Pokaż urządzenia";
            this.btnShowDevices.UseVisualStyleBackColor = true;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl.Location = new System.Drawing.Point(-6, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(143, 31);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "Podatnicy";
            // 
            // imieDataGridViewTextBoxColumn
            // 
            this.imieDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.imieDataGridViewTextBoxColumn.DataPropertyName = "imie";
            this.imieDataGridViewTextBoxColumn.HeaderText = "Imię";
            this.imieDataGridViewTextBoxColumn.Name = "imieDataGridViewTextBoxColumn";
            this.imieDataGridViewTextBoxColumn.Width = 51;
            // 
            // nazwiskoDataGridViewTextBoxColumn
            // 
            this.nazwiskoDataGridViewTextBoxColumn.DataPropertyName = "nazwisko";
            this.nazwiskoDataGridViewTextBoxColumn.HeaderText = "Nazwisko";
            this.nazwiskoDataGridViewTextBoxColumn.Name = "nazwiskoDataGridViewTextBoxColumn";
            this.nazwiskoDataGridViewTextBoxColumn.Width = 78;
            // 
            // nipDataGridViewTextBoxColumn
            // 
            this.nipDataGridViewTextBoxColumn.DataPropertyName = "nip";
            this.nipDataGridViewTextBoxColumn.HeaderText = "NIP";
            this.nipDataGridViewTextBoxColumn.Name = "nipDataGridViewTextBoxColumn";
            this.nipDataGridViewTextBoxColumn.Width = 50;
            // 
            // wojewodztwoDataGridViewTextBoxColumn
            // 
            this.wojewodztwoDataGridViewTextBoxColumn.DataPropertyName = "wojewodztwo";
            this.wojewodztwoDataGridViewTextBoxColumn.HeaderText = "Województwo";
            this.wojewodztwoDataGridViewTextBoxColumn.Name = "wojewodztwoDataGridViewTextBoxColumn";
            this.wojewodztwoDataGridViewTextBoxColumn.Width = 99;
            // 
            // miastoDataGridViewTextBoxColumn
            // 
            this.miastoDataGridViewTextBoxColumn.DataPropertyName = "miasto";
            this.miastoDataGridViewTextBoxColumn.HeaderText = "Miasto";
            this.miastoDataGridViewTextBoxColumn.Name = "miastoDataGridViewTextBoxColumn";
            this.miastoDataGridViewTextBoxColumn.Width = 63;
            // 
            // ulicaDataGridViewTextBoxColumn
            // 
            this.ulicaDataGridViewTextBoxColumn.DataPropertyName = "ulica";
            this.ulicaDataGridViewTextBoxColumn.HeaderText = "Ulica";
            this.ulicaDataGridViewTextBoxColumn.Name = "ulicaDataGridViewTextBoxColumn";
            this.ulicaDataGridViewTextBoxColumn.Width = 56;
            // 
            // kodpocztowyDataGridViewTextBoxColumn
            // 
            this.kodpocztowyDataGridViewTextBoxColumn.DataPropertyName = "kod_pocztowy";
            this.kodpocztowyDataGridViewTextBoxColumn.HeaderText = "Kod pocztowy";
            this.kodpocztowyDataGridViewTextBoxColumn.Name = "kodpocztowyDataGridViewTextBoxColumn";
            this.kodpocztowyDataGridViewTextBoxColumn.Width = 99;
            // 
            // telefonDataGridViewTextBoxColumn
            // 
            this.telefonDataGridViewTextBoxColumn.DataPropertyName = "telefon";
            this.telefonDataGridViewTextBoxColumn.HeaderText = "Telefon";
            this.telefonDataGridViewTextBoxColumn.Name = "telefonDataGridViewTextBoxColumn";
            this.telefonDataGridViewTextBoxColumn.Width = 68;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "E-mail";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 60;
            // 
            // bsClient
            // 
            this.bsClient.DataSource = typeof(Inzynierka_aplikacja.MainDB.Podatnik);
            // 
            // ShowClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnShowDevices);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgvClient);
            this.Name = "ShowClients";
            this.Size = new System.Drawing.Size(396, 333);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvClient;
        private System.Windows.Forms.BindingSource bsClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn imieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazwiskoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wojewodztwoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn miastoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ulicaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodpocztowyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnShowDevices;
        private System.Windows.Forms.Label lbl;
    }
}
