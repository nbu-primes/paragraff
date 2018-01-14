using Paragraff.ViewModels.MessageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices.Contracts
{
    public interface IMessageService
    {
        void SendNewMessage(string username, NewMessageViewModel message);
        IEnumerable<SentMessageViewModel> GetAllMessages(string username);
    }
}
