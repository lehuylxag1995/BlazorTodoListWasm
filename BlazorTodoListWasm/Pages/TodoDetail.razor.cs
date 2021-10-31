using BlazorTodoList.ViewModel.TodoViewModel;
using BlazorTodoListWasm.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Pages
{
    public partial class TodoDetail
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        private ITodoService _todoService { get; set; }

        public TodoVm Info { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Info = await _todoService.GetInfoTodoByIdAsync(Id);
        }
    }
}
