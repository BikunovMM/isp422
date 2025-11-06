using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using project.Contracts.ConvertationParameters;
using BusinessLogic.Services;
using project.Contracts.User;
using Azure.Core;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertationParametersController : ControllerBase
    {
        private IConvertationParametersService _convertationParametersService;
        public ConvertationParametersController(IConvertationParametersService convertationParametersService)
        {
            _convertationParametersService = convertationParametersService;
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

        // GET api/<ConvertationPatametersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _convertationParametersService.GetAll());
        }

        /// <summary>
        /// Получение ПараметровКонвертации по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {                
        ///        "IdпараметраКонвертации" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id ПараметровКонвертации</param>
        /// <returns></returns>        

        // GET api/<ConvertationPatametersController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _convertationParametersService.GetById(id);
            var response = new GetConvertationParametersResponse()
            {
                IdпараметраКонвертации = result.IdпараметраКонвертации,
                Значение = result.Значение

            };
            return Ok(response);
        }

        /// <summary>
        /// Создание ПараметровКонвертации
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {                
        ///        "IdпараметраКонвертации" : "0",
        ///        "Значение" : "0",
        ///     }      
        /// </remarks>
        /// <param name="convertationParameters">ПараметрыКонвертации</param>
        /// <returns></returns>        

        // POST api/<ConvertationPatametersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateConvertationParametersRequest convertationParameters)
        {
            var convertationParametersDto = convertationParameters.Adapt<ПараметрыКонвертации>();
            await _convertationParametersService.Create(convertationParametersDto);
            return Ok();
        }

        /// <summary>
        /// Изменение ПараметровКонвертации
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     PUT /Todo
        ///     {                
        ///        "IdпараметраКонвертации" : "0",
        ///        "Значение" : "0",
        ///     }      
        /// </remarks>
        /// <param name="convertationParameters">ПараметрыКонвертации</param>
        /// <returns></returns>        

        // PUT api/<ConvertationPatametersController>
        [HttpPut]
        public async Task<IActionResult> Update(ПараметрыКонвертации convertationParameters)
        {
            var convertationParametersDto = convertationParameters.Adapt<ПараметрыКонвертации>();
            await _convertationParametersService.Update(convertationParametersDto);
            return Ok();
        }

        /// <summary>
        /// Удаление ПараметровКонвертации
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     DELETE
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id ПараметровКонвертации</param>
        /// <returns></returns>        

        // DELETE api/<ConvertationPatametersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _convertationParametersService.Delete(id);
            return Ok();
        }
    }
}