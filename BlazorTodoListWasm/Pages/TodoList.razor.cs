using Blazored.Toast.Services;
using BlazorTodoList.ViewModel.Enums;
using BlazorTodoList.ViewModel.PagingViewModel;
using BlazorTodoList.ViewModel.TodoViewModel;
using BlazorTodoList.ViewModel.UserViewModel;
using BlazorTodoListWasm.Components;
using BlazorTodoListWasm.Pages.Components;
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
        [Inject] private ITodoService _todoService { set; get; }
        [Inject] private IUserService _userService { set; get; }
        [Inject] private IToastService _toastService { get; set; }
        [Inject] private NavigationManager MyNavigationManager { get; set; }

        //private List<TodoVm> _ListTodo;
        private PagingVm<TodoVm> _Paging;
        private List<AssigneeVm> _ListAssignee;
        private string[] _ListPriority;
        public RequestFormSearch reqSearch = new RequestFormSearch();

        //Modal Delete todo
        private Guid? IdDelete;
        public ModalConfirm modalDeleteConfirm;

        //Modal Assign Todo
        private ModalAssignee modalAssign;

        //Paging
        public Pagination _Pagination;
        private decimal TotalPages;

        protected override async Task OnInitializedAsync()
        {
            _ListAssignee = await _userService.GetAllAsync();
            await ListPaging(reqSearch);
            _ListPriority = Enum.GetNames(typeof(Priority));
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
                await ListPaging(reqSearch);
            }
        }

        public void ShowDialogAssign(Guid Id)
        {
            modalAssign.IdTodo = Id;
            modalAssign.ShowModal();
        }

        public async Task ConfirmAssignUser(bool value)
        {
            //Nếu người dùng xác nhận gán quyền xong thì load lại trang
            if (value)
            {
                await ListPaging(reqSearch);
            }
        }

        public async Task SelectedPage(int page)
        {
            reqSearch.PageIndex = page; // update query select paging
            await ListPaging(reqSearch);
        }

        private async Task ListPaging(RequestFormSearch reqSearch)
        {
            
            _Paging = await _todoService.GetPagingAsync(reqSearch);
            TotalPages = Math.Ceiling((decimal)_Paging.TotalRecord / reqSearch.PageSize);
        }
    }
}
