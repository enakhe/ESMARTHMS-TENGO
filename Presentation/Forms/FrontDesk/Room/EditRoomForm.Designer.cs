namespace ESMART_HMS.Presentation.Forms.Rooms
{
    partial class EditRoomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRoomForm));
            this.roomTypeTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.RoomTypeTableAdapter();
            this.roomTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.roomTypeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.Label();
            this.btnArea = new System.Windows.Forms.Button();
            this.btnAddBuilding = new System.Windows.Forms.Button();
            this.AddFloor = new System.Windows.Forms.Button();
            this.addRoomType = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFloor = new System.Windows.Forms.ComboBox();
            this.txtBuilding = new System.Windows.Forms.ComboBox();
            this.txtRoomType = new System.Windows.Forms.ComboBox();
            this.txtArea = new System.Windows.Forms.ComboBox();
            this.txtChildrenPerRoom = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdultPerRoom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRoomNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.roomTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomTypeBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // roomTypeTableAdapter
            // 
            this.roomTypeTableAdapter.ClearBeforeFill = true;
            // 
            // roomTypeBindingSource
            // 
            this.roomTypeBindingSource.DataMember = "RoomType";
            // 
            // eSMART_HMSDBDataSet
            // 
            this.eSMART_HMSDBDataSet.DataSetName = "ESMART_HMSDBDataSet";
            this.eSMART_HMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roomTypeBindingSource1
            // 
            this.roomTypeBindingSource1.DataMember = "RoomType";
            this.roomTypeBindingSource1.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(191, 582);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 41);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Edit";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 30);
            this.label1.TabIndex = 14;
            this.label1.Text = "Edit Room";
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Location = new System.Drawing.Point(155, 21);
            this.txtId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(16, 13);
            this.txtId.TabIndex = 34;
            this.txtId.Text = "Id";
            this.txtId.Visible = false;
            // 
            // btnArea
            // 
            this.btnArea.Location = new System.Drawing.Point(186, 277);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(75, 23);
            this.btnArea.TabIndex = 56;
            this.btnArea.Text = "Add";
            this.btnArea.UseVisualStyleBackColor = true;
            // 
            // btnAddBuilding
            // 
            this.btnAddBuilding.Location = new System.Drawing.Point(186, 172);
            this.btnAddBuilding.Name = "btnAddBuilding";
            this.btnAddBuilding.Size = new System.Drawing.Size(75, 23);
            this.btnAddBuilding.TabIndex = 55;
            this.btnAddBuilding.Text = "Add";
            this.btnAddBuilding.UseVisualStyleBackColor = true;
            // 
            // AddFloor
            // 
            this.AddFloor.Location = new System.Drawing.Point(425, 172);
            this.AddFloor.Name = "AddFloor";
            this.AddFloor.Size = new System.Drawing.Size(75, 23);
            this.AddFloor.TabIndex = 54;
            this.AddFloor.Text = "Add";
            this.AddFloor.UseVisualStyleBackColor = true;
            // 
            // addRoomType
            // 
            this.addRoomType.Location = new System.Drawing.Point(433, 277);
            this.addRoomType.Name = "addRoomType";
            this.addRoomType.Size = new System.Drawing.Size(75, 23);
            this.addRoomType.TabIndex = 53;
            this.addRoomType.Text = "Add";
            this.addRoomType.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(31, 500);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(471, 71);
            this.txtDescription.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 469);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 23);
            this.label9.TabIndex = 50;
            this.label9.Text = "Room Description";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(272, 170);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 23);
            this.label10.TabIndex = 49;
            this.label10.Text = "Floor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 275);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 48;
            this.label2.Text = "Area";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 23);
            this.label4.TabIndex = 47;
            this.label4.Text = "Building";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(272, 275);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 51;
            this.label8.Text = "Room Type";
            // 
            // txtFloor
            // 
            this.txtFloor.DisplayMember = "FloorNo";
            this.txtFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtFloor.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFloor.FormattingEnabled = true;
            this.txtFloor.Location = new System.Drawing.Point(275, 195);
            this.txtFloor.Margin = new System.Windows.Forms.Padding(2);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(225, 33);
            this.txtFloor.TabIndex = 46;
            this.txtFloor.ValueMember = "Id";
            // 
            // txtBuilding
            // 
            this.txtBuilding.DisplayMember = "BuildingName";
            this.txtBuilding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtBuilding.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuilding.FormattingEnabled = true;
            this.txtBuilding.Location = new System.Drawing.Point(28, 195);
            this.txtBuilding.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.Size = new System.Drawing.Size(233, 33);
            this.txtBuilding.TabIndex = 45;
            this.txtBuilding.ValueMember = "Id";
            this.txtBuilding.TextChanged += new System.EventHandler(this.txtBuilding_TextChanged);
            // 
            // txtRoomType
            // 
            this.txtRoomType.DataSource = this.roomTypeBindingSource1;
            this.txtRoomType.DisplayMember = "Title";
            this.txtRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoomType.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomType.FormattingEnabled = true;
            this.txtRoomType.Location = new System.Drawing.Point(275, 300);
            this.txtRoomType.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoomType.Name = "txtRoomType";
            this.txtRoomType.Size = new System.Drawing.Size(233, 33);
            this.txtRoomType.TabIndex = 44;
            this.txtRoomType.ValueMember = "Id";
            // 
            // txtArea
            // 
            this.txtArea.DisplayMember = "AreaName";
            this.txtArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtArea.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.FormattingEnabled = true;
            this.txtArea.Location = new System.Drawing.Point(28, 300);
            this.txtArea.Margin = new System.Windows.Forms.Padding(2);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(233, 33);
            this.txtArea.TabIndex = 43;
            this.txtArea.ValueMember = "Id";
            // 
            // txtChildrenPerRoom
            // 
            this.txtChildrenPerRoom.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChildrenPerRoom.Location = new System.Drawing.Point(275, 409);
            this.txtChildrenPerRoom.Margin = new System.Windows.Forms.Padding(2);
            this.txtChildrenPerRoom.Name = "txtChildrenPerRoom";
            this.txtChildrenPerRoom.Size = new System.Drawing.Size(227, 31);
            this.txtChildrenPerRoom.TabIndex = 42;
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(275, 97);
            this.txtRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(227, 31);
            this.txtRate.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(273, 382);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 23);
            this.label7.TabIndex = 40;
            this.label7.Text = "Children Per Room";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(275, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 23);
            this.label5.TabIndex = 39;
            this.label5.Text = "Rate";
            // 
            // txtAdultPerRoom
            // 
            this.txtAdultPerRoom.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdultPerRoom.Location = new System.Drawing.Point(30, 407);
            this.txtAdultPerRoom.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdultPerRoom.Name = "txtAdultPerRoom";
            this.txtAdultPerRoom.Size = new System.Drawing.Size(233, 31);
            this.txtAdultPerRoom.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 376);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 23);
            this.label6.TabIndex = 36;
            this.label6.Text = "Adults Per Room";
            // 
            // txtRoomNo
            // 
            this.txtRoomNo.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomNo.Location = new System.Drawing.Point(28, 97);
            this.txtRoomNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoomNo.Name = "txtRoomNo";
            this.txtRoomNo.Size = new System.Drawing.Size(233, 31);
            this.txtRoomNo.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "Room No";
            // 
            // EditRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(532, 641);
            this.Controls.Add(this.btnArea);
            this.Controls.Add(this.btnAddBuilding);
            this.Controls.Add(this.AddFloor);
            this.Controls.Add(this.addRoomType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFloor);
            this.Controls.Add(this.txtBuilding);
            this.Controls.Add(this.txtRoomType);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.txtChildrenPerRoom);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAdultPerRoom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRoomNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRoomForm";
            this.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Room";
            this.Load += new System.EventHandler(this.EditRoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomTypeBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESMART_HMSDBDataSetTableAdapters.RoomTypeTableAdapter roomTypeTableAdapter;
        private System.Windows.Forms.BindingSource roomTypeBindingSource;
        private ESMART_HMSDBDataSet eSMART_HMSDBDataSet;
        private System.Windows.Forms.BindingSource roomTypeBindingSource1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.Button btnArea;
        private System.Windows.Forms.Button btnAddBuilding;
        private System.Windows.Forms.Button AddFloor;
        private System.Windows.Forms.Button addRoomType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtFloor;
        private System.Windows.Forms.ComboBox txtBuilding;
        private System.Windows.Forms.ComboBox txtRoomType;
        private System.Windows.Forms.ComboBox txtArea;
        private System.Windows.Forms.TextBox txtChildrenPerRoom;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdultPerRoom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRoomNo;
        private System.Windows.Forms.Label label3;
    }
}