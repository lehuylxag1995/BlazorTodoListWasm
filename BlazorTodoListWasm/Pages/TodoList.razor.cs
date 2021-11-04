using Blazored.Toast.Services;
using BlazorTodoList.ViewModel.Enums;
using BlazorTodoList.ViewModel.TodoViewModel;
using BlazorTodoList.ViewModel.UserViewModel;
using BlazorTodoListWasm.Components;
using BlazorTodoListWasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoListWasm.Pages
{
    public partial class TodoList
    {
        [Inject]
        private ITodoService _todoService { set; get; }
        [Inject]
        private IUserService _userService { set; get; }
        [Inject]
        private IToastService _toastService { get; set; }
        [Inject]
        private NavigationManager MyNavigationManager { get; set; }

        private List<TodoVm> _ListTodo;
        private List<AssigneeVm> _ListAssignee;
        private string[] _ListPriority;
        public RequestFormSearch reqSearch = new RequestFormSearch();

        //Modal
        private Guid? IdDelete;
        public ModalConfirm modalDeleteConfirm { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _ListAssignee = await _userService.GetAllAsync();
            _ListTodo = await _todoService.GetListAsync(reqSearch);
            _ListPriority = Enum.GetNames(typeof(Priority));
        }

        private async Task SubmitSearch(RequestFormSearch req)
        {
            _ListTodo = await _todoService.GetListAsync(req);
        }

        public void ShowModal(Guid Id)
        {
            IdDelete = Id;
            modalDeleteConfirm.ModalShow();
        }

        public async Task ConfirmDelete(bool value)
        {
            if (value && IdDelete.HasValue)
            {
                var isSuccess = await _todoService.DeleteAsync(IdDelete.Value);
                _toastService.ShowSuccess("Thành công", "Bạn đã xoá việc cần làm");
                _ListTodo = await _todoService.GetListAsync(reqSearch);
            }
        }
    }
}
