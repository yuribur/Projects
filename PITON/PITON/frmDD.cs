using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PITON
{
    public partial class frmDD : Form
    {
        const string p1 = "onc";
        const string p2 = "15454";
        public int id_memo;

        public frmDD()
        {
            InitializeComponent();
            Cons.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();
        }

        private void frmDD_Load(object sender, EventArgs e)
        {

            aSensory.Fill(dsSensor1);

        }

        private void btnNew_MouseUp(object sender, MouseEventArgs e)
        {

            OpenFileDialog dpic = new OpenFileDialog();
            string fullName;

            dpic.Filter = "Images (*.jpg;*.gif)|*.jpg;*.gif";
            dpic.Multiselect = false;
            dpic.ShowDialog();

            if (dpic.FileName != "")
            {
                fullName = (dpic.FileName).ToUpper();
                photoBox.Image = Image.FromFile(fullName);

                int pos = fullName.IndexOf(".JPG");
                int k= pos;
                char a = Convert.ToChar(92);
                while ( fullName[k] != a )
                {
                    k--;
                }

                string name = fullName.Substring(k+1, (pos-1 - k));

                FileStream fs = new FileStream(fullName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] photo = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                fs.Dispose();

                aSensory.InsertCommand.Parameters["@id_sensor"].Value = name;
                aSensory.InsertCommand.Parameters["@Photo"].Value = photo;

                Cons.Open();
                aSensory.InsertCommand.ExecuteNonQuery();

                dsSensor1.SENSOR.Clear();
                aSensory.Fill(dsSensor1);

                for (int i=0;  i < dsSensor1.SENSOR.Count; i++)
                {
                    string id_sensor = dsSensor1.Tables["SENSOR"].Rows[i]["id_sensor"].ToString();
                    if (id_sensor == name)
                    {
                        this.BindingContext[dsSensor1, "SENSOR"].Position = i;
                        break;
                    }
                }

                Cons.Close();
                
            }

            dpic.Dispose();
            
        }
   



        private void btnDrop_MouseUp(object sender, MouseEventArgs e)
        {
            cmdDelete.Parameters["@id_sensor"].Value = lbl_id_sensor.Text;
            Cons.Open();
            cmdDelete.ExecuteNonQuery();
            int k1 = this.BindingContext[dsSensor1, "Sensor"].Position;
            DataRow dr = dsSensor1.Tables["Sensor"].Rows[k1];
            dsSensor1.Tables["Sensor"].Rows.Remove(dr);
            Cons.Close();
        }




        private void btnRemove_MouseUp(object sender, MouseEventArgs e)
        {
            aSensor1.DeleteCommand.Parameters["@ID_MEMO"].Value = id_memo;
            aSensor1.DeleteCommand.Parameters["@ID_SENSOR"].Value = lb_id_sensor.Text;
            Cons.Open();
            aSensor1.DeleteCommand.ExecuteNonQuery();
            dsSensor1.FromSensors.Clear();
            aSensor1.Fill(dsSensor1.FromSensors);
            Cons.Close();
            btnRemove.Enabled = dsSensor1.FromSensors.Count == 0 ? false : true;
        }

        private void btnAdd_MouseUp(object sender, MouseEventArgs e)
        {
            aSensor1.InsertCommand.Parameters["@ID_SENSOR"].Value = lbl_id_sensor.Text;
            aSensor1.InsertCommand.Parameters["@ID_MEMO"].Value = id_memo;
            Cons.Open();
            aSensor1.InsertCommand.ExecuteNonQuery();
            dsSensor1.FromSensors.Clear();
            aSensor1.Fill(dsSensor1.FromSensors);
            Cons.Close();
            btnRemove.Enabled = dsSensor1.FromSensors.Count == 0 ? false : true;

            for (int i = 0; i < dsSensor1.FromSensors.Count; i++)
            {

                string id_sensor = dsSensor1.Tables["FromSensors"].Rows[i]["id_sensor"].ToString();
                if (lbl_id_sensor.Text == id_sensor)
                {
                    this.BindingContext[dsSensor1, "FromSensors"].Position = i;
                    break;
                }
            }
        }




        private void aSensory_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
        {
            int idx_sensor =grdAll.CurrentCell.RowIndex;
            string id_sensor = dsSensor1.SENSOR[idx_sensor].ID_Sensor;
            string s;

            aSensory.UpdateCommand.Parameters["@ID_SENSOR"].Value = idx_sensor;

            s = dsSensor1.SENSOR[idx_sensor].Y1;
            aSensory.UpdateCommand.Parameters["@Y1"].Value = s;
            aSensory.UpdateCommand.ExecuteNonQuery();

            s = dsSensor1.SENSOR[idx_sensor].M1;
            aSensory.UpdateCommand.Parameters["@M1"].Value = s;
            aSensory.UpdateCommand.ExecuteNonQuery();

            s = dsSensor1.SENSOR[idx_sensor].Y2;
            aSensory.UpdateCommand.Parameters["@Y2"].Value = s;
            aSensory.UpdateCommand.ExecuteNonQuery();

            s = dsSensor1.SENSOR[idx_sensor].M2;
            aSensory.UpdateCommand.Parameters["@M2"].Value = s;
            aSensory.UpdateCommand.ExecuteNonQuery();
        }


        private void frmDD_Deactivate(object sender, EventArgs e)
        {
            aSensory.Update(dsSensor1.SENSOR);
        }

        private void frmDD_Activated(object sender, EventArgs e)
        {
            selSensor1.Parameters["@id_memo"].Value = id_memo;
            dsSensor1.FromSensors.Clear();
            aSensor1.Fill(dsSensor1);
            btnRemove.Enabled = dsSensor1.FromSensors.Count == 0 ? false : true;
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btClose_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}

