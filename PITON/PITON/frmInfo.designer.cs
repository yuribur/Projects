namespace PITON
{
    partial class frmInfo
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
            this.cmdSensors = new System.Data.SqlClient.SqlCommand();
            this.Con = new System.Data.SqlClient.SqlConnection();
            this.cmdPhoto = new System.Data.SqlClient.SqlCommand();
            this.PhotoCounter = new System.Data.SqlClient.SqlCommand();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.photoBox = new System.Windows.Forms.PictureBox();
            this.photoBox2 = new System.Windows.Forms.PictureBox();
            this.GetIdPhotos = new System.Data.SqlClient.SqlCommand();
            this.myPanel = new System.Windows.Forms.Panel();
            this.Markamodel = new System.Windows.Forms.Label();
            this.Comment = new System.Windows.Forms.TextBox();
            this.listAnalogi = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(487, 583);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // cmdSensors
            // 
            this.cmdSensors.CommandText = "FromSensors";
            this.cmdSensors.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmdSensors.Connection = this.Con;
            this.cmdSensors.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_MEMO", System.Data.SqlDbType.Int)});
            // 
            // Con
            // 
            this.Con.ConnectionString = "Data Source=box21;Initial Catalog=PITHON;Persist Security Info=True;User ID=datex" +
    "ml;Password=56538085";
            this.Con.FireInfoMessageEventOnUserErrors = false;
            // 
            // cmdPhoto
            // 
            this.cmdPhoto.CommandText = "GetPhotos_M";
            this.cmdPhoto.CommandTimeout = 60;
            this.cmdPhoto.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmdPhoto.Connection = this.Con;
            this.cmdPhoto.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_PHOTO", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@ID_NEXTPHOTO", System.Data.SqlDbType.Int)});
            // 
            // PhotoCounter
            // 
            this.PhotoCounter.CommandText = "COUNTER_PHOTO";
            this.PhotoCounter.CommandType = System.Data.CommandType.StoredProcedure;
            this.PhotoCounter.Connection = this.Con;
            this.PhotoCounter.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_MEMO", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@COUNT_PHOTO", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@COUNT_SENSOR", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Brown;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 624);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.Color.Brown;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Enabled = false;
            this.splitter3.Location = new System.Drawing.Point(1020, 5);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(5, 624);
            this.splitter3.TabIndex = 7;
            this.splitter3.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Brown;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1025, 5);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // splitter4
            // 
            this.splitter4.BackColor = System.Drawing.Color.Brown;
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Enabled = false;
            this.splitter4.Location = new System.Drawing.Point(0, 629);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(1025, 5);
            this.splitter4.TabIndex = 9;
            this.splitter4.TabStop = false;
            // 
            // splitter5
            // 
            this.splitter5.BackColor = System.Drawing.Color.Brown;
            this.splitter5.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter5.Enabled = false;
            this.splitter5.Location = new System.Drawing.Point(5, 5);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(1015, 2);
            this.splitter5.TabIndex = 10;
            this.splitter5.TabStop = false;
            // 
            // btnPrev
            // 
            this.btnPrev.BackgroundImage = global::PITON.Properties.Resources.Top1;
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.Location = new System.Drawing.Point(478, 222);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(38, 58);
            this.btnPrev.TabIndex = 14;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Visible = false;
            this.btnPrev.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPrev_MouseUp);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = global::PITON.Properties.Resources.Bottom1;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.Location = new System.Drawing.Point(479, 328);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(38, 58);
            this.btnNext.TabIndex = 13;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            this.btnNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnNext_MouseUp);
            // 
            // photoBox
            // 
            this.photoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.photoBox.Location = new System.Drawing.Point(7, 13);
            this.photoBox.Name = "photoBox";
            this.photoBox.Size = new System.Drawing.Size(470, 300);
            this.photoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox.TabIndex = 12;
            this.photoBox.TabStop = false;
            // 
            // photoBox2
            // 
            this.photoBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.photoBox2.Location = new System.Drawing.Point(7, 324);
            this.photoBox2.Name = "photoBox2";
            this.photoBox2.Size = new System.Drawing.Size(470, 300);
            this.photoBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox2.TabIndex = 15;
            this.photoBox2.TabStop = false;
            // 
            // GetIdPhotos
            // 
            this.GetIdPhotos.CommandText = "GetIdPhotos";
            this.GetIdPhotos.CommandType = System.Data.CommandType.StoredProcedure;
            this.GetIdPhotos.Connection = this.Con;
            this.GetIdPhotos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_MEMO", System.Data.SqlDbType.Int)});
            // 
            // myPanel
            // 
            this.myPanel.AutoScroll = true;
            this.myPanel.BackColor = System.Drawing.SystemColors.Control;
            this.myPanel.Location = new System.Drawing.Point(519, 44);
            this.myPanel.Name = "myPanel";
            this.myPanel.Padding = new System.Windows.Forms.Padding(10);
            this.myPanel.Size = new System.Drawing.Size(494, 478);
            this.myPanel.TabIndex = 16;
            // 
            // Markamodel
            // 
            this.Markamodel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Markamodel.Location = new System.Drawing.Point(479, 11);
            this.Markamodel.Name = "Markamodel";
            this.Markamodel.Size = new System.Drawing.Size(534, 31);
            this.Markamodel.TabIndex = 17;
            this.Markamodel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Comment
            // 
            this.Comment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comment.BackColor = System.Drawing.SystemColors.Window;
            this.Comment.Cursor = System.Windows.Forms.Cursors.Default;
            this.Comment.Enabled = false;
            this.Comment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Comment.Location = new System.Drawing.Point(590, 523);
            this.Comment.MaxLength = 8000;
            this.Comment.Multiline = true;
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            this.Comment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Comment.Size = new System.Drawing.Size(423, 101);
            this.Comment.TabIndex = 18;
            this.Comment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listAnalogi
            // 
            this.listAnalogi.Enabled = false;
            this.listAnalogi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listAnalogi.FormattingEnabled = true;
            this.listAnalogi.ItemHeight = 16;
            this.listAnalogi.Location = new System.Drawing.Point(513, 520);
            this.listAnalogi.Name = "listAnalogi";
            this.listAnalogi.Size = new System.Drawing.Size(399, 36);
            this.listAnalogi.TabIndex = 20;
            this.listAnalogi.Visible = false;
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 634);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listAnalogi);
            this.Controls.Add(this.Markamodel);
            this.Controls.Add(this.myPanel);
            this.Controls.Add(this.photoBox2);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.photoBox);
            this.Controls.Add(this.splitter5);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация";
            this.Load += new System.EventHandler(this.frmInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Data.SqlClient.SqlCommand cmdSensors;
        private System.Data.SqlClient.SqlCommand cmdPhoto;
        private System.Data.SqlClient.SqlCommand PhotoCounter;
        private System.Data.SqlClient.SqlConnection Con;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.PictureBox photoBox;
        private System.Windows.Forms.PictureBox photoBox2;
        private System.Data.SqlClient.SqlCommand GetIdPhotos;
        private System.Windows.Forms.Panel myPanel;
        public System.Windows.Forms.Label Markamodel;
        public System.Windows.Forms.TextBox Comment;
        public System.Windows.Forms.ListBox listAnalogi;
    }
}