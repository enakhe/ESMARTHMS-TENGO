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
