using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository Users { get; }
        IRoleRepository Role { get; }
        ISettingsRepository Settings { get; }
        IFileFormatsRepository FileFormats { get; }
        IUsingFormatsRepository UsingFormats { get; }
        IFilesRepository Files { get; }
        IConvertationsRepository Convertations { get; }
        IConvertationsHistoryRepository ConvertationsHistory { get; }
        IConvertationParameterRepository ConvertationParameter { get; }
        IConvertationParametersRepository ConvertationParameters { get; }
        Task Save();
    }
}
