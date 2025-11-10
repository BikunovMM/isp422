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
    public class ConvertationParametersServiceTest
    {
        private readonly ConvertationParametersService service;
        private readonly Mock<IConvertationParametersRepository> convertationParametersRepositoryMoq;

        public ConvertationParametersServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            convertationParametersRepositoryMoq = new Mock<IConvertationParametersRepository>();

            repositoryWrapperMoq.Setup(x => x.ConvertationParameters)
                .Returns(convertationParametersRepositoryMoq.Object);

            service = new ConvertationParametersService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullConvertationParameters_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            convertationParametersRepositoryMoq.Verify(x => x.Create(It.IsAny<ПараметрыКонвертации>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectConvertationParameters()
        {
            return new List<object[]>
            {
                new object[] {new ПараметрыКонвертации() { IdпараметраКонвертации = -1, Значение = ""} },
                new object[] {new ПараметрыКонвертации() { IdпараметраКонвертации = 0, Значение = ""} },
                new object[] {new ПараметрыКонвертации() { IdпараметраКонвертации = 0, Значение = "75"} }
            };
        }
        [Theory]
        [MemberDataAttribute(nameof(GetIncorrectConvertationParameters))]
        public async Task CreateAsyncNewConvertationParametersShouldNotCreateNewConvertationParameters(ПараметрыКонвертации convertationParameters)
        {
            var newConvertationParameters = convertationParameters;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newConvertationParameters));

            convertationParametersRepositoryMoq.Verify(x => x.Create(It.IsAny<ПараметрыКонвертации>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewConvertationParametersShouldCreateNewConvertationParameters()
        {
            var newConvertationParameters = new ПараметрыКонвертации()
            {
                IdпараметраКонвертации = 0,
                Значение = "75"
            };

            await service.Create(newConvertationParameters);

            convertationParametersRepositoryMoq.Verify(x => x.Create(It.IsAny<ПараметрыКонвертации>()), Times.Once);
        }
    }
}
