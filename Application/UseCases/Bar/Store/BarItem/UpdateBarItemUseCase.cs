using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Bar.Store.BarItem
{
    public class UpdateBarItemUseCase
    {
        private readonly IBarItemRepository _barItemRepository;

        public UpdateBarItemUseCase(IBarItemRepository barItemRepository)
        {
            _barItemRepository = barItemRepository;
        }

        public void Execute(Domain.Entities.MenuItem barItem)
        {
            _barItemRepository.UpdateBarItem(barItem);
        }
    }
}
