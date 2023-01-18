namespace PITON
{
    partial class frmPROCENT
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
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.sqlCon = new System.Data.SqlClient.SqlConnection();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aPROCENT = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.пОСТАВЩИКDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.лОБОВЫЕDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.бОКОВЫЕDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.зАДНИЕDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pITHONDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pITHONDataSet1 = new PITON.PITHONDataSet();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(446, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Ок";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // sqlCon
            // 
            this.sqlCon.ConnectionString = "Data Source=.;Initial Catalog=PITHON;User ID=sa;Password=onc15454*";
            this.sqlCon.FireInfoMessageEventOnUserErrors = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 37);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.пОСТАВЩИКDataGridViewTextBoxColumn,
            this.лОБОВЫЕDataGridViewTextBoxColumn,
            this.бОКОВЫЕDataGridViewTextBoxColumn,
            this.зАДНИЕDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "PROCENT";
            this.dataGridView1.DataSource = this.pITHONDataSet1BindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 296);
            this.dataGridView1.TabIndex = 2;
            // 
            // aPROCENT
            // 
            this.aPROCENT.DeleteCommand = this.sqlDeleteCommand1;
            this.aPROCENT.InsertCommand = this.sqlInsertCommand1;
            this.aPROCENT.SelectCommand = this.sqlSelectCommand1;
            this.aPROCENT.UpdateCommand = this.sqlCommand1;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = "UPDATE       PROCENT\r\nSET                ПОСТАВЩИК = @ПОСТАВЩИК, ЛОБОВЫЕ = @ЛОБОВ" +
    "ЫЕ, БОКОВЫЕ = @БОКОВЫЕ, ЗАДНИЕ = @ЗАДНИЕ\r\nWHERE        (ID = @ID)";
            this.sqlInsertCommand1.Connection = this.sqlCon;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ПОСТАВЩИК", System.Data.SqlDbType.NVarChar, 20, "ПОСТАВЩИК"),
            new System.Data.SqlClient.SqlParameter("@ЛОБОВЫЕ", System.Data.SqlDbType.SmallInt, 2, "ЛОБОВЫЕ"),
            new System.Data.SqlClient.SqlParameter("@БОКОВЫЕ", System.Data.SqlDbType.SmallInt, 2, "БОКОВЫЕ"),
            new System.Data.SqlClient.SqlParameter("@ЗАДНИЕ", System.Data.SqlDbType.SmallInt, 2, "ЗАДНИЕ"),
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT        ПОСТАВЩИК, ЛОБОВЫЕ, БОКОВЫЕ, ЗАДНИЕ, ID\r\nFROM            PROCENT";
            this.sqlSelectCommand1.Connection = this.sqlCon;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "UPDATE       PROCENT\r\nSET                ПОСТАВЩИК = @ПОСТАВЩИК, ЛОБОВЫЕ = @ЛОБОВ" +
    "ЫЕ, БОКОВЫЕ = @БОКОВЫЕ, ЗАДНИЕ = @ЗАДНИЕ\r\nWHERE        (ID = @ID)";
            this.sqlCommand1.Connection = this.sqlCon;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ПОСТАВЩИК", System.Data.SqlDbType.NVarChar, 20, "ПОСТАВЩИК"),
            new System.Data.SqlClient.SqlParameter("@ЛОБОВЫЕ", System.Data.SqlDbType.SmallInt, 2, "ЛОБОВЫЕ"),
            new System.Data.SqlClient.SqlParameter("@БОКОВЫЕ", System.Data.SqlDbType.SmallInt, 2, "БОКОВЫЕ"),
            new System.Data.SqlClient.SqlParameter("@ЗАДНИЕ", System.Data.SqlDbType.SmallInt, 2, "ЗАДНИЕ"),
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // пОСТАВЩИКDataGridViewTextBoxColumn
            // 
            this.пОСТАВЩИКDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.пОСТАВЩИКDataGridViewTextBoxColumn.DataPropertyName = "ПОСТАВЩИК";
            this.пОСТАВЩИКDataGridViewTextBoxColumn.HeaderText = "ПОСТАВЩИК";
            this.пОСТАВЩИКDataGridViewTextBoxColumn.MaxInputLength = 20;
            this.пОСТАВЩИКDataGridViewTextBoxColumn.Name = "пОСТАВЩИКDataGridViewTextBoxColumn";
            // 
            // лОБОВЫЕDataGridViewTextBoxColumn
            // 
            this.лОБОВЫЕDataGridViewTextBoxColumn.DataPropertyName = "ЛОБОВЫЕ";
            this.лОБОВЫЕDataGridViewTextBoxColumn.HeaderText = "ЛОБОВЫЕ";
            this.лОБОВЫЕDataGridViewTextBoxColumn.MaxInputLength = 3;
            this.лОБОВЫЕDataGridViewTextBoxColumn.Name = "лОБОВЫЕDataGridViewTextBoxColumn";
            // 
            // бОКОВЫЕDataGridViewTextBoxColumn
            // 
            this.бОКОВЫЕDataGridViewTextBoxColumn.DataPropertyName = "БОКОВЫЕ";
            this.бОКОВЫЕDataGridViewTextBoxColumn.HeaderText = "БОКОВЫЕ";
            this.бОКОВЫЕDataGridViewTextBoxColumn.MaxInputLength = 3;
            this.бОКОВЫЕDataGridViewTextBoxColumn.Name = "бОКОВЫЕDataGridViewTextBoxColumn";
            // 
            // зАДНИЕDataGridViewTextBoxColumn
            // 
            this.зАДНИЕDataGridViewTextBoxColumn.DataPropertyName = "ЗАДНИЕ";
            this.зАДНИЕDataGridViewTextBoxColumn.HeaderText = "ЗАДНИЕ";
            this.зАДНИЕDataGridViewTextBoxColumn.MaxInputLength = 3;
            this.зАДНИЕDataGridViewTextBoxColumn.Name = "зАДНИЕDataGridViewTextBoxColumn";
            // 
            // pITHONDataSet1BindingSource
            // 
            this.pITHONDataSet1BindingSource.DataSource = this.pITHONDataSet1;
            this.pITHONDataSet1BindingSource.Position = 0;
            // 
            // pITHONDataSet1
            // 
            this.pITHONDataSet1.DataSetName = "PITHONDataSet";
            this.pITHONDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmPROCENT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 333);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPROCENT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проценты";
            this.Load += new System.EventHandler(this.frmPROCENT_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Data.SqlClient.SqlConnection sqlCon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.SqlClient.SqlDataAdapter aPROCENT;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn пОСТАВЩИКDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn лОБОВЫЕDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn бОКОВЫЕDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn зАДНИЕDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pITHONDataSet1BindingSource;
        private PITHONDataSet pITHONDataSet1;
    }
}