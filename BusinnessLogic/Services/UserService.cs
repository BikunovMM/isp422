using BusinnessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
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

        public Task<List<Пользователи>> GetAll()
        {
            return _repositoryWrapper.Users.FindAll().ToListAsync();
        }

        public Task<Пользователи> GetById(int id)
        {
            var user = _repositoryWrapper.Users
                .FindByCondition(x => x.Idпользователя == id).First();
            return Task.FromResult(user);
        }

        public Task Create(Пользователи model)
        {
            _repositoryWrapper.Users.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Пользователи model)
        {
            _repositoryWrapper.Users.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var user = _repositoryWrapper.Users
                .FindByCondition(x => x.Idпользователя == id).First();

            _repositoryWrapper.Users.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}