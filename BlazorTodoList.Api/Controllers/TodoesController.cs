using BlazorTodoList.ViewModel.Repositories;
using BlazorTodoList.ViewModel.TodoViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorTodoList.ViewModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoesController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        //GET: api/Todoes/Get/{id}
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            var data = await _todoService.GetTaskByIdAsync(id);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        //GET: api/Todoes/List
        [HttpGet("List")]
        public async Task<IActionResult> GetList([FromQuery]RequestFormSearch reqSearch)
        {
            var list = await _todoService.GetListAsync(reqSearch);
            if (list == null)
                return BadRequest("Không lấy được danh sách");
            return Ok(list);
        }

        //POST: api/Todoes/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] RequestTodoCreate req)
        {
            var Id = await _todoService.CreateTaskAsync(req);
            if (string.IsNullOrEmpty(Id.ToString()))
                return BadRequest();
            var data = await _todoService.GetTaskByIdAsync(Id);
            return Ok(data);
        }

        //PUT: api/Todoes/Edit/{id}
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromQuery] RequestTodoUpdate req)
        {
            var data = await _todoService.UpdateTaskAsync(id, req);
            if (data == null)
                return BadRequest();
            return Ok(data);
        }

        //DELETE: api/Todoes/Remove/{id}
        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var isSuccess = await _todoService.DeleteTaskAsync(id);
            if (!isSuccess)
                return BadRequest();
            return Ok();
        }
    }
}
