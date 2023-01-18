namespace PITON
{
    partial class frmAnalog
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
            this.lstMarka = new System.Windows.Forms.ListBox();
            this.lstModel = new System.Windows.Forms.ListBox();
            this.btnAnalog = new System.Windows.Forms.Button();
            this.btnNoanalog = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPodbor = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Option = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMarka
            // 
            this.lstMarka.BackColor = System.Drawing.SystemColors.Window;
            this.lstMarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstMarka.ForeColor = System.Drawing.Color.Black;
            this.lstMarka.FormattingEnabled = true;
            this.lstMarka.ItemHeight = 16;
            this.lstMarka.Location = new System.Drawing.Point(10, 40);
            this.lstMarka.Name = "lstMarka";
            this.lstMarka.Size = new System.Drawing.Size(161, 404);
            this.lstMarka.TabIndex = 0;
            // 
            // lstModel
            // 
            this.lstModel.BackColor = System.Drawing.SystemColors.Window;
            this.lstModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstModel.ForeColor = System.Drawing.Color.Black;
            this.lstModel.FormattingEnabled = true;
            this.lstModel.ItemHeight = 16;
            this.lstModel.Location = new System.Drawing.Point(188, 40);
            this.lstModel.Name = "lstModel";
            this.lstModel.Size = new System.Drawing.Size(429, 404);
            this.lstModel.TabIndex = 1;
            // 
            // btnAnalog
            // 
            this.btnAnalog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAnalog.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAnalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAnalog.ForeColor = System.Drawing.Color.Black;
            this.btnAnalog.Location = new System.Drawing.Point(636, 164);
            this.btnAnalog.Name = "btnAnalog";
            this.btnAnalog.Size = new System.Drawing.Size(96, 40);
            this.btnAnalog.TabIndex = 2;
            this.btnAnalog.Text = "Аналог этой машины";
            this.btnAnalog.UseVisualStyleBackColor = false;
            this.btnAnalog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAnalog_MouseUp);
            // 
            // btnNoanalog
            // 
            this.btnNoanalog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNoanalog.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNoanalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNoanalog.ForeColor = System.Drawing.Color.Black;
            this.btnNoanalog.Location = new System.Drawing.Point(1, 46);
            this.btnNoanalog.Name = "btnNoanalog";
            this.btnNoanalog.Size = new System.Drawing.Size(96, 23);
            this.btnNoanalog.TabIndex = 3;
            this.btnNoanalog.Text = "Не аналог";
            this.btnNoanalog.UseVisualStyleBackColor = false;
            this.btnNoanalog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnNoanalog_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(637, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // lblPodbor
            // 
            this.lblPodbor.AutoSize = true;
            this.lblPodbor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPodbor.Location = new System.Drawing.Point(153, 5);
            this.lblPodbor.Name = "lblPodbor";
            this.lblPodbor.Size = new System.Drawing.Size(331, 24);
            this.lblPodbor.TabIndex = 9;
            this.lblPodbor.Text = "Форма подбора аналога автомоиля";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Option);
            this.groupBox1.Controls.Add(this.btnNoanalog);
            this.groupBox1.Location = new System.Drawing.Point(636, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 75);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // Option
            // 
            this.Option.AutoSize = true;
            this.Option.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Option.Location = new System.Drawing.Point(13, 10);
            this.Option.Name = "Option";
            this.Option.Size = new System.Drawing.Size(71, 31);
            this.Option.TabIndex = 0;
            this.Option.Text = "Копировать";
            this.Option.UseVisualStyleBackColor = true;
            this.Option.CheckedChanged += new System.EventHandler(this.Option_CheckedChanged);
            // 
            // frmAnalog
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 455);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPodbor);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAnalog);
            this.Controls.Add(this.lstModel);
            this.Controls.Add(this.lstMarka);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAnalog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подбор аналога";
            this.TransparencyKey = System.Drawing.SystemColors.HotTrack;
            this.Load += new System.EventHandler(this.frmAnalog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMarka;
        private System.Windows.Forms.ListBox lstModel;
        private System.Windows.Forms.Button btnAnalog;
        private System.Windows.Forms.Button btnNoanalog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblPodbor;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox Option;

    }
}