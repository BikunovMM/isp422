using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ConvertationParameterRepository : RepositoryBase<ПараметрКонвертации>, IConvertationParameterRepository
    {
        public ConvertationParameterRepository(DbIsp422Context repositoryContext)
            : base(repositoryContext) 
        {
        
        }
    }
}
