using BlazorTodoList.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoList.Api.Repositories
{
    public interface IUserRepository
    {
        public Task<List<AssigneeVm>> GetAllAsync();
    }
}
