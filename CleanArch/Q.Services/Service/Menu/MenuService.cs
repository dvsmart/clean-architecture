using Q.Domain;
using Q.Domain.Menu;
using Q.Infrastructure;
using Q.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.Menu
{
    public class MenuService : IMenuService
    {
        private readonly IGenericRepository<MenuItem> _menuItemRepository;
        private readonly IGenericRepository<MenuGroup> _menuGroupRepository;

        public MenuService(IGenericRepository<MenuItem> menuItemRepository, IGenericRepository<MenuGroup> menuGroupRepository)
        {
            _menuItemRepository = menuItemRepository;
            _menuGroupRepository = menuGroupRepository;
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItems()
        {
            return await _menuItemRepository.GetAllAsync();
        }

        public async System.Threading.Tasks.Task AddMenuItem(MenuItem menuItem)
        {
            await _menuItemRepository.AddAsync(menuItem);
        }

        public async System.Threading.Tasks.Task Add(MenuItem entity)
        {
            await _menuItemRepository.AddAsync(entity);
        }

        public async System.Threading.Tasks.Task Update(MenuItem entity)
        {
            await _menuItemRepository.UpdateAsync(entity, entity.Id);
        }

        public async System.Threading.Tasks.Task Delete(MenuItem entity)
        {
            await _menuItemRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<MenuItem>> GetAll()
        {
            return await _menuItemRepository.GetAllAsync();
        }
    }
}
