using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
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

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <remarks>
        /// Приер запроса:
        /// 
        ///     GET
        ///     {
        ///        
        ///     }
        /// 
        /// </remarks>
        /// <returns></returns>

        // GET api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        /// Получение пользователя по id
        /// </summary>
        /// <remarks>
        /// Приер запроса:
        /// 
        ///     GET
        ///     {
        ///        "IDПользователя" : "0"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id">id Пользователя</param>
        /// <returns></returns>

        // GET api/<UsersController>
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
                ДатаРегистрации = DateOnly.FromDateTime(DateTime.Today)
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
        /// <param name="request">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
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
        ///     PUT /Todo
        ///     {
        ///        "IDПользователя" : "0",
        ///        "IDРоли" : "0",
        ///        "Логин" : "lol_kek",
        ///        "Пароль" : "12345",
        ///        "АдресЭлектроннойПочты" : "lol_kek@mail.ru",
        ///        "ДатаРегистрации" : "01.01.2007"
        ///     }      
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns>
        /// </returns>      

        // PUT api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(CreateUserRequest user)
        {
            var userDto = user.Adapt<Пользователи>();
            await _userService.Update(userDto);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     DELETE
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id Пользователя</param>
        /// <returns></returns>        

        // DELETE api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}