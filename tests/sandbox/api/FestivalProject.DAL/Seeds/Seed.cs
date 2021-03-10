using FestivalProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;

namespace FestivalProject.DAL.Seed
{
    public static class Seed
    {

        public static void SeedMembers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberEntity>(entity =>
            {
                entity.HasData(new
                {
                    Data.AdamDuricaMember1.Id,
                    Data.AdamDuricaMember1.Name,
                    Data.AdamDuricaMember1.Surname,
                    Data.AdamDuricaMember1.InterpretId
                });
                entity.HasData(new
                {
                    Data.AdamDuricaMember2.Id,
                    Data.AdamDuricaMember2.Name,
                    Data.AdamDuricaMember2.Surname,
                    Data.AdamDuricaMember2.InterpretId
                });
            });
            
        }
      
        public static void SeedInterprets(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InterpretEntity>(entity =>
            {
                entity.HasMany(x => x.MemberList)
                    .WithOne(x => x.Interpret);
                entity.HasData(new
                {
                    Data.AdamDurica.Id,
                    Data.AdamDurica.Name,
                    Data.AdamDurica.Genre,
                    Data.AdamDurica.Description,
                    Data.AdamDurica.LogoUri,
                    Data.AdamDurica.Rating
                });
                entity.HasData(new
                {
                    Data.Metallica.Id,
                    Data.Metallica.Name,
                    Data.Metallica.Genre,
                    Data.Metallica.Description,
                    Data.Metallica.LogoUri,
                    Data.Metallica.Rating
                });
                entity.HasData(new
                {
                    Data.TomasKlus.Id,
                    Data.TomasKlus.Name,
                    Data.TomasKlus.Genre,
                    Data.TomasKlus.Description,
                    Data.TomasKlus.LogoUri,
                    Data.TomasKlus.Rating
                });
            });
        }

        public static void SeedStages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StageEntity>(entity =>
            {
                entity.HasMany(x => x.StageInterpret);
                entity.HasOne(x=>x.Festival);
                entity.HasData(new
                {
                    Data.MainStage.Id,
                    Data.MainStage.Capacity,
                    Data.MainStage.Name,
                    Data.MainStage.FestivalId
                });
                entity.HasData(new
                {
                    Data.LowStage.Id,
                    Data.LowStage.Capacity,
                    Data.LowStage.Name,
                    Data.LowStage.FestivalId
                });
                entity.HasData(new
                {
                    Data.MainStagePohoda.Id,
                    Data.MainStagePohoda.Capacity,
                    Data.MainStagePohoda.Name,
                    Data.MainStagePohoda.FestivalId
                });
            });
        }

        

        public static void SeedFestivals(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FestivalEntity>(entity =>
            {
                entity.HasMany(x => x.StageList).WithOne(x => x.Festival);
                entity.HasData(new
                {
                    Data.FestivalGrape.Id,
                    Data.FestivalGrape.Name,
                    Data.FestivalGrape.Street,
                    Data.FestivalGrape.Genre,
                    Data.FestivalGrape.Capacity,
                    Data.FestivalGrape.LogoUri,
                    Data.FestivalGrape.City,
                    Data.FestivalGrape.Country,
                    Data.FestivalGrape.Description,
                    Data.FestivalGrape.StartTime,
                    Data.FestivalGrape.EndTime,
                    Data.FestivalGrape.Price,
                   
                });
                entity.HasData(new
                {
                    Data.FestivalPohoda.Id,
                    Data.FestivalPohoda.Name,
                    Data.FestivalPohoda.Street,
                    Data.FestivalPohoda.Genre,
                    Data.FestivalPohoda.Capacity,
                    Data.FestivalPohoda.LogoUri,
                    Data.FestivalPohoda.City,
                    Data.FestivalPohoda.Country,
                    Data.FestivalPohoda.Description,
                    Data.FestivalPohoda.StartTime,
                    Data.FestivalPohoda.EndTime,
                    Data.FestivalPohoda.Price,

                });
            });
        }
        public static void SeedFestivalInterpret(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FestivalInterpretEntity>(entity =>
            {
                entity.HasKey(bc => new {bc.InterpretId, bc.FestivalId});
                entity.HasOne<FestivalEntity>(bc => bc.Festival)
                    .WithMany(bc => bc.FestivalInterpret)
                    .HasForeignKey(bc => bc.FestivalId);
                entity.HasOne<InterpretEntity>(bc => bc.Interpret)
                    .WithMany(bc => bc.FestivalInterpret)
                    .HasForeignKey(bc => bc.InterpretId);
                entity.HasData(new
                {
                    Data.FestivalInterpretGrapeDurica.InterpretId,
                    Data.FestivalInterpretGrapeDurica.FestivalId
                });
                entity.HasData(new
                {
                    Data.FestivalInterpretGrapeMetallica.InterpretId,
                    Data.FestivalInterpretGrapeMetallica.FestivalId
                });
                entity.HasData(new
                {
                    Data.FestivalInterpretPohodaDurica.InterpretId,
                    Data.FestivalInterpretPohodaDurica.FestivalId
                });
                entity.HasData(new
                {
                    Data.FestivalInterpretPohodaTomasKlus.InterpretId,
                    Data.FestivalInterpretPohodaTomasKlus.FestivalId
                });
            });
        }

        public static void SeedStageInterpret(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StageInterpretEntity>(entity =>
            {
                entity.HasKey(bc => new { bc.InterpretId, bc.StageId });
                entity.HasOne<StageEntity>(bc => bc.Stage)
                    .WithMany(bc => bc.StageInterpret)
                    .HasForeignKey(bc => bc.StageId);
                entity.HasOne<InterpretEntity>(bc => bc.Interpret)
                    .WithMany(bc => bc.StageInterpret)
                    .HasForeignKey(bc => bc.InterpretId);
                entity.HasData(new
                {
                    Data.StageInterpretDuricaMainStage.StageId,
                    Data.StageInterpretDuricaMainStage.InterpretId,
                    Data.StageInterpretDuricaMainStage.ConcertLength,
                    Data.StageInterpretDuricaMainStage.ConcertStart,
                    Data.StageInterpretDuricaMainStage.ConcertEnd

                });
                entity.HasData(new
                {
                    Data.StageInterpretMetallicaMainStage.StageId,
                    Data.StageInterpretMetallicaMainStage.InterpretId,
                    Data.StageInterpretMetallicaMainStage.ConcertLength,
                    Data.StageInterpretMetallicaMainStage.ConcertStart,
                    Data.StageInterpretDuricaMainStage.ConcertEnd

                });
                entity.HasData(new
                {
                    Data.StageInterpretTomasKlusMainStagePohoda.StageId,
                    Data.StageInterpretTomasKlusMainStagePohoda.InterpretId,
                    Data.StageInterpretTomasKlusMainStagePohoda.ConcertLength,
                    Data.StageInterpretTomasKlusMainStagePohoda.ConcertStart,
                    Data.StageInterpretDuricaMainStage.ConcertEnd

                });
            });
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasMany(x => x.ReservationList);
                entity.HasData(new
                {
                    Data.Admin.Id,
                    Data.Admin.Name,
                    Data.Admin.Street,
                    Data.Admin.Country,
                    Data.Admin.City,
                    Data.Admin.Surname,
                    Data.Admin.Username,
                    Data.Admin.Password,
                    Data.Admin.Email,
                    Data.Admin.Psc,
                    Data.Admin.Role
                });
                entity.HasData(new
                {
                    Data.Viewer1.Id,
                    Data.Viewer1.Name,
                    Data.Viewer1.Street,
                    Data.Viewer1.Country,
                    Data.Viewer1.City,
                    Data.Viewer1.Surname,
                    Data.Viewer1.Username,
                    Data.Viewer1.Password,
                    Data.Viewer1.Email,
                    Data.Viewer1.Psc,
                    Data.Viewer1.Role
                });
                entity.HasData(new
                {
                    Data.Cashier.Id,
                    Data.Cashier.Name,
                    Data.Cashier.Street,
                    Data.Cashier.Country,
                    Data.Cashier.City,
                    Data.Cashier.Surname,
                    Data.Cashier.Username,
                    Data.Cashier.Password,
                    Data.Cashier.Email,
                    Data.Cashier.Psc,
                    Data.Cashier.Role
                });
                entity.HasData(new
                {
                    Data.Organizer.Id,
                    Data.Organizer.Name,
                    Data.Organizer.Street,
                    Data.Organizer.Country,
                    Data.Organizer.City,
                    Data.Organizer.Surname,
                    Data.Organizer.Username,
                    Data.Organizer.Password,
                    Data.Organizer.Email,
                    Data.Organizer.Psc,
                    Data.Organizer.Role
                });
            });
        }

        public static void SeedReservations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationEntity>(entity =>
            {
                entity.HasOne(x => x.User);
                entity.HasOne(x => x.Festival);
                entity.HasData(new
                {
                    Data.Viewer1Reservation.Id,
                    Data.Viewer1Reservation.FestivalId,
                    Data.Viewer1Reservation.Price,
                    Data.Viewer1Reservation.Description,
                    Data.Viewer1Reservation.State,
                    Data.Viewer1Reservation.Tickets,
                    Data.Viewer1Reservation.UserId
                });
                entity.HasData(new
                {
                    Data.Viewer2Reservation.Id,
                    Data.Viewer2Reservation.FestivalId,
                    Data.Viewer2Reservation.Price,
                    Data.Viewer2Reservation.Description,
                    Data.Viewer2Reservation.State,
                    Data.Viewer2Reservation.Tickets,
                    Data.Viewer2Reservation.UserId
                });

            });
        }



    }
}
