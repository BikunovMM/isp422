using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLogic.Interfaces
{
    public interface IRoleService
    {
        Task<List<Роли>> GetAll();
        Task<Роли> GetById(int id);
        Task Create(Роли model);
        Task Update(Роли model);
        Task Delete(int id);
    }
}
