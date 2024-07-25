using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IConfigurationRepository
    {
        void SetConfigurationValue(string key, string value);
        Configuration GetConfigurationValue(string key);
    }
}
