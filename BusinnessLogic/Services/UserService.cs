using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Пользователи>> GetAll()
        {
            return await _repositoryWrapper.Users.FindAll();
        }

        public async Task<Пользователи> GetById(int id)
        {
            var user = await _repositoryWrapper.Users
                .FindByCondition(x => x.Idпользователя == id);
            return user.First();
        }

        public async Task Create(Пользователи model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Логин))
            {
                throw new ArgumentNullException(nameof(model.Логин));
            }
            await _repositoryWrapper.Users.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Пользователи model)
        {
            await _repositoryWrapper.Users.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Users
                .FindByCondition(x => x.Idпользователя == id);

            await _repositoryWrapper.Users.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}