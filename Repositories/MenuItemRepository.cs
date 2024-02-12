using Restaurant.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private string filePath = "C:\\Users\\migle\\OneDrive\\Documents\\Codeacademy\\Level2_tasks\\Exam\\Data\\MenuItems.txt";

        private List<MenuItem> menuItems;
        public void LoadMenuItemsFromFile(string filePath)
        {
            menuItems = File.ReadAllLines(filePath)
                .Select(line => line.Split(','))
                .Select(parts => new MenuItem
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Price = decimal.Parse(parts[2]),
                    Type = parts[3]
                })
                .ToList();
        }
        public void SaveMenuItemsToFile(string filePath)
        {
            var lines = menuItems.Select(item => $"{item.Id},{item.Name},{item.Price},{item.Type}");
            File.WriteAllLines(filePath, lines);
        }
        public List<MenuItem> GetAllMenuItems()
        {
            LoadMenuItemsFromFile(filePath);
            return menuItems;
        }

        public MenuItem GetMenuItemById(int id)
        {
            return menuItems.FirstOrDefault(item => item.Id == id);
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            LoadMenuItemsFromFile(filePath);
            menuItem.Id = menuItems.Count > 0 ? menuItems.Max(f => f.Id) + 1 : 1;
            menuItems.Add(menuItem);
            SaveMenuItemsToFile(filePath);
        }
    }
}
