using BusinnessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _fileFormatsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _fileFormatsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ФорматыФайлов fileFormat)
        {
            await _fileFormatsService.Create(fileFormat);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ФорматыФайлов fileFormat)
        {
            await _fileFormatsService.Update(fileFormat);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fileFormatsService.Delete(id);
            return Ok();
        }
    }
}