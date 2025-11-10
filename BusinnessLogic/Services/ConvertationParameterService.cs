using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ConvertationParameterService : IConvertationParameterService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ConvertationParameterService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<ПараметрКонвертации>> GetAll()
        {
            return await _repositoryWrapper.ConvertationParameter.FindAll();
        }

        public async Task<ПараметрКонвертации> GetById(int id)
        {
            var role = await _repositoryWrapper.ConvertationParameter
                .FindByCondition(x => x.IdпараметраКонвертации == id);
            return role.First();
        }

        public async Task Create(ПараметрКонвертации model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Название))
            {
                throw new ArgumentNullException(nameof(model.Название));
            }

            await _repositoryWrapper.ConvertationParameter.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(ПараметрКонвертации model)
        {
            await _repositoryWrapper.ConvertationParameter.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var convertationParameter = await _repositoryWrapper.ConvertationParameter
                .FindByCondition(x => x.IdпараметраКонвертации == id);

            await _repositoryWrapper.ConvertationParameter.Delete(convertationParameter.First());
            await _repositoryWrapper.Save();
        }
    }
}