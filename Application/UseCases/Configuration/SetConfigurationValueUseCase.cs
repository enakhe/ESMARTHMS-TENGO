using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Configuration
{
    public class SetConfigurationValueUseCase
    {
        private readonly IConfigurationRepository _configurationRepository;

        public SetConfigurationValueUseCase(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public void Execute(string key, string value)
        {
            _configurationRepository.SetConfigurationValue(key, value);
        }
    }
}
