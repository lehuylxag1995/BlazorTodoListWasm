using BlazorTodoList.ViewModel.Data;
using BlazorTodoList.ViewModel.TodoUserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoList.Api.Repositories
{
    public class TodoUserService : ITodoUserService
    {
        private readonly TodoDbContext _DbContext;
        public TodoUserService(TodoDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<bool> Assignee(RequestAssignUser req)
        {
            if (req.IdTodo.HasValue)
            {
                var todo = await _DbContext.Todoes.FindAsync(req.IdTodo.Value);
                todo.AssignId = req.IdUser ?? null;
                _DbContext.Todoes.Update(todo);
            }
            return await _DbContext.SaveChangesAsync() > 0;
        }
    }
}
