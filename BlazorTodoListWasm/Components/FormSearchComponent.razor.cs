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

namespace BlazorTodoListWasm.Components
{
    public partial class FormSearchComponent
    {
        [Parameter]
        public EventCallback<RequestFormSearch> OnSearch { get; set; }

        [Inject]
        private IUserService _userService { set; get; }

        private List<AssigneeVm> _ListAssignee;
        private string[] _ListPriority;
        private RequestFormSearch reqSearch = new();

        protected override async Task OnInitializedAsync()
        {
            _ListAssignee = await _userService.GetAllAsync();
            _ListPriority = Enum.GetNames(typeof(Priority));
        }

        protected async Task FormSearch()
        {
            await OnSearch.InvokeAsync(reqSearch);
        }
    }
}
