using Paragraff.ViewModels.PostViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paragraff.ViewModels.ReviewViewModels
{
    public class BookReviewViewModel
    {
        public BookReviewViewModel()
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