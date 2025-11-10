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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _repositoryWrapper.ConvertationsHistory.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(ИсторияКонвертаций model)
        {
            await _repositoryWrapper.ConvertationsHistory.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var convertation = await _repositoryWrapper.ConvertationsHistory
                .FindByCondition(x => x.IdисторииКонвертаций == id);

            await _repositoryWrapper.ConvertationsHistory.Delete(convertation.First());
            await _repositoryWrapper.Save();
        }
    }
}