using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class FilesService : IFilesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FilesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Файлы>> GetAll()
        {
            return await _repositoryWrapper.Files.FindAll();
        }

        public async Task<Файлы> GetById(int id)
        {
            var role = await  _repositoryWrapper.Files
                .FindByCondition(x => x.Idфайла == id);
            return role.First();
        }

        public async Task Create(Файлы model)
        {
            await _repositoryWrapper.Files.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Файлы model)
        {
            await _repositoryWrapper.Files.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var file = await _repositoryWrapper.Files
                .FindByCondition(x => x.Idфайла == id);

            _repositoryWrapper.Files.Delete(file.First());
            _repositoryWrapper.Save();
        }
    }
}