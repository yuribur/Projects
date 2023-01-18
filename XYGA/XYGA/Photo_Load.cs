using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace XYGA
{
    internal class Photo_Load
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmd_delete;
        SqlDataReader dr;
        SqlCommand cmd_update;
        SqlParameter p_id_model;
        SqlParameter p_pict;
        FileStream fs;


        public Photo_Load()
        {
            
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();

            cmd_delete = new SqlCommand();
            cmd_delete.Connection = con;
            cmd_delete.CommandText = "TRUNCATE table GLASS_IMAGE";

            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT DISTINCT photo, id_image FROM GLASSES WHERE id_image not in ( SELECT id_image FROM GLASS_IMAGE ) ";

            cmd_update = new SqlCommand();
            cmd_update.Connection = con;


            cmd_update.CommandType = CommandType.StoredProcedure;
            cmd_update.CommandText = "Update_glass_photo";

            p_id_model = new SqlParameter();
            p_id_model.DbType = DbType.String;
            p_id_model.ParameterName = "@id_image";
            p_id_model.Size = 100;

            p_pict = new SqlParameter();
            p_pict.DbType = DbType.Binary;
            p_pict.ParameterName = "@pict";
            p_pict.Direction = ParameterDirection.Input;

            cmd_update.Parameters.Add(p_id_model);
            cmd_update.Parameters.Add(p_pict);
        }


        public void UnLoad_photo_from_site()
        {
      
            con.Open();
            dr = cmd.ExecuteReader();

            using (WebClient client = new WebClient())
            {
                string url;

                while (dr.Read())
                {
                    url = dr[0].ToString();
                    string name = url.Substring(url.LastIndexOf("/") + 1);
                    
                    client.DownloadFile(url, @"c:\XYGA_PIC\" + name);
                }

            }
            con.Close();
            
        }


        public void Load_photo_into_pithon()
        {
            string picName, id_photo;
            string[] pathName;

            con.Open();

           // cmd_delete.ExecuteNonQuery();

            DirectoryInfo di = new DirectoryInfo(@"C:\XYGA_PICTURES");
            FileInfo[] finfo = di.GetFiles();


            foreach (FileInfo fi in finfo)
            {
                picName = fi.FullName;

                
                if (picName.IndexOf("no-photo.") > 0)
                {
                    id_photo = "no-photo.bd7e010b.jpg";
                }
                else
                {
                
                    pathName = picName.Split('\\', '.');
                    id_photo = pathName[2] + ".jpg";
                }
                
                fs = new FileStream(picName, FileMode.Open, FileAccess.Read);

                long length = fs.Length;
                byte[] storage2 = new byte[length];
                fs.Read(storage2, 0, (int)length);

                p_id_model.Value = id_photo;
                p_pict.Value = storage2;


                cmd_update.ExecuteNonQuery();
                fs.Close();
                fs.Dispose();
            }

            con.Close();
            
        }

    }
}
