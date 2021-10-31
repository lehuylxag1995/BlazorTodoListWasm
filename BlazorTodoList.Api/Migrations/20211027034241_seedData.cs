using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorTodoList.ViewModel.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e9c3466e-276a-470a-a774-d6d402b40702"), 0, "d8f6d900-cabb-4af9-b930-0814ec5babf8", "lehuylxag1995@gmail.com", false, "Lê", "Huy", false, null, null, null, "AQAAAAEAACcQAAAAEDcERgyGKo69CIgdJvou2QHHhRQqA14giuZmJQ469f4yTKI/m0bpTIo8KU/nA2yHdA==", "0392477681", false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "Todoes",
                columns: new[] { "Id", "AssignId", "CreatedDate", "NameTodo", "Priority", "Status" },
                values: new object[] { new Guid("27b17d75-8bfa-403c-9327-12ccabc67624"), null, new DateTime(2021, 10, 27, 10, 42, 41, 338, DateTimeKind.Local).AddTicks(8553), "Học Blazor phần 1", 1, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9c3466e-276a-470a-a774-d6d402b40702"));

            migrationBuilder.DeleteData(
                table: "Todoes",
                keyColumn: "Id",
                keyValue: new Guid("27b17d75-8bfa-403c-9327-12ccabc67624"));
        }
    }
}
