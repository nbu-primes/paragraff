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

        //Creator

        public DateTime CreatedOn { get; set; }
    }
}
