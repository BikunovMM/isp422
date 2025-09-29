using BusinnessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ConvertationsHistoryService : IConvertationsHistoryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ConvertationsHistoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<ИсторияКонвертаций>> GetAll()
        {
            return _repositoryWrapper.ConvertationsHistory.FindAll().ToListAsync();
        }

        public Task<ИсторияКонвертаций> GetById(int id)
        {
            var role = _repositoryWrapper.ConvertationsHistory
                .FindByCondition(x => x.IdисторииКонвертаций == id).First();
            return Task.FromResult(role);
        }

        public Task Create(ИсторияКонвертаций model)
        {
            _repositoryWrapper.ConvertationsHistory.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ИсторияКонвертаций model)
        {
            _repositoryWrapper.ConvertationsHistory.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var convertation = _repositoryWrapper.ConvertationsHistory
                .FindByCondition(x => x.IdисторииКонвертаций == id).First();

            _repositoryWrapper.ConvertationsHistory.Delete(convertation);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}