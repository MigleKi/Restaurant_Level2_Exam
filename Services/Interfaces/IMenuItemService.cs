using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.Interfaces
{
    public interface IMenuItemService
    {
        List<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(int id);
        void AddMenuItem(string name, decimal price, string type);

    }
}