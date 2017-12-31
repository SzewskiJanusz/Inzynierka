namespace Inzynierka_aplikacja.WinformViews.CRUD.Services
{
    partial class AddService
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
            this.gbBasics = new System.Windows.Forms.GroupBox();
            this.cbxDevice = new System.Windows.Forms.ComboBox();
            this.cboxService = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbxClient = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorPrv = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.gbBasics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorPrv)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBasics
            // 
            this.gbBasics.Controls.Add(this.cbxDevice);
            this.gbBasics.Controls.Add(this.cboxService);
            this.gbBasics.Controls.Add(this.dtpDate);
            this.gbBasics.Controls.Add(this.cbxClient);
            this.gbBasics.Controls.Add(this.label6);
            this.gbBasics.Controls.Add(this.label4);
            this.gbBasics.Controls.Add(this.label3);
            this.gbBasics.Controls.Add(this.label2);
            this.gbBasics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbBasics.Location = new System.Drawing.Point(9, 60);
            this.gbBasics.Name = "gbBasics";
            this.gbBasics.Size = new System.Drawing.Size(500, 215);
            this.gbBasics.TabIndex = 30;
            this.gbBasics.TabStop = false;
            this.gbBasics.Text = "Dane usługi";
            // 
            // cbxDevice
            // 
            this.cbxDevice.FormattingEnabled = true;
            this.cbxDevice.Location = new System.Drawing.Point(193, 123);
            this.cbxDevice.Name = "cbxDevice";
            this.cbxDevice.Size = new System.Drawing.Size(295, 24);
            this.cbxDevice.TabIndex = 27;
            // 
            // cboxService
            // 
            this.cboxService.FormattingEnabled = true;
            this.cboxService.Location = new System.Drawing.Point(193, 35);
            this.cboxService.Name = "cboxService";
            this.cboxService.Size = new System.Drawing.Size(295, 24);
            this.cboxService.TabIndex = 26;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(193, 169);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(295, 23);
            this.dtpDate.TabIndex = 14;
            // 
            // cbxClient
            // 
            this.cbxClient.FormattingEnabled = true;
            this.cbxClient.Location = new System.Drawing.Point(193, 79);
            this.cbxClient.Name = "cbxClient";
            this.cbxClient.Size = new System.Drawing.Size(295, 24);
            this.cbxClient.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(6, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "Data wykonania";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(6, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Wybierz urządzenie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Wybierz kontrahenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wybierz usługę";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 31);
            this.label1.TabIndex = 29;
            this.label1.Text = "Zaplanuj usługę";
            // 
            // errorPrv
            // 
            this.errorPrv.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 312);
            this.Controls.Add(this.gbBasics);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "AddService";
            this.Text = "Form1";
            this.gbBasics.ResumeLayout(false);
            this.gbBasics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorPrv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBasics;
        private System.Windows.Forms.ComboBox cbxDevice;
        private System.Windows.Forms.ComboBox cboxService;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cbxClient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorPrv;
        private System.Windows.Forms.Button button1;
    }
}