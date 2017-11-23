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
        public Guid Id { get; set; }

        [Required]
        public string PublisherId { get; set; }
    
        public virtual User Publisher { get; set; }

        //Book

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Description { get; set; }

        public decimal Price { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public bool IsOwned { get; set; }

        //PostRatings

        //Comments

        public bool IsActive { get; set; }
    }
}
