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
    public class UsingFormatsServiceTest
    {
        private readonly UsingFormatsService service;
        private readonly Mock<IUsingFormatsRepository> usingFormatsRepositoryMoq;

        public UsingFormatsServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            usingFormatsRepositoryMoq = new Mock<IUsingFormatsRepository>();

            repositoryWrapperMoq.Setup(x => x.UsingFormats)
                .Returns(usingFormatsRepositoryMoq.Object);

            service = new UsingFormatsService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullUsingFormats_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            usingFormatsRepositoryMoq.Verify(x => x.Create(It.IsAny<ИспользованиеФорматов>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectUsingFormats()
        {
            return new List<object[]>
            {
                new object[] {new ИспользованиеФорматов() { IdиспользованияФорматов = -1, Idпользователя = -1, Idформата = -1, КоличествоИспользований = -1} },
                new object[] {new ИспользованиеФорматов() { IdиспользованияФорматов = 0, Idпользователя = -1, Idформата = -1, КоличествоИспользований = -1} },
                new object[] {new ИспользованиеФорматов() { IdиспользованияФорматов = 0, Idпользователя = 0, Idформата = -1, КоличествоИспользований = -1} },
                new object[] {new ИспользованиеФорматов() { IdиспользованияФорматов = 0, Idпользователя = 0, Idформата = 0, КоличествоИспользований = -1} },
                new object[] {new ИспользованиеФорматов() { IdиспользованияФорматов = 0, Idпользователя = 0, Idформата = 0, КоличествоИспользований = 0} }
            };
        }

        [Theory]
        [MemberDataAttribute(nameof(GetIncorrectUsingFormats))]
        public async Task CreateAsyncNewUsingFormatsShouldNotCreateNewUsingFormats(ИспользованиеФорматов usingFormats)
        {
            var newUsingFormats = usingFormats;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUsingFormats));

            usingFormatsRepositoryMoq.Verify(x => x.Create(It.IsAny<ИспользованиеФорматов>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUsingFormatsShouldCreateNewUsingFormats()
        {
            var newUsingFormats = new ИспользованиеФорматов()
            {
                IdиспользованияФорматов = 0,
                Idпользователя = 0,
                Idформата = 0,
                КоличествоИспользований = 0
            };

            await service.Create(newUsingFormats);

            usingFormatsRepositoryMoq.Verify(x => x.Create(It.IsAny<ИспользованиеФорматов>()), Times.Once);
        }
    }
}
