using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;

namespace BusinessLogic.Tests
{
    public class SettingsServiceTest
    {
        private readonly SettingsService service;
        private readonly Mock<ISettingsRepository> settingsRepositoryMoq;

        public SettingsServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            settingsRepositoryMoq = new Mock<ISettingsRepository>();

            repositoryWrapperMoq.Setup(x => x.Settings)
                .Returns(settingsRepositoryMoq.Object);

            service = new SettingsService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullSettings_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            settingsRepositoryMoq.Verify(x => x.Create(It.IsAny<Настройки>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectSettings()
        {
            return new List<object[]>
            {
                new object[] {new Настройки() { Idнастроек = -1, Idпользователя = -1, Язык = "", Уведомления = -1} },
                new object[] {new Настройки() { Idнастроек = 0, Idпользователя = -1, Язык = "", Уведомления = -1} },
                new object[] {new Настройки() { Idнастроек = 0, Idпользователя = 0, Язык = "", Уведомления = -1} },
                new object[] {new Настройки() { Idнастроек = 0, Idпользователя = 0, Язык = "Russian", Уведомления = -1} },
                new object[] {new Настройки() { Idнастроек = 0, Idпользователя = 0, Язык = "Russian", Уведомления = 0} },
            };
        }

        [Theory]
        [MemberDataAttribute(nameof(GetIncorrectSettings))]
        public async Task CreateAsyncNewSettingsShouldNotCreateNewSettings(Настройки settings)
        {
            var newSettings = settings;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newSettings));

            settingsRepositoryMoq.Verify(x => x.Create(It.IsAny<Настройки>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewSettingsShouldCreateNewSettings()
        {
            var newSettings = new Настройки()
            {
                Idнастроек = 0,
                Idпользователя = 0,
                Язык = "Russian",
                Уведомления = 1
            };

            await service.Create(newSettings);

            settingsRepositoryMoq.Verify(x => x.Create(It.IsAny<Настройки>()), Times.Once);
        }
    }
}
