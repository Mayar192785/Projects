using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Global.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// IdentityUserClaim<TKey>
        /// IdentityUserClaim<string>
        /// </summary>
        public DbSet<IdentityUserClaim<string>> AspNetUserClaims { get; set; }

        public DbSet<IdentityUserRole<string>> AspNetUserRoles { get; set; }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        public DbSet<ApplicationRole> AspNetRoles { get; set; }

        /// <summary>
        /// make it strign as the definition has the TKey assigned to Role id
        /// </summary>
        public DbSet<IdentityRoleClaim<string>> AspNetRoleClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Configure Asp Net Identity Tables
            //builder.Entity<ApplicationUser>(i =>
            //{
            //    i.Property<string>("Id").ValueGeneratedOnAdd();
            //    i.HasKey(x => x.Id);
            //    //i.Property(u => u.PasswordHash).HasMaxLength(500);
            //    //i.Property(u => u.PhoneNumber).HasMaxLength(50);
            //    i.ToTable("AspNetUsers");
            //    //with user calims
            //    i.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            //    i.HasMany<IdentityUserClaim<string>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
            //});
            //builder.Entity<ApplicationRole>(i =>
            //{
            //    i.ToTable("AspNetRoles");
            //    i.HasKey(x => x.Id);
            //    i.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
            //    i.HasMany<IdentityRoleClaim<string>>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            //});

            //builder.Entity<IdentityUserRole<string>>(i =>
            //{
            //    i.ToTable("AspNetUserRoles");
            //    i.HasKey(x => new { x.RoleId, x.UserId });
            //});

            //builder.Entity<IdentityUserClaim<string>>(i =>
            //{
            //    i.ToTable("AspNetUserClaims");
            //    i.HasKey(x => x.Id);
            //    i.Property(u => u.ClaimType).HasMaxLength(150);
            //    i.Property(u => u.ClaimValue).HasMaxLength(500);
            //});
            //builder.Entity<IdentityRoleClaim<string>>(i =>
            //{
            //    i.ToTable("AspNetRoleClaims");
            //    i.HasKey(x => x.Id);
            //    //i.Property<string>("RoleId").IsRequired();
            //});

            builder.Entity<ApplicationUser>()
                 .Property(e => e.Id)
                 .ValueGeneratedOnAdd();

            builder.Entity<ApplicationUser>()
              .HasMany(e => e.Claims)
              .WithOne()
              .HasForeignKey(e => e.UserId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>()
              .HasMany(e => e.Users)
              .WithOne()
              .HasForeignKey(e => e.RoleId)
              .IsRequired();
        }
    }
}