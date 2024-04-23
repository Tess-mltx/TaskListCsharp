using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TaskList.Models.Entities;

namespace TaskList.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        }

        public DbSet<Assignment> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role_Permission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SeedUsers(modelBuilder);
            this.SeedRoles(modelBuilder);

            // Configure User-Assignment relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.Assignments)
                .WithOne(a => a.User) 
                .HasForeignKey(a => a.UserId);

            // Configure User-Role relationship (one-to-many)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role) 
                .WithMany(r => r.Users) 
                .HasForeignKey(u => u.RoleId);

            // Configure Role-Permission relationship (many-to-many)
            modelBuilder.Entity<Role_Permission>() 
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<Role_Permission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<Role_Permission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);
        }
        private void SeedUsers (ModelBuilder modelBuilder)
        {
            User user = new User()
            {
                UserId = Guid.NewGuid(),
                Name = "Doctor",
                Email = "Doctor@tardis.com",
                RoleId = 1,
            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            passwordHasher.HashPassword(user, "Doctor*L'odeur de la terre apres la pluie");
            modelBuilder.Entity<User>().HasData(user);
        }

        private void SeedRoles (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                     RoleId = 1,
                     RoleName = "Admin",
                     NormalizedName = "Admin",
                },
                new Role()
                {
                    RoleId = 2,
                    RoleName = "User",
                    NormalizedName = "User",
                }
                );
        }

        private void SeedPermissions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(
                new Permission()
                {
                    PermissionId = 1,
                    Description = "Create User",
                },

                new Permission()
                {
                    PermissionId = 2,
                    Description = "Read User",
                },

                new Permission()
                {
                    PermissionId = 3,
                    Description = "Update User",
                },

                new Permission()
                {
                    PermissionId = 4,
                    Description = "Delete User",
                },

                new Permission()
                {
                    PermissionId = 5,
                    Description = "Read Own Task",
                },

                new Permission()
                {
                    PermissionId = 6,
                    Description = "Create Own Task",
                },

                new Permission()
                {
                    PermissionId = 7,
                    Description = "Update Own Task",
                },

                new Permission()
                {
                    PermissionId = 8,
                    Description = "Delete Own Task",
                }
                );
        }

        private void SeedRole_Permission(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role_Permission>().HasData(
                
                new Role_Permission()
                {
                    RoleId = 1,
                    PermissionId = 1,
                },
                new Role_Permission()
                {
                    RoleId = 1,
                    PermissionId = 2,
                },
                new Role_Permission()
                {
                    RoleId = 1,
                    PermissionId = 3,
                },
                new Role_Permission()
                {
                    RoleId = 1,
                    PermissionId = 4,
                },
                new Role_Permission()
                {
                    RoleId = 1,
                    PermissionId = 5,
                },
                new Role_Permission()
                {
                    RoleId = 1,
                    PermissionId = 6,
                },
                new Role_Permission()
                {
                    RoleId = 1,
                    PermissionId = 7,
                },
                new Role_Permission()
                {
                    RoleId = 1,
                    PermissionId = 8,
                },
                new Role_Permission()
                {
                    RoleId = 2,
                    PermissionId = 5,
                },

                new Role_Permission()
                {
                    RoleId = 2,
                    PermissionId = 6,
                },
                new Role_Permission()
                {
                    RoleId = 2,
                    PermissionId = 7,
                },
                new Role_Permission()
                {
                    RoleId = 2,
                    PermissionId = 8,
                }
                );
        }
    }
}
