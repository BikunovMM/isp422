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
    public class ConvertationsHistoryServiceTest
    {
        private readonly ConvertationsHistoryService service;
        private readonly Mock<IConvertationsHistoryRepository> convertationsHistoryRepositoryMoq;

        public ConvertationsHistoryServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            convertationsHistoryRepositoryMoq = new Mock<IConvertationsHistoryRepository>();

            repositoryWrapperMoq.Setup(x => x.ConvertationsHistory)
                .Returns(convertationsHistoryRepositoryMoq.Object);

            service = new ConvertationsHistoryService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullConvertationsHistory_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            convertationsHistoryRepositoryMoq.Verify(x => x.Create(It.IsAny<ИсторияКонвертаций>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectConvertationsHistory()
        {
            return new List<object[]>
            {
                new object[] {new ИсторияКонвертаций() { IdисторииКонвертаций = -1, Idконвертации = -1, Idпользователя = -1} },
                new object[] {new ИсторияКонвертаций() { IdисторииКонвертаций = 0, Idконвертации = -1, Idпользователя = -1} },
                new object[] {new ИсторияКонвертаций() { IdисторииКонвертаций = 0, Idконвертации = 0, Idпользователя = -1} },
                new object[] {new ИсторияКонвертаций() { IdисторииКонвертаций = 0, Idконвертации = 0, Idпользователя = 0} },
            };
        }
        [Theory]
        [MemberDataAttribute(nameof(GetIncorrectConvertationsHistory))]
        public async Task CreateAsyncNewConvertationsHistoryShouldNotCreateNewConvertationsHistory(ИсторияКонвертаций convertationsHistory)
        {
            var newConvertationsHistory = convertationsHistory;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newConvertationsHistory));

            convertationsHistoryRepositoryMoq.Verify(x => x.Create(It.IsAny<ИсторияКонвертаций>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewConvertationsHistoryShouldCreateNewConvertationsHistory()
        {
            var newConvertationsHistory = new ИсторияКонвертаций()
            {
                IdисторииКонвертаций = 0,
                Idконвертации = 0,
                Idпользователя = 0                
            };

            await service.Create(newConvertationsHistory);

            convertationsHistoryRepositoryMoq.Verify(x => x.Create(It.IsAny<ИсторияКонвертаций>()), Times.Once);
        }
    }
}
