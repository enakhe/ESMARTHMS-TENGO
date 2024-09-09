namespace ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance
{
    partial class CardMaintenanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardMaintenanceForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.AUTHDATA = new System.Windows.Forms.TextBox();
            this.AuthorizationCard = new System.Windows.Forms.Label();
            this.btnUnlockParams = new System.Windows.Forms.Button();
            this.btnReadAuthCard = new System.Windows.Forms.Button();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtBuilding = new System.Windows.Forms.Label();
            this.txtEdate = new System.Windows.Forms.Label();
            this.btnRecycle = new System.Windows.Forms.Button();
            this.txtSDate = new System.Windows.Forms.Label();
            this.txtCardTypeTwo = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.Label();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.txtCardType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToEnd = new System.Windows.Forms.DateTimePicker();
            this.txtStart = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvSpecialCards = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issueTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refundTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issuedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canOpenDeadLocksDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.passageModeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isTrashedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateModifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMasterCard = new System.Windows.Forms.Button();
            this.btnBuildingCard = new System.Windows.Forms.Button();
            this.btnFloorCard = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.specialCardTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.SpecialCardTableAdapter();
            this.txtFloorList = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecialCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialCardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1514, 676);
            this.splitContainer1.SplitterDistance = 588;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(20);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainer2.Size = new System.Drawing.Size(1514, 588);
            this.splitContainer2.SplitterDistance = 504;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.splitContainer3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 548);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.panel4);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainer3.Size = new System.Drawing.Size(462, 546);
            this.splitContainer3.SplitterDistance = 126;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer4.Panel1.Controls.Add(this.AUTHDATA);
            this.splitContainer4.Panel1.Controls.Add(this.AuthorizationCard);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel2.Controls.Add(this.btnUnlockParams);
            this.splitContainer4.Panel2.Controls.Add(this.btnReadAuthCard);
            this.splitContainer4.Panel2.Controls.Add(this.btnOpenPort);
            this.splitContainer4.Size = new System.Drawing.Size(462, 126);
            this.splitContainer4.SplitterDistance = 58;
            this.splitContainer4.TabIndex = 0;
            // 
            // AUTHDATA
            // 
            this.AUTHDATA.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AUTHDATA.Location = new System.Drawing.Point(170, 13);
            this.AUTHDATA.Name = "AUTHDATA";
            this.AUTHDATA.ReadOnly = true;
            this.AUTHDATA.Size = new System.Drawing.Size(279, 30);
            this.AUTHDATA.TabIndex = 1;
            // 
            // AuthorizationCard
            // 
            this.AuthorizationCard.AutoSize = true;
            this.AuthorizationCard.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorizationCard.Location = new System.Drawing.Point(9, 19);
            this.AuthorizationCard.Name = "AuthorizationCard";
            this.AuthorizationCard.Size = new System.Drawing.Size(155, 23);
            this.AuthorizationCard.TabIndex = 0;
            this.AuthorizationCard.Text = "Authorization Card";
            // 
            // btnUnlockParams
            // 
            this.btnUnlockParams.Enabled = false;
            this.btnUnlockParams.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlockParams.Location = new System.Drawing.Point(294, 16);
            this.btnUnlockParams.Name = "btnUnlockParams";
            this.btnUnlockParams.Size = new System.Drawing.Size(122, 33);
            this.btnUnlockParams.TabIndex = 1;
            this.btnUnlockParams.Text = "Unlock Params";
            this.btnUnlockParams.UseVisualStyleBackColor = true;
            this.btnUnlockParams.Click += new System.EventHandler(this.btnUnlockParams_Click);
            // 
            // btnReadAuthCard
            // 
            this.btnReadAuthCard.BackColor = System.Drawing.Color.SlateGray;
            this.btnReadAuthCard.Enabled = false;
            this.btnReadAuthCard.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadAuthCard.ForeColor = System.Drawing.Color.White;
            this.btnReadAuthCard.Location = new System.Drawing.Point(166, 16);
            this.btnReadAuthCard.Name = "btnReadAuthCard";
            this.btnReadAuthCard.Size = new System.Drawing.Size(122, 33);
            this.btnReadAuthCard.TabIndex = 1;
            this.btnReadAuthCard.Text = "Read Auth Card";
            this.btnReadAuthCard.UseVisualStyleBackColor = false;
            this.btnReadAuthCard.Click += new System.EventHandler(this.btnReadAuthCard_Click);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOpenPort.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenPort.ForeColor = System.Drawing.Color.White;
            this.btnOpenPort.Location = new System.Drawing.Point(38, 16);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(122, 33);
            this.btnOpenPort.TabIndex = 1;
            this.btnOpenPort.Text = "Open Port";
            this.btnOpenPort.UseVisualStyleBackColor = false;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtTime);
            this.panel4.Controls.Add(this.txtFloorList);
            this.panel4.Controls.Add(this.txtBuilding);
            this.panel4.Controls.Add(this.txtEdate);
            this.panel4.Controls.Add(this.btnRecycle);
            this.panel4.Controls.Add(this.txtSDate);
            this.panel4.Controls.Add(this.txtCardTypeTwo);
            this.panel4.Controls.Add(this.txtCardNo);
            this.panel4.Controls.Add(this.txtStatus);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(20, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(422, 376);
            this.panel4.TabIndex = 0;
            // 
            // txtBuilding
            // 
            this.txtBuilding.AutoSize = true;
            this.txtBuilding.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuilding.Location = new System.Drawing.Point(18, 177);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.Size = new System.Drawing.Size(0, 21);
            this.txtBuilding.TabIndex = 0;
            // 
            // txtEdate
            // 
            this.txtEdate.AutoSize = true;
            this.txtEdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdate.Location = new System.Drawing.Point(18, 145);
            this.txtEdate.Name = "txtEdate";
            this.txtEdate.Size = new System.Drawing.Size(0, 21);
            this.txtEdate.TabIndex = 0;
            // 
            // btnRecycle
            // 
            this.btnRecycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRecycle.Enabled = false;
            this.btnRecycle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecycle.ForeColor = System.Drawing.Color.White;
            this.btnRecycle.Location = new System.Drawing.Point(22, 315);
            this.btnRecycle.Name = "btnRecycle";
            this.btnRecycle.Size = new System.Drawing.Size(374, 45);
            this.btnRecycle.TabIndex = 1;
            this.btnRecycle.Text = "Recycle Card";
            this.btnRecycle.UseVisualStyleBackColor = false;
            this.btnRecycle.Click += new System.EventHandler(this.btnRecycle_Click);
            // 
            // txtSDate
            // 
            this.txtSDate.AutoSize = true;
            this.txtSDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDate.Location = new System.Drawing.Point(18, 115);
            this.txtSDate.Name = "txtSDate";
            this.txtSDate.Size = new System.Drawing.Size(0, 21);
            this.txtSDate.TabIndex = 0;
            // 
            // txtCardTypeTwo
            // 
            this.txtCardTypeTwo.AutoSize = true;
            this.txtCardTypeTwo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardTypeTwo.Location = new System.Drawing.Point(18, 85);
            this.txtCardTypeTwo.Name = "txtCardTypeTwo";
            this.txtCardTypeTwo.Size = new System.Drawing.Size(0, 21);
            this.txtCardTypeTwo.TabIndex = 0;
            // 
            // txtCardNo
            // 
            this.txtCardNo.AutoSize = true;
            this.txtCardNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNo.Location = new System.Drawing.Point(18, 56);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(0, 21);
            this.txtCardNo.TabIndex = 0;
            // 
            // txtStatus
            // 
            this.txtStatus.AutoSize = true;
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(18, 11);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(0, 21);
            this.txtStatus.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(20, 20);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.panel3);
            this.splitContainer5.Size = new System.Drawing.Size(966, 548);
            this.splitContainer5.SplitterDistance = 57;
            this.splitContainer5.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.txtCardType);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtToEnd);
            this.panel2.Controls.Add(this.txtStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 57);
            this.panel2.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(835, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 29);
            this.button5.TabIndex = 5;
            this.button5.Text = "Query";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // txtCardType
            // 
            this.txtCardType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardType.FormattingEnabled = true;
            this.txtCardType.Items.AddRange(new object[] {
            "Master Card",
            "Floor Card",
            "Building Card",
            "Room Settings Card",
            "Lost Card",
            "Cancel Lost Card"});
            this.txtCardType.Location = new System.Drawing.Point(677, 18);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.Size = new System.Drawing.Size(121, 25);
            this.txtCardType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(603, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Card Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(342, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Issued Date";
            // 
            // txtToEnd
            // 
            this.txtToEnd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToEnd.Location = new System.Drawing.Point(370, 19);
            this.txtToEnd.Name = "txtToEnd";
            this.txtToEnd.Size = new System.Drawing.Size(200, 25);
            this.txtToEnd.TabIndex = 3;
            // 
            // txtStart
            // 
            this.txtStart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStart.Location = new System.Drawing.Point(122, 20);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(200, 25);
            this.txtStart.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.dgvSpecialCards);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(966, 487);
            this.panel3.TabIndex = 0;
            // 
            // dgvSpecialCards
            // 
            this.dgvSpecialCards.AllowUserToAddRows = false;
            this.dgvSpecialCards.AllowUserToDeleteRows = false;
            this.dgvSpecialCards.AutoGenerateColumns = false;
            this.dgvSpecialCards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSpecialCards.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSpecialCards.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpecialCards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSpecialCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpecialCards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.cardNoDataGridViewTextBoxColumn,
            this.cardTypeDataGridViewTextBoxColumn,
            this.issueTimeDataGridViewTextBoxColumn,
            this.refundTimeDataGridViewTextBoxColumn,
            this.issuedByDataGridViewTextBoxColumn,
            this.canOpenDeadLocksDataGridViewCheckBoxColumn,
            this.passageModeDataGridViewCheckBoxColumn,
            this.isTrashedDataGridViewCheckBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.dateModifiedDataGridViewTextBoxColumn});
            this.dgvSpecialCards.DataSource = this.specialCardBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpecialCards.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSpecialCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpecialCards.GridColor = System.Drawing.Color.Gray;
            this.dgvSpecialCards.Location = new System.Drawing.Point(0, 0);
            this.dgvSpecialCards.Name = "dgvSpecialCards";
            this.dgvSpecialCards.ReadOnly = true;
            this.dgvSpecialCards.Size = new System.Drawing.Size(966, 487);
            this.dgvSpecialCards.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // cardNoDataGridViewTextBoxColumn
            // 
            this.cardNoDataGridViewTextBoxColumn.DataPropertyName = "CardNo";
            this.cardNoDataGridViewTextBoxColumn.HeaderText = "Card No";
            this.cardNoDataGridViewTextBoxColumn.Name = "cardNoDataGridViewTextBoxColumn";
            this.cardNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardTypeDataGridViewTextBoxColumn
            // 
            this.cardTypeDataGridViewTextBoxColumn.DataPropertyName = "CardType";
            this.cardTypeDataGridViewTextBoxColumn.HeaderText = "Card Type";
            this.cardTypeDataGridViewTextBoxColumn.Name = "cardTypeDataGridViewTextBoxColumn";
            this.cardTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // issueTimeDataGridViewTextBoxColumn
            // 
            this.issueTimeDataGridViewTextBoxColumn.DataPropertyName = "IssueTime";
            this.issueTimeDataGridViewTextBoxColumn.HeaderText = "Issue Time";
            this.issueTimeDataGridViewTextBoxColumn.Name = "issueTimeDataGridViewTextBoxColumn";
            this.issueTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // refundTimeDataGridViewTextBoxColumn
            // 
            this.refundTimeDataGridViewTextBoxColumn.DataPropertyName = "RefundTime";
            this.refundTimeDataGridViewTextBoxColumn.HeaderText = "Refund Time";
            this.refundTimeDataGridViewTextBoxColumn.Name = "refundTimeDataGridViewTextBoxColumn";
            this.refundTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // issuedByDataGridViewTextBoxColumn
            // 
            this.issuedByDataGridViewTextBoxColumn.DataPropertyName = "IssuedBy";
            this.issuedByDataGridViewTextBoxColumn.HeaderText = "Issued By";
            this.issuedByDataGridViewTextBoxColumn.Name = "issuedByDataGridViewTextBoxColumn";
            this.issuedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // canOpenDeadLocksDataGridViewCheckBoxColumn
            // 
            this.canOpenDeadLocksDataGridViewCheckBoxColumn.DataPropertyName = "CanOpenDeadLocks";
            this.canOpenDeadLocksDataGridViewCheckBoxColumn.HeaderText = "Dead Locks";
            this.canOpenDeadLocksDataGridViewCheckBoxColumn.Name = "canOpenDeadLocksDataGridViewCheckBoxColumn";
            this.canOpenDeadLocksDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // passageModeDataGridViewCheckBoxColumn
            // 
            this.passageModeDataGridViewCheckBoxColumn.DataPropertyName = "PassageMode";
            this.passageModeDataGridViewCheckBoxColumn.HeaderText = "Passage Mode";
            this.passageModeDataGridViewCheckBoxColumn.Name = "passageModeDataGridViewCheckBoxColumn";
            this.passageModeDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // isTrashedDataGridViewCheckBoxColumn
            // 
            this.isTrashedDataGridViewCheckBoxColumn.DataPropertyName = "IsTrashed";
            this.isTrashedDataGridViewCheckBoxColumn.HeaderText = "IsTrashed";
            this.isTrashedDataGridViewCheckBoxColumn.Name = "isTrashedDataGridViewCheckBoxColumn";
            this.isTrashedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isTrashedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCreatedDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateModifiedDataGridViewTextBoxColumn
            // 
            this.dateModifiedDataGridViewTextBoxColumn.DataPropertyName = "DateModified";
            this.dateModifiedDataGridViewTextBoxColumn.HeaderText = "DateModified";
            this.dateModifiedDataGridViewTextBoxColumn.Name = "dateModifiedDataGridViewTextBoxColumn";
            this.dateModifiedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateModifiedDataGridViewTextBoxColumn.Visible = false;
            // 
            // specialCardBindingSource
            // 
            this.specialCardBindingSource.DataMember = "SpecialCard";
            this.specialCardBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // eSMART_HMSDBDataSet
            // 
            this.eSMART_HMSDBDataSet.DataSetName = "ESMART_HMSDBDataSet";
            this.eSMART_HMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMasterCard);
            this.flowLayoutPanel1.Controls.Add(this.btnBuildingCard);
            this.flowLayoutPanel1.Controls.Add(this.btnFloorCard);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 15, 10, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1514, 84);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnMasterCard
            // 
            this.btnMasterCard.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnMasterCard.Enabled = false;
            this.btnMasterCard.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterCard.ForeColor = System.Drawing.Color.White;
            this.btnMasterCard.Location = new System.Drawing.Point(23, 18);
            this.btnMasterCard.Name = "btnMasterCard";
            this.btnMasterCard.Size = new System.Drawing.Size(122, 36);
            this.btnMasterCard.TabIndex = 1;
            this.btnMasterCard.Text = "Master Card";
            this.btnMasterCard.UseVisualStyleBackColor = false;
            this.btnMasterCard.Click += new System.EventHandler(this.btnMasterCard_Click);
            // 
            // btnBuildingCard
            // 
            this.btnBuildingCard.BackColor = System.Drawing.Color.Blue;
            this.btnBuildingCard.Enabled = false;
            this.btnBuildingCard.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuildingCard.ForeColor = System.Drawing.Color.White;
            this.btnBuildingCard.Location = new System.Drawing.Point(151, 18);
            this.btnBuildingCard.Name = "btnBuildingCard";
            this.btnBuildingCard.Size = new System.Drawing.Size(122, 36);
            this.btnBuildingCard.TabIndex = 1;
            this.btnBuildingCard.Text = "Building Card";
            this.btnBuildingCard.UseVisualStyleBackColor = false;
            this.btnBuildingCard.Click += new System.EventHandler(this.btnBuildingCard_Click);
            // 
            // btnFloorCard
            // 
            this.btnFloorCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFloorCard.Enabled = false;
            this.btnFloorCard.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFloorCard.ForeColor = System.Drawing.Color.White;
            this.btnFloorCard.Location = new System.Drawing.Point(279, 18);
            this.btnFloorCard.Name = "btnFloorCard";
            this.btnFloorCard.Size = new System.Drawing.Size(122, 36);
            this.btnFloorCard.TabIndex = 1;
            this.btnFloorCard.Text = "Floor Card";
            this.btnFloorCard.UseVisualStyleBackColor = false;
            this.btnFloorCard.Click += new System.EventHandler(this.btnFloor_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(407, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 36);
            this.button3.TabIndex = 1;
            this.button3.Text = "Emergecy Card";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnMasterCard_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(535, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 36);
            this.button4.TabIndex = 1;
            this.button4.Text = "Backup Guest Card";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnMasterCard_Click);
            // 
            // specialCardTableAdapter
            // 
            this.specialCardTableAdapter.ClearBeforeFill = true;
            // 
            // txtFloorList
            // 
            this.txtFloorList.AutoSize = true;
            this.txtFloorList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFloorList.Location = new System.Drawing.Point(18, 209);
            this.txtFloorList.Name = "txtFloorList";
            this.txtFloorList.Size = new System.Drawing.Size(0, 21);
            this.txtFloorList.TabIndex = 0;
            // 
            // txtTime
            // 
            this.txtTime.AutoSize = true;
            this.txtTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(18, 239);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(0, 21);
            this.txtTime.TabIndex = 0;
            // 
            // CardMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1514, 676);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CardMaintenanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Maintenance";
            this.Load += new System.EventHandler(this.CardMaintenanceForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecialCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialCardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMasterCard;
        private System.Windows.Forms.Button btnBuildingCard;
        private System.Windows.Forms.Button btnFloorCard;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox AUTHDATA;
        private System.Windows.Forms.Label AuthorizationCard;
        private System.Windows.Forms.Button btnUnlockParams;
        private System.Windows.Forms.Button btnReadAuthCard;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvSpecialCards;
        private ESMART_HMSDBDataSet eSMART_HMSDBDataSet;
        private System.Windows.Forms.BindingSource specialCardBindingSource;
        private ESMART_HMSDBDataSetTableAdapters.SpecialCardTableAdapter specialCardTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn issueTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refundTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn issuedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canOpenDeadLocksDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn passageModeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isTrashedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateModifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtToEnd;
        private System.Windows.Forms.DateTimePicker txtStart;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox txtCardType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.Label txtCardNo;
        private System.Windows.Forms.Label txtCardTypeTwo;
        private System.Windows.Forms.Label txtEdate;
        private System.Windows.Forms.Label txtSDate;
        private System.Windows.Forms.Button btnRecycle;
        private System.Windows.Forms.Label txtBuilding;
        private System.Windows.Forms.Label txtFloorList;
        private System.Windows.Forms.Label txtTime;
    }
}