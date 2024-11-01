using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Infrastructure.Data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ESMART_HMSDBEntities _db;
        public RoleRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddRole(Role role)
        {
            try
            {
                _db.Roles.Add(role);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
