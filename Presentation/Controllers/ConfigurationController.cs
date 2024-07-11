using ESMART_HMS.Application.UseCases.Configuration;
using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.Controllers
{
    public class ConfigurationController
    {
        private readonly SetConfigurationValueUseCase _setConfigurationValueUseCase;
        private readonly GetConfigurationValueUseCase _getConfigurationValueUseCase;

        public ConfigurationController(SetConfigurationValueUseCase setConfigurationValueUseCase, GetConfigurationValueUseCase getConfigurationValueUseCase)
        {
            _setConfigurationValueUseCase = setConfigurationValueUseCase;
            _getConfigurationValueUseCase = getConfigurationValueUseCase;
        }

        public void SetConfigurationValue(string key, string value)
        {
            _setConfigurationValueUseCase.Execute(key, value);
        }

        public Configuration GetConfigurationValue(string key) 
        { 
            return _getConfigurationValueUseCase.Execute(key);
        }
    }
}
