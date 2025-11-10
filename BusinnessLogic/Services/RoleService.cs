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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Название))
            {
                throw new ArgumentNullException(nameof(model.Название));
            }

            await _repositoryWrapper.Role.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Роли model)
        {
            await _repositoryWrapper.Role.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var role = await _repositoryWrapper.Role
                .FindByCondition(x => x.Idроли == id);

            await _repositoryWrapper.Role.Delete(role.First());
            await _repositoryWrapper.Save();
        }
    }
}