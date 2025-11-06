using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using project.Contracts.Role;
using BusinessLogic.Services;
using project.Contracts.User;
using Azure.Core;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Получение всех Ролей
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        
        ///     }      
        /// </remarks>
        /// <returns></returns>        

        // GET api/<RoleController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleService.GetAll());
        }

        /// <summary>
        /// Получение Роли по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     GET /Todo
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id Роли</param>
        /// <returns></returns>        

        // GET api/<RoleController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roleService.GetById(id);
            var response = new GetRoleResponse()
            {
                Idроли = result.Idроли,
                Название = result.Название

            };
            return Ok(response);
        }

        /// <summary>
        /// Создание новой Роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     POST /Todo
        ///     {
        ///        "id" : "0",
        ///        "Название" : "РайнГослинг"
        ///     }      
        /// </remarks>
        /// <param name="role">Роль</param>
        /// <returns></returns>        

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRoleRequest role)
        {
            var roleDto = role.Adapt<Роли>();
            await _roleService.Create(roleDto);
            return Ok();
        }

        /// <summary>
        /// Обнавление Роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     PUT /Todo
        ///     {
        ///        "id" : "0",
        ///        "Название" : "РайнГослинг"
        ///     }      
        /// </remarks>
        /// <param name="role">Роль</param>
        /// <returns></returns>        

        // PUT api/<RoleController>
        [HttpPut]
        public async Task<IActionResult> Update(Роли role)
        {
            var roleDto = role.Adapt<Роли>();
            await _roleService.Update(roleDto);
            return Ok();
        }

        /// <summary>
        /// Удаление Роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:        
        ///     DELETE
        ///     {
        ///        "id" : "0"
        ///     }      
        /// </remarks>
        /// <param name="id">id Роли</param>
        /// <returns></returns>        

        // DELETE api/<RoleController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.Delete(id);
            return Ok();
        }
    }
}