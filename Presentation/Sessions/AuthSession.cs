using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Presentation.Sessions
{
    public static class AuthSession
    {
        public static ApplicationUser CurrentUser { get; set; }
    }
}
