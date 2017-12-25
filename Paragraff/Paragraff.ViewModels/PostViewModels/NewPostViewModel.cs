using Paragraff.ViewModels.BookViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.ViewModels.PostViewModels
{
    public class NewPostViewModel
    {
        public NewBookViewModel Book { get; set; }
        
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Description { get; set; }
        
        [Range(0, double.PositiveInfinity)]
        public decimal Price { get; set; }

        [Range(1,10)]
        public int Rating { get; set; }
    }
}
