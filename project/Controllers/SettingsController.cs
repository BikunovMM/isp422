using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private ISettingsService _settingsService;
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _settingsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _settingsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Настройки settings)
        {
            await _settingsService.Create(settings);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Настройки role)
        {
            await _settingsService.Update(role);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _settingsService.Delete(id);
            return Ok();
        }
    }
}