using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
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

        public async Task<List<Роли>> GetAll()
        {
            return await _repositoryWrapper.Role.FindAll();
        }

        public async Task<Роли> GetById(int id)
        {
            var role = await _repositoryWrapper.Role
                .FindByCondition(x => x.Idроли == id);
            return role.First();
        }

        public async Task Create(Роли model)
        {
            await _repositoryWrapper.Role.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Роли model)
        {
            await _repositoryWrapper.Role.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var role = await _repositoryWrapper.Role
                .FindByCondition(x => x.Idроли == id);

            _repositoryWrapper.Role.Delete(role.First());
            _repositoryWrapper.Save();
        }
    }
}