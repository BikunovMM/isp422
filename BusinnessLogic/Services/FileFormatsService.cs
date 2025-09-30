using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class FileFormatsService : IFileFormatsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FileFormatsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<ФорматыФайлов>> GetAll()
        {
            return await _repositoryWrapper.FileFormats.FindAll();
        }

        public async Task<ФорматыФайлов> GetById(int id)
        {
            var role = await _repositoryWrapper.FileFormats
                .FindByCondition(x => x.Idформата == id);
            return role.First();
        }

        public async Task Create(ФорматыФайлов model)
        {
            await _repositoryWrapper.FileFormats.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ФорматыФайлов model)
        {
            await _repositoryWrapper.FileFormats.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var fileFormat = await _repositoryWrapper.FileFormats
                .FindByCondition(x => x.Idформата == id);

            _repositoryWrapper.FileFormats.Delete(fileFormat.First());
            _repositoryWrapper.Save();
        }
    }
}