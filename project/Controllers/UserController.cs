using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using project.Contracts.User;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetById(id));
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "idпользователя" : "0",
        ///        "idроли" : "0",
        ///        "логин" : "lol_kek",
        ///        "пароль" : "12345",
        ///        "адресэлектроннойпочты" : "lol_kek@mail.ru",
        ///        "датарегистрации" : "01.01.2007"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        /// 

        // POST api/UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = new Пользователи()
            {
                Idпользователя { get; set; }

                Idроли { get; set; }

                Логин { get; set; } = null!;

                Пароль { get; set; } = null!;

                АдресЭлектроннойПочты { get; set; }

                ДатаРегистрации { get; set; }

                IdролиNavigation { get; set; } = null!;

                ИспользованиеФорматовs { get; set; } = new List<ИспользованиеФорматов>();

                ИсторияКонвертацийs { get; set; } = new List<ИсторияКонвертаций>();

                Настройкиs { get; set; } = new List<Настройки>();

            }
            await _userService.Create(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Пользователи user)
        {
            await _userService.Update(user);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}