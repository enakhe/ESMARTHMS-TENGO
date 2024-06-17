namespace ESMART_HMS.Forms.Rooms
{
    partial class RoomForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adultPerRoomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.childrenPerRoomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rightButtonFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addRoomBtn = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.topFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.totalCountPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtRoomCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.leftFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.roomTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.RoomTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            this.rightButtonFlowPanel.SuspendLayout();
            this.topFlowPanel.SuspendLayout();
            this.totalCountPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRooms
            // 
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
            this.dgvRooms.AllowUserToOrderColumns = true;
            this.dgvRooms.AutoGenerateColumns = false;
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRooms.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.RoomTypeName,
            this.adultPerRoomDataGridViewTextBoxColumn,
            this.childrenPerRoomDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgvRooms.DataSource = this.roomBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRooms.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRooms.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRooms.Location = new System.Drawing.Point(0, 477);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRooms.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRooms.RowHeadersWidth = 51;
            this.dgvRooms.RowTemplate.Height = 24;
            this.dgvRooms.Size = new System.Drawing.Size(1784, 307);
            this.dgvRooms.TabIndex = 5;
            this.dgvRooms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellContentClick);
            this.dgvRooms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RoomId";
            this.dataGridViewTextBoxColumn1.HeaderText = "RoomId";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RoomName";
            this.dataGridViewTextBoxColumn2.HeaderText = "RoomName";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RoomCardNo";
            this.dataGridViewTextBoxColumn3.HeaderText = "RoomCardNo";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RoomLockNo";
            this.dataGridViewTextBoxColumn4.HeaderText = "RoomLockNo";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RoomTypeId";
            this.dataGridViewTextBoxColumn5.HeaderText = "RoomTypeId";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // RoomTypeName
            // 
            this.RoomTypeName.DataPropertyName = "RoomTypeName";
            this.RoomTypeName.HeaderText = "RoomTypeName";
            this.RoomTypeName.MinimumWidth = 6;
            this.RoomTypeName.Name = "RoomTypeName";
            this.RoomTypeName.ReadOnly = true;
            // 
            // adultPerRoomDataGridViewTextBoxColumn
            // 
            this.adultPerRoomDataGridViewTextBoxColumn.DataPropertyName = "AdultPerRoom";
            this.adultPerRoomDataGridViewTextBoxColumn.HeaderText = "AdultPerRoom";
            this.adultPerRoomDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.adultPerRoomDataGridViewTextBoxColumn.Name = "adultPerRoomDataGridViewTextBoxColumn";
            this.adultPerRoomDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // childrenPerRoomDataGridViewTextBoxColumn
            // 
            this.childrenPerRoomDataGridViewTextBoxColumn.DataPropertyName = "ChildrenPerRoom";
            this.childrenPerRoomDataGridViewTextBoxColumn.HeaderText = "ChildrenPerRoom";
            this.childrenPerRoomDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.childrenPerRoomDataGridViewTextBoxColumn.Name = "childrenPerRoomDataGridViewTextBoxColumn";
            this.childrenPerRoomDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Rate";
            this.dataGridViewTextBoxColumn6.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsAvailable";
            this.dataGridViewCheckBoxColumn1.HeaderText = "IsAvailable";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DateCreated";
            this.dataGridViewTextBoxColumn7.HeaderText = "DateCreated";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DateModified";
            this.dataGridViewTextBoxColumn8.HeaderText = "DateModified";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // roomBindingSource1
            // 
            this.roomBindingSource1.DataMember = "Room";
            this.roomBindingSource1.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // eSMART_HMSDBDataSet
            // 
            this.eSMART_HMSDBDataSet.DataSetName = "ESMART_HMSDBDataSet";
            this.eSMART_HMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roomBindingSource
            // 
            this.roomBindingSource.DataMember = "Room";
            // 
            // rightButtonFlowPanel
            // 
            this.rightButtonFlowPanel.BackColor = System.Drawing.Color.White;
            this.rightButtonFlowPanel.Controls.Add(this.addRoomBtn);
            this.rightButtonFlowPanel.Controls.Add(this.btnViewDetails);
            this.rightButtonFlowPanel.Controls.Add(this.btnDelete);
            this.rightButtonFlowPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightButtonFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.rightButtonFlowPanel.Location = new System.Drawing.Point(1507, 0);
            this.rightButtonFlowPanel.Name = "rightButtonFlowPanel";
            this.rightButtonFlowPanel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.rightButtonFlowPanel.Size = new System.Drawing.Size(277, 477);
            this.rightButtonFlowPanel.TabIndex = 13;
            // 
            // addRoomBtn
            // 
            this.addRoomBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addRoomBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.addRoomBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRoomBtn.Location = new System.Drawing.Point(23, 3);
            this.addRoomBtn.Name = "addRoomBtn";
            this.addRoomBtn.Size = new System.Drawing.Size(229, 50);
            this.addRoomBtn.TabIndex = 9;
            this.addRoomBtn.Text = "Add Room";
            this.addRoomBtn.UseVisualStyleBackColor = true;
            this.addRoomBtn.Click += new System.EventHandler(this.addRoomBtn_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnViewDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(23, 59);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(229, 50);
            this.btnViewDetails.TabIndex = 11;
            this.btnViewDetails.Text = "View Room";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(23, 115);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(229, 50);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete Room";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // topFlowPanel
            // 
            this.topFlowPanel.BackColor = System.Drawing.Color.White;
            this.topFlowPanel.Controls.Add(this.totalCountPanel);
            this.topFlowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.topFlowPanel.Name = "topFlowPanel";
            this.topFlowPanel.Size = new System.Drawing.Size(1507, 220);
            this.topFlowPanel.TabIndex = 16;
            // 
            // totalCountPanel
            // 
            this.totalCountPanel.Controls.Add(this.panel3);
            this.totalCountPanel.Controls.Add(this.label1);
            this.totalCountPanel.Location = new System.Drawing.Point(3, 3);
            this.totalCountPanel.Name = "totalCountPanel";
            this.totalCountPanel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.totalCountPanel.Size = new System.Drawing.Size(367, 216);
            this.totalCountPanel.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.txtRoomCount);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(22, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(322, 143);
            this.panel3.TabIndex = 14;
            // 
            // txtRoomCount
            // 
            this.txtRoomCount.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomCount.ForeColor = System.Drawing.Color.White;
            this.txtRoomCount.Location = new System.Drawing.Point(23, 42);
            this.txtRoomCount.Name = "txtRoomCount";
            this.txtRoomCount.Size = new System.Drawing.Size(274, 101);
            this.txtRoomCount.TabIndex = 1;
            this.txtRoomCount.Text = "0";
            this.txtRoomCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Rooms";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(33, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 54);
            this.label1.TabIndex = 13;
            this.label1.Text = "Room";
            // 
            // leftFlowPanel
            // 
            this.leftFlowPanel.BackColor = System.Drawing.Color.White;
            this.leftFlowPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftFlowPanel.Location = new System.Drawing.Point(0, 220);
            this.leftFlowPanel.Name = "leftFlowPanel";
            this.leftFlowPanel.Size = new System.Drawing.Size(370, 257);
            this.leftFlowPanel.TabIndex = 17;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(370, 380);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1137, 97);
            this.flowLayoutPanel4.TabIndex = 18;
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.Black;
            this.searchPanel.Controls.Add(this.textBox1);
            this.searchPanel.Controls.Add(this.label4);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchPanel.Location = new System.Drawing.Point(370, 278);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(1137, 102);
            this.searchPanel.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(842, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 34);
            this.textBox1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(661, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 53);
            this.label4.TabIndex = 0;
            this.label4.Text = "Filter:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(184, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 34);
            this.txtSearch.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 53);
            this.label3.TabIndex = 0;
            this.label3.Text = "Search:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roomTableAdapter
            // 
            this.roomTableAdapter.ClearBeforeFill = true;
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1784, 784);
            this.ControlBox = false;
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.leftFlowPanel);
            this.Controls.Add(this.topFlowPanel);
            this.Controls.Add(this.rightButtonFlowPanel);
            this.Controls.Add(this.dgvRooms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RoomForm";
            this.Text = "RoomsForm";
            this.Load += new System.EventHandler(this.RoomsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            this.rightButtonFlowPanel.ResumeLayout(false);
            this.topFlowPanel.ResumeLayout(false);
            this.totalCountPanel.ResumeLayout(false);
            this.totalCountPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private System.Windows.Forms.FlowLayoutPanel rightButtonFlowPanel;
        private System.Windows.Forms.Button addRoomBtn;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.FlowLayoutPanel topFlowPanel;
        private System.Windows.Forms.Panel totalCountPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtRoomCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel leftFlowPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomCardNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomLockNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAvailableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateModifiedDataGridViewTextBoxColumn;
        private ESMART_HMSDBDataSet eSMART_HMSDBDataSet;
        private System.Windows.Forms.BindingSource roomBindingSource1;
        private ESMART_HMSDBDataSetTableAdapters.RoomTableAdapter roomTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn adultPerRoomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn childrenPerRoomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}