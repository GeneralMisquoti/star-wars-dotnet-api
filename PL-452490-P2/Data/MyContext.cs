using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using PL_452490_P2.Models;

namespace PL_452490_P2.Data
{
    public class MyContext : DbContext
    {
        public DbSet<PL_452490_P2.Models.Actor> Actors { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<ActorPerMovie> ActorsPerMovies { get; set; }
        public DbSet<AbstractWeaponType> AbstractWeaponTypes { get; set; }
        public DbSet<AbstractLifeFormType> AbstractLifeFormTypes { get; set; }
        public DbSet<LifeFormType> LifeFormTypes { get; set; }
        public DbSet<Blow> Blows { get; set; }
        public DbSet<Fight> Fights { get; set; }
        public DbSet<FightGroup> FightGroups { get; set; }
        public DbSet<FightStage> FightStages { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<WeaponOwners> WeaponOwners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Host=localhost;Database=postgres;Username=postgres;Password=postgress;Include Error Detail=true",
                o => o.UseNodaTime()
            );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Person>()
                .Property(e => e.ForceType)
                .HasConversion<string>();

            modelBuilder
                .Entity<Planet>()
                .Property(p => p.Population)
                .HasDefaultValueSql("0");
            
            modelBuilder
                .Entity<Planet>()
                .Property(p => p.NumMoons)
                .HasDefaultValueSql("1");
            
            modelBuilder
                .Entity<Planet>()
                .Property(p => p.NumSuns)
                .HasDefaultValueSql("1");

            // modelBuilder.Entity<Person>()
            //     .Property<int>("MasterId");

            modelBuilder
                .Entity<Person>()
                .HasOne(p => p.Apprentice)
                .WithOne(p => p.Master);
                // .HasOne<Person>(p => p.Apprentice)
                // .WithMany(p => p.Master)
                // .HasForeignKey("MasterId");

            modelBuilder
                .Entity<Person>()
                .HasOne(p => p.Master)
                .WithOne(p => p.Apprentice);
            
        }

    }
}