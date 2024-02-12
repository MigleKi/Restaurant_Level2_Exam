using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;
using Restaurant.Repositories.Interfaces;

namespace Restaurant.Repositories
{
    public class TableRepository : ITableRepository
    {
        private List<Table> _tables = new();
        private static string DataFilePath = "C:\\Users\\migle\\OneDrive\\Documents\\Codeacademy\\Level2_tasks\\Exam\\Data\\Tables.txt";

        //public TableRepository()
        //{
        //    // change to file 
        //    _tables = new List<Table>
        //    {
        //        new Table { Id = 1, NumberOfSeats = 4, Status = "Vacant" },
        //        new Table { Id = 2, NumberOfSeats = 2, Status = "Vacant" },
        //        new Table { Id = 3, NumberOfSeats = 6, Status = "Vacant" },
        //        new Table { Id = 4, NumberOfSeats = 3, Status = "Vacant" },
        //        new Table { Id = 5, NumberOfSeats = 6, Status = "Vacant" },
        //        new Table { Id = 6, NumberOfSeats = 3, Status = "Vacant" }
        //    };
        //}
        public TableRepository()
        {
            LoadTablesFromFile();
        }

        public Table GetTableById(int id)
        {
            return _tables.FirstOrDefault(table => table.Id == id);
        }

        public void LoadTablesFromFile()
        {
            if (File.Exists(DataFilePath))
            {
                string[] lines = File.ReadAllLines(DataFilePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 3)
                    {
                        Table table = new Table
                        {
                            Id = int.Parse(parts[0]),
                            NumberOfSeats = int.Parse(parts[1]),
                            Status = parts[2]
                        };

                        _tables.Add(table);
                    }
                }
            }
        }

        public void SaveTablesToFile()
        {
            var lines = _tables.Select(table => $"{table.Id},{table.NumberOfSeats},{table.Status}");
            File.WriteAllLines(DataFilePath, lines);
        }

        public List<Table> GetAllTables()
        {
            return _tables;
        }
        public void UpdateTableStatus(int tableId, string status)
        {
            var table = _tables.FirstOrDefault(t => t.Id == tableId);
            if (table != null)
            {
                table.Status = status;
                SaveTablesToFile();
            }
        }
    }
}
