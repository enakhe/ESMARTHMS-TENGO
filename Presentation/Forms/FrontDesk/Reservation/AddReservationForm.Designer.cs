namespace ESMART_HMS.Presentation.Forms.Reservation
{
    partial class AddReservationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReservationForm));
            this.btnGuest = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGuest = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.customerTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.GuestTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.ComboBox();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.RoomTableAdapter();
            this.txtCheckIn = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheckOut = new System.Windows.Forms.DateTimePicker();
            this.txtPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuest
            // 
            this.btnGuest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuest.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuest.Location = new System.Drawing.Point(354, 61);
            this.btnGuest.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(139, 24);
            this.btnGuest.TabIndex = 14;
            this.btnGuest.Text = "Add Guest";
            this.btnGuest.UseVisualStyleBackColor = true;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 61);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "Guest";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 30);
            this.label1.TabIndex = 15;
            this.label1.Text = "Add Reservation";
            // 
            // txtGuest
            // 
            this.txtGuest.DataSource = this.customerBindingSource;
            this.txtGuest.DisplayMember = "FullName";
            this.txtGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtGuest.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuest.FormattingEnabled = true;
            this.txtGuest.Location = new System.Drawing.Point(29, 91);
            this.txtGuest.Margin = new System.Windows.Forms.Padding(2);
            this.txtGuest.Name = "txtGuest";
            this.txtGuest.Size = new System.Drawing.Size(464, 33);
            this.txtGuest.TabIndex = 16;
            this.txtGuest.ValueMember = "Id";
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Guest";
            this.customerBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // eSMART_HMSDBDataSet
            // 
            this.eSMART_HMSDBDataSet.DataSetName = "ESMART_HMSDBDataSet";
            this.eSMART_HMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Room";
            // 
            // txtRoom
            // 
            this.txtRoom.DataSource = this.roomBindingSource;
            this.txtRoom.DisplayMember = "RoomNo";
            this.txtRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoom.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoom.FormattingEnabled = true;
            this.txtRoom.Location = new System.Drawing.Point(29, 176);
            this.txtRoom.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(464, 33);
            this.txtRoom.TabIndex = 16;
            this.txtRoom.ValueMember = "Id";
            this.txtRoom.TextChanged += new System.EventHandler(this.txtRoom_TextChanged);
            // 
            // roomBindingSource
            // 
            this.roomBindingSource.DataMember = "Room";
            this.roomBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // roomTableAdapter
            // 
            this.roomTableAdapter.ClearBeforeFill = true;
            // 
            // txtCheckIn
            // 
            this.txtCheckIn.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckIn.Location = new System.Drawing.Point(29, 258);
            this.txtCheckIn.Margin = new System.Windows.Forms.Padding(2);
            this.txtCheckIn.Name = "txtCheckIn";
            this.txtCheckIn.Size = new System.Drawing.Size(464, 31);
            this.txtCheckIn.TabIndex = 17;
            this.txtCheckIn.Value = new System.DateTime(2024, 7, 19, 0, 0, 0, 0);
            this.txtCheckIn.ValueChanged += new System.EventHandler(this.txtCheckIn_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 232);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Check In";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 336);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Expected Check Out";
            // 
            // txtCheckOut
            // 
            this.txtCheckOut.Enabled = false;
            this.txtCheckOut.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckOut.Location = new System.Drawing.Point(29, 362);
            this.txtCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.txtCheckOut.Name = "txtCheckOut";
            this.txtCheckOut.Size = new System.Drawing.Size(464, 31);
            this.txtCheckOut.TabIndex = 17;
            this.txtCheckOut.Value = new System.DateTime(2024, 6, 20, 16, 16, 49, 0);
            this.txtCheckOut.ValueChanged += new System.EventHandler(this.txtCheckOut_ValueChanged);
            // 
            // txtPaymentMethod
            // 
            this.txtPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentMethod.FormattingEnabled = true;
            this.txtPaymentMethod.Items.AddRange(new object[] {
            "POS",
            "BANK TRANSFER",
            "CASH"});
            this.txtPaymentMethod.Location = new System.Drawing.Point(29, 554);
            this.txtPaymentMethod.Margin = new System.Windows.Forms.Padding(2);
            this.txtPaymentMethod.Name = "txtPaymentMethod";
            this.txtPaymentMethod.Size = new System.Drawing.Size(464, 33);
            this.txtPaymentMethod.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 527);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Payment Method";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(183, 606);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 41);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(270, 454);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(224, 31);
            this.txtAmount.TabIndex = 20;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(266, 427);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Expected Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 427);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Amount";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPaid.Location = new System.Drawing.Point(29, 454);
            this.txtAmountPaid.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(224, 31);
            this.txtAmountPaid.TabIndex = 20;
            this.txtAmountPaid.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtAmountPaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(314, 309);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "No of days";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(402, 306);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(92, 26);
            this.textBox2.TabIndex = 20;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // AddReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(524, 666);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtAmountPaid);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPaymentMethod);
            this.Controls.Add(this.txtCheckOut);
            this.Controls.Add(this.txtCheckIn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGuest);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGuest);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddReservationForm";
            this.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Reservation";
            this.Load += new System.EventHandler(this.AddReservationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtGuest;
        private ESMART_HMSDBDataSet eSMART_HMSDBDataSet;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private ESMART_HMSDBDataSetTableAdapters.GuestTableAdapter customerTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtRoom;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private ESMART_HMSDBDataSetTableAdapters.RoomTableAdapter roomTableAdapter;
        private System.Windows.Forms.DateTimePicker txtCheckIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtCheckOut;
        private System.Windows.Forms.ComboBox txtPaymentMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
    }
}