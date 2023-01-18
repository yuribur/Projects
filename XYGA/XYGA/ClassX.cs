using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;

namespace XYGA
{
    internal class ClassX
    {
        SqlConnection Con;
        SqlCommand cmd_siteko;

        // GLASS_INFO
        
        SqlParameter q_marka;
        SqlParameter q_model;
        SqlParameter q_modeln;

        public ClassX()
        {
            Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();
            Con.Open();

            cmd_siteko = new SqlCommand();
            cmd_siteko.Connection = Con;

            cmd_siteko.CommandType = CommandType.Text;
            cmd_siteko.CommandText = "TRUNCATE TABLE SITESS";
            cmd_siteko.ExecuteNonQuery();

            cmd_siteko.CommandType = CommandType.StoredProcedure;
            cmd_siteko.CommandText = "INSERT_SITESS";


            q_marka = new SqlParameter();
            q_marka.SqlDbType = SqlDbType.VarChar;
            q_marka.Size = 50;
            q_marka.ParameterName = "@marka";
            cmd_siteko.Parameters.Add(q_marka);

            q_model = new SqlParameter();
            q_model.SqlDbType = SqlDbType.VarChar;
            q_model.Size = 50;
            q_model.ParameterName = "@model";
            cmd_siteko.Parameters.Add(q_model);

            q_modeln = new SqlParameter();
            q_modeln.SqlDbType = SqlDbType.VarChar;
            q_modeln.Size = 50;
            q_modeln.ParameterName = "@modeln";
            cmd_siteko.Parameters.Add(q_modeln);
        }


        public void Select_models()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();

            SqlCommand cmd_modell = new SqlCommand();
            cmd_modell.Connection = Con;
            cmd_modell.CommandType = CommandType.StoredProcedure;
            cmd_modell.CommandText = "SELECT_MODELS";

            Con.Open();

            SqlDataReader modell_reader = cmd_modell.ExecuteReader();

            while (modell_reader.Read())
            {
                string marka = (string)modell_reader[1];
                string model = (string)modell_reader[2];
                string address = "https://autotrade.su/moscow/catalog/" + marka + "/" + model; ;

                GetModelsTypes(address, marka, model);
            }

            Con.Close();
        }



        private void GetModelsTypes(string urlAddress, string marka, string model)
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
                    string sub = subs[i];


                    string razdel = "/moscow/catalog/" + marka + "/" + model + "/";

                    string[] SeparatorsModel = new string[] { razdel };
                    string[] models = sub.Split(SeparatorsModel, StringSplitOptions.None);

                    for (int j = 1; j < models.Length; j++)
                    {
                        models[j] = models[j].Substring(0, models[j].IndexOf("\""));
                    }

                    // сохраняем
                    for (int j = 1; j < models.Length; j++)
                    {
                        Save_siteko(marka, model, models[j]);
                    }

                }
            }
        }



        private void Save_siteko(string marka, string model, string id_model)
        {
            q_marka.Value = marka;
            q_model.Value = model;
            q_modeln.Value = id_model;

            cmd_siteko.ExecuteNonQuery();
        }

    }
}
