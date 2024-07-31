using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Maintenance.SystemSetup
{
    public class GetCompanyInfoUseCase
    {
        private readonly ISystemSetupRepository _systemSetupRepository;

        public GetCompanyInfoUseCase(ISystemSetupRepository systemSetupRepository)
        {
            _systemSetupRepository = systemSetupRepository;
        }

        public CompanyInformation Execute()
        {
           return _systemSetupRepository.GetCompanyInfo();
        }
    }
}
