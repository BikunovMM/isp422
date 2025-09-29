using BusinnessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsingFormatsController : ControllerBase
    {
        private IUsingFormatsService _usingFormatsService;
        public UsingFormatsController(IUsingFormatsService usingFormatsService)
        {
            _usingFormatsService = usingFormatsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _usingFormatsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _usingFormatsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ИспользованиеФорматов usingFormat)
        {
            await _usingFormatsService.Create(usingFormat);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ИспользованиеФорматов usingFormat)
        {
            await _usingFormatsService.Update(usingFormat);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _usingFormatsService.Delete(id);
            return Ok();
        }
    }
}