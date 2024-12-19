using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class addloans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loans_AspNetUsers_UserId",
                table: "loans");

            migrationBuilder.DropForeignKey(
                name: "FK_transfer_AspNetUsers_UserId",
                table: "transfer");

            migrationBuilder.DropIndex(
                name: "IX_transfer_UserId",
                table: "transfer");

            migrationBuilder.DropIndex(
                name: "IX_loans_UserId",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "transfer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "loans");

            migrationBuilder.AlterColumn<int>(
                name: "ToAccountId",
                table: "transfer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromAccountId",
                table: "transfer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_loans_AccountId",
                table: "loans",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_loans_accounts_AccountId",
                table: "loans",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loans_accounts_AccountId",
                table: "loans");

            migrationBuilder.DropIndex(
                name: "IX_loans_AccountId",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "loans");

            migrationBuilder.AlterColumn<int>(
                name: "ToAccountId",
                table: "transfer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FromAccountId",
                table: "transfer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "transfer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "loans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_UserId",
                table: "transfer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_loans_UserId",
                table: "loans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_loans_AspNetUsers_UserId",
                table: "loans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfer_AspNetUsers_UserId",
                table: "transfer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
