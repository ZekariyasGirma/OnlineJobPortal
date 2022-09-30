using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineJobPortal.Migrations
{
    public partial class photourlToByte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "JobSeeker");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Companies");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "JobSeeker",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Companies",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "JobSeeker");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "JobSeeker",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
