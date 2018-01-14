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

        public List<PublicUserViewModel> DisplayAllUsers()
        {
            var allUsers = this.dbContext.Users.Select(m => new PublicUserViewModel()
            {
                Id = m.Id,
                Username = m.UserName,
                Email = m.Email,
                IsActive = m.IsActive
            }).ToList();
            foreach (var user in allUsers)
            {
                user.IsAdmin = this.userManager.IsInRole(user.Id, "Admin");
            }

            return allUsers;
        }

        public void ChangeStatus(string username)
        {
            var user = this.dbContext.Users.First(u => u.UserName == username);
            user.IsActive = !user.IsActive;

            var postsByUser = this.dbContext.Posts.Where(p => p.Publisher.UserName == user.UserName);

            foreach (var post in postsByUser)
            {
                post.IsActive = !post.IsActive;
            }

            this.dbContext.SaveChanges();
        }

        public EditUserViewModel UserDetails(string username)
        {
            var viewModel = this.dbContext.Users
                 .Where(u => u.UserName == username)
                 .Select(user => new EditUserViewModel()
                 {
                     FirstName = user.FirstName,
                     LastName = user.LastName,
                     About = user.About,
                     Email = user.Email,
                     Gender = user.Gender,
                     Location = user.Location,
                     ProfilePicture = user.ProfilePicture
                 })
                 .First();


            return viewModel;
        }
    }
}
