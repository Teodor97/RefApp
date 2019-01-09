using System.Collections.Generic;

namespace RefApp.Services.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<IndexProductViewModel> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}
