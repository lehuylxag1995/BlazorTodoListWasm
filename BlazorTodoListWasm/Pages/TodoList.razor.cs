﻿using BlazorTodoList.ViewModel.Enums;
using BlazorTodoList.ViewModel.TodoViewModel;
using BlazorTodoList.ViewModel.UserViewModel;
using BlazorTodoListWasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
        private NavigationManager MyNavigationManager { get; set; }

        private List<TodoVm> _ListTodo;
        private List<AssigneeVm> _ListAssignee;
        private string[] _ListPriority;
        public RequestFormSearch reqSearch = new RequestFormSearch();


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
    }
}
