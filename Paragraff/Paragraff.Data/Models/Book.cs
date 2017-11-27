using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.Data.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string WisherId { get; set; }

        public virtual User Wisher { get; set; }

        [Required]
        public string Author { get; set; }
        
        public DateTime PublishedOn { get; set; }

        [Required]
        public string Publisher { get; set; }
        
        [Required]
        public byte[] Image { get; set; }
    }
}
