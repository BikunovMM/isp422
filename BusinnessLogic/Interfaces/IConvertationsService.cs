using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLogic.Interfaces
{
    public interface IConvertationsService
    {
        Task<List<Конвертации>> GetAll();
        Task<Конвертации> GetById(int id);
        Task Create(Конвертации model);
        Task Update(Конвертации model);
        Task Delete(int id);
    }
}
