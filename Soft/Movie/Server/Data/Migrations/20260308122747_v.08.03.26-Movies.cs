using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abc.Soft.Web.Migrations
{
    /// <inheritdoc />
    public partial class v080326Movies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "ValidTo");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Movies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Movies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Movies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Movies",
                type: "BLOB",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "Movies",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "ValidTo",
                table: "Movies",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ReleaseDate",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
