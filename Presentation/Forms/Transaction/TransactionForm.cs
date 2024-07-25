using ESMART_HMS.Domain.Entities;
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
            this.transactionTableAdapter.Fill(this.eSMART_HMSDBDataSet.Transaction);

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
            }
        }
    }
}
