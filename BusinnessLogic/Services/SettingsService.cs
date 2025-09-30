﻿using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
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

        public async Task<List<Настройки>> GetAll()
        {
            return await _repositoryWrapper.Settings.FindAll();
        }

        public async Task<Настройки> GetById(int id)
        {
            var settings = await _repositoryWrapper.Settings
                .FindByCondition(x => x.Idнастроек == id);
            return settings.First();
        }

        public async Task Create(Настройки model)
        {
            await _repositoryWrapper.Settings.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Настройки model)
        {
            await _repositoryWrapper.Settings.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var settings = await _repositoryWrapper.Settings
                .FindByCondition(x => x.Idнастроек == id);

            await _repositoryWrapper.Settings.Delete(settings.First());
            _repositoryWrapper.Save();
        }
    }
}