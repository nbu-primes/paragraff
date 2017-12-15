using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Paragraff.Data;
using Paragraff.Data.Models;
using Paragraff.DataServices.Contracts;
using Paragraff.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;

        public AdminService(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public List<AllUsersViewModel> DisplayAllUsers()
        {
            var allUsers = this.dbContext.Users.Select(m => new AllUsersViewModel()
            {
                Id = m.Id,
                Username = m.UserName,
                Email = m.Email,
            }).ToList();
            foreach (var user in allUsers)
            {
                user.IsAdmin = this.userManager.IsInRole(user.Id, "Admin");
            }

            return allUsers;
        }
    }
}
