namespace PITON
{
    partial class frmCOLORS
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
            this.btnClose = new System.Windows.Forms.Button();
            this.sqlCon = new System.Data.SqlClient.SqlConnection();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.aCOLORS = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.grdCOLORS = new System.Windows.Forms.DataGridView();
            this.iDCOLORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pITHONDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pITHONDataSet = new PITON.PITHONDataSet();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCOLORS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 403);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 47);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(321, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Ok";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // sqlCon
            // 
            this.sqlCon.ConnectionString = "Data Source=.;Initial Catalog=PITHON;User ID=sa;Password=onc15454*";
            this.sqlCon.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT        ID_COLOR, COLOR\r\nFROM            COLORS";
            this.sqlSelectCommand1.Connection = this.sqlCon;
            // 
            // aCOLORS
            // 
            this.aCOLORS.DeleteCommand = this.sqlDeleteCommand1;
            this.aCOLORS.InsertCommand = this.sqlInsertCommand1;
            this.aCOLORS.SelectCommand = this.sqlSelectCommand1;
            this.aCOLORS.UpdateCommand = this.sqlCommand1;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "UPDATE       COLORS\r\nSET                COLOR = @COLOR\r\nWHERE        (COLOR = @ID" +
    "_COLOR)";
            this.sqlCommand1.Connection = this.sqlCon;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@COLOR", System.Data.SqlDbType.NVarChar, 50, "COLOR"),
            new System.Data.SqlClient.SqlParameter("@ID_COLOR", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "COLOR", System.Data.DataRowVersion.Original, null)});
            // 
            // grdCOLORS
            // 
            this.grdCOLORS.AllowUserToAddRows = false;
            this.grdCOLORS.AutoGenerateColumns = false;
            this.grdCOLORS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCOLORS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCOLORDataGridViewTextBoxColumn,
            this.cOLORDataGridViewTextBoxColumn});
            this.grdCOLORS.DataMember = "COLORS";
            this.grdCOLORS.DataSource = this.pITHONDataSetBindingSource;
            this.grdCOLORS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCOLORS.Location = new System.Drawing.Point(0, 0);
            this.grdCOLORS.Name = "grdCOLORS";
            this.grdCOLORS.Size = new System.Drawing.Size(442, 403);
            this.grdCOLORS.TabIndex = 1;
            // 
            // iDCOLORDataGridViewTextBoxColumn
            // 
            this.iDCOLORDataGridViewTextBoxColumn.DataPropertyName = "ID_COLOR";
            this.iDCOLORDataGridViewTextBoxColumn.HeaderText = "обозначение";
            this.iDCOLORDataGridViewTextBoxColumn.Name = "iDCOLORDataGridViewTextBoxColumn";
            this.iDCOLORDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCOLORDataGridViewTextBoxColumn.Width = 50;
            // 
            // cOLORDataGridViewTextBoxColumn
            // 
            this.cOLORDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cOLORDataGridViewTextBoxColumn.DataPropertyName = "COLOR";
            this.cOLORDataGridViewTextBoxColumn.HeaderText = "цвет стекла";
            this.cOLORDataGridViewTextBoxColumn.Name = "cOLORDataGridViewTextBoxColumn";
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
            // frmCOLORS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 450);
            this.ControlBox = false;
            this.Controls.Add(this.grdCOLORS);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCOLORS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Цвета стекла";
            this.Load += new System.EventHandler(this.frmCOLORS_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCOLORS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pITHONDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Data.SqlClient.SqlConnection sqlCon;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlDataAdapter aCOLORS;
        private System.Windows.Forms.DataGridView grdCOLORS;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource pITHONDataSetBindingSource;
        private PITHONDataSet pITHONDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCOLORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLORDataGridViewTextBoxColumn;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
    }
}