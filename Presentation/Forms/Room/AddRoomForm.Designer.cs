namespace ESMART_HMS.Presentation.Forms.Rooms
{
    partial class AddRoomForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoomNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLockNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdultPerRoom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtChildrenPerRoom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRoomType = new System.Windows.Forms.ComboBox();
            this.roomTypeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.roomTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRoomType = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.roomTypeTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.RoomTypeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.roomTypeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Room";
            // 
            // txtRoomNo
            // 
            this.txtRoomNo.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomNo.Location = new System.Drawing.Point(39, 108);
            this.txtRoomNo.Name = "txtRoomNo";
            this.txtRoomNo.Size = new System.Drawing.Size(309, 37);
            this.txtRoomNo.TabIndex = 5;
            this.txtRoomNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomNo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Room No";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNo.Location = new System.Drawing.Point(365, 106);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(301, 37);
            this.txtCardNo.TabIndex = 7;
            this.txtCardNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardNo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(359, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "Room Card No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "Room Lock No";
            // 
            // txtLockNo
            // 
            this.txtLockNo.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLockNo.Location = new System.Drawing.Point(39, 216);
            this.txtLockNo.Name = "txtLockNo";
            this.txtLockNo.Size = new System.Drawing.Size(309, 37);
            this.txtLockNo.TabIndex = 5;
            this.txtLockNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLockNo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(365, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 30);
            this.label5.TabIndex = 6;
            this.label5.Text = "Rate";
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(365, 214);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(301, 37);
            this.txtRate.TabIndex = 7;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(244, 702);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(210, 50);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "Adults Per Room";
            // 
            // txtAdultPerRoom
            // 
            this.txtAdultPerRoom.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdultPerRoom.Location = new System.Drawing.Point(39, 338);
            this.txtAdultPerRoom.Name = "txtAdultPerRoom";
            this.txtAdultPerRoom.Size = new System.Drawing.Size(309, 37);
            this.txtAdultPerRoom.TabIndex = 5;
            this.txtAdultPerRoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdultPerRoom_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(363, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 30);
            this.label7.TabIndex = 6;
            this.label7.Text = "Children Per Room";
            // 
            // txtChildrenPerRoom
            // 
            this.txtChildrenPerRoom.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChildrenPerRoom.Location = new System.Drawing.Point(365, 336);
            this.txtChildrenPerRoom.Name = "txtChildrenPerRoom";
            this.txtChildrenPerRoom.Size = new System.Drawing.Size(301, 37);
            this.txtChildrenPerRoom.TabIndex = 7;
            this.txtChildrenPerRoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChildrenPerRoom_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 434);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 30);
            this.label8.TabIndex = 11;
            this.label8.Text = "Room Type";
            // 
            // txtRoomType
            // 
            this.txtRoomType.DataSource = this.roomTypeBindingSource1;
            this.txtRoomType.DisplayMember = "Title";
            this.txtRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoomType.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomType.FormattingEnabled = true;
            this.txtRoomType.Location = new System.Drawing.Point(39, 466);
            this.txtRoomType.Name = "txtRoomType";
            this.txtRoomType.Size = new System.Drawing.Size(627, 38);
            this.txtRoomType.TabIndex = 10;
            this.txtRoomType.ValueMember = "Id";
            // 
            // roomTypeBindingSource1
            // 
            this.roomTypeBindingSource1.DataMember = "RoomType";
            this.roomTypeBindingSource1.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // eSMART_HMSDBDataSet
            // 
            this.eSMART_HMSDBDataSet.DataSetName = "ESMART_HMSDBDataSet";
            this.eSMART_HMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roomTypeBindingSource
            // 
            this.roomTypeBindingSource.DataMember = "RoomType";
            // 
            // btnRoomType
            // 
            this.btnRoomType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoomType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomType.Location = new System.Drawing.Point(481, 434);
            this.btnRoomType.Name = "btnRoomType";
            this.btnRoomType.Size = new System.Drawing.Size(185, 30);
            this.btnRoomType.TabIndex = 12;
            this.btnRoomType.Text = "Add Room Type";
            this.btnRoomType.UseVisualStyleBackColor = true;
            this.btnRoomType.Click += new System.EventHandler(this.btnRoomType_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(39, 592);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(627, 86);
            this.txtDescription.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(34, 557);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 30);
            this.label9.TabIndex = 11;
            this.label9.Text = "Room Description";
            // 
            // roomTypeTableAdapter
            // 
            this.roomTypeTableAdapter.ClearBeforeFill = true;
            // 
            // AddRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(710, 768);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnRoomType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRoomType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtChildrenPerRoom);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAdultPerRoom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLockNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRoomNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRoomForm";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Room";
            this.Load += new System.EventHandler(this.AddRoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomTypeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRoomNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLockNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdultPerRoom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtChildrenPerRoom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtRoomType;
        private System.Windows.Forms.BindingSource roomTypeBindingSource;
        private System.Windows.Forms.Button btnRoomType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private ESMART_HMSDBDataSet eSMART_HMSDBDataSet;
        private System.Windows.Forms.BindingSource roomTypeBindingSource1;
        private ESMART_HMSDBDataSetTableAdapters.RoomTypeTableAdapter roomTypeTableAdapter;
    }
}