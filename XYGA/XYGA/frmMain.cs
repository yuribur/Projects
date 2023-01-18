using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace XYGA
{


    public partial class frmMain : Form
    {
        SqlConnection Cons;
        SqlCommand cmd_sitek;
        SqlCommand cmd_delete_glass;

        public frmMain()
        {
            InitializeComponent();

            


            Cons = new SqlConnection();
            Cons.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();
            Cons.Open();

            cmd_sitek = new SqlCommand();
            cmd_sitek.Connection = Cons;

            cmd_delete_glass = new SqlCommand();
            cmd_delete_glass.Connection = Cons;
            cmd_delete_glass.CommandType = System.Data.CommandType.Text;
            cmd_delete_glass.CommandText = "DELETE_GLASS_TRY";

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lbl_Begin.Text = String.Format("{0:d2}", DateTime.Now.Hour) + ":" + String.Format("{0:d2}", DateTime.Now.Minute) ;
            lbl_End.Text = "";
            this.Update();

            this.Cursor = Cursors.WaitCursor;
            btnStart.Enabled = false;
            btnClose.Enabled = false;

            if (radioLast.Checked)
            {
                if ( Cons.State == ConnectionState.Open)
                    Cons.Close();

                Cons.Open();
                cmd_delete_glass.CommandText = "DELETE_GLASS_TRY";
                cmd_delete_glass.ExecuteNonQuery();
                Cons.Close();   
            }
            
            if (radioAll.Checked)
            {
                if (Cons.State == ConnectionState.Open)
                    Cons.Close();

                Cons.Open();
                cmd_delete_glass.CommandText = "DELETE_GLASS_ALL";
                cmd_delete_glass.ExecuteNonQuery();
                Cons.Close();
            }


            if (chbModeli.Checked)
            {
                Modell gx = new Modell();
                gx.Select_modeli();

                ClassX mx = new ClassX();
                mx.Select_models();
                chbModeli.Checked = false;
            }



            if (chkGlass.Checked)
            {
                Class_Glass cg = new Class_Glass();
                cg.GetModel_Glass();
                chkGlass.Checked = false;
            }



            if (chbUnloadPhoto.Checked)
            {
                Photo_Load fotoload = new Photo_Load();
                fotoload.UnLoad_photo_from_site();
                chbUnloadPhoto.Checked = false;
            }

            if (chbLoadPhoto.Checked)
            {
                Photo_Load fotoload = new Photo_Load();
                fotoload.Load_photo_into_pithon();
                chbLoadPhoto.Checked = false;
            }

            if (cbShutdown.Checked) // закрыть виндовз
            {
                Reboot reboot = new Reboot();
                // reboot.Lock(); блокировка компа
                reboot.halt(false, false);
            }


            this.Cursor = Cursors.Default;
            
            btnStart.Enabled = true;
            btnClose.Enabled = true;
            lbl_End.Text = String.Format("{0:d2}", DateTime.Now.Hour) + ":" + String.Format("{0:d2}", DateTime.Now.Minute);
            this.Update();

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
