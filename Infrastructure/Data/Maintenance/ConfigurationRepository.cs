﻿using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public ConfigurationRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddConfiguration(Configuration configuration)
        {
            try
            {
                _db.Configurations.Add(configuration);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public void SetConfigurationValue(string key, string value)
        {
            try
            {
                Configuration configuration = _db.Configurations.FirstOrDefault(c => c.Key == key);
                if (configuration != null)
                {
                    configuration.Value = value;
                    _db.Entry(configuration).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    MessageBox.Show($"Unable to load resource", "Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public Configuration GetConfigurationValue(string key)
        {
            try
            {
                return _db.Configurations.FirstOrDefault(c => c.Key == key);
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
