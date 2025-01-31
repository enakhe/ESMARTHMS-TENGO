﻿namespace ESMART_HMS.Presentation.Forms.Report
{
    partial class ReservationReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bookingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.bookingTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.bookingTableAdapter();
            this.roomTypeTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.RoomTypeTableAdapter();
            this.roomTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.RoomTableAdapter();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnExport = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.ComboBox();
            this.roomTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvReservation = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReservationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestPhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkInDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkOutDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateModifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reservationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reservationTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.ReservationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bookingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomTypeBindingSource)).BeginInit();
            this.mainFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bookingBindingSource
            // 
            this.bookingBindingSource.DataMember = "booking";
            this.bookingBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // eSMART_HMSDBDataSet
            // 
            this.eSMART_HMSDBDataSet.DataSetName = "ESMART_HMSDBDataSet";
            this.eSMART_HMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookingTableAdapter
            // 
            this.bookingTableAdapter.ClearBeforeFill = true;
            // 
            // roomTypeTableAdapter
            // 
            this.roomTypeTableAdapter.ClearBeforeFill = true;
            // 
            // roomTableAdapter
            // 
            this.roomTableAdapter.ClearBeforeFill = true;
            // 
            // roomBindingSource
            // 
            this.roomBindingSource.DataMember = "Room";
            this.roomBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // btnExport
            // 
            this.btnExport.AutoSize = true;
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(89, 23);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 38);
            this.btnExport.TabIndex = 26;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnExport);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(235, 81);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.FormattingEnabled = true;
            this.txtStatus.Items.AddRange(new object[] {
            "All",
            "Paid",
            "Balance"});
            this.txtStatus.Location = new System.Drawing.Point(104, 23);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(230, 31);
            this.txtStatus.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(387, 27);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 23);
            this.label15.TabIndex = 23;
            this.label15.Text = "Type:";
            // 
            // txtType
            // 
            this.txtType.DataSource = this.roomTypeBindingSource;
            this.txtType.DisplayMember = "Title";
            this.txtType.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtType.FormattingEnabled = true;
            this.txtType.Location = new System.Drawing.Point(446, 23);
            this.txtType.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(230, 31);
            this.txtType.TabIndex = 25;
            this.txtType.ValueMember = "Id";
            // 
            // roomTypeBindingSource
            // 
            this.roomTypeBindingSource.DataMember = "RoomType";
            this.roomTypeBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // mainFlowLayoutPanel
            // 
            this.mainFlowLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainFlowLayoutPanel.Controls.Add(this.label7);
            this.mainFlowLayoutPanel.Controls.Add(this.txtStatus);
            this.mainFlowLayoutPanel.Controls.Add(this.label15);
            this.mainFlowLayoutPanel.Controls.Add(this.txtType);
            this.mainFlowLayoutPanel.Controls.Add(this.label1);
            this.mainFlowLayoutPanel.Controls.Add(this.txtFrom);
            this.mainFlowLayoutPanel.Controls.Add(this.label2);
            this.mainFlowLayoutPanel.Controls.Add(this.txtTo);
            this.mainFlowLayoutPanel.Controls.Add(this.btnQuery);
            this.mainFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainFlowLayoutPanel.Name = "mainFlowLayoutPanel";
            this.mainFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.mainFlowLayoutPanel.Size = new System.Drawing.Size(1520, 81);
            this.mainFlowLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(729, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "From:";
            // 
            // txtFrom
            // 
            this.txtFrom.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(792, 23);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(230, 30);
            this.txtFrom.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1075, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "To:";
            // 
            // txtTo
            // 
            this.txtTo.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(1114, 23);
            this.txtTo.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(230, 30);
            this.txtTo.TabIndex = 28;
            // 
            // btnQuery
            // 
            this.btnQuery.AutoSize = true;
            this.btnQuery.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuery.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.Location = new System.Drawing.Point(1397, 23);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(111, 38);
            this.btnQuery.TabIndex = 26;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.mainFlowLayoutPanel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(1759, 81);
            this.splitContainer2.SplitterDistance = 1520;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(30, 30);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainer1.Size = new System.Drawing.Size(1759, 786);
            this.splitContainer1.SplitterDistance = 81;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvReservation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1719, 661);
            this.panel2.TabIndex = 0;
            // 
            // dgvReservation
            // 
            this.dgvReservation.AllowUserToAddRows = false;
            this.dgvReservation.AllowUserToDeleteRows = false;
            this.dgvReservation.AutoGenerateColumns = false;
            this.dgvReservation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservation.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.GuestId,
            this.roomIdDataGridViewTextBoxColumn,
            this.ReservationId,
            this.customerDataGridViewTextBoxColumn,
            this.GuestPhoneNo,
            this.roomDataGridViewTextBoxColumn,
            this.checkInDateDataGridViewTextBoxColumn,
            this.checkOutDateDataGridViewTextBoxColumn,
            this.paymentMethodDataGridViewTextBoxColumn,
            this.Amount,
            this.AmountPaid,
            this.Balance,
            this.CreatedBy,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.dateModifiedDataGridViewTextBoxColumn});
            this.dgvReservation.DataSource = this.reservationBindingSource;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReservation.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvReservation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservation.GridColor = System.Drawing.Color.Black;
            this.dgvReservation.Location = new System.Drawing.Point(0, 0);
            this.dgvReservation.Margin = new System.Windows.Forms.Padding(2);
            this.dgvReservation.Name = "dgvReservation";
            this.dgvReservation.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservation.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvReservation.RowHeadersWidth = 51;
            this.dgvReservation.RowTemplate.Height = 24;
            this.dgvReservation.Size = new System.Drawing.Size(1717, 659);
            this.dgvReservation.TabIndex = 2;
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
            // GuestId
            // 
            this.GuestId.DataPropertyName = "GuestId";
            this.GuestId.HeaderText = "Guest Id";
            this.GuestId.Name = "GuestId";
            this.GuestId.ReadOnly = true;
            this.GuestId.Visible = false;
            // 
            // roomIdDataGridViewTextBoxColumn
            // 
            this.roomIdDataGridViewTextBoxColumn.DataPropertyName = "RoomId";
            this.roomIdDataGridViewTextBoxColumn.HeaderText = "Room Id";
            this.roomIdDataGridViewTextBoxColumn.Name = "roomIdDataGridViewTextBoxColumn";
            this.roomIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.roomIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // ReservationId
            // 
            this.ReservationId.DataPropertyName = "ReservationId";
            this.ReservationId.HeaderText = "Id";
            this.ReservationId.Name = "ReservationId";
            this.ReservationId.ReadOnly = true;
            this.ReservationId.Visible = false;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "Guest";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.customerDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.customerDataGridViewTextBoxColumn.HeaderText = "Guest";
            this.customerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // GuestPhoneNo
            // 
            this.GuestPhoneNo.DataPropertyName = "GuestPhoneNo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.GuestPhoneNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.GuestPhoneNo.HeaderText = "Phone No";
            this.GuestPhoneNo.MinimumWidth = 6;
            this.GuestPhoneNo.Name = "GuestPhoneNo";
            this.GuestPhoneNo.ReadOnly = true;
            // 
            // roomDataGridViewTextBoxColumn
            // 
            this.roomDataGridViewTextBoxColumn.DataPropertyName = "Room";
            this.roomDataGridViewTextBoxColumn.HeaderText = "Room";
            this.roomDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.roomDataGridViewTextBoxColumn.Name = "roomDataGridViewTextBoxColumn";
            this.roomDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkInDateDataGridViewTextBoxColumn
            // 
            this.checkInDateDataGridViewTextBoxColumn.DataPropertyName = "CheckInDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.checkInDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.checkInDateDataGridViewTextBoxColumn.HeaderText = "Check In";
            this.checkInDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.checkInDateDataGridViewTextBoxColumn.Name = "checkInDateDataGridViewTextBoxColumn";
            this.checkInDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkOutDateDataGridViewTextBoxColumn
            // 
            this.checkOutDateDataGridViewTextBoxColumn.DataPropertyName = "CheckOutDate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.checkOutDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.checkOutDateDataGridViewTextBoxColumn.HeaderText = "Check Out";
            this.checkOutDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.checkOutDateDataGridViewTextBoxColumn.Name = "checkOutDateDataGridViewTextBoxColumn";
            this.checkOutDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paymentMethodDataGridViewTextBoxColumn
            // 
            this.paymentMethodDataGridViewTextBoxColumn.DataPropertyName = "PaymentMethod";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.paymentMethodDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.paymentMethodDataGridViewTextBoxColumn.HeaderText = "Payment Method";
            this.paymentMethodDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.paymentMethodDataGridViewTextBoxColumn.Name = "paymentMethodDataGridViewTextBoxColumn";
            this.paymentMethodDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle7;
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // AmountPaid
            // 
            this.AmountPaid.DataPropertyName = "AmountPaid";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AmountPaid.DefaultCellStyle = dataGridViewCellStyle8;
            this.AmountPaid.HeaderText = "Paid";
            this.AmountPaid.MinimumWidth = 6;
            this.AmountPaid.Name = "AmountPaid";
            this.AmountPaid.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle9;
            this.Balance.HeaderText = "Balance";
            this.Balance.MinimumWidth = 6;
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CreatedBy.DefaultCellStyle = dataGridViewCellStyle10;
            this.CreatedBy.HeaderText = "Reserved By";
            this.CreatedBy.MinimumWidth = 6;
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dateCreatedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Date Reserved";
            this.dateCreatedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateModifiedDataGridViewTextBoxColumn
            // 
            this.dateModifiedDataGridViewTextBoxColumn.DataPropertyName = "DateModified";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dateModifiedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.dateModifiedDataGridViewTextBoxColumn.HeaderText = "Date Modified";
            this.dateModifiedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateModifiedDataGridViewTextBoxColumn.Name = "dateModifiedDataGridViewTextBoxColumn";
            this.dateModifiedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // reservationBindingSource
            // 
            this.reservationBindingSource.DataMember = "Reservation";
            this.reservationBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // reservationTableAdapter
            // 
            this.reservationTableAdapter.ClearBeforeFill = true;
            // 
            // ReservationReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(55)))), ((int)(((byte)(134)))));
            this.ClientSize = new System.Drawing.Size(1819, 846);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReservationReportForm";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Text = "Reservation Report";
            this.Load += new System.EventHandler(this.ReservationReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomTypeBindingSource)).EndInit();
            this.mainFlowLayoutPanel.ResumeLayout(false);
            this.mainFlowLayoutPanel.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bookingBindingSource;
        private ESMART_HMSDBDataSet eSMART_HMSDBDataSet;
        private ESMART_HMSDBDataSetTableAdapters.bookingTableAdapter bookingTableAdapter;
        private ESMART_HMSDBDataSetTableAdapters.RoomTypeTableAdapter roomTypeTableAdapter;
        private ESMART_HMSDBDataSetTableAdapters.RoomTableAdapter roomTableAdapter;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox txtStatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox txtType;
        private System.Windows.Forms.BindingSource roomTypeBindingSource;
        private System.Windows.Forms.FlowLayoutPanel mainFlowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtTo;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource reservationBindingSource;
        private ESMART_HMSDBDataSetTableAdapters.ReservationTableAdapter reservationTableAdapter;
        private System.Windows.Forms.DataGridView dgvReservation;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestPhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkInDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkOutDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateModifiedDataGridViewTextBoxColumn;
    }
}