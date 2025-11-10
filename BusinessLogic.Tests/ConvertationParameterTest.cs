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
    public class ConvertationParameterServiceTest
    {
        private readonly ConvertationParameterService service;
        private readonly Mock<IConvertationParameterRepository> convertationParameterRepositoryMoq;

        public ConvertationParameterServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            convertationParameterRepositoryMoq = new Mock<IConvertationParameterRepository>();

            repositoryWrapperMoq.Setup(x => x.ConvertationParameter)
                .Returns(convertationParameterRepositoryMoq.Object);

            service = new ConvertationParameterService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullConvertationParameter_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            convertationParameterRepositoryMoq.Verify(x => x.Create(It.IsAny<ПараметрКонвертации>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectConvertationParameter()
        {
            return new List<object[]>
            {
                new object[] {new ПараметрКонвертации() { IdпараметраКонвертации = -1, Название = ""} },
                new object[] {new ПараметрКонвертации() { IdпараметраКонвертации = 0, Название = ""} },
                new object[] {new ПараметрКонвертации() { IdпараметраКонвертации = 0, Название = "AudioQuality" } }
            };
        }
        [Theory]
        [MemberDataAttribute(nameof(GetIncorrectConvertationParameter))]
        public async Task CreateAsyncNewConvertationParameterShouldNotCreateNewConvertationParameter(ПараметрКонвертации convertationParameter)
        {
            var newConvertationParameter = convertationParameter;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newConvertationParameter));

            convertationParameterRepositoryMoq.Verify(x => x.Create(It.IsAny<ПараметрКонвертации>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewConvertationParameterShouldCreateNewConvertationParameter()
        {
            var newConvertationParameter = new ПараметрКонвертации()
            {
                IdпараметраКонвертации = 0,
                Название = "AudioQuality"
            };

            await service.Create(newConvertationParameter);

            convertationParameterRepositoryMoq.Verify(x => x.Create(It.IsAny<ПараметрКонвертации>()), Times.Once);
        }
    }
}
