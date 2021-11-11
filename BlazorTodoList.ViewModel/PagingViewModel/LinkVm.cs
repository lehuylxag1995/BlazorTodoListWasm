using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoList.ViewModel.PagingViewModel
{
    public class LinkVm
    {
        public LinkVm(int page, bool active) : this(page, active, page.ToString()) { }

        public LinkVm(int page, bool active, string textPage)
        {
            Page = page;
            Active = active;
            TextPage = textPage;
        }
        public LinkVm(int page, bool active, bool disabled, string textPage)
        {
            Page = page;
            Active = active;
            TextPage = textPage;
            Disable = disabled;
        }

        public bool Active { get; set; } = false;
        public bool Disable { get; set; } = false;
        public string TextPage { get; set; }
        public int Page { get; set; }
    }
}
