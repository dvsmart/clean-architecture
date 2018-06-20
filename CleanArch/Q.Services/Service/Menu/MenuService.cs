using Q.Domain.Menu;
using Q.Infrastructure;
using Q.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.Menu
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<MenuItem> _menuItemRepository;
        private readonly IRepository<MenuGroup> _menuGroupRepository;

        public MenuService(IRepository<MenuItem> menuItemRepository, IRepository<MenuGroup> menuGroupRepository)
        {
            _menuItemRepository = menuItemRepository;
            _menuGroupRepository = menuGroupRepository;
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItems()
        {
            return await _menuItemRepository.GetAll();
        }

        public async System.Threading.Tasks.Task AddMenuItem(MenuItem menuItem)
        {
            await _menuItemRepository.Insert(menuItem);
        }

        public async System.Threading.Tasks.Task Add(MenuItem entity)
        {
            await _menuItemRepository.Insert(entity);
        }

        public async System.Threading.Tasks.Task Update(MenuItem entity)
        {
            await _menuItemRepository.Update(entity);
        }

        public async System.Threading.Tasks.Task Delete(MenuItem entity)
        {
            await _menuItemRepository.Delete(entity);
        }

        public async Task<IEnumerable<MenuItem>> GetAll()
        {
            return await _menuItemRepository.GetAll();
        }
    }
}
