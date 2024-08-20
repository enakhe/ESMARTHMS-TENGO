namespace ESMART_HMS.Presentation.ViewModels
{
    public class IssueCardViewModel
    {
        public string Id { get; set; }
        public string Room { get; set; }
        public int CardQuantity { get; set; } = 1;
        public string RoomType { get; set; }
        public string Amount { get; set; }
        public string Floor { get; set; }
    }
}
