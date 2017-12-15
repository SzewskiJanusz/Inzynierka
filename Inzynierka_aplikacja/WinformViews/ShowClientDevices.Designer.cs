namespace Inzynierka_aplikacja.WinformViews
{
    partial class ShowClientDevices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvClientDev = new System.Windows.Forms.DataGridView();
            this.lbl = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientDev)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientDev
            // 
            this.dgvClientDev.AllowUserToAddRows = false;
            this.dgvClientDev.AllowUserToDeleteRows = false;
            this.dgvClientDev.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientDev.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvClientDev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientDev.Location = new System.Drawing.Point(3, 77);
            this.dgvClientDev.Name = "dgvClientDev";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientDev.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientDev.Size = new System.Drawing.Size(394, 254);
            this.dgvClientDev.TabIndex = 3;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl.Location = new System.Drawing.Point(-3, -2);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(406, 31);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "Urządzenia fiskalne podatnika";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUsername.Location = new System.Drawing.Point(148, 29);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 31);
            this.lblUsername.TabIndex = 6;
            // 
            // ShowClientDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.dgvClientDev);
            this.Controls.Add(this.lbl);
            this.Name = "ShowClientDevices";
            this.Size = new System.Drawing.Size(397, 331);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientDev)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientDev;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblUsername;
    }
}
