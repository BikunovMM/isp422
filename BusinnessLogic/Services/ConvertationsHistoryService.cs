using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
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
        public async Task<List<ИсторияКонвертаций>> GetAll()
        {
            return await _repositoryWrapper.ConvertationsHistory.FindAll();
        }

        public async Task<ИсторияКонвертаций> GetById(int id)
        {
            var role = await _repositoryWrapper.ConvertationsHistory
                .FindByCondition(x => x.IdисторииКонвертаций == id);
            return role.First();
        }

        public async Task Create(ИсторияКонвертаций model)
        {
            await _repositoryWrapper.ConvertationsHistory.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ИсторияКонвертаций model)
        {
            await _repositoryWrapper.ConvertationsHistory.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var convertation = await _repositoryWrapper.ConvertationsHistory
                .FindByCondition(x => x.IdисторииКонвертаций == id);

            _repositoryWrapper.ConvertationsHistory.Delete(convertation.First());
            _repositoryWrapper.Save();
        }
    }
}