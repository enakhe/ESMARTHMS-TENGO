using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Transaction
{
    public partial class TransactionForm : Form
    {
        private readonly TransactionController _transactionController;
        public TransactionForm(TransactionController transactionController)
        {
            InitializeComponent();
            _transactionController = transactionController;
        }

        private void TransactionForm_Load(object sender, System.EventArgs e)
        {
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
                }
                dgvTransaction.DataSource = allTransaction;
                dgvTransaction.CellFormatting += DataGridViewRooms_CellFormatting;
            }
        }

        private void DataGridViewRooms_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTransaction.Columns[e.ColumnIndex].Name == "Status")
            {
                var cell = dgvTransaction.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null && cell.Value.ToString() == "Paid")
                {
                    cell.Style.BackColor = System.Drawing.Color.Green;
                    cell.Style.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    cell.Style.BackColor = System.Drawing.Color.Red;
                    cell.Style.ForeColor = System.Drawing.Color.White;
                }
            }
        }
    }
}
