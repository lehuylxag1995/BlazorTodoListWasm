using Blazored.Toast.Services;
using BlazorTodoList.ViewModel.Enums;
using BlazorTodoList.ViewModel.TodoViewModel;
using BlazorTodoList.ViewModel.UserViewModel;
using BlazorTodoListWasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Pages
{
    public partial class TodoCreate
    {
        [Inject]
        private IUserService _userService { get; set; }
        [Inject]
        private ITodoService _todoService { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        [Inject]
        private IToastService toastService { get; set; }

        private RequestTodoCreate _requestCreate = new RequestTodoCreate();
        private string[] _listPriority = Enum.GetNames(typeof(Priority));
        private List<AssigneeVm> _ListAssignee;

        protected override async Task OnInitializedAsync()
        {
            _ListAssignee = await _userService.GetAllAsync();
        }

        private async Task SubmitCreate(EditContext form)
        {
            if (form.Validate())
            {
                var result = await _todoService.CreateAsync((RequestTodoCreate)form.Model);
                if (result)
                {
                    toastService.ShowSuccess("Đã thêm công việc mới thành công", "Chúc mừng");
                    _navigation.NavigateTo("/todoList");
                }
                else
                {
                    toastService.ShowError("Vui lòng liên hệ Admin", "Lỗi");
                }

            }
        }
    }
}
