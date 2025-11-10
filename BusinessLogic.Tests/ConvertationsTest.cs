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
    public class ConvertationsServiceTest
    {
        private readonly ConvertationsService service;
        private readonly Mock<IConvertationsRepository> convertationsRepositoryMoq;

        public ConvertationsServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            convertationsRepositoryMoq = new Mock<IConvertationsRepository>();

            repositoryWrapperMoq.Setup(x => x.Convertations)
                .Returns(convertationsRepositoryMoq.Object);

            service = new ConvertationsService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullConvertations_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            convertationsRepositoryMoq.Verify(x => x.Create(It.IsAny<Конвертации>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectConvertations()
        {
            return new List<object[]>
            {
                new object[] {new Конвертации() { Idконвертации = -1, IdвходногоФайла = -1, IdвыходногоФайла = -1, IdпараметровКонвертации = -1, ДатаКонвертации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Конвертации() { Idконвертации = 0, IdвходногоФайла = -1, IdвыходногоФайла = -1, IdпараметровКонвертации = -1, ДатаКонвертации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Конвертации() { Idконвертации = 0, IdвходногоФайла = 0, IdвыходногоФайла = -1, IdпараметровКонвертации = -1, ДатаКонвертации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Конвертации() { Idконвертации = 0, IdвходногоФайла = 0, IdвыходногоФайла = 0, IdпараметровКонвертации = -1, ДатаКонвертации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Конвертации() { Idконвертации = 0, IdвходногоФайла = 0, IdвыходногоФайла = 0, IdпараметровКонвертации = 0, ДатаКонвертации = DateOnly.FromDateTime(DateTime.Today) } }
            };
        }
        [Theory]
        [MemberDataAttribute(nameof(GetIncorrectConvertations))]
        public async Task CreateAsyncNewConvertationsShouldNotCreateNewConvertations(Конвертации convertations)
        {
            var newConvertations = convertations;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newConvertations));

            convertationsRepositoryMoq.Verify(x => x.Create(It.IsAny<Конвертации>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewConvertationsShouldCreateNewConvertations()
        {
            var newConvertations = new Конвертации()
            {
                Idконвертации = 0,
                IdвходногоФайла = 0,
                IdвыходногоФайла = 0,
                IdпараметровКонвертации = 0,
                ДатаКонвертации = DateOnly.FromDateTime(DateTime.Today)
            };

            await service.Create(newConvertations);

            convertationsRepositoryMoq.Verify(x => x.Create(It.IsAny<Конвертации>()), Times.Once);
        }
    }
}
