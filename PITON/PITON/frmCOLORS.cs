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
    public partial class frmCOLORS : Form
    {
        public frmCOLORS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aCOLORS.Update(pITHONDataSet.COLORS);
            Close();
        }

        private void frmCOLORS_Load(object sender, EventArgs e)
        {
            aCOLORS.Fill(pITHONDataSet.COLORS);
        }
    }
}
