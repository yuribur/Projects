using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PITON
{
    public partial class frmModel : Form
    {
        public frmModel()
        {
            InitializeComponent();
        }

        private void frmModel_Load(object sender, EventArgs e)
        {
           if ( H3.Checked==false
                && H5.Checked ==false  && S2.Checked == false && S4.Checked == false && S4L.Checked == false 
                && S6.Checked == false && C2.Checked == false && C4.Checked == false && E3.Checked == false 
                && E5.Checked == false && L2.Checked == false && T2.Checked == false
                && P2.Checked == false && P4.Checked == false && L4.Checked == false 
                && V2.Checked == false && V3.Checked == false && V3L.Checked == false 
                && V4.Checked == false && V4L.Checked == false  && V5.Checked == false && V5L.Checked == false 
                && M3.Checked == false && M3L.Checked == false && M4.Checked == false && M4L.Checked == false 
                && M5.Checked == false  && M5L.Checked == false
                && R3.Checked == false && R5.Checked == false && R5L.Checked == false  
                && HTOP.Checked == false && HARDTOP_E5.Checked == false && LIFTBACK.Checked == false )
            { btnSave.Enabled = false; }
        }


        private void BODY_CheckedChanged(object sender, EventArgs e)
        {
            if (H3.Checked == false
                 && H5.Checked == false && S2.Checked == false && S4.Checked == false && S4L.Checked == false
                 && S6.Checked == false && C2.Checked == false && C4.Checked == false && E3.Checked == false
                 && E5.Checked == false && L2.Checked == false && T2.Checked == false
                 && P2.Checked == false && P4.Checked == false && L4.Checked == false
                 && V2.Checked == false && V3.Checked == false && V3L.Checked == false
                 && V4.Checked == false && V4L.Checked == false && V5.Checked == false && V5L.Checked == false
                 && M3.Checked == false && M3L.Checked == false && M4.Checked == false && M4L.Checked == false
                 && M5.Checked == false && M5L.Checked == false
                 && R3.Checked == false && R5.Checked == false && R5L.Checked == false
                 && HTOP.Checked == false && HARDTOP_E5.Checked == false && LIFTBACK.Checked == false)
                btnSave.Enabled = false; 
            
            else
                btnSave.Enabled = true;
        }
    }
}
