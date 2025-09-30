using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFileFormatsService
    {
        Task<List<ФорматыФайлов>> GetAll();
        Task<ФорматыФайлов> GetById(int id);
        Task Create(ФорматыФайлов model);
        Task Update(ФорматыФайлов model);
        Task Delete(int id);
    }
}
