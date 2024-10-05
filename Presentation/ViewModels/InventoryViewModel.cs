namespace ESMART_HMS.Presentation.ViewModels
{
    public class InventoryViewModel
    {
        public string Id { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public string CostPrice { get; set; }
        public string SellingPrice { get; set; }
        public string Quantity { get; set; }
        public string InitialStock { get; set; }
        public string CurrentStock { get; set; }
        public string LowStockThreshold { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
    }
}
