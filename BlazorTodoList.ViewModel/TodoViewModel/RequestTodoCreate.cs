using BlazorTodoList.ViewModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.TodoViewModel
{
    public class RequestTodoCreate
    {
        //public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string NameTodo { get; set; }

        [Required]
        public Priority? Priority { get; set; }

        public Status Status { get; set; } = Status.Open;

        public Guid? AssignId { get; set; }
    }
}
