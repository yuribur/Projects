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
    public partial class frmLOCATION : Form
    {
        public frmLOCATION()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
            aLOCATION.Update(pITHONDataSet.LOCATION);
        }

        private void frmLOCATION_Load(object sender, EventArgs e)
        {
            aLOCATION.Fill(pITHONDataSet.LOCATION);
        }
    }
}
