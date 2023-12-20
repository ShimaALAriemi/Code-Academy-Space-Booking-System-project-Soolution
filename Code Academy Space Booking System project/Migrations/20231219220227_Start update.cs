using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code_Academy_Space_Booking_System_project.Migrations
{
    public partial class Startupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spaces_Book_BooksBook_ID",
                table: "Spaces");

            migrationBuilder.DropIndex(
                name: "IX_Spaces_BooksBook_ID",
                table: "Spaces");

            migrationBuilder.DropColumn(
                name: "BooksBook_ID",
                table: "Spaces");

            migrationBuilder.AlterColumn<string>(
                name: "Start_Day",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "End_Day",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Book",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "SpaceID",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_SpaceID",
                table: "Book",
                column: "SpaceID",
                unique: true,
                filter: "[SpaceID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Spaces_SpaceID",
                table: "Book",
                column: "SpaceID",
                principalTable: "Spaces",
                principalColumn: "Space_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Spaces_SpaceID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_SpaceID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "SpaceID",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "BooksBook_ID",
                table: "Spaces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start_Day",
                table: "Book",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End_Day",
                table: "Book",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Book",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_BooksBook_ID",
                table: "Spaces",
                column: "BooksBook_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Spaces_Book_BooksBook_ID",
                table: "Spaces",
                column: "BooksBook_ID",
                principalTable: "Book",
                principalColumn: "Book_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
