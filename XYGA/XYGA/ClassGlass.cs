using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;

namespace XYGA
{
    internal class Class_Glass
    {
        SqlConnection Con;
        SqlCommand cmd_save_info;
        SqlCommand cmd_delete_info;

        string data;

        // GLASS_INFO
        SqlParameter p_артикул;
        SqlParameter p_key;
        SqlParameter p_val;

        string артикул;

        SqlCommand cmd_save_nomenk;
        SqlCommand cmd_delete_nomenk;

        // GLASSES
        SqlParameter p_id_model, p_id_modele;
        SqlParameter p_photo;
        SqlParameter p_id_image;
        SqlParameter p_naim;
        SqlParameter p_артикулa;
        SqlParameter p_страна;
        SqlParameter p_цена;
        SqlParameter p_марка;
        SqlParameter p_наличие;
        SqlParameter p_рналичие;
        


        public Class_Glass()
        {
            Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();
            Con.Open();

            p_артикул = new SqlParameter();
            p_артикул.ParameterName = "@артикул";
            p_артикул.SqlDbType = SqlDbType.VarChar;
            p_артикул.Size = 100;


            p_id_modele = new SqlParameter();
            p_id_modele.ParameterName = "@id_model";
            p_id_modele.SqlDbType = SqlDbType.VarChar;
            p_id_modele.Size = 50;

            p_артикулa = new SqlParameter();
            p_артикулa.ParameterName = "@артикул";
            p_артикулa.SqlDbType = SqlDbType.VarChar;
            p_артикулa.Size = 100;

            p_key = new SqlParameter();
            p_key.ParameterName = "@keyv";
            p_key.SqlDbType = SqlDbType.VarChar;
            p_key.Size = 100;

            p_val = new SqlParameter();
            p_val.ParameterName = "@value";
            p_val.SqlDbType = SqlDbType.VarChar;
            p_val.Size = 100;


            cmd_save_info = new SqlCommand();
            cmd_save_info.CommandType = CommandType.StoredProcedure;
            cmd_save_info.CommandText = "SAVE_GLASS_INFO";

            cmd_save_info.Parameters.Add(p_id_modele);
            cmd_save_info.Parameters.Add(p_артикул);
            cmd_save_info.Parameters.Add(p_key);
            cmd_save_info.Parameters.Add(p_val);
            cmd_save_info.Connection = Con;

            cmd_delete_info = new SqlCommand();
            cmd_delete_info.CommandType = CommandType.Text;
            cmd_delete_info.CommandText = "TRUNCATE TABLE GLASS_INFO";
            cmd_delete_info.Connection = Con;
            cmd_delete_info.ExecuteNonQuery();


            cmd_save_nomenk = new SqlCommand();
            cmd_save_nomenk.CommandType = CommandType.StoredProcedure;
            cmd_save_nomenk.CommandText = "SAVE_GLASS_HEADER";
            cmd_save_nomenk.Connection = Con;

            cmd_delete_nomenk = new SqlCommand();
            cmd_delete_nomenk.CommandType = CommandType.Text;
            cmd_delete_nomenk.CommandText = "TRUNCATE TABLE GLASSES";
            cmd_delete_nomenk.Connection = Con;
          //  cmd_delete_nomenk.ExecuteNonQuery();

            p_id_model = new SqlParameter();
            p_id_model.ParameterName = "@id_model";
            p_id_model.SqlDbType = SqlDbType.VarChar;
            p_id_model.Size = 50;
            cmd_save_nomenk.Parameters.Add(p_id_model);
            
            p_photo = new SqlParameter();
            p_photo.ParameterName = "@photo";
            p_photo.SqlDbType = SqlDbType.VarChar;
            p_photo.Size = 200;
            cmd_save_nomenk.Parameters.Add(p_photo);

            p_id_image = new SqlParameter();
            p_id_image.ParameterName = "@id_image";
            p_id_image.SqlDbType = SqlDbType.VarChar;
            p_id_image.Size = 150;
            cmd_save_nomenk.Parameters.Add(p_id_image);

            p_naim = new SqlParameter();
            p_naim.ParameterName = "@naim";
            p_naim.SqlDbType = SqlDbType.VarChar;
            p_naim.Size = 200;
            cmd_save_nomenk.Parameters.Add(p_naim);

            p_артикулa = new SqlParameter();
            p_артикулa.ParameterName = "@артикул";
            p_артикулa.SqlDbType = SqlDbType.VarChar;
            p_артикулa.Size = 150;
            cmd_save_nomenk.Parameters.Add(p_артикулa);

            p_страна = new SqlParameter();
            p_страна.ParameterName = "@страна";
            p_страна.SqlDbType = SqlDbType.VarChar;
            p_страна.Size = 50;
            cmd_save_nomenk.Parameters.Add(p_страна);

            p_цена = new SqlParameter();
            p_цена.ParameterName = "@цена";
            p_цена.SqlDbType = SqlDbType.Int;
            cmd_save_nomenk.Parameters.Add(p_цена);

            p_марка = new SqlParameter();
            p_марка.ParameterName = "@марка";
            p_марка.SqlDbType = SqlDbType.VarChar;
            p_марка.Size = 50;
            cmd_save_nomenk.Parameters.Add(p_марка);

            p_наличие = new SqlParameter();
            p_наличие.ParameterName = "@наличие";
            p_наличие.SqlDbType = SqlDbType.VarChar;
            p_наличие.Size = 50;
            cmd_save_nomenk.Parameters.Add(p_наличие);

            p_рналичие = new SqlParameter();
            p_рналичие.ParameterName = "@рналичие";
            p_рналичие.SqlDbType = SqlDbType.VarChar;
            p_рналичие.Size = 50;
            cmd_save_nomenk.Parameters.Add(p_рналичие);
        }



        public void GetModel_Glass()
        {
            Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();

            SqlCommand cmd_glasses = new SqlCommand();
            cmd_glasses.Connection = Con;
            cmd_glasses.CommandText = "SELECT_FROM_SITESS";

            Con.Open();
            SqlDataReader dr_sites = cmd_glasses.ExecuteReader();
            string sitek;

            while (dr_sites != null && dr_sites.Read())
            {
                string marka  = dr_sites["marka"].ToString();
                string model  = dr_sites["model"].ToString();
                string modeln = dr_sites["modeln"].ToString();

                sitek = "https://autotrade.su/moscow/catalog/" + marka + "/" + model + "/" + modeln + "/steklo-lobovoe";
                Get_GlassInfo(marka, model, modeln, sitek);

                sitek = "https://autotrade.su/moscow/catalog/" + marka + "/" + model + "/" + modeln + "/steklo-zadnee";
                Get_GlassInfo(marka, model, modeln, sitek);

                sitek = "https://autotrade.su/moscow/catalog/" + marka + "/" + model + "/" + modeln + "/steklo-kuzova-bokovoe-ne-opusknoe";
                Get_GlassInfo(marka, model, modeln, sitek);

                sitek = "https://autotrade.su/moscow/catalog/" + marka + "/" + model + "/" + modeln + "/steklo-bokovoe-opusknoe";
                Get_GlassInfo(marka, model, modeln, sitek);

                sitek = "https://autotrade.su/moscow/catalog/" + marka + "/" + model + "/" + modeln + "/steklo-fortochki";
                Get_GlassInfo(marka, model, modeln, sitek);

                //Thread.Sleep(1000);
            }

            dr_sites.Close();

            cmd_glasses.CommandText = "DELETE FROM GLASSES WHERE страна='KMK' ";
            cmd_glasses.ExecuteNonQuery();

            cmd_glasses.CommandText = "TRUNCATE TABLE  XYGA..GLASSES_2; ";
            cmd_glasses.ExecuteNonQuery();

            cmd_glasses.CommandText = "INSERT INTO XYGA..GLASSES_2 SELECT * FROM XYGA..GLASSES WHERE RTRIM(рналичие)=''";
            cmd_glasses.ExecuteNonQuery();

        }



        private void Get_GlassInfo(string marka, string model, string modeln,string sitek)
        {
            // sitek = "https://autotrade.su/moscow/catalog/toyota/land-cruiser-prado/587/steklo-lobovoe";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(sitek);
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

                data = readStream.ReadToEnd();
            }


            Get_nomenk( marka, modeln);
        }




        private void Get_nomenk(string marka, string modeln)
        {
            string[] stringSeparators = new string[] { "data-filter-brand" };
            string[] nomenk = data.Split(stringSeparators, StringSplitOptions.None);
            

            for (int j = 1; j < nomenk.Length; j++)
            {
                Get_catalog_container( marka, nomenk[j],modeln);

                string[] techSeparators = new string[] { "<table>" };  /************************/
                string[] techInfo = nomenk[j].Split(techSeparators, StringSplitOptions.None);

                for (int i = 1; i < techInfo.Length; i++)
                {
                    Get_TechInfo(techInfo[i], modeln);
                }
            }

        }

        void Get_TechInfo(string techInfo, string modeln)
        {
            techInfo = techInfo.Replace("th", "td");
            techInfo = techInfo.Replace("</span>", " ");

            int pos_span = techInfo.IndexOf("<span");
            while (pos_span > -1)
            {
                pos_span = techInfo.IndexOf("<span");
                int posb = techInfo.IndexOf(">", pos_span)  +1; 
                //techInfo = techInfo.Substring(pos_span,  posb - pos_span);
                techInfo = techInfo.Substring(0, pos_span) + techInfo.Substring(posb);
                pos_span = techInfo.IndexOf("<span");
            }



            string[] techSeparators = new string[] { "<tr>" };
            string[] info = techInfo.Split(techSeparators, StringSplitOptions.None);



            for (int k = 1; k < info.Length; k++)
            {
                Get_info(info[k], modeln);
            }

        }




        private void Get_catalog_container(string marka, string container, string modeln)
        {
            string photo = "";
            string id_image = "";
            string cost;
            string наличие;

            int posa = container.IndexOf("href=") + 6;
            int length = container.IndexOf("jpg", posa) - posa;
            if (length < 0 )
            {
                photo = "https://autotrade.su/build/images/no-photo.bd7e010b.jpg";
                id_image = "no-photo.bd7e010b.jpg";
            }
            else
            {
                photo = container.Substring(posa, length + 3);
                posa = photo.LastIndexOf("/") + 1;
                length = photo.Length - posa;
                id_image = photo.Substring(posa, length);
            }



            posa = container.IndexOf("<h2>") + 3;
            posa = container.IndexOf("\">", posa) + 4;
            length = container.IndexOf("</a>", posa) - posa -4;
            string naim = container.Substring(posa, length);
            naim = naim.Trim();

            posa = container.IndexOf("cell small-", posa);
            posa = container.IndexOf("Артикул:", posa) + 14;
            length = container.IndexOf("</div>", posa) - posa;
            артикул = container.Substring(posa, length);

            posa = container.IndexOf("data-brand", posa) + 12;
            length = container.IndexOf("\"", posa) - posa;
            string бренд = container.Substring(posa, length);

            posa = container.IndexOf("Страна:", posa) ;
            string страна;

            if ( posa > 0 )
            {
                posa = posa + 13;
                length = container.IndexOf("</div>", posa) - posa;
                страна = container.Substring(posa, length);
                страна = бренд.ToUpper(); // + " (" + страна + ")";
            }
            else
            {
                страна = бренд.ToUpper();
                posa = 0;
            }


            cost = "class=\"cost\"";
            posa = container.IndexOf(cost, posa) + 13;
            length = container.IndexOf("</span>", posa) - posa;
            string цена = container.Substring(posa, length);



            //cmd_save_nomenk
            p_id_model.Value = modeln;
            p_photo.Value = photo;
            p_id_image.Value = id_image;
            p_naim.Value = naim;
            p_артикулa.Value = артикул;
            p_страна.Value = страна;
            p_цена.Value = цена;
            p_марка.Value = marka;
            p_рналичие.Value = 0;
            posa = container.IndexOf("В наличии");

            if (posa < 0)
            {
                posa = container.IndexOf("Под заказ") + 11;

                
                наличие = container.Substring(posa, 6);
                наличие = наличие.Replace(")", " ");
                p_рналичие.Value = наличие; // container.Substring(posa, 6);
                p_наличие.Value = "";
            }
                
            
            else
            {

                p_наличие.Value = container.Substring(posa, 16);
                p_рналичие.Value = "";
            }
               
            cmd_save_nomenk.ExecuteNonQuery();

        }



        void Get_info(string info, string modeln)
        {
            int pos1 = info.IndexOf("<td>") ;

            if (pos1 == -1) return;

            int pos2 = info.IndexOf("</td>");
            pos1 += 4;
            int len = pos2 - pos1;
            string key = info.Substring(pos1, len);
            key = key.Trim();

            info = info.Substring(pos2 + 5);
            pos1 = info.IndexOf("<td>");

            pos2 = info.IndexOf("</td>");
            pos1 += 4;
            len = pos2 - pos1;
            string val = info.Substring(pos1, len);
            val = val.Trim();

            p_id_modele.Value = modeln;
            p_артикул.Value = артикул;
            p_key.Value = key;
            p_val.Value = val;
            cmd_save_info.ExecuteNonQuery();
        }


    }
}
