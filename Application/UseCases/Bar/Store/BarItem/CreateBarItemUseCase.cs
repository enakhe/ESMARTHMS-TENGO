using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Store.BarItem
{
    public class CreateBarItemUseCase
    {
        private readonly IBarItemRepository _barRepository;

        public CreateBarItemUseCase(IBarItemRepository barRepository)
        {
            _barRepository = barRepository;
        }

        public void Execute(Domain.Entities.MenuItem barItem)
        {
            _barRepository.AddItem(barItem);
        }
    }
}
