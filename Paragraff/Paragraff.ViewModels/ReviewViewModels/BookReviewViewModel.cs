using System;
using System.ComponentModel.DataAnnotations;

namespace Paragraff.ViewModels.ReviewViewModels
{
    public class BookReviewViewModel
    {
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Author { get; set; }
    }
}