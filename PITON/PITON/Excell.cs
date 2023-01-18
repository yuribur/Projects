using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Exc = Microsoft.Office.Interop.Excel;

namespace PITON
{
    class Excell
    {
       // const string p1 = "onc";
       // const string p2 = "15454";

        Exc.Application xlsExcel;
        Exc.Workbook xlsBook;    //Книга
        Exc.Worksheet xlsSheet;  //Таблица
        public int RowCount;

        public void xlsLoad(string path, int sheetNumber)
        {
            xlsExcel = new Exc.Application();
            xlsBook = xlsExcel.Workbooks.Open(path, 0, false, 5, "", "", false, Exc.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            xlsSheet = (Exc.Worksheet)xlsBook.Sheets[sheetNumber];
            RowCount = xlsSheet.Cells.SpecialCells(Exc.XlCellType.xlCellTypeLastCell).Row;
        }


        // cell - это номер ячейки в
        // стандартном Excel формате
        // Например A1

        public string GetCell(string cell)
        {
            Exc.Range range = xlsSheet.get_Range(cell);
            return range.Text.ToString();
        }
        public void SetCell(string cell, string value)
        {
            Exc.Range range = xlsSheet.get_Range(cell);
            range.Value = value;
        }


        public void xlsClose()
        {
            xlsExcel.Quit();
        }

        public void Save()
        {
            xlsBook.Save();
        }

        public void CreateTab()
        {
            xlsExcel = new Exc.Application();
            xlsExcel.Workbooks.Add();
            
            xlsExcel.Range["A1"].Value = "код 1С";
            xlsExcel.Range["B1"].Value = "Наименование";
            xlsExcel.Range["C1"].Value = "Еврокод";
            xlsExcel.Range["D1"].Value = "Цена";
            xlsExcel.Range["E1"].Value = "Количество";
            xlsExcel.Range["F1"].Value = "Год";
            xlsExcel.Range["G1"].Value = "Производитель";

            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[SN_ECXEL]"; // В БАЗЕ ПРОЦЕДУРА
            cmd.CommandTimeout = 3000;

            Con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            int row = 1;

            while ( dr.Read())
            {
                row++;

                xlsExcel.Range["A" + row].Value = dr[0].ToString();
                xlsExcel.Range["B" + row].Value = dr[1];
                xlsExcel.Range["C" + row].Value = dr[2];
               // xlsExcel.Range["D" + row].Value = dr[3];
               // xlsExcel.Range["E" + row].Value = dr[4];
               // xlsExcel.Range["F" + row].Value = dr[5];
               // xlsExcel.Range["G" + row].Value = dr[6];
            }

            Con.Close();
            xlsExcel.Visible = true;
        }
    }
}
