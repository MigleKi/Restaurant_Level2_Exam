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
    internal class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public List<Table> GetAllTables()
        {
            return _tableRepository.GetAllTables();
        }

        public Table GetTableById(int tableId)
        {
            return _tableRepository.GetTableById(tableId);
        }

        public void MarkTableAsOccupied(int tableId)
        {
            _tableRepository.UpdateTableStatus(tableId, "Occupied");
        }

        public void MarkTableAsVacant(int tableId)
        {
            _tableRepository.UpdateTableStatus(tableId, "Vacant");
        }
    }
}
