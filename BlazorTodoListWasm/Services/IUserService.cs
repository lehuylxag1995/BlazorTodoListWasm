using BlazorTodoList.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Services
{
    public interface IUserService
    {
        public Task<List<AssigneeVm>> GetAllAsync();
    }
}
