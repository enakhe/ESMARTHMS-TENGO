using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<RoleViewModel> GetAllRole()
        {
            try
            {
                var allRoles = _db.Roles
                                      .Where(r => !r.IsTrashed && r.Title != "SuperAdmin" && r.Title != "Admin")
                                      .OrderBy(u => u.Title)
                                      .Select(role => new RoleViewModel
                                      {
                                          Id = role.Id,
                                          Title = role.Title,
                                          Description = role.Description,
                                          DateCreated = role.DateCreated.ToString(),
                                          DateModified = role.DateModified.ToString()
                                      })
                                      .ToList();
                return allRoles;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when getting all roles", ex);
            }
        }

        public Role GetRoleById(string Id)
        {
            try
            {
                Role role = _db.Roles.FirstOrDefault(r => r.Id == Id);
                return role;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when getting role", ex);
            }
        }

        public void UpdateRole(Role role)
        {
            try
            {
                _db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when editing role", ex);
            }
        }

        public void DeleteRole(string id)
        {
            try
            {
                Role role = _db.Roles.FirstOrDefault(r => r.Id == id);
                if (role != null)
                {
                    role.IsTrashed = true;
                    _db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when getting role", ex);
            }
        }
    }
}
