using BusinnessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class FileFormatsService : IFileFormatsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FileFormatsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<ФорматыФайлов>> GetAll()
        {
            return _repositoryWrapper.FileFormats.FindAll().ToListAsync();
        }

        public Task<ФорматыФайлов> GetById(int id)
        {
            var role = _repositoryWrapper.FileFormats
                .FindByCondition(x => x.Idформата == id).First();
            return Task.FromResult(role);
        }

        public Task Create(ФорматыФайлов model)
        {
            _repositoryWrapper.FileFormats.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ФорматыФайлов model)
        {
            _repositoryWrapper.FileFormats.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var fileFormat = _repositoryWrapper.FileFormats
                .FindByCondition(x => x.Idформата == id).First();

            _repositoryWrapper.FileFormats.Delete(fileFormat);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}