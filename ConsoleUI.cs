using Restaurant.Repositories.Interfaces;
using Restaurant.Repositories;
using Restaurant.Services;
using Restaurant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Restaurant.Models;

namespace Restaurant
{
    public class ConsoleUI
    {
        private readonly ITableService _tableService;
        private readonly IMenuItemService _menuItemService;
        public ConsoleUI(ITableService tableService, IMenuItemService menuItemService)
        {
            _tableService = tableService;
            _menuItemService = menuItemService;
        }

        public void Run()
        {
            Logo();
            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("Restaurant Manager");
                Console.WriteLine("************************");
                Console.WriteLine("1. Show Restaurant Menu");
                Console.WriteLine("2. Start New Order");
                Console.WriteLine("3. Manage Tables");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");


                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        StartOrder();
                        break;
                    case "3":
                        ShowTables();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                Console.ResetColor();
            }
            Exit();
        }
        private void Logo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\r\n  ____           _                              _    \r\n |  _ \\ ___  ___| |_ __ _ _   _ _ __ __ _ _ __ | |" +
                              "_  \r\n | |_) / _ \\/ __| __/ _` | | | | '__/ _` | '_ \\| __| \r\n |  _ <  __/\\__ \\ || (_| | |_| | | | (_| | | | " +
                              "| |_  \r\n |_| \\_\\___||___/\\__\\__,_|\\__,_|_|  \\__,_|_| |_|\\__| \r\n     |  \\/  | __ _ _ __   __ _  __ _  ___ " +
                              "_ __       \r\n     | |\\/| |/ _` | '_ \\ / _` |/ _` |/ _ \\ '__|      \r\n     | |  | | (_| | | | | (_| | (_| |  __" +
                              "/ |         \r\n     |_|  |_|\\__,_|_| |_|\\__,_|\\__, |\\___|_|         \r\n                               |___/  " +
                              "               \r\n");
            Thread.Sleep(1000); ;
        }
        private void Exit()
        {
            Console.Clear();
            Logo();
        }
        private void ShowMenu()
        {
            Console.Clear();
            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. View Menu");
                Console.WriteLine("2. Add a new menu item");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllMenuItems();
                        break;
                    case "2":
                        AddNewMenuItem();
                        break;
                    case "0":
                        running = false;
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.ResetColor();
            }
        }
        private void DisplayAllMenuItems()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            List<MenuItem> allMenuItems = _menuItemService.GetAllMenuItems();
            Console.WriteLine("Food Menu ");
            Console.WriteLine("*************************************");
            Console.WriteLine("{0,-4} {1,-20} {2,-6}", "No.", "Name", "Price\n");
            foreach (var foodItem in allMenuItems.Where(item => item.Type == "Food"))
            {

                Console.WriteLine("{0,-4} {1,-20} {2,-6} Eur", foodItem.Id, foodItem.Name, foodItem.Price);
            }

            Console.WriteLine("\nDrinks Menu ");
            Console.WriteLine("*************************************");
            Console.WriteLine("{0,-4} {1,-20} {2,-6}", "No.", "Name", "Price\n");

            foreach (var drinkItem in allMenuItems.Where(item => item.Type == "Drink"))
            {
                Console.WriteLine("{0,-4} {1,-20} {2,-6} Eur", drinkItem.Id, drinkItem.Name, drinkItem.Price);
            }

            Console.WriteLine(" ");
            Console.ResetColor();
        }
        private void AddNewMenuItem()
        {
            Console.Clear();
            Console.Write("Which type of menu item would you like to add? \nWrite 'F' for food\nWrite 'D' for drinks \n");
            bool running = true;
            while (running)
            {
                string choice = Console.ReadLine().ToUpperInvariant();

                switch (choice)
                {
                    case "F":
                        AddNewFoodItem();
                        running = false;
                        break;
                    case "D":
                        AddNewDrinksItem();
                        running = false;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid option. \nWrite 'F' for food\nWrite 'D' for drinks");
                        Console.ResetColor();
                        break;
                }
            }


        }
        private void AddNewFoodItem()
        {
            Console.Clear();
            string type = "Food";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter name of the food: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the price: ");
            decimal price;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }

            _menuItemService.AddMenuItem(name, price, type);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New food item added successfully.");
            Console.ResetColor();
        }
        private void AddNewDrinksItem()
        {
            Console.Clear();
            string type = "Drink";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter name of the drink: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the price: ");
            decimal price;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }

            _menuItemService.AddMenuItem(name, price, type);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New drink added successfully.");
            Console.ResetColor();
        }
        private void StartOrder()
        {
            Console.Clear();
            DisplayAvailableTAbles();
            Console.Write("Enter table ID to start an order:");
            string input = Console.ReadLine();


            if (int.TryParse(input, out int tableId))
            {
                var tables = _tableService.GetAllTables();
                var table = tables.FirstOrDefault(t => t.Id == tableId); ;

                if (table != null)
                {
                    switch (table.Status)
                    {
                        case "Occupied":
                            Console.WriteLine($"Table {tableId} is occupied.");
                            break;
                        case "Vacant":
                            _tableService.MarkTableAsOccupied(tableId);
                            Console.WriteLine($"Table {tableId} marked as occupied.");
                            break;
                        default:
                            Console.WriteLine($"Unknown status for table {tableId}.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid table ID.");
            }

            Table chosenTable = _tableService.GetTableById(tableId);
            Console.Clear();
            DisplayAllMenuItems();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Start an order for table {tableId}\n*************************************");
            List<MenuItem> orderedItems = new List<MenuItem>();
            bool ordering = true;
            while (ordering)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter Menu Item No. to add to this order or enter '0' to finish): ");
                int itemId = int.Parse(Console.ReadLine());
                if (itemId == 0)
                {
                    ordering = false;
                    break;
                }

                MenuItem selectedItem = _menuItemService.GetMenuItemById(itemId);
                if (selectedItem != null)
                {
                    orderedItems.Add(selectedItem);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{selectedItem.Name} added to the order.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid item ID.");
                    Console.ResetColor();
                }
            }
            GenerateVouchers(chosenTable, orderedItems);

        }
        private void DisplayAvailableTAbles()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Table\tSeats\tStatus");
            List<Table> allTables = _tableService.GetAllTables();
            List<Table> availableTables = allTables.Where(t => t.Status == "Vacant").ToList();
            foreach (var table in availableTables)
            {
                Console.WriteLine($"{table.Id}\t{table.NumberOfSeats}\t{table.Status}");
            }

            Console.ResetColor();
        }
        private void GenerateVouchers(Table table, List<MenuItem> orderedItems)
        {
            Console.Clear();
            string restaurantVoucher = GenerateRestaurantVoucher(table, orderedItems);
            Console.WriteLine("\nRestaurant Voucher:\n");
            Console.WriteLine(restaurantVoucher);


            string customerVoucher = GenerateCustomerVoucher(orderedItems);
            Console.WriteLine("\nCustomer Voucher:\n");
            Console.WriteLine(customerVoucher);

            Console.Write("\nSend customer voucher via email? (yes/no): ");

            bool sending = true;
            while (sending)
            {
                string sendEmail = Console.ReadLine().ToLower();

                if (sendEmail == "yes")
                {
                    SendEmailToCustomer(customerVoucher);
                    sending = false;
                }
                else if (sendEmail == "no")
                {
                    Console.WriteLine("Returning to main screen.");
                    Thread.Sleep(800);
                    Console.Write(".");
                    Thread.Sleep(800);
                    Console.Write(".");
                    Thread.Sleep(800);
                    sending = false;
                }
                else
                {
                    Console.WriteLine("Incorrect input, please enter 'yes' or 'no'");

                }
            }

        }
        private string GenerateRestaurantVoucher(Table table, List<MenuItem> orderedItems)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table ID: {table.Id}");
            sb.AppendLine($"Number of Seats: {table.NumberOfSeats}");
            sb.AppendLine($"Date and Time of Order: {DateTime.Now}");
            sb.AppendLine("Ordered Food Items:");
            foreach (var item in orderedItems.Where(item => item.Type == "Food"))
            {
                sb.AppendLine($"{item.Name}\t{item.Price}  EUR");
            }
            sb.AppendLine("Ordered Drink Items:");
            foreach (var item in orderedItems.Where(item => item.Type == "Drink"))
            {
                sb.AppendLine($"{item.Name}\t{item.Price} EUR");
            }
            sb.AppendLine($"Total Amount: {orderedItems.Sum(item => item.Price)} EUR");

            string restaurantVoucher = sb.ToString();
            string fileName = $"{table.Id}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            File.WriteAllText(fileName, restaurantVoucher);

            return restaurantVoucher;
        }
        private string GenerateCustomerVoucher(List<MenuItem> orderItems)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Date and Time of Order: {DateTime.Now}");
            sb.AppendLine("Ordered Food Items:");
            foreach (var item in orderItems.Where(item => item.Type == "Food"))
            {
                sb.AppendLine($"{item.Name}\t{item.Price} EUR");
            }
            sb.AppendLine("Ordered Drink Items:");
            foreach (var item in orderItems.Where(item => item.Type == "Drink"))
            {
                sb.AppendLine($"{item.Name}\t{item.Price} EUR");
            }
            sb.AppendLine($"Total Amount: {orderItems.Sum(item => item.Price)} EUR");

            return sb.ToString();
        }
        private void SendEmailToCustomer(string customerVoucher)
        {
            Console.Clear();
            Console.Write("Sending email.");
            Thread.Sleep(800);
            Console.Write(".");
            Thread.Sleep(800);
            Console.Write(".");
            Thread.Sleep(800);
            Console.Clear();
            Console.WriteLine("Email sent to the customer.");
            Console.Write("Returning to main screen.");
            Thread.Sleep(700);
            Console.Write(".");
            Thread.Sleep(700);
            Console.Write(".");
            Thread.Sleep(700);
        }
        private void ShowTables()
        {
            Console.Clear();
            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. View all tables");
                Console.WriteLine("2. Change table status");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        DisplayAllTables();
                        break;
                    case "2":
                        Console.Clear();
                        ChangeTableStatus();
                        running = false;
                        break;
                    case "0":
                        running = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            Console.ResetColor();
        }
        private void DisplayAllTables()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Table\tSeats\tStatus");
            List<Table> allTables = _tableService.GetAllTables();
            foreach (var table in allTables)
            {
                Console.WriteLine($"{table.Id}\t{table.NumberOfSeats}\t{table.Status}");
            }

            Console.ResetColor();

        }
        private void ChangeTableStatus()
        {
            bool running = true;
            while (running)

            {

                Console.WriteLine("All tables:");
                DisplayAllTables();

                Console.Write("Enter table ID to change status (or press '0' to exit): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int tableId))
                {
                    var tables = _tableService.GetAllTables();
                    var table = tables.FirstOrDefault(t => t.Id == tableId);
                    if (table != null)
                    {
                        switch (table.Status)
                        {
                            case "Occupied":
                                _tableService.MarkTableAsVacant(tableId);
                                Console.WriteLine($"Table {tableId} marked as vacant.");
                                break;
                            case "Vacant":
                                _tableService.MarkTableAsOccupied(tableId);
                                Console.WriteLine($"Table {tableId} marked as occupied.");
                                break;
                            default:
                                Console.WriteLine($"Unknown status for table {tableId}.");
                                break;
                        }
                    }
                    else if (input == "0")
                    {
                        running = false;
                        return;
                    }

                    else
                    {
                        Console.WriteLine($"Table {tableId} not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid table ID or '0' to exit.");
                }
            }
            Console.ResetColor();

        }
    }

}
