using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using project.Contracts.ConvertationsHistory;
using BusinessLogic.Services;
using project.Contracts.User;
using Azure.Core;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertationsHistoryController : ControllerBase
    {
        private IConvertationsHistoryService _convertationsHistoryService;
        public ConvertationsHistoryController(IConvertationsHistoryService convertationsHistoryService)
        {
            _convertationsHistoryService = convertationsHistoryService;
        }

        /// <summary>
        /// Получение всех ИсторийКонвертаций
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        
        ///     }      
        /// </remarks>
        /// <returns></returns>        

        // GET api/<ConvertationsHistoryController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _convertationsHistoryService.GetAll());
        }

        /// <summary>
        /// Получение ИсторииКонвертаций по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        "IdисторииКонвертаций" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id ИсторииКонвертаций</param>
        /// <returns></returns>        

        // GET api/<ConvertationsHistoryController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _convertationsHistoryService.GetById(id);
            var response = new GetConvertationsHistoryResponse()
            {
                IdисторииКонвертаций = result.IdисторииКонвертаций,
                Idпользователя = result.Idпользователя,
                Idконвертации = result.Idконвертации,
                IdпараметровКонвертации = result.IdпараметровКонвертации
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание ИсторииКонвертаций
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {
        ///        "IdисторииКонвертаций" : "0",
        ///        "Idпользователя" : "0",
        ///        "Idконвертации" : "0",
        ///        "IdПараметровКонвертации" : "0"
        ///     }      
        /// </remarks>
        /// <param name="convertationHistory">ИсторияКонвертаций</param>
        /// <returns></returns>        

        // POST api/<ConvertationsHistoryController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateConvertationsHistoryRequest convertationHistory)
        {
            var convertationHistoryDto = convertationHistory.Adapt<ИсторияКонвертаций>();
            await _convertationsHistoryService.Create(convertationHistoryDto);
            return Ok();
        }

        /// <summary>
        /// Обнавление ИсторииКонвертаций
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     PUT /Todo
        ///     {
        ///        "IdисторииКонвертаций" : "0",
        ///        "Idпользователя" : "0",
        ///        "Idконвертации" : "0",
        ///        "IdПараметровКонвертации" : "0"
        ///     }      
        /// </remarks>
        /// <param name="convertationHistory">ИсторияКонвертаций</param>
        /// <returns></returns>        

        // PUT api/<ConvertationsHistoryController>
        [HttpPut]
        public async Task<IActionResult> Update(ИсторияКонвертаций convertationHistory)
        {
            var convertationHistoryDto = convertationHistory.Adapt<ИсторияКонвертаций>();
            await _convertationsHistoryService.Update(convertationHistoryDto);
            return Ok();
        }

        /// <summary>
        /// Удаление ИсторииКонвертаций
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     DELETE
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id ИсторииКонвертаций</param>
        /// <returns></returns>        

        // DELETE api/<ConvertationsHistoryController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _convertationsHistoryService.Delete(id);
            return Ok();
        }
    }
}