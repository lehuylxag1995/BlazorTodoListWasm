using BlazorTodoList.ViewModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoList.Api.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string NameTodo { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid? AssignId { get; set; }

        [ForeignKey("AssignId")]
        public User Assignee { get; set; }
    }
}
