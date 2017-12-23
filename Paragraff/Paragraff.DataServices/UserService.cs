﻿using Bytes2you.Validation;
using Paragraff.Data;
using Paragraff.Data.Models;
using Paragraff.DataServices.Contracts;
using Paragraff.ViewModels.DataTransferObjects;
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

        public void EditUser(string id, EditUserViewModel data)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();

            var user = this.context.Users.Find(id);

            user.About = data.About;
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.Gender = data.Gender;
            user.Email = data.Email;
            user.Location = data.Location;

            // if there is no uploaded image on next editing, dont remove the previous one
            if (data.ProfilePicture != null)
            {
                user.ProfilePicture = data.ProfilePicture;
            }

            this.context.SaveChanges();
        }

        public EditUserViewModel FindUserByUsername(string username)
        {
            var viewModel = this.context.Users
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
