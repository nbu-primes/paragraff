using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.Data.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Post> posts;
        private ICollection<PostRating> postRatings;
        private ICollection<UserRating> userRatings;

        public User()
        {
            this.posts = new HashSet<Post>();
            this.postRatings = new HashSet<PostRating>();
            this.userRatings = new HashSet<UserRating>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }
            set
            {
                this.posts = value;
            }
        }

        public virtual ICollection<PostRating> PostRatings
        {
            get
            {
                return this.postRatings;
            }
            set
            {
                this.postRatings = value;
            }
        }

        public virtual ICollection<UserRating> UserRatings
        {
            get
            {
                return this.userRatings;
            }
            set
            {
                this.userRatings = value;
            }
        }

        public bool isActive { get; set; }
    }
}
