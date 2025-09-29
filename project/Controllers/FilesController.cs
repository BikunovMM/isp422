using BusinnessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _filesService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Файлы file)
        {
            await _filesService.Create(file);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Файлы file)
        {
            await _filesService.Update(file);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _filesService.Delete(id);
            return Ok();
        }
    }
}