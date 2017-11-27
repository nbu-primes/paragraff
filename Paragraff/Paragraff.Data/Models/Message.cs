using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.Data.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string FromUserId { get; set; }

        public virtual User FromUser { get; set; }
        
        [Required]
        public string ToUserId { get; set; }

        public virtual User ToUser { get; set; }

        public DateTime SendOn { get; set; }
    }
}
