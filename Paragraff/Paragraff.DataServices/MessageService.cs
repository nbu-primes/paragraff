using Bytes2you.Validation;
using Paragraff.Data;
using Paragraff.Data.Models;
using Paragraff.DataServices.Contracts;
using Paragraff.ViewModels.MessageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext dbContext;

        public MessageService(ApplicationDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public IEnumerable<SentMessageViewModel> GetAllMessages(string username)
        {
            var messages = new List<SentMessageViewModel>();

            var recievedMs = this.dbContext.Messages
                .Where(m => m.ToUser.UserName == username)
                .Select(m => new SentMessageViewModel()
                {
                    Id = m.Id,
                    Content = m.Content,
                    FromUser = m.FromUser.UserName,
                    ToUser = m.ToUser.UserName,
                    SendOn = m.SendOn
                }).ToList();

            var sentMs = this.dbContext.Messages
                .Where(m => m.FromUser.UserName == username)
                .Select(m => new SentMessageViewModel()
                {
                    Id = m.Id,
                    Content = m.Content,
                    FromUser = m.FromUser.UserName,
                    ToUser = m.ToUser.UserName,
                    SendOn = m.SendOn
                }).ToList();

            messages.AddRange(recievedMs);
            messages.AddRange(sentMs);

            messages.OrderBy(m => m.SendOn);

            return messages;
        }

        public void SendNewMessage(string username, NewMessageViewModel message)
        {
            var fromUser = this.dbContext.Users.First(u => u.UserName == username);
            var toUser = this.dbContext.Users.First(u => u.UserName == message.ToUser);

            var newMessage = new Message()
            {
                Id = Guid.NewGuid(),
                FromUser = fromUser,
                ToUser = toUser,
                Content = message.Content,
                SendOn = DateTime.Now
            };

            this.dbContext.Messages.Add(newMessage);
            this.dbContext.SaveChanges();
        }
    }
}
