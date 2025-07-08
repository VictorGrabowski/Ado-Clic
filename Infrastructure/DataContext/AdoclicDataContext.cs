using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Infrastructure.DataContext
{
    public class AdoclicDataContext(DbContextOptions<AdoclicDataContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserBlacklist> UserBlacklists { get; set; }
        public DbSet<UserEmergencyContact> UserEmergencyContacts { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserVolunteerInterest> UserVolunteerInterests { get; set; }
        public DbSet<EmailVerificationToken> EmailVerificationTokens { get; set; }

        public DbSet<InterventionRequest> InterventionRequests { get; set; }
        public DbSet<InterventionType> InterventionTypes { get; set; }
        public DbSet<InterventionAddress> InterventionAddresses { get; set; }
        public DbSet<InterventionActivity> InterventionActivities { get; set; }
        public DbSet<InterventionChatMessage> InterventionChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One to many relationship between User and UserRole
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            // Configure the one-to-one relationship between User and UserAddress
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<UserAddress>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the one-to-one relationship between User and UserEmergencyContact
            modelBuilder.Entity<User>()
                .HasOne(u => u.EmergencyContact)
                .WithOne(ec => ec.User)
                .HasForeignKey<UserEmergencyContact>(ec => ec.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the one-to-many relationship between User and UserVolunteerInterest
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserVolunteerInterests)
                .WithOne(vi => vi.User)
                .HasForeignKey(vi => vi.UserId)
                .OnDelete(DeleteBehavior.Cascade); // or Restrict, depending on your needs

            // Configure the one-to-many relationship between User and UserBlacklist
            modelBuilder.Entity<UserBlacklist>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.BlacklistedUsers)
                .HasForeignKey(ub => ub.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.VerificationToken)
                .WithOne(t => t.User)
                .HasForeignKey<EmailVerificationToken>(vt => vt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-many relationship between User and InterventionType
            modelBuilder.Entity<User>()
                .HasMany(u => u.InterventionTypes)
                .WithMany(it => it.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserInterventionType", // Name of the join table
                    j => j
                    .HasOne<InterventionType>()
                    .WithMany()
                    .HasForeignKey("InterventionTypeId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("UserId", "InterventionTypeId");
                });

            // One-to-many relationship between User and InterventionRequest
            modelBuilder.Entity<User>()
                .HasMany(u => u.InterventionRequests)
                .WithOne(ir => ir.User)
                .HasForeignKey(ir => ir.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-many relationship between InterventionType and InterventionRequest
            modelBuilder.Entity<InterventionRequest>()
                .HasOne(i => i.Address)
                .WithOne(a => a.Intervention)
                .HasForeignKey<InterventionAddress>(a => a.InterventionId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between InterventionRequest and InterventionActivity
            modelBuilder.Entity<InterventionRequest>()
                .HasMany(i => i.Activities)
                .WithOne(ia => ia.Intervention)
                .HasForeignKey(ia => ia.InterventionId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between InterventionActivity and InterventionComment
            modelBuilder.Entity<InterventionActivity>()
                .HasMany(ia => ia.Messages)
                .WithOne(icm => icm.Activity)
                .HasForeignKey(icm => icm.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
