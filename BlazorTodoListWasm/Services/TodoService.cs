using BlazorTodoList.ViewModel.TodoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(RequestTodoCreate req)
        {
            var result = await _httpClient.PostAsJsonAsync("Todoes/Create", req);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var result = await _httpClient.DeleteAsync($"Todoes/Remove/{Id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<TodoVm> GetInfoTodoByIdAsync(string Id)
        {
            var data = await _httpClient.GetFromJsonAsync<TodoVm>($"Todoes/Get/{Id}");
            return data;
        }

        public async Task<List<TodoVm>> GetListAsync(RequestFormSearch reqSearch)
        {
            string uri = $"Todoes/List?Name={reqSearch.Name}&Assignee={reqSearch.Assignee}&Priority={reqSearch.Priority}";
            var list = await _httpClient.GetFromJsonAsync<List<TodoVm>>(uri);
            return list;
        }

        public async Task<bool> UpdateAsync(Guid Id, RequestTodoUpdate req)
        {
            var result = await _httpClient.PutAsJsonAsync($"Todoes/Edit/{Id}", req);
            return result.IsSuccessStatusCode;
        }
    }
}
