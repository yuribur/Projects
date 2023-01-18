namespace PITON
{
    partial class frmLOCATION
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
            this.Ok = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDLOCATIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOCATIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pITHONDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pITHONDataSet = new PITON.PITHONDataSet();
            this.sqlCon = new System.Data.SqlClient.SqlConnection();
            this.aLOCATION = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 33);
            this.panel1.TabIndex = 0;
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(356, 4);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 0;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDLOCATIONDataGridViewTextBoxColumn,
            this.lOCATIONDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "LOCATION";
            this.dataGridView1.DataSource = this.pITHONDataSetBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(499, 417);
            this.dataGridView1.TabIndex = 1;
            // 
            // iDLOCATIONDataGridViewTextBoxColumn
            // 
            this.iDLOCATIONDataGridViewTextBoxColumn.DataPropertyName = "ID_LOCATION";
            this.iDLOCATIONDataGridViewTextBoxColumn.HeaderText = "иднтификатор";
            this.iDLOCATIONDataGridViewTextBoxColumn.Name = "iDLOCATIONDataGridViewTextBoxColumn";
            this.iDLOCATIONDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lOCATIONDataGridViewTextBoxColumn
            // 
            this.lOCATIONDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lOCATIONDataGridViewTextBoxColumn.DataPropertyName = "LOCATION";
            this.lOCATIONDataGridViewTextBoxColumn.HeaderText = "положение";
            this.lOCATIONDataGridViewTextBoxColumn.Name = "lOCATIONDataGridViewTextBoxColumn";
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
            // sqlCon
            // 
            this.sqlCon.ConnectionString = "Data Source=.;Initial Catalog=PITHON;User ID=sa;Password=onc15454*";
            this.sqlCon.FireInfoMessageEventOnUserErrors = false;
            // 
            // aLOCATION
            // 
            this.aLOCATION.DeleteCommand = this.sqlCommand1;
            this.aLOCATION.InsertCommand = this.sqlCommand2;
            this.aLOCATION.SelectCommand = this.sqlCommand3;
            this.aLOCATION.UpdateCommand = this.sqlCommand4;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "DELETE FROM LOCATION\r\nWHERE        (ID_LOCATION = @ID_LOCATION)";
            this.sqlCommand1.Connection = this.sqlCon;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_LOCATION", System.Data.SqlDbType.NChar, 3, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_LOCATION", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = "INSERT INTO STRIP\r\n                         (ID_STRIP, STRIP)\r\nVALUES        (@ID" +
    "_STRIP,@STRIP)";
            this.sqlCommand2.Connection = this.sqlCon;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_STRIP", System.Data.SqlDbType.NChar, 2, "ID_STRIP"),
            new System.Data.SqlClient.SqlParameter("@STRIP", System.Data.SqlDbType.NVarChar, 50, "STRIP")});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = "SELECT        ID_LOCATION, LOCATION\r\nFROM            LOCATION";
            this.sqlCommand3.Connection = this.sqlCon;
            // 
            // sqlCommand4
            // 
            this.sqlCommand4.CommandText = "UPDATE       LOCATION\r\nSET                LOCATION = @LOCATION\r\nWHERE        (ID_" +
    "LOCATION = @ID_LOCATION)";
            this.sqlCommand4.Connection = this.sqlCon;
            this.sqlCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@LOCATION", System.Data.SqlDbType.NVarChar, 60, "LOCATION"),
            new System.Data.SqlClient.SqlParameter("@ID_LOCATION", System.Data.SqlDbType.NChar, 3, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_LOCATION", System.Data.DataRowVersion.Original, null)});
            // 
            // frmLOCATION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLOCATION";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Положения стекол";
            this.Load += new System.EventHandler(this.frmLOCATION_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn iDLOCATIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOCATIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button Ok;
        private System.Data.SqlClient.SqlConnection sqlCon;
        private System.Data.SqlClient.SqlDataAdapter aLOCATION;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        private System.Data.SqlClient.SqlCommand sqlCommand3;
        private System.Data.SqlClient.SqlCommand sqlCommand4;
    }
}