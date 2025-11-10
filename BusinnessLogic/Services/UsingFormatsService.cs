using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
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
        public async Task<List<ИспользованиеФорматов>> GetAll()
        {
            return await _repositoryWrapper.UsingFormats.FindAll();
        }

        public async Task<ИспользованиеФорматов> GetById(int id)
        {
            var role = await _repositoryWrapper.UsingFormats
                .FindByCondition(x => x.IdиспользованияФорматов == id);
            return role.First();
        }

        public async Task Create(ИспользованиеФорматов model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _repositoryWrapper.UsingFormats.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(ИспользованиеФорматов model)
        {
            await _repositoryWrapper.UsingFormats.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var fileFormat = await _repositoryWrapper.UsingFormats
                .FindByCondition(x => x.IdиспользованияФорматов == id);

            await _repositoryWrapper.UsingFormats.Delete(fileFormat.First());
            await _repositoryWrapper.Save();
        }
    }
}