using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.ViewModels.ReviewDTOs
{
    public class PostReviewDto
    {
        public Guid PostId { get; set; }

        public string PublisherId { get; set; }

        public BookReviewDto Book { get; set; }
        
        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsOwned { get; set; }

        public bool IsRead { get; set; }

        public bool IsTradable { get; set; }

        public IEnumerable<int> Ratings { get; set; }

        public IEnumerable<CommentReviewDto> Comments { get; set; }

        public int? RatedFromViewer { get; set; }

    }
}
