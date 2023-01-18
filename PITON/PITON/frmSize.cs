using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PITON
{
    public partial class frmSize : Form
    {

        public frmSize()
        {
            InitializeComponent();

            sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();
        }



        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_MouseUp(object sender, MouseEventArgs e)
        {
            aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE";

            if ( Convert.ToInt16(ddHeight.Text) != 0)
            {
                aFYG.SelectCommand.Parameters["@height1"].Value = Convert.ToInt16(ddHeight.Text) - Convert.ToInt16(delta.Text);
                aFYG.SelectCommand.Parameters["@height2"].Value = Convert.ToInt16(ddHeight.Text) + Convert.ToInt16(delta.Text);
            }
            else
            {
                aFYG.SelectCommand.Parameters["@height1"].Value = 0;
                aFYG.SelectCommand.Parameters["@height2"].Value = 0;
            }

            if (Convert.ToInt16(ddWidth.Text) != 0)
            {
                aFYG.SelectCommand.Parameters["@width1"].Value = Convert.ToInt16(ddWidth.Text) - Convert.ToInt16(delta.Text);
                aFYG.SelectCommand.Parameters["@width2"].Value = Convert.ToInt16(ddWidth.Text) + Convert.ToInt16(delta.Text);
            }
            else
            {
                aFYG.SelectCommand.Parameters["@width1"].Value = 0;
                aFYG.SelectCommand.Parameters["@width2"].Value = 0;
            }

            if (Convert.ToInt16(ddCentr.Text) != 0)
            {
                aFYG.SelectCommand.Parameters["@centr1"].Value = Convert.ToInt16(ddCentr.Text) - Convert.ToInt16(delta.Text);
                aFYG.SelectCommand.Parameters["@centr2"].Value = Convert.ToInt16(ddCentr.Text) + Convert.ToInt16(delta.Text);
            }
            else
            {
                aFYG.SelectCommand.Parameters["@centr1"].Value = 0;
                aFYG.SelectCommand.Parameters["@centr2"].Value = 0;
            }

            if (Convert.ToInt16(ddDiago.Text) != 0)
            {
                aFYG.SelectCommand.Parameters["@diago1"].Value = Convert.ToInt16(ddDiago.Text) - Convert.ToInt16(delta.Text);
                aFYG.SelectCommand.Parameters["@diago2"].Value = Convert.ToInt16(ddDiago.Text) - Convert.ToInt16(delta.Text);
            }
            else
            {
                aFYG.SelectCommand.Parameters["@diago1"].Value = 0;
                aFYG.SelectCommand.Parameters["@diago2"].Value = 0;
            }

            if (Convert.ToInt16(ddCentr.Text) == 0 && Convert.ToInt16(ddDiago.Text) == 0 && Convert.ToInt16(ddHeight.Text) != 0 && Convert.ToInt16(ddWidth.Text) != 0)
                   aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_WIDTH_HEIGHT";

            if (Convert.ToInt16(ddHeight.Text) == 0 && Convert.ToInt16(ddDiago.Text) == 0 && Convert.ToInt16(ddCentr.Text) != 0 && Convert.ToInt16(ddWidth.Text) != 0)
                aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_WIDTH_CENTR";

            if (Convert.ToInt16(ddHeight.Text) == 0 && Convert.ToInt16(ddCentr.Text) == 0 && Convert.ToInt16(ddDiago.Text) != 0 && Convert.ToInt16(ddWidth.Text) != 0)
                aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_WIDTH_DIAGO";
            
            if (Convert.ToInt16(ddHeight.Text) == 0 && Convert.ToInt16(ddWidth.Text) == 0 && Convert.ToInt16(ddDiago.Text) != 0 && Convert.ToInt16(ddCentr.Text) != 0)
                aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_CENTR_DIAGO";

            if (Convert.ToInt16(ddWidth.Text) == 0 && Convert.ToInt16(ddDiago.Text) == 0 && Convert.ToInt16(ddHeight.Text) != 0 && Convert.ToInt16(ddCentr.Text) != 0)
                aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_HEIGHT_CENTR";

            if (Convert.ToInt16(ddCentr.Text) == 0 && Convert.ToInt16(ddWidth.Text) == 0 && Convert.ToInt16(ddHeight.Text) != 0 && Convert.ToInt16(ddDiago.Text) != 0)
                aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_HEIGHT_DIAGO";



            if (Convert.ToInt16(ddCentr.Text) != 0 && Convert.ToInt16(ddWidth.Text) != 0 && Convert.ToInt16(ddHeight.Text) != 0 && Convert.ToInt16(ddDiago.Text) == 0)
                aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_HEIGHT_WIDTH_CENTER";

            if (Convert.ToInt16(ddDiago.Text) != 0 && Convert.ToInt16(ddWidth.Text) != 0 && Convert.ToInt16(ddHeight.Text) == 0 && Convert.ToInt16(ddCentr.Text) != 0)
                aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_DIAGO_WIDTH_CENTER";

            if (Convert.ToInt16(ddCentr.Text) != 0 && Convert.ToInt16(ddWidth.Text) == 0 && Convert.ToInt16(ddHeight.Text) != 0 && Convert.ToInt16(ddDiago.Text) != 0)
                aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_DIAGO_HEIGHT_CENTER";

            if (Convert.ToInt16(ddCentr.Text) == 0 && Convert.ToInt16(ddWidth.Text) != 0 && Convert.ToInt16(ddHeight.Text) != 0 && Convert.ToInt16(ddDiago.Text) != 0)
                aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_WIDTH_HEIGHT_DIAGO";


            if (Convert.ToInt16(ddCentr.Text) != 0 && Convert.ToInt16(ddWidth.Text) != 0 && Convert.ToInt16(ddHeight.Text) != 0 && Convert.ToInt16(ddDiago.Text) != 0)
                aFYG.SelectCommand.CommandText = "SEARCH_BY_SIZE_WIDTH_HEIGHT_CENTER_DIAGO";

            dsSize1.Clear();
            aFYG.Fill(dsSize1);
        }


        private void ddWidth_Leave(object sender, EventArgs e)
        {
            if (ddWidth.Text.Length == 0)
            {
                 ddWidth.Text = "0";
            }
        }

        private void ddHeight_Leave(object sender, EventArgs e)
        {
            if (ddHeight.Text.Length == 0)
            {
                ddHeight.Text = "0";
            }
        }

        private void ddCentr_Leave(object sender, EventArgs e)
        {
            if (ddCentr.Text.Length == 0)
            {
                ddCentr.Text = "0";
            }
        }

        private void ddDiago_Leave(object sender, EventArgs e)
        {
            if (ddDiago.Text.Length == 0)
            {
                ddDiago.Text = "0";
            }
        }

        private void delta_Leave(object sender, EventArgs e)
        {
            if (delta.Text.Length == 0)
            {
                delta.Text = "0";
            }
        }
    }
}
