using Bytes2you.Validation;
using Paragraff.Data;
using Paragraff.DataServices.Contracts;
using Paragraff.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public EditUserViewModel FindUserByUsername(string username)
        {
            var user = this.context.Users.First(u => u.UserName == username);

            var viewModel = new EditUserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                About = user.About,
                Email = user.Email,
                Gender = user.Gender,
                Location = user.Location,
                ProfilePicture = user.ProfilePicture
            };

            return viewModel;
        }
    }
}
