using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLogic.Interfaces
{
    public interface IConvertationParametersService
    {
        Task<List<ПараметрыКонвертации>> GetAll();
        Task<ПараметрыКонвертации> GetById(int id);
        Task Create(ПараметрыКонвертации model);
        Task Update(ПараметрыКонвертации model);
        Task Delete(int id);
    }
}
