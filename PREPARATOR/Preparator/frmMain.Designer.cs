namespace Preparator
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_END = new System.Windows.Forms.Label();
            this.lbl_BEGIN = new System.Windows.Forms.Label();
            this.chbGlass = new System.Windows.Forms.CheckBox();
            this.chbUpdateData = new System.Windows.Forms.CheckBox();
            this.chbPhotos = new System.Windows.Forms.CheckBox();
            this.cbShutdown = new System.Windows.Forms.CheckBox();
            this.chbWATERMARK = new System.Windows.Forms.CheckBox();
            this.copy_MARKA = new System.Windows.Forms.CheckBox();
            this.copy_GLASS = new System.Windows.Forms.CheckBox();
            this.cb_podrobno = new System.Windows.Forms.CheckBox();
            this.chbPrepare = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(271, 244);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(92, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Выполнить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(387, 244);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "начало в :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "завершено в :";
            // 
            // lbl_END
            // 
            this.lbl_END.AutoSize = true;
            this.lbl_END.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_END.Location = new System.Drawing.Point(356, 220);
            this.lbl_END.Name = "lbl_END";
            this.lbl_END.Size = new System.Drawing.Size(19, 13);
            this.lbl_END.TabIndex = 10;
            this.lbl_END.Text = "...";
            // 
            // lbl_BEGIN
            // 
            this.lbl_BEGIN.AutoSize = true;
            this.lbl_BEGIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_BEGIN.Location = new System.Drawing.Point(356, 201);
            this.lbl_BEGIN.Name = "lbl_BEGIN";
            this.lbl_BEGIN.Size = new System.Drawing.Size(19, 13);
            this.lbl_BEGIN.TabIndex = 11;
            this.lbl_BEGIN.Text = "...";
            // 
            // chbGlass
            // 
            this.chbGlass.AutoSize = true;
            this.chbGlass.Location = new System.Drawing.Point(261, 143);
            this.chbGlass.Name = "chbGlass";
            this.chbGlass.Size = new System.Drawing.Size(139, 17);
            this.chbGlass.TabIndex = 14;
            this.chbGlass.Text = "сформировать стёкла";
            this.chbGlass.UseVisualStyleBackColor = true;
            // 
            // chbUpdateData
            // 
            this.chbUpdateData.AutoSize = true;
            this.chbUpdateData.Location = new System.Drawing.Point(261, 25);
            this.chbUpdateData.Name = "chbUpdateData";
            this.chbUpdateData.Size = new System.Drawing.Size(114, 17);
            this.chbUpdateData.TabIndex = 17;
            this.chbUpdateData.Text = "обновить данные";
            this.chbUpdateData.UseVisualStyleBackColor = true;
            // 
            // chbPhotos
            // 
            this.chbPhotos.AutoSize = true;
            this.chbPhotos.Location = new System.Drawing.Point(261, 55);
            this.chbPhotos.Name = "chbPhotos";
            this.chbPhotos.Size = new System.Drawing.Size(105, 17);
            this.chbPhotos.TabIndex = 18;
            this.chbPhotos.Text = "загрузить фото";
            this.chbPhotos.UseVisualStyleBackColor = true;
            // 
            // cbShutdown
            // 
            this.cbShutdown.AutoSize = true;
            this.cbShutdown.Location = new System.Drawing.Point(261, 175);
            this.cbShutdown.Name = "cbShutdown";
            this.cbShutdown.Size = new System.Drawing.Size(142, 17);
            this.cbShutdown.TabIndex = 19;
            this.cbShutdown.Text = "выключить компьютер";
            this.cbShutdown.UseVisualStyleBackColor = true;
            // 
            // chbWATERMARK
            // 
            this.chbWATERMARK.AutoSize = true;
            this.chbWATERMARK.Location = new System.Drawing.Point(261, 83);
            this.chbWATERMARK.Name = "chbWATERMARK";
            this.chbWATERMARK.Size = new System.Drawing.Size(147, 17);
            this.chbWATERMARK.TabIndex = 20;
            this.chbWATERMARK.Text = "нанести водяные знаки";
            this.chbWATERMARK.UseVisualStyleBackColor = true;
            // 
            // copy_MARKA
            // 
            this.copy_MARKA.AutoSize = true;
            this.copy_MARKA.Location = new System.Drawing.Point(402, 25);
            this.copy_MARKA.Name = "copy_MARKA";
            this.copy_MARKA.Size = new System.Drawing.Size(167, 17);
            this.copy_MARKA.TabIndex = 21;
            this.copy_MARKA.Text = "копировать МАРКИ на сайт";
            this.copy_MARKA.UseVisualStyleBackColor = true;
            this.copy_MARKA.Visible = false;
            // 
            // copy_GLASS
            // 
            this.copy_GLASS.AutoSize = true;
            this.copy_GLASS.Location = new System.Drawing.Point(402, 2);
            this.copy_GLASS.Name = "copy_GLASS";
            this.copy_GLASS.Size = new System.Drawing.Size(172, 17);
            this.copy_GLASS.TabIndex = 23;
            this.copy_GLASS.Text = "копировать СТЕКЛА на сайт";
            this.copy_GLASS.UseVisualStyleBackColor = true;
            this.copy_GLASS.Visible = false;
            // 
            // cb_podrobno
            // 
            this.cb_podrobno.AutoSize = true;
            this.cb_podrobno.Location = new System.Drawing.Point(406, 143);
            this.cb_podrobno.Name = "cb_podrobno";
            this.cb_podrobno.Size = new System.Drawing.Size(74, 17);
            this.cb_podrobno.TabIndex = 24;
            this.cb_podrobno.Text = "подробно";
            this.cb_podrobno.UseVisualStyleBackColor = true;
            // 
            // chbPrepare
            // 
            this.chbPrepare.AutoSize = true;
            this.chbPrepare.Location = new System.Drawing.Point(261, 114);
            this.chbPrepare.Name = "chbPrepare";
            this.chbPrepare.Size = new System.Drawing.Size(164, 17);
            this.chbPrepare.TabIndex = 25;
            this.chbPrepare.Text = "определить модели-стекла";
            this.chbPrepare.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.BackgroundImage = global::Preparator.Properties.Resources.MP;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(504, 301);
            this.Controls.Add(this.chbPrepare);
            this.Controls.Add(this.cb_podrobno);
            this.Controls.Add(this.copy_GLASS);
            this.Controls.Add(this.copy_MARKA);
            this.Controls.Add(this.chbWATERMARK);
            this.Controls.Add(this.cbShutdown);
            this.Controls.Add(this.chbPhotos);
            this.Controls.Add(this.chbUpdateData);
            this.Controls.Add(this.chbGlass);
            this.Controls.Add(this.lbl_BEGIN);
            this.Controls.Add(this.lbl_END);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_END;
        private System.Windows.Forms.Label lbl_BEGIN;
        private System.Windows.Forms.CheckBox chbGlass;
        private System.Windows.Forms.CheckBox chbUpdateData;
        private System.Windows.Forms.CheckBox chbPhotos;
        private System.Windows.Forms.CheckBox cbShutdown;
        private System.Windows.Forms.CheckBox chbWATERMARK;
        private System.Windows.Forms.CheckBox copy_MARKA;
        private System.Windows.Forms.CheckBox copy_GLASS;
        private System.Windows.Forms.CheckBox cb_podrobno;
        private System.Windows.Forms.CheckBox chbPrepare;
    }
}

