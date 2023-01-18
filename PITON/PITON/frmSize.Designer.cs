namespace PITON
{
     partial class frmSize
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.aFYG = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dsSize1 = new PITON.dsSize();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ddWidth = new System.Windows.Forms.MaskedTextBox();
            this.ddHeight = new System.Windows.Forms.MaskedTextBox();
            this.delta = new System.Windows.Forms.MaskedTextBox();
            this.ddCentr = new System.Windows.Forms.MaskedTextBox();
            this.ddDiago = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSize1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(780, 297);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(686, 297);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSearch_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ширина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "высота";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "допуск";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Brown;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(864, 5);
            this.splitter2.TabIndex = 11;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Brown;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 324);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // splitter4
            // 
            this.splitter4.BackColor = System.Drawing.Color.Brown;
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Enabled = false;
            this.splitter4.Location = new System.Drawing.Point(0, 329);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(864, 5);
            this.splitter4.TabIndex = 13;
            this.splitter4.TabStop = false;
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.Color.Brown;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Enabled = false;
            this.splitter3.Location = new System.Drawing.Point(859, 5);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(5, 324);
            this.splitter3.TabIndex = 14;
            this.splitter3.TabStop = false;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = "Data Source=box21;Initial Catalog=PITHON;Persist Security Info=True;User ID=datex" +
    "ml;Password=56538085";
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // aFYG
            // 
            this.aFYG.SelectCommand = this.sqlCommand1;
            this.aFYG.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SEARCH_BY_SIZE", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CAT", "CAT"),
                        new System.Data.Common.DataColumnMapping("MODEL", "MODEL"),
                        new System.Data.Common.DataColumnMapping("WIDTH", "WIDTH"),
                        new System.Data.Common.DataColumnMapping("HEIGHT", "HEIGHT"),
                        new System.Data.Common.DataColumnMapping("CENTR", "CENTR"),
                        new System.Data.Common.DataColumnMapping("DIAGO", "DIAGO"),
                        new System.Data.Common.DataColumnMapping("FYGCODE", "FYGCODE")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "dbo.SEARCH_BY_SIZE";
            this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand1.Connection = this.sqlConn;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@WIDTH1", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@WIDTH2", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@HEIGHT1", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@HEIGHT2", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@CENTR1", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@CENTR2", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@DIAGO1", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@DIAGO2", System.Data.SqlDbType.Int, 4)});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "центр";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "диагональ";
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "SEARCH_BY_SIZE";
            this.dataGrid1.DataSource = this.dsSize1;
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(5, 5);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 15;
            this.dataGrid1.Size = new System.Drawing.Size(854, 283);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dsSize1
            // 
            this.dsSize1.DataSetName = "dsSize";
            this.dsSize1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "SEARCH_BY_SIZE";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "где";
            this.dataGridTextBoxColumn7.MappingName = "CAT";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 42;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "модель";
            this.dataGridTextBoxColumn1.MappingName = "MODEL";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 350;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "FYG-код";
            this.dataGridTextBoxColumn2.MappingName = "FYGCODE";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "ширина";
            this.dataGridTextBoxColumn3.MappingName = "WIDTH";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "высота";
            this.dataGridTextBoxColumn4.MappingName = "HEIGHT";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 80;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "центр";
            this.dataGridTextBoxColumn5.MappingName = "CENTR";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 80;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "диагональ";
            this.dataGridTextBoxColumn6.MappingName = "DIAGO";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // ddWidth
            // 
            this.ddWidth.Location = new System.Drawing.Point(74, 299);
            this.ddWidth.Mask = "0000";
            this.ddWidth.Name = "ddWidth";
            this.ddWidth.Size = new System.Drawing.Size(54, 20);
            this.ddWidth.TabIndex = 21;
            this.ddWidth.Text = "0";
            this.ddWidth.ValidatingType = typeof(int);
            this.ddWidth.Leave += new System.EventHandler(this.ddWidth_Leave);
            // 
            // ddHeight
            // 
            this.ddHeight.Location = new System.Drawing.Point(197, 299);
            this.ddHeight.Mask = "0000";
            this.ddHeight.Name = "ddHeight";
            this.ddHeight.Size = new System.Drawing.Size(54, 20);
            this.ddHeight.TabIndex = 22;
            this.ddHeight.Text = "0";
            this.ddHeight.ValidatingType = typeof(int);
            this.ddHeight.Leave += new System.EventHandler(this.ddHeight_Leave);
            // 
            // delta
            // 
            this.delta.Location = new System.Drawing.Point(582, 299);
            this.delta.Mask = "0000";
            this.delta.Name = "delta";
            this.delta.Size = new System.Drawing.Size(54, 20);
            this.delta.TabIndex = 23;
            this.delta.Text = "0";
            this.delta.ValidatingType = typeof(int);
            this.delta.Leave += new System.EventHandler(this.delta_Leave);
            // 
            // ddCentr
            // 
            this.ddCentr.Location = new System.Drawing.Point(311, 299);
            this.ddCentr.Mask = "0000";
            this.ddCentr.Name = "ddCentr";
            this.ddCentr.Size = new System.Drawing.Size(54, 20);
            this.ddCentr.TabIndex = 24;
            this.ddCentr.Text = "0";
            this.ddCentr.ValidatingType = typeof(int);
            this.ddCentr.Leave += new System.EventHandler(this.ddCentr_Leave);
            // 
            // ddDiago
            // 
            this.ddDiago.Location = new System.Drawing.Point(455, 299);
            this.ddDiago.Mask = "0000";
            this.ddDiago.Name = "ddDiago";
            this.ddDiago.Size = new System.Drawing.Size(54, 20);
            this.ddDiago.TabIndex = 25;
            this.ddDiago.Text = "0";
            this.ddDiago.ValidatingType = typeof(int);
            this.ddDiago.Leave += new System.EventHandler(this.ddDiago_Leave);
            // 
            // frmSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 334);
            this.Controls.Add(this.ddDiago);
            this.Controls.Add(this.ddCentr);
            this.Controls.Add(this.delta);
            this.Controls.Add(this.ddHeight);
            this.Controls.Add(this.ddWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.splitter4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(200, 25);
            this.Name = "frmSize";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSize";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSize1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Splitter splitter3;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlDataAdapter aFYG;
        private dsSize dsSize1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.MaskedTextBox ddWidth;
        private System.Windows.Forms.MaskedTextBox ddHeight;
        private System.Windows.Forms.MaskedTextBox delta;
        private System.Windows.Forms.MaskedTextBox ddCentr;
        private System.Windows.Forms.MaskedTextBox ddDiago;
    }
}