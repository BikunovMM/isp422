using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ConvertationParametersService : IConvertationParametersService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ConvertationParametersService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<ПараметрыКонвертации>> GetAll()
        {
            return await _repositoryWrapper.ConvertationParameters.FindAll();
        }

        public async Task<ПараметрыКонвертации> GetById(int id)
        {
            var role = await _repositoryWrapper.ConvertationParameters
                .FindByCondition(x => x.IdпараметраКонвертации == id);
            return role.First();
        }

        public async Task Create(ПараметрыКонвертации model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Значение))
            {
                throw new ArgumentNullException(nameof(model.Значение));
            }

            await _repositoryWrapper.ConvertationParameters.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(ПараметрыКонвертации model)
        {
            await _repositoryWrapper.ConvertationParameters.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var convertationParameter = await _repositoryWrapper.ConvertationParameters
                .FindByCondition(x => x.IdпараметраКонвертации == id);

            await _repositoryWrapper.ConvertationParameters.Delete(convertationParameter.First());
            await _repositoryWrapper.Save();
        }
    }
}