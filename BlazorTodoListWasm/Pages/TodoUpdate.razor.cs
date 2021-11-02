using Blazored.Toast.Services;
using BlazorTodoList.ViewModel.Enums;
using BlazorTodoList.ViewModel.TodoViewModel;
using BlazorTodoListWasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Pages
{
    public partial class TodoUpdate
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private ITodoService _todoService { get; set; }
        [Inject]
        private IToastService _toastService { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }

        private RequestTodoUpdate _info = new RequestTodoUpdate();
        private string[] _ListPriority = Enum.GetNames(typeof(Priority));
        private string[] _ListStatus = Enum.GetNames(typeof(Status));

        protected override async Task OnInitializedAsync()
        {
            var info = await _todoService.GetInfoTodoByIdAsync(Id);
            _info.NameTodo = info.NameTodo;
            _info.Priority = info.Priority;
            _info.Status = info.Status;
        }

        private async Task SubmitUpdate(EditContext form)
        {
            if (form.Validate())
            {
                var id = Guid.Parse(Id);
                var isSuccess = await _todoService.UpdateAsync(id, _info);
                if (isSuccess)
                {
                    _toastService.ShowSuccess("Cập nhật việc cần làm thành công", "Chúc mừng");
                    _navigation.NavigateTo("/todoList");
                }
                else
                {
                    _toastService.ShowError("Cập nhật thất bại", "Lỗi");
                }
            }
        }
    }
}
