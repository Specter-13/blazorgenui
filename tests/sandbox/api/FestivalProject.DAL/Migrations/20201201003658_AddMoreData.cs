using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivalProject.DAL.Migrations
{
    public partial class AddMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1ae18ad6-9809-4b19-be41-94aa4ff622f8"),
                columns: new[] { "City", "Password", "Psc", "Street" },
                values: new object[] { "Dolny Kubin", "admin", "1234", "Hviezdoslavovo" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("54d733af-b179-418c-b7d3-ca3d3f7c96a4"),
                column: "Surname",
                value: "MIchalek");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1"),
                columns: new[] { "Password", "Username" },
                values: new object[] { "barborka", "barborka" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("8edf6ecd-8d1d-4fbf-92c1-9640e4bc21d9"),
                column: "Name",
                value: "Grape rezervacia (mozno bude lepsie nejake cislo rezervacie)");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("f1de571c-fa9e-42de-b19a-a67a66841112"),
                column: "Name",
                value: "Pohoda rezervacia (mozno bude lepsie nejake cislo rezervacie)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1ae18ad6-9809-4b19-be41-94aa4ff622f8"),
                columns: new[] { "City", "Password", "Psc", "Street" },
                values: new object[] { null, "123", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("54d733af-b179-418c-b7d3-ca3d3f7c96a4"),
                column: "Surname",
                value: "Sedlacek");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1"),
                columns: new[] { "Password", "Username" },
                values: new object[] { "12345", "trdielko" });
        }
    }
}
