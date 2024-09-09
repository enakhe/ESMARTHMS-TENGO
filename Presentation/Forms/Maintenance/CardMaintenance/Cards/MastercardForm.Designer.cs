namespace ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards
{
    partial class MastercardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MastercardForm));
            this.passageMode = new System.Windows.Forms.CheckBox();
            this.openLocks = new System.Windows.Forms.CheckBox();
            this.cancleCard = new System.Windows.Forms.CheckBox();
            this.btnIssue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // passageMode
            // 
            this.passageMode.AutoSize = true;
            this.passageMode.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passageMode.Location = new System.Drawing.Point(31, 135);
            this.passageMode.Name = "passageMode";
            this.passageMode.Size = new System.Drawing.Size(126, 24);
            this.passageMode.TabIndex = 2;
            this.passageMode.Text = "Passage Mode";
            this.passageMode.UseVisualStyleBackColor = true;
            // 
            // openLocks
            // 
            this.openLocks.AutoSize = true;
            this.openLocks.Checked = true;
            this.openLocks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openLocks.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openLocks.Location = new System.Drawing.Point(31, 180);
            this.openLocks.Name = "openLocks";
            this.openLocks.Size = new System.Drawing.Size(165, 24);
            this.openLocks.TabIndex = 2;
            this.openLocks.Text = "Can open deadlocks";
            this.openLocks.UseVisualStyleBackColor = true;
            // 
            // cancleCard
            // 
            this.cancleCard.AutoSize = true;
            this.cancleCard.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancleCard.Location = new System.Drawing.Point(31, 222);
            this.cancleCard.Name = "cancleCard";
            this.cancleCard.Size = new System.Drawing.Size(139, 24);
            this.cancleCard.TabIndex = 2;
            this.cancleCard.Text = "Cancle old cards";
            this.cancleCard.UseVisualStyleBackColor = true;
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.White;
            this.btnIssue.Location = new System.Drawing.Point(176, 335);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(94, 29);
            this.btnIssue.TabIndex = 3;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valid Time";
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(128, 65);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(285, 30);
            this.txtTime.TabIndex = 1;
            // 
            // MastercardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(455, 376);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.cancleCard);
            this.Controls.Add(this.openLocks);
            this.Controls.Add(this.passageMode);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MastercardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Card";
            this.Load += new System.EventHandler(this.MastercardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox passageMode;
        private System.Windows.Forms.CheckBox openLocks;
        private System.Windows.Forms.CheckBox cancleCard;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtTime;
    }
}