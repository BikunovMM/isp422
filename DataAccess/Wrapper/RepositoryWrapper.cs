using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//LarionovInternetShopContext
namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DbIsp422Context _repoContext;
        private IUserRepository _users;
        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_repoContext);
                }
                return _users;
            }
        }
        private IRoleRepository _role;
        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_repoContext);
                }
                return _role;
            }
        }
        private ISettingsRepository _settings;
        public ISettingsRepository Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new SettingsRepository(_repoContext);
                }
                return _settings;
            }
        }
        private IFileFormatsRepository _fileFormats;
        public IFileFormatsRepository FileFormats
        {
            get
            {
                if (_fileFormats == null)
                {
                    _fileFormats = new FileFormatsRepository(_repoContext);
                }
                return _fileFormats;
            }
        }
        private IUsingFormatsRepository _usingFormats;
        public IUsingFormatsRepository UsingFormats
        {
            get
            {
                if (_usingFormats == null)
                {
                    _usingFormats = new UsingFormatsRepository(_repoContext);
                }
                return _usingFormats;
            }
        }
        private IFilesRepository _files;
        public IFilesRepository Files
        {
            get
            {
                if (_files == null)
                {
                    _files = new FilesRepository(_repoContext);
                }
                return _files;
            }
        }
        private IConvertationsRepository _convertations;
        public IConvertationsRepository Convertations
        {
            get
            {
                if (_convertations == null)
                {
                    _convertations = new ConvertationsRepository(_repoContext);
                }
                return _convertations;
            }
        }
        private IConvertationsHistoryRepository _convertationsHistory;
        public IConvertationsHistoryRepository ConvertationsHistory
        {
            get
            {
                if (_convertationsHistory == null)
                {
                    _convertationsHistory = new ConvertationsHistoryRepository(_repoContext);
                }
                return _convertationsHistory;
            }
        }
        private IConvertationParameterRepository _convertationParameter;
        public IConvertationParameterRepository ConvertationParameter
        {
            get
            {
                if (_convertationParameter == null)
                {
                    _convertationParameter = new ConvertationParameterRepository(_repoContext);
                }
                return _convertationParameter;
            }
        }
        private IConvertationParametersRepository _convertationParameters;
        public IConvertationParametersRepository ConvertationParameters
        {
            get
            {
                if (_convertationParameters == null)
                {
                    _convertationParameters = new ConvertationParametersRepository(_repoContext);
                }
                return _convertationParameters;
            }
        }

        public RepositoryWrapper(DbIsp422Context repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
           await _repoContext.SaveChangesAsync();
        }
    }
}
