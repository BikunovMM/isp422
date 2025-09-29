using BusinnessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
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
        public Task<List<ПараметрКонвертации>> GetAll()
        {
            return _repositoryWrapper.ConvertationParameter.FindAll().ToListAsync();
        }

        public Task<ПараметрКонвертации> GetById(int id)
        {
            var role = _repositoryWrapper.ConvertationParameter
                .FindByCondition(x => x.IdпараметраКонвертации == id).First();
            return Task.FromResult(role);
        }

        public Task Create(ПараметрКонвертации model)
        {
            _repositoryWrapper.ConvertationParameter.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ПараметрКонвертации model)
        {
            _repositoryWrapper.ConvertationParameter.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var convertationParameter = _repositoryWrapper.ConvertationParameter
                .FindByCondition(x => x.IdпараметраКонвертации == id).First();

            _repositoryWrapper.ConvertationParameter.Delete(convertationParameter);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}