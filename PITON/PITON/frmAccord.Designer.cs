namespace PITON
{
    partial class frmAccord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccord));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.Conc = new System.Data.SqlClient.SqlConnection();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.atBSG = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.atFYG = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.atXYG = new System.Data.SqlClient.SqlDataAdapter();
            this.gCatalog = new System.Windows.Forms.DataGrid();
            this.dsCatal1 = new PITON.dsCatal();
            this.gStyle = new System.Windows.Forms.DataGridTableStyle();
            this.C1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.C2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.C3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.C4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCatalog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCatal1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 538);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 37);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(463, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCancel_MouseUp);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(263, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Обновить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOk_MouseUp);
            // 
            // Conc
            // 
            this.Conc.ConnectionString = "Data Source=box21;Initial Catalog=PITHON;Persist Security Info=True;User ID=datex" +
    "ml;Password=56538085";
            this.Conc.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "dbo.TEST_CATALOG_BSG";
            this.sqlSelectCommand1.CommandTimeout = 300;
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.Conc;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // atBSG
            // 
            this.atBSG.SelectCommand = this.sqlSelectCommand1;
            this.atBSG.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "TEST_CATALOG_BSG", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("НАИМЕНОВАНИЕ", "НАИМЕНОВАНИЕ"),
                        new System.Data.Common.DataColumnMapping("ЕВРОКОД", "ЕВРОКОД"),
                        new System.Data.Common.DataColumnMapping("FYGКОД", "FYGКОД"),
                        new System.Data.Common.DataColumnMapping("XYGКОД", "XYGКОД")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "dbo.TEST_CATALOG_FYG";
            this.sqlSelectCommand2.CommandTimeout = 300;
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.Conc;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // atFYG
            // 
            this.atFYG.SelectCommand = this.sqlSelectCommand2;
            this.atFYG.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "TEST_CATALOG_FYG", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("НАИМЕНОВАНИЕ", "НАИМЕНОВАНИЕ"),
                        new System.Data.Common.DataColumnMapping("ЕВРОКОД", "ЕВРОКОД"),
                        new System.Data.Common.DataColumnMapping("FYGКОД", "FYGКОД"),
                        new System.Data.Common.DataColumnMapping("XYGКОД", "XYGКОД")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "dbo.TEST_CATALOG_XYG";
            this.sqlSelectCommand3.CommandTimeout = 300;
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.Conc;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // atXYG
            // 
            this.atXYG.SelectCommand = this.sqlSelectCommand3;
            this.atXYG.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "TEST_CATALOG_XYG", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("НАИМЕНОВАНИЕ", "НАИМЕНОВАНИЕ"),
                        new System.Data.Common.DataColumnMapping("ЕВРОКОД", "ЕВРОКОД"),
                        new System.Data.Common.DataColumnMapping("FYGКОД", "FYGКОД"),
                        new System.Data.Common.DataColumnMapping("XYGКОД", "XYGКОД")})});
            // 
            // gCatalog
            // 
            this.gCatalog.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gCatalog.CaptionVisible = false;
            this.gCatalog.DataMember = "";
            this.gCatalog.DataSource = this.dsCatal1;
            this.gCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCatalog.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gCatalog.Location = new System.Drawing.Point(0, 0);
            this.gCatalog.Name = "gCatalog";
            this.gCatalog.Size = new System.Drawing.Size(694, 538);
            this.gCatalog.TabIndex = 1;
            this.gCatalog.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.gStyle});
            // 
            // dsCatal1
            // 
            this.dsCatal1.DataSetName = "dsCatal";
            this.dsCatal1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gStyle
            // 
            this.gStyle.DataGrid = this.gCatalog;
            this.gStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.C1,
            this.C2,
            this.C3,
            this.C4});
            this.gStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gStyle.MappingName = "Table";
            this.gStyle.RowHeaderWidth = 30;
            // 
            // C1
            // 
            this.C1.Format = "";
            this.C1.FormatInfo = null;
            this.C1.HeaderText = "НАИМЕНОВАНИЕ";
            this.C1.MappingName = "НАИМЕНОВАНИЕ";
            this.C1.NullText = "";
            this.C1.Width = 400;
            // 
            // C2
            // 
            this.C2.Format = "";
            this.C2.FormatInfo = null;
            this.C2.HeaderText = "ЕВРОКОД";
            this.C2.MappingName = "ЕВРОКОД";
            this.C2.NullText = "";
            this.C2.Width = 120;
            // 
            // C3
            // 
            this.C3.Format = "";
            this.C3.FormatInfo = null;
            this.C3.HeaderText = "СКАНКОД";
            this.C3.MappingName = "СКАНКОД";
            this.C3.NullText = "";
            this.C3.Width = 75;
            // 
            // C4
            // 
            this.C4.Format = "";
            this.C4.FormatInfo = null;
            this.C4.HeaderText = "XYGКОДЕ";
            this.C4.MappingName = "XYGКОДЕ";
            this.C4.NullText = "";
            this.C4.Width = 75;
            // 
            // frmAccord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 575);
            this.Controls.Add(this.gCatalog);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccord";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Несоответствия с каталогом";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccord_FormClosing);
            this.Load += new System.EventHandler(this.frmAccord_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gCatalog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCatal1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGrid gCatalog;
        private System.Data.SqlClient.SqlConnection Conc;
        private System.Windows.Forms.DataGridTableStyle gStyle;
        private System.Windows.Forms.DataGridTextBoxColumn C1;
        private System.Windows.Forms.DataGridTextBoxColumn C2;
        private System.Windows.Forms.DataGridTextBoxColumn C3;
        private System.Windows.Forms.DataGridTextBoxColumn C4;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlDataAdapter atBSG;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlDataAdapter atFYG;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
        private System.Data.SqlClient.SqlDataAdapter atXYG;
        private dsCatal dsCatal1;
    }
}