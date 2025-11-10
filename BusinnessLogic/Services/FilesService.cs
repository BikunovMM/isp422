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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.НазваниеФайла))
            {
                throw new ArgumentNullException(nameof(model.НазваниеФайла));
            }

            await _repositoryWrapper.Files.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Файлы model)
        {
            await _repositoryWrapper.Files.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var file = await _repositoryWrapper.Files
                .FindByCondition(x => x.Idфайла == id);

            await _repositoryWrapper.Files.Delete(file.First());
            await _repositoryWrapper.Save();
        }
    }
}