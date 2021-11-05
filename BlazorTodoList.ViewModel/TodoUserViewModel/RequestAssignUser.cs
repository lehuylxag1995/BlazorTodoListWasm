using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.TodoUserViewModel
{
    public class RequestAssignUser
    {
        public Guid? IdUser { get; set; }
        public Guid? IdTodo { get; set; }
    }
}
