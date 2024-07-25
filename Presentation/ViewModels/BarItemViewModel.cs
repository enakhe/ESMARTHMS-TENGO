using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.ViewModels
{
    public class BarItemViewModel
    {
        public string Id { get; set; }
        public string BarItemId { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public string Type { get; set; }
        public string Measurement { get; set; }
        public string CreatedBy { get; set; }
        public string CostPrice { get; set; }
        public string SellingPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
