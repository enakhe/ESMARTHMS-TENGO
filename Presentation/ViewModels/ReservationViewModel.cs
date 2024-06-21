using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.ViewModels
{
    public class ReservationViewModel
    {
        public string Id { get; set; }
        public string ReservationId { get; set; }
        public string CustomerId { get; set; }
        public string RoomId { get; set; }
        public string Customer { get; set; }
        public string CustomerPhoneNo { get; set; }
        public string Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string PaymentMethod { get; set; }
        public string ReservationRefNo { get; set; }
        public decimal Amount { get; set; } 
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
