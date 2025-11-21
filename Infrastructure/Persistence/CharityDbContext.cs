using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Persistence
{
    public class CharityDbContext
        : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public CharityDbContext(DbContextOptions<CharityDbContext> options)
            : base(options) { }


        public DbSet<Donor> Donors { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Donation> Donations { get; set; }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectVolunteer> ProjectVolunteers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Donor>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.FullName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(d => d.Email)
                      .HasMaxLength(150);

                entity.Property(d => d.PhoneNumber)
                      .HasMaxLength(50);

                entity.Property(d => d.Country)
                      .HasMaxLength(100);

                entity.Property(d => d.Address)
                      .HasMaxLength(300);
            });

            builder.Entity<Beneficiary>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.FullName).IsRequired().HasMaxLength(200);
                entity.Property(b => b.NationalId).HasMaxLength(50);
                entity.Property(b => b.PhoneNumber).HasMaxLength(50);
                entity.Property(b => b.Country).HasMaxLength(100);
                entity.Property(b => b.Address).HasMaxLength(300);
                entity.Property(b => b.Notes).HasMaxLength(500);
            });

            builder.Entity<Donation>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.HasOne(d => d.Donor)
                      .WithMany()
                      .HasForeignKey(d => d.DonorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Beneficiary)
                      .WithMany()
                      .HasForeignKey(d => d.BeneficiaryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(d => d.Amount).HasColumnType("decimal(18,2)");
                entity.Property(d => d.Currency).HasMaxLength(10);
                entity.Property(d => d.DonationType).HasMaxLength(100);
            });

            builder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Currency).HasMaxLength(10);
            });

            builder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Amount).HasColumnType("decimal(18,2)");
                entity.Property(t => t.Currency).HasMaxLength(10);
            });

            builder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.FullName).IsRequired().HasMaxLength(200);
                entity.Property(v => v.Email).HasMaxLength(200);
                entity.Property(v => v.Phone).HasMaxLength(50);
            });

            builder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Description).HasMaxLength(1000);
            });

            // ProjectVolunteer Config (Join Table)
            builder.Entity<ProjectVolunteer>(entity =>
            {
                entity.HasKey(pv => new { pv.ProjectId, pv.VolunteerId });

                entity.HasOne(pv => pv.Project)
                      .WithMany(p => p.ProjectVolunteers)
                      .HasForeignKey(pv => pv.ProjectId);

                entity.HasOne(pv => pv.Volunteer)
                      .WithMany(v => v.ProjectVolunteers)
                      .HasForeignKey(pv => pv.VolunteerId);

                entity.Property(pv => pv.Role).HasMaxLength(100);
            });

            builder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Position).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
            });
        }
    }
}

