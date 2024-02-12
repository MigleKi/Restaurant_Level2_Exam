using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    public interface ITableRepository
    {
        List<Table> GetAllTables();
        Table GetTableById(int id);
        void LoadTablesFromFile();
        void SaveTablesToFile();
        void UpdateTableStatus(int tableId, string status);
    }
}
