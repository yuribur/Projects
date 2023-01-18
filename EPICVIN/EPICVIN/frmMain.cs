using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace EPICVIN
{
    public partial class frmMain : Form
    {

       // string data;

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con_epic"].ConnectionString;
            
            SqlCommand cmd_marky = new SqlCommand();
            cmd_marky.Connection = con;
            cmd_marky.CommandText = "SELECT * FROM marky";

            con.Open();
            SqlDataReader dr_marky = cmd_marky.ExecuteReader();

            while (dr_marky.Read())
            {
                string marka = (string)dr_marky[1];
            }


           // GetCode("https://epicvin.com/ru/vin-lookup/bmw");

        }

        /*
        public void GetCode(string urlAddress)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

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
                int lengh_html = data.Length;
                string[] stringSeparators = new string[] { "https://epicvin.com/ru/vin-lookup/bmw/" };
                string[] subs = data.Split(stringSeparators, StringSplitOptions.None);

                for (int i= 1; i < subs.Length; i++)
                {
                    int pos = subs[i].IndexOf(">\n");
                    subs[i] = subs[i].Substring(0, subs[i].IndexOf(">\n") - 1);
                }
                
                
                response.Close();
                readStream.Close();

            }

        }
        */

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
