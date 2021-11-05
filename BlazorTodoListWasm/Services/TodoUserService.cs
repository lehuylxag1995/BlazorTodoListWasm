using BlazorTodoList.ViewModel.TodoUserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Services
{
    public class TodoUserService : ITodoUserService
    {
        private readonly HttpClient _httpClient;
        public TodoUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AssignUserAsync(RequestAssignUser req)
        {
            var isSuccess = await _httpClient.PostAsJsonAsync("TodoUser/Assign", req);
            return isSuccess.IsSuccessStatusCode;
        }
    }
}
