using Domain;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Station> Station { get; set; }
        public DbSet<PowerUnit> PowerUnit { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }


        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=postgres;Password=12345");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );


            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = 1, 
                    FirstName = "Ivan", 
                    SecondName = "Ivanov",
                    Patronymic = "Ivanovich", 
                    Email = "admin@mail.ru", 
                    Password = PasswordHasher.HashPassword("admin"),
                    RoleId = 1 
                },
                new User 
                {
                    Id = 2,
                    FirstName = "Semen",
                    SecondName = "Semenov",
                    Patronymic = "Semenovich",
                    Email = "user@mail.ru",
                    Password = PasswordHasher.HashPassword("user"),
                    RoleId = 2
                }
            );


            #region Station

            modelBuilder.Entity<Station>()
                .ToTable("STATION");

            modelBuilder.Entity<Station>()
               .HasKey(e => e.Id);

            modelBuilder.Entity<Station>()
                .Property(e => e.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Station>()
                .Property(e => e.Name)
                .HasColumnName("name");

            modelBuilder.Entity<Station>()
                .Property(e => e.CreatedAt)
                .HasColumnName("created_at");

            modelBuilder.Entity<Station>()
                .HasMany(x => x.PowerUnits)
                .WithOne(x => x.Station)
                .HasForeignKey(x => x.StationId);

            #endregion

            #region PowerUnit
            modelBuilder.Entity<PowerUnit>()
                .ToTable("POWER_UNIT");

            modelBuilder.Entity<PowerUnit>()
               .HasKey(e => e.Id);

            modelBuilder.Entity<PowerUnit>()
                .Property(e => e.Id)
                .HasColumnName("id");

            modelBuilder.Entity<PowerUnit>()
                .Property(e => e.Name)
                .HasColumnName("name");

            modelBuilder.Entity<PowerUnit>()
                .Property(e => e.CreatedAt)
                .HasColumnName("created_at");

            modelBuilder.Entity<PowerUnit>()
                .Property(e => e.StationId)
                .HasColumnName("station_id");

            modelBuilder.Entity<PowerUnit>()
                .Property(e => e.DateOfNextService)
                .HasColumnName("date_of_next_service");

            modelBuilder.Entity<PowerUnit>()
                .Property(e => e.CountSensor)
                .HasColumnName("count_sensor");

            #endregion

            #region Role

            modelBuilder.Entity<Role>()
               .ToTable("ROLE");

            modelBuilder.Entity<Role>()
               .HasKey(e => e.Id);

            modelBuilder.Entity<Role>()
                .Property(e => e.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .HasColumnName("name");

            #endregion

            #region User

            modelBuilder.Entity<User>()
               .ToTable("USER");

            modelBuilder.Entity<User>()
               .HasKey(e => e.Id);

            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .HasColumnName("id");

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .HasColumnName("first_name");

            modelBuilder.Entity<User>()
               .Property(e => e.SecondName)
               .HasColumnName("second_name");

            modelBuilder.Entity<User>()
               .Property(e => e.Patronymic)
               .HasColumnName("patronymic");

            modelBuilder.Entity<User>()
               .Property(e => e.Email)
               .HasColumnName("email");

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role) 
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            #endregion
        }
    }
}
