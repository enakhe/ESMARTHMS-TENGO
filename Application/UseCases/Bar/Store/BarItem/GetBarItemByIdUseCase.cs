using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Bar.Store.BarItem
{
    public class GetBarItemByIdUseCase
    {
        private readonly IBarItemRepository _barItemRepository;

        public GetBarItemByIdUseCase(IBarItemRepository barItemRepository)
        {
            _barItemRepository = barItemRepository;
        }

        public Domain.Entities.MenuItem Execute(string id)
        {
            return _barItemRepository.GetBarItemById(id);
        }
    }
}
