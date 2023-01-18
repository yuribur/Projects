using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PITON;

namespace PITON
{
    public partial class frmAnalog : Form
    {
        public int pos_marka;
        public int pos_model;
        public dsv dsv2;

        int current_id_memo;
        int current_id_model;
        public int new_id_memo;

        public frmAnalog()
        {
            InitializeComponent();
        }

        private void frmAnalog_Load(object sender, EventArgs e)
        {
            lstMarka.DataSource = dsv2;
            lstMarka.DisplayMember = "FromMarka.marka";
            lstModel.DataSource = dsv2;
            lstModel.DisplayMember = "FromMarka.FromMarka_FromModel.model";
            this.BindingContext[dsv2, "FromMarka"].Position = pos_marka;
            this.BindingContext[dsv2, "FromMarka.FromMarka_FromModel"].Position = pos_model;
            int k1 = this.BindingContext[dsv2, "FromMarka"].Position;
            int k2 = this.BindingContext[dsv2, "FromMarka.FromMarka_FromModel"].Position;
            DataRow[] dr = dsv2.Tables["FromMarka"].Rows[k1].GetChildRows("FromMarka_FromModel");
            current_id_memo = Convert.ToInt32( dr[k2]["id_memo"].ToString());
            current_id_model = Convert.ToInt32(dr[k2]["id_model"].ToString());
        }


        private void btnAnalog_MouseUp(object sender, MouseEventArgs e)
        {
            //--- получим id_model->new_id_model и id_memo-> new_id_memo указанной записи
            int k1 = this.BindingContext[dsv2, "FromMarka"].Position;
            int k2 = this.BindingContext[dsv2, "FromMarka.FromMarka_FromModel"].Position;
            DataRow[] dr = dsv2.Tables["FromMarka"].Rows[k1].GetChildRows("FromMarka_FromModel");
            new_id_memo = Convert.ToInt32(dr[k2]["id_memo"].ToString());

            this.Close();
        }

        private void btnNoanalog_MouseUp(object sender, MouseEventArgs e)
        {
            //-- модель уникальная и всё !!
            new_id_memo = current_id_model;
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            //-- изменений нет !
            new_id_memo = 0;
        }

        private void Option_CheckedChanged(object sender, EventArgs e)
        {
            if (Option.Checked)
            {
                btnAnalog.Enabled = false;
            }
            else
            {
                btnAnalog.Enabled = true;
            }
        }

    }
}