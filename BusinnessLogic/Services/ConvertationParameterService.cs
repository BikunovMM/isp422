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
            await _repositoryWrapper.ConvertationParameter.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ПараметрКонвертации model)
        {
            await _repositoryWrapper.ConvertationParameter.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var convertationParameter = await _repositoryWrapper.ConvertationParameter
                .FindByCondition(x => x.IdпараметраКонвертации == id);

            _repositoryWrapper.ConvertationParameter.Delete(convertationParameter.First());
            _repositoryWrapper.Save();
        }
    }
}