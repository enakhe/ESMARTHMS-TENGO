namespace ESMART_HMS.Presentation.ViewModels
{
    public class RoomViewModel
    {
        public string Id { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomCardNo { get; set; }
        public string RoomLockNo { get; set; }
        public string RoomTypeName { get; set; }
        public int AdultPerRoom { get; set; }
        public int ChildrenPerRoom { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public bool IsAvailable { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    }
}
