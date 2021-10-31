using BlazorTodoList.ViewModel.TodoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.Repositories
{
    public interface ITodoService
    {
        public Task<List<TodoVm>> GetListAsync(RequestFormSearch reqSearch);
        public Task<Guid> CreateTaskAsync(RequestTodoCreate req);
        public Task<TodoVm> UpdateTaskAsync(Guid Id, RequestTodoUpdate req);
        public Task<bool> DeleteTaskAsync(Guid Id);
        public Task<TodoVm> GetTaskByIdAsync(Guid Id);
    }
}
