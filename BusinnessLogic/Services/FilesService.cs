using BusinnessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class FilesService : IFilesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FilesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<Файлы>> GetAll()
        {
            return _repositoryWrapper.Files.FindAll().ToListAsync();
        }

        public Task<Файлы> GetById(int id)
        {
            var role = _repositoryWrapper.Files
                .FindByCondition(x => x.Idфайла == id).First();
            return Task.FromResult(role);
        }

        public Task Create(Файлы model)
        {
            _repositoryWrapper.Files.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Файлы model)
        {
            _repositoryWrapper.Files.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var file = _repositoryWrapper.Files
                .FindByCondition(x => x.Idфайла == id).First();

            _repositoryWrapper.Files.Delete(file);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}