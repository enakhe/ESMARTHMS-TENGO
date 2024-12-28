namespace ESMART_HMS.Presentation.Forms.FrontDesk.Booking
{
    partial class EditBookingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBookingForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bankAccounts = new System.Windows.Forms.CheckedListBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.labelVAT = new System.Windows.Forms.Label();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.noOfDays = new System.Windows.Forms.TextBox();
            this.txtbookingAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnGuest = new System.Windows.Forms.Button();
            this.txtPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCheckOut = new System.Windows.Forms.DateTimePicker();
            this.txtCheckIn = new System.Windows.Forms.DateTimePicker();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtRoom = new System.Windows.Forms.ComboBox();
            this.txtGuest = new System.Windows.Forms.ComboBox();
            this.duration = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNoOfPerson = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(453, 560);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 41);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(532, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 551);
            this.panel1.TabIndex = 29;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bankAccounts);
            this.panel3.Controls.Add(this.txtTotalAmount);
            this.panel3.Controls.Add(this.txtVAT);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtAmount);
            this.panel3.Controls.Add(this.txtDiscount);
            this.panel3.Controls.Add(this.labelVAT);
            this.panel3.Controls.Add(this.labelTotalAmount);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(-3, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(533, 549);
            this.panel3.TabIndex = 32;
            // 
            // bankAccounts
            // 
            this.bankAccounts.Enabled = false;
            this.bankAccounts.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankAccounts.FormattingEnabled = true;
            this.bankAccounts.Location = new System.Drawing.Point(36, 335);
            this.bankAccounts.Name = "bankAccounts";
            this.bankAccounts.Size = new System.Drawing.Size(459, 204);
            this.bankAccounts.TabIndex = 60;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(271, 215);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(224, 31);
            this.txtTotalAmount.TabIndex = 59;
            // 
            // txtVAT
            // 
            this.txtVAT.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVAT.Location = new System.Drawing.Point(268, 106);
            this.txtVAT.Margin = new System.Windows.Forms.Padding(2);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(227, 31);
            this.txtVAT.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(32, 309);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 23);
            this.label13.TabIndex = 37;
            this.label13.Text = "Bank Account";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 189);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 23);
            this.label7.TabIndex = 37;
            this.label7.Text = "Expected Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(32, 215);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(224, 31);
            this.txtAmount.TabIndex = 56;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(32, 106);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(223, 31);
            this.txtDiscount.TabIndex = 54;
            // 
            // labelVAT
            // 
            this.labelVAT.AutoSize = true;
            this.labelVAT.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVAT.Location = new System.Drawing.Point(266, 78);
            this.labelVAT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVAT.Name = "labelVAT";
            this.labelVAT.Size = new System.Drawing.Size(41, 23);
            this.labelVAT.TabIndex = 42;
            this.labelVAT.Text = "VAT";
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalAmount.Location = new System.Drawing.Point(267, 187);
            this.labelTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(119, 23);
            this.labelTotalAmount.TabIndex = 43;
            this.labelTotalAmount.Text = "Total Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(32, 78);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 23);
            this.label11.TabIndex = 39;
            this.label11.Text = "Discount";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.noOfDays);
            this.panel2.Controls.Add(this.txtbookingAmount);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnGuest);
            this.panel2.Controls.Add(this.txtPaymentMethod);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtCheckOut);
            this.panel2.Controls.Add(this.txtCheckIn);
            this.panel2.Controls.Add(this.txtDuration);
            this.panel2.Controls.Add(this.txtRoom);
            this.panel2.Controls.Add(this.txtGuest);
            this.panel2.Controls.Add(this.duration);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtNoOfPerson);
            this.panel2.Location = new System.Drawing.Point(11, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 552);
            this.panel2.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(321, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 17);
            this.label15.TabIndex = 64;
            this.label15.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(439, 263);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 17);
            this.label17.TabIndex = 63;
            this.label17.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(341, 377);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 17);
            this.label19.TabIndex = 63;
            this.label19.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(407, 484);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 17);
            this.label21.TabIndex = 63;
            this.label21.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(170, 488);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 17);
            this.label20.TabIndex = 63;
            this.label20.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(140, 378);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 17);
            this.label18.TabIndex = 63;
            this.label18.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(103, 265);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 17);
            this.label16.TabIndex = 63;
            this.label16.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(80, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 17);
            this.label14.TabIndex = 63;
            this.label14.Text = "*";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(30, 78);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(461, 30);
            this.txtSearch.TabIndex = 62;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 482);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 23);
            this.label9.TabIndex = 60;
            this.label9.Text = "Booking Amount";
            // 
            // noOfDays
            // 
            this.noOfDays.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfDays.Location = new System.Drawing.Point(403, 216);
            this.noOfDays.Margin = new System.Windows.Forms.Padding(2);
            this.noOfDays.Name = "noOfDays";
            this.noOfDays.Size = new System.Drawing.Size(92, 26);
            this.noOfDays.TabIndex = 59;
            // 
            // txtbookingAmount
            // 
            this.txtbookingAmount.Enabled = false;
            this.txtbookingAmount.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbookingAmount.Location = new System.Drawing.Point(26, 508);
            this.txtbookingAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtbookingAmount.Name = "txtbookingAmount";
            this.txtbookingAmount.Size = new System.Drawing.Size(224, 31);
            this.txtbookingAmount.TabIndex = 61;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(315, 219);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 20);
            this.label12.TabIndex = 58;
            this.label12.Text = "No of days";
            // 
            // btnGuest
            // 
            this.btnGuest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuest.Location = new System.Drawing.Point(352, 49);
            this.btnGuest.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(139, 24);
            this.btnGuest.TabIndex = 56;
            this.btnGuest.Text = "Add Guest";
            this.btnGuest.UseVisualStyleBackColor = true;
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
            this.txtPaymentMethod.Location = new System.Drawing.Point(268, 507);
            this.txtPaymentMethod.Margin = new System.Windows.Forms.Padding(2);
            this.txtPaymentMethod.Name = "txtPaymentMethod";
            this.txtPaymentMethod.Size = new System.Drawing.Size(227, 33);
            this.txtPaymentMethod.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 30);
            this.label6.TabIndex = 55;
            this.label6.Text = "Edit Booking";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(264, 479);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 23);
            this.label5.TabIndex = 40;
            this.label5.Text = "Payment Method";
            // 
            // txtCheckOut
            // 
            this.txtCheckOut.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckOut.Location = new System.Drawing.Point(268, 285);
            this.txtCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.txtCheckOut.Name = "txtCheckOut";
            this.txtCheckOut.Size = new System.Drawing.Size(223, 31);
            this.txtCheckOut.TabIndex = 50;
            this.txtCheckOut.Value = new System.DateTime(2024, 6, 20, 16, 16, 49, 0);
            // 
            // txtCheckIn
            // 
            this.txtCheckIn.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckIn.Location = new System.Drawing.Point(31, 285);
            this.txtCheckIn.Margin = new System.Windows.Forms.Padding(2);
            this.txtCheckIn.Name = "txtCheckIn";
            this.txtCheckIn.Size = new System.Drawing.Size(223, 31);
            this.txtCheckIn.TabIndex = 51;
            this.txtCheckIn.Value = new System.DateTime(2024, 6, 20, 16, 16, 49, 0);
            // 
            // txtDuration
            // 
            this.txtDuration.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(268, 399);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(2);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(227, 31);
            this.txtDuration.TabIndex = 57;
            // 
            // txtRoom
            // 
            this.txtRoom.DisplayMember = "RoomNo";
            this.txtRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoom.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoom.FormattingEnabled = true;
            this.txtRoom.Location = new System.Drawing.Point(272, 168);
            this.txtRoom.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(223, 33);
            this.txtRoom.TabIndex = 48;
            this.txtRoom.ValueMember = "Id";
            // 
            // txtGuest
            // 
            this.txtGuest.DisplayMember = "FullName";
            this.txtGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtGuest.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuest.Location = new System.Drawing.Point(30, 170);
            this.txtGuest.Margin = new System.Windows.Forms.Padding(2);
            this.txtGuest.Name = "txtGuest";
            this.txtGuest.Size = new System.Drawing.Size(223, 33);
            this.txtGuest.TabIndex = 49;
            this.txtGuest.ValueMember = "Id";
            // 
            // duration
            // 
            this.duration.AutoSize = true;
            this.duration.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duration.Location = new System.Drawing.Point(264, 371);
            this.duration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(81, 23);
            this.duration.TabIndex = 41;
            this.duration.Text = "Duration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(270, 258);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 23);
            this.label4.TabIndex = 44;
            this.label4.Text = "Expected Check Out";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 259);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 23);
            this.label3.TabIndex = 45;
            this.label3.Text = "Check In";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 46;
            this.label2.Text = "Room";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(29, 371);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 23);
            this.label10.TabIndex = 38;
            this.label10.Text = "No Of Person";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 140);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 23);
            this.label8.TabIndex = 47;
            this.label8.Text = "Guest";
            // 
            // txtNoOfPerson
            // 
            this.txtNoOfPerson.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfPerson.Location = new System.Drawing.Point(31, 399);
            this.txtNoOfPerson.Margin = new System.Windows.Forms.Padding(2);
            this.txtNoOfPerson.Name = "txtNoOfPerson";
            this.txtNoOfPerson.Size = new System.Drawing.Size(224, 31);
            this.txtNoOfPerson.TabIndex = 53;
            // 
            // EditBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 606);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Booking";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox bankAccounts;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label labelVAT;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox noOfDays;
        private System.Windows.Forms.TextBox txtbookingAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.ComboBox txtPaymentMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtCheckOut;
        private System.Windows.Forms.DateTimePicker txtCheckIn;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.ComboBox txtRoom;
        private System.Windows.Forms.ComboBox txtGuest;
        private System.Windows.Forms.Label duration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNoOfPerson;
    }
}