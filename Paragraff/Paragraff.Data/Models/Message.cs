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

        //From User

        //To User

        public DateTime SendOn { get; set; }
    }
}
