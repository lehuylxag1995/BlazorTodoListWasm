using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.LoginViewModel
{
    public class LoginResponse
    {
        public bool Success { get; set; } = false;
        public string Error { get; set; } = "";
        public string Token { get; set; } = null;
    }
}
