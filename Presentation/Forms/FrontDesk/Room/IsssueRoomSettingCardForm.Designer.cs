namespace ESMART_HMS.Presentation.Forms.FrontDesk.Room
{
    partial class IsssueRoomSettingCardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsssueRoomSettingCardForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRecycle = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.txtArea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.areaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.areaTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.AreaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaBindingSource)).BeginInit();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(20);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainer1.Size = new System.Drawing.Size(374, 518);
            this.splitContainer1.SplitterDistance = 404;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtArea);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(334, 364);
            this.panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnRecycle);
            this.flowLayoutPanel1.Controls.Add(this.btnIssue);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(334, 70);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnRecycle
            // 
            this.btnRecycle.BackColor = System.Drawing.Color.Red;
            this.btnRecycle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecycle.ForeColor = System.Drawing.Color.White;
            this.btnRecycle.Location = new System.Drawing.Point(13, 13);
            this.btnRecycle.Name = "btnRecycle";
            this.btnRecycle.Size = new System.Drawing.Size(151, 42);
            this.btnRecycle.TabIndex = 0;
            this.btnRecycle.Text = "Recycle";
            this.btnRecycle.UseVisualStyleBackColor = false;
            this.btnRecycle.Click += new System.EventHandler(this.btnRecycle_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.White;
            this.btnIssue.Location = new System.Drawing.Point(170, 13);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(137, 42);
            this.btnIssue.TabIndex = 0;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // txtArea
            // 
            this.txtArea.DataSource = this.areaBindingSource;
            this.txtArea.DisplayMember = "AreaName";
            this.txtArea.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.FormattingEnabled = true;
            this.txtArea.Location = new System.Drawing.Point(14, 49);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(305, 31);
            this.txtArea.TabIndex = 0;
            this.txtArea.ValueMember = "AreaNo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Area";
            // 
            // eSMART_HMSDBDataSet
            // 
            this.eSMART_HMSDBDataSet.DataSetName = "ESMART_HMSDBDataSet";
            this.eSMART_HMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // areaBindingSource
            // 
            this.areaBindingSource.DataMember = "Area";
            this.areaBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // areaTableAdapter
            // 
            this.areaTableAdapter.ClearBeforeFill = true;
            // 
            // IsssueRoomSettingCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 518);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IsssueRoomSettingCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Setting Card";
            this.Load += new System.EventHandler(this.IsssueRoomSettingCardForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnRecycle;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtArea;
        private ESMART_HMSDBDataSet eSMART_HMSDBDataSet;
        private System.Windows.Forms.BindingSource areaBindingSource;
        private ESMART_HMSDBDataSetTableAdapters.AreaTableAdapter areaTableAdapter;
    }
}