using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Text;
using System.IO;


namespace Preparator
{
    public partial class frmMain : Form
    {
        string alt;

        string SQLconnect;
        MySqlConnection con_update;
        SqlConnection scon_update;

        MySqlConnection con_update2;
        SqlConnection scon_update2;

        string query;

        SqlConnection con;
        SqlConnection con_marki;

        SqlCommand cmd;
        MySqlCommand cmd_update;
        SqlCommand scmd_update;

        MySqlCommand cmd_update2;
        SqlCommand scmd_update2;

        SqlCommand cmd_marki;
        SqlCommand cmd_mmby;

        MySqlParameter pId_marka_marka;
        SqlParameter spId_marka_marka;

        SqlParameter p_marka;

        MySqlParameter pHtml_marka;
        SqlParameter spHtml_marka;

        StringBuilder sb;
        StringBuilder bhtml;

        SqlDataReader dr;
        SqlDataReader dr_mmby;
        SqlDataReader dr_marka;

        int iid = 1000;
        int idglass;
        string id;
        string id_marka;
        string Wmodel;
        bool rd_result;
        string id_photo;
        string marka;

        MySqlParameter pIdglass;
        MySqlParameter pSide;
        MySqlParameter pLocation;
        MySqlParameter pHtml;
        MySqlParameter pMarka;
        MySqlParameter pModel;
        MySqlParameter pBody;
        MySqlParameter pWmodel;
        MySqlParameter pData;
        MySqlParameter pBodi;
        MySqlParameter pCena;
        MySqlParameter pProducer;
        MySqlParameter pDD;
        MySqlParameter poknoDD_P_A;
        MySqlParameter pRul;
        MySqlParameter pHud;
        MySqlParameter pTV_FW;
        MySqlParameter pGPS_FW;
        MySqlParameter pCamera;
        MySqlParameter pObogrev_fw;
        MySqlParameter pObogref_fw;
        MySqlParameter pAntenna_fw;

        MySqlParameter pObogrev_rw;
        MySqlParameter pAntenna_rw;
        MySqlParameter pTriplex_rw;
        MySqlParameter pStop_rw;
        MySqlParameter pTV_RW;
        MySqlParameter pGPS_RW;
        MySqlParameter pKrepezh_rw;
        MySqlParameter pInkapsulazia_rw;
        MySqlParameter pVerhnee_rw;
        
        MySqlParameter pBody_left;
        MySqlParameter pBody_right;
        MySqlParameter pFd_left;
        MySqlParameter pFd_right;
        MySqlParameter pRd_left;
        MySqlParameter pRd_right;
        MySqlParameter pObogrev_lr;
        MySqlParameter pTV_antenna_lr;
        MySqlParameter pKrepezh_lr;
        MySqlParameter pPodvizhnoe_lr;
        MySqlParameter pInkapsulazia_lr;
        MySqlParameter pVerhnee_lr;
        MySqlParameter pTriplex_lr;
        MySqlParameter pRazdel;
        MySqlParameter pid_sensor;
        MySqlParameter pEurocode;
        

        SqlParameter spIdglass;
        SqlParameter spSide;
        SqlParameter spLocation;
        SqlParameter spHtml;
        SqlParameter spMarka;
        SqlParameter spModel;
        SqlParameter spBody;
        SqlParameter spWmodel;
        SqlParameter spData;
        SqlParameter spBodi;
        SqlParameter spCena;      
        SqlParameter spProducer;
        SqlParameter spDD;
        SqlParameter spoknoDD_P_A;
        SqlParameter spRul;
        SqlParameter spHud;
        SqlParameter spTV_FW;
        SqlParameter spGPS_FW;
        SqlParameter spCamera;
        SqlParameter spObogrev_fw;
        SqlParameter spObogref_fw;
        SqlParameter spAntenna_fw;


        SqlParameter spObogrev_rw;
        SqlParameter spAntenna_rw;
        SqlParameter spTriplex_rw;
        SqlParameter spStop_rw;
        SqlParameter spTV_RW;
        SqlParameter spGPS_RW;
        SqlParameter spKrepezh_rw;
        SqlParameter spInkapsulazia_rw;
        SqlParameter spVerhnee_rw;
        SqlParameter spBody_left;
        SqlParameter spBody_right;
        SqlParameter spFd_left;
        SqlParameter spFd_right;
        SqlParameter spRd_left;
        SqlParameter spRd_right;
        SqlParameter spObogrev_lr;
        SqlParameter spTV_antenna_lr;
        SqlParameter spKrepezh_lr;
        SqlParameter spPodvizhnoe_lr;
        SqlParameter spInkapsulazia_lr;
        SqlParameter spVerhnee_lr;
        SqlParameter spTriplex_lr;

        SqlParameter spRazdel;
        SqlParameter spid_sensor;
        SqlParameter spEurocode;
        


        string razdel;
        string side;
        string location;
        string producer;
        string цена;  // цена
        string id_sensor;
        string положение;
        string отверстий;
        string color;
        string strip;
       
        
        bool ПравыйРуль;
        bool МестоКамеры_C_A;
        bool GPS_G_A;
        bool Обогрев_H_A;
        bool Обогрев_F_A;
        bool TV_антенна_J_A;
        bool Антенна_A_A;
        bool ЛеваяПоловина_L_A;
        bool МестоДД_M_A;
        bool Водооталк_N_A;
        bool ДатчикТумана_O_A;
        bool Окно_ДД_P_A;
        bool ПраваяПоловина_R_A;
        bool Дисплей_U_A;
        bool Крепеж_W_A;
        bool Инкапсуляция_Z_A;

        bool Антенна_A_B;
        bool Стопсигнал_B_B;
        bool steklopaket_D_B;
        bool GPS_G_B;
        bool TV_антенна_J_B;
        bool Триплекс_K_B;
        bool Открывающееся_O_B;
        bool РамкаСподвИнеподвСтеклом_S_B;
        bool БезОбогрева_U_B;
        bool VINокно_V_B;
        bool ПраваяПоловина_R_B;
        bool ЛеваяПоловина_L_B;
        bool Крепеж_W_B;
        bool ПроводСигнализации_X_B;
        bool Верхнее_Y_B;
        bool Инкапсуляция_Z_B;

        bool Антенна_A_C;
        bool Стеклопакет_D_C;
        bool ОткрываемоеЕлектрически_E_C;
        bool РамкаСподвИнеподвСтеклом_F_C;
        bool GPS_G_C;
        bool Обогрев_H_C;
        bool TV_антенна_J_C;
        bool Триплекс_K_C;
        bool Открывающееся_O_C;
        bool ВыдвигающаясяАнтенна_Q_C;
        bool Подвижное_S_C;
        bool ФиксаторОткрывания_T_C;
        bool Верхнее_U_C;
        bool VIN_V_C;
        bool Крепеж_W_C;
        bool Инкапсуляция_Z_C;

        string model;
        string data;
        string body;
        string mesto;
        string model_k; // dr["Model_K"].ToString();

        string bodyl;
        string date2;
        string height;
        string width;
        string eurocode;
        string raspolozhenie;


        private void frmMain_Load(object sender, EventArgs e)
        {
            scon_update = new SqlConnection();
            con_update = new MySqlConnection();

            scon_update2 = new SqlConnection();
            con_update2 = new MySqlConnection();

            cmd_update2 = new MySqlCommand();
            cmd_update2.CommandType = CommandType.StoredProcedure;
            cmd_update2.CommandText = "SAVE_GLASS";

            scmd_update2 = new SqlCommand();
            scmd_update2.CommandType = CommandType.StoredProcedure;
            scmd_update2.CommandText = "SAVE_GLASS";


            query = " SELECT "
                          + "ID_GLASS"
                          + ",RAZDEL"
                          + ",SIDE"
                          + ",PRODUCER"  // producer;
                          + ",PRICE"     // price;
                          + ",ID_SENSOR" //id_sensor;
                          + ",Положение"  // H5_AA 
                          + ",отверстий" //otverstiy;
                          + ",color"      // color
                          + ",strip"        //  strip
                          + ",ПравыйРуль"   // pravyrul;
                          + ",МестоКамеры_C_A"  //  camera;
                          + ",GPS_G_A"       //  GPS_G_A;
                          + ",Обогрев_H_A"    //  obogrev_H_A;
                          + ",Обогрев_F_A"    //  obogrev_F_A;
                          + ",TV_антенна_J_A"   //  TV_A;
                          + ",Антенна_A_A"   //  Антенна_A_A радио антенна
                          + ",ЛеваяПоловина_L_A"  //    levajapolovina_L_A;
                          + ",МестоДД_M_A"       //    mestoDD_M_A;
                          + ",Водооталк_N_A"     //    vodoottalk_N_A;
                          + ",ДатчикТумана_O_A"  //    datchiktumana_O_A;
                          + ",Окно_ДД_P_A"       //    oknoDD_P_A;
                          + ",ПраваяПоловина_R_A"    //    pravajapolovina_R_A;
                          + ",Дисплей_U_A"       //    display_U_A;
                          + ",Крепеж_W_A"       //    krepezh_W_A;
                          + ",Инкапсуляция_Z_A"   //    incapsulacia_Z_A;
                          + ",Антенна_A_B"       //    antenna_A_B;
                          + ",Стопсигнал_B_B"    //    stop_B_B;
                          + ",Стеклопакет_D_B"   //    steklopaket_D_B;
                          + ",GPS_G_B"          //    GPS_G_B;
                          + ",TV_антенна_J_B"   //    TV_B;
                          + ",Триплекс_K_B"      //    triplex_K_B;
                          + ",Открывающееся_O_B"   //    otkryv_O_B;
                          + ",РамкаСподвИнеподвСтеклом_S_B"  //    ramka_S_B;
                          + ",БезОбогрева_U_B"        //    bezobogreva_U_B;
                          + ",VInокно_V_B"            //    vin_V_B;
                          + ",ПраваяПоловина_R_B"    //    pravajapolovina_R_B;
                          + ",ЛеваяПоловина_L_B"     //    levajapolovina_L_B;
                          + ",Крепеж_W_B"      //    krepezh_W_B;
                          + ",ПроводСигнализации_X_B"    //    provod_X_B;
                          + ",Верхнее_Y_B"           //    verhnee_Y_B;
                          + ",Инкапсуляция_Z_B"     //    incapsulacia_Z_B;
                          + ",Антенна_A_C"         // antenna_A_C;
                          + ",Стеклопакет_D_C"      //    steklopaket_D_C;
                          + ",ОткрываемоеЕлектрически_E_C"  //    otkryvaemoeelektricheski_E_C;
                          + ",РамкаСподвИнеподвСтеклом_F_C"   //    ramka_c_podvizhNepodvsteklom_F_C;
                          + ",GPS_G_C"            //    GPS_G_C;
                          + ",Обогрев_H_C"     //    obogrev_H_C;
                          + ",TV_антенна_J_C"   //    TV_J_C;
                          + ",Триплекс_K_C"     //    triplex_K_C;
                          + ",Открывающееся_O_C"   //    otkryv_O_C;
                          + ",ВыдвигающаясяАнтенна_Q_C"  // ВЫДВИНАЮЩ. АНТЕННА
                          + ",Подвижное_S_C"      //    podvizhnoe_S_C;
                          + ",ФиксаторОткрывания_T_C"   //    fixator_T_C;
                          + ",Верхнее_U_C"       //    verhnee_U_C;
                          + ",VIN_V_C"      //    VIN_V_C;
                          + ",Крепеж_W_C"    //    krepezh_W_C;
                          + ",Инкапсуляция_Z_C"   //    incapsulacia_Z_C;
                          + ",marka"
                          + ",model"    //    model="";
                          + ",web_name"
                          + ",data"       //    data="";
                          + ",body"
                          + ",mesto"  //  РАСПОЛОЖЕНИЕ СЛОВАМИ  raspolozhenie = "";  стекло лобовое /стекло заднее
                          + ",ID_body" 
                          + ",BODYL"  
                          + ",DATE2"   
                          + ",WIDTH"
                          + ",HEIGHT"
                          + ",EUROCODE"
                          + " FROM GLASSC "; // ORDER BY model_k";   WHERE Model_K='7684S4'  WHERE ID_Model='7978'



            SQLconnect = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

            sb = new StringBuilder();
            con = new SqlConnection();
            con.ConnectionString = SQLconnect;

            scon_update.ConnectionString = ConfigurationManager.ConnectionStrings["scon_update"].ConnectionString;
            con_update.ConnectionString = ConfigurationManager.ConnectionStrings["con_update"].ConnectionString;

            scon_update2.ConnectionString = ConfigurationManager.ConnectionStrings["scon_update"].ConnectionString;
            con_update2.ConnectionString = ConfigurationManager.ConnectionStrings["con_update"].ConnectionString;

            con_marki = new SqlConnection();
            con_marki.ConnectionString = SQLconnect;

            scmd_update = new SqlCommand();
            scmd_update.Connection = scon_update2;
            scmd_update.CommandText = "UPDATE MARKY SET html = @html Where id_marka=@id_marka";

            cmd_update = new MySqlCommand();
            cmd_update.Connection = con_update2;
            cmd_update.CommandText = "UPDATE MARKA SET html = @html Where id_marka=@id_marka";

            //----------- параметры обновления  марки --------------------------------------------
            scmd_update.Parameters.Clear();
            cmd_update.Parameters.Clear();

            pHtml_marka = new MySqlParameter();
            pHtml_marka.DbType = DbType.String;
            pHtml_marka.ParameterName = "html";
            pHtml_marka.Size = 8192;
            cmd_update.Parameters.Add(pHtml_marka);

            spHtml_marka = new SqlParameter();
            spHtml_marka.DbType = DbType.String;
            spHtml_marka.ParameterName = "@html";
            spHtml_marka.Size = 8192;
            scmd_update.Parameters.Add(spHtml_marka);

            pId_marka_marka = new MySqlParameter();
            pId_marka_marka.DbType = DbType.String;
            pId_marka_marka.Size = 10;
            pId_marka_marka.ParameterName = "id_marka";
            cmd_update.Parameters.Add(pId_marka_marka);

            spId_marka_marka = new SqlParameter();
            spId_marka_marka.DbType = DbType.String;
            spId_marka_marka.Size = 10;
            spId_marka_marka.ParameterName = "@id_marka";
            scmd_update.Parameters.Add(spId_marka_marka);

            cmd_marki = new SqlCommand();
            cmd_marki.Connection = con_marki;
            cmd_marki.CommandText = "SELECT  id_marka  FROM  MARKY  ORDER BY id_marka";

            cmd_mmby = new SqlCommand();
            cmd_mmby.Connection = con;
            cmd_mmby.CommandType = CommandType.Text;
            cmd_mmby.CommandText = "SELECT Id_marka,WEB_NAME,WMODEL,DATA,BODY,BODYL,DATA2,ID_BODY, ID_BODI,ID_PHOTO,ID_MODEL,ID_BODY  FROM MMBY WHERE Id_marka=@id_marka ORDER BY WEB_NAME,DATA DESC,BODYL";

            p_marka = new SqlParameter();
            p_marka.SqlDbType = SqlDbType.VarChar;
            p_marka.Size = 10;
            p_marka.ParameterName = "@id_marka";
            cmd_mmby.Parameters.Add(p_marka);


            //--- параметры обновления  стекла ------------
            pIdglass = new MySqlParameter();
            pIdglass.ParameterName = "id_glass";
            pIdglass.DbType = DbType.Int32;
            cmd_update2.Parameters.Add(pIdglass);

            spIdglass = new SqlParameter();
            spIdglass.ParameterName = "@id_glass";
            spIdglass.DbType = DbType.Int32;
            scmd_update2.Parameters.Add(spIdglass);

            //-------------------------------------------
            pSide = new MySqlParameter();
            pSide.DbType = DbType.String;
            pSide.Size = 5;
            pSide.ParameterName = "side";
            cmd_update2.Parameters.Add(pSide);

            spSide = new SqlParameter();
            spSide.DbType = DbType.String;
            spSide.Size = 5;
            spSide.ParameterName = "@side";
            scmd_update2.Parameters.Add(spSide);

            pLocation = new MySqlParameter();
            pLocation.DbType = DbType.String;
            pLocation.Size = 20;
            pLocation.ParameterName = "flocation";
            cmd_update2.Parameters.Add(pLocation);

            spLocation = new SqlParameter();
            spLocation.DbType = DbType.String;
            spLocation.Size = 20;
            spLocation.ParameterName = "@flocation";
            scmd_update2.Parameters.Add(spLocation);


            //--------------------------------------
            pHtml = new MySqlParameter();
            pHtml.DbType = DbType.String;
            pHtml.Size = 64000;
            pHtml.ParameterName = "html";
            cmd_update2.Parameters.Add(pHtml);

            spHtml = new SqlParameter();
            spHtml.DbType = DbType.String;
            spHtml.Size = 64000;
            spHtml.ParameterName = "@html";
            scmd_update2.Parameters.Add(spHtml);

            //--------------------------------------
            pMarka = new MySqlParameter();
            pMarka.DbType = DbType.String;
            pMarka.Size = 80;
            pMarka.ParameterName = "marka";
            cmd_update2.Parameters.Add(pMarka);

            spMarka = new SqlParameter();
            spMarka.DbType = DbType.String;
            spMarka.Size = 80;
            spMarka.ParameterName = "@marka";
            scmd_update2.Parameters.Add(spMarka);

            //--------------------------------------
            pModel = new MySqlParameter();
            pModel.ParameterName = "model";
            pModel.DbType = DbType.String;
            pModel.Size = 256;
            cmd_update2.Parameters.Add(pModel);

            spModel = new SqlParameter();
            spModel.ParameterName = "@model";
            spModel.DbType = DbType.String;
            spModel.Size = 256;
            scmd_update2.Parameters.Add(spModel);

            //--------------------------------------------
            pBody = new MySqlParameter();
            pBody.DbType = DbType.String;
            pBody.Size = 30;
            pBody.ParameterName = "idbody";
            cmd_update2.Parameters.Add(pBody);

            spBody = new SqlParameter();
            spBody.DbType = DbType.String;
            spBody.Size = 30;
            spBody.ParameterName = "@idbody";
            scmd_update2.Parameters.Add(spBody);

            //------------------------------------
            pWmodel = new MySqlParameter();
            pWmodel.ParameterName = "wmodel";
            pWmodel.DbType = DbType.String;
            pWmodel.Size = 256;
            cmd_update2.Parameters.Add(pWmodel);

            spWmodel = new SqlParameter();
            spWmodel.ParameterName = "@wmodel";
            spWmodel.DbType = DbType.String;
            spWmodel.Size = 256;
            scmd_update2.Parameters.Add(spWmodel);


            //-------------------------------------
            pData = new MySqlParameter();
            pData.DbType = DbType.String;
            pData.Size = 50;
            pData.ParameterName = "data";
            cmd_update2.Parameters.Add(pData);

            spData = new SqlParameter();
            spData.DbType = DbType.String;
            spData.Size = 50;
            spData.ParameterName = "@data";
            scmd_update2.Parameters.Add(spData);



            //-------------------------------------
            pBodi = new MySqlParameter();
            pBodi.DbType = DbType.String;
            pBodi.Size = 50;
            pBodi.ParameterName = "body";
            cmd_update2.Parameters.Add(pBodi);

            spBodi = new SqlParameter();
            spBodi.DbType = DbType.String;
            spBodi.Size = 50;
            spBodi.ParameterName = "@body";
            scmd_update2.Parameters.Add(spBodi);


            //------------------------------------
            pCena = new MySqlParameter();
            pCena.ParameterName = "cena";
            pCena.DbType = DbType.Int32;
            cmd_update2.Parameters.Add(pCena);

            spCena = new SqlParameter();
            spCena.ParameterName = "@cena";
            spCena.DbType = DbType.Int32;
            scmd_update2.Parameters.Add(spCena);


            //-----------------------------------------
            pProducer = new MySqlParameter();
            pProducer.ParameterName = "producer";
            pProducer.DbType = DbType.String;
            pProducer.Size = 50;
            cmd_update2.Parameters.Add(pProducer);

            spProducer = new SqlParameter();
            spProducer.ParameterName = "@producer";
            spProducer.DbType = DbType.String;
            spProducer.Size = 50;
            scmd_update2.Parameters.Add(spProducer);


            //---------------------------------------------
            pDD = new MySqlParameter();
            pDD.DbType = DbType.Byte;
            pDD.ParameterName = "dd";
            cmd_update2.Parameters.Add(pDD);

            spDD = new SqlParameter();
            spDD.DbType = DbType.Byte;
            spDD.ParameterName = "@dd";
            scmd_update2.Parameters.Add(spDD);

            //-----------------------------------------------
            poknoDD_P_A = new MySqlParameter();
            poknoDD_P_A.DbType = DbType.Byte;
            poknoDD_P_A.ParameterName = "oknoDD_P_A";
            cmd_update2.Parameters.Add(poknoDD_P_A);

            spoknoDD_P_A = new SqlParameter();
            spoknoDD_P_A.DbType = DbType.Byte;
            spoknoDD_P_A.ParameterName = "@oknoDD_P_A";
            scmd_update2.Parameters.Add(spoknoDD_P_A);


            // ---------------------------------------------
            pRul = new MySqlParameter();
            pRul.ParameterName = "pravrul";
            pRul.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pRul);

            spRul = new SqlParameter();
            spRul.ParameterName = "@pravrul";
            spRul.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spRul);



            //---------------------------------------
            pHud = new MySqlParameter();
            pHud.ParameterName = "hud";
            pHud.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pHud);

            spHud = new SqlParameter();
            spHud.ParameterName = "@hud";
            spHud.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spHud);

            //---------------------------------------
            pTV_FW = new MySqlParameter();
            pTV_FW.ParameterName = "tv_fw";
            pTV_FW.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pTV_FW);

            spTV_FW = new SqlParameter();
            spTV_FW.ParameterName = "@tv_fw";
            spTV_FW.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spTV_FW);

            //---------------------------------------
            pGPS_FW = new MySqlParameter();
            pGPS_FW.ParameterName = "gps_fw";
            pGPS_FW.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pGPS_FW);

            spGPS_FW = new SqlParameter();
            spGPS_FW.ParameterName = "@gps_fw";
            spGPS_FW.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spGPS_FW);

            //-----------------------------------------------
            pCamera = new MySqlParameter();
            pCamera.DbType = DbType.Byte;
            pCamera.ParameterName = "camera";
            cmd_update2.Parameters.Add(pCamera);

            spCamera = new SqlParameter();
            spCamera.DbType = DbType.Byte;
            spCamera.ParameterName = "@camera";
            scmd_update2.Parameters.Add(spCamera);

            //---------------------------------------------
            pObogrev_fw = new MySqlParameter(); ;
            pObogrev_fw.DbType = DbType.Byte;
            pObogrev_fw.ParameterName = "obogrev_fw";
            cmd_update2.Parameters.Add(pObogrev_fw);

            spObogrev_fw = new SqlParameter();
            spObogrev_fw.DbType = DbType.Byte;
            spObogrev_fw.ParameterName = "@obogrev_fw";
            scmd_update2.Parameters.Add(spObogrev_fw);

            //-----------------------------------------------
            pObogref_fw = new MySqlParameter();
            pObogref_fw.DbType = DbType.Byte;
            pObogref_fw.ParameterName = "obogref_fw";
            cmd_update2.Parameters.Add(pObogref_fw);

            spObogref_fw = new SqlParameter();
            spObogref_fw.DbType = DbType.Byte;
            spObogref_fw.ParameterName = "@obogref_fw";
            scmd_update2.Parameters.Add(spObogref_fw);

            //-----------------------------------------------
            pAntenna_fw = new MySqlParameter();
            pAntenna_fw.DbType = DbType.Byte;
            pAntenna_fw.ParameterName = "antenna_fw";
            cmd_update2.Parameters.Add(pAntenna_fw);

            spAntenna_fw = new SqlParameter();
            spAntenna_fw.DbType = DbType.Byte;
            spAntenna_fw.ParameterName = "@antenna_fw";
            scmd_update2.Parameters.Add(spAntenna_fw);

            //-----------------------------------------------
            pObogrev_rw = new MySqlParameter();
            pObogrev_rw.DbType = DbType.Byte;
            pObogrev_rw.ParameterName = "obogrev_rw";
            cmd_update2.Parameters.Add(pObogrev_rw);

            spObogrev_rw = new SqlParameter();
            spObogrev_rw.DbType = DbType.Byte;
            spObogrev_rw.ParameterName = "@obogrev_rw";
            scmd_update2.Parameters.Add(spObogrev_rw);


            //-----------------------------------------------
            pAntenna_rw = new MySqlParameter();
            pAntenna_rw.DbType = DbType.Byte;
            pAntenna_rw.ParameterName = "antenna_rw";
            cmd_update2.Parameters.Add(pAntenna_rw);

            spAntenna_rw = new SqlParameter();
            spAntenna_rw.DbType = DbType.Byte;
            spAntenna_rw.ParameterName = "@antenna_rw";
            scmd_update2.Parameters.Add(spAntenna_rw);

            //-----------------------------------------------
            pTriplex_rw = new MySqlParameter();
            pTriplex_rw.DbType = DbType.Byte;
            pTriplex_rw.ParameterName = "triplex_rw";
            cmd_update2.Parameters.Add(pTriplex_rw);

            spTriplex_rw = new SqlParameter();
            spTriplex_rw.DbType = DbType.Byte;
            spTriplex_rw.ParameterName = "@triplex_rw";
            scmd_update2.Parameters.Add(spTriplex_rw);

            //-----------------------------------------------
            pStop_rw = new MySqlParameter();
            pStop_rw.DbType = DbType.Byte;
            pStop_rw.ParameterName = "stop_rw";
            cmd_update2.Parameters.Add(pStop_rw);

            spStop_rw = new SqlParameter();
            spStop_rw.DbType = DbType.Byte;
            spStop_rw.ParameterName = "@stop_rw";
            scmd_update2.Parameters.Add(spStop_rw);



            //---------------------------------------
            pTV_RW = new MySqlParameter();
            pTV_RW.ParameterName = "tv_rw";
            pTV_RW.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pTV_RW);

            spTV_RW = new SqlParameter();
            spTV_RW.ParameterName = "@tv_rw";
            spTV_RW.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spTV_RW);

            //---------------------------------------
            pGPS_RW = new MySqlParameter();
            pGPS_RW.ParameterName = "gps_rw";
            pGPS_RW.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pGPS_RW);

            spGPS_RW = new SqlParameter();
            spGPS_RW.ParameterName = "@gps_rw";
            spGPS_RW.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spGPS_RW);


            //---------------------------------------
            pKrepezh_rw = new MySqlParameter();
            pKrepezh_rw.ParameterName = "krepezh_rw";
            pKrepezh_rw.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pKrepezh_rw);

            spKrepezh_rw = new SqlParameter();
            spKrepezh_rw.ParameterName = "@krepezh_rw";
            spKrepezh_rw.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spKrepezh_rw);

            //---------------------------------------
            pInkapsulazia_rw = new MySqlParameter();
            pInkapsulazia_rw.ParameterName = "inkapsulazia_rw";
            pInkapsulazia_rw.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pInkapsulazia_rw);

            spInkapsulazia_rw = new SqlParameter();
            spInkapsulazia_rw.ParameterName = "@inkapsulazia_rw";
            spInkapsulazia_rw.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spInkapsulazia_rw);

            //---------------------------------------
            pVerhnee_rw = new MySqlParameter();
            pVerhnee_rw.ParameterName = "verhnee_rw";
            pVerhnee_rw.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pVerhnee_rw);

            spVerhnee_rw = new SqlParameter();
            spVerhnee_rw.ParameterName = "@verhnee_rw";
            spVerhnee_rw.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spVerhnee_rw);


            //-----------------------------------------------
            pBody_left = new MySqlParameter();
            pBody_left.DbType = DbType.Byte;
            pBody_left.ParameterName = "body_left";
            cmd_update2.Parameters.Add(pBody_left);

            spBody_left = new SqlParameter();
            spBody_left.DbType = DbType.Byte;
            spBody_left.ParameterName = "@body_left";
            scmd_update2.Parameters.Add(spBody_left);

            //-----------------------------------------------
            pBody_right = new MySqlParameter();
            pBody_right.DbType = DbType.Byte;
            pBody_right.ParameterName = "body_right";
            cmd_update2.Parameters.Add(pBody_right);

            spBody_right = new SqlParameter();
            spBody_right.DbType = DbType.Byte;
            spBody_right.ParameterName = "@body_right";
            scmd_update2.Parameters.Add(spBody_right);

            //-----------------------------------------------
            pFd_left = new MySqlParameter();
            pFd_left.DbType = DbType.Byte;
            pFd_left.ParameterName = "fd_left";
            cmd_update2.Parameters.Add(pFd_left);

            spFd_left = new SqlParameter();
            spFd_left.DbType = DbType.Byte;
            spFd_left.ParameterName = "@fd_left";
            scmd_update2.Parameters.Add(spFd_left);

            //---------------------------------------------
            pFd_right = new MySqlParameter();
            pFd_right.DbType = DbType.Byte;
            pFd_right.ParameterName = "fd_right";
            cmd_update2.Parameters.Add(pFd_right);

            spFd_right = new SqlParameter();
            spFd_right.DbType = DbType.Byte;
            spFd_right.ParameterName = "@fd_right";
            scmd_update2.Parameters.Add(spFd_right);

            //---------------------------------------------
            pRd_left = new MySqlParameter();
            pRd_left.DbType = DbType.Byte;
            pRd_left.ParameterName = "rd_left";
            cmd_update2.Parameters.Add(pRd_left);

            spRd_left = new SqlParameter();
            spRd_left.DbType = DbType.Byte;
            spRd_left.ParameterName = "@rd_left";
            scmd_update2.Parameters.Add(spRd_left);

            //-----------------------------------------------
            pRd_right = new MySqlParameter();
            pRd_right.DbType = DbType.Byte;
            pRd_right.ParameterName = "rd_right";
            cmd_update2.Parameters.Add(pRd_right);

            spRd_right = new SqlParameter();
            spRd_right.DbType = DbType.Byte;
            spRd_right.ParameterName = "@rd_right";
            scmd_update2.Parameters.Add(spRd_right);


            //-----------------------------------------------
            pObogrev_lr = new MySqlParameter();
            pObogrev_lr.DbType = DbType.Byte;
            pObogrev_lr.ParameterName = "obogrev_lr";
            cmd_update2.Parameters.Add(pObogrev_lr);

            spObogrev_lr = new SqlParameter();
            spObogrev_lr.DbType = DbType.Byte;
            spObogrev_lr.ParameterName = "@obogrev_lr";
            scmd_update2.Parameters.Add(spObogrev_lr);


            //-----------------------------------------------
            pTV_antenna_lr = new MySqlParameter();
            pTV_antenna_lr.DbType = DbType.Byte;
            pTV_antenna_lr.ParameterName = "TV_antenna_lr";
            cmd_update2.Parameters.Add(pTV_antenna_lr);

            spTV_antenna_lr = new SqlParameter();
            spTV_antenna_lr.DbType = DbType.Byte;
            spTV_antenna_lr.ParameterName = "@TV_antenna_lr";
            scmd_update2.Parameters.Add(spTV_antenna_lr);


            //---------------------------------------
            pKrepezh_lr = new MySqlParameter();
            pKrepezh_lr.ParameterName = "krepezh_lr";
            pKrepezh_lr.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pKrepezh_lr);

            spKrepezh_lr = new SqlParameter();
            spKrepezh_lr.ParameterName = "@krepezh_lr";
            spKrepezh_lr.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spKrepezh_lr);


            //---------------------------------------
            pPodvizhnoe_lr = new MySqlParameter();
            pPodvizhnoe_lr.ParameterName = "podvizhnoe_lr";
            pPodvizhnoe_lr.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pPodvizhnoe_lr);

            spPodvizhnoe_lr = new SqlParameter();
            spPodvizhnoe_lr.ParameterName = "@podvizhnoe_lr";
            spPodvizhnoe_lr.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spPodvizhnoe_lr);


            //---------------------------------------
            pInkapsulazia_lr = new MySqlParameter();
            pInkapsulazia_lr.ParameterName = "inkapsulazia_lr";
            pInkapsulazia_lr.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pInkapsulazia_lr);

            spInkapsulazia_lr = new SqlParameter();
            spInkapsulazia_lr.ParameterName = "@inkapsulazia_lr";
            spInkapsulazia_lr.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spInkapsulazia_lr);

            //---------------------------------------
            pVerhnee_lr = new MySqlParameter();
            pVerhnee_lr.ParameterName = "verhnee_lr";
            pVerhnee_lr.DbType = DbType.Byte;
            cmd_update2.Parameters.Add(pVerhnee_lr);

            spVerhnee_lr = new SqlParameter();
            spVerhnee_lr.ParameterName = "@verhnee_lr";
            spVerhnee_lr.DbType = DbType.Byte;
            scmd_update2.Parameters.Add(spVerhnee_lr);

            //-----------------------------------------------
            pTriplex_lr = new MySqlParameter();
            pTriplex_lr.DbType = DbType.Byte;
            pTriplex_lr.ParameterName = "triplex_lr";
            cmd_update2.Parameters.Add(pTriplex_lr);

            spTriplex_lr = new SqlParameter();
            spTriplex_lr.DbType = DbType.Byte;
            spTriplex_lr.ParameterName = "@triplex_lr";
            scmd_update2.Parameters.Add(spTriplex_lr);


            //-----------------------------------------
            pRazdel = new MySqlParameter();
            pRazdel.ParameterName = "razdel";
            pRazdel.DbType = DbType.String;
            pRazdel.Size = 50;
            cmd_update2.Parameters.Add(pRazdel);

            spRazdel = new SqlParameter();
            spRazdel.ParameterName = "@razdel";
            spRazdel.DbType = DbType.String;
            spRazdel.Size = 50;
            scmd_update2.Parameters.Add(spRazdel);



            //-----------------------------------------------
            pid_sensor = new MySqlParameter();
            pid_sensor.DbType = DbType.String;
            pid_sensor.Size = 20;
            pid_sensor.ParameterName = "id_sensor";
            cmd_update2.Parameters.Add(pid_sensor);

            spid_sensor = new SqlParameter();
            spid_sensor.DbType = DbType.String;
            spid_sensor.Size = 20;
            spid_sensor.ParameterName = "@id_sensor";
            scmd_update2.Parameters.Add(spid_sensor);



            // ------------------------------------------
            pEurocode = new MySqlParameter();
            pEurocode.ParameterName = "eurocode";
            pEurocode.DbType = DbType.String;
            pEurocode.Size = 50;
            cmd_update2.Parameters.Add(pEurocode);

            spEurocode = new SqlParameter();
            spEurocode.ParameterName = "@eurocode";
            spEurocode.DbType = DbType.String;
            spEurocode.Size = 50;
            scmd_update2.Parameters.Add(spEurocode);

        }


        void Zero()
        {
            pDD.Value = 0;
            poknoDD_P_A.Value = 0;
            pCamera.Value = 0;
            pObogrev_fw.Value = 0;
            pObogref_fw.Value = 0;
            pAntenna_fw.Value = 0;
            pObogrev_rw.Value = 0;

            pAntenna_rw.Value = 0;
            pTV_RW.Value = 0;
            pTriplex_rw.Value = 0;
            pStop_rw.Value = 0;
            pBody_left.Value = 0;
            pBody_right.Value = 0;
            pFd_left.Value = 0;
            pFd_right.Value = 0;
            pRd_left.Value = 0;
            pRd_right.Value = 0;
            pTriplex_lr.Value = 0;
            pRazdel.Value = "";
            pProducer.Value = "";
            pEurocode.Value = "";
            

            pRul.Value = 0;
            pHud.Value = 0;
            pGPS_FW.Value = 0;
            pTV_FW.Value = 0;
            pGPS_RW.Value = 0;
            pTV_RW.Value = 0;
            poknoDD_P_A.Value = 0;
            pid_sensor.Value = "";

            spDD.Value = 0;
            spoknoDD_P_A.Value = 0;
            spCamera.Value = 0;
            spObogrev_fw.Value = 0;
            spObogref_fw.Value = 0;
            spAntenna_fw.Value = 0;
            spObogrev_rw.Value = 0;
            spAntenna_rw.Value = 0;
            spTriplex_rw.Value = 0;
            spStop_rw.Value = 0;
            spBody_left.Value = 0;
            spBody_right.Value = 0;
            spFd_left.Value = 0;
            spFd_right.Value = 0;
            spRd_left.Value = 0;
            spRd_right.Value = 0;
            spTriplex_lr.Value = 0;
            spRazdel.Value = "";
            pProducer.Value = "";
            spEurocode.Value = "";
            
            spRul.Value = 0;
            spHud.Value = 0;
            spGPS_FW.Value = 0;
            spTV_FW.Value = 0;
            spGPS_RW.Value = 0;
            spTV_RW.Value = 0;
            spoknoDD_P_A.Value = 0;
            spid_sensor.Value = "";
        }


        public frmMain()
        {
            InitializeComponent();
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            lbl_BEGIN.Text = String.Format("{0:d2}", DateTime.Now.Hour) + ":" + String.Format("{0:d2}", DateTime.Now.Minute) +":"+ String.Format("{0:d2}", DateTime.Now.Second);
            lbl_END.Text = "";

            Cursor = Cursors.WaitCursor;
            btnLoad.Enabled = false;
            btnClose.Enabled = false;
            this.Update();

            if (chbUpdateData.Checked)
            {
                Cursor = Cursors.WaitCursor;

                SqlConnection conSteklo = new SqlConnection();
                conSteklo.ConnectionString = ConfigurationManager.ConnectionStrings["conSteklo"].ConnectionString;

                SqlCommand cmdSteklo = new SqlCommand();
                cmdSteklo.CommandType = CommandType.StoredProcedure;
                cmdSteklo.CommandText = "LOAD_TABLES";
                cmdSteklo.CommandTimeout = 0;
                cmdSteklo.Connection = conSteklo;

                try
                {
                    conSteklo.Open();
                    cmdSteklo.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ошибка " + ex.Message);
                }
                finally
                {
                    conSteklo.Close();
                    cmdSteklo.Dispose();
                    conSteklo.Dispose();
                }


                chbUpdateData.Checked = false;
            }



            if (chbPhotos.Checked)
            {
                LoadPhotos();
                chbPhotos.Checked = false;
                this.Update();
            }




            if (chbWATERMARK.Checked)
            {
                WATERMARK();
                MINI_PHOTO();
                chbWATERMARK.Checked = false;
                this.Update();
            }



            if (chbPrepare.Checked)
            {
                Prepare();

                chbPrepare.Checked = false;
                cb_podrobno.Checked = false;
                this.Update();
            }



            if (chbGlass.Checked)
            {
                Marki_Load();
                
                GlassLoad();

                Compress_MMBY();

                Marki_Load_2();

                chbGlass.Checked = false;
                cb_podrobno.Checked = false;
                this.Update();
            }




            if (copy_MARKA.Checked)
            {
                CopyMarki();
                copy_MARKA.Checked = false;
                this.Update();
            }



            if (copy_GLASS.Checked)
            {
                CopyGlass();
                copy_GLASS.Checked = false;
                this.Update();
            }



            if (cbShutdown.Checked) // закрыть виндовз
            {
                Reboot reboot = new Reboot();
                // reboot.Lock(); блокировка компа
                reboot.halt(false, false);
            }


            btnLoad.Enabled = true;
            btnClose.Enabled = true;

            Cursor = Cursors.Default;
            lbl_END.Text = String.Format("{0:d2}", DateTime.Now.Hour) + ":" + String.Format("{0:d2}", DateTime.Now.Minute) + ":" + String.Format("{0:d2}", DateTime.Now.Second);
        }



        private void WATERMARK()
        {
            DirectoryInfo dii = new DirectoryInfo("c:\\i\\");
            try
            {
                FileInfo[] filesi = dii.GetFiles();
            }
            catch
            {
                System.IO.Directory.CreateDirectory("c:\\i\\");
            }
            

            DirectoryInfo di = new DirectoryInfo("c:\\PNG_IN\\");
            FileInfo[] files = di.GetFiles("*.png");
            string site = "стеклопоиск";

            Cursor = Cursors.WaitCursor;

            for (int i = 0; i < files.Length; i++)
            {
                string fname = files[i].Name;

                Bitmap bm = new Bitmap(Image.FromFile("C:\\PNG_IN\\" + fname));

                int BMwidth = bm.Width;
                int BMheight = bm.Height;

                int newWidth = 320;
                int newHeight = BMheight * newWidth / BMwidth;
                Image NewImage = bm.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);

                Graphics graphics = Graphics.FromImage(NewImage);

                int y1 = newHeight + 10;

                int x = (320 - 180) / 2;

                graphics.RotateTransform(5);
                graphics.TranslateTransform(-20, -newHeight / 2);
                graphics.DrawString(site, new Font("Tempus Sans ITC", 18f, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Yellow), x, y1);
                graphics.DrawString(site, new Font("Tempus Sans ITC", 18f, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Brown), x + 1, y1 + 1);

                NewImage.Save("C:\\I\\" + fname);
                bm.Dispose();
                NewImage.Dispose();
            }

            Cursor = Cursors.Default;
        }


        private void MINI_PHOTO()
        {
            DirectoryInfo dii = new DirectoryInfo("c:\\m\\");
            try
            {
                FileInfo[] filesi = dii.GetFiles();
            }
            catch
            {
                System.IO.Directory.CreateDirectory("c:\\m\\");
            }

            DirectoryInfo di = new DirectoryInfo("c:\\PNG_IN\\");
            FileInfo[] files = di.GetFiles("*.png");

            Cursor = Cursors.WaitCursor;

            for (int i = 0; i < files.Length; i++)
            {
                string fname = files[i].Name;

                Bitmap bm = new Bitmap(Image.FromFile("c:\\PNG_IN\\" + fname));

                int BMwidth = bm.Width;
                int BMheight = bm.Height;

                
                int newHeight = 50;
                int newWidth = BMwidth * newHeight / BMheight;
                Image NewImage = bm.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);

                NewImage.Save("C:\\M\\" + fname);
                bm.Dispose();
                NewImage.Dispose();
            }

            
            Cursor = Cursors.Default;
        }


        void Marki_Load()
        {
            con = new SqlConnection();
            con.ConnectionString = SQLconnect;

            cmd = new SqlCommand();
            cmd.Connection = con;

            Cursor = Cursors.WaitCursor;

            SqlCommand cmd_MSSQL = new SqlCommand();
            cmd_MSSQL.Connection = con;
            cmd_MSSQL.CommandType = CommandType.StoredProcedure;
            cmd_MSSQL.CommandTimeout = 0;

            con.Open();

            cmd_MSSQL.CommandText = "SET_BODYES";   // строится таблица BODYES
            cmd_MSSQL.ExecuteNonQuery();

            cmd_MSSQL.CommandText = "LOAD_MMBY";
            cmd_MSSQL.ExecuteNonQuery();

            con.Close();

            if (con_update.State == ConnectionState.Closed)
            {
                con_update.Open();
            }

            if (scon_update.State == ConnectionState.Closed)
            {
                scon_update.Open();
            }

            if (con_marki.State == ConnectionState.Closed)
            {
                con_marki.Open();
            }

            if (cmd_update.Connection.State == ConnectionState.Closed)
            {
                cmd_update.Connection.Open();
            }

            if (scmd_update.Connection.State == ConnectionState.Closed)
            {
                scmd_update.Connection.Open();
            }


            dr_marka = cmd_marki.ExecuteReader();

            while (dr_marka.Read())
            {
                string iid_marka = dr_marka["id_marka"].ToString();
                Marka_make_html(iid_marka);
            }

            con.Close();

            con_update.Close();
            scon_update.Close();
            con_marki.Close();
        }


        void Marki_Load_2()
        {
            
            SqlCommand cmd_MSSQL = new SqlCommand();
            cmd_MSSQL.Connection = con;
            cmd_MSSQL.CommandType = CommandType.Text;
            cmd_MSSQL.CommandTimeout = 0;

            con.Open();
            cmd_MSSQL.CommandText = "DELETE FROM MMBY WHERE ID_PHOTO=''";
            cmd_MSSQL.ExecuteNonQuery();
            
            /* нет стекол, но есть модель */
            cmd_MSSQL.CommandText = "DELETE FROM MMBY WHERE WEB_MODEL NOT IN ( SELECT WMODEL FROM GLASSH )";
            cmd_MSSQL.ExecuteNonQuery();

            
            // на mssql
            scmd_update.CommandType = CommandType.Text;
            scmd_update.Connection = scon_update;
            scmd_update.CommandText = "UPDATE MARKY SET html = @html Where id_marka=@id_marka";

            // на mysql
            cmd_update.CommandType = CommandType.Text;
            cmd_update.Connection = con_update;
            cmd_update.CommandText = "UPDATE MARKA SET html = @html Where id_marka=@id_marka";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (con_update.State == ConnectionState.Closed)
            {
                con_update.Open();
            }

            if (scon_update.State == ConnectionState.Closed)
            {
                scon_update.Open();
            }

            if (con_marki.State == ConnectionState.Closed)
            {
                con_marki.Open();
            }

            if (cmd_update.Connection.State == ConnectionState.Closed)
            {
                cmd_update.Connection.Open();
            }

            if (scmd_update.Connection.State == ConnectionState.Closed)
            {
                scmd_update.Connection.Open();
            }


            dr_marka = cmd_marki.ExecuteReader();

            while (dr_marka.Read())
            {
                string iid_marka = dr_marka["id_marka"].ToString();
                Marka_make_html(iid_marka);
            }


            con.Close();
            con_update.Close();
            scon_update.Close();
            con_marki.Close();
        }



        public void Marka_make_html(string id_marka)
        {
            // для выбранной марки собираем модели
            p_marka.Value = id_marka;

            if (cmd_mmby.Connection.State == ConnectionState.Closed)
            {
                cmd_mmby.Connection.Open();
            }

            dr_mmby = cmd_mmby.ExecuteReader();

            if (!dr_mmby.HasRows)
            {
                dr_mmby.Close();
                return;  //  нет записей по марке
            }


            rd_result = dr_mmby.Read();

            string cur_id_marka = id_marka;

            while (rd_result)
            {
                sb.Clear();
                id_marka = dr_mmby["id_marka"].ToString();
                Marka_formir(id_marka);
            }

            dr_mmby.Close();
            cmd_mmby.Connection.Close();
        }



        private void Marka_formir(string id_marka)
        {
            string cur_id_marka = dr_mmby["id_marka"].ToString();
            string wmodel = dr_mmby["wmodel"].ToString();
            wmodel = wmodel.ToLower();
            string cur_wmodel = wmodel.ToLower();

            sb.Clear();
            sb.Append("<div class='css-treeview'><ul>");

            while ((cur_id_marka == id_marka) && (cur_wmodel == wmodel) && rd_result)
            {
                Model_formir(id_marka, cur_wmodel);

                if (rd_result)
                {
                    cur_id_marka = dr_mmby["id_marka"].ToString();
                }
            }

            sb.Append("</ul></div>"); // !!!!!

            Marka_save(cur_id_marka); // !!  сохранили html
        }


        private void Model_formir(string cur_id_marka, string cur_wmodel)
        {
            string wmodel = dr_mmby["wmodel"].ToString();
            
            wmodel = wmodel.ToLower();
            cur_wmodel = wmodel;
            string id_marka = cur_id_marka;

            id = "i" + dr_mmby["id_model"].ToString();

            string wmodel2 = wmodel.ToUpper();
            if (wmodel2.IndexOf("FORD-USA") == 0 )
            {
                wmodel2 = "FORD " + wmodel2.Substring(9);
            }

            
            while ((id_marka == cur_id_marka) && (wmodel == cur_wmodel) && rd_result)
            {
                string data = dr_mmby["DATA"].ToString().Trim();

                if (data == "")
                {
                    sb.Append("<li><input type='checkbox' checked id ='" + id + "'/> <label for='" + id + "'>" + wmodel2.ToUpper() + "</label>");
                    Data_empty_formir( wmodel, data);
                    sb.Append("</li>");
                }
                else
                {
                    sb.Append("<li><input type='checkbox' checked id ='" + id + "' /><label for='" + id + "'>" + wmodel.ToUpper() + "<br/>&nbsp;&nbsp;&nbsp;&nbsp; <b>" + data + " г.в.</b> " + "</label>");
                    Data_formir(wmodel, data);
                    sb.Append("</li>");
                }


                if (rd_result)
                {
                    id_marka = dr_mmby["id_marka"].ToString();
                    wmodel = dr_mmby["wmodel"].ToString();
                    wmodel = wmodel.ToLower();
                    wmodel = wmodel.Replace("(", "");
                    wmodel = wmodel.Replace(")", "");
                   
                }
            }

        }


        private void Data_empty_formir( string cur_wmodel, string cur_data)
        {
            string data = cur_data;
            
            string wmodel = cur_wmodel;

            while ((cur_wmodel == wmodel) && (cur_data == "") && rd_result)
            {
                iid++;
                id = "i" + iid.ToString();

                Body_formir( wmodel, cur_data);

                if (rd_result)
                {
                    id_marka = dr_mmby["id_marka"].ToString();
                    wmodel = dr_mmby["wmodel"].ToString();
                    cur_data = dr_mmby["data"].ToString();
                }
            }

        }


        private void Data_formir( string cur_wmodel, string cur_data)
        {
            string data = cur_data;
            
            string wmodel = cur_wmodel;
            string cur_data2;

            cur_data2 = cur_data;

            if (cur_data.Length == 4)
            {
                cur_data2 = "с " + cur_data;
            }

 
            while ((cur_wmodel == wmodel) && rd_result)
            {
                iid++;
                id = "i" + iid.ToString();

                string c_data = cur_data;
                if (cur_data.Length == 4)
                {
                    c_data = "с " + c_data;
                }

                Body_formir( wmodel, cur_data);
           
                if (rd_result)
                {
                    id_marka = dr_mmby["id_marka"].ToString();
                    wmodel = dr_mmby["wmodel"].ToString();
                    cur_data = dr_mmby["data"].ToString();
                }
            }

        }


        private void Body_formir( string cur_wmodel, string cur_data)
        {
            
            string wmodel = cur_wmodel;
            string data = cur_data;

            sb.Append("<ul>");

            while ( (cur_wmodel.ToLower() == wmodel.ToLower()) && (cur_data == data) && rd_result)
            {
                string id_body = dr_mmby["ID_BODY"].ToString().Trim();
                string body = dr_mmby["BODY"].ToString().Trim();
                string bodyl = dr_mmby["BODYL"].ToString().Trim();
                string data2 = dr_mmby["DATA2"].ToString().Trim();
                string model = dr_mmby["WMODEL"].ToString().Trim();
                 id_photo = dr_mmby["ID_PHOTO"].ToString().Trim();

                model = model.ToLower().TrimStart();

                if (data2 == "")
                {
                    model = model + "-" + bodyl;
                }
                else
                {
                    model = model + "-" + bodyl + "-" + data2;
                }

                model = model.Replace("(", "");
                model = model.Replace(")", "");
                model = model.Replace(",", "-");
                model = model.Replace("/", "-");
                model = model.Replace("   ", "-");
                model = model.Replace("  ", "-");
                model = model.Replace(",", "-");
                model = model.Replace(".", "-");
                model = model.Replace(" ", "-");
                model = model.Replace(",-", "-");
                model = model.Replace("--", "-");
                model = model.Replace("--", "-");
                model = model.Replace("--", "-");

                model = model.Replace("низкий", "low");
                model = model.Replace("высокий", "heigh");
                model = model.Replace("из-россии", "russia");

                string href = "model/" + model;
                string id = "id" + dr_mmby["ID_BODY"].ToString();

                string li = "<li><a id='"+ id +"' rel='/i/modelk.php?img=" + id_photo + "_" + model + "' class='model_k' href='/autosteklo/" + href + "'>"
                          + "<img alt='стекла на " + model + "'" + " src='/m/" + id_photo + ".png" + "'> <br>" + body + "</a></li>";

                sb.Append(li);

                rd_result = dr_mmby.Read();

                if (rd_result)
                {
                    id_marka = dr_mmby["id_marka"].ToString();
                    wmodel = dr_mmby["wmodel"].ToString();
                    model = dr_mmby["WMODEL"].ToString().Trim().ToLower();
                    data = dr_mmby["data"].ToString();
                    bodyl = dr_mmby["BODYL"].ToString().Trim();
                }
            }

            sb.Append("</ul>");
            
        }


        private void Marka_save(string id_marka)
        {
            pHtml_marka.Value = sb.ToString();
            pId_marka_marka.Value = id_marka;
            cmd_update.ExecuteNonQuery();

            spHtml_marka.Value = sb.ToString();   //si;
            spId_marka_marka.Value = id_marka;
            scmd_update.ExecuteNonQuery();
        }


        private void Prepare()
        {
            SQLconnect = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
            bhtml = new StringBuilder();

            con = new SqlConnection();
            con.ConnectionString = SQLconnect;

            //----- удаляем лишние стекла

            cmd = new SqlCommand();
            cmd.Connection = con;

            Cursor = Cursors.WaitCursor;

            SqlCommand cmd_MSSQL = new SqlCommand();
            cmd_MSSQL.Connection = con;
            cmd_MSSQL.CommandType = CommandType.StoredProcedure;
            cmd_MSSQL.CommandTimeout = 0;

            string msg = "";

            try
            {
                con.Open();

                msg = "EUROPA_WEB";
                cmd_MSSQL.CommandText = "EUROPA_WEB";
                cmd_MSSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ! " + msg + " : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void GlassLoad()
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;

            string msg = "";

            SqlCommand cmd_MSSQL = new SqlCommand();
            cmd_MSSQL.Connection = con;
            cmd_MSSQL.CommandType = CommandType.StoredProcedure;
            cmd_MSSQL.CommandTimeout = 0;
            bhtml = new StringBuilder();

            try
            {
                con.Open();

              //  msg = "UPDATE_GLASS_WH";
              //  cmd_MSSQL.CommandText = "UPDATE_GLASS_WH";
              //  cmd_MSSQL.ExecuteNonQuery();

                msg = "FORMIROV_GLASS_MYSQL";
                cmd_MSSQL.CommandText = "FORMIROV_GLASS_MYSQL";
                cmd_MSSQL.ExecuteNonQuery();

                msg = "COMPRESS_GLASS_MYSQL";
                cmd_MSSQL.CommandText = "COMPRESS_GLASS_MYSQL";
                cmd_MSSQL.ExecuteNonQuery();


                msg = "COMPRESS_GLASS_MYSQL_2";
                cmd_MSSQL.CommandText = "COMPRESS_GLASS_MYSQL_2";
                cmd_MSSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ! " + msg + " : " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            Cursor = Cursors.WaitCursor;

            if (con_update2.State == ConnectionState.Closed)
            {
                con_update2.Open();
            }

            if (scon_update2.State == ConnectionState.Closed)
            {
                scon_update2.Open();
            }

            cmd_MSSQL.CommandType = CommandType.Text;
            cmd_MSSQL.CommandText = query;

            SqlCommand scmd_update22 = new SqlCommand();
            scmd_update22.Connection = scon_update2;
            scmd_update22.CommandText = "TRUNCATE TABLE GLASSH";
            scmd_update22.CommandType = CommandType.Text;
            scmd_update22.Parameters.Clear();
            scmd_update22.CommandTimeout = 0;
            scmd_update22.ExecuteNonQuery();


            MySqlCommand cmd_update22 = new MySqlCommand();
            cmd_update22.Connection = con_update2;
            cmd_update22.CommandText = "TRUNCATE TABLE GLASSH";
            cmd_update22.CommandType = CommandType.Text;
            cmd_update22.Parameters.Clear();
            cmd_update22.CommandTimeout = 0;
            cmd_update22.ExecuteNonQuery();

            scmd_update2.Connection = scon_update2;
            cmd_update2.Connection = con_update2;

            con.Open();
            dr = cmd_MSSQL.ExecuteReader(); 
            
            while (dr.Read())
            {
                razdel = dr["RAZDEL"].ToString();
                side = dr["SIDE"].ToString();
                location = dr["положение"].ToString();
                producer = dr["PRODUCER"].ToString();
                цена = dr["PRICE"].ToString();  // цена
                id_sensor = dr["ID_SENSOR"].ToString();
                положение = dr["Положение"].ToString();
                location = положение.ToString().Substring( положение.IndexOf("_") +1 );
                отверстий = dr["Отверстий"].ToString();
                color = dr["COLOR"].ToString();

                if ( color.IndexOf("(") != 1 )
                {
                    color = color.Replace("(", "<br>(");
                }

                strip = dr["STRIP"].ToString();
                ПравыйРуль = (bool)dr["ПравыйРуль"];
                МестоКамеры_C_A = (bool)dr["МестоКамеры_C_A"];
                GPS_G_A = (bool)dr["GPS_G_A"];
                Обогрев_H_A = (bool)dr["Обогрев_H_A"];
                Обогрев_F_A = (bool)dr["Обогрев_F_A"];
                TV_антенна_J_A = (bool)dr["TV_антенна_J_A"];
                Антенна_A_A = (bool)dr["Антенна_A_A"];
                ЛеваяПоловина_L_A = (bool)dr["ЛеваяПоловина_L_A"];
                МестоДД_M_A = (bool)dr["МестоДД_M_A"];

                Водооталк_N_A = (bool)dr["Водооталк_N_A"];
                ДатчикТумана_O_A = (bool)dr["ДатчикТумана_O_A"];
                Окно_ДД_P_A = (bool)dr["Окно_ДД_P_A"];
                ПраваяПоловина_R_A = (bool)dr["ПраваяПоловина_R_A"];
                Дисплей_U_A = (bool)dr["Дисплей_U_A"];
                Крепеж_W_A = (bool)dr["Крепеж_W_A"];
                Инкапсуляция_Z_A = (bool)dr["Инкапсуляция_Z_A"];

                Антенна_A_B = (bool)dr["Антенна_A_B"];
                Стопсигнал_B_B = (bool)dr["Стопсигнал_B_B"];
                steklopaket_D_B = (bool)dr["Стеклопакет_D_B"];
                GPS_G_B = (bool)dr["GPS_G_B"];
                TV_антенна_J_B = (bool)dr["TV_антенна_J_B"];
                Триплекс_K_B = (bool)dr["Триплекс_K_B"];
                Открывающееся_O_B = (bool)dr["Открывающееся_O_B"];

                РамкаСподвИнеподвСтеклом_S_B = (bool)dr["РамкаСподвИнеподвСтеклом_S_B"];

                БезОбогрева_U_B = (bool)dr["БезОбогрева_U_B"];
                VINокно_V_B = (bool)dr["VINокно_V_B"];
                ПраваяПоловина_R_B = (bool)dr["ПраваяПоловина_R_B"];
                ЛеваяПоловина_L_B = (bool)dr["ЛеваяПоловина_L_B"];
                Крепеж_W_B = (bool)dr["Крепеж_W_B"];
                ПроводСигнализации_X_B = (bool)dr["ПроводСигнализации_X_B"];
                Верхнее_Y_B = (bool)dr["Верхнее_Y_B"];
                Инкапсуляция_Z_B = (bool)dr["Инкапсуляция_Z_B"];

                Антенна_A_C = (bool)dr["Антенна_A_C"];
                Стеклопакет_D_C = (bool)dr["Стеклопакет_D_C"];
                ОткрываемоеЕлектрически_E_C = (bool)dr["ОткрываемоеЕлектрически_E_C"];
                РамкаСподвИнеподвСтеклом_F_C = (bool)dr["РамкаСподвИнеподвСтеклом_F_C"];
                GPS_G_C = (bool)dr["GPS_G_C"];
                Обогрев_H_C = (bool)dr["Обогрев_H_C"];
                TV_антенна_J_C = (bool)dr["TV_антенна_J_C"];
                Триплекс_K_C = (bool)dr["Триплекс_K_C"];
                Открывающееся_O_C = (bool)dr["Открывающееся_O_C"];
                ВыдвигающаясяАнтенна_Q_C = (bool)dr["ВыдвигающаясяАнтенна_Q_C"];
                Подвижное_S_C = (bool)dr["Подвижное_S_C"];
                
                ФиксаторОткрывания_T_C = (bool)dr["ФиксаторОткрывания_T_C"];

                Верхнее_U_C = (bool)dr["Верхнее_U_C"];
                VIN_V_C = (bool)dr["VIN_V_C"];
                Крепеж_W_C = (bool)dr["Крепеж_W_C"];
                Инкапсуляция_Z_C = (bool)dr["Инкапсуляция_Z_C"];

                model = dr["WEB_NAME"].ToString();
                data = dr["DATA"].ToString();
                body = dr["BODY"].ToString();
                mesto = dr["MESTO"].ToString();
                model_k = dr["ID_BODY"].ToString();  // dr["Model_K"].ToString();
                
                bodyl = dr["BODYL"].ToString();
                date2 = dr["DATE2"].ToString();
                height = dr["HEIGHT"].ToString();
                width = dr["WIDTH"].ToString();
             //   id_photo = dr["ID_PHOTO"].ToString();
                eurocode = dr["EUROCODE"].ToString();
                //clas = dr["CLASS"].ToString();
             //   clas = "";

                pCena.Value = цена;

                string bodyK = dr["ID_BODY"].ToString().Substring(4);


                    switch (side)
                    {
                        case "A":
                            A_glass();
                            Save_glass();
                            break;

                        case "B":
                            B_glass();
                            Save_glass();
                            break;

                        case "L":
                            LR_glass();
                            Save_glass();
                            break;

                        case "R":
                            LR_glass();
                            Save_glass();
                            break;

                        case "F":
                            LR_glass();
                            Save_glass();
                            break;

                        case "T":
                            LR_glass();
                            Save_glass();
                            break;
                    }
                
            }


            SqlCommand   scmd_update20 = new SqlCommand();
            scmd_update20.Connection = scon_update2;

            MySqlCommand cmd_update20 = new MySqlCommand();
            cmd_update20.Connection = con_update2;

            scmd_update20.CommandType = CommandType.StoredProcedure;
            scmd_update20.Parameters.Clear();
            scmd_update20.CommandText = "DELETE_ANY_LOCATION";
            scmd_update20.ExecuteNonQuery();

            cmd_update20.CommandType = CommandType.StoredProcedure;
            cmd_update20.Parameters.Clear();
            cmd_update20.CommandText = "delete_any_location";
            cmd_update20.ExecuteNonQuery();

            cmd_update20.Dispose();
            scmd_update20.Dispose();

            con.Close();
            con_update2.Close();
            scon_update2.Close();

            Cursor = Cursors.Default;
        }


        void Save_glass()
        {
            pIdglass.Value = idglass;
            spIdglass.Value = idglass;

            pSide.Value = dr["SIDE"].ToString();
            spSide.Value = dr["SIDE"].ToString();


            if (location == "LFD")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 1;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 1;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "RFD")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 1;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 1;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "RRD")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 1;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 1;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "LRD")
            {
                pRd_left.Value = 1;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 1;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "FFD")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 1;
                pFd_left.Value = 1;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 1;
                spFd_left.Value = 1;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "FRD")
            {
                pRd_left.Value = 1;
                pRd_right.Value = 1;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 1;
                spRd_right.Value = 1;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "FRD")
            {
                pRd_left.Value = 1;
                pRd_right.Value = 1;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 1;
                spRd_right.Value = 1;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "FFQ" || location == "FMQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 1;
                pBody_right.Value = 1;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 1;
                spBody_right.Value = 1;
            }

            if (location == "FRQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 1;
                pBody_right.Value = 1;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 1;
                spBody_right.Value = 1;
            }

            if (location == "LFQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 1;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 1;
                spBody_right.Value = 0;
            }

            if (location == "LRQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 1;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 1;
                spBody_right.Value = 0;
            }

            if (location == "RFQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 1;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 1;
            }

            if (location == "RRQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 1;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 1;
            }



            pLocation.Value = dr["положение"].ToString();
            spLocation.Value = dr["положение"].ToString();

            pModel.Value = dr["WEB_NAME"].ToString();
            spModel.Value = dr["WEB_NAME"].ToString();

            pData.Value = dr["DATA"].ToString();
            spData.Value = dr["DATA"].ToString();

            pBody.Value = dr["ID_BODY"].ToString();
            spBody.Value = dr["ID_BODY"].ToString();

            pBodi.Value = dr["body"].ToString();
            spBodi.Value = dr["body"].ToString();

            pCena.Value = dr["PRICE"].ToString();
            spCena.Value = dr["PRICE"].ToString();

            pProducer.Value = dr["PRODUCER"].ToString();
            spProducer.Value = dr["PRODUCER"].ToString();

            pMarka.Value = dr["MARKA"].ToString();
            spMarka.Value = dr["MARKA"].ToString();

            string pModel_Value = dr["Model"].ToString();
           


            if (dr["DATE2"].ToString().Trim() == "")
            {
                Wmodel = pModel_Value + "-" + dr["BODYL"].ToString();
            }
            else
            {
                Wmodel = pModel_Value + "-" + dr["BODYL"].ToString() + "-" + dr["DATE2"].ToString();
            }

            Wmodel = Wmodel.ToLower().TrimStart();
            Wmodel = Wmodel.Replace("(", "");
            Wmodel = Wmodel.Replace(")", "");
            Wmodel = Wmodel.Replace(",", "-");
            Wmodel = Wmodel.Replace("/", "-");
            Wmodel = Wmodel.Replace(" ", "-");
            Wmodel = Wmodel.Replace(",", "-");
            Wmodel = Wmodel.Replace(" ", "-");
            Wmodel = Wmodel.Replace(",-", "-");
            Wmodel = Wmodel.Replace("--", "-");
            Wmodel = Wmodel.Replace("--", "-");

            Wmodel = Wmodel.Replace("низкий", "low");
            Wmodel = Wmodel.Replace("высокий", "heigh");
            Wmodel = Wmodel.Replace("из-россии", "russia");

            pWmodel.Value = Wmodel;
            spWmodel.Value = Wmodel;

            string locato = (string) pLocation.Value;
            locato = locato.Substring( locato.IndexOf("_") +1 );
            

            switch(locato)
            {
                case "AA":
                      alt = "лобовое стекло";
                    break;

                case "BB":
                    alt = "заднее стекло";
                    break;

                case "FFD":
                    alt = "стекло передней двери опускное плоское";
                    break;

                case "FFQ":
                    alt = "стекло переднее боковое в кузове плоское";
                    break;

                case "FFV":
                    alt = "стекло форточка передней двери плоская";
                    break;

                case "FMD":
                    alt = "стекло средней двери подвижное плоское";
                    break;

                case "FMQ":
                    alt = "стекло средней двери неподвижное плоское";
                    break;

                case "FPG":
                    alt = "стекло перегородка в салоне, плоское";
                    break;

                case "FRD":
                    alt = "стекло задней двери опускное плоское";
                    break;

                case "FRQ":
                    alt = "стекло заднее боковое в кузове плоское";
                    break;

                case "FRV":
                    alt = "стекло задней двери неопускное плоское";
                    break;


                case "LFD":
                    alt = "стекло передней левой двери опускное";
                    break;

                case "RFD":
                    alt = "стекло передней левой двери опускное";
                    break;

                case "LFQ":
                    alt = "стекло переднее левое в кузове";
                    break;


                case "RFQ":
                    alt = "стекло переднее правое в кузове";
                    break;


                case "LFV":
                    alt = "стекло форточка передней левой двери";
                    break;

                case "RFV":
                    alt = "стекло форточка передней правой двери";
                    break;

                case "LMD":
                    alt = "стекло среднее кузова подвижное левое";
                    break;

                case "RMD":
                    alt = "стекло среднее кузова подвижное правое";
                    break;


                case "LRD":
                    alt = "стекло задней левой двери опускное";
                    break;

                case "RRD":
                    alt = "стекло задней правой двери опускное";
                    break;


                case "LRQ":
                    alt = "стекло заднее левое в кузове";
                    break;

                case "RRQ":
                    alt = "стекло заднее в кузове правое";
                    break;


                case "LRV":
                    alt = "стекло задней левой двери неопускное";
                    break;

                case "RRV":
                    alt = "стекло задней правой двери неопускное";
                    break;

                case "LMQ":
                    alt = "стекло среднее кузова неподвижное левое";
                    break;

                case "RMQ":
                    alt = "стекло среднее кузова неподвижное правое";
                    break;

                default:
                    alt = "автостекло";
                    break;
            }

            string alto = bhtml.ToString(); 
            alto = alto.Replace("alto",alt);

            pHtml.Value = alto;
            spHtml.Value = alto;

            pRazdel.Value = razdel;
            spRazdel.Value = razdel;

            pCamera.Value = МестоКамеры_C_A;
            spCamera.Value = МестоКамеры_C_A;

            pid_sensor.Value = id_sensor;
            spid_sensor.Value = id_sensor;

            pEurocode.Value = eurocode;
            spEurocode.Value = eurocode; 


            pRul.Value = ПравыйРуль;
            spRul.Value = ПравыйРуль;

            pHud.Value = Дисплей_U_A;
            spHud.Value = Дисплей_U_A;

            pGPS_FW.Value = GPS_G_A;
            spGPS_FW.Value = GPS_G_A;

            pTV_FW.Value = TV_антенна_J_A;
            spTV_FW.Value = TV_антенна_J_A;

            pGPS_RW.Value = GPS_G_B;
            spGPS_RW.Value = GPS_G_B;

            pTV_RW.Value = TV_антенна_J_B;
            spTV_RW.Value = TV_антенна_J_B;

            poknoDD_P_A.Value = Окно_ДД_P_A;
            spoknoDD_P_A.Value = Окно_ДД_P_A;

            pid_sensor.Value = id_sensor;
            spid_sensor.Value = id_sensor;

            pKrepezh_rw.Value = Крепеж_W_B;
            spKrepezh_rw.Value = Крепеж_W_B;

            pInkapsulazia_rw.Value = Инкапсуляция_Z_B;
            spInkapsulazia_rw.Value = Инкапсуляция_Z_B;

            pVerhnee_rw.Value = Верхнее_Y_B;
            spVerhnee_rw.Value = Верхнее_Y_B;

            pObogrev_lr.Value = Обогрев_H_C;
            spObogrev_lr.Value = Обогрев_H_C;

            pTV_antenna_lr.Value = Антенна_A_C;
            spTV_antenna_lr.Value = Антенна_A_C;

            pKrepezh_lr.Value = Крепеж_W_C;
            spKrepezh_lr.Value = Крепеж_W_C;

            pPodvizhnoe_lr.Value = Подвижное_S_C;
            spPodvizhnoe_lr.Value = Подвижное_S_C;

            pInkapsulazia_lr.Value = Инкапсуляция_Z_C;
            spInkapsulazia_lr.Value = Инкапсуляция_Z_C;

            pVerhnee_lr.Value = Верхнее_U_C;
            spVerhnee_lr.Value = Верхнее_U_C;

            pTriplex_lr.Value = Триплекс_K_C;
            spTriplex_lr.Value = Триплекс_K_C;



            try
            {
                cmd_update2.ExecuteNonQuery();
                scmd_update2.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
               
                MessageBox.Show("ошибка " + ex.Message);
            }
        }


        void Compress_MMBY()
        {
            con.ConnectionString = SQLconnect;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            // удаляем лишние модели и на которые нет фото
            SqlCommand cmd_MSSQL = new SqlCommand();
            cmd_MSSQL.Connection = con;
            cmd_MSSQL.CommandTimeout = 0;
            cmd_MSSQL.CommandType = CommandType.StoredProcedure;
            cmd_MSSQL.CommandText = "COMPRESS_MMBY";
          //  cmd_MSSQL.ExecuteNonQuery();
            con.Close();
        }


        void A_glass()
        {
            idglass = (int)dr["ID_GLASS"];

            Zero();

            string n = "dg" + idglass;
            
            bhtml.Clear();

            string model_k = dr["ID_BODY"].ToString();
        
            bhtml.Append("<div class='col-md-4' id='" + n + "'>");
            положение = dr["положение"].ToString();

            положение = положение.Trim() + ".jpg";
            bhtml.Append("<div><img alt='' src='/g/" + положение + "'/></div><br/>");

            if ( id_photo != "")
            {
                bhtml.Append("<a  href='#' rel='/i/auto.php?img=" + model_k + "' class='mok' ><img alt='' src='/i/" + model_k + ".png'></a>");
            }

            bhtml.Append("<ul class='gr'>");
            bhtml.Append("<li>");

            bhtml.Append("<input type='checkbox' id='c" + idglass + "' name='c" + idglass + "'/>"
               + "<label for='c" + idglass + "'><span></span>заказать</label></li>");


            raspolozhenie = dr["mesto"].ToString().Trim();
            raspolozhenie = raspolozhenie.Replace("(", "");
            raspolozhenie = raspolozhenie.Replace(")", "");
            marka = dr["marka"].ToString().Trim();

            if (data == "")
            {
                bhtml.Append("<li><b>" + raspolozhenie.Trim() + "</b><br> модель <b>" + marka + " " + model + "</b></li>");
                bhtml.Append("<li>кузов: <b>" + body + "</b></li>");
            }
            else
            {
                bhtml.Append("<li><b>" + raspolozhenie.Trim() + "</b><br> модель <b>" + marka + " " + model + "</b></li>");
                bhtml.Append("<li>выпуск <b>" + data + " г</b></li>");
                bhtml.Append("<li>кузов <b>" + body + "</b></li>");
            }



            if (ПравыйРуль)
            {
                bhtml.Append("<li>положение руля <b>правое</b></li>");
                pRul.Value = ПравыйРуль;
                spRul.Value = ПравыйРуль;
            }
            else
            {
                bhtml.Append("<li>положение руля <b>левое</b></li>");
                pRul.Value = false;
                spRul.Value = false;
            }



            razdel = dr["razdel"].ToString();

            bhtml.Append("<li>цвет: <b>" + color + "</b></li>");


            if (strip != "")
            {
                bhtml.Append("<li>козырек светофильтра <b>&#10004;</b></li>");
            }



            if (ДатчикТумана_O_A)
            {
                bhtml.Append("<li>окно датчика тумана <b>&#10004;</b></li>");
            }



            if (Окно_ДД_P_A)
            {
                bhtml.Append("<li>окно датчика дождя <b>&#10004;</b></li>");
                poknoDD_P_A.Value = 1;
                spoknoDD_P_A.Value = 1;
            }


            if (МестоКамеры_C_A)
            {
                bhtml.Append("<li>окно видеокамеры <b>&#10004;</b></li>");
                pCamera.Value = МестоКамеры_C_A;
                spCamera.Value = МестоКамеры_C_A;
            }


            if (отверстий != "0")
            {
                bhtml.Append("<li>отверстий - <b>" + отверстий + "</b></li>");
            }


            if (GPS_G_A)
            {
                bhtml.Append("<li>антенна GPS телефона <b>&#10004;</b></li>");
                pAntenna_fw.Value = 1;
                spAntenna_fw.Value = 1;
            }


            if (Антенна_A_A)
            {
                bhtml.Append("<li>антенна приема радио <b>&#10004;</b></li>");
            }


            if (Обогрев_H_A == true)
            {
                bhtml.Append("<li>обогрев щеток очистителя <b>&#10004;</b></li>");
                pObogrev_fw.Value = 1;
                spObogrev_fw.Value = 1;
            }
            else
            {
                pObogrev_fw.Value = 0;
                spObogrev_fw.Value = 0;
            }


            if (Обогрев_F_A)
            {
                bhtml.Append("<li><b>полный обогрев стекла</b></li>");
                pObogref_fw.Value = 1;
                spObogref_fw.Value = 1;
            }
            else
            {
                pObogref_fw.Value = 0;
                spObogref_fw.Value = 0;
            }


            if (TV_антенна_J_A)
            {
                bhtml.Append("<li>антенна TV <b>&#10004;</b></li>");
                pTV_FW.Value = 1;
                spTV_FW.Value = 1;
            }



            if (ЛеваяПоловина_L_A)
            {
                bhtml.Append("<li><b>левая половина </b></li>");
            }



            if (ПраваяПоловина_R_A)
            {
                bhtml.Append("<li><b>правая половина<b> </li>");
            }



            if (Дисплей_U_A)
            {
                bhtml.Append("<li>информационный дисплей <b>&#10004;</b></li>");
                pHud.Value = 1;
                spHud.Value = 1;
            }



            if (Водооталк_N_A)
            {
                bhtml.Append("<li>водоотталкивающее</li>");
            }

            if (Крепеж_W_A)
            {
                bhtml.Append("<li>элементы крепежа <b>&#10004;</b></li>");
            }


            if (Инкапсуляция_Z_A)
            {
                bhtml.Append("<li>уплотнитель по краю стекла <b>&#10004;</b></li>");
            }

            if (МестоДД_M_A)
            {
                bhtml.Append("<li>линзы датчика дождя <b>&#10004;</b></li>");
                pDD.Value = 1;
                spDD.Value = 1;
                pid_sensor.Value = id_sensor;
                spid_sensor.Value = id_sensor;
            }
            else
            {
                pDD.Value = 0;
                spDD.Value = 0;
            }

            if (height != "0")
            {
               // bhtml.Append("<li>ширина <b><i>" + width + "</i></b> мм<i>/</i>высота <b><i>" + height + "</i></b> мм</li>");
                bhtml.Append("<li>размеры в мм <b><i>" + width + "</i>x<i>" + height + "</i></b></li>");
            }


            bhtml.Append("<li>марка: <b>" + producer + "</b></li>");


            if (razdel == "ЦЕНТР")
            {
                bhtml.Append("<li><b>цена - " + цена + "</b><span class='rub'>P.</span></li>");
            }
            else
            {
                bhtml.Append("<li><b>цена - " + цена + "</b><span class='rub'>P</span></li>");
            }


            if (cb_podrobno.Checked)
            {
                bhtml.Append("<li> <a class='opis' href='/opisanie/steklo/" + idglass.ToString() + "'>&laquo; подробности &raquo;</a></li>");
            }

            if ((id_sensor != "...") && (id_sensor.IndexOf("DZ") == -1))
            {
                bhtml.Append("<li>&nbsp;&nbsp;&nbsp;тип датчика дождя &#8211;&#9658;</li>");

                string ps2 = "/i/sens/" + id_sensor;
                string li = "<li><a href='#' rel='/i/sens/sens.php?img=" + id_sensor + "' class='sens'><img alt='' src='" + ps2 + ".jpg'></a></li>";
                bhtml.Append(li);
            }
            /*
            if ((id_sensor != "...") && (id_sensor.IndexOf("DZ") == 0))
            {
                bhtml.Append("<li>&nbsp;&nbsp;&nbsp;крепеж зеркала &#8211;&#9658;</li>");
            }
            

            if (id_sensor != "...")
            {
                string ps2 = "/i/sens/" + id_sensor;
                string li = "<li><a href='#' rel='/i/sens/sens.php?img=" + id_sensor + "' class='sens'><img alt='' src='" + ps2 + ".jpg'></a></li>";
                bhtml.Append(li);
            }
            */

            bhtml.Append("</ul>");
            bhtml.Append("</div>");
        }


        void B_glass()
        {
            idglass = (int)dr["ID_GLASS"];

            Zero();

            string n = "dg" + idglass;
            bhtml.Clear();

            string model_k = dr["ID_BODY"].ToString();
          //  string url = "/i/" + model_k + ".png";

            bhtml.Append("<div class='col-md-4' id='" + n + "'>");

            положение = dr["положение"].ToString();

            положение = положение.Trim() + ".jpg";
            bhtml.Append("<div><img alt='' src='/g/" + положение + "'/></div><br/>");

            if (id_photo != "")
            {
                bhtml.Append("<a href='#' rel='/i/auto.php?img=" + model_k + "' class='mok' ><img alt='' src='/i/" + model_k + ".png'></a>");
            }

            bhtml.Append("<ul class='gr'>");
            bhtml.Append("<li>");

            bhtml.Append("<input type='checkbox' id='c" + idglass + "' name='c" + idglass + "'/>");
            bhtml.Append("<label for='c" + idglass + "'><span></span>заказать</label>");
            bhtml.Append("</li>");

            raspolozhenie = dr["mesto"].ToString().Trim();
            raspolozhenie = raspolozhenie.Replace("(", "");
            raspolozhenie = raspolozhenie.Replace(")", "");



            if (data == "")
            {
                bhtml.Append("<li><b>" + raspolozhenie.Trim() + "</b><br> модель <b>" + marka + " " + model + "</b></li>");
                bhtml.Append("<li>кузов: <b>" + body + "</b></li>");
            }
            else
            {
                bhtml.Append("<li><b>" + raspolozhenie.Trim() + "</b><br> модель <b>" + marka + " " + model + "</b></li>");
                bhtml.Append("<li>выпуск <b>" + data + " г</b></li>");
                bhtml.Append("<li>кузов <b>" + body + "</b></li>");
            }


            if (ПравыйРуль)
            {
                bhtml.Append("<li>положение руля <b>правое</b></li>");
                pRul.Value = ПравыйРуль;
                spRul.Value = ПравыйРуль;
            }
            else
            {
                bhtml.Append("<li>положение руля <b>левое</b></li>");
                pRul.Value = false;
                spRul.Value = false;
            }


            razdel = dr["razdel"].ToString();

            bhtml.Append("<li>цвет: <b>" + color + "</b></li>");

            if (БезОбогрева_U_B)
            {
                bhtml.Append("<li>обогрева стекла <b>нет</b></li>");
                pObogrev_rw.Value = 0;
                spObogrev_rw.Value = 0;
            }
            else
            {
                bhtml.Append("<li>обогрев стекла <b>&#10004;</b></li>");
                pObogrev_rw.Value = 1;
                spObogrev_rw.Value = 1;
            }


            if (отверстий != "0")
            {
                bhtml.Append("<li>число отверстий: <b>" + отверстий + "</b></li>");
            }



            if (GPS_G_B)
            {
                bhtml.Append("<li>антенна GPS телефона <b>&#10004;</b></li>");
                pAntenna_rw.Value = 1;
                spAntenna_rw.Value = 1;
            }
            else
            {
                pAntenna_rw.Value = 0;
                spAntenna_rw.Value = 0;
            }


            if (TV_антенна_J_B)
            {
                bhtml.Append("<li>антенна приема телевидения <b>&#10004;</b> </li>");
                pTV_RW.Value = 1;
                spTV_RW.Value = 1;
            }

            if ( Антенна_A_B)
            {
                bhtml.Append("<li>антенна приема радио <b>&#10004;</b> </li>");
                pAntenna_rw.Value = 1;
                spAntenna_rw.Value = 1;
            }


            if (ЛеваяПоловина_L_B)
            {
                bhtml.Append("<li><b>левая половина</b></li>");
            }


            if (ПраваяПоловина_R_B)
            {
                bhtml.Append("<li><b>правая половина</b></li>");
            }


            if (Крепеж_W_B)
            {
                bhtml.Append("<li>элементы крепежа <b>&#10004;</b></li>");
            }

            if (ПроводСигнализации_X_B)
            {
                bhtml.Append("<li>провод сигнализации <b>&#10004;</b></li>");
            }

            if (Инкапсуляция_Z_B)
            {
                bhtml.Append("<li>уплотнитель по краю стекла <b>&#10004;</b></li>");
            }

            if (Стопсигнал_B_B)
            {
                bhtml.Append("<li>окно стоп-сигнала <b>&#10004;</b></li>");
                pStop_rw.Value = 1;
                spStop_rw.Value = 1;
            }



            if (steklopaket_D_B)
            {
                bhtml.Append("<li><b>форма стеклопакета</b></li>");
            }


            if (Триплекс_K_B)
            {
                bhtml.Append("<li><b>стекло трехслойное</b></li>");
                pTriplex_rw.Value = 1;
                spTriplex_rw.Value = 1;
            }



            if (Инкапсуляция_Z_B)
            {
                bhtml.Append("<li><b>стекло в рамке</b></li>");
            }


            if (VINокно_V_B)
            {
                bhtml.Append("<li>VIN - окно <b>&#10004;</b></li>");
            }


            if (Верхнее_Y_B)
            {
                bhtml.Append("<li><b>верхняя часть</b></li>");
            }


            if (Открывающееся_O_B)
            {
                bhtml.Append("<li><b>открываемое</b></li>");
            }


            if (РамкаСподвИнеподвСтеклом_S_B)
            {
                bhtml.Append("<li><b>стекло в рамке</b></li>");
            }

            if (height != "0")
            {
                bhtml.Append("<li>размеры в мм <b><i>" + width + "</i>x<i>" + height + "</i></b></li>");
            }



            bhtml.Append("<li>марка: <b>" + producer + "</b></li>");


            if (razdel == "ЦЕНТР")
            {
                bhtml.Append("<li><b>цена - " + цена + "</b><span class='rub'>P.</span></li>");
            }
            else
            {
                bhtml.Append("<li><b>цена - " + цена + "</b><span class='rub'>P</span></li>");
            }


            if (cb_podrobno.Checked)
            {
                bhtml.Append("<a class='opis' href='/opisanie/steklo/" + idglass.ToString() + "'>&laquo; подобности &raquo;" + "</a>");
            }

            bhtml.Append("</ul></div>");
        }


        void LR_glass()
        {
            idglass = (int)dr["ID_GLASS"];

            Zero();

            // Левые  и правые

            string n = "dg" + idglass;
            bhtml.Clear();

            string model_k = dr["ID_BODY"].ToString();
            string url = "/i/" + model_k + ".png";

            bhtml.Append("<div class='col-md-4' id='" + n + "'>");

            положение = dr["положение"].ToString();
            положение = положение.Trim() + ".jpg";
            bhtml.Append("<div><img alt='' src='/g/" + положение + "'/></div><br/>");

            if (id_photo != "")
            {
                bhtml.Append("<a href='#' rel='/i/auto.php?img=" + model_k + "' class='mok' ><img alt='alto' src='/i/" + model_k + ".png'></a>");
            }

            bhtml.Append("<ul class='gr'>");
            bhtml.Append("<li>");

            bhtml.Append("<input type='checkbox' id='c" + idglass + "' name='c" + idglass + "'/>");
            bhtml.Append("<label for='c" + idglass + "'><span></span>заказать</label>");
            bhtml.Append("</li>");

            raspolozhenie = dr["mesto"].ToString().Trim();
            raspolozhenie = raspolozhenie.Replace("(", "");
            raspolozhenie = raspolozhenie.Replace(")", "");

            if (data == "")
            {
                bhtml.Append("<li><b>" + raspolozhenie.Trim() + "</b><br> модель <b>" + marka + " " + model + "</b></li>");
                bhtml.Append("<li>кузов: <b>" + body + "</b></li>");
            }
            else
            {
                bhtml.Append("<li><b>" + raspolozhenie.Trim() + "</b><br> модель <b>" + marka + " " + model + "</b></li>");
                bhtml.Append("<li>выпуск <b>" + data + " г</b></li>");
                bhtml.Append("<li>кузов <b>" + body + "</b></li>");
            }


            razdel = dr["razdel"].ToString();

            bhtml.Append("<li>цвет: <b>" + color + "</b></li>");

            if (Стеклопакет_D_C)
            {
                bhtml.Append("<li>стеклопакет <b> &#10004;</b></li>");
            }


            if (Антенна_A_C)
            {
                bhtml.Append("<li>антенна приема радио<b> &#10004;</b></li>");
            }

            if (Верхнее_U_C)
            {
                bhtml.Append("<li><b> верхняя часть</b></li>");
            }


            if (ОткрываемоеЕлектрически_E_C)
            {
                bhtml.Append("<li><b>открываемое электроприводом</b></li>");
            }

            if (РамкаСподвИнеподвСтеклом_F_C)
            {
                bhtml.Append("<li><b>рамка с подвижным стеклом</b></li>");
            }



            if (GPS_G_C)
            {
                bhtml.Append("<li>антенна мобильного телефона <b> &#10004;</b></li>");
            }


            if (Инкапсуляция_Z_C)
            {
                bhtml.Append("<li>уплотнитель по краю стекла <b>&#10004;</b></li>");
            }



            if (Триплекс_K_C)
            {
                bhtml.Append("<li><b>стекло трехслойное</b></li>");
                pTriplex_lr.Value = 1;
                spTriplex_lr.Value = 1;
            }


            if (TV_антенна_J_C)
            {
                bhtml.Append("<li>TV-антенна приема телевидения <b> &#10004;</b></li>");
            }


            if (location == "LFD")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 1;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 1;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "RFD")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 1;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 1;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "RRD")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 1;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 1;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "LRD")
            {
                pRd_left.Value = 1;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 1;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "FFD")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 1;
                pFd_left.Value = 1;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 1;
                spFd_left.Value = 1;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }

            if (location == "FRD")
            {
                pRd_left.Value = 1;
                pRd_right.Value = 1;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 0;

                spRd_left.Value = 1;
                spRd_right.Value = 1;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 0;
            }


            if (location == "FFQ" || location == "FMQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 1;
                pBody_right.Value = 1;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 1;
                spBody_right.Value = 1;
            }

            if (location == "FRQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 1;
                pBody_right.Value = 1;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 1;
                spBody_right.Value = 1;
            }

            if (location == "LFQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 1;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 1;
                spBody_right.Value = 0;
            }

            if (location == "LRQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 1;
                pBody_right.Value = 0;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 1;
                spBody_right.Value = 0;
            }

            if (location == "RFQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 1;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 1;
            }

            if (location == "RRQ")
            {
                pRd_left.Value = 0;
                pRd_right.Value = 0;
                pFd_right.Value = 0;
                pFd_left.Value = 0;
                pBody_left.Value = 0;
                pBody_right.Value = 1;

                spRd_left.Value = 0;
                spRd_right.Value = 0;
                spFd_right.Value = 0;
                spFd_left.Value = 0;
                spBody_left.Value = 0;
                spBody_right.Value = 1;
            }


            if (VIN_V_C)
            {
                bhtml.Append("<li> VIN-окно <b> &#10004;</b></li>");
            }

            if (Обогрев_H_C)
            {
                bhtml.Append("<li>стекло с обогревом <b> &#10004;</b></li>");
            }

            if (Открывающееся_O_C)
            {
                bhtml.Append("<li><b>открываемое для вентиляции</b></li>");
            }

            if (ВыдвигающаясяАнтенна_Q_C)
            {
                bhtml.Append("<li>Выдвигающаяся антенна<b> &#10004;</b></li>");
            }

            if (ФиксаторОткрывания_T_C)
            {
                bhtml.Append("<li>фиксатор открывания<b> &#10004;</b></li>");
            }

            if (height != "0")
            {
                bhtml.Append("<li>размеры в мм <b><i>" + width + "</i>x<i>" + height + "</i></b></li>");
            }

            bhtml.Append("<li>марка: <b>" + producer + "</b></li>");


            if (razdel == "ЦЕНТР")
            {
                bhtml.Append("<li><br/><b>цена - " + цена + "</b><span class='rub'>P.</span></li>");
            }
            else
            {
                bhtml.Append("<li><br/><b>цена - " + цена + "</b><span class='rub'>P</span></li>");
            }

            if (cb_podrobno.Checked )
            {
                bhtml.Append("<a class='opis' href='/opisanie/steklo/" + idglass.ToString() + "'>&laquo; подобности &raquo;" + "</a>");
            }
               
            bhtml.Append("</ul></div>");
        }


        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            Close();
        }


        private void LoadPhotos()
        {
            SQLconnect = ConfigurationManager.ConnectionStrings["myPhotos"].ToString();

            con = new SqlConnection();
            con.ConnectionString = SQLconnect;

            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.Clear();

            con.Open();
            cmd.CommandText = "TRUNCATE TABLE AUTO_PHOTO";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO AUTO_PHOTO (MODEL)  VALUES(@MODEL)";

            SqlParameter pMODEL = new SqlParameter();
            pMODEL.SqlDbType = SqlDbType.VarChar;
            pMODEL.Size = 50;
            pMODEL.ParameterName = "@MODEL";

            cmd.Parameters.Add(pMODEL);

            string[] di = Directory.GetFiles("C:\\PNG_IN_ARCH\\");

            Cursor = Cursors.WaitCursor;

            foreach (string fname in di)
            {
                int pos = fname.IndexOf("C:\\PNG_IN_ARCH\\");

                string ss = fname.Substring(fname.IndexOf("C:\\PNG_IN_ARCH\\") + 15);

                if (ss.IndexOf(".png") > 0)
                {
                    pMODEL.Value = ss.Substring(0, ss.IndexOf(".png"));
                    cmd.ExecuteNonQuery();
                }
            }


            cmd.Parameters.Clear();
            cmd.CommandText = "TRUNCATE TABLE MMBY";  // MMBY_PHOTO
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO MMBY SELECT * FROM  MMBY WHERE ID_BODY NOT IN (SELECT MODEL FROM AUTO_PHOTO) ORDER BY ID_BODY";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "UPDATE MMBY SET ID_PHOTO = ID_BODY";
            cmd.ExecuteNonQuery();

            con.Close();

            this.Cursor = Cursors.Default;
            
        }


        private void CopyMarki()
        {
            MySqlConnection con_molten = new MySqlConnection();
            con_molten.ConnectionString = ConfigurationManager.ConnectionStrings["con_update2"].ConnectionString;

            MySqlCommand cmd_marka_molten = new MySqlCommand();
            cmd_marka_molten.Connection = con_molten;
            cmd_marka_molten.CommandText = "TRUNCATE TABLE marka_2";
            con_molten.Open();
            cmd_marka_molten.ExecuteNonQuery();
            con_molten.Close();

            MySqlConnection con_marka = new MySqlConnection();
            con_marka.ConnectionString = ConfigurationManager.ConnectionStrings["con_update"].ConnectionString;

            MySqlCommand cmd_marka = new MySqlCommand();
            cmd_marka.CommandType = CommandType.Text;
            cmd_marka.CommandText = "SELECT * FROM marka";
            cmd_marka.Connection = con_marka;

            MySqlParameter pId_marka = new MySqlParameter();
            pId_marka.MySqlDbType = MySqlDbType.Int32;
            pId_marka.ParameterName = "iid_marka";

            MySqlParameter pMarka = new MySqlParameter();
            pMarka.MySqlDbType = MySqlDbType.String;
            pMarka.Size = 80;
            pMarka.ParameterName = "imarka";

            MySqlParameter pHtml = new MySqlParameter();
            pHtml.MySqlDbType = MySqlDbType.LongText;
            pHtml.ParameterName = "ihtml";

            MySqlParameter pMarka_rus = new MySqlParameter();
            pMarka_rus.MySqlDbType = MySqlDbType.String;
            pMarka_rus.Size = 80;
            pMarka_rus.ParameterName = "imarka_rus";

            cmd_marka_molten.CommandType = CommandType.StoredProcedure;
            cmd_marka_molten.CommandText = "SaveMarka_2";

            cmd_marka_molten.Parameters.Add(pId_marka);
            cmd_marka_molten.Parameters.Add(pMarka);
            cmd_marka_molten.Parameters.Add(pHtml);
            cmd_marka_molten.Parameters.Add(pMarka_rus);

            con_marka.Open();
            con_molten.Open();

            MySqlDataReader dr = cmd_marka.ExecuteReader();

            while (dr.Read())
            {
                pId_marka.Value = (int)dr[0];
                pMarka.Value = (string)dr[1];
                pHtml.Value = (string)dr[2];
                pMarka_rus.Value = (string)dr[3];
                cmd_marka_molten.ExecuteNonQuery();
            }
            
            dr.Close();
            dr.Dispose();

            cmd_marka_molten.Parameters.Clear();
            cmd_marka_molten.CommandText = "Update_marka";
            cmd_marka_molten.ExecuteNonQuery();

            con_marka.Close();
        }


        private void CopyGlass()
        {
            MySqlConnection con_molten = new MySqlConnection();
            con_molten.ConnectionString = ConfigurationManager.ConnectionStrings["con_update2"].ConnectionString;

            MySqlCommand cmd_molten = new MySqlCommand();
            cmd_molten.Connection = con_molten;
            cmd_molten.CommandText = "TRUNCATE TABLE glassh_2";
            cmd_molten.CommandTimeout = 100000;
            con_molten.Open();
            cmd_molten.ExecuteNonQuery();


            cmd_molten.CommandText = "SAVE_GLASS";
            cmd_molten.CommandType = CommandType.StoredProcedure;

            //--- параметры обновления  стекла ------------
            pIdglass = new MySqlParameter();
            pIdglass.ParameterName = "id_glass";
            pIdglass.DbType = DbType.Int32;
            cmd_molten.Parameters.Add(pIdglass);


            //-------------------------------------------
            pSide = new MySqlParameter();
            pSide.DbType = DbType.String;
            pSide.Size = 5;
            pSide.ParameterName = "side";
            cmd_molten.Parameters.Add(pSide);



            pLocation = new MySqlParameter();
            pLocation.DbType = DbType.String;
            pLocation.Size = 20;
            pLocation.ParameterName = "flocation";
            cmd_molten.Parameters.Add(pLocation);




            //--------------------------------------
            pHtml = new MySqlParameter();
            pHtml.DbType = DbType.String;
            pHtml.Size = 64000;
            pHtml.ParameterName = "html";
            cmd_molten.Parameters.Add(pHtml);



            //--------------------------------------
            pModel = new MySqlParameter();
            pModel.ParameterName = "model";
            pModel.DbType = DbType.String;
            pModel.Size = 256;
            cmd_molten.Parameters.Add(pModel);



            //--------------------------------------------
            pBody = new MySqlParameter();
            pBody.DbType = DbType.String;
            pBody.Size = 30;
            pBody.ParameterName = "idbody";
            cmd_molten.Parameters.Add(pBody);

            //------------------------------------
            pWmodel = new MySqlParameter();
            pWmodel.ParameterName = "wmodel";
            pWmodel.DbType = DbType.String;
            pWmodel.Size = 256;
            cmd_molten.Parameters.Add(pWmodel);

            //-------------------------------------
            pData = new MySqlParameter();
            pData.DbType = DbType.String;
            pData.Size = 50;
            pData.ParameterName = "data";
            cmd_molten.Parameters.Add(pData);

            //-------------------------------------
            pBodi = new MySqlParameter();
            pBodi.DbType = DbType.String;
            pBodi.Size = 50;
            pBodi.ParameterName = "body";
            cmd_molten.Parameters.Add(pBodi);

            //------------------------------------
            pCena = new MySqlParameter();
            pCena.ParameterName = "cena";
            pCena.DbType = DbType.Int32;
            cmd_molten.Parameters.Add(pCena);

            //-----------------------------------------
            pProducer = new MySqlParameter();
            pProducer.ParameterName = "producer";
            pProducer.DbType = DbType.String;
            pProducer.Size = 50;
            cmd_molten.Parameters.Add(pProducer);

            //---------------------------------------------
            pDD = new MySqlParameter();
            pDD.DbType = DbType.Byte;
            pDD.ParameterName = "dd";
            cmd_molten.Parameters.Add(pDD);

            //-----------------------------------------------
            poknoDD_P_A = new MySqlParameter();
            poknoDD_P_A.DbType = DbType.Byte;
            poknoDD_P_A.ParameterName = "oknoDD_P_A";
            cmd_molten.Parameters.Add(poknoDD_P_A);


            // ---------------------------------------------
            pRul = new MySqlParameter();
            pRul.ParameterName = "pravrul";
            pRul.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pRul);


            //---------------------------------------
            pHud = new MySqlParameter();
            pHud.ParameterName = "hud";
            pHud.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pHud);



            //---------------------------------------
            pTV_FW = new MySqlParameter();
            pTV_FW.ParameterName = "tv_fw";
            pTV_FW.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pTV_FW);



            //---------------------------------------
            pGPS_FW = new MySqlParameter();
            pGPS_FW.ParameterName = "gps_fw";
            pGPS_FW.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pGPS_FW);


            //-----------------------------------------------
            pCamera = new MySqlParameter();
            pCamera.DbType = DbType.Byte;
            pCamera.ParameterName = "camera";
            cmd_molten.Parameters.Add(pCamera);



            //---------------------------------------------
            pObogrev_fw = new MySqlParameter(); ;
            pObogrev_fw.DbType = DbType.Byte;
            pObogrev_fw.ParameterName = "obogrev_fw";
            cmd_molten.Parameters.Add(pObogrev_fw);



            //-----------------------------------------------
            pObogref_fw = new MySqlParameter();
            pObogref_fw.DbType = DbType.Byte;
            pObogref_fw.ParameterName = "obogref_fw";
            cmd_molten.Parameters.Add(pObogref_fw);



            //-----------------------------------------------
            pAntenna_fw = new MySqlParameter();
            pAntenna_fw.DbType = DbType.Byte;
            pAntenna_fw.ParameterName = "antenna_fw";
            cmd_molten.Parameters.Add(pAntenna_fw);


            //-----------------------------------------------
            pObogrev_rw = new MySqlParameter();
            pObogrev_rw.DbType = DbType.Byte;
            pObogrev_rw.ParameterName = "obogrev_rw";
            cmd_molten.Parameters.Add(pObogrev_rw);



            //-----------------------------------------------
            pAntenna_rw = new MySqlParameter();
            pAntenna_rw.DbType = DbType.Byte;
            pAntenna_rw.ParameterName = "antenna_rw";
            cmd_molten.Parameters.Add(pAntenna_rw);



            //-----------------------------------------------
            pTriplex_rw = new MySqlParameter();
            pTriplex_rw.DbType = DbType.Byte;
            pTriplex_rw.ParameterName = "triplex_rw";
            cmd_molten.Parameters.Add(pTriplex_rw);



            //-----------------------------------------------
            pStop_rw = new MySqlParameter();
            pStop_rw.DbType = DbType.Byte;
            pStop_rw.ParameterName = "stop_rw";
            cmd_molten.Parameters.Add(pStop_rw);


            //---------------------------------------
            pTV_RW = new MySqlParameter();
            pTV_RW.ParameterName = "tv_rw";
            pTV_RW.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pTV_RW);

            //---------------------------------------
            pGPS_RW = new MySqlParameter();
            pGPS_RW.ParameterName = "gps_rw";
            pGPS_RW.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pGPS_RW);



            //---------------------------------------
            pKrepezh_rw = new MySqlParameter();
            pKrepezh_rw.ParameterName = "krepezh_rw";
            pKrepezh_rw.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pKrepezh_rw);


            //---------------------------------------
            pInkapsulazia_rw = new MySqlParameter();
            pInkapsulazia_rw.ParameterName = "inkapsulazia_rw";
            pInkapsulazia_rw.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pInkapsulazia_rw);


            //---------------------------------------
            pVerhnee_rw = new MySqlParameter();
            pVerhnee_rw.ParameterName = "verhnee_rw";
            pVerhnee_rw.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pVerhnee_rw);




            //-----------------------------------------------
            pBody_left = new MySqlParameter();
            pBody_left.DbType = DbType.Byte;
            pBody_left.ParameterName = "body_left";
            cmd_molten.Parameters.Add(pBody_left);



            //-----------------------------------------------
            pBody_right = new MySqlParameter();
            pBody_right.DbType = DbType.Byte;
            pBody_right.ParameterName = "body_right";
            cmd_molten.Parameters.Add(pBody_right);



            //-----------------------------------------------
            pFd_left = new MySqlParameter();
            pFd_left.DbType = DbType.Byte;
            pFd_left.ParameterName = "fd_left";
            cmd_molten.Parameters.Add(pFd_left);



            //---------------------------------------------
            pFd_right = new MySqlParameter();
            pFd_right.DbType = DbType.Byte;
            pFd_right.ParameterName = "fd_right";
            cmd_molten.Parameters.Add(pFd_right);



            //---------------------------------------------
            pRd_left = new MySqlParameter();
            pRd_left.DbType = DbType.Byte;
            pRd_left.ParameterName = "rd_left";
            cmd_molten.Parameters.Add(pRd_left);



            //-----------------------------------------------
            pRd_right = new MySqlParameter();
            pRd_right.DbType = DbType.Byte;
            pRd_right.ParameterName = "rd_right";
            cmd_molten.Parameters.Add(pRd_right);

            //-----------------------------------------------
            pObogrev_lr = new MySqlParameter();
            pObogrev_lr.DbType = DbType.Byte;
            pObogrev_lr.ParameterName = "obogrev_lr";
            cmd_molten.Parameters.Add(pObogrev_lr);

            //-----------------------------------------------
            pTV_antenna_lr = new MySqlParameter();
            pTV_antenna_lr.DbType = DbType.Byte;
            pTV_antenna_lr.ParameterName = "TV_antenna_lr";
            cmd_molten.Parameters.Add(pTV_antenna_lr);


            //---------------------------------------
            pKrepezh_lr = new MySqlParameter();
            pKrepezh_lr.ParameterName = "krepezh_lr";
            pKrepezh_lr.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pKrepezh_lr);


            //---------------------------------------
            pPodvizhnoe_lr = new MySqlParameter();
            pPodvizhnoe_lr.ParameterName = "podvizhnoe_lr";
            pPodvizhnoe_lr.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pPodvizhnoe_lr);

            //---------------------------------------
            pInkapsulazia_lr = new MySqlParameter();
            pInkapsulazia_lr.ParameterName = "inkapsulazia_lr";
            pInkapsulazia_lr.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pInkapsulazia_lr);

            //---------------------------------------
            pVerhnee_lr = new MySqlParameter();
            pVerhnee_lr.ParameterName = "verhnee_lr";
            pVerhnee_lr.DbType = DbType.Byte;
            cmd_molten.Parameters.Add(pVerhnee_lr);

            //-----------------------------------------------
            pTriplex_lr = new MySqlParameter();
            pTriplex_lr.DbType = DbType.Byte;
            pTriplex_lr.ParameterName = "triplex_lr";
            cmd_molten.Parameters.Add(pTriplex_lr);


            //-----------------------------------------
            pRazdel = new MySqlParameter();
            pRazdel.ParameterName = "razdel";
            pRazdel.DbType = DbType.String;
            pRazdel.Size = 50;
            cmd_molten.Parameters.Add(pRazdel);


            //-----------------------------------------------
            pid_sensor = new MySqlParameter();
            pid_sensor.DbType = DbType.String;
            pid_sensor.Size = 20;
            pid_sensor.ParameterName = "id_sensor";
            cmd_molten.Parameters.Add(pid_sensor);

            // ------------------------------------------
            pEurocode = new MySqlParameter();
            pEurocode.ParameterName = "eurocode";
            pEurocode.DbType = DbType.String;
            pEurocode.Size = 50;
            cmd_molten.Parameters.Add(pEurocode);

            SqlConnection con_local = new SqlConnection();
            con_local.ConnectionString = ConfigurationManager.ConnectionStrings["conSteklo"].ConnectionString;

            SqlCommand cmd_local = new SqlCommand();
            cmd_local.Connection = con_local;
            cmd_local.CommandText = "SELECT * FROM glassh";
            con_local.Open();

            SqlDataReader drr = cmd_local.ExecuteReader();

            while (drr.Read())
            {
                pIdglass.Value = (int)drr["id_glass"];
                pSide.Value = (string)drr["side"];
                pLocation.Value = (string)drr["flocation"];
                pHtml.Value = (string)drr["html"];
                pModel.Value = (string)drr["model"];
                pBody.Value = (string)drr["idbody"];
                pWmodel.Value = (string)drr["wmodel"];
                pData.Value = (string)drr["data"];           
                pBodi.Value = (string)drr["body"];
                pCena.Value = (int)drr["cena"];
                pProducer.Value = (string)drr["producer"];
                pDD.Value = (bool)drr["dd"];
                poknoDD_P_A.Value = (bool)drr["oknoDD_P_A"];
                pRul.Value = (bool)drr["pravrul"];
                pHud.Value = (bool)drr["hud"];
                pGPS_FW.Value = (bool)drr["gps_fw"];
                pTV_FW.Value = (bool)drr["tv_fw"];
                pCamera.Value = (bool)drr["camera"];
                pObogrev_fw.Value = (bool)drr["obogrev_fw"];
                pObogref_fw.Value = (bool)drr["obogref_fw"];
                pAntenna_fw.Value = (bool)drr["antenna_fw"];
                pObogrev_rw.Value = (bool)drr["obogrev_rw"];
                pAntenna_rw.Value = (bool)drr["antenna_rw"];
                pTriplex_rw.Value = (bool)drr["triplex_rw"];
                pStop_rw.Value = (bool)drr["stop_rw"];
                pTV_RW.Value = (bool)drr["tv_rw"];
                pGPS_RW.Value = (bool)drr["gps_rw"];
                pKrepezh_rw.Value = (bool)drr["krepezh_rw"];
                pInkapsulazia_rw.Value = (bool)drr["inkapsulazia_rw"];
                pVerhnee_rw.Value = (bool)drr["verhnee_rw"]; 
                pBody_left.Value = (bool)drr["Body_left"];
                pBody_right.Value = (bool)drr["Body_right"];
                pFd_left.Value = (bool)drr["fd_left"];
                pFd_right.Value = (bool)drr["fd_right"];
                pRd_left.Value = (bool)drr["rd_left"];
                pRd_right.Value = (bool)drr["rd_right"];
                pObogrev_lr.Value = (bool)drr["obogrev_lr"];
                pTV_antenna_lr.Value = (bool)drr["TV_antenna_lr"];
                pKrepezh_lr.Value = (bool)drr["krepezh_lr"];
                pPodvizhnoe_lr.Value = (bool)drr["podvizhnoe_lr"];
                pInkapsulazia_lr.Value = (bool)drr["inkapsulazia_lr"];
                pVerhnee_lr.Value = (bool)drr["verhnee_lr"];
                pTriplex_lr.Value = (bool)drr["Triplex_lr"];
               
                pRazdel.Value = (string)drr["razdel"];
                pid_sensor.Value = (string)drr["id_sensor"];
                pEurocode.Value = (string)drr["Eurocode"];

                cmd_molten.ExecuteNonQuery();
            }

            cmd_molten.Parameters.Clear();
            cmd_molten.CommandText = "Update_glassh";
            cmd_molten.ExecuteNonQuery();

            con_molten.Close();
            con_local.Close();
            drr.Close();
            drr.Dispose();
        }
    }

}