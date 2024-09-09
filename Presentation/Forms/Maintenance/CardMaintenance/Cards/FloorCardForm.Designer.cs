namespace ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards
{
    partial class FloorCardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloorCardForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listFloors = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToMinute = new System.Windows.Forms.NumericUpDown();
            this.txtToHour = new System.Windows.Forms.NumericUpDown();
            this.txtMinute = new System.Windows.Forms.NumericUpDown();
            this.txtHour = new System.Windows.Forms.NumericUpDown();
            this.cancleCard = new System.Windows.Forms.CheckBox();
            this.openLocks = new System.Windows.Forms.CheckBox();
            this.passageMode = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.comboBuilding = new System.Windows.Forms.ComboBox();
            this.eSMART_HMSDBDataSet = new ESMART_HMS.ESMART_HMSDBDataSet();
            this.buildingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buildingTableAdapter = new ESMART_HMS.ESMART_HMSDBDataSetTableAdapters.BuildingTableAdapter();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtToMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHour)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildingBindingSource)).BeginInit();
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
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainer1.Size = new System.Drawing.Size(774, 481);
            this.splitContainer1.SplitterDistance = 381;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(20);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainer2.Size = new System.Drawing.Size(774, 381);
            this.splitContainer2.SplitterDistance = 281;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.comboBuilding);
            this.panel2.Controls.Add(this.listFloors);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 341);
            this.panel2.TabIndex = 0;
            // 
            // listFloors
            // 
            this.listFloors.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listFloors.FormattingEnabled = true;
            this.listFloors.Location = new System.Drawing.Point(21, 105);
            this.listFloors.Name = "listFloors";
            this.listFloors.Size = new System.Drawing.Size(196, 220);
            this.listFloors.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "All Floors";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtToMinute);
            this.panel1.Controls.Add(this.txtToHour);
            this.panel1.Controls.Add(this.txtMinute);
            this.panel1.Controls.Add(this.txtHour);
            this.panel1.Controls.Add(this.cancleCard);
            this.panel1.Controls.Add(this.openLocks);
            this.panel1.Controls.Add(this.passageMode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 341);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(331, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(129, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(248, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "From";
            // 
            // txtToMinute
            // 
            this.txtToMinute.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToMinute.Location = new System.Drawing.Point(348, 60);
            this.txtToMinute.Name = "txtToMinute";
            this.txtToMinute.Size = new System.Drawing.Size(49, 25);
            this.txtToMinute.TabIndex = 8;
            this.txtToMinute.ValueChanged += new System.EventHandler(this.txtToMinute_ValueChanged);
            // 
            // txtToHour
            // 
            this.txtToHour.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToHour.Location = new System.Drawing.Point(278, 60);
            this.txtToHour.Name = "txtToHour";
            this.txtToHour.Size = new System.Drawing.Size(49, 25);
            this.txtToHour.TabIndex = 8;
            this.txtToHour.ValueChanged += new System.EventHandler(this.txtToHour_ValueChanged);
            // 
            // txtMinute
            // 
            this.txtMinute.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinute.Location = new System.Drawing.Point(146, 58);
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.Size = new System.Drawing.Size(49, 25);
            this.txtMinute.TabIndex = 8;
            this.txtMinute.ValueChanged += new System.EventHandler(this.txtMinute_ValueChanged);
            // 
            // txtHour
            // 
            this.txtHour.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHour.Location = new System.Drawing.Point(76, 58);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(49, 25);
            this.txtHour.TabIndex = 8;
            this.txtHour.ValueChanged += new System.EventHandler(this.txtHour_ValueChanged);
            // 
            // cancleCard
            // 
            this.cancleCard.AutoSize = true;
            this.cancleCard.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancleCard.Location = new System.Drawing.Point(33, 233);
            this.cancleCard.Name = "cancleCard";
            this.cancleCard.Size = new System.Drawing.Size(139, 24);
            this.cancleCard.TabIndex = 5;
            this.cancleCard.Text = "Cancle old cards";
            this.cancleCard.UseVisualStyleBackColor = true;
            // 
            // openLocks
            // 
            this.openLocks.AutoSize = true;
            this.openLocks.Checked = true;
            this.openLocks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openLocks.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openLocks.Location = new System.Drawing.Point(33, 191);
            this.openLocks.Name = "openLocks";
            this.openLocks.Size = new System.Drawing.Size(165, 24);
            this.openLocks.TabIndex = 6;
            this.openLocks.Text = "Can open deadlocks";
            this.openLocks.UseVisualStyleBackColor = true;
            // 
            // passageMode
            // 
            this.passageMode.AutoSize = true;
            this.passageMode.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passageMode.Location = new System.Drawing.Point(34, 146);
            this.passageMode.Name = "passageMode";
            this.passageMode.Size = new System.Drawing.Size(126, 24);
            this.passageMode.TabIndex = 7;
            this.passageMode.Text = "Passage Mode";
            this.passageMode.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnIssue);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(734, 56);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.White;
            this.btnIssue.Location = new System.Drawing.Point(608, 8);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(111, 38);
            this.btnIssue.TabIndex = 0;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // comboBuilding
            // 
            this.comboBuilding.DataSource = this.buildingBindingSource;
            this.comboBuilding.DisplayMember = "BuildingName";
            this.comboBuilding.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBuilding.FormattingEnabled = true;
            this.comboBuilding.Location = new System.Drawing.Point(21, 48);
            this.comboBuilding.Name = "comboBuilding";
            this.comboBuilding.Size = new System.Drawing.Size(196, 28);
            this.comboBuilding.TabIndex = 2;
            this.comboBuilding.ValueMember = "Id";
            this.comboBuilding.SelectedValueChanged += new System.EventHandler(this.comboBuilding_SelectedValueChanged);
            // 
            // eSMART_HMSDBDataSet
            // 
            this.eSMART_HMSDBDataSet.DataSetName = "ESMART_HMSDBDataSet";
            this.eSMART_HMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buildingBindingSource
            // 
            this.buildingBindingSource.DataMember = "Building";
            this.buildingBindingSource.DataSource = this.eSMART_HMSDBDataSet;
            // 
            // buildingTableAdapter
            // 
            this.buildingTableAdapter.ClearBeforeFill = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pick floor based on selected building";
            // 
            // FloorCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(774, 481);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FloorCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Floor Card";
            this.Load += new System.EventHandler(this.FloorCardForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtToMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHour)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eSMART_HMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox listFloors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cancleCard;
        private System.Windows.Forms.CheckBox openLocks;
        private System.Windows.Forms.CheckBox passageMode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtMinute;
        private System.Windows.Forms.NumericUpDown txtHour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtToMinute;
        private System.Windows.Forms.NumericUpDown txtToHour;
        private System.Windows.Forms.ComboBox comboBuilding;
        private ESMART_HMSDBDataSet eSMART_HMSDBDataSet;
        private System.Windows.Forms.BindingSource buildingBindingSource;
        private ESMART_HMSDBDataSetTableAdapters.BuildingTableAdapter buildingTableAdapter;
        private System.Windows.Forms.Label label6;
    }
}