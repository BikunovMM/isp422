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
    public class FilesServiceTest
    {
        private readonly FilesService service;
        private readonly Mock<IFilesRepository> filesRepositoryMoq;

        public FilesServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            filesRepositoryMoq = new Mock<IFilesRepository>();

            repositoryWrapperMoq.Setup(x => x.Files)
                .Returns(filesRepositoryMoq.Object);

            service = new FilesService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullFiles_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            filesRepositoryMoq.Verify(x => x.Create(It.IsAny<Файлы>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectFiles()
        {
            return new List<object[]>
            {
                new object[] {new Файлы() { Idфайла = -1, Idформата = -1, НазваниеФайла = ""} },
                new object[] {new Файлы() { Idфайла = 0, Idформата = -1, НазваниеФайла = ""} },
                new object[] {new Файлы() { Idфайла = 0, Idформата = 0, НазваниеФайла = ""} },
                new object[] {new Файлы() { Idфайла = 0, Idформата = 0, НазваниеФайла = "Batya.png"} }
            };
        }

        [Theory]
        [MemberDataAttribute(nameof(GetIncorrectFiles))]
        public async Task CreateAsyncNewFilesShouldNotCreateNewFiles(Файлы files)
        {
            var newFiles = files;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newFiles));

            filesRepositoryMoq.Verify(x => x.Create(It.IsAny<Файлы>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewFilesShouldCreateNewFiles()
        {
            var newFiles = new Файлы()
            {
                Idфайла = 0,
                Idформата = 0,
                НазваниеФайла = "Batya.png"
            };

            await service.Create(newFiles);

            filesRepositoryMoq.Verify(x => x.Create(It.IsAny<Файлы>()), Times.Once);
        }
    }
}
