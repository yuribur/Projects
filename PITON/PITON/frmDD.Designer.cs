namespace PITON
{
    partial class frmDD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Cons = new System.Data.SqlClient.SqlConnection();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lb_id_sensor = new System.Windows.Forms.Label();
            this.dsSensor1 = new PITON.dsSensor1();
            this.grdReal = new System.Windows.Forms.DataGridView();
            this.iDSENSORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_id_sensor = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.photoBox = new System.Windows.Forms.PictureBox();
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.grdAll = new System.Windows.Forms.DataGridView();
            this.iDSensorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.M1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Y2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.M2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.selSensor1 = new System.Data.SqlClient.SqlCommand();
            this.aSensor1 = new System.Data.SqlClient.SqlDataAdapter();
            this.cmdDropFromModel = new System.Data.SqlClient.SqlCommand();
            this.cmdInsert = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.cmddInsert = new System.Data.SqlClient.SqlCommand();
            this.aSensory = new System.Data.SqlClient.SqlDataAdapter();
            this.cmdDelete = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.btnClose = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSensor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAll)).BeginInit();
            this.SuspendLayout();
            // 
            // Cons
            // 
            this.Cons.ConnectionString = "Data Source=box21;Initial Catalog=PITHON;Persist Security Info=True;User ID=sa;Pa" +
    "ssword=onc15454*";
            this.Cons.FireInfoMessageEventOnUserErrors = false;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(134, 468);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(156, 25);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Исключить из модели";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRemove_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(750, 540);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.btClose);
            this.tabPage1.Controls.Add(this.lb_id_sensor);
            this.tabPage1.Controls.Add(this.grdReal);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.btnRemove);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(742, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Датчики модели";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lb_id_sensor
            // 
            this.lb_id_sensor.AutoSize = true;
            this.lb_id_sensor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsSensor1, "FromSensors.ID_SENSOR", true));
            this.lb_id_sensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_id_sensor.Location = new System.Drawing.Point(23, 472);
            this.lb_id_sensor.Name = "lb_id_sensor";
            this.lb_id_sensor.Size = new System.Drawing.Size(60, 17);
            this.lb_id_sensor.TabIndex = 4;
            this.lb_id_sensor.Text = "сенсор";
            // 
            // dsSensor1
            // 
            this.dsSensor1.DataSetName = "dsSensor1";
            this.dsSensor1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grdReal
            // 
            this.grdReal.AllowUserToAddRows = false;
            this.grdReal.AllowUserToResizeColumns = false;
            this.grdReal.AllowUserToResizeRows = false;
            this.grdReal.AutoGenerateColumns = false;
            this.grdReal.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdReal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdReal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReal.ColumnHeadersVisible = false;
            this.grdReal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDSENSORDataGridViewTextBoxColumn});
            this.grdReal.DataMember = "FromSensors";
            this.grdReal.DataSource = this.dsSensor1;
            this.grdReal.Location = new System.Drawing.Point(435, 1);
            this.grdReal.Name = "grdReal";
            this.grdReal.ReadOnly = true;
            this.grdReal.RowHeadersVisible = false;
            this.grdReal.Size = new System.Drawing.Size(120, 499);
            this.grdReal.TabIndex = 2;
            // 
            // iDSENSORDataGridViewTextBoxColumn
            // 
            this.iDSENSORDataGridViewTextBoxColumn.DataPropertyName = "ID_SENSOR";
            this.iDSENSORDataGridViewTextBoxColumn.HeaderText = "ID_SENSOR";
            this.iDSENSORDataGridViewTextBoxColumn.Name = "iDSENSORDataGridViewTextBoxColumn";
            this.iDSENSORDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.dsSensor1, "FromSensors.SensorPhoto", true));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.btnClose);
            this.tabPage2.Controls.Add(this.lbl_id_sensor);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.photoBox);
            this.tabPage2.Controls.Add(this.btnDrop);
            this.tabPage2.Controls.Add(this.btnNew);
            this.tabPage2.Controls.Add(this.grdAll);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(742, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Все датчики";
            // 
            // lbl_id_sensor
            // 
            this.lbl_id_sensor.AutoSize = true;
            this.lbl_id_sensor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsSensor1, "SENSOR.ID_Sensor", true));
            this.lbl_id_sensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_id_sensor.Location = new System.Drawing.Point(5, 475);
            this.lbl_id_sensor.Name = "lbl_id_sensor";
            this.lbl_id_sensor.Size = new System.Drawing.Size(52, 17);
            this.lbl_id_sensor.TabIndex = 11;
            this.lbl_id_sensor.Text = "label1";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(101, 467);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(123, 25);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Добавить к модели";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAdd_MouseUp);
            // 
            // photoBox
            // 
            this.photoBox.BackColor = System.Drawing.SystemColors.Control;
            this.photoBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.photoBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.dsSensor1, "SENSOR.SensorPhoto", true));
            this.photoBox.ImageLocation = "";
            this.photoBox.Location = new System.Drawing.Point(0, 0);
            this.photoBox.Name = "photoBox";
            this.photoBox.Size = new System.Drawing.Size(400, 450);
            this.photoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox.TabIndex = 6;
            this.photoBox.TabStop = false;
            // 
            // btnDrop
            // 
            this.btnDrop.Location = new System.Drawing.Point(244, 467);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(123, 25);
            this.btnDrop.TabIndex = 5;
            this.btnDrop.Text = "Удалить";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDrop_MouseUp);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(388, 467);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 25);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "Новый сенсор";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnNew_MouseUp);
            // 
            // grdAll
            // 
            this.grdAll.AllowUserToAddRows = false;
            this.grdAll.AllowUserToDeleteRows = false;
            this.grdAll.AllowUserToResizeRows = false;
            this.grdAll.AutoGenerateColumns = false;
            this.grdAll.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdAll.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAll.ColumnHeadersVisible = false;
            this.grdAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDSensorDataGridViewTextBoxColumn1,
            this.Y1,
            this.M1,
            this.Y2,
            this.M2});
            this.grdAll.DataMember = "SENSOR";
            this.grdAll.DataSource = this.dsSensor1;
            this.grdAll.Location = new System.Drawing.Point(410, 1);
            this.grdAll.MultiSelect = false;
            this.grdAll.Name = "grdAll";
            this.grdAll.RowHeadersVisible = false;
            this.grdAll.Size = new System.Drawing.Size(322, 449);
            this.grdAll.TabIndex = 10;
            // 
            // iDSensorDataGridViewTextBoxColumn1
            // 
            this.iDSensorDataGridViewTextBoxColumn1.DataPropertyName = "ID_Sensor";
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.iDSensorDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle46;
            this.iDSensorDataGridViewTextBoxColumn1.HeaderText = "ID_Sensor";
            this.iDSensorDataGridViewTextBoxColumn1.Name = "iDSensorDataGridViewTextBoxColumn1";
            this.iDSensorDataGridViewTextBoxColumn1.Width = 80;
            // 
            // Y1
            // 
            this.Y1.DataPropertyName = "Y1";
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Y1.DefaultCellStyle = dataGridViewCellStyle47;
            this.Y1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Y1.HeaderText = "Y1";
            this.Y1.Items.AddRange(new object[] {
            "....",
            "1970",
            "1971",
            "1972",
            "1973",
            "1974",
            "1975",
            "1976",
            "1977",
            "1978",
            "1979",
            "1980",
            "1981",
            "1982",
            "1983",
            "1984",
            "1985",
            "1986",
            "1987",
            "1988",
            "1989",
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010"});
            this.Y1.Name = "Y1";
            this.Y1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Y1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Y1.Width = 50;
            // 
            // M1
            // 
            this.M1.DataPropertyName = "M1";
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.M1.DefaultCellStyle = dataGridViewCellStyle48;
            this.M1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.M1.HeaderText = "M1";
            this.M1.Items.AddRange(new object[] {
            "..",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.M1.Name = "M1";
            this.M1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.M1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.M1.Width = 40;
            // 
            // Y2
            // 
            this.Y2.DataPropertyName = "Y2";
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Y2.DefaultCellStyle = dataGridViewCellStyle49;
            this.Y2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Y2.HeaderText = "Y2";
            this.Y2.Items.AddRange(new object[] {
            "....",
            "1970",
            "1971",
            "1972",
            "1973",
            "1974",
            "1975",
            "1976",
            "1977",
            "1978",
            "1979",
            "1980",
            "1981",
            "1982",
            "1983",
            "1984",
            "1985",
            "1986",
            "1987",
            "1988",
            "1989",
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010"});
            this.Y2.Name = "Y2";
            this.Y2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Y2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Y2.Width = 50;
            // 
            // M2
            // 
            this.M2.DataPropertyName = "M2";
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.M2.DefaultCellStyle = dataGridViewCellStyle50;
            this.M2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.M2.HeaderText = "M2";
            this.M2.Items.AddRange(new object[] {
            "..",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.M2.Name = "M2";
            this.M2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.M2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.M2.Width = 40;
            // 
            // selSensor1
            // 
            this.selSensor1.CommandText = "dbo.FromSensors";
            this.selSensor1.CommandType = System.Data.CommandType.StoredProcedure;
            this.selSensor1.Connection = this.Cons;
            this.selSensor1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@ID_MEMO", System.Data.SqlDbType.Int, 4)});
            // 
            // aSensor1
            // 
            this.aSensor1.DeleteCommand = this.cmdDropFromModel;
            this.aSensor1.InsertCommand = this.cmdInsert;
            this.aSensor1.SelectCommand = this.selSensor1;
            this.aSensor1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "FromSensors", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID_SENSOR", "ID_SENSOR"),
                        new System.Data.Common.DataColumnMapping("SensorPhoto", "SensorPhoto")})});
            // 
            // cmdDropFromModel
            // 
            this.cmdDropFromModel.CommandText = "DeleteSensorFromModel";
            this.cmdDropFromModel.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmdDropFromModel.Connection = this.Cons;
            this.cmdDropFromModel.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_MEMO", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@ID_SENSOR", System.Data.SqlDbType.VarChar)});
            // 
            // cmdInsert
            // 
            this.cmdInsert.CommandText = "updSensor1";
            this.cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmdInsert.Connection = this.Cons;
            this.cmdInsert.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_MEMO", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@ID_SENSOR", System.Data.SqlDbType.VarChar, 20)});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT        ID_Sensor, SensorPhoto, Y1, M1, Y2, M2\r\nFROM            SENSOR\r\nWHE" +
    "RE        (ID_Sensor <> \'...\')\r\nORDER BY ID_Sensor";
            this.sqlSelectCommand1.Connection = this.Cons;
            // 
            // cmddInsert
            // 
            this.cmddInsert.CommandText = "updSensor";
            this.cmddInsert.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmddInsert.Connection = this.Cons;
            this.cmddInsert.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_SENSOR", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@PHOTO", System.Data.SqlDbType.Image)});
            // 
            // aSensory
            // 
            this.aSensory.DeleteCommand = this.cmdDelete;
            this.aSensory.InsertCommand = this.cmddInsert;
            this.aSensory.SelectCommand = this.sqlSelectCommand1;
            this.aSensory.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SENSOR", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID_Sensor", "ID_Sensor"),
                        new System.Data.Common.DataColumnMapping("SensorPhoto", "SensorPhoto")})});
            this.aSensory.UpdateCommand = this.sqlCommand1;
            this.aSensory.RowUpdated += new System.Data.SqlClient.SqlRowUpdatedEventHandler(this.aSensory_RowUpdated);
            // 
            // cmdDelete
            // 
            this.cmdDelete.CommandText = "DELETE FROM SENSOR   WHERE     (ID_Sensor = @ID_SENSOR)";
            this.cmdDelete.Connection = this.Cons;
            this.cmdDelete.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_SENSOR", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Sensor", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "UPDATE    SENSOR\r\nSET              Y1 = @Y1, M1 = @M1, Y2 = @Y2, M2 = @M2\r\nWHERE " +
    "    (ID_Sensor = @ID_Sensor)";
            this.sqlCommand1.Connection = this.Cons;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Y1", System.Data.SqlDbType.Char, 4, "Y1"),
            new System.Data.SqlClient.SqlParameter("@M1", System.Data.SqlDbType.Char, 2, "M1"),
            new System.Data.SqlClient.SqlParameter("@Y2", System.Data.SqlDbType.Char, 4, "Y2"),
            new System.Data.SqlClient.SqlParameter("@M2", System.Data.SqlDbType.Char, 2, "M2"),
            new System.Data.SqlClient.SqlParameter("@ID_Sensor", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Sensor", System.Data.DataRowVersion.Original, null)});
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(523, 467);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 25);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(302, 468);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(112, 25);
            this.btClose.TabIndex = 13;
            this.btClose.Text = "Закрыть";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btClose_MouseUp);
            // 
            // frmDD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(764, 541);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDD";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Датчики дождя";
            this.Activated += new System.EventHandler(this.frmDD_Activated);
            this.Deactivate += new System.EventHandler(this.frmDD_Deactivate);
            this.Load += new System.EventHandler(this.frmDD_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSensor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.SqlClient.SqlConnection Cons;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView grdReal;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.PictureBox photoBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView grdAll;
        private System.Data.SqlClient.SqlCommand selSensor1;
        private System.Data.SqlClient.SqlDataAdapter aSensor1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand cmddInsert;
        private System.Data.SqlClient.SqlDataAdapter aSensory;
        private dsSensor1 dsSensor1;
        private System.Data.SqlClient.SqlCommand cmdDelete;
        private System.Data.SqlClient.SqlCommand cmdInsert;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDSENSORDataGridViewTextBoxColumn;
        private System.Data.SqlClient.SqlCommand cmdDropFromModel;
        private System.Windows.Forms.Label lb_id_sensor;
        private System.Windows.Forms.Label lbl_id_sensor;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDSensorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Y1;
        private System.Windows.Forms.DataGridViewComboBoxColumn M1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Y2;
        private System.Windows.Forms.DataGridViewComboBoxColumn M2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btClose;
    }
}