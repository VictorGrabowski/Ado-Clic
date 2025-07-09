using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Infrastructure.DataContext
{
    internal static class UserRoleMigrationExtensions
    {
        internal static void AddUserRoleMigration(this ModelBuilder modelBuilder)
        {
            UserRole[] roles = [
                new(){ Id = 1, Name = "Beneficiary" },
                new(){ Id = 2, Name = "Volunteer" },
                new(){ Id = 3, Name = "Support" },
                new(){ Id = 4, Name = "Admin" }
                ];

            modelBuilder.Entity<UserRole>()
                .HasData(roles);

            // Development Admin
            string password = "password";

            User admin = new()
            {
                Id = 1,
                Email = "email@email.com",
                BirthTimestamp = 0,
                FirstName = "Admin",
                LastName = "Admin",
                RoleId = 4
            };

            modelBuilder.Entity<User>()
                .HasData(admin);
        }
    }
}
