using System.Threading.Tasks;
using Q.Service.Interfaces;

namespace Q.Service.UseCases.Menu
{
    using Q.Domain.Menu;
    public class AddMenuItemInteractor : IInputBoundary<CreateMenuItemRequest>
    {

        private readonly IRepository<MenuItem> _menuItemRepository;
        private readonly IOutputConverter _outputConverter;

        public AddMenuItemInteractor(IRepository<MenuItem> menuItemRepository, IOutputConverter outputConverter)
        {
            _menuItemRepository = menuItemRepository;
            _outputConverter = outputConverter;
        }

        public async System.Threading.Tasks.Task Process(CreateMenuItemRequest input)
        {
            var menuItem = _outputConverter.Map<MenuItem>(input);
            await _menuItemRepository.Insert(menuItem);
        }
    }
}
