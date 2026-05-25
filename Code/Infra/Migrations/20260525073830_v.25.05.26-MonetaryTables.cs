using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v250526MonetaryTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrency_Countries_CountryId",
                table: "CountryCurrency");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrency_Currencies_CurrencyId",
                table: "CountryCurrency");

            migrationBuilder.DropForeignKey(
                name: "FK_Money_Currencies_CurrencyId",
                table: "Money");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Money_MoneyId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Money",
                table: "Money");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryCurrency",
                table: "CountryCurrency");

            migrationBuilder.RenameTable(
                name: "Money",
                newName: "Monies");

            migrationBuilder.RenameTable(
                name: "CountryCurrency",
                newName: "CountryCurrencies");

            migrationBuilder.RenameIndex(
                name: "IX_Money_CurrencyId",
                table: "Monies",
                newName: "IX_Monies_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryCurrency_CurrencyId",
                table: "CountryCurrencies",
                newName: "IX_CountryCurrencies_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryCurrency_CountryId",
                table: "CountryCurrencies",
                newName: "IX_CountryCurrencies_CountryId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "Monies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "CountryCurrencies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "CountryCurrencies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Monies",
                table: "Monies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryCurrencies",
                table: "CountryCurrencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrencies_Countries_CountryId",
                table: "CountryCurrencies",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrencies_Currencies_CurrencyId",
                table: "CountryCurrencies",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monies_Currencies_CurrencyId",
                table: "Monies",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Monies_MoneyId",
                table: "Movies",
                column: "MoneyId",
                principalTable: "Monies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrencies_Countries_CountryId",
                table: "CountryCurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrencies_Currencies_CurrencyId",
                table: "CountryCurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Monies_Currencies_CurrencyId",
                table: "Monies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Monies_MoneyId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Monies",
                table: "Monies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryCurrencies",
                table: "CountryCurrencies");

            migrationBuilder.RenameTable(
                name: "Monies",
                newName: "Money");

            migrationBuilder.RenameTable(
                name: "CountryCurrencies",
                newName: "CountryCurrency");

            migrationBuilder.RenameIndex(
                name: "IX_Monies_CurrencyId",
                table: "Money",
                newName: "IX_Money_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryCurrencies_CurrencyId",
                table: "CountryCurrency",
                newName: "IX_CountryCurrency_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryCurrencies_CountryId",
                table: "CountryCurrency",
                newName: "IX_CountryCurrency_CountryId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "Money",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "CountryCurrency",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "CountryCurrency",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Money",
                table: "Money",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryCurrency",
                table: "CountryCurrency",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrency_Countries_CountryId",
                table: "CountryCurrency",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrency_Currencies_CurrencyId",
                table: "CountryCurrency",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Money_Currencies_CurrencyId",
                table: "Money",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Money_MoneyId",
                table: "Movies",
                column: "MoneyId",
                principalTable: "Money",
                principalColumn: "Id");
        }
    }
}
