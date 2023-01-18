using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PITON;
using System.Data.SqlClient;

namespace PITON
{
    public partial class frmTest : Form
    {

        public int dbIndex;
        private string dbName;
        public int flag;

        public frmTest()
        {
            InitializeComponent();
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();
        }


        private void btClose_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
            dbIndex = -1;
        }

        private void MySelect()
        {
            adb.SelectCommand.CommandType = CommandType.StoredProcedure;
            adb.SelectCommand.CommandTimeout = 900;
            adb.SelectCommand.CommandText = dbName;
            adb.SelectCommand.Connection = Conn;
            dsTest1.Clear();

            try
            {
                adb.Fill(dsTest1);
            }
            catch (SqlException ex)
            { 
                MessageBox.Show(frmTest.ActiveForm,"Ошибка " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private void MyUpdate()
         {
             Cursor = Cursors.WaitCursor;

             switch (dbIndex)
            {
                case 0:
                    this.Text = "Несоответствия в базе Центр";
                    dbName = "TEST_CENTER";
                    break;


                case 1:
                    this.Text = "Несоответствия в базе XYG";
                    dbName = "TEST_XYG";
                    break;


                case 2:
                    this.Text = "Несоответствия в базе Планета стёкол";
                    dbName = "TEST_PLANETA";
                    break;

                case 3:
                    this.Text = "Несоответствия в базе Пилкинтон";
                    dbName = "TEST_PILKINGTON";
                    break;

                case 4:
                    this.Text = "Несоответствия в базе АВТОХЕЛП";
                    dbName = "TEST_AVTOHELP";
                    break;

                    /*
                case 6:
                    this.Text = "Несоответствия в базе PILKINTON ФИНЛЯНДИЯ";
                    dbName = "TEST_PILKIN_FINLAND";
                    break;


                case 7:
                    this.Text = "Несоответствия в базе Бор-Спринтекс";
                    dbName = "TEST_SPLINTEX";
                    break;

                    */

                case 5:
                    this.Text = "Несоответствия с базой GLASS 2000";
                    dbName = "TEST_2000";
                    break;

                case 6:
                    this.Text = "Несоответствия с базой Sekurit";
                    dbName = "TEST_SEKURIT";
                    break;

                    /*
                case 10:
                    this.Text = "Несоответствия с базой ОЛИМПИЯ";
                    dbName = "TEST_OLIMPIA"; 
                    break;
                    */
                case 7:
                    this.Text = "Несоответствия с  базой LEMART АВТО";
                    dbName = "TEST_LEMART";
                    break;

                case 8:
                    this.Text = "Несоответствия с  базой TEST_BENSON";
                    dbName = "TEST_BENSON";
                    break;

            }

             MySelect();
             flag = 1;
             Cursor = Cursors.Default;
         }

        private void btnRefresh_MouseUp(object sender, MouseEventArgs e)
        {
              MyUpdate();
        }


        private void frmTest_Load(object sender, EventArgs e)
        {
              MyUpdate();
        }



        private void frmTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbIndex = -1;
        }

    }
}