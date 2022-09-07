using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EzpeletaNetCore6.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<IdentityRole> roles = new List<IdentityRole>()
            {
            new IdentityRole { Name = "Superusuario",NormalizedName = "SUPERUSUARIO"} ,
            new IdentityRole { Name = "Administrador", NormalizedName = "ADMINISTRADOR" }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            List<ApplicationUser> users = new List<ApplicationUser>()
            { new ApplicationUser
            {
                UserName ="superusuario@appezpeleta.com",
                NormalizedUserName ="SUPERUSUARIO@APPEZPELETA.COM",
                Email ="superusuario@appezpeleta.com",
                NormalizedEmail = "SUPERUSUARIO@APPEZPELETA.COM"
            },

            };
            modelBuilder.Entity<ApplicationUser>().HasData(users);

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Ezpe123");

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Superusuario").Id
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }

    }
}
