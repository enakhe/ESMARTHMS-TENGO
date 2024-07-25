using System;

namespace ESMART_HMS.Presentation.ViewModels
{
    public class BookingViewModel
    {
        public string Id { get; set; }
        public string BookingId { get; set; }
        public string Guest { get; set; }
        public string GuestPhoneNo { get; set; }
        public string Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Duration { get; set; }
        public string TotalAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
