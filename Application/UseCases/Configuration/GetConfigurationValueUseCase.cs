using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Configuration
{
    public class GetConfigurationValueUseCase
    {
        private readonly IConfigurationRepository _configurationRepository;

        public GetConfigurationValueUseCase(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public ESMART_HMS.Domain.Entities.Configuration Execute(string value)
        {
            return _configurationRepository.GetConfigurationValue(value);
        }
    }
}
