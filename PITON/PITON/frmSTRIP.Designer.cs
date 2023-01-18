namespace PITON
{
    partial class frmSTRIP
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDSTRIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTRIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pITHONDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pITHONDataSet = new PITON.PITHONDataSet();
            this.aSTRIP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCon = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 307);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 33);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDSTRIPDataGridViewTextBoxColumn,
            this.sTRIPDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "STRIP";
            this.dataGridView1.DataSource = this.pITHONDataSetBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(427, 307);
            this.dataGridView1.TabIndex = 2;
            // 
            // iDSTRIPDataGridViewTextBoxColumn
            // 
            this.iDSTRIPDataGridViewTextBoxColumn.DataPropertyName = "ID_STRIP";
            this.iDSTRIPDataGridViewTextBoxColumn.HeaderText = "ID_STRIP";
            this.iDSTRIPDataGridViewTextBoxColumn.Name = "iDSTRIPDataGridViewTextBoxColumn";
            this.iDSTRIPDataGridViewTextBoxColumn.Width = 70;
            // 
            // sTRIPDataGridViewTextBoxColumn
            // 
            this.sTRIPDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sTRIPDataGridViewTextBoxColumn.DataPropertyName = "STRIP";
            this.sTRIPDataGridViewTextBoxColumn.HeaderText = "STRIP";
            this.sTRIPDataGridViewTextBoxColumn.Name = "sTRIPDataGridViewTextBoxColumn";
            // 
            // pITHONDataSetBindingSource
            // 
            this.pITHONDataSetBindingSource.DataSource = this.pITHONDataSet;
            this.pITHONDataSetBindingSource.Position = 0;
            // 
            // pITHONDataSet
            // 
            this.pITHONDataSet.DataSetName = "PITHONDataSet";
            this.pITHONDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aSTRIP
            // 
            this.aSTRIP.DeleteCommand = this.sqlDeleteCommand1;
            this.aSTRIP.InsertCommand = this.sqlInsertCommand1;
            this.aSTRIP.SelectCommand = this.sqlSelectCommand1;
            this.aSTRIP.UpdateCommand = this.sqlCommand1;
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM STRIP\r\nWHERE        (ID_STRIP = @ID_STRIP)";
            this.sqlDeleteCommand1.Connection = this.sqlCon;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_STRIP", System.Data.SqlDbType.NChar, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_STRIP", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCon
            // 
            this.sqlCon.ConnectionString = "Data Source=.;Initial Catalog=PITHON;User ID=sa;Password=onc15454*";
            this.sqlCon.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = "INSERT INTO STRIP\r\n                         (ID_STRIP, STRIP)\r\nVALUES        (@ID" +
    "_STRIP,@STRIP)";
            this.sqlInsertCommand1.Connection = this.sqlCon;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_STRIP", System.Data.SqlDbType.NChar, 2, "ID_STRIP"),
            new System.Data.SqlClient.SqlParameter("@STRIP", System.Data.SqlDbType.NVarChar, 50, "STRIP")});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT        ID_STRIP, STRIP\r\nFROM            STRIP";
            this.sqlSelectCommand1.Connection = this.sqlCon;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "UPDATE       STRIP\r\nSET                STRIP = @STRIP\r\nWHERE        (ID_STRIP = @" +
    "ID_STRIP)";
            this.sqlCommand1.Connection = this.sqlCon;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@STRIP", System.Data.SqlDbType.NVarChar, 50, "STRIP"),
            new System.Data.SqlClient.SqlParameter("@ID_STRIP", System.Data.SqlDbType.NChar, 2, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_STRIP", System.Data.DataRowVersion.Original, null)});
            // 
            // frmSTRIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 340);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSTRIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Цвет полосы светофильтра";
            this.Load += new System.EventHandler(this.frmSTRIP_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource pITHONDataSetBindingSource;
        private PITHONDataSet pITHONDataSet;
        private System.Windows.Forms.Button button1;
        private System.Data.SqlClient.SqlDataAdapter aSTRIP;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlConnection sqlCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDSTRIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTRIPDataGridViewTextBoxColumn;
    }
}