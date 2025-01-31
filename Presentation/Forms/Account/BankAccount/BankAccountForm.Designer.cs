﻿namespace ESMART_HMS.Presentation.Forms.Account.BankAccount
{
    partial class BankAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankAccountForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.bankAccount = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddBank = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankAccountTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.BankAccountTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankAccNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankAccNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTrashedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateModifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.bankAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.bankAccount);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(20, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 548);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // bankAccount
            // 
            this.bankAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(175)))), ((int)(((byte)(129)))));
            this.bankAccount.Controls.Add(this.splitContainer2);
            this.bankAccount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankAccount.Location = new System.Drawing.Point(4, 46);
            this.bankAccount.Name = "bankAccount";
            this.bankAccount.Size = new System.Drawing.Size(974, 498);
            this.bankAccount.TabIndex = 2;
            this.bankAccount.Text = "Bank Account";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel4);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer2.Size = new System.Drawing.Size(974, 498);
            this.splitContainer2.SplitterDistance = 833;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.splitContainer3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(813, 478);
            this.panel4.TabIndex = 0;
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
            this.splitContainer3.Panel2.Controls.Add(this.dgvAccount);
            this.splitContainer3.Size = new System.Drawing.Size(813, 478);
            this.splitContainer3.SplitterDistance = 56;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.flowLayoutPanel7);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.label13);
            this.splitContainer4.Size = new System.Drawing.Size(813, 56);
            this.splitContainer4.SplitterDistance = 556;
            this.splitContainer4.TabIndex = 0;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel7.Controls.Add(this.label14);
            this.flowLayoutPanel7.Controls.Add(this.textBox2);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Padding = new System.Windows.Forms.Padding(20, 6, 5, 20);
            this.flowLayoutPanel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel7.Size = new System.Drawing.Size(556, 56);
            this.flowLayoutPanel7.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(23, 13);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 23);
            this.label14.TabIndex = 0;
            this.label14.Text = "Search:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(97, 9);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 30);
            this.textBox2.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(88, 12);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label13.Size = new System.Drawing.Size(189, 29);
            this.label13.TabIndex = 2;
            this.label13.Text = "Manage Bank Account";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.btnAddBank);
            this.flowLayoutPanel1.Controls.Add(this.btnEditAccount);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(117, 478);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnAddBank
            // 
            this.btnAddBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(121)))), ((int)(((byte)(247)))));
            this.btnAddBank.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddBank.ForeColor = System.Drawing.Color.White;
            this.btnAddBank.Location = new System.Drawing.Point(3, 3);
            this.btnAddBank.Name = "btnAddBank";
            this.btnAddBank.Size = new System.Drawing.Size(108, 37);
            this.btnAddBank.TabIndex = 1;
            this.btnAddBank.Text = "New";
            this.btnAddBank.UseVisualStyleBackColor = false;
            this.btnAddBank.Click += new System.EventHandler(this.btnAddBank_Click);
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEditAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditAccount.ForeColor = System.Drawing.Color.White;
            this.btnEditAccount.Location = new System.Drawing.Point(3, 46);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(108, 37);
            this.btnEditAccount.TabIndex = 2;
            this.btnEditAccount.Text = "Edit";
            this.btnEditAccount.UseVisualStyleBackColor = false;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(3, 89);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 37);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvAccount
            // 
            this.dgvAccount.AllowUserToAddRows = false;
            this.dgvAccount.AllowUserToDeleteRows = false;
            this.dgvAccount.AutoGenerateColumns = false;
            this.dgvAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccount.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAccount.BackgroundColor = System.Drawing.Color.White;
            this.dgvAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.bankAccNoDataGridViewTextBoxColumn,
            this.bankNameDataGridViewTextBoxColumn,
            this.bankAccNameDataGridViewTextBoxColumn,
            this.isTrashedDataGridViewCheckBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.dateModifiedDataGridViewTextBoxColumn});
            this.dgvAccount.DataSource = this.bankAccountBindingSource;
            this.dgvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccount.GridColor = System.Drawing.Color.Gray;
            this.dgvAccount.Location = new System.Drawing.Point(0, 0);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.ReadOnly = true;
            this.dgvAccount.Size = new System.Drawing.Size(813, 418);
            this.dgvAccount.TabIndex = 4;
            // 
            // eSMART_HMSDBDataSet
            // 
            this.eSMART_HMSDBDataSet.DataSetName = "ESMART_HMSDBDataSet";
            this.eSMART_HMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataMember = "BankAccount";
            this.bankAccountBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // bankAccountTableAdapter
            // 
            this.bankAccountTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // bankAccNoDataGridViewTextBoxColumn
            // 
            this.bankAccNoDataGridViewTextBoxColumn.DataPropertyName = "BankAccNo";
            this.bankAccNoDataGridViewTextBoxColumn.HeaderText = "Bank Acc No";
            this.bankAccNoDataGridViewTextBoxColumn.Name = "bankAccNoDataGridViewTextBoxColumn";
            this.bankAccNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bankNameDataGridViewTextBoxColumn
            // 
            this.bankNameDataGridViewTextBoxColumn.DataPropertyName = "BankName";
            this.bankNameDataGridViewTextBoxColumn.HeaderText = "Bank Name";
            this.bankNameDataGridViewTextBoxColumn.Name = "bankNameDataGridViewTextBoxColumn";
            this.bankNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bankAccNameDataGridViewTextBoxColumn
            // 
            this.bankAccNameDataGridViewTextBoxColumn.DataPropertyName = "BankAccName";
            this.bankAccNameDataGridViewTextBoxColumn.HeaderText = "Bank Acc Name";
            this.bankAccNameDataGridViewTextBoxColumn.Name = "bankAccNameDataGridViewTextBoxColumn";
            this.bankAccNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isTrashedDataGridViewCheckBoxColumn
            // 
            this.isTrashedDataGridViewCheckBoxColumn.DataPropertyName = "IsTrashed";
            this.isTrashedDataGridViewCheckBoxColumn.HeaderText = "IsTrashed";
            this.isTrashedDataGridViewCheckBoxColumn.Name = "isTrashedDataGridViewCheckBoxColumn";
            this.isTrashedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isTrashedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            this.createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.HeaderText = "Created By";
            this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            this.createdByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Date Created";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateModifiedDataGridViewTextBoxColumn
            // 
            this.dateModifiedDataGridViewTextBoxColumn.DataPropertyName = "DateModified";
            this.dateModifiedDataGridViewTextBoxColumn.HeaderText = "Date Modified";
            this.dateModifiedDataGridViewTextBoxColumn.Name = "dateModifiedDataGridViewTextBoxColumn";
            this.dateModifiedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BankAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 548);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BankAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Account";
            this.Load += new System.EventHandler(this.BankAccountForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.bankAccount.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage bankAccount;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddBank;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvAccount;
        private ESMART_HMSDBDataSet eSMART_HMSDBDataSet;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private ESMART_HMSDBDataSetTableAdapters.BankAccountTableAdapter bankAccountTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isTrashedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateModifiedDataGridViewTextBoxColumn;
    }
}