using BlazorTodoList.ViewModel.TodoUserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoList.Api.Repositories
{
    public interface ITodoUserService
    {
        public Task<bool> Assignee(RequestAssignUser req);
    }
}
