using BusinnessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RoleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Роли>> GetAll()
        {
            return _repositoryWrapper.Role.FindAll().ToListAsync();
        }

        public Task<Роли> GetById(int id)
        {
            var role = _repositoryWrapper.Role
                .FindByCondition(x => x.Idроли == id).First();
            return Task.FromResult(role);
        }

        public Task Create(Роли model)
        {
            _repositoryWrapper.Role.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Роли model)
        {
            _repositoryWrapper.Role.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var role = _repositoryWrapper.Role
                .FindByCondition(x => x.Idроли == id).First();

            _repositoryWrapper.Role.Delete(role);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}