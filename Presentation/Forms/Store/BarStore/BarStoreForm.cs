using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Reservation;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Store.BarStore
{
    public partial class BarStoreForm : Form
    {
        private readonly BarItemController _barItemController;
        public BarStoreForm(BarItemController barItemController)
        {
            _barItemController = barItemController;
            InitializeComponent();
        }

        private void BarStoreForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                List<BarItemViewModel> allBarItems = _barItemController.GetAllBarItem();
                if (allBarItems != null)
                {
                    foreach (var items in allBarItems)
                    {
                        FormHelper.TryConvertStringToDecimal(items.CostPrice, out decimal costPrice);
                        FormHelper.TryConvertStringToDecimal(items.SellingPrice, out decimal sellingPrice);

                        items.CostPrice = FormHelper.FormatNumberWithCommas(costPrice);
                        items.SellingPrice = FormHelper.FormatNumberWithCommas(sellingPrice);
                    }
                    dgvBarStore.DataSource = allBarItems;
                    txtCount.Text = allBarItems.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddBarItemForm addBarItemForm = serviceProvider.GetRequiredService<AddBarItemForm>();
            if (addBarItemForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
