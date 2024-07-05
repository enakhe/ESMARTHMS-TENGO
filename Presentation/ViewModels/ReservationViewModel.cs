using System;

namespace ESMART_HMS.Presentation.ViewModels
{
    public class ReservationViewModel
    {
        public string Id { get; set; }
        public string ReservationId { get; set; }
        public string GuestId { get; set; }
        public string RoomId { get; set; }
        public string Guest { get; set; }
        public string GuestPhoneNo { get; set; }
        public string Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string PaymentMethod { get; set; }
        public string ReservationRefNo { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
