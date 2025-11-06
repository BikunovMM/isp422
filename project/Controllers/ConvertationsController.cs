using Azure.Core;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using project.Contracts.Convertations;
using Mapster;
using project.Contracts.Convertations;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertationsController : ControllerBase
    {
        private IConvertationsService _convertationsService;
        public ConvertationsController(IConvertationsService convertationsService)
        {
            _convertationsService = convertationsService;
        }

        /// <summary>
        /// Получение всех Конвертаций
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        
        ///     }      
        /// </remarks>
        /// <returns></returns>        

        // GET api/<ConvertationsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _convertationsService.GetAll());
        }

        /// <summary>
        /// Получение Конвертации по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        "Idконвертации" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id Конвертации</param>
        /// <returns></returns>        

        // GET api/<ConvertationsController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _convertationsService.GetById(id);
            var response = new GetConvertationsResponse()
            {
                Idконвертации = result.Idконвертации,
                IdвходногоФайла = result.IdвходногоФайла,
                IdвыходногоФайла = result.IdвыходногоФайла,
                IdпараметровКонвертации = result.IdпараметровКонвертации,
                ДатаКонвертации = DateTime.Now

            };
            return Ok(response);
        }

        /// <summary>
        /// Создание новой Конвертации
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {
        ///        "Idконвертации" : "0",
        ///        "IdвходногоФайла" : "0",
        ///        "IdвыходногоФайла" : "0",
        ///        "IdпараметровКонвертации" : "0",
        ///        "ДатаКонвертации" : "01-02-2007",
        ///     }      
        /// </remarks>
        /// <param name="convertation">Конвертация</param>
        /// <returns></returns>        

        // POST api/<ConvertationsController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateConvertationsRequest convertation)
        {
            var convertationDto = convertation.Adapt<Конвертации>();
            await _convertationsService.Create(convertationDto);
            return Ok();
        }

        /// <summary>
        /// Обновление Конвертации
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     PUT /Todo
        ///     {
        ///        "Idконвертации" : "0",
        ///        "IdвходногоФайла" : "0",
        ///        "IdвыходногоФайла" : "0",
        ///        "IdпараметровКонвертации" : "0",
        ///        "ДатаКонвертации" : "01-02-2007",
        ///     }      
        /// </remarks>
        /// <param name="convertation">Конвертация</param>
        /// <returns></returns>        

        // PUT api/<ConvertationsController>
        [HttpPut]
        public async Task<IActionResult> Update(Конвертации convertation)
        {
            var convertationDto = convertation.Adapt<Конвертации>();
            await _convertationsService.Update(convertationDto);
            return Ok();
        }

        /// <summary>
        /// Удаление Конвертации
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     DELETE
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id Конвертации</param>
        /// <returns></returns>        

        // DELETE api/<ConvertationsController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _convertationsService.Delete(id);
            return Ok();
        }
    }
}