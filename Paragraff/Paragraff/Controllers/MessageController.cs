using Bytes2you.Validation;
using Paragraff.DataServices.Contracts;
using Paragraff.ViewModels.MessageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            Guard.WhenArgument(messageService, "messageService").IsNull().Throw();

            this.messageService = messageService;
        }

        public ActionResult Inbox()
        {
            return this.View();
        }

        public ActionResult InboxSummary()
        {
            var messages = this.messageService.GetAllMessages(this.User.Identity.Name);

            return this.PartialView("_InboxSummary", messages);
        }

        public ActionResult NewMessage()
        {
            var messageVm = new NewMessageViewModel();

            return this.View(messageVm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMessage(NewMessageViewModel message)
        {
            this.messageService.SendNewMessage(this.User.Identity.Name, message);

            return this.RedirectToAction("Inbox");
        }
    }
}