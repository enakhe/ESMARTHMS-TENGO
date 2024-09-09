namespace ESMART_HMS.Presentation.ViewModels
{
    public class SpecialCardViewModel
    {
        public string Id { get; set; }
        public string CardNo { get; set; }
        public string CardType { get; set; }
        public System.DateTime IssueTime { get; set; }
        public System.DateTime RefundTime { get; set; }
        public string IssuedBy { get; set; }
        public bool CanOpenDeadLocks { get; set; }
        public bool PassageMode { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    }
}
