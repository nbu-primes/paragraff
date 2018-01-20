using Paragraff.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.ViewModels.ReviewDTOs
{
    public class BookReviewDto
    {
        public BookReviewDto()
        {
            this.Wishers = new HashSet<UserViewModel>();
        }

        public Guid Id { get; set; }
        
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }
        
        [Required]
        public string Author { get; set; }

        public IEnumerable<UserViewModel> Wishers { get; set; }

    }
}
