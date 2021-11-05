using BlazorTodoList.Api.Repositories;
using BlazorTodoList.ViewModel.TodoUserViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoUserController : ControllerBase
    {
        private readonly ITodoUserService _todoUserService;
        public TodoUserController(ITodoUserService todoUserService)
        {
            _todoUserService = todoUserService;
        }

        //POST api/TodoUser/Assign
        [HttpPost("Assign")]
        public async Task<IActionResult> Assignee([FromBody] RequestAssignUser req)
        {
            var isSuccess = await _todoUserService.Assignee(req);
            if (isSuccess)
                return Ok();
            else
                return BadRequest();
        }
    }
}
