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
            this.btnShowDevices = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.dgvClient = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowDevices
            // 
            this.btnShowDevices.Location = new System.Drawing.Point(0, 53);
            this.btnShowDevices.Name = "btnShowDevices";
            this.btnShowDevices.Size = new System.Drawing.Size(118, 23);
            this.btnShowDevices.TabIndex = 1;
            this.btnShowDevices.Text = "Pokaż urządzenia";
            this.btnShowDevices.UseVisualStyleBackColor = true;
            this.btnShowDevices.Click += new System.EventHandler(this.btnShowDevices_Click);
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
            this.dgvClient.Size = new System.Drawing.Size(390, 248);
            this.dgvClient.TabIndex = 3;
            this.dgvClient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClient_CellClick);
            // 
            // ShowClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvClient);
            this.Controls.Add(this.btnShowDevices);
            this.Controls.Add(this.lbl);
            this.Name = "ShowClients";
            this.Size = new System.Drawing.Size(396, 333);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnShowDevices;
        private System.Windows.Forms.Label lbl;
        public System.Windows.Forms.DataGridView dgvClient;
    }
}
