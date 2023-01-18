using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace PITON
{
    public partial class frmMain : Form
    {
        public string Error_Msq;
        public int Error_Code;

        public string str_provider = "provider=Microsoft.Jet.OLEDB.4.0;data source={0};Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";
        //public string str_provider = "provider=Microsoft.ACE.OLEDB.12.0;data source={0};Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

        bool oper = true;
        string prev_model;
        string prev_marka;
        //Int16 Catalog_idx; // выбранный каталог

        int[] chk_summ;
        int[] cur_chk_summ;

        Guid guide;
        DateTime starttime;


        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        };

        [DllImport("kernel32.dll")]
        public static extern int SetSystemTime(ref SYSTEMTIME lpSystemTime);

        frmAnalog Analog;
        frmTest Test;
        frmAccord fa;
        frmPhoto fp;
        frmDD fdd;
        frmInfo fi;
        frmSize fs;

        public bool flagSpy;

        private int id_memo;

        //** EUROPA

        Hashtable htSPES;
        IEnumerator enumer;
        public string richNaimUpd;
        string Body;
        string Side;
        bool record_status;
        public string SQLconnection;

        bool current_option; // false = режим обычный, true= обработка

        SqlParameter p_VER;
        SqlParameter p_euro;
        SqlParameter p_антенна_A_A;
        SqlParameter p_правыйРуль_B_A;
        SqlParameter p_местоКамеры_C_A;
        SqlParameter p_gPS_G_A;
        SqlParameter p_обогрев_H_A;
        SqlParameter p_обогрев_F_A;
        SqlParameter p_tV_антенна_J_A;
        SqlParameter p_местоДД_M_A;
        SqlParameter p_окно_ДД_P_A;
        SqlParameter p_крепеж_W_A;
        SqlParameter p_инкапсуляция_Z_A;
        SqlParameter p_леваяПоловина_L_A;
        SqlParameter p_праваяПоловина_R_A;
        SqlParameter p_VINокно_V_A;
        SqlParameter p_дисплей_U_A;
        SqlParameter p_водооталк_N_A;
        SqlParameter p_датчикТумана_O_A;
        SqlParameter p_comDD;
        SqlParameter p_comSTRIP;
        SqlParameter p_антенна_A_B;
        SqlParameter p_стопсигнал_B_B;
        SqlParameter p_инкапсуляция_Z_B;
        SqlParameter p_стеклопакет_D_B;
        SqlParameter p_крепеж_W_B;
        SqlParameter p_триплекс_K_B;
        SqlParameter p_vINокно_V_B;
        SqlParameter p_tV_антенна_J_B;
        SqlParameter p_gPS_G_B;
        SqlParameter p_topBand_T_B;
        SqlParameter p_безОбогрева_U_B;
        SqlParameter p_верхнее_Y_B;
        SqlParameter p_открывающееся_O_B;
        SqlParameter p_проводСигнализации_X_B;
        SqlParameter p_водоотталкивающее_N_B;
        SqlParameter p_аварОповещение_M_B;
        SqlParameter p_антеннаТелефона_P_B;
        SqlParameter p_выдвигающаясяАнтенна_Q_B;
        SqlParameter p_леваяПоловина_L_B;
        SqlParameter p_праваяПоловина_R_B;
        SqlParameter p_центральнаяЧасть_C_B;
        SqlParameter p_рамкаСподвИнеподвСтеклом_S_B;
        SqlParameter p_tV_антенна_J_C;
        SqlParameter p_подвижное_S_C;
        SqlParameter p_открывающееся_O_C;
        SqlParameter p_инкапсуляция_Z_C;
        SqlParameter p_крепеж_W_C;
        SqlParameter p_триплекс_K_C;
        SqlParameter p_антенна_A_C;
        SqlParameter p_обогрев_H_C;
        SqlParameter p_VIN_V_C;
        SqlParameter p_подогревАнтенны_P_C;
        SqlParameter p_верхнее_U_C;
        SqlParameter p_gPS_G_C;
        SqlParameter p_выдвигающаясяАнтенна_Q_C;
        SqlParameter p_стеклопакет_D_C;
        SqlParameter p_водоотталкивающее_N_C;
        SqlParameter p_проводСигнализации_X_C;
        SqlParameter p_открываемоеЕлектрически_E_C;
        SqlParameter p_фиксаторОткрывания_T_C;
        SqlParameter p_рамкаСподвИнеподвСтеклом_F_C;
        SqlParameter p_Отверстий;
        SqlParameter p_Комментарий;
        SqlParameter p_H3;
        SqlParameter p_H5;
        SqlParameter p_S2;
        SqlParameter p_S4;
        SqlParameter p_S4L;
        SqlParameter p_S6;
        SqlParameter p_E3;
        SqlParameter p_E5;
        SqlParameter p_C2;
        SqlParameter p_C4;
        SqlParameter p_R3;
        SqlParameter p_R5;
        SqlParameter p_R5L;
        SqlParameter p_L2;
        SqlParameter p_L4;
        SqlParameter p_LIFTBACK;
        SqlParameter p_T2;
        SqlParameter p_V2;
        SqlParameter p_V3;
        SqlParameter p_V3L;
        SqlParameter p_V4;
        SqlParameter p_V4L;
        SqlParameter p_V5;
        SqlParameter p_V5L;
        SqlParameter p_P2;
        SqlParameter p_P4;
        SqlParameter p_M3;
        SqlParameter p_M3L;
        SqlParameter p_M4;
        SqlParameter p_M4L;
        SqlParameter p_M5;
        SqlParameter p_M5L;
        SqlParameter p_HTOP;
        SqlParameter p_HARDTOP_E5;
        SqlParameter p_comLOCATION;
        SqlParameter p_comCOLOR;
        SqlParameter p_richNaim;
        SqlParameter p_WIDTH;
        SqlParameter p_HEIGHT;
        SqlConnection conn;


        public frmMain()
        {
            chk_summ = new int[2];
            cur_chk_summ = new int[2];

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

            Con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();
            SQLconnection = Con.ConnectionString;
            selModel.Connection.ConnectionString = Con.ConnectionString; // ConfigurationManager.ConnectionStrings["myCon"].ToString();
            selAnalog.Connection.ConnectionString = Con.ConnectionString; // ConfigurationManager.ConnectionStrings["myCon"].ToString();

            Error_Msq = "";
            Error_Code = 0;

            Con.Open();

            SqlParameter p = new SqlParameter();
            p.ParameterName = "@BASE";
            p.SqlDbType = SqlDbType.NChar;
            p.Size = 100;
            cmdCHECK_SUM.Parameters.Add(p);

            p.Value = "MARKA";
            chk_summ[0] = (int)cmdCHECK_SUM.ExecuteScalar();

            p.Value = "Model";
            chk_summ[1] = (int)cmdCHECK_SUM.ExecuteScalar();
            Con.Close();

            cur_chk_summ[0] = chk_summ[0];
            cur_chk_summ[1] = chk_summ[1];

        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            guide = Guid.NewGuid();

            string msg = "";

            current_option = false;  // false =режим обычный, true= обработка
            record_status = false;

            try
            {
                Con.Open();
                starttime = DateTime.Now;
                TimeCom.ExecuteNonQuery();
                DateTime dt = (DateTime)TimeCom.Parameters["@dt"].Value;

                st.wYear = (ushort)dt.Year;
                st.wMonth = (ushort)dt.Month;
                st.wDayOfWeek = (ushort)dt.DayOfWeek;
                st.wDay = (ushort)dt.Day;
                st.wHour = (ushort)dt.Hour;

                st.wHour -= (ushort)3;
                st.wMinute = (ushort)dt.Minute;
                st.wSecond = (ushort)dt.Second;
                st.wMilliseconds = (ushort)dt.Millisecond;
                // SetSystemTime(ref st);

                msg = " марки ";
                aMarka.Fill(dsv1.FromMarka);

                msg = " модели ";
                aModel.Fill(dsv1.FromModel);

                msg = " аналоги ";
                aNalogs.Fill(dsv1.FromAnalogs);
            }
            catch (Exception ex)
            {
                msg += ex.Message;
                MessageBox.Show("Ошибка - открытия: " + msg);
                this.Close();
            }
            Con.Close();

            prev_model = "пусто";

            if (oper == false)
            {
                btnTestBSG.Visible = false;
                btnTestFYG.Visible = false;
                btnTestXYG.Visible = false;
                toolStripSeparator2.Visible = false;
                btnMarka.Visible = false;
                toolStripSeparator5.Visible = false;
                btnNewModel.Visible = false;
                btnEditModel.Visible = false;
                btnDropModel.Visible = false;
                btnAnalog.Visible = false;
                toolStripSplitButton1.Visible = false;
                btnCopyTo.Visible = false;
                btnCopyFrom.Visible = false;
                toolStripSeparator1.Visible = false;
                btnPhoto.Visible = false;
                btnDD.Visible = false;
                updButtons.Visible = false;
            }

            p_VER = new SqlParameter();
            p_VER.ParameterName = "@VER";
            p_VER.SqlDbType = SqlDbType.Char;
            p_VER.Size = 1;
            cmd.Parameters.Add(p_VER);

            p_euro = new SqlParameter();
            p_euro.ParameterName = "@euro";
            p_euro.SqlDbType = SqlDbType.VarChar;
            p_euro.Size = 50;
            cmd.Parameters.Add(p_euro);

            p_антенна_A_A = new SqlParameter();
            p_антенна_A_A.ParameterName = "@антенна_A_A";
            p_антенна_A_A.SqlDbType = System.Data.SqlDbType.Bit;
            cmd.Parameters.Add(p_антенна_A_A);

            p_правыйРуль_B_A = new SqlParameter();
            p_правыйРуль_B_A.ParameterName = "@правыйРуль_B_A";
            p_правыйРуль_B_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_правыйРуль_B_A);

            p_местоКамеры_C_A = new SqlParameter();
            p_местоКамеры_C_A.ParameterName = "@местоКамеры_C_A";
            p_местоКамеры_C_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_местоКамеры_C_A);

            p_gPS_G_A = new SqlParameter();
            p_gPS_G_A.ParameterName = "@gPS_G_A";
            p_gPS_G_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_gPS_G_A);

            p_обогрев_H_A = new SqlParameter();
            p_обогрев_H_A.ParameterName = "@обогрев_H_A";
            p_обогрев_H_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_обогрев_H_A);

            p_обогрев_F_A = new SqlParameter();
            p_обогрев_F_A.ParameterName = "@обогрев_F_A";
            p_обогрев_F_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_обогрев_F_A);

            p_tV_антенна_J_A = new SqlParameter();
            p_tV_антенна_J_A.ParameterName = "@tV_антенна_J_A";
            p_tV_антенна_J_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_tV_антенна_J_A);

            p_местоДД_M_A = new SqlParameter();
            p_местоДД_M_A.ParameterName = "@местоДД_M_A";
            p_местоДД_M_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_местоДД_M_A);

            p_окно_ДД_P_A = new SqlParameter();
            p_окно_ДД_P_A.ParameterName = "@окно_ДД_P_A";
            p_окно_ДД_P_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_окно_ДД_P_A);

            p_крепеж_W_A = new SqlParameter();
            p_крепеж_W_A.ParameterName = "@крепеж_W_A";
            p_крепеж_W_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_крепеж_W_A);


            p_инкапсуляция_Z_A = new SqlParameter();
            p_инкапсуляция_Z_A.ParameterName = "@инкапсуляция_Z_A";
            p_инкапсуляция_Z_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_инкапсуляция_Z_A);

            p_леваяПоловина_L_A = new SqlParameter();
            p_леваяПоловина_L_A.ParameterName = "@леваяПоловина_L_A";
            p_леваяПоловина_L_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_леваяПоловина_L_A);

            p_праваяПоловина_R_A = new SqlParameter();
            p_праваяПоловина_R_A.ParameterName = "@праваяПоловина_R_A";
            p_праваяПоловина_R_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_праваяПоловина_R_A);

            p_VINокно_V_A = new SqlParameter();
            p_VINокно_V_A.ParameterName = "@VINокно_V_A";
            p_VINокно_V_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_VINокно_V_A);

            p_дисплей_U_A = new SqlParameter();
            p_дисплей_U_A.ParameterName = "@дисплей_U_A";
            p_дисплей_U_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_дисплей_U_A);

            p_водооталк_N_A = new SqlParameter();
            p_водооталк_N_A.ParameterName = "@водооталк_N_A";
            p_водооталк_N_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_водооталк_N_A);

            p_датчикТумана_O_A = new SqlParameter();
            p_датчикТумана_O_A.ParameterName = "@датчикТумана_O_A";
            p_датчикТумана_O_A.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_датчикТумана_O_A);

            p_comDD = new SqlParameter();
            p_comDD.ParameterName = "@comDD";     // ID_SENSOR
            p_comDD.SqlDbType = SqlDbType.VarChar;
            p_comDD.Size = 20;
            cmd.Parameters.Add(p_comDD);

            p_comSTRIP = new SqlParameter();
            p_comSTRIP.ParameterName = "@comSTRIP";
            p_comSTRIP.SqlDbType = SqlDbType.Char;
            p_comSTRIP.Size = 2;
            cmd.Parameters.Add(p_comSTRIP);

            p_антенна_A_B = new SqlParameter();
            p_антенна_A_B.ParameterName = "@антенна_A_B";
            p_антенна_A_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_антенна_A_B);

            p_стопсигнал_B_B = new SqlParameter();
            p_стопсигнал_B_B.ParameterName = "@стопсигнал_B_B";
            p_стопсигнал_B_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_стопсигнал_B_B);


            p_инкапсуляция_Z_B = new SqlParameter();
            p_инкапсуляция_Z_B.SqlDbType = SqlDbType.Bit;
            p_инкапсуляция_Z_B.ParameterName = "@инкапсуляция_Z_B";
            cmd.Parameters.Add(p_инкапсуляция_Z_B);

            p_стеклопакет_D_B = new SqlParameter();
            p_стеклопакет_D_B.SqlDbType = SqlDbType.Bit;
            p_стеклопакет_D_B.ParameterName = "@стеклопакет_D_B";
            cmd.Parameters.Add(p_стеклопакет_D_B);

            p_крепеж_W_B = new SqlParameter();
            p_крепеж_W_B.ParameterName = "@крепеж_W_B";
            p_крепеж_W_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_крепеж_W_B);

            p_триплекс_K_B = new SqlParameter();
            p_триплекс_K_B.ParameterName = "@триплекс_K_B";
            p_триплекс_K_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_триплекс_K_B);

            p_vINокно_V_B = new SqlParameter();
            p_vINокно_V_B.ParameterName = "@vINокно_V_B";
            p_vINокно_V_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_vINокно_V_B);

            p_tV_антенна_J_B = new SqlParameter();
            p_tV_антенна_J_B.ParameterName = "@tV_антенна_J_B";
            p_tV_антенна_J_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_tV_антенна_J_B);

            p_gPS_G_B = new SqlParameter();
            p_gPS_G_B.ParameterName = "@gPS_G_B";
            p_gPS_G_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_gPS_G_B);

            p_topBand_T_B = new SqlParameter();
            p_topBand_T_B.ParameterName = "@topBand_T_B";
            p_topBand_T_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_topBand_T_B);

            p_безОбогрева_U_B = new SqlParameter();
            p_безОбогрева_U_B.ParameterName = "@безОбогрева_U_B";
            p_безОбогрева_U_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_безОбогрева_U_B);

            p_верхнее_Y_B = new SqlParameter();
            p_верхнее_Y_B.ParameterName = "@верхнее_Y_B";
            p_верхнее_Y_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_верхнее_Y_B);

            p_открывающееся_O_B = new SqlParameter();
            p_открывающееся_O_B.ParameterName = "@открывающееся_O_B";
            p_открывающееся_O_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_открывающееся_O_B);

            p_проводСигнализации_X_B = new SqlParameter();
            p_проводСигнализации_X_B.ParameterName = "@проводСигнализации_X_B";
            p_проводСигнализации_X_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_проводСигнализации_X_B);

            p_водоотталкивающее_N_B = new SqlParameter();
            p_водоотталкивающее_N_B.ParameterName = "@водоотталкивающее_N_B";
            p_водоотталкивающее_N_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_водоотталкивающее_N_B);

            p_аварОповещение_M_B = new SqlParameter();
            p_аварОповещение_M_B.ParameterName = "@аварОповещение_M_B";
            p_аварОповещение_M_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_аварОповещение_M_B);

            p_антеннаТелефона_P_B = new SqlParameter();
            p_антеннаТелефона_P_B.ParameterName = "@антеннаТелефона_P_B";
            p_антеннаТелефона_P_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_антеннаТелефона_P_B);

            p_выдвигающаясяАнтенна_Q_B = new SqlParameter();
            p_выдвигающаясяАнтенна_Q_B.ParameterName = "@выдвигающаясяАнтенна_Q_B";
            p_выдвигающаясяАнтенна_Q_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_выдвигающаясяАнтенна_Q_B);

            p_леваяПоловина_L_B = new SqlParameter();
            p_леваяПоловина_L_B.ParameterName = "@леваяПоловина_L_B";
            p_леваяПоловина_L_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_леваяПоловина_L_B);

            p_праваяПоловина_R_B = new SqlParameter();
            p_праваяПоловина_R_B.ParameterName = "@праваяПоловина_R_B";
            p_праваяПоловина_R_B.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_праваяПоловина_R_B);

            p_центральнаяЧасть_C_B = new SqlParameter();
            p_центральнаяЧасть_C_B.SqlDbType = SqlDbType.Bit;
            p_центральнаяЧасть_C_B.ParameterName = "@центральнаяЧасть_C_B";
            cmd.Parameters.Add(p_центральнаяЧасть_C_B);

            p_рамкаСподвИнеподвСтеклом_S_B = new SqlParameter();
            p_рамкаСподвИнеподвСтеклом_S_B.SqlDbType = SqlDbType.Bit;
            p_рамкаСподвИнеподвСтеклом_S_B.ParameterName = "@рамкаСподвИнеподвСтеклом_S_B";
            cmd.Parameters.Add(p_рамкаСподвИнеподвСтеклом_S_B);

            p_tV_антенна_J_C = new SqlParameter();
            p_tV_антенна_J_C.SqlDbType = SqlDbType.Bit;
            p_tV_антенна_J_C.ParameterName = "@tV_антенна_J_C";
            cmd.Parameters.Add(p_tV_антенна_J_C);

            p_подвижное_S_C = new SqlParameter();
            p_подвижное_S_C.SqlDbType = SqlDbType.Bit;
            p_подвижное_S_C.ParameterName = "@подвижное_S_C";
            cmd.Parameters.Add(p_подвижное_S_C);

            p_открывающееся_O_C = new SqlParameter();
            p_открывающееся_O_C.ParameterName = "@открывающееся_O_C";
            p_открывающееся_O_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_открывающееся_O_C);

            p_инкапсуляция_Z_C = new SqlParameter();
            p_инкапсуляция_Z_C.ParameterName = "@инкапсуляция_Z_C";
            p_инкапсуляция_Z_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_инкапсуляция_Z_C);

            p_крепеж_W_C = new SqlParameter();
            p_крепеж_W_C.ParameterName = "@крепеж_W_C";
            p_крепеж_W_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_крепеж_W_C);

            p_триплекс_K_C = new SqlParameter();
            p_триплекс_K_C.ParameterName = "@триплекс_K_C";
            p_триплекс_K_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_триплекс_K_C);

            p_антенна_A_C = new SqlParameter();
            p_антенна_A_C.SqlDbType = SqlDbType.Bit;
            p_антенна_A_C.ParameterName = "@антенна_A_C";
            cmd.Parameters.Add(p_антенна_A_C);

            p_обогрев_H_C = new SqlParameter();
            p_обогрев_H_C.ParameterName = "@обогрев_H_C";
            p_обогрев_H_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_обогрев_H_C);

            p_VIN_V_C = new SqlParameter();
            p_VIN_V_C.ParameterName = "@VIN_V_C";
            p_VIN_V_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_VIN_V_C);

            p_подогревАнтенны_P_C = new SqlParameter();
            p_подогревАнтенны_P_C.SqlDbType = SqlDbType.Bit;
            p_подогревАнтенны_P_C.ParameterName = "@подогревАнтенны_P_C";
            cmd.Parameters.Add(p_подогревАнтенны_P_C);

            p_верхнее_U_C = new SqlParameter();
            p_верхнее_U_C.ParameterName = "@верхнее_U_C";
            p_верхнее_U_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_верхнее_U_C);

            p_gPS_G_C = new SqlParameter();
            p_gPS_G_C.SqlDbType = SqlDbType.Bit;
            p_gPS_G_C.ParameterName = "@gPS_G_C";
            cmd.Parameters.Add(p_gPS_G_C);

            p_выдвигающаясяАнтенна_Q_C = new SqlParameter();
            p_выдвигающаясяАнтенна_Q_C.ParameterName = "@выдвигающаясяАнтенна_Q_C";
            p_выдвигающаясяАнтенна_Q_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_выдвигающаясяАнтенна_Q_C);

            p_стеклопакет_D_C = new SqlParameter();
            p_стеклопакет_D_C.ParameterName = "@стеклопакет_D_C";
            p_стеклопакет_D_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_стеклопакет_D_C);

            p_водоотталкивающее_N_C = new SqlParameter();
            p_водоотталкивающее_N_C.ParameterName = "@водоотталкивающее_N_C";
            p_водоотталкивающее_N_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_водоотталкивающее_N_C);

            p_проводСигнализации_X_C = new SqlParameter();
            p_проводСигнализации_X_C.ParameterName = "@проводСигнализации_X_C";
            p_проводСигнализации_X_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_проводСигнализации_X_C);

            p_открываемоеЕлектрически_E_C = new SqlParameter();
            p_открываемоеЕлектрически_E_C.ParameterName = "@открываемоеЕлектрически_E_C";
            p_открываемоеЕлектрически_E_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_открываемоеЕлектрически_E_C);

            p_фиксаторОткрывания_T_C = new SqlParameter();
            p_фиксаторОткрывания_T_C.ParameterName = "@фиксаторОткрывания_T_C";
            p_фиксаторОткрывания_T_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_фиксаторОткрывания_T_C);

            p_рамкаСподвИнеподвСтеклом_F_C = new SqlParameter();
            p_рамкаСподвИнеподвСтеклом_F_C.ParameterName = "@рамкаСподвИнеподвСтеклом_F_C";
            p_рамкаСподвИнеподвСтеклом_F_C.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_рамкаСподвИнеподвСтеклом_F_C);

            p_Отверстий = new SqlParameter();
            p_Отверстий.ParameterName = "@Отверстий";
            p_Отверстий.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p_Отверстий);

            p_Комментарий = new SqlParameter();
            p_Комментарий.ParameterName = "@Комментарий";
            p_Комментарий.SqlDbType = SqlDbType.VarChar;
            p_Комментарий.Size = 50;
            cmd.Parameters.Add(p_Комментарий);

            p_H3 = new SqlParameter();
            p_H3.ParameterName = "@H3";
            p_H3.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_H3);

            p_H5 = new SqlParameter();
            p_H5.ParameterName = "@H5";
            p_H5.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_H5);

            p_S2 = new SqlParameter();
            p_S2.ParameterName = "@S2";
            p_S2.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_S2);

            p_S4 = new SqlParameter();
            p_S4.ParameterName = "@S4";
            p_S4.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_S4);

            p_S4L = new SqlParameter();
            p_S4L.ParameterName = "@S4L";
            p_S4L.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_S4L);

            p_S6 = new SqlParameter();
            p_S6.ParameterName = "@S6";
            p_S6.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_S6);

            p_E3 = new SqlParameter();
            p_E3.ParameterName = "@E3";
            p_E3.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_E3);

            p_E5 = new SqlParameter();
            p_E5.ParameterName = "@E5";
            p_E5.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_E5);

            p_C2 = new SqlParameter();
            p_C2.ParameterName = "@C2";
            p_C2.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_C2);

            p_C4 = new SqlParameter();
            p_C4.ParameterName = "@C4";
            p_C4.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_C4);

            p_R3 = new SqlParameter();
            p_R3.ParameterName = "@R3";
            p_R3.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_R3);

            p_R5 = new SqlParameter();
            p_R5.ParameterName = "@R5";
            p_R5.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_R5);

            p_R5L = new SqlParameter();
            p_R5L.ParameterName = "@R5L";
            p_R5L.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_R5L);

            p_L2 = new SqlParameter();
            p_L2.ParameterName = "@L2";
            p_L2.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_L2);

            p_L4 = new SqlParameter();
            p_L4.ParameterName = "@L4";
            p_L4.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_L4);

            p_LIFTBACK = new SqlParameter();
            p_LIFTBACK.ParameterName = "@LIFTBACK";
            p_LIFTBACK.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_LIFTBACK);

            p_T2 = new SqlParameter();
            p_T2.ParameterName = "@T2";
            p_T2.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_T2);

            p_V2 = new SqlParameter();
            p_V2.ParameterName = "@V2";
            p_V2.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_V2);

            p_V3 = new SqlParameter();
            p_V3.ParameterName = "@V3";
            p_V3.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_V3);

            p_V3L = new SqlParameter();
            p_V3L.ParameterName = "@V3L";
            p_V3L.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_V3L);

            p_V4 = new SqlParameter();
            p_V4.ParameterName = "@V4";
            p_V4.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_V4);

            p_V4L = new SqlParameter();
            p_V4L.ParameterName = "@V4L";
            p_V4L.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_V4L);

            p_V5 = new SqlParameter();
            p_V5.ParameterName = "@V5";
            p_V5.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_V5);

            p_V5L = new SqlParameter();
            p_V5L.ParameterName = "@V5L";
            p_V5L.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_V5L);

            p_P2 = new SqlParameter();
            p_P2.ParameterName = "@P2";
            p_P2.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_P2);

            p_P4 = new SqlParameter();
            p_P4.ParameterName = "@P4";
            p_P4.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_P4);

            p_M3 = new SqlParameter();
            p_M3.ParameterName = "@M3";
            p_M3.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_M3);

            p_M3L = new SqlParameter();
            p_M3L.ParameterName = "@M3L";
            p_M3L.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_M3L);

            p_M4 = new SqlParameter();
            p_M4.ParameterName = "@M4";
            p_M4.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_M4);

            p_M4L = new SqlParameter();
            p_M4L.ParameterName = "@M4L";
            p_M4L.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_M4L);

            p_M5 = new SqlParameter();
            p_M5.ParameterName = "@M5";
            p_M5.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_M5);

            p_M5L = new SqlParameter();
            p_M5L.ParameterName = "@M5L";
            p_M5L.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_M5L);

            p_HTOP = new SqlParameter();
            p_HTOP.ParameterName = "@HTOP";
            p_HTOP.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_HTOP);

            p_HARDTOP_E5 = new SqlParameter();
            p_HARDTOP_E5.ParameterName = "@HARDTOPE5";
            p_HARDTOP_E5.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(p_HARDTOP_E5);

            p_comLOCATION = new SqlParameter();
            p_comLOCATION.ParameterName = "@comLOCATION";
            p_comLOCATION.SqlDbType = SqlDbType.Char;
            p_comLOCATION.Size = 3;
            cmd.Parameters.Add(p_comLOCATION);

            p_comCOLOR = new SqlParameter();
            p_comCOLOR.ParameterName = "@comCOLOR";
            p_comCOLOR.SqlDbType = SqlDbType.Char;
            p_comCOLOR.Size = 3;
            cmd.Parameters.Add(p_comCOLOR);


            p_richNaim = new SqlParameter();
            p_richNaim.SqlDbType = SqlDbType.Char;
            p_richNaim.ParameterName = "@НАИМЕНОВАНИЕ";
            p_richNaim.Size = 500;
            cmd.Parameters.Add(p_richNaim);

            p_WIDTH = new SqlParameter();
            p_WIDTH.SqlDbType = SqlDbType.Int;
            p_WIDTH.ParameterName = "@WIDTH";
            cmd.Parameters.Add(p_WIDTH);

            p_HEIGHT = new SqlParameter();
            p_HEIGHT.SqlDbType = SqlDbType.Int;
            p_HEIGHT.ParameterName = "@HEIGHT";
            cmd.Parameters.Add(p_HEIGHT);

            //current_option = false;  // false =режим обычный, true= обработка
            record_status = false;

            richNaimUpd = String.Empty;

            htSPES = new Hashtable(100);

            aSPEC.SelectCommand.Connection.ConnectionString = SQLconnection;
            aSPEC.Fill(dsv1.Спецификации);

            for (int i = 0; i < dsv1.Спецификации.Rows.Count; i++)
            {
                string id_char = dsv1.Спецификации.Rows[i]["id_char"].ToString();
                string param = dsv1.Спецификации.Rows[i]["Спецификация"].ToString();
                htSPES[id_char] = param;
            }

            Cursor = Cursors.WaitCursor;

            aSensor.SelectCommand.Connection.ConnectionString = SQLconnection;
            aSensor.Fill(dsv1.SENSOR);

            aCHARAC.SelectCommand.Connection.ConnectionString = SQLconnection;
            aCHARAC.Fill(dsv1.ХАРАКТЕРИСТИКИ);

            aCOLORS.SelectCommand.Connection.ConnectionString = SQLconnection;
            aCOLORS.Fill(dsv1.COLORS);

            aSTRIP.SelectCommand.Connection.ConnectionString = SQLconnection;
            aSTRIP.Fill(dsv1.STRIP);

            aLOCATION.SelectCommand.Connection.ConnectionString = SQLconnection;
            aLOCATION.Fill(dsv1.LOCATION);

            Cursor = Cursors.Default;

            conn = new SqlConnection();
            conn.ConnectionString = SQLconnection;
            conn.Open();
            cmd.Connection = conn;

        }

        private void btnAnalog_MouseUp(object sender, MouseEventArgs e)
        {
            MainTimer.Enabled = false;
            int k1 = this.BindingContext[dsv1, "FromMarka"].Position;
            string id_marka = dsv1.Tables["FromMarka"].Rows[k1]["id_marka"].ToString();

            int k2 = this.BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position;
            DataRow[] dr = dsv1.Tables["FromMarka"].Rows[k1].GetChildRows("FromMarka_FromModel");
            string id_model = dr[k2]["id_model"].ToString();

            Analog = new frmAnalog();
            Analog.pos_marka = this.BindingContext[dsv1, "FromMarka"].Position;
            Analog.pos_model = this.BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position;
            Analog.dsv2 = dsv1;

            Analog.ShowDialog();

            bool Option = Analog.Option.Checked;

            int new_id_memo = Analog.new_id_memo;  // получили значение ссыли из Analog

            Analog.Dispose();

            if (new_id_memo != 0)  // если не 0 то обновить id_memo
            {
                updAnalog.Parameters["@id_model"].Value = id_model;
                updAnalog.Parameters["@id_memo"].Value = new_id_memo;
                updAnalog.Parameters["@OPTION"].Value = Option;  // РЕЖИМ ОБНОВЛЕНИЯ

                // обновляем модель в базе
                Con.Open();
                updAnalog.ExecuteNonQuery();
                Con.Close();

                dsv1.FromAnalogs.Clear();
                dsv1.FromModel.Clear();
                aNalogs.Fill(dsv1);
                aModel.Fill(dsv1);

                // возвращаемся на начальную позицию для просмотра
                for (k1 = 0; k1 < dsv1.Tables["FromMarka"].Rows.Count; k1++)
                {
                    if (id_marka == dsv1.Tables["FromMarka"].Rows[k1]["id_marka"].ToString())
                    {
                        this.BindingContext[dsv1, "FromMarka"].Position = k1;
                        break;
                    }
                }

                dr = dsv1.Tables["FromMarka"].Rows[k1].GetChildRows("FromMarka_FromModel");
                for (k2 = 0; k2 < dr.Length; k2++)
                {
                    if (id_model == dr[k2]["id_model"].ToString())
                    {
                        this.BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position = k2;
                        break;
                    }
                }

                Con.Close();
                MainTimer.Enabled = true; // обновление включено
            }
        }

        private void btnPhoto_MouseUp(object sender, MouseEventArgs e)
        {
            int cur_row = gModel.FirstDisplayedScrollingRowIndex;

            MainTimer.Enabled = false;
            fp = new frmPhoto();

            fp.tId_memo = Convert.ToInt16(lbl_Id_memo.Text);
            if (fp.tId_memo != 0)
            {
                fp.lbl_photo = lbl_photo.Text;
                fp.ShowDialog();
            }

            if ((fp.flagDelete == true) || (fp.flagUpdate = true))
            {
                int k1 = this.BindingContext[dsv1, "FromMarka"].Position;
                int k2 = this.BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position;
                dsv1.FromModel.Clear();
                aModel.Fill(dsv1);
                BindingContext[dsv1, "FromMarka"].Position = k1;
                BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position = k2;
            }

            gModel.FirstDisplayedScrollingRowIndex = cur_row;
            fp.Dispose();
            MainTimer.Enabled = true;

        }

        private void btnTest_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MainTimer.Enabled = false;
                
                if (((Test == null) || (Test.dbIndex == -1)) && tabGlass.SelectedIndex < 13)
                {
                    Cursor = Cursors.WaitCursor;
                    Test = new frmTest();
                    Test.flag = 0;
                    Test.dbIndex = tabGlass.SelectedIndex;
                    Test.Show();
                    Cursor = Cursors.Default;
                }
                MainTimer.Enabled = true;
            }
        }

        private void NewMarka_MouseUp(object sender, MouseEventArgs e)
        {
            MainTimer.Enabled = false;

            frmMarka fm = new frmMarka();
            fm.ShowDialog();

            if (fm.DialogResult == DialogResult.OK)
            {
                Con.Open();
                InsMarka.Parameters["@marka"].Value = fm.txtMarka.Text.Trim();
                InsMarka.ExecuteNonQuery();

                dsv1.FromMarka.Clear();
                dsv1.FromModel.Clear();
                dsv1.FromAnalogs.Clear();

                aMarka.Fill(dsv1);
                aModel.Fill(dsv1);
                aNalogs.Fill(dsv1);
                Con.Close();

                int count = dsv1.Tables["FromMarka"].Rows.Count;

                for (int c = 0; c < count; c++)
                {
                    string s = dsv1.Tables["FromMarka"].Rows[c]["Marka"].ToString();
                    if (fm.txtMarka.Text.Trim() == dsv1.Tables["FromMarka"].Rows[c]["Marka"].ToString())
                    {
                        this.BindingContext[dsv1, "FromMarka"].Position = c;
                        break;
                    }
                }

                fm.Dispose();
            }

            MainTimer.Enabled = true;
        }

        private void EditMarka_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MainTimer.Enabled = false;

                frmMarka fm = new frmMarka();

                int k1 = this.BindingContext[dsv1, "FromMarka"].Position;
                DataRow dr = dsv1.Tables["FromMarka"].Rows[k1];
                int id_marka = Convert.ToInt16(dr["id_marka"].ToString());
                fm.txtMarka.Text = dr["marka"].ToString();
                fm.ShowDialog();

                if (fm.DialogResult == DialogResult.OK)
                {
                    Con.Open();
                    UpdateMarka.Parameters["@id_marka"].Value = id_marka;
                    UpdateMarka.Parameters["@marka"].Value = fm.txtMarka.Text;
                    UpdateMarka.ExecuteNonQuery();
                    Con.Close();

                    dr["marka"] = fm.txtMarka.Text;
                }

                fm.Dispose();
                MainTimer.Enabled = true;
            }
        }

        private void DropMarka_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MainTimer.Enabled = false;

                frmMarka fm = new frmMarka();
                fm.label1.Text = "Удаляется марка";
                int k1 = this.BindingContext[dsv1, "FromMarka"].Position;
                DataRow dr = dsv1.Tables["FromMarka"].Rows[k1];
                int id_marka = Convert.ToInt16(dr["id_marka"].ToString());
                fm.txtMarka.Text = dr["marka"].ToString();
                fm.txtMarka.ReadOnly = true;

                int km = this.BindingContext[dsv1, "FromMarka"].Position;
                // число дочерних строк равно kmodels
                DataRow[] dro = dsv1.Tables["FromMarka"].Rows[km].GetChildRows("FromMarka_FromModel");
                int kmodels = dro.Length;

                if (kmodels > 0)
                {
                    fm.btnOk.Enabled = false;
                    fm.label1.Text = "Нельзя удалить марку, пока у неё есть модели.";
                }

                fm.ShowDialog();
                fm.Dispose();


                if (fm.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        Con.Open();
                        DeleteMarka.Parameters["@id_marka"].Value = id_marka;
                        DeleteMarka.ExecuteNonQuery();
                        dsv1.Tables["FromMarka"].Rows.Remove(dr);
                    }

                    catch (SqlException ex)
                    {
                        if (ex.ErrorCode < 0)
                        {
                            MessageBox.Show(this, "Нельзя удалить марку, пока у неё есть модели.",
                                           "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    finally
                    {
                        Con.Close();
                    }
                }
                MainTimer.Enabled = true;
            }
        }

        private void NewModel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MainTimer.Enabled = false;
                frmModel mo = new frmModel();
                mo.tEuro.Text = "";
                mo.tModel.Text = "";
                mo.tComment.Text = "";
                mo.tEurocode.Text = "";
                mo.web_name.Text = "";
                mo.tXYGcode.Text = "";
                mo.Web_name2.Text = "";

                MainTimer.Enabled = false;
                mo.ShowDialog();


                if (mo.DialogResult == DialogResult.OK)
                {
                    InsertModel.Parameters["@eurom"].Value = Trunc_Str(mo.tEurocode);
                    InsertModel.Parameters["@web_name"].Value = mo.web_name.Text;
                    InsertModel.Parameters["@xygm"].Value = Trunc_Str(mo.tXYGcode);

                    int k8 = this.BindingContext[dsv1, "FromMarka"].Position;
                    DataRow dr = dsv1.Tables["FromMarka"].Rows[k8];

                    InsertModel.Parameters["@Id_marka"].Value = Convert.ToInt16(dr["Id_marka"].ToString());
                    InsertModel.Parameters["@Model"].Value = mo.tModel.Text;
                    InsertModel.Parameters["@euro"].Value = mo.tEuro.Text;
                    InsertModel.Parameters["@Comment"].Value = mo.tComment.Text;
                    InsertModel.Parameters["@id_memo"].Value = 0;

                    InsertModel.Parameters["@id_model"].Value = 0;
                    InsertModel.Parameters["@result"].Value = 0;
                    InsertModel.Parameters["@Date1"].Value = mo.tDate1.Text;
                    InsertModel.Parameters["@Date2"].Value = mo.tDate2.Text;

                    InsertModel.Parameters["@web_name"].Value = mo.web_name.Text;
                    InsertModel.Parameters["@XYGM"].Value = Trunc_Str(mo.tXYGcode);

                    InsertModel.Parameters["@H3"].Value = (mo.H3.Checked) ? 1 : 0;
                    InsertModel.Parameters["@H5"].Value = (mo.H5.Checked) ? 1 : 0;

                    InsertModel.Parameters["@S2"].Value = (mo.S2.Checked) ? 1 : 0;
                    InsertModel.Parameters["@S4"].Value = (mo.S4.Checked) ? 1 : 0;
                    InsertModel.Parameters["@S4L"].Value = (mo.S4L.Checked) ? 1 : 0;
                    InsertModel.Parameters["@S6"].Value = (mo.S6.Checked) ? 1 : 0;

                    InsertModel.Parameters["@E3"].Value = (mo.E3.Checked) ? 1 : 0;
                    InsertModel.Parameters["@E5"].Value = (mo.E5.Checked) ? 1 : 0;

                    InsertModel.Parameters["@C2"].Value = (mo.C2.Checked) ? 1 : 0;
                    InsertModel.Parameters["@C4"].Value = (mo.C4.Checked) ? 1 : 0;

                    InsertModel.Parameters["@R3"].Value = (mo.R3.Checked) ? 1 : 0;
                    InsertModel.Parameters["@R5"].Value = (mo.R5.Checked) ? 1 : 0;
                    InsertModel.Parameters["@R5L"].Value = (mo.R5L.Checked) ? 1 : 0;

                    InsertModel.Parameters["@L2"].Value = (mo.L2.Checked) ? 1 : 0;
                    InsertModel.Parameters["@L4"].Value = (mo.L4.Checked) ? 1 : 0;

                    InsertModel.Parameters["@LIFTBACK"].Value = (mo.LIFTBACK.Checked) ? 1 : 0;

                    InsertModel.Parameters["@T2"].Value = (mo.T2.Checked) ? 1 : 0;

                    InsertModel.Parameters["@V2"].Value = (mo.V2.Checked) ? 1 : 0;
                    InsertModel.Parameters["@V3"].Value = (mo.V3.Checked) ? 1 : 0;
                    InsertModel.Parameters["@V3L"].Value = (mo.V3L.Checked) ? 1 : 0;
                    InsertModel.Parameters["@V4"].Value = (mo.V4.Checked) ? 1 : 0;
                    InsertModel.Parameters["@V4L"].Value = (mo.V4L.Checked) ? 1 : 0;
                    InsertModel.Parameters["@V5"].Value = (mo.V5.Checked) ? 1 : 0;
                    InsertModel.Parameters["@V5L"].Value = (mo.V5L.Checked) ? 1 : 0;

                    InsertModel.Parameters["@P2"].Value = (mo.P2.Checked) ? 1 : 0;
                    InsertModel.Parameters["@P4"].Value = (mo.P4.Checked) ? 1 : 0;

                    InsertModel.Parameters["@M3"].Value = (mo.M3.Checked) ? 1 : 0;
                    InsertModel.Parameters["@M3L"].Value = (mo.M3L.Checked) ? 1 : 0;
                    InsertModel.Parameters["@M4"].Value = (mo.M4.Checked) ? 1 : 0;
                    InsertModel.Parameters["@M4L"].Value = (mo.M4L.Checked) ? 1 : 0;
                    InsertModel.Parameters["@M5"].Value = (mo.M5.Checked) ? 1 : 0;
                    InsertModel.Parameters["@M5L"].Value = (mo.M5L.Checked) ? 1 : 0;

                    InsertModel.Parameters["@HTOP"].Value = (mo.HTOP.Checked) ? 1 : 0;
                    InsertModel.Parameters["@HARDTOP_E5"].Value = (mo.HARDTOP_E5.Checked) ? 1 : 0;
                    InsertModel.Parameters["@WEB_NAME2"].Value = (mo.Web_name2.Text);


                    Con.Open();
                    InsertModel.ExecuteNonQuery();
                    dsv1.FromModele.Clear();
                    dsv1.FromModel.Clear();
                    dsv1.FromAnalogs.Clear();

                    aModel.Fill(dsv1);
                    aNalogs.Fill(dsv1);

                    Con.Close();

                    SqlParameter p = InsertModel.Parameters["@id_model"];

                    //---- позиционируем ------------
                    int id_model = Convert.ToInt16(p.Value);
                    int km = this.BindingContext[dsv1, "FromMarka"].Position;
                    // число дочерних строк равно 
                    DataRow[] dro = dsv1.Tables["FromMarka"].Rows[km].GetChildRows("FromMarka_FromModel");
                    int pos = 0;
                    while (id_model.ToString() != dro[pos]["id_model"].ToString())
                    {
                        pos++;
                    }
                    this.BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position = pos;
                }

                mo.Dispose();
                MainTimer.Enabled = true;
            }
        }

        private void EditModel_MouseUp(object sender, MouseEventArgs e)
        {
            int rdx = gModel.FirstDisplayedCell.RowIndex;

            if (e.Button == MouseButtons.Left)
            {
                MainTimer.Enabled = false;
                int k1 = this.BindingContext[dsv1, "FromMarka"].Position;
                int k2 = this.BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position;

                if (k2 < 0) goto mimo;

                DataRow[] dr = dsv1.Tables["FromMarka"].Rows[k1].GetChildRows("FromMarka_FromModel");
                selModele.Parameters["@id_memo"].Value = Convert.ToInt16(dr[k2]["id_memo"].ToString());
                selModele.Parameters["@id_model"].Value = Convert.ToInt16(dr[k2]["id_model"].ToString());

                dsv1.FromModele.Clear();
                aModele.Fill(dsv1.FromModele);

                // int id_marka = Convert.ToInt16(dsv1.Tables["FromMarka"].Rows[k1]["Id_marka"].ToString());

                // нашли идентификатор марки

                DataRow dr1 = dsv1.Tables["FromModele"].Rows[0];

                frmModel mo = new frmModel();
                mo.tEuro.Text = dr1["Euro"].ToString();
                mo.tModel.Text = dr1["Model"].ToString();
                mo.web_name.Text = dr1["web_name"].ToString();
                mo.Web_name2.Text = dr1["web_name2"].ToString();
                mo.tDate1.Text = dr1["DATE1"].ToString();
                mo.tDate2.Text = dr1["DATE2"].ToString();
                mo.tComment.Text = dr1["Comment"].ToString();
                mo.lbId_model.Text = dr1["id_model"].ToString();
                mo.lbId_memo.Text = dr1["id_memo"].ToString();

                mo.tEurocode.Text = dsv1.FromModele.Rows[0]["EUROM"].ToString();
                mo.tXYGcode.Text = dsv1.FromModele.Rows[0]["XYGM"].ToString();

                mo.H3.Checked = dr1["H3"].ToString() == "1" ? true : false;
                mo.H5.Checked = dr1["H5"].ToString() == "1" ? true : false;
                mo.S2.Checked = dr1["S2"].ToString() == "1" ? true : false;
                mo.S4.Checked = dr1["S4"].ToString() == "1" ? true : false;
                mo.S4L.Checked = dr1["S4L"].ToString() == "1" ? true : false;
                mo.S6.Checked = dr1["S6"].ToString() == "1" ? true : false;

                mo.E3.Checked = dr1["E3"].ToString() == "1" ? true : false;
                mo.E5.Checked = dr1["E5"].ToString() == "1" ? true : false;

                mo.C2.Checked = dr1["C2"].ToString() == "1" ? true : false;
                mo.C4.Checked = dr1["C4"].ToString() == "1" ? true : false;

                mo.R3.Checked = dr1["R3"].ToString() == "1" ? true : false;
                mo.R5.Checked = dr1["R5"].ToString() == "1" ? true : false;
                mo.R5L.Checked = dr1["R5L"].ToString() == "1" ? true : false;

                mo.T2.Checked = dr1["T2"].ToString() == "1" ? true : false;

                mo.L2.Checked = dr1["L2"].ToString() == "1" ? true : false;
                mo.L4.Checked = dr1["L4"].ToString() == "1" ? true : false;

                mo.LIFTBACK.Checked = dr1["LIFTBACK"].ToString() == "1" ? true : false;

                mo.V2.Checked = dr1["V2"].ToString() == "1" ? true : false;
                mo.V3.Checked = dr1["V3"].ToString() == "1" ? true : false;
                mo.V3L.Checked = dr1["V3L"].ToString() == "1" ? true : false;
                mo.V4.Checked = dr1["V4"].ToString() == "1" ? true : false;
                mo.V4L.Checked = dr1["V4L"].ToString() == "1" ? true : false;
                mo.V5.Checked = dr1["V5"].ToString() == "1" ? true : false;
                mo.V5L.Checked = dr1["V5L"].ToString() == "1" ? true : false;

                mo.P2.Checked = dr1["P2"].ToString() == "1" ? true : false;
                mo.P4.Checked = dr1["P4"].ToString() == "1" ? true : false;

                mo.M3.Checked = dr1["M3"].ToString() == "1" ? true : false;
                mo.M3L.Checked = dr1["M3L"].ToString() == "1" ? true : false;
                mo.M4.Checked = dr1["M4"].ToString() == "1" ? true : false;
                mo.M4L.Checked = dr1["M4L"].ToString() == "1" ? true : false;
                mo.M5.Checked = dr1["M5"].ToString() == "1" ? true : false;
                mo.M5L.Checked = dr1["M5L"].ToString() == "1" ? true : false;

                mo.HTOP.Checked = dr1["HTOP"].ToString() == "1" ? true : false;
                mo.HARDTOP_E5.Checked = dr1["HARDTOPE5"].ToString() == "1" ? true : false;


                mo.ShowDialog();

                if (mo.DialogResult == DialogResult.OK)
                {
                    updModel.Parameters["@EUROM"].Value = Trunc_Str(mo.tEurocode);
                    updModel.Parameters["@web_name"].Value = mo.web_name.Text;
                    updModel.Parameters["@XYGM"].Value = Trunc_Str(mo.tXYGcode);
                    updModel.Parameters["@id_model"].Value = Convert.ToInt16(dr[k2]["Id_model"].ToString());
                    updModel.Parameters["@model"].Value = mo.tModel.Text;
                    updModel.Parameters["@Comment"].Value = mo.tComment.Text;
                    updModel.Parameters["@EURO"].Value = mo.tEuro.Text;
                    updModel.Parameters["@DATE1"].Value = mo.tDate1.Text;
                    updModel.Parameters["@DATE2"].Value = mo.tDate2.Text;
                    updModel.Parameters["@Result"].Value = 0;

                    updModel.Parameters["@H3"].Value = (mo.H3.Checked) ? 1 : 0;
                    updModel.Parameters["@H5"].Value = (mo.H5.Checked) ? 1 : 0;

                    updModel.Parameters["@S2"].Value = (mo.S2.Checked) ? 1 : 0;
                    updModel.Parameters["@S4"].Value = (mo.S4.Checked) ? 1 : 0;
                    updModel.Parameters["@S4L"].Value = (mo.S4L.Checked) ? 1 : 0;
                    updModel.Parameters["@S6"].Value = (mo.S6.Checked) ? 1 : 0;

                    updModel.Parameters["@E3"].Value = (mo.E3.Checked) ? 1 : 0;
                    updModel.Parameters["@E5"].Value = (mo.E5.Checked) ? 1 : 0;

                    updModel.Parameters["@C2"].Value = (mo.C2.Checked) ? 1 : 0;
                    updModel.Parameters["@C4"].Value = (mo.C4.Checked) ? 1 : 0;

                    updModel.Parameters["@R3"].Value = (mo.R3.Checked) ? 1 : 0;
                    updModel.Parameters["@R5"].Value = (mo.R5.Checked) ? 1 : 0;
                    updModel.Parameters["@R5L"].Value = (mo.R5L.Checked) ? 1 : 0;

                    updModel.Parameters["@L2"].Value = (mo.L2.Checked) ? 1 : 0;
                    updModel.Parameters["@L4"].Value = (mo.L4.Checked) ? 1 : 0;

                    updModel.Parameters["@LIFTBACK"].Value = (mo.LIFTBACK.Checked) ? 1 : 0;

                    updModel.Parameters["@T2"].Value = (mo.T2.Checked) ? 1 : 0;

                    updModel.Parameters["@V2"].Value = (mo.V2.Checked) ? 1 : 0;
                    updModel.Parameters["@V3"].Value = (mo.V3.Checked) ? 1 : 0;
                    updModel.Parameters["@V3L"].Value = (mo.V3L.Checked) ? 1 : 0;
                    updModel.Parameters["@V4"].Value = (mo.V4.Checked) ? 1 : 0;
                    updModel.Parameters["@V4L"].Value = (mo.V4L.Checked) ? 1 : 0;
                    updModel.Parameters["@V5"].Value = (mo.V5.Checked) ? 1 : 0;
                    updModel.Parameters["@V5L"].Value = (mo.V5L.Checked) ? 1 : 0;

                    updModel.Parameters["@P2"].Value = (mo.P2.Checked) ? 1 : 0;
                    updModel.Parameters["@P4"].Value = (mo.P4.Checked) ? 1 : 0;

                    updModel.Parameters["@M3"].Value = (mo.M3.Checked) ? 1 : 0;
                    updModel.Parameters["@M3L"].Value = (mo.M3L.Checked) ? 1 : 0;
                    updModel.Parameters["@M4"].Value = (mo.M4.Checked) ? 1 : 0;
                    updModel.Parameters["@M4L"].Value = (mo.M4L.Checked) ? 1 : 0;
                    updModel.Parameters["@M5"].Value = (mo.M5.Checked) ? 1 : 0;
                    updModel.Parameters["@M5L"].Value = (mo.M5L.Checked) ? 1 : 0;

                    updModel.Parameters["@HTOP"].Value = (mo.HTOP.Checked) ? 1 : 0;
                    updModel.Parameters["@HARDTOP_E5"].Value = (mo.HARDTOP_E5.Checked) ? 1 : 0;
                    updModel.Parameters["@WEB_NAME2"].Value = mo.Web_name2.Text;

                    Con.Open();
                    updModel.ExecuteNonQuery();
                    Con.Close();  // обновили modele

                    gModel.CurrentRow.Cells[0].Value = mo.tModel.Text;
                    gModel.CurrentRow.Cells[1].Value = mo.tEuro.Text;

                    dr[k2]["EURO"] = mo.tEuro.Text; // EURO
                    dr[k2]["MODEL"] = mo.tModel.Text; // MODEL
                    dr[k2]["COMMENT"] = mo.tComment.Text;
                    dr[k2]["DATE1"] = mo.tDate1.Text;
                    dr[k2]["DATE2"] = mo.tDate2.Text;
                    dr[k2]["WEB_NAME2"] = mo.Web_name2.Text;

                }

                mo.Dispose();
                gModel.FirstDisplayedScrollingRowIndex = rdx;

            mimo:
                MainTimer.Enabled = true;
            }
        }

        private void btnDeleteModel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MainTimer.Enabled = false;

                frmDelModel fd = new frmDelModel();

                int k1 = this.BindingContext[dsv1, "FromMarka"].Position;
                fd.lbMarka.Text = dsv1.Tables["FromMarka"].Rows[k1]["marka"].ToString();

                int k2 = this.BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position;

                if (k2 < 0) goto mimo;

                DataRow[] dr = dsv1.Tables["FromMarka"].Rows[k1].GetChildRows("FromMarka_FromModel");
                fd.lbModel.Text = dr[k2]["model"].ToString();
                MainTimer.Enabled = false;
                fd.ShowDialog();


                if (fd.DialogResult == DialogResult.OK)
                {
                    int id_model = Convert.ToInt16(dr[k2]["id_model"].ToString());
                    delModel.Parameters["@id_model"].Value = id_model;

                    try
                    {
                        Con.Open();
                        delModel.ExecuteNonQuery();
                        dr[k2].Delete();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка удаления: " + ex.Message);
                    }
                    finally
                    {
                        Con.Close();
                    }
                }

            mimo:
                fd.Dispose();
                MainTimer.Enabled = true;
            }
        }

        private void toolStripButton2_MouseUp(object sender, MouseEventArgs e)
        {

            if (textSearch.Text.Trim() != "")
            {
                tabGlass.SelectedIndex = 12;

                Cursor = Cursors.WaitCursor;
                string parm = textSearch.Text.Trim();
                dsFind1.Clear();
                selCmd.Parameters["@PARM"].Value = "%" + parm + "%";
                aFind.Fill(dsFind1);
                selectBSG.Parameters["@PARM"].Value = "%" + parm + "%";
                selectFYG.Parameters["@PARM"].Value = "%" + parm + "%";
                aBSG.Fill(dsFind1.SEARCH_CATALOG_BSG);
                aFYG.Fill(dsFind1.SEARCH_CATALOG_FYG);

                Cursor = Cursors.Default;
            }
        }

        private void btnExit_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }


        private void btnTestXYG_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (((fa == null) || (fa.GetBase() == "")))
                {
                    MainTimer.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    fa = new frmAccord();
                    fa.flag = 0;
                    fa.SetBase("XYG");
                    fa.Show();
                    Cursor = Cursors.Default;
                    MainTimer.Enabled = true;
                }
            }
        }


        private void btnTestFYG_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((fa == null) || (fa.GetBase() == ""))
                {
                    MainTimer.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    fa = new frmAccord();
                    fa.flag = 0;
                    fa.SetBase("FYG");
                    fa.Show();
                    Cursor = Cursors.Default;
                    MainTimer.Enabled = true;
                }
            }
        }


        private void btnTestBSG_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((fa == null) || (fa.GetBase() == ""))
                {
                    MainTimer.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    fa = new frmAccord();
                    fa.flag = 0;
                    fa.SetBase("BSG");
                    fa.Show();
                    Cursor = Cursors.Default;
                    MainTimer.Enabled = true;
                }
            }
        }


        private void Avtohelp_MouseUp(object sender, MouseEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE AVTOHELP_K";
            cmdp.Connection = sqlCon;

            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\AVTOHELP\AVTOHELP.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT [Номенклатура],[Артикул],[Остаток],[Цена],[Ед],[произв] FROM [Лист1$]";



                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "AVTOHELP_K";

                bc.WriteToServer(dr);
            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице AVTOHELP " + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "PITHON_AVTOHELP";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица AVTOHELP успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице AVTOHELP ");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

        }


        private void Glass2000_MouseUp(object sender, MouseEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE GLASS2000_K";
            cmdp.Connection = sqlCon;


            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\GLASS2000\GLASS2000.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT [Наименование],'' as [Год],[Сканкод],[Еврокод],[Произв],'' as [FYG-код],[Остаток],[Опт],' ' AS [Сропт],' ' AS [Мелкопт],[Размер] FROM [Лист1$]";



                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "GLASS2000_K";

                bc.WriteToServer(dr);
            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице GLASS2000 " + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "PITHON_GLASS2000";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица GLASS2000 успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице GLASS2000 ");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

        }


        private void Mobiscar_MouseUp(object sender, MouseEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE MOBISCAR_K";
            cmdp.Connection = sqlCon;

            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\MOBISCAR\MOBISCAR.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT [Номенклатура],[EURO],[Тип товара],[Полное наименование],[Года выпуска],[Размер],[Характеристика],[Производитель],[Цена],[Свободный остаток] FROM [Лист1$]";

                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "MOBISCAR_K";
                bc.BulkCopyTimeout = 30000;
                bc.WriteToServer(dr);
            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице MOBISCAR " + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "PITHON_MOBISCAR";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица MOBISCAR успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице MOBISCAR ");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

        }


        private void Splintex_MouseUp(object sender, MouseEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE SPLINTEX_K";
            cmdp.Connection = sqlCon;

            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\SPLINTEX\SPLINTEX.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT [наименование],[еврокод],[Код AGC],[год],[год1],[цена],[Высота],[Ширина],[Производитель] FROM [Лист1$]";

                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "SPLINTEX_K";

                bc.WriteToServer(dr);
            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице SPLINTEX " + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "PITHON_SPLINTEX";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица SPLINTEX успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице SPLINTEX ");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

        }


        private void Lemart_MouseUp(object sender, MouseEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE LEMART_K";
            cmdp.Connection = sqlCon;

            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\LEMART\LEMART.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT [Номенклатура] as Наименование,[Количество] as Остаток,[Еврокод],'' as XYGкод,[Размер],[Цена],[Производитель] FROM [Лист1$]";

                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "LEMART_K";
                bc.BulkCopyTimeout = 60000;
                bc.WriteToServer(dr);
            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице LEMART " + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "PITHON_LEMART";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица LEMART успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице LEMART");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

        }


        private void btnBENSON_MouseUp(object sender, MouseEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE BENSON_K";
            cmdp.Connection = sqlCon;

            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\BENSON\BENSON.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT [Номенклатура],[Остаток],[Артикул],[Еврокод],[Цена],[Ед] FROM [Лист1$]";

                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "BENSON_K";
                bc.WriteToServer(dr);

            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице BENSON - " + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "PITHON_BENSON";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица BENSON успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице BENSON");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

        }


        private void Sekurit_MouseUp(object sender, MouseEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE SEKURIT_K";
            cmdp.Connection = sqlCon;

            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\SEKURIT\SEKURIT.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT [Марка],[Номенклатура],[Вид],[Производитель],[Eurocode],[Argis],[мелкий ОПТ],[крупный ОПТ] FROM [Лист1$]";

                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "SEKURIT_K";
                bc.WriteToServer(dr);

            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице SEKURIT - " + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "PITHON_SEKURIT";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица SEKURIT успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице SEKURIT");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

        }


        private void Olimpia_MouseUp(object sender, MouseEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE Олимпия_k";
            cmdp.Connection = sqlCon;

            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\OLIMPIA\Остатки.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT [Артикул],[Еврокод],[Номенклатура],[Вид],[Год],[Размер],[Спецификация]";
                Cmd.CommandText += ",[Характеристика номенклатуры],[Производитель],[Цена],[Количество],' ' AS [EUROCODE]";
                Cmd.CommandText += " ,' ' AS [Наименование],' ' AS [Высота],' ' AS[Ширина]  FROM [Лист1$]";

                //sqlCon.Open();
                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "Олимпия_k";

                bc.WriteToServer(dr);
            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице Остатки " + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "UPDATE_Олимпия";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица OLIMPIA успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице Остатки ");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

        }


        private void Pilkington_MouseUp(object sender, MouseEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE PILKINGTON_NEAR; TRUNCATE TABLE PILKINGTON_FAR; TRUNCATE TABLE PILKINGTON_K";
            cmdp.Connection = sqlCon;

            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\PILKINGTON\PILKINGTON.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT Еврокод,Наименование,Стекло,Производитель,Опт  FROM [МОСКВА$]";

                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "PILKINGTON_NEAR";
                bc.BulkCopyTimeout = 100000;
                bc.WriteToServer(dr);

                //    2-- ДАЛЬНИЙ  СКЛАД

                Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandTimeout = 100000;
                Cmd.CommandText = "SELECT * FROM [дальнийсклад$]";
                dr = Cmd.ExecuteReader();

                bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "PILKINGTON_FAR";
                bc.WriteToServer(dr);
            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице PILKINGTON - " + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "PITHON_PILKINGTON";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица PILKINGTON успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице PILKINGTON");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }
        }


        private void Planeta_MouseUp(object sender, MouseEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE PLANETA_K";
            cmdp.Connection = sqlCon;

            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\PLANETA\PLANETA.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT [№ по каталогу],[производитель],[тип ],[марка автомобиля],[сканкод],[еврокод],[опт],[наличие] FROM [Лист1$]";

                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "PLANETA_K";
                bc.WriteToServer(dr);

            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице PLANETA - " + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "PITHON_PLANETA";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица PLANETA успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице PLANETA");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }

        }


        private void Xyg_MouseUp(object sender, MouseEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Con.ConnectionString;

            SqlCommand cmdp = new SqlCommand();
            cmdp.CommandType = CommandType.Text;
            cmdp.CommandText = "TRUNCATE TABLE XYGR_K";
            cmdp.Connection = sqlCon;

            try
            {
                sqlCon.Open();
                cmdp.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Нет связи с сервером данных");
                return;
            }


            string file_name = @"C:\ПОИСК\XYG\XYG.xls";
            OleDbConnection xlsCon = new OleDbConnection(string.Format(str_provider, file_name));

            try
            {
                xlsCon.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = xlsCon;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "SELECT [Артикул],[ТМЦ],";
                Cmd.CommandText += "[Еврокод] AS Еврокод,[Техинформация],";
                Cmd.CommandText += "[Р - Опт] AS [Опт],[Рязань] AS [Рязань],[Комментарии] FROM [Лист1$]";

                OleDbDataReader dr = Cmd.ExecuteReader();

                SqlBulkCopy bc = new SqlBulkCopy(sqlCon);
                bc.DestinationTableName = "XYGR_K";

                bc.WriteToServer(dr);
            }
            catch (Exception ax)
            {
                MessageBox.Show("Ошибка в таблице XYG" + ax.Message);
                return;
            }
            finally
            {
                xlsCon.Close();
            }

            cmdp.CommandType = CommandType.StoredProcedure;
            cmdp.CommandText = "PITHON_XYGR";
            cmdp.Connection = sqlCon;

            try
            {
                cmdp.ExecuteNonQuery();
                MessageBox.Show("Таблица XYG успешно обновлена");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка преобразования в таблице XYG ");
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }
        }


        private string Trunc_Str(TextBox text_box)
        {
            string rn = "\r\n";
            string result = "";
            string cur_parts = "";
            ArrayList parts = new ArrayList();


            for (int nl = 0; nl < text_box.Lines.Length; nl++)
            {
                parts.Add(text_box.Lines[nl].Trim());
            }

            parts.Sort();

            for (int nl = 0; nl < parts.Count; nl++)
            {

                if ((parts[nl].ToString() != "") & (cur_parts != parts[nl].ToString()))
                {
                    result += ((parts[nl].ToString()).Trim() + rn);
                    cur_parts = parts[nl].ToString();
                }
            }

            return result;
        }


        private void lstMarka_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tabMarkaModel.SelectedIndex = 1;
            }
        }


        private void gModel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tabMarkaModel.SelectedIndex = 0;
            }
        }


        private void tabMarkaModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabGlass.SelectedIndex)
            {
                case 0:
                    btnTest.ToolTipText = "Несоответствия с 1С";
                    btnTest.Enabled = true;
                    break;

                case 1:
                    btnTest.ToolTipText = "Несоответствия с Мобискар";
                    btnTest.Enabled = true;
                    break;

                case 2:
                    btnTest.ToolTipText = "Несоответствия с XYG";
                    btnTest.Enabled = true;
                    break;

                case 3:
                    btnTest.ToolTipText = "Несоответствия с PLANETA";
                    btnTest.Enabled = true;
                    break;

                case 4:
                    btnTest.ToolTipText = "Несоответствия с PILKINGTON";
                    btnTest.Enabled = true;
                    break;

                case 5:
                    btnTest.ToolTipText = "Несоответствия с FVTOHELP";
                    btnTest.Enabled = true;
                    break;

                case 6:
                    btnTest.ToolTipText = "Несоответствия с Финским справочником";
                    btnTest.Enabled = true;
                    break;

                case 7:
                    btnTest.ToolTipText = "Несоответствия с SPLINTEX";
                    btnTest.Enabled = true;
                    break;

                case 8:
                    btnTest.ToolTipText = "Несоответствия с GLASS2000";
                    btnTest.Enabled = true;
                    break;

                case 9:
                    btnTest.ToolTipText = "Несоответствия с SEKURIT";
                    btnTest.Enabled = true;
                    break;

                case 10:
                    btnTest.ToolTipText = "Несоответствия с OLIMPIA";
                    btnTest.Enabled = true;
                    break;

                case 11:
                    btnTest.ToolTipText = "Несоответствия с LEMART";
                    btnTest.Enabled = true;
                    break;

                case 12:
                    btnTest.ToolTipText = "Несоответствия с BENSON";
                    btnTest.Enabled = true;
                    break;

                case 13:
                    btnTest.ToolTipText = "";
                    btnTest.Enabled = false;
                    break;

                case 14:
                    btnTest.ToolTipText = "";
                    btnTest.Enabled = false;
                    break;

            }

            if (tabMarkaModel.SelectedIndex == 0)
            {
                btnNewModel.Enabled = false;
                btnEditModel.Enabled = false;
                btnDropModel.Enabled = false;
                btnPhoto.Enabled = false;
                btnAnalog.Enabled = false;
                btnMarka.Enabled = true;
                btnDD.Enabled = false;
                btnCopyTo.Enabled = false;
                btnCopyFrom.Enabled = false;
                btnDump.Enabled = false;
            }
            else
            {
                btnNewModel.Enabled = true;
                btnEditModel.Enabled = true;
                btnDropModel.Enabled = true;
                btnPhoto.Enabled = true;
                btnAnalog.Enabled = true;
                btnMarka.Enabled = false;
                btnDD.Enabled = true;
                btnCopyTo.Enabled = true;
                btnDump.Enabled = true;

                if (prev_marka == lbl_id_marka.Text)
                {
                    btnCopyFrom.Enabled = false;
                }
                else
                {
                    btnCopyFrom.Enabled = (prev_model == "пусто" ? false : true);
                }
            }

        }


        private void MainTimer_Tick(object sender, EventArgs e)
        {
            Con.Open();
            cmdCHECK_SUM.Parameters["@BASE"].Value = "MARKA";
            chk_summ[0] = (int)cmdCHECK_SUM.ExecuteScalar();

            cmdCHECK_SUM.Parameters["@BASE"].Value = "Model";
            chk_summ[1] = (int)cmdCHECK_SUM.ExecuteScalar();
            Con.Close();


            if ((cur_chk_summ[0] == chk_summ[0]) && (cur_chk_summ[1] == chk_summ[1]))
                return; // нет изменений

            cur_chk_summ[0] = chk_summ[0];
            cur_chk_summ[1] = chk_summ[1];

            int rdx = 0;

            if (gModel.Visible)
            {
                rdx = gModel.FirstDisplayedCell.RowIndex;
            }

            int k1 = this.BindingContext[dsv1, "FromMarka"].Position;
            int cid_marka = Convert.ToInt16(dsv1.Tables["FromMarka"].Rows[k1]["id_marka"].ToString());
            int cid_model;

            try
            {
                cid_model = Convert.ToInt16(lbl_id_model.Text);
            }
            catch //(Exception a)
            {
                cid_model = -1;
            }

            dsv1.FromModel.Clear();
            dsv1.FromMarka.Clear();
            dsv1.FromAnalogs.Clear();

            aMarka.Fill(dsv1.FromMarka);
            aModel.Fill(dsv1.FromModel);
            aNalogs.Fill(dsv1.FromAnalogs);

            int pmarka;
            for (pmarka = 0; pmarka < dsv1.Tables["FromMarka"].Rows.Count; pmarka++)
            {
                if (cid_marka == Convert.ToInt16(dsv1.Tables["FromMarka"].Rows[pmarka]["id_marka"].ToString()))
                {
                    this.BindingContext[dsv1, "FromMarka"].Position = pmarka;
                    break;
                }
            }

            if (pmarka == dsv1.Tables["FromMarka"].Rows.Count)
            {
                pmarka = 0;
            }

            this.BindingContext[dsv1, "FromMarka"].Position = pmarka;

            int pmodel;

            if (cid_model != -1)
            {
                DataRow[] dr = dsv1.Tables["FromMarka"].Rows[pmarka].GetChildRows("FromMarka_FromModel");
                for (pmodel = 0; pmodel < dr.Length; pmodel++)
                {
                    if (Convert.ToInt16(dr[pmodel]["id_model"].ToString()) == cid_model)
                    {
                        this.BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position = pmodel;
                        // gModel.Select(pmodel);
                        break;
                    }
                }

                if (pmodel == dr.Length)
                {
                    this.BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position = 0;
                }
            }

            gModel.FirstDisplayedScrollingRowIndex = rdx;

        }


        private void btnDD_MouseUp(object sender, MouseEventArgs e)
        {

            dsv1.SENSOR.Clear();
            aSensor.Fill(dsv1.SENSOR);

            int cur_row = gModel.FirstDisplayedScrollingRowIndex;

            if (lbl_Id_memo.Text == "") return;

            id_memo = Convert.ToInt16(lbl_Id_memo.Text);


            if ((fdd == null) || (fdd.Text != "Датчики дождя"))
            {
                fdd = new frmDD();
                fdd.id_memo = id_memo;
                fdd.Show();
            }
            else
            {
                fdd.id_memo = id_memo;
                fdd.Activate();
                dsv1.SENSOR.Clear();
                aSensor.Fill(dsv1.SENSOR);
            }

            gModel.FirstDisplayedScrollingRowIndex = cur_row;
        }


        private void lbl_id_model_TextChanged(object sender, EventArgs e)
        {
            if (fi != null)
            {
                fi.Dispose();
            }
        }


        private void btnCopyTo_MouseUp(object sender, MouseEventArgs e)
        {
            prev_model = lbl_id_model.Text;
            prev_marka = lbl_id_marka.Text;
            btnCopyFrom.Enabled = true;
        }


        private void btnCopyFrom_MouseUp(object sender, MouseEventArgs e)
        {
            MainTimer.Enabled = false;
            string idmarka = lbl_id_marka.Text;
            cmdMoveModel.Parameters["@id_model"].Value = Convert.ToInt16(prev_model);
            cmdMoveModel.Parameters["@id_marka"].Value = Convert.ToInt16(idmarka);

            Con.Open();
            cmdMoveModel.ExecuteNonQuery();
            Con.Close();

            //     ------------------  обновим модели ----------------- 
            dsv1.FromModel.Clear();
            aModel.Fill(dsv1.FromModel);

            //  ------------------  позиционирование на модель ----------------\\

            MainTimer.Enabled = false;
            int k1 = this.BindingContext[dsv1, "FromMarka"].Position;
            string id_marka = dsv1.Tables["FromMarka"].Rows[k1]["id_marka"].ToString();

            DataRow[] dr = dsv1.Tables["FromMarka"].Rows[k1].GetChildRows("FromMarka_FromModel");

            for (int k2 = 0; k2 < dr.Length; k2++)
            {
                if (prev_model == dr[k2]["id_model"].ToString())
                {
                    this.BindingContext[dsv1, "FromMarka.FromMarka_FromModel"].Position = k2;
                    break;
                }
            }

            prev_model = "пусто";
            btnCopyFrom.Enabled = false;
            MainTimer.Enabled = true;
        }


        private void btnSize_MouseUp(object sender, MouseEventArgs e)
        {
            fs = new frmSize();
            fs.ShowDialog();
            fs.Dispose();
        }



        private void gModel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pictXYG.Image = null;

            Cursor = Cursors.WaitCursor;

            id_memo = Convert.ToInt16(lbl_Id_memo.Text);

            if (Con.State == ConnectionState.Closed)
                Con.Open();
            cmdSelector.Parameters["@ID_MEMO"].Value = id_memo;
            cmdSelector.Parameters["@GUIDE"].Value = guide;
            cmdSelector.Parameters["@STARTTIME"].Value = starttime;
            cmdSelector.ExecuteNonQuery();
            Con.Close();

            selCenter.Parameters["@GUIDE"].Value = guide;  // FromCenter

            selCatalogBSG.Parameters["@GUIDE"].Value = guide;  // FromCATALOG_BSG

            selCatalogFYG.Parameters["@GUIDE"].Value = guide;  // FromCATALOG_FYG

            selFinland.Parameters["@GUIDE"].Value = guide;    // FromPilkin_FINLAND

            selPlaneta.Parameters["@GUIDE"].Value = guide;    // FromPlaneta

            selPilkington.Parameters["@GUIDE"].Value = guide;  // FromPilkington

            selAhelp.Parameters["@GUIDE"].Value = guide;       // FromAvtohelp

            selSplin.Parameters["@GUIDE"].Value = guide;       // FromSplintex

            sel2000.Parameters["@GUIDE"].Value = guide;        // FromGLASS2000

            selSekurit.Parameters["@GUIDE"].Value = guide;     // FromSekurit

            selLEMART.Parameters["@GUIDE"].Value = guide;      // FromLEMART

            selFYG.Parameters["@GUIDE"].Value = guide;         // FromFYG

            selCenterCode.Parameters["@GUIDE"].Value = guide;

            selEuropa.Parameters["@GUIDE"].Value = guide;

            sqlGLASSES.Parameters["@GUIDE"].Value = guide;            // FromGLASSES

            sqlGLASS_INFO.Parameters["@GUIDE"].Value = guide;      // GLASS_INFO
            sqlGLASS_INFO.Parameters["@ID_MODEL"].Value = lbl_id_model.Text;

            dsv1.FromPilkin_FINLAND.Clear();
            dsv1.FromCenter.Clear();
            dsv1.FromCenterCode.Clear();
            dsv1.FromCatalog_BSG.Clear();
            dsv1.FromCATALOG_FYG.Clear();

            dsv1.FromPlaneta.Clear();
            dsv1.FromPilkington.Clear();

            dsv1.FromAvtohelp.Clear();
            dsv1.FromSplintex.Clear();
            dsv1.FromGLASS2000.Clear();
            dsv1.FromGLASSES.Clear();
            dsv1.FromSekurit.Clear();
            dsv1.FromLEMART.Clear();

            dsv1.FromGLASSES.Clear();
            dsv1.FromGLASS_INFO.Clear();

            dsv1.FromBENSON.Clear();
            dsv1.EUROPA.Clear();

            string mess = "";

            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                mess = " Центр";
                aCenter.Fill(dsv1.FromCenter);

                aCenterCode.Fill(dsv1.FromCenterCode);

                mess = " CATALOG_FYG";
                aCatalog_FYG.Fill(dsv1.FromCATALOG_FYG);

                mess = " Catalog_BSG";
                aCatalog_BSG.Fill(dsv1.FromCatalog_BSG);

                if (oper == true)
                {
                    mess = " Planeta";
                    aPlaneta.Fill(dsv1.FromPlaneta);

                    mess = " Pilkington";
                    aPilkington.Fill(dsv1.FromPilkington);

                    mess = " Avtohelp";
                    aHelp.Fill(dsv1.FromAvtohelp);

                    mess = " Splintex";
                    aSplin.Fill(dsv1.FromSplintex);

                    mess = " GLASS2000";
                    a2000.Fill(dsv1.FromGLASS2000);

                    mess = " GLASSES_INFO";
                    aGLASS_INFO.Fill(dsv1.FromGLASS_INFO);

                    mess = " GLASSES";
                    aXYGA.Fill(dsv1.FromGLASSES);

                    mess = " Sekurit";
                    aSekurit.Fill(dsv1.FromSekurit);

                    mess = " LEMART";
                    aLEMART.Fill(dsv1.FromLEMART);

                    mess = " BENSON";
                    aBENSON.Fill(dsv1.FromBENSON);

                    mess = " ЕВРОКОДЫ ";
                    aEUROPA.Fill(dsv1.EUROPA);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + mess);
            }
            finally
            {
                Con.Close();
            }

            Cursor = Cursors.Default;

            if ((lbl_Comment.Text.Trim() != "") || (lbl_photo.Text == "+"))
            {
                if (fi != null)
                {
                    fi.Dispose();
                }

                fi = new frmInfo();
                fi.Comment.Text = lbl_Comment.Text;
                fi.Comment.SelectionStart = 1;
                fi.id_memo = id_memo;
                fi.lbl_photo = lbl_photo.Text;
                fi.Markamodel.Text = this.Markamodel.Text;

                for (int nom = 0; nom < lstAnalog.Items.Count; nom++)
                {
                    DataRowView s = (DataRowView)lstAnalog.Items[nom];
                    string analog = (String)s.Row.ItemArray[0];
                    fi.listAnalogi.Items.Add(analog);
                }

                fi.Show();
            }

        }


        private void EUROCODES_MouseUp(object sender, MouseEventArgs e)
        {

            Cursor = Cursors.WaitCursor;

            dsv1.EUROPA.Clear();
            Con.Close();

            conUpdate.ConnectionString = SQLconnection;

            cmdUpdate.CommandText = "EUROPA_ADD";
            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.CommandTimeout = 0;
            cmdUpdate.Parameters.Clear();
            cmdUpdate.Connection = conUpdate;

            conUpdate.Open();
            cmdUpdate.ExecuteNonQuery();
            conUpdate.Close();

            Convertor conv = new Convertor();
            conv.DoPrepare();

            conUpdate.Open();
            cmdUpdate.CommandText = "EUROPA_ADD2";
            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.ExecuteNonQuery();
            conUpdate.Close();

            Cursor = Cursors.Default;
            MessageBox.Show("ЕВРОКОДЫ успешно обновлены");
        }


        private void gModel_SelectionChanged(object sender, EventArgs e)
        {
                Markamodel.Text = lbl_marka.Text.Trim() + "  " + lbl_model.Text
                    + "    <" + lbl_id_model.Text + ">";
        }


        private void InDump_MouseUp(object sender, MouseEventArgs e)
        {
            frmDump dump = new frmDump();
            cmdDump.Parameters[0].Value = lbl_id_model.Text;
            dump.lblMessage.Text = lbl_id_model.Text;
            dump.ShowDialog();

            if (dump.DialogResult == DialogResult.OK)
            {
                Con.Open();
                cmdDump.ExecuteNonQuery();
                Con.Close();
            }
        }


        private void update_row()
        {
            p_VER.Value = (string)grdEUROPA.CurrentRow.Cells[0].Value;
            p_euro.Value = (string)grdEUROPA.CurrentRow.Cells[1].Value;
            p_антенна_A_A.Value = антенна_A_A.Checked ? 1 : 0;
            p_правыйРуль_B_A.Value = правыйРуль_B_A.Checked ? 1 : 0;
            p_местоКамеры_C_A.Value = местоКамеры_C_A.Checked ? 1 : 0;
            p_gPS_G_A.Value = gPS_G_A.Checked ? 1 : 0;
            p_обогрев_H_A.Value = обогрев_H_A.Checked ? 1 : 0;
            p_обогрев_F_A.Value = обогрев_F_A.Checked ? 1 : 0;
            p_tV_антенна_J_A.Value = tV_антенна_J_A.Checked ? 1 : 0;
            p_местоДД_M_A.Value = местоДД_M_A.Checked ? 1 : 0;
            p_окно_ДД_P_A.Value = окно_ДД_P_A.Checked ? 1 : 0;
            p_крепеж_W_A.Value = крепеж_W_A.Checked ? 1 : 0;
            p_инкапсуляция_Z_A.Value = инкапсуляция_Z_A.Checked ? 1 : 0;
            p_леваяПоловина_L_A.Value = леваяПоловина_L_A.Checked ? 1 : 0;
            p_праваяПоловина_R_A.Value = праваяПоловина_R_A.Checked ? 1 : 0;
            p_VINокно_V_A.Value = 1;
            p_дисплей_U_A.Value = дисплей_U_A.Checked ? 1 : 0;
            p_водооталк_N_A.Value = водооталк_N_A.Checked ? 1 : 0;
            p_датчикТумана_O_A.Value = датчикТумана_O_A.Checked ? 1 : 0;
            p_антенна_A_B.Value = антенна_A_B.Checked ? 1 : 0;
            p_стопсигнал_B_B.Value = стопсигнал_B_B.Checked ? 1 : 0;
            p_инкапсуляция_Z_B.Value = инкапсуляция_Z_B.Checked ? 1 : 0;
            p_триплекс_K_B.Value = триплекс_K_B.Checked ? 1 : 0;
            p_стеклопакет_D_B.Value = стеклопакет_D_B.Checked ? 1 : 0;
            p_крепеж_W_B.Value = крепеж_W_B.Checked ? 1 : 0;
            p_vINокно_V_B.Value = vINокно_V_B.Checked ? 1 : 0;
            p_tV_антенна_J_B.Value = tV_антенна_J_B.Checked ? 1 : 0;
            p_gPS_G_B.Value = gPS_G_B.Checked ? 1 : 0;
            p_topBand_T_B.Value = topBand_T_B.Checked ? 1 : 0;
            p_безОбогрева_U_B.Value = безОбогрева_U_B.Checked ? 1 : 0;
            p_верхнее_Y_B.Value = верхнее_Y_B.Checked ? 1 : 0;
            p_открывающееся_O_B.Value = открывающееся_O_B.Checked ? 1 : 0;
            p_проводСигнализации_X_B.Value = проводСигнализации_X_B.Checked ? 1 : 0;
            p_водоотталкивающее_N_B.Value = водоотталкивающее_N_B.Checked ? 1 : 0;
            p_аварОповещение_M_B.Value = аварОповещение_M_B.Checked ? 1 : 0;
            p_антеннаТелефона_P_B.Value = антеннаТелефона_P_B.Checked ? 1 : 0;
            p_выдвигающаясяАнтенна_Q_B.Value = выдвигающаясяАнтенна_Q_B.Checked ? 1 : 0;
            p_леваяПоловина_L_B.Value = леваяПоловина_L_B.Checked ? 1 : 0;
            p_праваяПоловина_R_B.Value = праваяПоловина_R_B.Checked ? 1 : 0;
            p_центральнаяЧасть_C_B.Value = центральнаяЧасть_C_B.Checked ? 1 : 0;
            p_рамкаСподвИнеподвСтеклом_S_B.Value = рамкаСподвИнеподвСтеклом_S_B.Checked ? 1 : 0;
            p_tV_антенна_J_C.Value = tV_антенна_J_C.Checked ? 1 : 0;
            p_подвижное_S_C.Value = подвижное_S_C.Checked ? 1 : 0;
            p_открывающееся_O_C.Value = открывающееся_O_C.Checked ? 1 : 0;
            p_инкапсуляция_Z_C.Value = инкапсуляция_Z_C.Checked ? 1 : 0;
            p_крепеж_W_C.Value = крепеж_W_C.Checked ? 1 : 0;
            p_триплекс_K_C.Value = триплекс_K_C.Checked ? 1 : 0;
            p_антенна_A_C.Value = антенна_A_C.Checked ? 1 : 0;
            p_обогрев_H_C.Value = обогрев_H_C.Checked ? 1 : 0;
            p_VIN_V_C.Value = VIN_V_C.Checked ? 1 : 0;
            p_подогревАнтенны_P_C.Value = подогревАнтенны_P_C.Checked ? 1 : 0;
            p_верхнее_U_C.Value = верхнее_U_C.Checked ? 1 : 0;
            p_gPS_G_C.Value = gPS_G_C.Checked ? 1 : 0;
            p_выдвигающаясяАнтенна_Q_C.Value = выдвигающаясяАнтенна_Q_C.Checked ? 1 : 0;
            p_стеклопакет_D_C.Value = стеклопакет_D_C.Checked ? 1 : 0;
            p_водоотталкивающее_N_C.Value = водоотталкивающее_N_C.Checked ? 1 : 0;
            p_проводСигнализации_X_C.Value = проводСигнализации_X_C.Checked ? 1 : 0;
            p_открываемоеЕлектрически_E_C.Value = открываемоеЕлектрически_E_C.Checked ? 1 : 0;
            p_фиксаторОткрывания_T_C.Value = фиксаторОткрывания_T_C.Checked ? 1 : 0;
            p_рамкаСподвИнеподвСтеклом_F_C.Value = рамкаСподвИнеподвСтеклом_F_C.Checked ? 1 : 0;
            p_Отверстий.Value = Convert.ToInt32(Отверстий.Text);
            p_Комментарий.Value = Комментарий.Text.Trim();
            p_WIDTH.Value = Convert.ToInt32("0" + Ширина.Text);
            p_HEIGHT.Value = Convert.ToInt32("0" + Высота.Text);

            p_H3.Value = H3.Checked ? 1 : 0;
            p_H5.Value = H5.Checked ? 1 : 0;

            p_S2.Value = S2.Checked ? 1 : 0;
            p_S4.Value = S4.Checked ? 1 : 0;
            p_S4L.Value = S4L.Checked ? 1 : 0;
            p_S6.Value = S6.Checked ? 1 : 0;

            p_E3.Value = E3.Checked ? 1 : 0;
            p_E5.Value = E5.Checked ? 1 : 0;

            p_C2.Value = C2.Checked ? 1 : 0;
            p_C4.Value = C4.Checked ? 1 : 0;

            p_R3.Value = R3.Checked ? 1 : 0;
            p_R5.Value = R5.Checked ? 1 : 0;
            p_R5L.Value = R5L.Checked ? 1 : 0;
            p_L2.Value = L2.Checked ? 1 : 0;
            p_L4.Value = L4.Checked ? 1 : 0;

            p_LIFTBACK.Value = LIFTBACK.Checked ? 1 : 0;
            p_T2.Value = T2.Checked ? 1 : 0;

            p_V2.Value = V2.Checked ? 1 : 0;
            p_V3.Value = V3.Checked ? 1 : 0;
            p_V3L.Value = V3L.Checked ? 1 : 0;
            p_V4.Value = V4.Checked ? 1 : 0;
            p_V4L.Value = V4L.Checked ? 1 : 0;
            p_V5.Value = V5.Checked ? 1 : 0;
            p_V5L.Value = V5L.Checked ? 1 : 0;

            p_P2.Value = P2.Checked ? 1 : 0;
            p_P4.Value = P4.Checked ? 1 : 0;
            p_M3.Value = M3.Checked ? 1 : 0;
            p_M3L.Value = M3L.Checked ? 1 : 0;
            p_M4.Value = M4.Checked ? 1 : 0;
            p_M4L.Value = M4L.Checked ? 1 : 0;
            p_M5.Value = M5.Checked ? 1 : 0;
            p_M5L.Value = M5L.Checked ? 1 : 0;
            p_HTOP.Value = HTOP.Checked ? 1 : 0;
            p_HARDTOP_E5.Value = HARDTOP_E5.Checked ? 1 : 0;

            p_comLOCATION.Value = comLOCATION.SelectedValue;
            p_comSTRIP.Value = comSTRIP.SelectedValue;
            p_comCOLOR.Value = comCOLOR.SelectedValue;
            p_comDD.Value = comDD.SelectedValue == null ? "..." : comDD.SelectedValue;

            p_richNaim.Value = richNaim.Text.Trim();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (p_comCOLOR.Value != null)
                    MessageBox.Show("Произошла ошибка - " + ex.Message);
            }

            record_status = false;
        }


        private void Row_Edit(object sender, EventArgs e)
        {
            //-- пока нет наименования
            richNaimUpd = "";
            tabMarkaModel.SelectedIndex = 1;

            try
            {
                Side = (comLOCATION.SelectedValue.ToString()).Substring(0, 2);

                switch (Side)
                {
                    case "AM":
                        record_status = true;
                        richNaimUpd = comLOCATION.Text;
                        richNaimUpd += Комментарий.Text.Trim() != "" ? ", " + Комментарий.Text.Trim() : "";
                        GetBody();
                        richNaim.Text = richNaimUpd;
                        textSIDE.Text = "A";
                        break;

                    case "AK":
                        record_status = true;
                        richNaimUpd = comLOCATION.Text;
                        richNaimUpd += Комментарий.Text.Trim() != "" ? ", " + Комментарий.Text.Trim() : "";
                        GetBody();
                        richNaim.Text = richNaimUpd;
                        textSIDE.Text = "A";
                        break;

                    case "AT":
                        record_status = true;
                        richNaimUpd = comLOCATION.Text;
                        richNaimUpd += Комментарий.Text.Trim() != "" ? ", " + Комментарий.Text.Trim() : "";
                        GetBody();
                        richNaim.Text = richNaimUpd;
                        textSIDE.Text = "A";
                        break;

                    case "AB":
                        record_status = true;
                        richNaimUpd = comLOCATION.Text;
                        richNaimUpd += Комментарий.Text.Trim() != "" ? ", " + Комментарий.Text.Trim() : "";
                        GetBody();
                        richNaim.Text = richNaimUpd;
                        textSIDE.Text = "A";
                        break;

                    case "BM":
                        record_status = true;
                        richNaimUpd = comLOCATION.Text;
                        richNaimUpd += Комментарий.Text.Trim() != "" ? ", " + Комментарий.Text.Trim() : "";
                        GetBody();
                        richNaim.Text = richNaimUpd;
                        textSIDE.Text = "B";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка : " + ex.Message);
                return;
            }

            // ЕСЛИ ПОПАЛСЯ МОЛДИНГ, ТОГДА richNaimUpd != "" ВОЗВРАТ
            if (richNaimUpd != "") return;

            try
            {
                Side = (comLOCATION.SelectedValue.ToString()).Substring(0, 1);

                switch (Side)
                {
                    case "A":
                        record_status = true;
                        Naim_A();
                        richNaimUpd += Комментарий.Text.Trim() != "" ? ", " + Комментарий.Text.Trim() : "";
                        GetBody();
                        richNaim.Text = richNaimUpd;
                        textSIDE.Text = "A";
                        break;

                    case "B":
                        record_status = true;
                        Naim_B();
                        richNaimUpd += Комментарий.Text.Trim() != "" ? ", " + Комментарий.Text.Trim() : "";
                        GetBody();
                        richNaim.Text = richNaimUpd;
                        textSIDE.Text = "B";
                        break;

                    case "L":
                        record_status = true;
                        Naim_C();
                        richNaimUpd += Комментарий.Text.Trim() != "" ? ", " + Комментарий.Text.Trim() : "";
                        GetBody();
                        richNaim.Text = richNaimUpd;
                        textSIDE.Text = "L";
                        break;

                    case "R":
                        record_status = true;
                        Naim_C();
                        richNaimUpd += Комментарий.Text.Trim() != "" ? ", " + Комментарий.Text.Trim() : "";
                        GetBody();
                        richNaim.Text = richNaimUpd;
                        textSIDE.Text = "R";
                        break;

                    case "F":
                        record_status = true;
                        Naim_C();
                        richNaimUpd += Комментарий.Text.Trim() != "" ? ", " + Комментарий.Text.Trim() : "";
                        GetBody();
                        richNaim.Text = richNaimUpd;
                        textSIDE.Text = "F";
                        break;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка : " + ex.Message);
                return;
            }

            update_row();
        }


        private void grdEUROPA_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            record_status = true;

            if ((string)grdEUROPA.CurrentRow.Cells[0].Value == "?" | (string)grdEUROPA.CurrentRow.Cells[0].Value == "*")
            {
                grdEUROPA.CurrentRow.Cells[0].Value = " ";
            }
            else grdEUROPA.CurrentRow.Cells[0].Value = "?";

            update_row();
        }


        private void Naim_A()
        {
            //-- закладка лобовых
            enumer = tabA.Controls.GetEnumerator();
            enumer.Reset();

            CheckBox cb;
            richNaimUpd = comLOCATION.Text;

            if (comCOLOR.Text == "")
            {
                richNaimUpd += " бесцветное";
            }
            else
            {
                richNaimUpd += " " + comCOLOR.Text;
            }

            if (comSTRIP.Text.Trim() != "")
                richNaimUpd += ", " + comSTRIP.Text.Trim();

            while (enumer.MoveNext())
            {
                try
                {
                    cb = (CheckBox)enumer.Current;
                    if (cb.Checked)
                    {
                        string Acces_name = cb.AccessibleName;
                        richNaimUpd += ", " + htSPES[Acces_name];
                    }
                }
                catch { }
            }
        }


        private void Naim_B()
        {
            //-- закладка задних
            enumer = tabB.Controls.GetEnumerator();
            enumer.Reset();

            CheckBox cb;

            richNaimUpd = comLOCATION.Text;
            richNaimUpd += ", " + comCOLOR.Text;

            while (enumer.MoveNext())
            {
                try
                {
                    cb = (CheckBox)enumer.Current;
                    if (cb.Checked)
                    {
                        string Acces_name = cb.AccessibleName;
                        richNaimUpd += ", " + htSPES[Acces_name];
                    }
                }
                catch { }
            }

        }


        private void Naim_C()
        {
            //-- закладка боковых
            enumer = tabC.Controls.GetEnumerator();
            enumer.Reset();
            richNaimUpd = String.Empty;

            CheckBox cb;

            richNaimUpd += comLOCATION.Text;
            richNaimUpd += ", " + comCOLOR.Text;

            while (enumer.MoveNext())
            {
                try
                {
                    cb = (CheckBox)enumer.Current;
                    if (cb.Checked)
                    {
                        string Acces_name = cb.AccessibleName;
                        richNaimUpd += ", " + htSPES[Acces_name];
                    }
                }
                catch { }
            }

        }


        private void GetBody()
        {
            Side = Side.Substring(0, 1);

            if (Convert.ToInt16(Отверстий.Text) == 0)
            {
                if ((Side != "A") && (Side != "B") && (Side != "K"))
                {
                    richNaimUpd += ", без отверстий";
                }
            }
            else
            {
                richNaimUpd += ", отверстий-" + Отверстий.Text;
            }


            Body = String.Empty;

            Body += (H3.Checked) ? ",хэтчбек 3дв" : "";
            Body += (H5.Checked) ? ",хэтчбек 5дв" : "";

            Body += (S2.Checked) ? ",седан 2дв" : "";
            Body += (S4.Checked) ? ",седан 4дв" : "";
            Body += (S4L.Checked) ? ",седан 4дв длинная база" : "";
            Body += (S6.Checked) ? ",седан 6дв" : "";

            Body += (E3.Checked) ? ",универсал 3дв" : "";
            Body += (E5.Checked) ? ",универсал 5дв" : "";

            Body += (R3.Checked) ? ",внедорожник 3дв" : "";
            Body += (R5.Checked) ? ",внедорожник 5дв" : "";
            Body += (R5L.Checked) ? ",внедорожник 5дв длинная база" : "";

            Body += (C2.Checked) ? ",купе 2дв" : "";
            Body += (C4.Checked) ? ",купе 4дв" : "";

            Body += (L2.Checked) ? ",грузовик 2дв" : "";
            Body += (L4.Checked) ? ",грузовик 4дв" : "";
            Body += (LIFTBACK.Checked) ? ",лифтбэк" : "";

            Body += (T2.Checked) ? ",кабриолет 2дв" : "";

            Body += (V2.Checked) ? ",вэн 2дв" : "";
            Body += (V3.Checked) ? ",вэн 3дв" : "";
            Body += (V3L.Checked) ? ",вэн 3дв длинная база" : "";
            Body += (V4.Checked) ? ",вэн 4дв" : "";
            Body += (V4L.Checked) ? ",вэн 4дв длинная база" : "";
            Body += (V5.Checked) ? ",вэн 5дв" : "";
            Body += (V5L.Checked) ? ",вэн 5дв длинная база" : "";

            Body += (P2.Checked) ? ",пикап 2дв" : "";
            Body += (P4.Checked) ? ",пикап 4дв" : "";

            Body += (M3.Checked) ? ",минивэн 3дв" : "";
            Body += (M3L.Checked) ? ",минивэн 3дв длинная база" : "";
            Body += (M4.Checked) ? ",минивэн 4дв" : "";
            Body += (M4L.Checked) ? ",минивэн 4дв длинная база" : "";
            Body += (M5.Checked) ? ",минивэн 5дв" : "";
            Body += (M5L.Checked) ? ",минивэн 5дв длинная база" : "";

            Body += (HTOP.Checked) ? ",хардтоп 4дв" : "";
            Body += (HARDTOP_E5.Checked) ? ",хардтоп 5дв" : "";

            if (Body != String.Empty)
            {
                richNaimUpd += " +(" + Body.Substring(1, Body.Length - 1) + ")";
            }

        }


        private void textSIDE_TextChanged(object sender, EventArgs e)
        {
            if (!current_option)
            {
                switch (textSIDE.Text)
                {
                    case "A":
                        tabA.BackColor = System.Drawing.Color.LightGray;
                        tabB.BackColor = System.Drawing.Color.Gray;
                        tabC.BackColor = System.Drawing.Color.Gray;

                        tabA.Enabled = true;
                        tabB.Enabled = false;
                        tabC.Enabled = false;
                        break;

                    case "B":
                        tabB.BackColor = System.Drawing.Color.LightGray;
                        tabA.BackColor = System.Drawing.Color.Gray;
                        tabC.BackColor = System.Drawing.Color.Gray;

                        tabA.Enabled = false;
                        tabB.Enabled = true;
                        tabC.Enabled = false;
                        break;

                    case "L":
                    case "R":
                    case "F":
                        tabC.BackColor = System.Drawing.Color.LightGray;
                        tabB.BackColor = System.Drawing.Color.Gray;
                        tabA.BackColor = System.Drawing.Color.Gray;

                        tabA.Enabled = false;
                        tabB.Enabled = false;
                        tabC.Enabled = true;
                        break;
                }
            }
        }


        private void comLOCATION_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comLOCATION.Focused)
            {
                textSIDE_TextChanged(sender, e);
                Row_Edit(sender, e);
            }
        }



        private void Ширина_Validated(object sender, EventArgs e)
        {
            record_status = true;
        }


        private void Высота_Validated(object sender, EventArgs e)
        {
            record_status = true;
        }


        private void Комментарий_Validated(object sender, EventArgs e)
        {
            record_status = true;
        }


        private void tabGlass_Leave(object sender, EventArgs e)
        {
            if (record_status == true)
            {
                update_row();
            }
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (record_status == true)
            {
                update_row();
            }
        }


        private void toolStripp_Click(object sender, EventArgs e)
        {
            if (record_status == true)
            {
                update_row();
            }
        }


        private void DeleteRecord_Click(object sender, EventArgs e)
        {

            string msg = "Продолжить удаление еврокода " + grdEUROPA.CurrentRow.Cells[1].Value + " ?";

            if (MessageBox.Show(ActiveForm, msg, "Удаление еврокода", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int rx = grdEUROPA.CurrentRow.Index;
                insDUMP.Parameters["@EURO"].Value = (string)grdEUROPA.CurrentRow.Cells[1].Value;
                Con.Open();
                insDUMP.ExecuteNonQuery(); // вставка удаляемого кода в dump
                Con.Close();

                aEUROPA.DeleteCommand.Parameters[0].Value = grdEUROPA.CurrentRow.Cells[1].Value;
                Con.Open();
                aEUROPA.DeleteCommand.ExecuteNonQuery();
                Con.Close();

                string euro = (string)grdEUROPA.CurrentRow.Cells[1].Value;
                dsv.EUROPARow currow = dsv1.EUROPA.FindByEURO(euro);
                currow.Delete();
                dsv1.EUROPA.Rows[grdEUROPA.CurrentRow.Index].Delete();
            }
        }


        private void применитьРеквизитыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPRIMENITE fp = new frmPRIMENITE();
            fp.ShowDialog();
        }


        private void цветСтеклаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCOLORS fc = new frmCOLORS();
            fc.ShowDialog();
            dsv1.COLORS.Clear();
            aCOLORS.Fill(dsv1.COLORS);
        }


        private void цветПолосыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSTRIP fs = new frmSTRIP();
            fs.ShowDialog();
            dsv1.STRIP.Clear();
            aSTRIP.Fill(dsv1.STRIP);
        }


        private void положениеСтеклаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLOCATION fl = new frmLOCATION();
            fl.ShowDialog();
            dsv1.LOCATION.Clear();
            aLOCATION.Fill(dsv1.LOCATION);
        }


        private void процентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPROCENT fp = new frmPROCENT();
            fp.ShowDialog();
        }


        private void comDD_TextUpdate(object sender, EventArgs e)
        {
            Row_Edit(sender, e);
            update_row();
        }


        private void grdEUROPA_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            switch (textSIDE.Text)
            {
                case "A":
                    tabA.BackColor = panel1.BackColor; // System.Drawing.Color.LightGray;
                    tabB.BackColor = System.Drawing.Color.Gray;
                    tabC.BackColor = System.Drawing.Color.Gray;

                    tabA.Enabled = true;
                    tabB.Enabled = false;
                    tabC.Enabled = false;
                    break;

                case "B":
                    tabB.BackColor = panel1.BackColor;   // System.Drawing.Color.LightGray;
                    tabA.BackColor = panel1.BackColor;   // System.Drawing.Color.Gray;
                    tabC.BackColor = panel1.BackColor;   // System.Drawing.Color.Gray;

                    tabA.Enabled = false;
                    tabB.Enabled = true;
                    tabC.Enabled = false;
                    break;

                case "L":
                case "R":
                case "F":
                    tabC.BackColor = System.Drawing.Color.LightGray;
                    tabB.BackColor = System.Drawing.Color.Gray;
                    tabA.BackColor = System.Drawing.Color.Gray;

                    tabA.Enabled = false;
                    tabB.Enabled = false;
                    tabC.Enabled = true;
                    break;
            }

        }


        private void XYGupdate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            conUpdate.ConnectionString = SQLconnection;
            cmdUpdate.Connection = conUpdate;

            conUpdate.Open();

            cmdUpdate.CommandText = "EUROPA_ADD_XYG";
            cmdUpdate.CommandTimeout = 0;
            cmdUpdate.ExecuteNonQuery();
            conUpdate.Close();

            Cursor = Cursors.Default;
            MessageBox.Show("XYG успешно обновлены");

        }



        private void ShowPict()
        {
            MemoryStream memstrm_photo_XYG = new MemoryStream();
            SqlDataReader dr_photo;

            byte[] buffer;
            cmdImageXYG.Parameters["@id_image"].Value = lbl_id_image.Text.ToString();

            if (Con.State == ConnectionState.Closed)
                Con.Open();

            dr_photo = cmdImageXYG.ExecuteReader();
            dr_photo.Read();

            int lengh_photo = Convert.ToInt32(dr_photo["LENGH_PHOTO"].ToString());
            buffer = new byte[lengh_photo];


            long startIndex = 0;

            long retval = dr_photo.GetBytes(1, startIndex, buffer, 0, lengh_photo);

            MemoryStream memstrm_photo = new MemoryStream(buffer);
            memstrm_photo.Write(buffer, 0, (int)retval);
            memstrm_photo.Flush();
            pictXYG.Image = Image.FromStream(memstrm_photo);
            
            Con.Close();
        }



        private void gXYGA_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowPict();
        }
    }

 }
