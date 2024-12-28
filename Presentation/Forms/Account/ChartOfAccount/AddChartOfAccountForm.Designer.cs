namespace ESMART_HMS.Presentation.Forms.Account.ChartOfAccount
{
    partial class AddChartOfAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddChartOfAccountForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAccName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccType = new System.Windows.Forms.ComboBox();
            this.txtRollTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checckRollBalance = new System.Windows.Forms.CheckBox();
            this.checkCashFlowAcc = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(128, 525);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 41);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAccName
            // 
            this.txtAccName.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccName.Location = new System.Drawing.Point(28, 178);
            this.txtAccName.Margin = new System.Windows.Forms.Padding(2);
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.Size = new System.Drawing.Size(360, 31);
            this.txtAccName.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 235);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Acc Group";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "Acc Name";
            // 
            // txtAccCode
            // 
            this.txtAccCode.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccCode.Location = new System.Drawing.Point(27, 100);
            this.txtAccCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtAccCode.Name = "txtAccCode";
            this.txtAccCode.Size = new System.Drawing.Size(149, 31);
            this.txtAccCode.TabIndex = 24;
            this.txtAccCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccCode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "Acc Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 30);
            this.label1.TabIndex = 22;
            this.label1.Text = "Add Chart of Account";
            // 
            // txtAccGroup
            // 
            this.txtAccGroup.Font = new System.Drawing.Font("Segoe UI", 13.2F);
            this.txtAccGroup.FormattingEnabled = true;
            this.txtAccGroup.Items.AddRange(new object[] {
            "CURRENT ASSETS",
            "NON CURRENT ASSETS",
            "INTANGIBLE ASSETS",
            "CURRENT LIABILITY",
            "LONG TERM LIABILITY",
            "EQUITY",
            "INCOME",
            "COST OF SALES",
            "EXPESES",
            "OTHER INCOME",
            "OTHER EXPESES"});
            this.txtAccGroup.Location = new System.Drawing.Point(28, 261);
            this.txtAccGroup.Name = "txtAccGroup";
            this.txtAccGroup.Size = new System.Drawing.Size(360, 33);
            this.txtAccGroup.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 320);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 25;
            this.label4.Text = "Acc Type";
            // 
            // txtAccType
            // 
            this.txtAccType.Font = new System.Drawing.Font("Segoe UI", 13.2F);
            this.txtAccType.FormattingEnabled = true;
            this.txtAccType.Items.AddRange(new object[] {
            "TITLE ACCOUNT (NON POSTING)",
            "HEADING ACCOUNT (NON POSTING)",
            "POSTING ACCOUNT"});
            this.txtAccType.Location = new System.Drawing.Point(28, 346);
            this.txtAccType.Name = "txtAccType";
            this.txtAccType.Size = new System.Drawing.Size(360, 33);
            this.txtAccType.TabIndex = 29;
            // 
            // txtRollTo
            // 
            this.txtRollTo.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRollTo.Location = new System.Drawing.Point(27, 433);
            this.txtRollTo.Margin = new System.Windows.Forms.Padding(2);
            this.txtRollTo.Name = "txtRollTo";
            this.txtRollTo.Size = new System.Drawing.Size(149, 31);
            this.txtRollTo.TabIndex = 31;
            this.txtRollTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRollTo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 406);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 30;
            this.label6.Text = "Roll To";
            // 
            // checckRollBalance
            // 
            this.checckRollBalance.AutoSize = true;
            this.checckRollBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checckRollBalance.Location = new System.Drawing.Point(28, 484);
            this.checckRollBalance.Name = "checckRollBalance";
            this.checckRollBalance.Size = new System.Drawing.Size(99, 21);
            this.checckRollBalance.TabIndex = 32;
            this.checckRollBalance.Text = "Roll Balance";
            this.checckRollBalance.UseVisualStyleBackColor = true;
            // 
            // checkCashFlowAcc
            // 
            this.checkCashFlowAcc.AutoSize = true;
            this.checkCashFlowAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCashFlowAcc.Location = new System.Drawing.Point(148, 484);
            this.checkCashFlowAcc.Name = "checkCashFlowAcc";
            this.checkCashFlowAcc.Size = new System.Drawing.Size(135, 21);
            this.checkCashFlowAcc.TabIndex = 32;
            this.checkCashFlowAcc.Text = "Cashflow Account";
            this.checkCashFlowAcc.UseVisualStyleBackColor = true;
            // 
            // AddChartOfAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 574);
            this.Controls.Add(this.checkCashFlowAcc);
            this.Controls.Add(this.checckRollBalance);
            this.Controls.Add(this.txtRollTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAccType);
            this.Controls.Add(this.txtAccGroup);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAccName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAccCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddChartOfAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Chart Of Account";
            this.Load += new System.EventHandler(this.AddChartOfAccountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAccName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAccCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtAccGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtAccType;
        private System.Windows.Forms.TextBox txtRollTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checckRollBalance;
        private System.Windows.Forms.CheckBox checkCashFlowAcc;
    }
}