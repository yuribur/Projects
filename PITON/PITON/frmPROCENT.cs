using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PITON
{
    public partial class frmPROCENT : Form
    {
        public frmPROCENT()
        {
            InitializeComponent();
        }


        private void Close_Click(object sender, EventArgs e)
        {
            aPROCENT.Update(pITHONDataSet1.PROCENT);
            Close();
        }

        private void frmPROCENT_Load(object sender, EventArgs e)
        {
            aPROCENT.Fill(pITHONDataSet1.PROCENT);
        }
    }
}
