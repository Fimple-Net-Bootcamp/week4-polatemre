using VirtualPetCareApi.Domain.Entities;
using VirtualPetCareApi.Domain.Entities.Common;
using VirtualPetCareApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using VirtualPetCareApi.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace VirtualPetCareApi.Persistence.Contexts
{
    public class VirtualPetCareApiDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public VirtualPetCareApiDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<SocialInteraction> SocialInteractions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Food>().HasData(
                new Food { Id = 1, Value = 25, Name = "Kedi Maması"},
                new Food { Id = 2, Value = 50, Name = "Et" }
                );

            builder.Entity<Health>().HasData(
                new Health { Id = 1, Value = 100, Description = "Sağlıklı"},
                new Health { Id = 2, Value = 50, Description = "Orta"}
                );

            builder.Entity<Pet>().HasData(
                new Pet { Id = 1, Name = "Kedi", Description = "Sevimli", HealthId = 1, UserId = "b74ddd14-6340-4840-95c2-db12554843e5", Status = true },
                new Pet { Id = 2, Name = "Köpek", Description = "", HealthId = 1, UserId = "b74ddd14-6340-4840-95c2-db12554843e5", Status = true }
            );

            builder.Entity<Activity>().HasData(
                new Activity { Id = 1, Name = "Yürüyebilir", PetId = 1 },
                new Activity { Id = 2, Name = "Oyun Oynayabilir", PetId = 1 },
                new Activity { Id = 3, Name = "Eğitilebilir", PetId = 2, }
                );

            this.SeedUsers(builder);
            base.OnModelCreating(builder);

        }

        private void SeedUsers(ModelBuilder builder)
        {
            AppUser user = new AppUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                NameSurname = "Admin",
                UserName = "Admin",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                NormalizedUserName = "OWNER",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<AppUser>().HasData(user);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir.Update operasyonlarında track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
