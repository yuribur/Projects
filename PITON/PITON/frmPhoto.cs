using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PITON
{
    public class frmPhoto : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panel1;
        public int tId_memo;
		public string fullName;
        public string lbl_photo;
        Image img;
        Image undo_img;
		public bool  flagUpdate;
        public bool  flagDelete;

        private System.Data.SqlClient.SqlCommand cmdPhoto;
        private System.Data.SqlClient.SqlCommand delPhoto;
        private PictureBox photoBox;
        private SqlConnection Conne;
        
        MemoryStream memostream;
        private SqlCommand insPhotos;

        
        private byte[] buffer;  

        int id_photo;
        int id_next_photo;
        int id_prev_photo;
        string id_body;

        private Button btnCopy;
        private Button btnFromMemo;
        private Button btnDelete;
        private Button btnNext;
        private Button button1;
        private Button btnFromFile;
        private Button btnPrev;
        private Button btnUndo;
        private System.ComponentModel.Container components = null;

		public frmPhoto()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//

            Conne.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhoto));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnFromFile = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFromMemo = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cmdPhoto = new System.Data.SqlClient.SqlCommand();
            this.Conne = new System.Data.SqlClient.SqlConnection();
            this.delPhoto = new System.Data.SqlClient.SqlCommand();
            this.photoBox = new System.Windows.Forms.PictureBox();
            this.insPhotos = new System.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnUndo);
            this.panel1.Controls.Add(this.btnFromFile);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnFromMemo);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Location = new System.Drawing.Point(592, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 468);
            this.panel1.TabIndex = 4;
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(5, 109);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(116, 23);
            this.btnUndo.TabIndex = 14;
            this.btnUndo.Text = "Отменить";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUndo_MouseUp);
            // 
            // btnFromFile
            // 
            this.btnFromFile.Location = new System.Drawing.Point(4, 192);
            this.btnFromFile.Name = "btnFromFile";
            this.btnFromFile.Size = new System.Drawing.Size(117, 23);
            this.btnFromFile.TabIndex = 13;
            this.btnFromFile.Text = "Фото из файла";
            this.btnFromFile.UseVisualStyleBackColor = true;
            this.btnFromFile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnFromFile_MouseUp);
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(13, 312);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(100, 23);
            this.btnPrev.TabIndex = 12;
            this.btnPrev.Text = "Предыдущее";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPrev_MouseUp);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(13, 279);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 23);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "Следующее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnNext_MouseUp);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(13, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnFromMemo
            // 
            this.btnFromMemo.Enabled = false;
            this.btnFromMemo.Location = new System.Drawing.Point(4, 157);
            this.btnFromMemo.Name = "btnFromMemo";
            this.btnFromMemo.Size = new System.Drawing.Size(117, 23);
            this.btnFromMemo.TabIndex = 9;
            this.btnFromMemo.Text = "Вставить из памяти";
            this.btnFromMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromMemo.UseVisualStyleBackColor = true;
            this.btnFromMemo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnFromMemo_MouseUp);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(4, 74);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Удалить фото";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDelete_MouseUp);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(13, 245);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(100, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Запомнить";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCopy_MouseUp);
            // 
            // cmdPhoto
            // 
            this.cmdPhoto.CommandText = "NextPhoto_M";
            this.cmdPhoto.CommandTimeout = 60;
            this.cmdPhoto.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmdPhoto.Connection = this.Conne;
            this.cmdPhoto.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_MEMO", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@ID_PHOTO", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@LENGH_PHOTO", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // Conne
            // 
            this.Conne.FireInfoMessageEventOnUserErrors = false;
            // 
            // delPhoto
            // 
            this.delPhoto.CommandText = "DeletePhoto";
            this.delPhoto.CommandType = System.Data.CommandType.StoredProcedure;
            this.delPhoto.Connection = this.Conne;
            this.delPhoto.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_MEMO", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@ID_PHOTO", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.InputOutput, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@ID_PREVPHOTO", System.Data.SqlDbType.Int, 1, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, "0"),
            new System.Data.SqlClient.SqlParameter("@ID_NEXTPHOTO", System.Data.SqlDbType.Int, 1, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, "0")});
            // 
            // photoBox
            // 
            this.photoBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.photoBox.Location = new System.Drawing.Point(2, 2);
            this.photoBox.Name = "photoBox";
            this.photoBox.Size = new System.Drawing.Size(588, 468);
            this.photoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox.TabIndex = 5;
            this.photoBox.TabStop = false;
            // 
            // insPhotos
            // 
            this.insPhotos.CommandText = "insPhoto";
            this.insPhotos.CommandType = System.Data.CommandType.StoredProcedure;
            this.insPhotos.Connection = this.Conne;
            this.insPhotos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_MEMO", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@Photo", System.Data.SqlDbType.Image),
            new System.Data.SqlClient.SqlParameter("@ID_PHOTO", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@ID_PREVPHOTO", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // frmPhoto
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(720, 472);
            this.Controls.Add(this.photoBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhoto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Photo";
            this.Load += new System.EventHandler(this.frmPhoto_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion



		private void frmPhoto_Load(object sender, System.EventArgs e)
		{

            if (lbl_photo == "+")
            {
                Photo_Load(0);
            }
            else
            {
                id_photo = 0;
                id_next_photo = 0;
                id_prev_photo = 0;

                btnPrev.Enabled = false;
                btnNext.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (Clipboard.ContainsImage())
            {
                btnFromMemo.Enabled = true;
            }
        }



        private void Photo_Load(int cur_photo)
        {
           	long retval;
			long startIndex = 0;

            cmdPhoto.Parameters["@ID_MEMO"].Value = tId_memo;
            cmdPhoto.Parameters["@Id_PHOTO"].Value = cur_photo;

            if (Conne.State == ConnectionState.Closed)
            {
                Conne.Open();
            }
			
			SqlDataReader  rdCenter = cmdPhoto.ExecuteReader(CommandBehavior.SequentialAccess);

            if (rdCenter.Read())
            {
                int lengh_photo = Convert.ToInt32(rdCenter["LENGH_PHOTO"].ToString());
                buffer = new byte[lengh_photo];

                // ЧИТАЕМ ИДЕНТИФИКАТОР ФОТОГРАФИИ
                id_photo = Convert.ToInt32(rdCenter["ID_PHOTO"].ToString());
                id_next_photo = Convert.ToInt32(rdCenter["ID_NEXTPHOTO"].ToString());
                id_prev_photo = Convert.ToInt32(rdCenter["ID_PREVPHOTO"].ToString());
                id_body = rdCenter["ID_BODY"].ToString();

                // читаем фотографию целиком
                retval = rdCenter.GetBytes(5, startIndex, buffer, 0, lengh_photo);

                memostream = new MemoryStream(buffer);
                memostream.Write(buffer, 0, (int)retval);
                photoBox.Image = Image.FromStream(memostream);

                rdCenter.Close();
            }
            else
            {
                photoBox.Image = null;
            }

            if (Conne.State == ConnectionState.Open)
            {
                Conne.Close();
            }

            btnPrev.Enabled = (id_prev_photo == 0 ? false : true);
            btnNext.Enabled = (id_next_photo == 0 ? false : true);

            if (id_photo != 0)
            {
                btnDelete.Enabled = true;
                btnCopy.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnCopy.Enabled = false;
            }

            btnFromMemo.Enabled = (Clipboard.ContainsImage() ? true : false);

            buffer = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }// конец процедуры загрузки изображения frmPhoto_Load



        private void btnFromMemo_MouseUp(object sender, MouseEventArgs e)
        {
            img = Clipboard.GetImage();

            ImageConverter _imageConverter = new ImageConverter();
            byte[] storage2 = (byte[])_imageConverter.ConvertTo(img, typeof(byte[]));

            insPhotos.Parameters["@ID_MEMO"].Value = tId_memo;
            insPhotos.Parameters["@PHOTO"].Value = storage2;
            Conne.Open();
            insPhotos.ExecuteNonQuery();
            Conne.Close();

            id_photo = (int) insPhotos.Parameters["@ID_PHOTO"].Value;
            Photo_Load(id_photo);

            storage2 = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }



        private void btnDelete_MouseUp(object sender, MouseEventArgs e)
        {
            undo_img = photoBox.Image;
            delPhoto.Parameters["@Id_Photo"].Value = Convert.ToInt16(id_photo);
            delPhoto.Parameters["@ID_MEMO"].Value = tId_memo;

            Conne.Open();
            delPhoto.ExecuteNonQuery();
            Conne.Close();

            Photo_Load(id_prev_photo);
            btnUndo.Enabled = true;
            id_photo = (int)delPhoto.Parameters["@ID_PHOTO"].Value;
        }



        private void btnNext_MouseUp(object sender, MouseEventArgs e)
        {
            Photo_Load(id_next_photo);
        }



        private void btnPrev_MouseUp(object sender, MouseEventArgs e)
        {
            Photo_Load(id_prev_photo);
        }



        private void btnFromFile_MouseUp(object sender, MouseEventArgs e)
        {
            OpenFileDialog dpic = new OpenFileDialog();

            dpic.Filter = "Images (*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png";
            dpic.Multiselect = false;
            dpic.ShowDialog();

            if (dpic.FileName != "")
            {
                fullName = dpic.FileName;
                photoBox.Image = Image.FromFile(fullName);
                flagUpdate = true;

                FileStream fs = new FileStream(fullName, FileMode.Open, FileAccess.Read);
                long length = fs.Length;
                byte[] storage2 = new byte[length];
                fs.Read(storage2, 0, (int)length);

                insPhotos.Parameters["@ID_MEMO"].Value = tId_memo;
                insPhotos.Parameters["@PHOTO"].Value = storage2;

                Conne.Open();
                insPhotos.ExecuteNonQuery();

                id_photo = (int)insPhotos.Parameters["@ID_PHOTO"].Value;
                id_next_photo = 0;
                id_prev_photo = (int)insPhotos.Parameters["@ID_PREVPHOTO"].Value;

                btnPrev.Enabled = (id_prev_photo == 0 ? false : true);
                btnNext.Enabled = (id_next_photo == 0 ? false : true);
                btnDelete.Enabled = true;
                btnCopy.Enabled = true;
                btnFromMemo.Enabled = true;

                Conne.Close();
                fs.Close();
                fs.Dispose();
            }

            dpic.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }



        private void btnCopy_MouseUp(object sender, MouseEventArgs e)
        {
            if ( photoBox.Image != null)
            {
                Clipboard.SetImage(photoBox.Image);
                btnFromMemo.Enabled = true;
                btnUndo.Enabled = false;
            }
        }



        private void btnUndo_MouseUp(object sender, MouseEventArgs e)
        {
            photoBox.Image = undo_img ;
            Photo_Load(id_prev_photo);
            btnUndo.Enabled = false;

            TempFileCollection tc = new TempFileCollection();

            fullName = tc.BasePath + ".bms";

            undo_img.Save(fullName);

            FileStream fs = new FileStream(fullName, FileMode.Open);
            long length = fs.Length;
            byte[] storage2 = new byte[length];
            fs.Read(storage2, 0, (int)length);

            insPhotos.Parameters["@ID_MEMO"].Value = tId_memo;
            insPhotos.Parameters["@PHOTO"].Value = storage2;
            Conne.Open();
            insPhotos.ExecuteNonQuery();
            Conne.Close();

            id_photo = (int)insPhotos.Parameters["@ID_PHOTO"].Value;
            id_next_photo = 0;
            id_prev_photo = (int)insPhotos.Parameters["@ID_PREVPHOTO"].Value;

            btnPrev.Enabled = (id_prev_photo == 0 ? false : true);
            btnNext.Enabled = (id_next_photo == 0 ? false : true);
            btnDelete.Enabled = true;
            btnFromMemo.Enabled = (Clipboard.ContainsImage() ? true : false);

            fs.Close();
            fs.Dispose();

            File.Delete(fullName);
            btnUndo.Enabled = false;
        }
    }
}
