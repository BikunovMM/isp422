using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using project.Contracts.Files;
using BusinessLogic.Services;
using Azure.Core;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private IFilesService _filesService;
        public FilesController(IFilesService filesService)
        {
            _filesService = filesService;
        }

        /// <summary>
        /// Получение всех Файлов
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        
        ///     }      
        /// </remarks>
        /// <returns></returns>        

        // GET api/<FilesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filesService.GetAll());
        }

        /// <summary>
        /// Получение Файла по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id Файла</param>
        /// <returns></returns>        

        // GET api/<FilesController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _filesService.GetById(id);
            var response = new GetFilesResponse()
            {
                Idфайла = result.Idфайла,
                НазваниеФайла = result.НазваниеФайла,
                Idформата = result.Idформата

            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового Файла
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {
        ///        "id" : "0",
        ///        "Название" : "img00_eshkere422.png"
        ///     }      
        /// </remarks>
        /// <param name="file">Файл</param>
        /// <returns></returns>        

        // POST api/<FilesController>
        [HttpPost]
        public async Task<IActionResult> Add(GetFilesResponse file)
        {
            var filesDto = file.Adapt<Файлы>();
            await _filesService.Create(filesDto);
            return Ok();
        }

        /// <summary>
        /// Обнавление Файла
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     PUT /Todo
        ///     {
        ///        "id" : "0",
        ///        "Название" : "img00_eshkere422.png"
        ///     }      
        /// </remarks>
        /// <param name="file">Файл</param>
        /// <returns></returns>        

        // PUT api/<FilesController>
        [HttpPut]
        public async Task<IActionResult> Update(CreateFilesRequest file)
        {
            var filesDto = file.Adapt<Файлы>();
            await _filesService.Update(filesDto);
            return Ok();
        }

        /// <summary>
        /// Удаление Файла
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     DELETE
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id Файла</param>
        /// <returns></returns>        

        // DELETE api/<FilesController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _filesService.Delete(id);
            return Ok();
        }
    }
}