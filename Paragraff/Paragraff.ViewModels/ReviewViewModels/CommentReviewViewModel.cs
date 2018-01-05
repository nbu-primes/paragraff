using System;
using System.ComponentModel.DataAnnotations;

namespace Paragraff.ViewModels.ReviewViewModels
{
    public class CommentReviewViewModel
    {
        public Guid PostId { get; set; }

        public string PublisherId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Content { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}