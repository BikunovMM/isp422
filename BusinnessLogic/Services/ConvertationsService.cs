using BusinnessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
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
        public Task<List<Конвертации>> GetAll()
        {
            return _repositoryWrapper.Convertations.FindAll().ToListAsync();
        }

        public Task<Конвертации> GetById(int id)
        {
            var role = _repositoryWrapper.Convertations
                .FindByCondition(x => x.Idконвертации == id).First();
            return Task.FromResult(role);
        }

        public Task Create(Конвертации model)
        {
            _repositoryWrapper.Convertations.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Конвертации model)
        {
            _repositoryWrapper.Convertations.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var convertation = _repositoryWrapper.Convertations
                .FindByCondition(x => x.Idконвертации == id).First();

            _repositoryWrapper.Convertations.Delete(convertation);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}