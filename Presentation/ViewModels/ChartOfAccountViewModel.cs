using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.ViewModels
{
    public class ChartOfAccountViewModel
    {
        public string Id { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountGroup { get; set; }
        public string RollTo { get; set; }
        public bool RollBalance { get; set; }
        public bool CashflowAccount { get; set; }
        public bool IsActive { get; set; }
        public bool IsTrashed { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
    }
}
