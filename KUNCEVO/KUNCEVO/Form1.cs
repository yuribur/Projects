using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace KUNCEVO
{
    public partial class Form1 : Form
    {
        object misValue = System.Reflection.Missing.Value;
        private Excel.Application xlApp;
        private Excel.Workbook xlWorkBook;
        private Excel.Worksheet xlWorkSheet;

        public Form1()
        {
            InitializeComponent();
            
            Configuration config = ConfigurationManager.OpenExeConfiguration(
                System.Reflection.Assembly.GetExecutingAssembly().Location);

            ConnectionStringsSection section =
                 config.GetSection("connectionStrings") as ConnectionStringsSection;

            if (!section.SectionInformation.IsProtected)
            {
                // выполняем шифрование секции
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                config.Save();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // this.Visible = false;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            string SaveFilePath = @"D:\Cloud\Kuncevo.xls";
            if (File.Exists(SaveFilePath))
                File.Delete(SaveFilePath);



            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlApp.Range["A1"].Value = "код 1С";
            xlApp.Range["B1"].Value = "Наименование";
            xlApp.Range["C1"].Value = "Еврокод";
            xlApp.Range["D1"].Value = "Цена";
            xlApp.Range["E1"].Value = "Количество";
            xlApp.Range["F1"].Value = "Год";
            xlApp.Range["G1"].Value = "Производитель";


            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = "SELECT  * FROM KUNCEVO ORDER BY EUROCODE";
            cmd.CommandType = CommandType.Text;
            Con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            int row = 1;

            while (dr.Read())
            {
                row++;

                xlApp.Range["A" + row].Value = dr[0].ToString();
                xlApp.Range["B" + row].Value = dr[1];
                xlApp.Range["C" + row].Value = dr[2];
                xlApp.Range["D" + row].Value = dr[3];
                xlApp.Range["E" + row].Value = dr[4];
                xlApp.Range["F" + row].Value = dr[5];
                xlApp.Range["G" + row].Value = dr[6];
            }

            Con.Close();

            xlWorkBook.SaveAs(SaveFilePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            

            this.Close();
        }
    }
}
