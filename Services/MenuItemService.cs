using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;
using Restaurant.Repositories.Interfaces;
using Restaurant.Services.Interfaces;

namespace Restaurant.Services
{
    internal class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository foodItemRepository)
        {
            _menuItemRepository = foodItemRepository;
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItemRepository.GetAllMenuItems();
        }

        public MenuItem GetMenuItemById(int id)
        {
            return _menuItemRepository.GetMenuItemById(id);
        }

        public void AddMenuItem(string name, decimal price, string type)
        {
            MenuItem newMenuItem = new MenuItem { Name = name, Price = price, Type = type };
            _menuItemRepository.AddMenuItem(newMenuItem);
        }

    }
}