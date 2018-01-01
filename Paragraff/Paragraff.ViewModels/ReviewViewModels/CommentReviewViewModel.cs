using System;
using System.ComponentModel.DataAnnotations;

namespace Paragraff.ViewModels.ReviewViewModels
{
    public class CommentReviewViewModel
    {
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Content { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}