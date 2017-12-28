using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.ViewModels.DataTransferObjects
{
    public class SummaryBookDto
    {
        public Guid BookId  { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

    }
}
