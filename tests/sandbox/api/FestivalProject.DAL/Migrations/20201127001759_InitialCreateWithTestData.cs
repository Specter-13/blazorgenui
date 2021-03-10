using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivalProject.DAL.Migrations
{
    public partial class InitialCreateWithTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Genre = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    LogoUri = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interprets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LogoUri = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interprets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Psc = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    FestivalId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FestivalInterprets",
                columns: table => new
                {
                    FestivalId = table.Column<Guid>(nullable: false),
                    InterpretId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalInterprets", x => new { x.InterpretId, x.FestivalId });
                    table.ForeignKey(
                        name: "FK_FestivalInterprets_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FestivalInterprets_Interprets_InterpretId",
                        column: x => x.InterpretId,
                        principalTable: "Interprets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    InterpretId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Interprets_InterpretId",
                        column: x => x.InterpretId,
                        principalTable: "Interprets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Tickets = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FestivalId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StageInterprets",
                columns: table => new
                {
                    InterpretId = table.Column<Guid>(nullable: false),
                    StageId = table.Column<Guid>(nullable: false),
                    ConcertLength = table.Column<int>(nullable: false),
                    ConcertStart = table.Column<DateTime>(nullable: false),
                    ConcertEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageInterprets", x => new { x.InterpretId, x.StageId });
                    table.ForeignKey(
                        name: "FK_StageInterprets_Interprets_InterpretId",
                        column: x => x.InterpretId,
                        principalTable: "Interprets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StageInterprets_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "Capacity", "City", "Country", "Description", "EndTime", "Genre", "LogoUri", "Name", "Price", "StartTime", "Street" },
                values: new object[,]
                {
                    { new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e"), 1500, "Piestany", "Slovakia", "One of the best festivals in Slovakia!", new DateTime(2020, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://www.gregi.net/wp-content/uploads/2018/07/logo-1.jpg", "Grape", 55m, new DateTime(2020, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Letiskova 123" },
                    { new Guid("30d09c0f-f6aa-442c-9d87-2869faf175f4"), 10000, "Trenčin", "Slovakia", "The best festivals in Slovakia!", new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://dl-media.viber.com/5/share/2/long/vibes/icon/image/0x0/105c/2c48f0221e7b0b58487a6483ba8c19e8a0a4f4d27a7e0291932b5dc92c41105c.jpg", "Pohoda", 70m, new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Letisko" }
                });

            migrationBuilder.InsertData(
                table: "Interprets",
                columns: new[] { "Id", "Description", "Genre", "LogoUri", "Name", "Rating" },
                values: new object[,]
                {
                    { new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), "One of the most talented slovak singer.", 0, "https://www.adamdurica.com/wp-content/uploads/2019/04/album_adam_durica_mandolina-400x400.jpg", "Adam Durica", 8.7f },
                    { new Guid("c993e8d3-719b-43d7-908b-e26dc6f4ace0"), "Without word one of the best metal groups.", 2, "https://i.pinimg.com/originals/93/47/6b/93476b00366cd9998f5299a75d793f17.jpg", "Metallica", 9.7f },
                    { new Guid("6fe7846f-3d54-4c46-9ebe-7d9558b4589e"), "One of the best czech singers.", 0, "https://upload.wikimedia.org/wikipedia/commons/3/3c/T_Klus_2014.JPG", "Tomas Klus", 7.7f }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Country", "Email", "Name", "Password", "Psc", "Role", "Street", "Surname", "Username" },
                values: new object[,]
                {
                    { new Guid("1ae18ad6-9809-4b19-be41-94aa4ff622f8"), null, "Slovakia", "xspavo00@vutrb.cz", "David", "123", null, 0, null, "Spavor", "admin" },
                    { new Guid("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1"), "Bratislava", "Slovakia", "trdielko@hotmail.sk", "Barbora", "12345", "03855", 3, "Vajnorska", "Bakosova", "trdielko" },
                    { new Guid("54d733af-b179-418c-b7d3-ca3d3f7c96a4"), "Pardubice", "Czech Republic", "simonko@gmail.sk", "Simon", "pokladni", "13845", 2, "Orlojova", "Sedlacek", "pokladni" },
                    { new Guid("2b578e7f-adef-4511-86d6-4237cf958d80"), "Praha", "Czech Republic", "gutentag@gmail.com", "Bolek", "organizator", "236548", 1, "Letna", "Polivka", "organizator" }
                });

            migrationBuilder.InsertData(
                table: "FestivalInterprets",
                columns: new[] { "InterpretId", "FestivalId" },
                values: new object[,]
                {
                    { new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e") },
                    { new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), new Guid("30d09c0f-f6aa-442c-9d87-2869faf175f4") },
                    { new Guid("c993e8d3-719b-43d7-908b-e26dc6f4ace0"), new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e") },
                    { new Guid("6fe7846f-3d54-4c46-9ebe-7d9558b4589e"), new Guid("30d09c0f-f6aa-442c-9d87-2869faf175f4") }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "InterpretId", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("d01d66d9-ac9d-4419-81b3-bc8ae2dfae96"), new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), "Janko", "Mrkvicka" },
                    { new Guid("af1e3d1f-fbd7-4d2f-a7f1-f7cda8e3547f"), new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), "Misko", "Maly" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Description", "FestivalId", "Name", "Price", "State", "Tickets", "UserId" },
                values: new object[,]
                {
                    { new Guid("8edf6ecd-8d1d-4fbf-92c1-9640e4bc21d9"), "rezervacia sa vybavuje", new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e"), "Grape rezervacia (mozno bude lepsie nejake cislo rezervacie)", 55m, 0, 1, new Guid("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1") },
                    { new Guid("f1de571c-fa9e-42de-b19a-a67a66841112"), "rezervacia zruzena kvoli nezaplateniu", new Guid("30d09c0f-f6aa-442c-9d87-2869faf175f4"), "Pohoda rezervacia (mozno bude lepsie nejake cislo rezervacie)", 210m, 2, 3, new Guid("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1") }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "Capacity", "FestivalId", "Name" },
                values: new object[,]
                {
                    { new Guid("cb22c323-729d-49e6-834a-644d47d3dc4c"), 600, new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e"), "Main Stage" },
                    { new Guid("4afd5bb9-6c95-411b-becf-daffb873a7a4"), 200, new Guid("46abef51-c53f-4cc5-a270-a2756ef1455e"), "Low Stage" },
                    { new Guid("f9adad79-fd79-469d-8dda-53400fc572bd"), 5000, new Guid("30d09c0f-f6aa-442c-9d87-2869faf175f4"), "Main Stage Pohoda" }
                });

            migrationBuilder.InsertData(
                table: "StageInterprets",
                columns: new[] { "InterpretId", "StageId", "ConcertEnd", "ConcertLength", "ConcertStart" },
                values: new object[] { new Guid("0c41b222-d06b-4021-9668-a4f845bbe57b"), new Guid("cb22c323-729d-49e6-834a-644d47d3dc4c"), new DateTime(2020, 7, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), 120, new DateTime(2020, 7, 25, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "StageInterprets",
                columns: new[] { "InterpretId", "StageId", "ConcertEnd", "ConcertLength", "ConcertStart" },
                values: new object[] { new Guid("c993e8d3-719b-43d7-908b-e26dc6f4ace0"), new Guid("cb22c323-729d-49e6-834a-644d47d3dc4c"), new DateTime(2020, 7, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), 60, new DateTime(2020, 7, 26, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "StageInterprets",
                columns: new[] { "InterpretId", "StageId", "ConcertEnd", "ConcertLength", "ConcertStart" },
                values: new object[] { new Guid("6fe7846f-3d54-4c46-9ebe-7d9558b4589e"), new Guid("f9adad79-fd79-469d-8dda-53400fc572bd"), new DateTime(2020, 7, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), 40, new DateTime(2020, 7, 26, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_FestivalInterprets_FestivalId",
                table: "FestivalInterprets",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_InterpretId",
                table: "Members",
                column: "InterpretId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FestivalId",
                table: "Reservations",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StageInterprets_StageId",
                table: "StageInterprets",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_FestivalId",
                table: "Stages",
                column: "FestivalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FestivalInterprets");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "StageInterprets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Interprets");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Festivals");
        }
    }
}
