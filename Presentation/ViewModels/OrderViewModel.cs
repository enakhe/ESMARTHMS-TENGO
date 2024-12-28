using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.ViewModels
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string Item { get; set; }
        public string Customer { get; set; }
        public string Quantity { get; set; }
        public string TotalAmount { get; set; }
        public string OrderDate { get; set; }
        public string IssuedBy { get; set; }
    }
}
