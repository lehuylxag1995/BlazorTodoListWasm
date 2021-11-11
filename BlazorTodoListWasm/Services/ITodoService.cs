using BlazorTodoList.ViewModel.PagingViewModel;
using BlazorTodoList.ViewModel.TodoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Services
{
    public interface ITodoService
    {
        public Task<PagingVm<TodoVm>> GetPagingAsync(RequestFormSearch reqSearch);
        public Task<List<TodoVm>> GetListAsync(RequestFormSearch reqSearch);
        public Task<TodoVm> GetInfoTodoByIdAsync(string Id);
        public Task<bool> CreateAsync(RequestTodoCreate req);
        public Task<bool> UpdateAsync(Guid Id, RequestTodoUpdate req);
        public Task<bool> DeleteAsync(Guid Id);
    }
}
