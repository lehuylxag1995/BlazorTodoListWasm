using BlazorTodoList.ViewModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.TodoViewModel
{
    public class RequestTodoUpdate
    {
        //public Guid Id { get; set; }
        [Required]
        public string NameTodo { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
        //public DateTime CreatedDate { get; set; }

        //public Guid? AssignId { get; set; }
        //[ForeignKey("AssignId")]
        //public User Assignee { get; set; }
    }
}
