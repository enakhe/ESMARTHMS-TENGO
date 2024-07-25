using System;

namespace ESMART_HMS.Presentation.ViewModels
{
    public class TransactionViewModel
    {
        public string TransactionId { get; set; }
        public string Guest { get; set; }
        public string GuestPhoneNo { get; set; }
        public string BookingId { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
