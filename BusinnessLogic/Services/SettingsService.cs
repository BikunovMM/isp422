using BusinnessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class SettingsService : ISettingsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SettingsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Настройки>> GetAll()
        {
            return _repositoryWrapper.Settings.FindAll().ToListAsync();
        }

        public Task<Настройки> GetById(int id)
        {
            var settings = _repositoryWrapper.Settings
                .FindByCondition(x => x.Idнастроек == id).First();
            return Task.FromResult(settings);
        }

        public Task Create(Настройки model)
        {
            _repositoryWrapper.Settings.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Настройки model)
        {
            _repositoryWrapper.Settings.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var settings = _repositoryWrapper.Settings
                .FindByCondition(x => x.Idнастроек == id).First();

            _repositoryWrapper.Settings.Delete(settings);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}