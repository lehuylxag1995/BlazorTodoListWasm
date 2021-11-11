using BlazorTodoList.ViewModel.Enums;
using BlazorTodoList.ViewModel.PagingViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.TodoViewModel
{
    public class RequestFormSearch : RequestPagingBase
    {
        public string Name { get; set; } = null;

        public Guid? Assignee { get; set; }

        public Priority? Priority { get; set; }
    }
}
