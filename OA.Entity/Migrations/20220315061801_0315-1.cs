using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OA.Entity.Migrations
{
    public partial class _03151 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastLoginIp",
                table: "userAccounts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "userAccounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginAccount",
                table: "userAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoginLockAccount",
                table: "userAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginIp",
                table: "userAccounts");

            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "userAccounts");

            migrationBuilder.DropColumn(
                name: "LoginAccount",
                table: "userAccounts");

            migrationBuilder.DropColumn(
                name: "LoginLockAccount",
                table: "userAccounts");
        }
    }
}
