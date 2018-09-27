﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Q.Domain.Menu;

namespace Q.Services.Interfaces.Menu
{
    public interface IMenuService
    {
        System.Threading.Tasks.Task Add(MenuItem entity);

        Task<MenuItem> Update(MenuItem entity);

        System.Threading.Tasks.Task Delete(int id);

        System.Threading.Tasks.Task<IEnumerable<MenuItem>> GetAll();

        System.Threading.Tasks.Task<MenuItem> AddMenuItem(MenuItem menuItem);

        Task<IEnumerable<MenuGroup>> GetMenuGroups();

        Task<MenuItem> GetMenuItem(int id);
    }
}
