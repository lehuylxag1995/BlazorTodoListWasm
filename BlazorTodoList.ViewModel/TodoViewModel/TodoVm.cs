using BlazorTodoList.ViewModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.TodoViewModel
{
    public class TodoVm
    {
        public Guid Id { get; set; }
        public string NameTodo { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }

        //public Guid? AssignId { get; set; }
        //[ForeignKey("AssignId")]
        //public User Assignee { get; set; }
    }
}
