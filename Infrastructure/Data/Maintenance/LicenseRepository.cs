using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data.Maintenance
{
    public class LicenseRepository : ILicenseRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public LicenseRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddLicence(LicenseInfo licenseInfo)
        {
            try
            {
                var existingLicenses = _db.LicenseInfoes.ToList();
                if (existingLicenses.Any())
                {
                    _db.LicenseInfoes.RemoveRange(existingLicenses);
                    _db.SaveChanges();
                }

                _db.LicenseInfoes.Add(licenseInfo);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public LicenseInfo GetLicenseInfo()
        {
            try
            {
                return _db.LicenseInfoes.FirstOrDefault();
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
