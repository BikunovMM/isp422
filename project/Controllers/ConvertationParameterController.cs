using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _convertationParameterService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _convertationParameterService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ПараметрКонвертации convertationParameter)
        {
            await _convertationParameterService.Create(convertationParameter);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ПараметрКонвертации convertationParameter)
        {
            await _convertationParameterService.Update(convertationParameter);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _convertationParameterService.Delete(id);
            return Ok();
        }
    }
}