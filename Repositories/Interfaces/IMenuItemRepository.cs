using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        void LoadMenuItemsFromFile(string filepath);
        void SaveMenuItemsToFile(string filepath);
        List<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(int id);
        void AddMenuItem(MenuItem menuItem);
    }
}
