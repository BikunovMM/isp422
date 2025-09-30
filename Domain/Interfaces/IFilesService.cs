using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFilesService
    {
        Task<List<Файлы>> GetAll();
        Task<Файлы> GetById(int id);
        Task Create(Файлы model);
        Task Update(Файлы model);
        Task Delete(int id);
    }
}
