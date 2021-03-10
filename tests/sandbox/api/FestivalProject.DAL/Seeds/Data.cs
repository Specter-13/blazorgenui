using System;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.DAL.Seed
{
    public static class Data
    {
        public static readonly MemberEntity AdamDuricaMember1 = new MemberEntity
        {
            Id = Guid.Parse("d01d66d9-ac9d-4419-81b3-bc8ae2dfae96"),
            Name = "Janko",
            Surname = "Mrkvicka",
            InterpretId = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b")
        };
        public static readonly MemberEntity AdamDuricaMember2 = new MemberEntity
        {
            Id = Guid.Parse("af1e3d1f-fbd7-4d2f-a7f1-f7cda8e3547f"),
            Name = "Misko",
            Surname = "Maly",
            InterpretId = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b")
        };

        public static readonly MemberEntity MetallicaMember1 = new MemberEntity
        {
            Id = Guid.Parse("3464eae2-99f6-4462-b28b-fb8690e4a632"),
            Name = "James",
            Surname = "Hetfield",
            InterpretId = Guid.Parse("c993e8d3-719b-43d7-908b-e26dc6f4ace0")
        };

        public static readonly InterpretEntity AdamDurica = new InterpretEntity
        {
            Id = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b"),
            Name = "Adam Durica",
            LogoUri = "https://www.adamdurica.com/wp-content/uploads/2019/04/album_adam_durica_mandolina-400x400.jpg",
            Rating = 8.7f,
            Genre = MusicGenre.Rock,
            Description = "One of the most talented slovak singer."

        };
        public static readonly InterpretEntity TomasKlus = new InterpretEntity
        {
            Id = Guid.Parse("6fe7846f-3d54-4c46-9ebe-7d9558b4589e"),
            Name = "Tomas Klus",
            LogoUri = "https://upload.wikimedia.org/wikipedia/commons/3/3c/T_Klus_2014.JPG",
            Rating = 7.7f,
            Genre = MusicGenre.Rock,
            Description = "One of the best czech singers."

        };
        public static readonly InterpretEntity Metallica = new InterpretEntity
        {
            Id = Guid.Parse("c993e8d3-719b-43d7-908b-e26dc6f4ace0"),
            Name = "Metallica",
            LogoUri = "https://i.pinimg.com/originals/93/47/6b/93476b00366cd9998f5299a75d793f17.jpg",
            Rating = 9.7f,
            Genre = MusicGenre.Metal,
            Description = "Without word one of the best metal groups."
        };
        public static readonly StageEntity MainStage = new StageEntity
        {
            Id = Guid.Parse("cb22c323-729d-49e6-834a-644d47d3dc4c"),
            Name = "Main Stage",
            Capacity = 600,
            FestivalId = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),

        };

        public static readonly StageEntity LowStage = new StageEntity
        {
            Id = Guid.Parse("4afd5bb9-6c95-411b-becf-daffb873a7a4"),
            Name = "Low Stage",
            Capacity = 200,
            FestivalId = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),

        };

        public static readonly StageEntity MainStagePohoda = new StageEntity
        {
            Id = Guid.Parse("f9adad79-fd79-469d-8dda-53400fc572bd"),
            Name = "Main Stage Pohoda",
            Capacity = 5000,
            FestivalId = Guid.Parse("30d09c0f-f6aa-442c-9d87-2869faf175f4"),

        };

        public static readonly FestivalEntity FestivalGrape = new FestivalEntity
        {
            Id = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
            Capacity = 1500,
            Name = "Grape",
            City = "Piestany",
            LogoUri = "https://www.gregi.net/wp-content/uploads/2018/07/logo-1.jpg",
            Street = "Letiskova 123",
            Country = "Slovakia",
            Description = "One of the best festivals in Slovakia!",
            StartTime = new DateTime(2020, 7, 25),
            EndTime = new DateTime(2020, 7, 23),
            Genre = MusicGenre.Rock,
            Price = 55,

        };

        public static readonly FestivalEntity FestivalPohoda = new FestivalEntity
        {
            Id = Guid.Parse("30d09c0f-f6aa-442c-9d87-2869faf175f4"),
            Capacity = 10000,
            Name = "Pohoda",
            City = "Trenčin",
            LogoUri = "https://dl-media.viber.com/5/share/2/long/vibes/icon/image/0x0/105c/2c48f0221e7b0b58487a6483ba8c19e8a0a4f4d27a7e0291932b5dc92c41105c.jpg",
            Street = "Letisko",
            Country = "Slovakia",
            Description = "The best festivals in Slovakia!",
            StartTime = new DateTime(2020, 8, 6),
            EndTime = new DateTime(2020, 8, 10),
            Genre = MusicGenre.Rock,
            Price = 70,

        };
        public static readonly FestivalInterpretEntity FestivalInterpretPohodaDurica = new FestivalInterpretEntity
        {
            FestivalId = Guid.Parse("30d09c0f-f6aa-442c-9d87-2869faf175f4"),
            InterpretId = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b")

        };

        public static readonly FestivalInterpretEntity FestivalInterpretPohodaTomasKlus = new FestivalInterpretEntity
        {
            FestivalId = Guid.Parse("30d09c0f-f6aa-442c-9d87-2869faf175f4"),
            InterpretId = Guid.Parse("6fe7846f-3d54-4c46-9ebe-7d9558b4589e")

        };
        public static readonly FestivalInterpretEntity FestivalInterpretGrapeDurica = new FestivalInterpretEntity
        {
            FestivalId = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
            InterpretId = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b")

        };

        public static readonly FestivalInterpretEntity FestivalInterpretGrapeMetallica = new FestivalInterpretEntity
        {
            FestivalId = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
            InterpretId = Guid.Parse("c993e8d3-719b-43d7-908b-e26dc6f4ace0")

        };

       

        public static readonly StageInterpretEntity StageInterpretDuricaMainStage = new StageInterpretEntity
        {
            InterpretId = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b"),
            StageId = Guid.Parse("cb22c323-729d-49e6-834a-644d47d3dc4c"),
            ConcertLength = 120,
            ConcertStart = new DateTime(2020, 7, 25, 15, 0, 0),
            ConcertEnd = new DateTime(2020, 7, 25, 17, 0, 0)
        };


        public static readonly StageInterpretEntity StageInterpretMetallicaMainStage = new StageInterpretEntity
        {
            InterpretId = Guid.Parse("c993e8d3-719b-43d7-908b-e26dc6f4ace0"),
            StageId = Guid.Parse("cb22c323-729d-49e6-834a-644d47d3dc4c"),
            ConcertLength = 60,
            ConcertStart = new DateTime(2020, 7, 26, 10, 0, 0),
            ConcertEnd = new DateTime(2020, 7, 25, 11, 0, 0)
        };

        public static readonly StageInterpretEntity StageInterpretTomasKlusMainStagePohoda = new StageInterpretEntity
        {
            InterpretId = Guid.Parse("6fe7846f-3d54-4c46-9ebe-7d9558b4589e"),
            StageId = Guid.Parse("f9adad79-fd79-469d-8dda-53400fc572bd"),
            ConcertLength = 40,
            ConcertStart = new DateTime(2020, 7, 26, 20, 0, 0),
            ConcertEnd = new DateTime(2020, 7, 25, 20, 40, 0)
        };

        public static readonly UserEntity Admin = new UserEntity
        {
            Id = Guid.Parse("1ae18ad6-9809-4b19-be41-94aa4ff622f8"),
            Role = UserRoles.Admin,
            Name = "David",
            Surname = "Spavor",
            Country = "Slovakia",
            City = "Dolny Kubin",
            Street = "Hviezdoslavovo",
            Psc = "1234",
            Email = "xspavo00@vutrb.cz",
            Username = "admin",
            Password = "admin"
        };

        public static readonly UserEntity Viewer1 = new UserEntity
        {
            Id = Guid.Parse("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1"),
            Role = UserRoles.Viewer,
            Name = "Barbora",
            Surname = "Bakosova",
            Country = "Slovakia",
            City = "Bratislava",
            Street = "Vajnorska",
            Psc = "03855",
            Email = "trdielko@hotmail.sk",
            Username = "barborka",
            Password = "barborka"
        };

        public static readonly UserEntity Cashier = new UserEntity
        {
            Id = Guid.Parse("54d733af-b179-418c-b7d3-ca3d3f7c96a4"),
            Role = UserRoles.Cashier,
            Name = "Simon",
            Surname = "MIchalek",
            Country = "Czech Republic",
            City = "Pardubice",
            Street = "Orlojova",
            Psc = "13845",
            Email = "simonko@gmail.sk",
            Username = "pokladni",
            Password = "pokladni"
        };

        public static readonly UserEntity Organizer = new UserEntity
        {
            Id = Guid.Parse("2b578e7f-adef-4511-86d6-4237cf958d80"),
            Role = UserRoles.Organizer,
            Name = "Bolek",
            Surname = "Polivka",
            Country = "Czech Republic",
            City = "Praha",
            Street = "Letna",
            Psc = "236548",
            Email = "gutentag@gmail.com",
            Username = "organizator",
            Password = "organizator"
        };


        public static readonly ReservationEntity Viewer1Reservation = new ReservationEntity
        {
            Id = Guid.Parse("8edf6ecd-8d1d-4fbf-92c1-9640e4bc21d9"),
            State = ReservationStatus.InProgress,
            Tickets = 1,
            Price = 55,
            Description = "rezervacia sa vybavuje",
            FestivalId = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
            UserId = Guid.Parse("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1")
        };

        public static readonly ReservationEntity Viewer2Reservation = new ReservationEntity
        {
            Id = Guid.Parse("f1de571c-fa9e-42de-b19a-a67a66841112"),
            State = ReservationStatus.Declined,
            Tickets = 3,
            Price = 210,
            Description = "rezervacia zruzena kvoli nezaplateniu",
            FestivalId = Guid.Parse("30d09c0f-f6aa-442c-9d87-2869faf175f4"),
            UserId = Guid.Parse("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1")
        };
    }
}
