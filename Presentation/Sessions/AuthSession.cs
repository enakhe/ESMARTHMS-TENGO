using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.Sessions
{
    public static class AuthSession
    {
       public static ApplicationUser CurrentUser { get; set; }
    }
}
