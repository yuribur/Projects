using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PictCompres
{
    public partial class btnDir : Form
    {
        string SQLPithon;

        private PictureBox pict1;
        SqlConnection Con;
        
        SqlCommand cmdSelect;
        private Button btnLoad;
        private Button btnClose;
        private Button btnUnload;
        SqlCommand cmdUpdate;
        int id_photo;

        string picName = "";
        string[] pathName;
        byte[] buffer;

        public btnDir()
        {
            InitializeComponent();
            SQLPithon = @"Data Source=localhost;Initial Catalog=PITHON;Persist Security Info=True;User ID=sa;Password=onc15454*";
            Con = new SqlConnection();
            Con.ConnectionString = SQLPithon;
            cmdSelect = new SqlCommand();
            cmdSelect.Connection = Con;
            
            cmdSelect.CommandText = " ID_PHOTO,DATALENGTH(photo),PHOTO  FROM  PHOTOS";
            cmdSelect.CommandType = CommandType.Text;

            cmdUpdate = new SqlCommand();
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.Connection = Con;
        }


        private void btnUnload_MouseUp(object sender, MouseEventArgs e)
        {
            int bufferSize;
            byte[] buffer;
            long retval = 0;
            long startIndex = 0;
           
            btnUnload.Enabled = false;
            btnLoad.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            string name;

             MemoryStream memstrm_photo = null;
         
             byte[] storage_photo;

             SqlDataReader dr_photo;
             Con.Open();

             dr_photo = cmdSelect.ExecuteReader();
             
             
             Bitmap bm = null;
             Image NewImage;


            while (dr_photo.Read())
            {
                try
                {
                    id_photo = Convert.ToInt16(dr_photo[0].ToString());
                    bufferSize = Convert.ToInt16(dr_photo[1].ToString());
                    buffer = new byte[bufferSize];
                    storage_photo = new byte[bufferSize]; //создали буфер
                    memstrm_photo = new MemoryStream(storage_photo);
                    memstrm_photo.Seek(0L, 0L);

                    retval = dr_photo.GetBytes(2, startIndex, buffer, 0, bufferSize);
                    memstrm_photo.Write(buffer, 0, (int)retval);
                    memstrm_photo.Flush();

                    bm = new Bitmap(Image.FromStream(memstrm_photo));
                    int BMwidth = bm.Width;
                    int BMheight = bm.Height;
                    int newWidth = 800;
                    int newHeight = BMheight * newWidth / BMwidth;

                    if ( BMwidth > 800)
                    {
                        BMwidth = bm.Width;
                        BMheight = bm.Height;
                        newWidth = 800;
                        newHeight = BMheight * newWidth / BMwidth;
                    }
                    else
                    {
                        newWidth = bm.Width;
                        newHeight = bm.Height;
                    }

                     NewImage = bm.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);

                    name = @"C:\Pict\" + id_photo.ToString() + ".jpg";
                    NewImage.Save(name);
                    bm = null;
                }
                    
                catch(Exception ex)
                {
                    string msg = ex.Message;
                    MessageBox.Show("ошибка " + ex.Message);
                    bm = null;
                }
                finally
                {

                    NewImage = null;
                    bm.Dispose();

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

            }

            pict1.Image = null;
            Con.Close();

            memstrm_photo.Dispose();
            Close();
        }

        private void btnLoad_MouseUp(object sender, MouseEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\PNG_IN");
 
            FileInfo[] finfo = di.GetFiles();

            foreach (FileInfo fi in finfo)
            {
                try
                {
                    picName = fi.FullName;
                    pathName = picName.Split('\\', '.');
                    id_photo = Convert.ToInt32(pathName[2].Substring(0, 4));
                }
                catch
                {
                    string s = pathName[2].Substring(0, 4);
                }

            }


            btnUnload.Enabled = false;
            btnLoad.Enabled = false;
            this.Cursor = Cursors.WaitCursor;


            Con.Open();

            cmdUpdate.CommandText = " UPDATE PHOTOS SET PHOTO = @PHOTO where ID_PHOTO = @ID_PHOTO";
            cmdUpdate.CommandType = CommandType.Text;

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@id_photo";
            p1.SqlDbType = SqlDbType.Int;

            cmdUpdate.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@photo";
            p2.SqlDbType = SqlDbType.Image;
            cmdUpdate.Parameters.Add(p2);



            int k_photos = 0;

            foreach (FileInfo fi in finfo)
            {
                picName =fi.FullName;
                pathName= picName.Split('\\','.');
                id_photo = Convert.ToInt32(pathName[2]);
                
                FileStream fs = new FileStream(picName, FileMode.Open, FileAccess.Read);

                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int) fs.Length);

                cmdUpdate.Parameters["@id_photo"].Value = id_photo;
                cmdUpdate.Parameters["@photo"].Value = buffer;
                cmdUpdate.ExecuteNonQuery();
                k_photos ++;
                fs.Close();
                fs.Dispose();
                buffer = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            Con.Close();
            this.Close();
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.pict1 = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUnload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pict1)).BeginInit();
            this.SuspendLayout();
            // 
            // pict1
            // 
            this.pict1.Location = new System.Drawing.Point(25, 23);
            this.pict1.Name = "pict1";
            this.pict1.Size = new System.Drawing.Size(338, 194);
            this.pict1.TabIndex = 0;
            this.pict1.TabStop = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(190, 300);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Загружай";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLoad_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(290, 300);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // btnUnload
            // 
            this.btnUnload.Location = new System.Drawing.Point(90, 300);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(75, 23);
            this.btnUnload.TabIndex = 3;
            this.btnUnload.Text = "Выгружай";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUnload_MouseUp);
            // 
            // btnDir
            // 
            this.ClientSize = new System.Drawing.Size(406, 335);
            this.Controls.Add(this.btnUnload);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pict1);
            this.Name = "btnDir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pict1)).EndInit();
            this.ResumeLayout(false);

        }

    }
}
