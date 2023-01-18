using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PITON
{
    public partial class frmInfo : Form
    {
        public int id_memo;

        private int sensor_count;  // число сенсоров 
        private int photo_count;  // число  автомобилей
        private MemoryStream  memstrm;
        private byte[] storage;
        
        private byte[] buffer;

        private byte[] storage_photo;
        
        private MemoryStream memstrm_photo;
        private MemoryStream memstrm_photo2;


        public string lbl_photo;
        SqlDataReader dr;
        SqlDataReader dr_photo;
        int id_photo;
        int id_next_photo;
        int id_prev_photo;
        int nomer; // номер первой, из двух выводимых, фотографий

        string[] id_photos;

        public frmInfo()
        {
            InitializeComponent();
            Con.ConnectionString = Con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();
        }



        private void PictureLoader(int step)
        {
            if (memstrm_photo != null)
            {
                memstrm_photo.Dispose();
            }

            if (memstrm_photo2 != null)
            {
                memstrm_photo2.Dispose();
            }


            switch (step)
            {
                case 0:
                    id_photo = Convert.ToInt32(id_photos[nomer]);
                    cmdPhoto.Parameters["@id_photo"].Value = id_photo;
                    id_prev_photo = -1;

                    if (nomer + 1 < photo_count)
                    {
                        id_next_photo = Convert.ToInt32(id_photos[nomer + 1]);
                        cmdPhoto.Parameters["@id_nextphoto"].Value = id_next_photo;
                    }
                    else
                    {
                        id_next_photo = -1;
                        cmdPhoto.Parameters["@id_nextphoto"].Value = id_next_photo;
                    }
                    break;

                case 1:
                    nomer++;
                    id_prev_photo = id_photo;
                    id_photo = id_next_photo;
                    cmdPhoto.Parameters["@id_photo"].Value = id_photo;
                    id_next_photo = -1;
                    
                    if (nomer < photo_count )
                    {
                        id_next_photo = Convert.ToInt32(id_photos[nomer + 1]);
                        cmdPhoto.Parameters["@id_nextphoto"].Value = id_next_photo;
                    }

                    break;

                case -1:
                    nomer--;
                    id_next_photo = id_photo;
                    id_photo = id_prev_photo;
                    cmdPhoto.Parameters["@id_photo"].Value = id_photo;
                    cmdPhoto.Parameters["@id_nextphoto"].Value = id_next_photo;
                    id_prev_photo = -1;
                    if (nomer > 0)
                    {
                        id_prev_photo = Convert.ToInt32(id_photos[nomer - 1]);
                    }
                    break;

            }


            Con.Open();
            dr_photo = cmdPhoto.ExecuteReader();
            dr_photo.Read();

            int lengh_photo = Convert.ToInt32(dr_photo["LENGH_PHOTO"].ToString());
            buffer = new byte[lengh_photo];

            long retval = 0;
            long startIndex = 0;

            retval = dr_photo.GetBytes(2, startIndex, buffer, 0, lengh_photo);
          
            memstrm_photo = new MemoryStream(buffer);
            memstrm_photo.Write(buffer, 0, (int)retval);
            memstrm_photo.Flush();
            photoBox.Image = Image.FromStream(memstrm_photo);

            
            if (id_next_photo != -1)
            {
                dr_photo.Read();
                lengh_photo = Convert.ToInt32(dr_photo["LENGH_PHOTO"].ToString());
                buffer = new byte[lengh_photo];

                retval = dr_photo.GetBytes(2, startIndex, buffer, 0, lengh_photo);
               
                memstrm_photo2 = new MemoryStream(buffer);
                memstrm_photo2.Write(buffer, 0, (int)retval);
                memstrm_photo2.Flush();
                photoBox2.Image = Image.FromStream(memstrm_photo2);
            }
            
            Con.Close();
            buffer = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            btnPrev.Visible = (nomer == 0 ? false : true);
            btnNext.Visible = (nomer +2 >= photo_count ? false : true);

        }



        private void frmInfo_Load(object sender, EventArgs e)
        {
            int row;
            int col;
            int bufferSize = 200000;
            byte[] buffer = new byte[bufferSize];

            long retval;
            long startIndex = 0;

            // определим число фотографий
            PhotoCounter.Parameters["@ID_MEMO"].Value = id_memo;
            Con.Open();
            PhotoCounter.ExecuteNonQuery();
            photo_count = (int)PhotoCounter.Parameters["@COUNT_PHOTO"].Value;
            sensor_count = (int)PhotoCounter.Parameters["@COUNT_SENSOR"].Value;

            id_photos = new string[photo_count];
            nomer = 0;

            GetIdPhotos.Parameters[0].Value = id_memo;
            SqlDataReader rphotos = GetIdPhotos.ExecuteReader();

            for (int ph = 0; ph < photo_count; ph++ )
            {
                rphotos.Read();
                id_photos[ph] = rphotos[0].ToString();
            }
            Con.Close();

            // параметр - идентификатор 
            cmdSensors.Parameters["@id_memo"].Value = id_memo;

            storage_photo = new byte[1];
            Con.Open();
            dr = cmdSensors.ExecuteReader();

            PictureBox[] pbox = new PictureBox[sensor_count];

            for (int i = 0; i < sensor_count; i++)  // цикл по всем ДД
            {
                dr.Read();

                retval = dr.GetBytes(1, startIndex, buffer, 0, bufferSize);

                storage = new byte[retval]; //создали буфер
                memstrm = new MemoryStream(storage);

                memstrm.Write(buffer,0, (int)retval);
                memstrm.Flush();

                row = i / 3;
                col = i - row * 3;

                pbox[i] = new PictureBox();
                pbox[i].Height = 180;
                pbox[i].Width = 162;
                pbox[i].Left = 166 * col;
                pbox[i].Top = 185 * row;
                pbox[i].BorderStyle = BorderStyle.None;
                pbox[i].SizeMode = PictureBoxSizeMode.Zoom;
                myPanel.Controls.Add(pbox[i]);
                pbox[i].Image = Image.FromStream(memstrm);
            }
            Con.Close();

            if (lbl_photo == "+")
            {
                PictureLoader(0);
            }
        }



        private void btnNext_MouseUp(object sender, MouseEventArgs e)
        {
            PictureLoader(+1);
        }

        private void btnPrev_MouseUp(object sender, MouseEventArgs e)
        {
            PictureLoader(-1);
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }

    }
}
