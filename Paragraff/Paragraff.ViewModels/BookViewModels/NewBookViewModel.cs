using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Paragraff.ViewModels.BookViewModels
{
    public class NewBookViewModel
    {
        [Required]
        public string Author { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Publisher { get; set; }
        
        public DateTime PublishedOn { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        public string Category { get; set; }

        // This property will hold all available states for selection
        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}
