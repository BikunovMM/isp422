using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using project.Contracts.User;
using project.Contracts.UsingFormats;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsingFormatsController : ControllerBase
    {
        private IUsingFormatsService _usingFormatsService;
        public UsingFormatsController(IUsingFormatsService usingFormatsService)
        {
            _usingFormatsService = usingFormatsService;
        }

        /// <summary>
        /// Получение всех ИспользованныхФорматов
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
        /// <param name="model">ИспользованиеФорматов</param>
        /// <returns></returns>

        // GET api/<UsingFormatsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _usingFormatsService.GetAll());
        }

        /// <summary>
        /// Получение ИспользованныхФорматов по id
        /// </summary>
        /// <remarks>
        /// Приер запроса:
        /// 
        ///     GET
        ///     {
        ///        "IdИспользованияФорматов" : "0"
        ///     }
        /// 
        /// </remarks>
        /// <param name="model">ИспользованиеФорматов</param>
        /// <param name="id">id ИспользованияФорматов</param>
        /// <returns></returns>

        // GET api/<UsingFormatsController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _usingFormatsService.GetById(id);
            var response = new GetUsingFormatsResponse()
            {
                IdиспользованияФорматов = result.IdиспользованияФорматов,
                Idпользователя = result.Idпользователя,
                Idформата = result.Idформата,
                КоличествоИспользований = result.КоличествоИспользований
            };
            return Ok(response);

            return Ok(await _usingFormatsService.GetById(id));
        }

        /// <summary>
        /// Создание нового ИспользованияФорматов
        /// </summary>
        /// <remarks>
        /// Приер запроса:
        /// 
        ///     POST
        ///     {
        ///        "IdИспользованияФорматов" : "0",
        ///        "IdПользователя" : "0",
        ///        "IdФормата" : "0",
        ///        "КоличествоИспользований" : "228"
        ///     }
        /// 
        /// </remarks>
        /// <param name="usingFormat">ИспользованиеФорматов</param>
        /// <returns></returns>

        // POST api/<UsingFormatsController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUsingFormatsRequest usingFormat)
        {
            var usingFormatsDto = usingFormat.Adapt<ИспользованиеФорматов>();
            await _usingFormatsService.Create(usingFormatsDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных ИспользованияФорматов
        /// </summary>
        /// <remarks>
        /// Приер запроса:
        /// 
        ///     UPDATE
        ///     {
        ///        "IdИспользованияФорматов" : "0",
        ///        "IdПользователя" : "0",
        ///        "IdФормата" : "0",
        ///        "КоличествоИспользований" : "228"
        ///     }
        /// 
        /// </remarks>
        /// <param name="usingFormat">ИспользованиеФормата</param>
        /// <returns></returns>

        // PUT api/<UsingFormatsController>
        [HttpPut]
        public async Task<IActionResult> Update(CreateUsingFormatsRequest usingFormat)
        {
            var usingFormatsDto = usingFormat.Adapt<ИспользованиеФорматов>();
            await _usingFormatsService.Update(usingFormatsDto);
            return Ok();
        }

        /// <summary>
        /// Удаление ИспользованияФорматов
        /// </summary>
        /// <remarks>
        /// Приер запроса:
        /// 
        ///     DELETE
        ///     {
        ///        "id" : "0"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id">id ИспользованияФормата</param>
        /// <returns></returns>

        // DELETE api/<UsingFormatsController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _usingFormatsService.Delete(id);
            return Ok();
        }
    }
}