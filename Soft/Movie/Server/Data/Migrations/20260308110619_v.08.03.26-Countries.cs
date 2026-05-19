using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abc.Soft.Web.Migrations
{
    /// <inheritdoc />
    public partial class v080326Countries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OfficialName = table.Column<string>(type: "TEXT", nullable: true),
                    NativeName = table.Column<string>(type: "TEXT", nullable: true),
                    NumericCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsoCode = table.Column<string>(type: "TEXT", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });
        }
    }
}
