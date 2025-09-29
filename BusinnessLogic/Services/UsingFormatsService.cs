using BusinnessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UsingFormatsService : IUsingFormatsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UsingFormatsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<ИспользованиеФорматов>> GetAll()
        {
            return _repositoryWrapper.UsingFormats.FindAll().ToListAsync();
        }

        public Task<ИспользованиеФорматов> GetById(int id)
        {
            var role = _repositoryWrapper.UsingFormats
                .FindByCondition(x => x.IdиспользованияФорматов == id).First();
            return Task.FromResult(role);
        }

        public Task Create(ИспользованиеФорматов model)
        {
            _repositoryWrapper.UsingFormats.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ИспользованиеФорматов model)
        {
            _repositoryWrapper.UsingFormats.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var fileFormat = _repositoryWrapper.UsingFormats
                .FindByCondition(x => x.IdиспользованияФорматов == id).First();

            _repositoryWrapper.UsingFormats.Delete(fileFormat);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}