using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.Data.Models
{
    public class PostRating
    {
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int Rating { get; set; }
        
        [Required]
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
