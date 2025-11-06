using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using project.Contracts.FileFormats;
using BusinessLogic.Services;
using project.Contracts.User;
using Azure.Core;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileFormatsController : ControllerBase
    {
        private IFileFormatsService _fileFormatsService;
        public FileFormatsController(IFileFormatsService fileFormatsService)
        {
            _fileFormatsService = fileFormatsService;
        }

        /// <summary>
        /// Получение всех ФорматовФайлов
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        
        ///     }      
        /// </remarks>
        /// <returns></returns>        

        // GET api/<FileFormatsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _fileFormatsService.GetAll());
        }

        /// <summary>
        /// Получение ФорматаФайла по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        "Idформата" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id ФорматаФайлов</param>
        /// <returns></returns>        

        // GET api/<FileFormatsController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _fileFormatsService.GetById(id);
            var response = new GetFileFormatsResponse()
            {
                Idформата = result.Idформата,
                Название = result.Название
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового ФорматаФайла
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {
        ///        "Idформата" : "0",
        ///        "Название" : "png"
        ///     }      
        /// </remarks>
        /// <param name="fileFormat">ФорматФайлов</param>
        /// <returns></returns>        

        // POST api/<FileFormatsController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateFileFormatsRequest fileFormat)
        {
            var fileFormatDto = fileFormat.Adapt<ФорматыФайлов>();
            await _fileFormatsService.Create(fileFormatDto);
            return Ok();
        }

        /// <summary>
        /// Обновление ФорматаФайла
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     PUT /Todo
        ///     {
        ///        "Idформата" : "0",
        ///        "Название" : "png"
        ///     }      
        /// </remarks>
        /// <param name="fileFormat">ФорматФайлов</param>
        /// <returns></returns>        

        // PUT api/<FileFormatsController>
        [HttpPut]
        public async Task<IActionResult> Update(CreateFileFormatsRequest fileFormat)
        {
            var fileFormatDto = fileFormat.Adapt<ФорматыФайлов>();
            await _fileFormatsService.Update(fileFormatDto);
            return Ok();
        }

        /// <summary>
        /// Удаление ФорматаФайла
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     DELETE
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id ФорматаФайла</param>
        /// <returns></returns>        

        // DELETE api/<FileFormatsController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fileFormatsService.Delete(id);
            return Ok();
        }
    }
}