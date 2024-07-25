using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Infrastructure.Data;
using ESMART_HMS.Presentation.Sessions;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Middleware
{
    public static class AuthorizationMiddleware
    {
        public static bool IsAuthorized(ApplicationUser user, string title)
        {
            using (ESMART_HMSDBEntities db = new ESMART_HMSDBEntities())
            {
                UserRoleRepository userRoleRepository = new UserRoleRepository(db);
                return userRoleRepository.IsInRole(user, title);
            }
        }

        public static void Protect(ApplicationUser user, Control control, string requiredRole)
        {
            if (!IsAuthorized(user, requiredRole))
            {
                control.Enabled = false;
            }
        }
    }
}
