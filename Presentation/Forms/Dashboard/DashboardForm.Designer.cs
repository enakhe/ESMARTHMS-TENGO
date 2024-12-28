namespace ESMART_HMS.Presentation.Forms
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.statusIndicatorPanel = new System.Windows.Forms.Panel();
            this.mainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // statusIndicatorPanel
            // 
            this.statusIndicatorPanel.BackColor = System.Drawing.Color.Transparent;
            this.statusIndicatorPanel.Location = new System.Drawing.Point(12, 174);
            this.statusIndicatorPanel.Name = "statusIndicatorPanel";
            this.statusIndicatorPanel.Size = new System.Drawing.Size(200, 50);
            this.statusIndicatorPanel.TabIndex = 2;
            this.statusIndicatorPanel.Visible = false;
            // 
            // mainFlowLayoutPanel
            // 
            this.mainFlowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainFlowLayoutPanel.Location = new System.Drawing.Point(12, 241);
            this.mainFlowLayoutPanel.Name = "mainFlowLayoutPanel";
            this.mainFlowLayoutPanel.Size = new System.Drawing.Size(200, 100);
            this.mainFlowLayoutPanel.TabIndex = 1;
            this.mainFlowLayoutPanel.Visible = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1832, 831);
            this.Controls.Add(this.statusIndicatorPanel);
            this.Controls.Add(this.mainFlowLayoutPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashboardForm";
            this.Text = "IndexForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel statusIndicatorPanel;
        private System.Windows.Forms.FlowLayoutPanel mainFlowLayoutPanel;
    }
}