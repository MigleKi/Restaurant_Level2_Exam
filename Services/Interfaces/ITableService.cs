using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.Interfaces
{
    public interface ITableService
    {
        void MarkTableAsOccupied(int tableId);
        void MarkTableAsVacant(int tableId);
        List<Table> GetAllTables();
        Table GetTableById(int tableId);
    }
}
