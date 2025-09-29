using BusinnessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _convertationParametersService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _convertationParametersService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ПараметрыКонвертации convertationParameters)
        {
            await _convertationParametersService.Create(convertationParameters);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ПараметрыКонвертации convertationParameters)
        {
            await _convertationParametersService.Update(convertationParameters);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _convertationParametersService.Delete(id);
            return Ok();
        }
    }
}