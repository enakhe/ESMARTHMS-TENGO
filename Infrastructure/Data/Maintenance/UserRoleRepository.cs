using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public UserRoleRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AssignUserToRole(ApplicationUserRole userRole)
        {
            try
            {
                _db.ApplicationUserRoles.Add(userRole);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public bool IsInRole(ApplicationUser user, string title)
        {
            try
            {
                ApplicationUserRole applicationUserRole = _db.ApplicationUserRoles.FirstOrDefault(ur => ur.Role.Title == title && ur.ApplicationUser.Id == user.Id);
                if (applicationUserRole != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return false;
        }

        public void UpdateUserRole(ApplicationUserRole userRole)
        {
            try
            {
                _db.Entry(userRole).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when updating user role", ex);
            }
        }

        public ApplicationUserRole FindUserRole(string id)
        {
            try
            {
                return _db.ApplicationUserRoles.FirstOrDefault(uR => uR.ApplicationUser.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when getting user role", ex);
            }
        }
    }
}
