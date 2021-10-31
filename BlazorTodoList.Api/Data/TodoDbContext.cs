using BlazorTodoList.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.Data
{
    public class TodoDbContext : IdentityDbContext<User, Role, Guid>
    {
        //private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Lê",
                LastName = "Huy",
                Email = "lehuylxag1995@gmail.com",
                UserName = "admin",
                PhoneNumber = "0392477681"
            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "123!@#");
            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<Todo>().HasData(
               new Todo
               {
                   Id = Guid.NewGuid(),
                   CreatedDate = DateTime.Now,
                   NameTodo = "Học Blazor phần 1",
                   Priority = Enums.Priority.Medium,
                   Status = Enums.Status.Open,
               }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Todo> Todoes { set; get; }
    }
}
