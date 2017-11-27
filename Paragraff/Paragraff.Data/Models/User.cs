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
        private ICollection<Post> trades;
        private ICollection<Book> wishlist; 

        public User()
        {
            this.posts = new HashSet<Post>();
            this.postRatings = new HashSet<PostRating>();
            this.userRatings = new HashSet<UserRating>();
            this.trades = new HashSet<Post>();
            this.wishlist = new HashSet<Book>();
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

        public virtual ICollection<Post> Trades
        {
            get
            {
                return this.trades;
            }
            set
            {
                this.trades = value;
            }
        }

        public virtual ICollection<Book> Wishlist
        {
            get
            {
                return this.wishlist;
            }
            set
            {
                this.wishlist = value;
            }
        }

        public bool IsActive { get; set; }
    }
}
