using BlazorTodoList.ViewModel.Data;
using BlazorTodoList.ViewModel.UserViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoList.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoDbContext _todoDbContext;
        public UserRepository(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
        public async Task<List<AssigneeVm>> GetAllAsync()
        {
            var data = await _todoDbContext.Users
                .Select(x => new AssigneeVm()
                {
                    Id = x.Id,
                    FullName = x.FirstName + ' ' + x.LastName
                })
                .ToListAsync();
            return data;
        }
    }
}
