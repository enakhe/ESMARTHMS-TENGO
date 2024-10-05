using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ESMART_HMS.Presentation.Forms.Transaction
{
    public partial class TransactionForm : Form
    {
        private readonly TransactionController _transactionController;
        private DispatcherTimer dispatcherTimer;
        public TransactionForm(TransactionController transactionController)
        {
            _transactionController = transactionController;
            InitializeComponent();
            LoadData();
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
            dgvTransaction.CellFormatting += DataGridViewRooms_CellFormatting;
            LoadData();
        }

        private void TransactionForm_Load(object sender, System.EventArgs e)
        {
            dispatcherTimer.Start();
            LoadData();
            splitContainer21.SplitterWidth = 1;
            splitContainer21.BackColor = splitContainer21.Panel1.BackColor;
            dgvTransaction.Font = new System.Drawing.Font("Segoe UI", 10); 
            dgvTransaction.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        public void LoadData()
        {
            List<TransactionViewModel> allTransaction = _transactionController.GetAllTransactions();
            if (allTransaction != null)
            {
                foreach (var transaction in allTransaction)
                {
                    transaction.Amount = FormHelper.FormatNumberWithCommas(decimal.Parse(transaction.Amount));
                    transaction.Date = FormHelper.FormatDateTimeWithSuffix(transaction.Date);
                }
                dgvTransaction.DataSource = allTransaction;
                txtCount.Text = _transactionController.GetAllTransactions().Count.ToString();
                var totalAmount = _transactionController.GetTotalAmount();
                if (totalAmount != null)
                {
                    txtToalAmount.Text = FormHelper.FormatNumberWithCommas(totalAmount[0]);
                    txtReceivables.Text = FormHelper.FormatNumberWithCommas(totalAmount[1]);
                }
            }
        }

        private void DataGridViewRooms_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTransaction.Columns[e.ColumnIndex].Name == "statusDataGridViewTextBoxColumn")
            {
                var cell = dgvTransaction.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null && cell.Value.ToString() == "Paid")
                {
                    cell.Style.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    cell.Style.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
