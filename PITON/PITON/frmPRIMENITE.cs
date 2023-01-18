using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PITON
{
    public partial class frmPRIMENITE : Form
    {

        public frmPRIMENITE()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            Con.Open();

            Cursor = Cursors.WaitCursor;

            cmd.CommandText = "GLASS_A";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            cmd.CommandText = "GLASS_B";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            cmd.CommandText = "GLASS_L";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            cmd.CommandText = "GLASS_R";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            cmd.CommandText = "GLASS_F";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            Cursor = Cursors.Default;

            Close();
        }
    }
}
