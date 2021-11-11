﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.PagingViewModel
{
    public class RequestPagingBase
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
