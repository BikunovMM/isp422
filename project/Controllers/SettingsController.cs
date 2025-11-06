using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using project.Contracts.Settings;
using BusinessLogic.Services;
using project.Contracts.User;
using Azure.Core;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private ISettingsService _settingsService;
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        /// <summary>
        /// Получение всех Настроек
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        
        ///     }      
        /// </remarks>
        /// <returns></returns>    

        // GET api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _settingsService.GetAll());
        }

        /// <summary>
        /// Получение Настроек по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        "IdНастроек" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id Настроек</param>
        /// <returns></returns>        

        // GET api/<UsersController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _settingsService.GetById(id);
            var response = new GetSettingsResponse()
            {
                Idнастроек = result.Idнастроек,
                Idпользователя = result.Idпользователя,
                Язык = result.Язык,
                Уведомления = result.Уведомления

            };
            return Ok(response);
        }

        /// <summary>
        /// Создание новых Настроек
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {
        ///        "IdНастроек" : "0",
        ///        "IdПользователя" : "0",
        ///        "Язык" : "Русский",
        ///        "Уведомления" : "FALSE"
        ///     }      
        /// </remarks>
        /// <param name="settings">Настройки</param>
        /// <returns></returns>        

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateSettingsRequest settings)
        {
            var settingsDto = settings.Adapt<Настройки>();
            await _settingsService.Create(settingsDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных Настроек
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     PUT /Todo
        ///     {
        ///        "IdНастроек" : "0",
        ///        "IdПользователя" : "0",
        ///        "Язык" : "Русский",
        ///        "Уведомления" : "FALSE"
        ///     }      
        /// </remarks>
        /// <param name="settings">Настройки</param>
        /// <returns></returns>        

        // PUT api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(CreateSettingsRequest settings)
        {
            var settingsDto = settings.Adapt<Настройки>();
            await _settingsService.Create(settingsDto);
            return Ok();
        }

        /// <summary>
        /// Удаление Настроек
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     DELETE
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id Настроек</param>
        /// <returns></returns>        

        // DELETE api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _settingsService.Delete(id);
            return Ok();
        }
    }
}