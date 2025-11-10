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
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.Users)
                .Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Пользователи>()), Times.Never);
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] {new Пользователи() { Idпользователя = -1, Idроли  = -1, Логин  = "", Пароль = "", АдресЭлектроннойПочты  = "", ДатаРегистрации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Пользователи() { Idпользователя = 0, Idроли  = -1, Логин  = "", Пароль = "", АдресЭлектроннойПочты  = "", ДатаРегистрации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Пользователи() { Idпользователя = -1, Idроли  = 0, Логин  = "", Пароль = "", АдресЭлектроннойПочты  = "", ДатаРегистрации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Пользователи() { Idпользователя = 0, Idроли  = 0, Логин  = "", Пароль = "", АдресЭлектроннойПочты  = "", ДатаРегистрации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Пользователи() { Idпользователя = 0, Idроли  = 0, Логин  = "qwerty", Пароль = "", АдресЭлектроннойПочты  = "", ДатаРегистрации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Пользователи() { Idпользователя = 0, Idроли  = 0, Логин  = "qwerty", Пароль = "qwerty", АдресЭлектроннойПочты  = "", ДатаРегистрации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Пользователи() { Idпользователя = 0, Idроли  = 0, Логин  = "qwerty", Пароль = "qwerty", АдресЭлектроннойПочты  = "qwerty@gmail.com", ДатаРегистрации = DateOnly.FromDateTime(DateTime.Today)} },
                new object[] {new Пользователи() { Idпользователя = 0, Idроли  = 0, Логин  = "qwerty", Пароль = "qwerty", АдресЭлектроннойПочты  = "qwerty@gmail.com", ДатаРегистрации = DateOnly.FromDateTime(DateTime.Today)} }
            };
        }

        [Theory]
        [MemberDataAttribute(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(Пользователи user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Пользователи>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new Пользователи()
            {
                Idпользователя = 0,
                Idроли = 0,
                Логин = "qwerty",
                Пароль = "qwerty",
                АдресЭлектроннойПочты = "qwerty@gmail.com",
                ДатаРегистрации = DateOnly.FromDateTime(DateTime.Today)
            };

            await service.Create(newUser);

            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Пользователи>()), Times.Once);
        }
    }
}
