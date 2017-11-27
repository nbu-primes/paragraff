using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.Data.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        
        [Index(IsUnique = true)]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }

        //Category

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
