using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.ViewModels.MessageViewModels
{
    public class SentMessageViewModel
    {
        public Guid Id { get; set; }
        
        public string Content { get; set; }
        
        public string FromUser { get; set; }
        
        public string ToUser { get; set; }

        public DateTime SendOn { get; set; }
    }
}
