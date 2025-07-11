using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Infrastructure.DataContext
{
    public static class InterventionMigrationExtensions
    {
        public static void AddInterventionMigrations(this ModelBuilder modelBuilder)
        {
            InterventionType[] interventionTypes = [
                new(){Id = 1, Name = "Courses"},
                new(){Id = 2, Name = "Menuiserie"},
                new(){Id = 3, Name = "Ménage"},
                new(){Id = 4, Name = "Démarches légales"},
                new(){Id = 5, Name = "Aide informatique"}
                ];

            modelBuilder.Entity<InterventionType>()
                .HasData(interventionTypes);
        }
    }
}
