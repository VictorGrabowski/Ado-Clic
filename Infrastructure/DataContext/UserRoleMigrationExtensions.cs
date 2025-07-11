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
            User admin = new()
            {
                Id = 1,
                Email = "email@email.com",
                BirthTimestamp = 0,
                FirstName = "Admin",
                LastName = "Admin",
                RoleId = 4
            };

            User volunteer = new()
            {
                Id = 2,
                Email = "jean.doe@gmail.com",
                BirthTimestamp = 0,
                FirstName = "Jean",
                LastName = "Doe",
                RoleId = 2
            };

            User beneficiary = new()
            {
                Id = 3,
                Email = "marie.lala@hotmail.fr",
                BirthTimestamp = 0,
                FirstName = "Marie",
                LastName = "Lala",
                RoleId = 1
            };

            User support = new()
            {
                Id = 4,
                Email = "mlock@gmail.com",
                BirthTimestamp = 0,
                FirstName = "Mark",
                LastName = "Lock",
                RoleId = 3
            };

            User[] users = [admin, volunteer, beneficiary, support];

            modelBuilder.Entity<User>()
                .HasData(users);
        }
    }
}
