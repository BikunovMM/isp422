using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using project.Contracts.User;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        /// <summary>
        /// Кнонструктор контроллера. Сохраняет аргумент в приватное поле _user_service *-*
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {
        ///        "IDПользователя" : "0",
        ///        "IDРоли" : "0",
        ///        "Логин" : "lol_kek",
        ///        "Пароль" : "12345",
        ///        "АдресЭлектроннойПочты" : "lol_kek@mail.ru",
        ///        "ДатаРегистрации" : "01.01.2007"
        ///     }      
        /// </remarks>
        /// <param name="model">Пользователи</param>
        /// <returns>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="model">Пользователи</param>
        /// <returns>
        ///     GET
        ///     {
        ///        "IDПользователя" : "0",
        ///        "IDРоли" : "0",
        ///        "Логин" : "lol_kek",
        ///        "Пароль" : "12345",
        ///        "АдресЭлектроннойПочты" : "lol_kek@mail.ru",
        ///        "ДатаРегистрации" : "01.01.2007"
        ///     }
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        /// Получение пользователя по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "IDПользователя": "8459759479345798437593475437534594"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователи</param>
        /// <returns>
        ///     GET
        ///     {
        ///        "IDПользователя" : "0",
        ///        "IDРоли" : "0",
        ///        "Логин" : "lol_kek",
        ///        "Пароль" : "12345",
        ///        "АдресЭлектроннойПочты" : "lol_kek@mail.ru",
        ///        "ДатаРегистрации" : "01.01.2007"
        ///     }
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse()
            {
                IDПользователя = result.Idпользователя,
                IDРоли = result.Idроли,
                Логин = result.Логин,
                Пароль = result.Пароль,
                АдресЭлектроннойПочты = result.АдресЭлектроннойПочты!,
                ДатаРегистрации = DateTime.Now
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "Логин" : "lol_kek",
        ///        "Пароль" : "12345",
        ///        "АдресЭлектроннойПочты" : "lol_kek@mail.ru"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователи</param>
        /// <returns>
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<Пользователи>();
            await _userService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {
        ///        "IDПользователя" : "0",
        ///        "IDРоли" : "0",
        ///        "Логин" : "lol_kek",
        ///        "Пароль" : "12345",
        ///        "АдресЭлектроннойПочты" : "lol_kek@mail.ru",
        ///        "ДатаРегистрации" : "01.01.2007"
        ///     }      
        /// </remarks>
        /// <param name="model">Пользователи</param>
        /// <returns>
        /// </returns>      
        [HttpPut]
        public async Task<IActionResult> Update(Пользователи user)
        {
            await _userService.Update(user);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {
        ///        "IDПользователя" : "0",
        ///        "IDРоли" : "0",
        ///        "Логин" : "lol_kek",
        ///        "Пароль" : "12345",
        ///        "АдресЭлектроннойПочты" : "lol_kek@mail.ru",
        ///        "ДатаРегистрации" : "01.01.2007"
        ///     }      
        /// </remarks>
        /// <param name="model">Пользователи</param>
        /// <returns>        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}