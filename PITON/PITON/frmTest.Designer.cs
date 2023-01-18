namespace PITON
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.seldb = new System.Data.SqlClient.SqlCommand();
            this.Conn = new System.Data.SqlClient.SqlConnection();
            this.adb = new System.Data.SqlClient.SqlDataAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.grdTEST = new System.Windows.Forms.DataGrid();
            this.dsTest1 = new PITON.dsTest();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTEST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTest1)).BeginInit();
            this.SuspendLayout();
            // 
            // seldb
            // 
            this.seldb.CommandText = "dbo.TEST_SPLIN";
            this.seldb.CommandTimeout = 6000;
            this.seldb.CommandType = System.Data.CommandType.StoredProcedure;
            this.seldb.Connection = this.Conn;
            this.seldb.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // Conn
            // 
            this.Conn.ConnectionString = "Data Source=box21;Initial Catalog=PITHON;Persist Security Info=True;User ID=datex" +
    "ml;Password=56538085";
            this.Conn.FireInfoMessageEventOnUserErrors = false;
            // 
            // adb
            // 
            this.adb.SelectCommand = this.seldb;
            this.adb.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "TEST_SPLIN", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Õ¿»Ã≈ÕŒ¬¿Õ»≈", "Õ¿»Ã≈ÕŒ¬¿Õ»≈"),
                        new System.Data.Common.DataColumnMapping("≈¬–Œ Œƒ", "≈¬–Œ Œƒ"),
                        new System.Data.Common.DataColumnMapping("— ¿Õ Œƒ", "— ¿Õ Œƒ"),
                        new System.Data.Common.DataColumnMapping("XYG Œƒ", "XYG Œƒ")})});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 534);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 31);
            this.panel1.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(463, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Œ·ÌÓ‚ËÚ¸";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRefresh_MouseUp);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btClose.Location = new System.Drawing.Point(632, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "«‡Í˚Ú¸";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btClose_MouseUp);
            // 
            // grdTEST
            // 
            this.grdTEST.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdTEST.CaptionVisible = false;
            this.grdTEST.DataMember = "TEST_SPLIN";
            this.grdTEST.DataSource = this.dsTest1;
            this.grdTEST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTEST.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdTEST.Location = new System.Drawing.Point(0, 0);
            this.grdTEST.Name = "grdTEST";
            this.grdTEST.ReadOnly = true;
            this.grdTEST.RowHeaderWidth = 30;
            this.grdTEST.Size = new System.Drawing.Size(719, 534);
            this.grdTEST.TabIndex = 2;
            this.grdTEST.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dsTest1
            // 
            this.dsTest1.DataSetName = "dsTest";
            this.dsTest1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.grdTEST;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn4});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "TEST_SPLIN";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 30;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Ì‡ËÏÂÌÓ‚‡ÌËÂ";
            this.dataGridTextBoxColumn1.MappingName = "Õ¿»Ã≈ÕŒ¬¿Õ»≈";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 380;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Â‚ÓÍÓ‰";
            this.dataGridTextBoxColumn2.MappingName = "≈¬–Œ Œƒ";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "XYG-ÍÓ‰";
            this.dataGridTextBoxColumn4.MappingName = "XYG Œƒ";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 80;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 565);
            this.Controls.Add(this.grdTEST);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÕÂÒÓÓÚ‚ÂÚÒÚ‚Ëˇ";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTest_FormClosed);
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTEST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTest1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.SqlClient.SqlCommand seldb;
        private System.Data.SqlClient.SqlDataAdapter adb;
        private System.Data.SqlClient.SqlConnection Conn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGrid grdTEST;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.Button btnRefresh;
        private dsTest dsTest1;
    }
}