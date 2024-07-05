using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class GuestRepository : IGuestRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public GuestRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddGuest(Guest customer)
        {
            try
            {
                _db.Guests.Add(customer);
                _db.SaveChanges();
                MessageBox.Show("Successfully added customer information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<Guest> GetAllGuests()
        {
            try
            {
                List<Guest> allGuests = _db.Guests.Where(c => c.IsTrashed != true).OrderBy(g => g.FullName).ToList<Guest>();
                return allGuests;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public Guest GetGuestById(string Id)
        {
            try
            {
                var Guest = _db.Guests.FirstOrDefault(c => c.Id == Id);
                if (Guest == null)
                {
                    MessageBox.Show("Guest not found", "Not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    return Guest;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void UpdateGuest(Guest customer)
        {
            try
            {
                _db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                MessageBox.Show("Successfully edited customer information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public void DeleteGuest(string Id)
        {
            try
            {
                var customer = _db.Guests.FirstOrDefault(c => c.Id == Id);
                if (customer != null)
                {
                    customer.IsTrashed = true;
                    _db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Guest not found", "Not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<Guest> SearchGuest(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Keyword cannot be empty", "Invalid Entry", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }

                List<Guest> searchGuest = _db.Guests.Where(c => c.FullName.Contains(keyword) || c.Email.Contains(keyword) || c.PhoneNumber.Contains(keyword) || c.Street.Contains(keyword) || c.City.Contains(keyword) || c.State.Contains(keyword) || c.Country.Contains(keyword) || c.GuestId.Contains(keyword) || c.Company.Contains(keyword)).OrderBy(g => g.FullName).ToList();

                return searchGuest;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

            return null;
        }

        public List<Guest> GetDeletedGuest()
        {
            try
            {
                return _db.Guests.Where(c => c.IsTrashed == true).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
