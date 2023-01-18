using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace PITON
{
    class Convertor
    {
        string color;
        string strip;
        string body;
        string side;
        string euro;

        string location;

        SqlCommand upd;
        SqlConnection conn;

        SqlParameter p_EURO;
        SqlParameter p_НАИМЕНОВАНИЕ;
        SqlParameter p_COLOR;
        SqlParameter p_STRIP;
        SqlParameter p_SIDE;
        SqlParameter p_LOCATION;
        SqlParameter p_CHARAC;
        SqlParameter p_Антенна_A_A;
        SqlParameter p_ПравыйРуль_B_A;
        SqlParameter p_МестоКамеры_C_A;
        SqlParameter p_GPS_G_A;
        SqlParameter p_Обогрев_H_A;
        SqlParameter p_Обогрев_F_A;
        SqlParameter p_TV_антенна_J_A;
        SqlParameter p_ЛеваяПоловина_L_A;
        SqlParameter p_МестоДД_M_A;
        SqlParameter p_Водооталк_N_A;
        SqlParameter p_ДатчикТумана_O_A;
        SqlParameter p_Окно_ДД_P_A;
        SqlParameter p_ПраваяПоловина_R_A;
        SqlParameter p_ПодогревАнтенны_P_A;
        SqlParameter p_Дисплей_U_A;
        SqlParameter p_VINокно_V_A;
        SqlParameter p_Крепеж_W_A;
        SqlParameter p_Инкапсуляция_Z_A;
        SqlParameter p_Антенна_A_B;
        SqlParameter p_Стопсигнал_B_B;
        SqlParameter p_ЦентральнаяЧасть_C_B;
        SqlParameter p_Стеклопакет_D_B;
        SqlParameter p_GPS_G_B;
        SqlParameter p_TV_антенна_J_B;
        SqlParameter p_Триплекс_K_B;
        SqlParameter p_ЛеваяПоловина_L_B;
        SqlParameter p_АварОповещение_M_B;
        SqlParameter p_Водоотталкивающее_N_B;
        SqlParameter p_Открывающееся_O_B;
        SqlParameter p_АнтеннаТелефона_P_B;
        SqlParameter p_ПраваяПоловина_R_B;
        SqlParameter p_ВыдвигающаясяАнтенна_Q_B;
        SqlParameter p_РамкаСподвИнеподвСтеклом_S_B;
        SqlParameter p_TopBand_T_B;
        SqlParameter p_БезОбогрева_U_B;
        SqlParameter p_VINокно_V_B;
        SqlParameter p_Крепеж_W_B;
        SqlParameter p_ПроводСигнализации_X_B;
        SqlParameter p_Верхнее_Y_B;
        SqlParameter p_Инкапсуляция_Z_B;
        SqlParameter p_Антенна_A_C;
        SqlParameter p_Стеклопакет_D_C;
        SqlParameter p_ОткрываемоеЕлектрически_E_C;
        SqlParameter p_РамкаСподвИнеподвСтеклом_F_C;
        SqlParameter p_GPS_G_C;
        SqlParameter p_Обогрев_H_C;
        SqlParameter p_TV_антенна_J_C;
        SqlParameter p_Триплекс_K_C;
        SqlParameter p_Водоотталкивающее_N_C;
        SqlParameter p_Открывающееся_O_C;
        SqlParameter p_ПодогревАнтенны_P_C;
        SqlParameter p_ВыдвигающаясяАнтенна_Q_C;
        SqlParameter p_Подвижное_S_C;
        SqlParameter p_ФиксаторОткрывания_T_C;
        SqlParameter p_Верхнее_U_C;
        SqlParameter p_VIN_V_C;
        SqlParameter p_Крепеж_W_C;
        SqlParameter p_ПроводСигнализации_X_C;
        SqlParameter p_Инкапсуляция_Z_C;
        SqlConnection con;
        SqlDataReader reader;

        Hashtable htSPEC;
        Hashtable htSPEC_ID;
        Hashtable htCOLORS;
        Hashtable htLOCATION;
        Hashtable htSTRIPS;
        Hashtable htBODIES;
        Hashtable htХарактер;

        SqlCommand readerCMD;

        bool flag_update;


        public Convertor()
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(
                    System.Reflection.Assembly.GetExecutingAssembly().Location);

            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;


            string SQLconnection = ConfigurationManager.ConnectionStrings["myCon"].ToString();

            conn = new SqlConnection();
            conn.ConnectionString = SQLconnection;

            con = new SqlConnection();
            con.ConnectionString = SQLconnection;

            readerCMD = new SqlCommand();
            readerCMD.Connection = con;
            readerCMD.CommandType = CommandType.Text;
            readerCMD.CommandText = "SELECT ID_CHAR,описание FROM ХАРАКТЕРИСТИКИ";

            con.Open();
            reader = readerCMD.ExecuteReader();

            //---------------------  здесь  особенности изготовления стекла - пятака и шелка ---
            htХарактер = new Hashtable(600);

            while (reader.Read())
            {
                htХарактер[(string)reader["id_char"]] = (string)reader["описание"].ToString();
            }
            con.Close();

            // -------------------- здесь типы кузовов ---------------------------------------
            readerCMD.CommandText = " SELECT ID_BODY, BODY FROM BODY ";
            con.Open();
            reader = readerCMD.ExecuteReader();
            htBODIES = new Hashtable(30);

            while (reader.Read())
            {
                htBODIES[(string)reader["ID_BODY"]] = (string)reader["BODY"];
            }

            con.Close();
            //---------------------  вводим спецификации на элементы стекла
            //---------------------  исключая характеристики на конце еврокода 3
            htSPEC = new Hashtable(100);
            htSPEC_ID = new Hashtable(100);

            readerCMD.CommandText = "SELECT id_char,параметр,спецификация FROM СПЕЦИФИКАЦИИ";
            con.Open();

            reader = readerCMD.ExecuteReader();
            while (reader.Read())
            {
                htSPEC[(string)reader["параметр"]] = (string)reader["спецификация"];
                htSPEC_ID[(string)reader["id_char"]] = (string)reader["параметр"];
            }

            con.Close();


            //----------------------------------- положение стекол ------------------------------
            readerCMD.CommandText = "SELECT id_location,location FROM location";

            con.Open();
            reader = readerCMD.ExecuteReader();
            htLOCATION = new Hashtable(50);

            while (reader.Read())
            {
                htLOCATION[(string)reader["id_location"]] = (string)reader["LOCATION"]; ;
            }
            con.Close();

            //-------------------------------цвета полос стекол ------------------------------
            readerCMD.CommandText = "SELECT id_strip,strip FROM strip";

            con.Open();
            reader = readerCMD.ExecuteReader();
            htSTRIPS = new Hashtable(20);

            while (reader.Read())
            {
                htSTRIPS[(string)reader["id_strip"]] = (string)reader["strip"]; ;
            }
            con.Close();

            //----------------------------------- таблица цветов стёкол ------------------------
            readerCMD.CommandText = "SELECT ID_COLOR, COLOR FROM COLORS";

            con.Open();
            reader = readerCMD.ExecuteReader();

            htCOLORS = new Hashtable(50);
            while (reader.Read())
            {
                htCOLORS[(string)reader["ID_COLOR"]] = (string)reader["COLOR"];
            }
            con.Close();

        }

        private void ZeroParam()
        {
            p_EURO.Value = "";
            p_НАИМЕНОВАНИЕ.Value = " ";
            p_COLOR.Value = "..";
            p_STRIP.Value = "..";
            p_SIDE.Value = 0;
            p_LOCATION.Value = "...";
            p_CHARAC.Value = "...";
            p_Антенна_A_A.Value = 0;
            p_ПравыйРуль_B_A.Value = 0;
            p_МестоКамеры_C_A.Value = 0;
            p_GPS_G_A.Value = 0;
            p_Обогрев_H_A.Value = 0;
            p_Обогрев_F_A.Value = 0;
            p_TV_антенна_J_A.Value = 0;
            p_ЛеваяПоловина_L_A.Value = 0;
            p_МестоДД_M_A.Value = 0;
            p_Водооталк_N_A.Value = 0;
            p_ДатчикТумана_O_A.Value = 0;
            p_Окно_ДД_P_A.Value = 0;
            p_ПодогревАнтенны_P_A.Value = 0;
            p_ПраваяПоловина_R_A.Value = 0;
            p_Дисплей_U_A.Value = 0;
            p_VINокно_V_A.Value = 0;
            p_Крепеж_W_A.Value = 0;
            p_Инкапсуляция_Z_A.Value = 0;
            p_Антенна_A_B.Value = 0;
            p_Стопсигнал_B_B.Value = 0;
            p_ЦентральнаяЧасть_C_B.Value = 0;
            p_Стеклопакет_D_B.Value = 0;
            p_GPS_G_B.Value = 0;
            p_TV_антенна_J_B.Value = 0;
            p_Триплекс_K_B.Value = 0;
            p_АварОповещение_M_B.Value = 0;
            p_ЛеваяПоловина_L_B.Value = 0;
            p_Водоотталкивающее_N_B.Value = 0;
            p_Открывающееся_O_B.Value = 0;
            p_АнтеннаТелефона_P_B.Value = 0;
            p_ВыдвигающаясяАнтенна_Q_B.Value = 0;
            p_ПраваяПоловина_R_B.Value = 0;
            p_РамкаСподвИнеподвСтеклом_S_B.Value = 0;
            p_TopBand_T_B.Value = 0;
            p_БезОбогрева_U_B.Value = 0;
            p_VINокно_V_B.Value = 0;
            p_Крепеж_W_B.Value = 0;
            p_ПроводСигнализации_X_B.Value = 0;
            p_Верхнее_Y_B.Value = 0;
            p_Инкапсуляция_Z_B.Value = 0;
            p_Антенна_A_C.Value = 0;
            p_Стеклопакет_D_C.Value = 0;
            p_ОткрываемоеЕлектрически_E_C.Value = 0;
            p_РамкаСподвИнеподвСтеклом_F_C.Value = 0;
            p_GPS_G_C.Value = 0;
            p_Обогрев_H_C.Value = 0;
            p_TV_антенна_J_C.Value = 0;
            p_Триплекс_K_C.Value = 0;
            p_Водоотталкивающее_N_C.Value = 0;
            p_Открывающееся_O_C.Value = 0;
            p_ПодогревАнтенны_P_C.Value = 0;
            p_ВыдвигающаясяАнтенна_Q_C.Value = 0;
            p_Подвижное_S_C.Value = 0;
            p_ФиксаторОткрывания_T_C.Value = 0;
            p_Верхнее_U_C.Value = 0;
            p_VIN_V_C.Value = 0;
            p_Крепеж_W_C.Value = 0;
            p_ПроводСигнализации_X_C.Value = 0;
            p_Инкапсуляция_Z_C.Value = 0;
        }

        private void A_Glass()
        {
            //--------- лобовое стекло

            upd.Parameters["@EURO"].Value = euro.Trim();
            side = "A";



            euro = euro.Substring(5, euro.Length - 5);
            upd.Parameters["@SIDE"].Value = side;
            upd.Parameters["@LOCATION"].Value = "AA";

            color = null;
            if (euro.Length >= 2)
            {
                color = (string)htCOLORS[euro.Substring(0, 2)]; // определен цвет стекла 
            }

            if (color != null)
            {
                upd.Parameters["@COLOR"].Value = euro.Substring(0, 2);
                euro = euro.Substring(2, euro.Length - 2);
            }
            else
            {
                color = "";
                upd.Parameters["@COLOR"].Value = "..";
            }

            if (euro.Length >= 2)
            {
                strip = (string)htSTRIPS[euro.Substring(0, 2)]; // определен цвет полосы
            }
            else strip = null;

            if (strip != null) // если это полоса
            {
                upd.Parameters["@STRIP"].Value = strip = euro.Substring(0, 2);
                euro = euro.Substring(2, euro.Length - 2);   // отсекаем
            }
            else
            {
                strip = "..";
                upd.Parameters["@STRIP"].Value = strip = "..";
            }

            SearchCharacters();
            euro = euro.Trim();
            ParseEuro("A");

        }

        private void B_Glass()
        {
            upd.Parameters["@EURO"].Value = euro.Trim();
            side = "B";

            euro = euro.Substring(5, euro.Length - 5);
            upd.Parameters["@SIDE"].Value = side;
            upd.Parameters["@LOCATIOn"].Value = "BB";

            color = "..";
            if (euro.Length >= 2)
            {
                color = euro.Substring(0, 2); // определен цвет стекла 
            }

            if ((string)htCOLORS[color] != null)
            {
                upd.Parameters["@COLOR"].Value = color;
                euro = euro.Substring(2, euro.Length - 2);
            }

            euro = euro.Substring(1, euro.Length - 1);
            euro = euro.Trim();
            SearchCharacters();

            ParseEuro("B");
        }

        private void C_Glass()
        {
            upd.Parameters["@EURO"].Value = euro.Trim();
            side = euro.Substring(4, 1);

            euro = euro.Substring(5, euro.Length - 5);
            upd.Parameters["@SIDE"].Value = side;

            color = euro.Substring(0, 2); // определен цвет стекла 
            if ((string)htCOLORS[color] != null)
            {
                upd.Parameters["@COLOR"].Value = color;
            }

            body = euro.Substring(2, 2); //- определен тип кузова

            location = side + euro.Substring(4, 2);

            if (htLOCATION[location] != null)
            {
                euro = euro.Substring(6, euro.Length - 6);
                upd.Parameters["@LOCATION"].Value = location;
            }

            euro = euro.Trim();
            SearchCharacters();
            ParseEuro("C");
        }

        private void SearchCharacters()
        {
            string key = "...";
            string описание;
            string eurocod;

            eurocod = euro.Trim();

            upd.Parameters["@CHARAC"].Value = "..."; // для начала пусть будет так !

            while (eurocod.Length >= 2)
            {
                switch (side)
                {
                    case "A":
                        key = "A" + eurocod.Substring(eurocod.Length - 2, 2);
                        break;

                    case "B":
                        key = "B" + eurocod.Substring(eurocod.Length - 2, 2);
                        break;

                    case "L":
                    case "R":
                    case "F":
                        key = "C" + eurocod.Substring(eurocod.Length - 2, 2);
                        break;
                }



                описание = (string)htХарактер[key];

                if (описание != null) // берем ключ из массива спецификаций
                {
                    upd.Parameters["@CHARAC"].Value = key; // ключ найден и записан в параметре!
                    key = key.Substring(1, 2);

                    // -- теперь  надо укоротить еврокод до - обрезать характеристики пятака и прочее.
                    // том числе и 4-й знак, который используется на мобискаре  
                    euro = euro.Substring(0, euro.IndexOf(key));
                    break;
                }

                // длина характеристики 3 знака 1-й- сторона , продолжение поиска
                eurocod = (eurocod.Length > 2) ? eurocod.Substring(1, eurocod.Length - 1) : " ";
            }

        }

        private void ParseEuro(string side2)
        {
            string s;
            string parm;

            for (int k = 0; k < euro.Length; k++)
            {
                s = side2 + euro.Substring(k, 1);
                parm = (string)htSPEC_ID[s]; // берем по ключу из массива спецификацию стекла
                if (parm != null)
                {
                    upd.Parameters["@" + parm].Value = 1;
                }
                else
                {
                    break;
                }
            }

        }


        // формирует колонку "НАИМЕНОВАНИЕ" для стекла
        public void DoPrepare()
        {
            upd = new SqlCommand();
            upd.CommandTimeout = 100;
            upd.CommandType = CommandType.StoredProcedure;
            upd.Connection = conn;
            upd.CommandText = "EUROPA_UPD";

            // параметр Наименование
            p_НАИМЕНОВАНИЕ = new SqlParameter();
            p_НАИМЕНОВАНИЕ.ParameterName = "@Наименование";
            p_НАИМЕНОВАНИЕ.SqlDbType = SqlDbType.VarChar;
            p_НАИМЕНОВАНИЕ.Size = 500;
            upd.Parameters.Add(p_НАИМЕНОВАНИЕ);

            // параметр @EURO - он уникальный
            p_EURO = new SqlParameter();
            p_EURO.ParameterName = "@EURO";
            p_EURO.SqlDbType = SqlDbType.VarChar;
            p_EURO.Size = 50;
            upd.Parameters.Add(p_EURO);

            // параметр @SIDE = сторона на которой расположено стекло -
            p_SIDE = new SqlParameter();
            p_SIDE.ParameterName = "@SIDE";
            p_SIDE.SqlDbType = SqlDbType.VarChar;
            p_SIDE.Size = 2;
            upd.Parameters.Add(p_SIDE);

            // кузов @COLOR
            p_COLOR = new SqlParameter();
            p_COLOR.ParameterName = "@COLOR";
            p_COLOR.SqlDbType = SqlDbType.VarChar;
            p_COLOR.Size = 2;
            upd.Parameters.Add(p_COLOR);

            // полоса @STRIP
            p_STRIP = new SqlParameter();
            p_STRIP.ParameterName = "@STRIP";
            p_STRIP.SqlDbType = SqlDbType.VarChar;
            p_STRIP.Size = 2;
            upd.Parameters.Add(p_STRIP);

            // положение @LOCATION
            p_LOCATION = new SqlParameter();
            p_LOCATION.ParameterName = "@LOCATION";
            p_LOCATION.SqlDbType = SqlDbType.VarChar;
            p_LOCATION.Size = 3;
            upd.Parameters.Add(p_LOCATION);

            // положение @readerCMD
            p_CHARAC = new SqlParameter();
            p_CHARAC.ParameterName = "@CHARAC";
            p_CHARAC.SqlDbType = SqlDbType.VarChar;
            p_CHARAC.Size = 3;
            upd.Parameters.Add(p_CHARAC);

            // антенна @Антенна_A_A
            p_Антенна_A_A = new SqlParameter();
            p_Антенна_A_A.ParameterName = "@Антенна_A_A";
            p_Антенна_A_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Антенна_A_A);

            // положение руля @ПравыйРуль_B_A
            p_ПравыйРуль_B_A = new SqlParameter();
            p_ПравыйРуль_B_A.ParameterName = "@ПравыйРуль_B_A";
            p_ПравыйРуль_B_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ПравыйРуль_B_A);

            //  @МестоКамеры_C_A
            p_МестоКамеры_C_A = new SqlParameter();
            p_МестоКамеры_C_A.ParameterName = "@МестоКамеры_C_A";
            p_МестоКамеры_C_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_МестоКамеры_C_A);

            // @GPS_G_A
            p_GPS_G_A = new SqlParameter();
            p_GPS_G_A.ParameterName = "@GPS_G_A";
            p_GPS_G_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_GPS_G_A);

            // @Обогрев_H_A
            p_Обогрев_H_A = new SqlParameter();
            p_Обогрев_H_A.ParameterName = "@Обогрев_H_A";
            p_Обогрев_H_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Обогрев_H_A);

            // @Обогрев_F_A
            p_Обогрев_F_A = new SqlParameter();
            p_Обогрев_F_A.ParameterName = "@Обогрев_F_A";
            p_Обогрев_F_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Обогрев_F_A);

            // @TV_антенна_A
            p_TV_антенна_J_A = new SqlParameter();
            p_TV_антенна_J_A.ParameterName = "@TV_антенна_J_A";
            p_TV_антенна_J_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_TV_антенна_J_A);

            // @ЛеваяПоловина_L_A
            p_ЛеваяПоловина_L_A = new SqlParameter();
            p_ЛеваяПоловина_L_A.ParameterName = "@ЛеваяПоловина_L_A";
            p_ЛеваяПоловина_L_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ЛеваяПоловина_L_A);

            // @МестоДД_M_A
            p_МестоДД_M_A = new SqlParameter();
            p_МестоДД_M_A.ParameterName = "@МестоДД_M_A";
            p_МестоДД_M_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_МестоДД_M_A);

            // @Водооталк_N_A
            p_Водооталк_N_A = new SqlParameter();
            p_Водооталк_N_A.ParameterName = "@Водооталк_N_A";
            p_Водооталк_N_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Водооталк_N_A);

            // @ДатчикТумана_O_A
            p_ДатчикТумана_O_A = new SqlParameter();
            p_ДатчикТумана_O_A.ParameterName = "@ДатчикТумана_O_A";
            p_ДатчикТумана_O_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ДатчикТумана_O_A);

            // @Окно_ДД_P_A
            p_Окно_ДД_P_A = new SqlParameter();
            p_Окно_ДД_P_A.ParameterName = "@Окно_ДД_P_A";
            p_Окно_ДД_P_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Окно_ДД_P_A);

            // @ПодогревАнтенны_P_A
            p_ПодогревАнтенны_P_A = new SqlParameter();
            p_ПодогревАнтенны_P_A.ParameterName = "@ПодогревАнтенны_P_A";
            p_ПодогревАнтенны_P_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ПодогревАнтенны_P_A);

            // @ПраваяПоловина_R_A
            p_ПраваяПоловина_R_A = new SqlParameter();
            p_ПраваяПоловина_R_A.ParameterName = "@ПраваяПоловина_R_A";
            p_ПраваяПоловина_R_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ПраваяПоловина_R_A);

            // @Дисплей_U_A
            p_Дисплей_U_A = new SqlParameter();
            p_Дисплей_U_A.ParameterName = "@Дисплей_U_A";
            p_Дисплей_U_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Дисплей_U_A);

            // @VINокно_V_A
            p_VINокно_V_A = new SqlParameter();
            p_VINокно_V_A.ParameterName = "@VINокно_V_A";
            p_VINокно_V_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_VINокно_V_A);

            // @Крепеж_W_A
            p_Крепеж_W_A = new SqlParameter();
            p_Крепеж_W_A.ParameterName = "@Крепеж_W_A";
            p_Крепеж_W_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Крепеж_W_A);

            // @Инкапсуляция_Z_A
            p_Инкапсуляция_Z_A = new SqlParameter();
            p_Инкапсуляция_Z_A.ParameterName = "@Инкапсуляция_Z_A";
            p_Инкапсуляция_Z_A.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Инкапсуляция_Z_A);

            // @Антенна_A_B
            p_Антенна_A_B = new SqlParameter();
            p_Антенна_A_B.ParameterName = "@Антенна_A_B";
            p_Антенна_A_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Антенна_A_B);

            // @Стопсигнал_B_B
            p_Стопсигнал_B_B = new SqlParameter();
            p_Стопсигнал_B_B.ParameterName = "@Стопсигнал_B_B";
            p_Стопсигнал_B_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Стопсигнал_B_B);

            // @ЦентральнаяЧасть_C_B
            p_ЦентральнаяЧасть_C_B = new SqlParameter();
            p_ЦентральнаяЧасть_C_B.ParameterName = "@ЦентральнаяЧасть_C_B";
            p_ЦентральнаяЧасть_C_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ЦентральнаяЧасть_C_B);

            // @Стеклопакет_D_B
            p_Стеклопакет_D_B = new SqlParameter();
            p_Стеклопакет_D_B.ParameterName = "@Стеклопакет_D_B";
            p_Стеклопакет_D_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Стеклопакет_D_B);

            // @GPS_G_B
            p_GPS_G_B = new SqlParameter();
            p_GPS_G_B.ParameterName = "@GPS_G_B";
            p_GPS_G_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_GPS_G_B);

            // @TV_антенна_J_B
            p_TV_антенна_J_B = new SqlParameter();
            p_TV_антенна_J_B.ParameterName = "@TV_антенна_J_B";
            p_TV_антенна_J_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_TV_антенна_J_B);

            // @Триплекс_K_B
            p_Триплекс_K_B = new SqlParameter();
            p_Триплекс_K_B.ParameterName = "@Триплекс_K_B";
            p_Триплекс_K_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Триплекс_K_B);

            // @ЛеваяПоловина_L_B
            p_ЛеваяПоловина_L_B = new SqlParameter();
            p_ЛеваяПоловина_L_B.ParameterName = "@ЛеваяПоловина_L_B";
            p_ЛеваяПоловина_L_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ЛеваяПоловина_L_B);

            // @ПраваяПоловина_L_B
            p_ПраваяПоловина_R_B = new SqlParameter();
            p_ПраваяПоловина_R_B.ParameterName = "@ПраваяПоловина_R_B";
            p_ПраваяПоловина_R_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ПраваяПоловина_R_B);


            // @АварОповещение_M_B
            p_АварОповещение_M_B = new SqlParameter();
            p_АварОповещение_M_B.ParameterName = "@АварОповещение_M_B";
            p_АварОповещение_M_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_АварОповещение_M_B);

            // @Водоотталкивающее_N_B
            p_Водоотталкивающее_N_B = new SqlParameter();
            p_Водоотталкивающее_N_B.ParameterName = "@Водоотталкивающее_N_B";
            p_Водоотталкивающее_N_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Водоотталкивающее_N_B);

            // @Открывающееся_O_B
            p_Открывающееся_O_B = new SqlParameter();
            p_Открывающееся_O_B.ParameterName = "@Открывающееся_O_B";
            p_Открывающееся_O_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Открывающееся_O_B);

            // @АнтеннаТелефона_P_B
            p_АнтеннаТелефона_P_B = new SqlParameter();
            p_АнтеннаТелефона_P_B.ParameterName = "@АнтеннаТелефона_P_B";
            p_АнтеннаТелефона_P_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_АнтеннаТелефона_P_B);

            // @ВыдвигающаясяАнтенна_Q_B
            p_ВыдвигающаясяАнтенна_Q_B = new SqlParameter();
            p_ВыдвигающаясяАнтенна_Q_B.ParameterName = "@ВыдвигающаясяАнтенна_Q_B";
            p_ВыдвигающаясяАнтенна_Q_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ВыдвигающаясяАнтенна_Q_B);

            // @РамкаСподвИнеподвСтеклом_S_B
            p_РамкаСподвИнеподвСтеклом_S_B = new SqlParameter();
            p_РамкаСподвИнеподвСтеклом_S_B.ParameterName = "@РамкаСподвИнеподвСтеклом_S_B";
            p_РамкаСподвИнеподвСтеклом_S_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_РамкаСподвИнеподвСтеклом_S_B);

            // @TopBand_T_B
            p_TopBand_T_B = new SqlParameter();
            p_TopBand_T_B.ParameterName = "@TopBand_T_B";
            p_TopBand_T_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_TopBand_T_B);

            // @БезОбогрева_U_B
            p_БезОбогрева_U_B = new SqlParameter();
            p_БезОбогрева_U_B.ParameterName = "@БезОбогрева_U_B";
            p_БезОбогрева_U_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_БезОбогрева_U_B);

            // @VINокно_V_B
            p_VINокно_V_B = new SqlParameter();
            p_VINокно_V_B.ParameterName = "@VINокно_V_B";
            p_VINокно_V_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_VINокно_V_B);

            // @Крепеж_W_B
            p_Крепеж_W_B = new SqlParameter();
            p_Крепеж_W_B.ParameterName = "@Крепеж_W_B";
            p_Крепеж_W_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Крепеж_W_B);

            // @ПроводСигнализации_X
            p_ПроводСигнализации_X_B = new SqlParameter();
            p_ПроводСигнализации_X_B.ParameterName = "@ПроводСигнализации_X_B";
            p_ПроводСигнализации_X_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ПроводСигнализации_X_B);

            // @Верхнее_Y_B
            p_Верхнее_Y_B = new SqlParameter();
            p_Верхнее_Y_B.ParameterName = "@Верхнее_Y_B";
            p_Верхнее_Y_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Верхнее_Y_B);

            // @Инкапсуляция_Z_B
            p_Инкапсуляция_Z_B = new SqlParameter();
            p_Инкапсуляция_Z_B.ParameterName = "@Инкапсуляция_Z_B";
            p_Инкапсуляция_Z_B.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Инкапсуляция_Z_B);

            // @Антенна_A_C
            p_Антенна_A_C = new SqlParameter();
            p_Антенна_A_C.ParameterName = "@Антенна_A_C";
            p_Антенна_A_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Антенна_A_C);

            // @Стеклопакет_D_C
            p_Стеклопакет_D_C = new SqlParameter();
            p_Стеклопакет_D_C.ParameterName = "@Стеклопакет_D_C";
            p_Стеклопакет_D_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Стеклопакет_D_C);

            // @ОткрываемоеЕлектрически_E_C
            p_ОткрываемоеЕлектрически_E_C = new SqlParameter();
            p_ОткрываемоеЕлектрически_E_C.ParameterName = "@ОткрываемоеЕлектрически_E_C";
            p_ОткрываемоеЕлектрически_E_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ОткрываемоеЕлектрически_E_C);

            // @РамкаСподвИнеподвСтеклом_F_C
            p_РамкаСподвИнеподвСтеклом_F_C = new SqlParameter();
            p_РамкаСподвИнеподвСтеклом_F_C.ParameterName = "@РамкаСподвИнеподвСтеклом_F_C";
            p_РамкаСподвИнеподвСтеклом_F_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_РамкаСподвИнеподвСтеклом_F_C);

            // @GPS_G_C
            p_GPS_G_C = new SqlParameter();
            p_GPS_G_C.ParameterName = "@GPS_G_C";
            p_GPS_G_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_GPS_G_C);

            // @Обогрев_H_C
            p_Обогрев_H_C = new SqlParameter();
            p_Обогрев_H_C.ParameterName = "@Обогрев_H_C";
            p_Обогрев_H_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Обогрев_H_C);

            // @TV_антенна_J_C
            p_TV_антенна_J_C = new SqlParameter();
            p_TV_антенна_J_C.ParameterName = "@TV_антенна_J_C";
            p_TV_антенна_J_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_TV_антенна_J_C);

            // @Триплекс_K_C
            p_Триплекс_K_C = new SqlParameter();
            p_Триплекс_K_C.ParameterName = "@Триплекс_K_C";
            p_Триплекс_K_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Триплекс_K_C);

            // @Водоотталкивающее_N_C
            p_Водоотталкивающее_N_C = new SqlParameter();
            p_Водоотталкивающее_N_C.ParameterName = "@Водоотталкивающее_N_C";
            p_Водоотталкивающее_N_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Водоотталкивающее_N_C);

            // @Открывающееся_O_C
            p_Открывающееся_O_C = new SqlParameter();
            p_Открывающееся_O_C.ParameterName = "@Открывающееся_O_C";
            p_Открывающееся_O_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Открывающееся_O_C);

            // @ПодогревАнтенны_P_C
            p_ПодогревАнтенны_P_C = new SqlParameter();
            p_ПодогревАнтенны_P_C.ParameterName = "@ПодогревАнтенны_P_C";
            p_ПодогревАнтенны_P_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ПодогревАнтенны_P_C);

            // @ВыдвигающаясяАнтенна_Q_C
            p_ВыдвигающаясяАнтенна_Q_C = new SqlParameter();
            p_ВыдвигающаясяАнтенна_Q_C.ParameterName = "@ВыдвигающаясяАнтенна_Q_C";
            p_ВыдвигающаясяАнтенна_Q_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ВыдвигающаясяАнтенна_Q_C);

            // @Подвижное_S_C
            p_Подвижное_S_C = new SqlParameter();
            p_Подвижное_S_C.ParameterName = "@Подвижное_S_C";
            p_Подвижное_S_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Подвижное_S_C);

            // @ФиксаторОткрывания_T_C
            p_ФиксаторОткрывания_T_C = new SqlParameter();
            p_ФиксаторОткрывания_T_C.ParameterName = "@ФиксаторОткрывания_T_C";
            p_ФиксаторОткрывания_T_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ФиксаторОткрывания_T_C);

            // @Верхнее_U_C
            p_Верхнее_U_C = new SqlParameter();
            p_Верхнее_U_C.ParameterName = "@Верхнее_U_C";
            p_Верхнее_U_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Верхнее_U_C);

            // @VIN_V_C
            p_VIN_V_C = new SqlParameter();
            p_VIN_V_C.ParameterName = "@VIN_V_C";
            p_VIN_V_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_VIN_V_C);

            // @Крепеж_W_C
            p_Крепеж_W_C = new SqlParameter();
            p_Крепеж_W_C.ParameterName = "@Крепеж_W_C";
            p_Крепеж_W_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Крепеж_W_C);

            // @ПроводСигнализации_X_C
            p_ПроводСигнализации_X_C = new SqlParameter();
            p_ПроводСигнализации_X_C.ParameterName = "@ПроводСигнализации_X_C";
            p_ПроводСигнализации_X_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_ПроводСигнализации_X_C);

            // @Инкапсуляция_Z_C
            p_Инкапсуляция_Z_C = new SqlParameter();
            p_Инкапсуляция_Z_C.ParameterName = "@Инкапсуляция_Z_C";
            p_Инкапсуляция_Z_C.SqlDbType = SqlDbType.Bit;
            upd.Parameters.Add(p_Инкапсуляция_Z_C);



            readerCMD = new SqlCommand();
            readerCMD.CommandText =
                "SELECT EURO FROM EUROPA2  WHERE SUBSTRING(EURO,6,1) <>'S' AND  VER ='*' ";
            readerCMD.Connection = con;

            conn.Open();
            con.Open();
            SqlDataReader reader = readerCMD.ExecuteReader();

            while (reader.Read())
            {
                ZeroParam();
                euro = (string)reader["EURO"] + "     ";
                switch (euro.Substring(4, 1))
                {
                    case "A":
                        A_Glass();
                        flag_update = true;
                        break;

                    case "L":
                    case "R":
                    case "F":
                        C_Glass();
                        flag_update = true;
                        break;

                    case "B":
                        B_Glass();
                        flag_update = true;
                        break;
                }

                if (flag_update)
                {
                    upd.ExecuteNonQuery();
                    flag_update = false;
                }
            }


            con.Close();
            conn.Close();

        }

    }

}
