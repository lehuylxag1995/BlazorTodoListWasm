using BlazorTodoList.Api.Entities;
using BlazorTodoList.ViewModel.Data;
using BlazorTodoList.ViewModel.TodoViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.Repositories
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _context;
        public TodoService(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateTaskAsync(RequestTodoCreate req)
        {
            var todoo = new Todo()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                NameTodo = req.NameTodo,
                Priority = req.Priority ?? Enums.Priority.Low,
                Status = req.Status,
                AssignId = req.AssignId ?? null
            };
            await _context.Todoes.AddAsync(todoo);
            await _context.SaveChangesAsync();
            return todoo.Id;
        }

        public async Task<bool> DeleteTaskAsync(Guid Id)
        {
            var todo = await _context.Todoes.FindAsync(Id);
            _context.Todoes.Remove(todo);
            var data = await _context.SaveChangesAsync() > 0;
            return data;
        }

        public async Task<List<TodoVm>> GetListAsync(RequestFormSearch reqSearch)
        {
            var query = _context.Todoes.Include(x => x.Assignee).AsQueryable();

            if (!string.IsNullOrEmpty(reqSearch.Name))
            {
                query = query.Where(x => x.NameTodo.Contains(reqSearch.Name));
            }

            if (reqSearch.Assignee.HasValue)
            {
                query = query.Where(x => x.AssignId.Value.Equals(reqSearch.Assignee.Value));
            }

            if (reqSearch.Priority.HasValue)
            {
                query = query.Where(x => x.Priority.Equals(reqSearch.Priority.Value));
            }

            var data = await query.Select(x => new TodoVm()
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate,
                NameTodo = x.NameTodo,
                Priority = x.Priority,
                Status = x.Status,
                AssigneeName = x.Assignee != null ? x.Assignee.FirstName + " " + x.Assignee.LastName : ""
            }).OrderByDescending(x => x.CreatedDate).ToListAsync();

            return data;
        }

        public async Task<TodoVm> GetTaskByIdAsync(Guid Id)
        {
            var todo = await _context.Todoes.FindAsync(Id);
            var data = new TodoVm()
            {
                Id = todo.Id,
                CreatedDate = todo.CreatedDate,
                NameTodo = todo.NameTodo,
                Priority = todo.Priority,
                Status = todo.Status
            };
            return data;
        }

        public async Task<TodoVm> UpdateTaskAsync(Guid Id, RequestTodoUpdate req)
        {
            var todo = await _context.Todoes.FindAsync(Id);
            todo.Id = Id;
            todo.NameTodo = req.NameTodo;
            todo.Priority = req.Priority;
            todo.Status = req.Status;

            _context.Todoes.Update(todo);
            await _context.SaveChangesAsync();
            return await GetTaskByIdAsync(Id);
        }
    }
}