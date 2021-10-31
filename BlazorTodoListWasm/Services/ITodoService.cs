using BlazorTodoList.ViewModel.TodoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Services
{
    public interface ITodoService
    {
        public Task<List<TodoVm>> GetListAsync(RequestFormSearch reqSearch);
        public Task<TodoVm> GetInfoTodoByIdAsync(string Id);

    }
}
