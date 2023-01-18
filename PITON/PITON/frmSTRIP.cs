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
    public partial class frmSTRIP : Form
    {
        public frmSTRIP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aSTRIP.Update(pITHONDataSet.STRIP);
            Close();
        }

        private void frmSTRIP_Load(object sender, EventArgs e)
        {
            aSTRIP.Fill(pITHONDataSet.STRIP);
        }
    }
}
