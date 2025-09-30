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
            await _repositoryWrapper.Users.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Пользователи model)
        {
            await _repositoryWrapper.Users.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Users
                .FindByCondition(x => x.Idпользователя == id);

            _repositoryWrapper.Users.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}