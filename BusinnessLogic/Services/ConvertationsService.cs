using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ConvertationsService : IConvertationsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ConvertationsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Конвертации>> GetAll()
        {
            return await _repositoryWrapper.Convertations.FindAll();
        }

        public async Task<Конвертации> GetById(int id)
        {
            var role = await _repositoryWrapper.Convertations
                .FindByCondition(x => x.Idконвертации == id);
            return role.First();
        }

        public async Task Create(Конвертации model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _repositoryWrapper.Convertations.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Конвертации model)
        {
            await _repositoryWrapper.Convertations.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var convertation = await _repositoryWrapper.Convertations
                .FindByCondition(x => x.Idконвертации == id);

            await _repositoryWrapper.Convertations.Delete(convertation.First());
            await _repositoryWrapper.Save();
        }
    }
}