using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.PagingViewModel
{
    public class PagingVm<T>
    {
        public int TotalRecord { get; set; }
        public List<T> Data { get; set; }
    }
}
