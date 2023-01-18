using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;

namespace XYGA
{
    internal class Modell
    {
        SqlConnection Con;
        SqlCommand cmd;
        SqlCommand cmd_delete_models;
        SqlCommand cmd_save_model;
        SqlParameter p_marka;
        SqlParameter p_model;

        public Modell()
        {
            Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();

            cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                Connection = Con,
                CommandText = "SELECT marka FROM marky order by marka"
            };

            cmd_save_model = new SqlCommand();
            cmd_save_model.CommandType = CommandType.StoredProcedure;
            cmd_save_model.CommandText = "SAVE_MODELS";
            cmd_save_model.Connection = Con;

            p_marka = new SqlParameter
            {
                ParameterName = "@marka",
                SqlDbType = SqlDbType.VarChar,
                Size = 50
            };
            cmd_save_model.Parameters.Add(p_marka);
        

            p_model = new SqlParameter();
            p_model.ParameterName = "@model";
            p_model.SqlDbType = SqlDbType.VarChar;
            p_model.Size = 50;
            cmd_save_model.Parameters.Add(p_model);

            cmd_delete_models = new SqlCommand();
            cmd_delete_models.CommandType = CommandType.Text;
            cmd_delete_models.CommandText = "TRUNCATE TABLE MODELS";
            cmd_delete_models.Connection = Con;

        }


        public void Select_modeli()
        {
            Con.Open();

            cmd_delete_models.ExecuteNonQuery();

            string[] marki = new string[100];

            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;

            while (dr.Read())
            {
                string m = dr[0].ToString();
                marki[i++] = m;
            }

            i--;
            dr.Close();
            

            for (int i2 = 0; i2 < i; i2++)
            {
                string site = "https://autotrade.su/moscow/catalog/" + marki[i2];
                GetModels(site, marki[i2]);
            }

            Con.Close();
        }




        public void GetModels(string urlAddress, string marka)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlAddress);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                return;
            }


            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();
                int lengh_html = data.Length;


                string[] stringSeparators = new string[] { "search-panel" };
                string[] subs = data.Split(stringSeparators, StringSplitOptions.None);



                for (int i = 1; i < subs.Length; i++)
                {
                    string subp = subs[i];
                    Model_path(subp, marka);
                }
            }

        }

        private void Model_path(string subp, string marka)
            {
                string[] stringSeparators = new string[] { "/catalog/" + marka + "/" };
                string[] model_path = subp.Split(stringSeparators, StringSplitOptions.None);
                int length_catalog = model_path.Length;

                for (int i = 1; i < length_catalog; i++)
                {
                    string model = model_path[i];
                    model = model.Substring(0, model.IndexOf("\""));
                    string site = "/catalog/" + marka + "/" + model;
                    Save_marka_model(marka, model, site);
                }
            }



        private void Save_marka_model(string marka, string model, string site)
        {
            p_marka.SqlValue = marka;
            p_model.SqlValue = model;
            cmd_save_model.ExecuteNonQuery();
        }


    }
}
