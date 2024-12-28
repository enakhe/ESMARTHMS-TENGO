using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESMART_HMS.Presentation.Forms.Report
{
    public partial class TransactionReport : Form
    {
        private readonly TransactionController _transactionController;
        private DispatcherTimer dispatcherTimer;
        public TransactionReport(TransactionController transactionController)
        {
            _transactionController = transactionController; 
            InitializeComponent();
            InitializeTimer();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        }

        private void InitializeTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            string status = txtStatus.SelectedItem?.ToString();
            DateTime from = txtFrom.Value;
            DateTime to = txtTo.Value;

            if (status != null)
            {
                if (status == "All")
                {
                    GetByFilterDate(from, to);
                }
                else
                {
                    GetByFilter(status, from, to);
                }
            }

        }

        private void TransactionReport_Load(object sender, EventArgs e)
        {
            dispatcherTimer.Start();

            txtFrom.Value = DateTime.Now;
            txtTo.Value = DateTime.Now;
            dgvTransaction.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvTransaction.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        public void GetByFilter(string status, DateTime from, DateTime to)
        {
            List<TransactionViewModel> filteredTransactions = _transactionController.GetByFilter(status, from, to);
            if (filteredTransactions != null)
            {
                foreach (var transaction in filteredTransactions)
                {
                    transaction.Amount = FormHelper.FormatNumberWithCommas(decimal.Parse(transaction.Amount));

                    transaction.Date = FormHelper.FormatDateTimeWithSuffix(transaction.Date);
                }
                dgvTransaction.DataSource = filteredTransactions;
            }
        }

        public void GetByFilterDate(DateTime from, DateTime to)
        {
            List<TransactionViewModel> filteredTransactions = _transactionController.GetByFilterDate(from, to);
            if (filteredTransactions != null)
            {
                foreach (var transaction in filteredTransactions)
                {
                    transaction.Amount = FormHelper.FormatNumberWithCommas(decimal.Parse(transaction.Amount));

                    transaction.Date = FormHelper.FormatDateTimeWithSuffix(transaction.Date);
                }
                dgvTransaction.DataSource = filteredTransactions;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportsForm exportForm = new ExportsForm(dgvTransaction);
            exportForm.ShowDialog();
        }
    }
}
