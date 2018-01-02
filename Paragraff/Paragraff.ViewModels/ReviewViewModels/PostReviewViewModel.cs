using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.ViewModels.ReviewViewModels
{
    public class PostReviewViewModel
    {
        public string Username { get; set; }

        public BookReviewViewModel Book { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsOwned { get; set; }

        public bool IsRead { get; set; }

        public bool IsTradable { get; set; }

        public bool IsRated { get; set; }

        public IEnumerable<CommentReviewViewModel> Comments { get; set; }

        public IEnumerable<int> Ratings { get; set; }
    }
}
