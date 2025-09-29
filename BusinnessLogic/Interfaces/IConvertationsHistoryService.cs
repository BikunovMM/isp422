using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLogic.Interfaces
{
    public interface IConvertationsHistoryService
    {
        Task<List<ИсторияКонвертаций>> GetAll();
        Task<ИсторияКонвертаций> GetById(int id);
        Task Create(ИсторияКонвертаций model);
        Task Update(ИсторияКонвертаций model);
        Task Delete(int id);
    }
}
