using Microsoft.AspNet.Identity.EntityFramework;
using Paragraff.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany<UserRating>(u => u.UserRatings)
                .WithRequired(s => s.FromUser)
                .HasForeignKey(s => s.FromUserId);

            modelBuilder.Entity<User>()
                .HasMany<Post>(u => u.Posts)
                .WithRequired(p => p.Publisher)
                .HasForeignKey(p => p.PublisherId);


            // should be optional
            // https://stackoverflow.com/a/29514803/4990859

            modelBuilder.Entity<User>()
                .HasMany<Post>(u => u.Trades)
                .WithOptional(p => p.TradedWith)
                .HasForeignKey(p => p.TradedWithId);
            
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<PostRating> PostRatings { get; set; }

        public IDbSet<UserRating> UserRatings { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Message> Messages { get; set; }
    }
}
