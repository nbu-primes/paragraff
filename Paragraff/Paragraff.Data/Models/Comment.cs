using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.Data.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Content { get; set; }
        
        [Required]
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        [Required]
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
