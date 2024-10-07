namespace ESMART_HMS.Presentation.Forms.FrontDesk.booking
{
    partial class IssueCardForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueCardForm));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtOutTime = new System.Windows.Forms.DateTimePicker();
            this.txtInTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGuest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.roundedPanel1 = new ESMART_HMS.Presentation.Forms.FormClasses.RoundedPanel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvIssueCard = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIssueCard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssueCard)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(30, 30);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.roundedPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(978, 538);
            this.splitContainer2.SplitterDistance = 133;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtOutTime);
            this.panel3.Controls.Add(this.txtInTime);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtRoom);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtGuest);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(978, 133);
            this.panel3.TabIndex = 0;
            // 
            // txtOutTime
            // 
            this.txtOutTime.Enabled = false;
            this.txtOutTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutTime.Location = new System.Drawing.Point(682, 79);
            this.txtOutTime.Name = "txtOutTime";
            this.txtOutTime.Size = new System.Drawing.Size(264, 30);
            this.txtOutTime.TabIndex = 10;
            // 
            // txtInTime
            // 
            this.txtInTime.Enabled = false;
            this.txtInTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInTime.Location = new System.Drawing.Point(133, 79);
            this.txtInTime.Name = "txtInTime";
            this.txtInTime.Size = new System.Drawing.Size(264, 30);
            this.txtInTime.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(561, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Check Out:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Check In:";
            // 
            // txtRoom
            // 
            this.txtRoom.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoom.Location = new System.Drawing.Point(682, 32);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.ReadOnly = true;
            this.txtRoom.Size = new System.Drawing.Size(264, 30);
            this.txtRoom.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(561, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Room:";
            // 
            // txtGuest
            // 
            this.txtGuest.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuest.Location = new System.Drawing.Point(133, 32);
            this.txtGuest.Name = "txtGuest";
            this.txtGuest.ReadOnly = true;
            this.txtGuest.Size = new System.Drawing.Size(264, 30);
            this.txtGuest.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Guest:";
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderColor = System.Drawing.Color.Gray;
            this.roundedPanel1.BorderRadius = 5;
            this.roundedPanel1.BorderThickness = 1;
            this.roundedPanel1.Controls.Add(this.splitContainer3);
            this.roundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.roundedPanel1.Size = new System.Drawing.Size(978, 401);
            this.roundedPanel1.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(10, 10);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvIssueCard);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnIssueCard);
            this.splitContainer3.Size = new System.Drawing.Size(958, 381);
            this.splitContainer3.SplitterDistance = 324;
            this.splitContainer3.TabIndex = 0;
            // 
            // dgvIssueCard
            // 
            this.dgvIssueCard.AllowUserToAddRows = false;
            this.dgvIssueCard.AllowUserToDeleteRows = false;
            this.dgvIssueCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIssueCard.BackgroundColor = System.Drawing.Color.White;
            this.dgvIssueCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIssueCard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIssueCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssueCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Room,
            this.CardQuantity,
            this.RoomType,
            this.Amount,
            this.Floor});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIssueCard.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIssueCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIssueCard.GridColor = System.Drawing.Color.Black;
            this.dgvIssueCard.Location = new System.Drawing.Point(0, 0);
            this.dgvIssueCard.Margin = new System.Windows.Forms.Padding(2);
            this.dgvIssueCard.Name = "dgvIssueCard";
            this.dgvIssueCard.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIssueCard.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIssueCard.RowHeadersWidth = 51;
            this.dgvIssueCard.RowTemplate.Height = 24;
            this.dgvIssueCard.Size = new System.Drawing.Size(958, 324);
            this.dgvIssueCard.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Room
            // 
            this.Room.DataPropertyName = "Room";
            this.Room.HeaderText = "Room";
            this.Room.Name = "Room";
            this.Room.ReadOnly = true;
            // 
            // CardQuantity
            // 
            this.CardQuantity.DataPropertyName = "CardQuantity";
            this.CardQuantity.HeaderText = "Card Quantity";
            this.CardQuantity.Name = "CardQuantity";
            this.CardQuantity.ReadOnly = true;
            // 
            // RoomType
            // 
            this.RoomType.DataPropertyName = "RoomType";
            this.RoomType.HeaderText = "Room Type";
            this.RoomType.Name = "RoomType";
            this.RoomType.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Floor
            // 
            this.Floor.DataPropertyName = "Floor";
            this.Floor.HeaderText = "Floor";
            this.Floor.Name = "Floor";
            this.Floor.ReadOnly = true;
            // 
            // btnIssueCard
            // 
            this.btnIssueCard.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnIssueCard.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueCard.ForeColor = System.Drawing.Color.White;
            this.btnIssueCard.Location = new System.Drawing.Point(810, 5);
            this.btnIssueCard.Name = "btnIssueCard";
            this.btnIssueCard.Size = new System.Drawing.Size(138, 42);
            this.btnIssueCard.TabIndex = 0;
            this.btnIssueCard.Text = "Issue Card";
            this.btnIssueCard.UseVisualStyleBackColor = false;
            this.btnIssueCard.Click += new System.EventHandler(this.btnIssueCard_Click);
            // 
            // IssueCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1038, 598);
            this.Controls.Add(this.splitContainer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueCardForm";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Card";
            this.Load += new System.EventHandler(this.IssueCardForm_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.roundedPanel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssueCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker txtOutTime;
        private System.Windows.Forms.DateTimePicker txtInTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGuest;
        private System.Windows.Forms.Label label2;
        private FormClasses.RoundedPanel roundedPanel1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvIssueCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Floor;
        private System.Windows.Forms.Button btnIssueCard;
    }
}