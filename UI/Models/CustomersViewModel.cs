using System.Collections.Generic;

namespace UI.Models
{
    public class CustomersViewModel
    {
        public string PageTitle { get; set; }
        public string PageNoResultText { get; set; }
        public IEnumerable<object> Items { get; set; }
        public string Title { get; internal set; }
    }
}
