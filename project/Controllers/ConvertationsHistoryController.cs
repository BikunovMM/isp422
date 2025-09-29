using BusinnessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertationsHistoryController : ControllerBase
    {
        private IConvertationsHistoryService _convertationsHistoryService;
        public ConvertationsHistoryController(IConvertationsHistoryService convertationsHistoryService)
        {
            _convertationsHistoryService = convertationsHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _convertationsHistoryService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _convertationsHistoryService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ИсторияКонвертаций convertationHistory)
        {
            await _convertationsHistoryService.Create(convertationHistory);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ИсторияКонвертаций convertationHistory)
        {
            await _convertationsHistoryService.Update(convertationHistory);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _convertationsHistoryService.Delete(id);
            return Ok();
        }
    }
}