namespace PITON
{
    partial class frmDelModel
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbMarka = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(214, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(90, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Отменить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lbMarka
            // 
            this.lbMarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMarka.Location = new System.Drawing.Point(24, 69);
            this.lbMarka.Name = "lbMarka";
            this.lbMarka.Size = new System.Drawing.Size(352, 23);
            this.lbMarka.TabIndex = 3;
            this.lbMarka.Text = "марка";
            this.lbMarka.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(74, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Удаляется модель автомобиля";
            // 
            // lbModel
            // 
            this.lbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbModel.Location = new System.Drawing.Point(25, 96);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(352, 23);
            this.lbModel.TabIndex = 5;
            this.lbModel.Text = "модель";
            this.lbModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDelModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 189);
            this.Controls.Add(this.lbModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMarka);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDelModel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbMarka;
        public System.Windows.Forms.Label lbModel;
    }
}