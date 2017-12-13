namespace Paragraff.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Paragraff.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;

        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                context.Roles.Add(new IdentityRole("Admin"));
                context.SaveChanges();
            }

            if (!context.Users.Any(u => u.UserName == "test"))
            {
                var admin = new User
                {
                    UserName = "test",
                    Email = "test@test.com"
                };

                var password = "Test!23";

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                userManager.Create(admin, password);
                userManager.AddToRoles(admin.Id, new[] { "Admin" });
            }
        }
    }
}
