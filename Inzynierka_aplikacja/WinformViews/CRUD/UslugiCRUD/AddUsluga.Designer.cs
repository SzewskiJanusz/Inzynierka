namespace Inzynierka_aplikacja.WinformViews.CRUD.Uslugi
{
    partial class AddUsluga
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorPrv = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbxNazwa = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCena = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorPrv)).BeginInit();
            this.SuspendLayout();
            // 
            // errorPrv
            // 
            this.errorPrv.ContainerControl = this;
            // 
            // tbxNazwa
            // 
            this.tbxNazwa.Location = new System.Drawing.Point(170, 66);
            this.tbxNazwa.Name = "tbxNazwa";
            this.tbxNazwa.Size = new System.Drawing.Size(318, 20);
            this.tbxNazwa.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(12, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 24);
            this.label12.TabIndex = 17;
            this.label12.Text = "Nazwa";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(170, 146);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 28);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dodaj usługę";
            // 
            // tbxCena
            // 
            this.tbxCena.Location = new System.Drawing.Point(170, 104);
            this.tbxCena.Name = "tbxCena";
            this.tbxCena.Size = new System.Drawing.Size(318, 20);
            this.tbxCena.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cena";
            // 
            // AddUsluga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 183);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCena);
            this.Controls.Add(this.tbxNazwa);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Name = "AddUsluga";
            this.Text = "Dodaj usługę";
            ((System.ComponentModel.ISupportInitialize)(this.errorPrv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorPrv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCena;
        private System.Windows.Forms.TextBox tbxNazwa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
    }
}