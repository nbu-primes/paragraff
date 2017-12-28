using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Paragraff.ViewModels.BookViewModels
{
    public class SummaryBookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Guid BookId { get; set; }
    }
}
