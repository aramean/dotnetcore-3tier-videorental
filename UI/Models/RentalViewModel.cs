using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class RentalViewModel
    {
        public string PageTitle { get; set; }
        public string PageNoResultText { get; set; }
        public IEnumerable<object> Items { get; set; }
        public string Title { get; internal set; }
    }
}
