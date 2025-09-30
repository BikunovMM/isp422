using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsingFormatsService
    {
        Task<List<ИспользованиеФорматов>> GetAll();
        Task<ИспользованиеФорматов> GetById(int id);
        Task Create(ИспользованиеФорматов model);
        Task Update(ИспользованиеФорматов model);
        Task Delete(int id);
    }
}
