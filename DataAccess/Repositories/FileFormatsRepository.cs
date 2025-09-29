using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class FileFormatsRepository : RepositoryBase<ФорматыФайлов>, IFileFormatsRepository
    {
        public FileFormatsRepository(DbIsp422Context repositoryContext)
            : base(repositoryContext) 
        {
        
        }
    }
}
