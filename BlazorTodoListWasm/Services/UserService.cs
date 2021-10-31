using BlazorTodoList.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<AssigneeVm>> GetAllAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<List<AssigneeVm>>("Users/GetAll");
            return data;
        }
    }
}
