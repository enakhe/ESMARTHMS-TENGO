using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace ESMART_HMS.Presentation.Middleware
{
    public static class AuthorizationMiddleware
    {
        public static bool IsAuthorized(ApplicationUser user, List<string> roles)
        {
            using (ESMART_HMSDBEntities db = new ESMART_HMSDBEntities())
            {
                UserRoleRepository userRoleRepository = new UserRoleRepository(db);
                return roles.Any(role => userRoleRepository.IsInRole(user, role));
            }
        }

        public static void Protect(ApplicationUser user, ToolStripMenuItem control, List<string> requiredRoles)
        {
            if (!IsAuthorized(user, requiredRoles))
            {
                control.Visible = false;
            }
            else
            {
                control.Visible = true;
            }
        }

        public static void ProtectControl(ApplicationUser user, Control control, List<string> requiredRoles)
        {
            if (!IsAuthorized(user, requiredRoles))
            {
                control.Visible = false;
            }
            else
            {
                control.Visible = true;
            }
        }
    }
}
