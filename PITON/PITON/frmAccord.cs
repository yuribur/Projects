using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PITON
{
    public partial class frmAccord : Form
    {
        const string p1 = "onc";
        const string p2 = "15454";
        private string baseName;
        public Int16 flag;

        public void SetBase(string baseN)
        {
            baseName = baseN;
        }

        public string GetBase()
        {
            return baseName;
        }

        public frmAccord()
        {
            InitializeComponent();
           // string s = Conc.ConnectionString;
            Conc.ConnectionString = ConfigurationManager.ConnectionStrings["myCon"].ToString();
           // Conc.ConnectionString = s; //.Replace("onS15454*", "onc15454*");
        }

        private void btnCancel_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnOk_MouseUp(object sender, MouseEventArgs e)
        {
            dsCatal1.Clear();
            Cursor = Cursors.WaitCursor;

            switch (baseName)
            {
                case "FYG":
                   gCatalog.DataMember = "TEST_CATALOG_FYG";
                    atFYG.Fill(dsCatal1.TEST_CATALOG_FYG);
                    this.Text = "Несоответствия с каталогом FYG";
                    flag = 1;
                    break;

                case "XYG":
                    gCatalog.DataMember = "TEST_CATALOG_XYG";
                    atFYG.Fill(dsCatal1.TEST_CATALOG_XYG);
                    this.Text = "Несоответствия с каталогом XYG";
                    flag = 1;
                    break;

                case "BSG":
                    gCatalog.DataMember = "TEST_CATALOG_BSG";
                    atBSG.Fill(dsCatal1.TEST_CATALOG_BSG);
                    this.Text = "Несоответствия с каталогом BSG";
                    flag = 1;
                    break;
            }

            Cursor = Cursors.Default;
        }

        private void frmAccord_Load(object sender, EventArgs e)
        {
          dsCatal1.Clear();

            switch (baseName)
            {
                case "FYG":
                    atFYG.Fill(dsCatal1.TEST_CATALOG_FYG);
                    gCatalog.DataMember = "TEST_CATALOG_FYG";            
                    this.Text = "Несоответствия с каталогом FYG";
                    flag = 1;
                    C1.Width = 200;
                    break;

                case "XYG":
                    atXYG.Fill(dsCatal1.TEST_CATALOG_XYG);
                    gCatalog.DataMember = "TEST_CATALOG_XYG";
                    this.Text = "Несоответствия с каталогом XYG";
                    flag = 1;
                    break;

                case "BSG":
                    atBSG.Fill(dsCatal1.TEST_CATALOG_BSG);
                    gCatalog.DataMember = "TEST_CATALOG_BSG";
                    this.Text = "Несоответствия с каталогом BSG";
                    flag = 1;
                    break;
            }
        }



        private void frmAccord_FormClosing(object sender, FormClosingEventArgs e)
        {
            baseName = "";
            this.Dispose();
        }

    }
}
