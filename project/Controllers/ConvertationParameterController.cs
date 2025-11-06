using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using project.Contracts.ConvertationParameter;
using BusinessLogic.Services;
using project.Contracts.User;
using Azure.Core;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertationParameterController : ControllerBase
    {
        private IConvertationParameterService _convertationParameterService;
        public ConvertationParameterController(IConvertationParameterService convertationParameterService)
        {
            _convertationParameterService = convertationParameterService;
        }

        /// <summary>
        /// Получение всех ПараметровКонвертации
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        
        ///     }      
        /// </remarks>
        /// <returns></returns>        

        // GET api/<ConvertationPatameterController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _convertationParameterService.GetAll());
        }

        /// <summary>
        /// Получение ПараметраКонвертации по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        "IdпараметраКонвертации" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id ПараметраКонвертации</param>
        /// <returns></returns>        

        // GET api/<ConvertationPatameterController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _convertationParameterService.GetById(id);
            var response = new GetConvertationParameterResponse()
            {
                IdпараметраКонвертации = result.IdпараметраКонвертации,
                Название = result.Название
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового ПараметраКонвертации
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {
        ///        "IdпараметраКонвертации" : "0",
        ///        "Название" : "ВидеоКодек"
        ///     }      
        /// </remarks>
        /// <param name="convertationParameter">ПараметрКонвертации</param>
        /// <returns></returns>        

        // POST api/<ConvertationPatameterController>
        [HttpPost]
        public async Task<IActionResult> Add(ПараметрКонвертации convertationParameter)
        {
            var convertationParameterDto = convertationParameter.Adapt<ПараметрКонвертации>();
            await _convertationParameterService.Create(convertationParameterDto);
            return Ok();
        }

        /// <summary>
        /// Обновление ПараметраКонвертации
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     PUT /Todo
        ///     {
        ///        "IdпараметраКонвертации" : "0",
        ///        "Название" : "ВидеоКодек"
        ///     }      
        /// </remarks>
        /// <param name="convertationParameter">ПараметрКонвертации</param>
        /// <returns></returns>        

        // PUT api/<ConvertationPatameterController>
        [HttpPut]
        public async Task<IActionResult> Update(ПараметрКонвертации convertationParameter)
        {
            var convertationParameterDto = convertationParameter.Adapt<ПараметрКонвертации>();
            await _convertationParameterService.Update(convertationParameterDto);
            return Ok();
        }

        /// <summary>
        /// Удаление ПараметраКонвертации
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     DELETE
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id ПараметраКонвертации</param>
        /// <returns></returns>        

        // DELETE api/<ConvertationPatameterController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _convertationParameterService.Delete(id);
            return Ok();
        }
    }
}