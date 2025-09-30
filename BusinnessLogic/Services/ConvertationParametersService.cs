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
            await _repositoryWrapper.ConvertationParameters.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ПараметрыКонвертации model)
        {
            await _repositoryWrapper.ConvertationParameters.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var convertationParameter = await _repositoryWrapper.ConvertationParameters
                .FindByCondition(x => x.IdпараметраКонвертации == id);

            _repositoryWrapper.ConvertationParameters.Delete(convertationParameter.First());
            _repositoryWrapper.Save();
        }
    }
}