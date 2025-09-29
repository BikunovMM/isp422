using BusinnessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
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
        public Task<List<ПараметрыКонвертации>> GetAll()
        {
            return _repositoryWrapper.ConvertationParameters.FindAll().ToListAsync();
        }

        public Task<ПараметрыКонвертации> GetById(int id)
        {
            var role = _repositoryWrapper.ConvertationParameters
                .FindByCondition(x => x.IdпараметраКонвертации == id).First();
            return Task.FromResult(role);
        }

        public Task Create(ПараметрыКонвертации model)
        {
            _repositoryWrapper.ConvertationParameters.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ПараметрыКонвертации model)
        {
            _repositoryWrapper.ConvertationParameters.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var convertationParameter = _repositoryWrapper.ConvertationParameters
                .FindByCondition(x => x.IdпараметраКонвертации == id).First();

            _repositoryWrapper.ConvertationParameters.Delete(convertationParameter);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}