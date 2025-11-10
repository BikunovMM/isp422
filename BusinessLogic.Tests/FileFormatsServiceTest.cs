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
    public class FileFormatsServiceTest
    {
        private readonly FileFormatsService service;
        private readonly Mock<IFileFormatsRepository> fileFormatsRepositoryMoq;

        public FileFormatsServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            fileFormatsRepositoryMoq = new Mock<IFileFormatsRepository>();

            repositoryWrapperMoq.Setup(x => x.FileFormats)
                .Returns(fileFormatsRepositoryMoq.Object);

            service = new FileFormatsService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullFileFormats_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            fileFormatsRepositoryMoq.Verify(x => x.Create(It.IsAny<ФорматыФайлов>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectFileFormats()
        {
            return new List<object[]>
            {
                new object[] {new ФорматыФайлов() { Idформата = -1, Название = ""} },
                new object[] {new ФорматыФайлов() { Idформата = 0, Название = ""} },
                new object[] {new ФорматыФайлов() { Idформата = 0, Название = "png"} }
            };
        }

        [Theory]
        [MemberDataAttribute(nameof(GetIncorrectFileFormats))]
        public async Task CreateAsyncNewFileFormatsShouldNotCreateNewFileFormats(ФорматыФайлов fileFormats)
        {
            var newFileFormats = fileFormats;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newFileFormats));

            fileFormatsRepositoryMoq.Verify(x => x.Create(It.IsAny<ФорматыФайлов>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewFileFormatsShouldCreateNewFileFormats()
        {
            var newFileFormats = new ФорматыФайлов()
            {
                Idформата = 0,
                Название = "png"
            };

            await service.Create(newFileFormats);

            fileFormatsRepositoryMoq.Verify(x => x.Create(It.IsAny<ФорматыФайлов>()), Times.Once);
        }
    }
}
