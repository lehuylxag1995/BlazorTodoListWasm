using BlazorTodoList.ViewModel.TodoUserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Services
{
    public interface ITodoUserService
    {
        public Task<bool> AssignUserAsync(RequestAssignUser req);
    }
}
