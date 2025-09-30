using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISettingsService
    {
        Task<List<Настройки>> GetAll();
        Task<Настройки> GetById(int id);
        Task Create(Настройки model);
        Task Update(Настройки model);
        Task Delete(int id);
    }
}
