using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Seed;
using Microsoft.EntityFrameworkCore;

namespace FestivalProject.DAL
{
    public class FestivalDbContext : DbContext
    {
        public FestivalDbContext(DbContextOptions options):base(options)
        {
               
        }

        public DbSet<FestivalInterpretEntity> FestivalInterprets { get; set; }
        public DbSet<StageInterpretEntity> StageInterprets { get; set; }
        public DbSet<FestivalEntity> Festivals { get; set; }
        public DbSet<InterpretEntity> Interprets { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<StageEntity> Stages { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedMembers();
            modelBuilder.SeedInterprets();
            modelBuilder.SeedStages();
            modelBuilder.SeedFestivals();
            modelBuilder.SeedFestivalInterpret();
            modelBuilder.SeedStageInterpret();
            modelBuilder.SeedUsers();
            modelBuilder.SeedReservations();

        }
    }
}
