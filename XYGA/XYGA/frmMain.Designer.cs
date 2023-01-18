namespace XYGA
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chbModeli = new System.Windows.Forms.CheckBox();
            this.chkGlass = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Begin = new System.Windows.Forms.Label();
            this.lbl_End = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chbUnloadPhoto = new System.Windows.Forms.CheckBox();
            this.chbLoadPhoto = new System.Windows.Forms.CheckBox();
            this.cbShutdown = new System.Windows.Forms.CheckBox();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioLast = new System.Windows.Forms.RadioButton();
            this.radioSave = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(281, 262);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 22);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(281, 291);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 22);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XYGA.Properties.Resources.XYG;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(404, 118);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // chbModeli
            // 
            this.chbModeli.AutoSize = true;
            this.chbModeli.Location = new System.Drawing.Point(34, 133);
            this.chbModeli.Name = "chbModeli";
            this.chbModeli.Size = new System.Drawing.Size(110, 17);
            this.chbModeli.TabIndex = 4;
            this.chbModeli.Text = "выбрать модели";
            this.chbModeli.UseVisualStyleBackColor = true;
            // 
            // chkGlass
            // 
            this.chkGlass.AutoSize = true;
            this.chkGlass.Location = new System.Drawing.Point(34, 239);
            this.chkGlass.Name = "chkGlass";
            this.chkGlass.Size = new System.Drawing.Size(107, 17);
            this.chkGlass.TabIndex = 5;
            this.chkGlass.Text = "выбрать стёкла";
            this.chkGlass.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "начало в";
            // 
            // lbl_Begin
            // 
            this.lbl_Begin.AutoSize = true;
            this.lbl_Begin.Location = new System.Drawing.Point(345, 147);
            this.lbl_Begin.Name = "lbl_Begin";
            this.lbl_Begin.Size = new System.Drawing.Size(16, 13);
            this.lbl_Begin.TabIndex = 9;
            this.lbl_Begin.Text = "...";
            // 
            // lbl_End
            // 
            this.lbl_End.AutoSize = true;
            this.lbl_End.Location = new System.Drawing.Point(345, 165);
            this.lbl_End.Name = "lbl_End";
            this.lbl_End.Size = new System.Drawing.Size(16, 13);
            this.lbl_End.TabIndex = 10;
            this.lbl_End.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "окончено в";
            // 
            // chbUnloadPhoto
            // 
            this.chbUnloadPhoto.AutoSize = true;
            this.chbUnloadPhoto.Location = new System.Drawing.Point(34, 262);
            this.chbUnloadPhoto.Name = "chbUnloadPhoto";
            this.chbUnloadPhoto.Size = new System.Drawing.Size(210, 17);
            this.chbUnloadPhoto.TabIndex = 12;
            this.chbUnloadPhoto.Text = "выгрузить фото из AUTOTRADE.SU";
            this.chbUnloadPhoto.UseVisualStyleBackColor = true;
            // 
            // chbLoadPhoto
            // 
            this.chbLoadPhoto.AutoSize = true;
            this.chbLoadPhoto.Location = new System.Drawing.Point(34, 286);
            this.chbLoadPhoto.Name = "chbLoadPhoto";
            this.chbLoadPhoto.Size = new System.Drawing.Size(146, 17);
            this.chbLoadPhoto.TabIndex = 13;
            this.chbLoadPhoto.Text = "загрузить фото в XYGA";
            this.chbLoadPhoto.UseVisualStyleBackColor = true;
            // 
            // cbShutdown
            // 
            this.cbShutdown.AutoSize = true;
            this.cbShutdown.Location = new System.Drawing.Point(34, 309);
            this.cbShutdown.Name = "cbShutdown";
            this.cbShutdown.Size = new System.Drawing.Size(142, 17);
            this.cbShutdown.TabIndex = 15;
            this.cbShutdown.Text = "выключить компьютер";
            this.cbShutdown.UseVisualStyleBackColor = true;
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Location = new System.Drawing.Point(50, 157);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(124, 17);
            this.radioAll.TabIndex = 16;
            this.radioAll.Text = "удалить все стёкла";
            this.radioAll.UseVisualStyleBackColor = true;
            // 
            // radioLast
            // 
            this.radioLast.AutoSize = true;
            this.radioLast.Location = new System.Drawing.Point(50, 180);
            this.radioLast.Name = "radioLast";
            this.radioLast.Size = new System.Drawing.Size(132, 17);
            this.radioLast.TabIndex = 17;
            this.radioLast.Text = "продолжить выборку";
            this.radioLast.UseVisualStyleBackColor = true;
            // 
            // radioSave
            // 
            this.radioSave.AutoSize = true;
            this.radioSave.Checked = true;
            this.radioSave.Location = new System.Drawing.Point(50, 204);
            this.radioSave.Name = "radioSave";
            this.radioSave.Size = new System.Drawing.Size(115, 17);
            this.radioSave.TabIndex = 18;
            this.radioSave.TabStop = true;
            this.radioSave.Text = "сохранить стёкла";
            this.radioSave.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 348);
            this.Controls.Add(this.radioSave);
            this.Controls.Add(this.radioLast);
            this.Controls.Add(this.radioAll);
            this.Controls.Add(this.cbShutdown);
            this.Controls.Add(this.chbLoadPhoto);
            this.Controls.Add(this.chbUnloadPhoto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_End);
            this.Controls.Add(this.lbl_Begin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkGlass);
            this.Controls.Add(this.chbModeli);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStart);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Импорт данных из AUROTRADE.SU";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chbModeli;
        public System.Windows.Forms.CheckBox chkGlass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Begin;
        private System.Windows.Forms.Label lbl_End;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbUnloadPhoto;
        private System.Windows.Forms.CheckBox chbLoadPhoto;
        private System.Windows.Forms.CheckBox cbShutdown;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioLast;
        private System.Windows.Forms.RadioButton radioSave;
    }
}

