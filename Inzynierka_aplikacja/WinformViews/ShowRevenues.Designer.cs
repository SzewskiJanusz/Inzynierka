﻿namespace Inzynierka_aplikacja.WinformViews
{
    partial class ShowRevenues
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
            this.dgvRevenues = new System.Windows.Forms.DataGridView();
            this.lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenues)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRevenues
            // 
            this.dgvRevenues.AllowUserToAddRows = false;
            this.dgvRevenues.AllowUserToDeleteRows = false;
            this.dgvRevenues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRevenues.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRevenues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRevenues.Location = new System.Drawing.Point(3, 71);
            this.dgvRevenues.MultiSelect = false;
            this.dgvRevenues.Name = "dgvRevenues";
            this.dgvRevenues.ReadOnly = true;
            this.dgvRevenues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRevenues.Size = new System.Drawing.Size(463, 261);
            this.dgvRevenues.TabIndex = 4;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl.Location = new System.Drawing.Point(3, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(240, 31);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "Urzędy skarbowe";
            // 
            // ShowRevenues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgvRevenues);
            this.Name = "ShowRevenues";
            this.Size = new System.Drawing.Size(471, 335);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvRevenues;
        private System.Windows.Forms.Label lbl;
    }
}
