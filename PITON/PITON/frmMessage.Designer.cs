namespace PITON
{
    partial class frmMessage
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
            this.MsgLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MsgLabel
            // 
            this.MsgLabel.AutoSize = true;
            this.MsgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MsgLabel.ForeColor = System.Drawing.Color.Maroon;
            this.MsgLabel.Location = new System.Drawing.Point(59, 19);
            this.MsgLabel.Name = "MsgLabel";
            this.MsgLabel.Size = new System.Drawing.Size(324, 29);
            this.MsgLabel.TabIndex = 0;
            this.MsgLabel.Text = "Ждите создания таблицы !";
            this.MsgLabel.UseWaitCursor = true;
            // 
            // frmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(446, 70);
            this.Controls.Add(this.MsgLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMessage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MsgLabel;
    }
}