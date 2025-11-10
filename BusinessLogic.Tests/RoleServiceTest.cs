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
    public class RoleServiceTest
    {
        private readonly RoleService service;
        private readonly Mock<IRoleRepository> roleRepositoryMoq;

        public RoleServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            roleRepositoryMoq = new Mock<IRoleRepository>();

            repositoryWrapperMoq.Setup(x => x.Role)
                .Returns(roleRepositoryMoq.Object);

            service = new RoleService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullRole_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            roleRepositoryMoq.Verify(x => x.Create(It.IsAny<Роли>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectRole()
        {
            return new List<object[]>
            {
                new object[] {new Роли() { Idроли = -1, Название = ""} },
                new object[] {new Роли() { Idроли = 0, Название = ""} },
                new object[] {new Роли() { Idроли = 0, Название = "kek"} }
            };
        }

        [Theory]
        [MemberDataAttribute(nameof(GetIncorrectRole))]
        public async Task CreateAsyncNewRoleShouldNotCreateNewRole(Роли role)
        {
            var newRole = role;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newRole));

            roleRepositoryMoq.Verify(x => x.Create(It.IsAny<Роли>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewRoleShouldCreateNewRole()
        {
            var newRole = new Роли()
            {
                Idроли = 0,
                Название = "kek"
            };

            await service.Create(newRole);

            roleRepositoryMoq.Verify(x => x.Create(It.IsAny<Роли>()), Times.Once);
        }
    }
}
