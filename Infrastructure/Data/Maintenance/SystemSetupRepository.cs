using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data.Maintenance
{
    public class SystemSetupRepository : ISystemSetupRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public SystemSetupRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void SetupCompanyInfo(CompanyInformation companyInformation)
        {
            try
            {
                CompanyInformation foundCompanyInfo = _db.CompanyInformations.FirstOrDefault(cI => cI.Id == companyInformation.Id);

                if (foundCompanyInfo == null)
                {
                    _db.CompanyInformations.Add(companyInformation);
                    _db.SaveChanges();
                    MessageBox.Show("Successfully added company information", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                }
                else
                {
                    if (companyInformation.Logo == null)
                    {
                        companyInformation.Logo = foundCompanyInfo.Logo;
                    }
                    _db.Entry(companyInformation).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    MessageBox.Show("Successfully updated company information", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public CompanyInformation GetCompanyInfo()
        {
            try
            {
                return _db.CompanyInformations.FirstOrDefault();
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
