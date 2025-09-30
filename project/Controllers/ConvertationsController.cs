using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _convertationsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _convertationsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Конвертации convertation)
        {
            await _convertationsService.Create(convertation);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Конвертации convertation)
        {
            await _convertationsService.Update(convertation);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _convertationsService.Delete(id);
            return Ok();
        }
    }
}