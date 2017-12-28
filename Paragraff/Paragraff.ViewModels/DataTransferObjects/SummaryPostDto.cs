using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.ViewModels.DataTransferObjects
{
    public class SummaryPostDto
    {
        public Guid PostId { get; set; }
        public SummaryBookDto Book { get; set; }
        public string PublisherId { get; set; }
        public IEnumerable<int> Ratings { get; set; }
        public bool IsTradable { get; set; }
        public bool IsRead { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
