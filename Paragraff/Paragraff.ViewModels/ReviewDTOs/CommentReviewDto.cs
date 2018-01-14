using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.ViewModels.ReviewDTOs
{
    public class CommentReviewDto
    {
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }
        
        public DateTime CreatedOn { get; set; }
    }
}
