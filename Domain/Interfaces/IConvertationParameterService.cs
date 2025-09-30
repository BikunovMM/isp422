using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IConvertationParameterService
    {
        Task<List<ПараметрКонвертации>> GetAll();
        Task<ПараметрКонвертации> GetById(int id);
        Task Create(ПараметрКонвертации model);
        Task Update(ПараметрКонвертации model);
        Task Delete(int id);
    }
}
