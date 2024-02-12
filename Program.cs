using Restaurant.Repositories.Interfaces;
using Restaurant.Repositories;
using Restaurant.Services;
using Restaurant.Services.Interfaces;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ITableRepository tableRepository = new TableRepository();
            ITableService tableService = new TableService(tableRepository);
            IMenuItemRepository menuItemRepository = new MenuItemRepository();
            IMenuItemService menuItemService = new MenuItemService(menuItemRepository);
            ConsoleUI ui = new ConsoleUI(tableService, menuItemService);
            ui.Run();
        }
    }
}
