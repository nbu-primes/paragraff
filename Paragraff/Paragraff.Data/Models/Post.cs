using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.Data.Models
{
    public class Post
    {
        private ICollection<PostRating> postRatings;
        private ICollection<Comment> comments;

        public Post()
        {
            this.postRatings = new HashSet<PostRating>();
            this.comments = new HashSet<Comment>();
        }

        public Guid Id { get; set; }

        [Required]
        public string PublisherId { get; set; }

        /// <summary>
        /// The creator of the post.
        /// </summary>
        public virtual User Publisher { get; set; }

        public string TradedWithId { get; set; }

        public virtual User TradedWith { get; set; }

        [Required]
        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsOwned { get; set; }
        
        public virtual ICollection<PostRating> PostRatings
        {
            get
            {
                return this.postRatings;
            }
            set
            {
                this.postRatings = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public bool IsActive { get; set; }
    }
}
