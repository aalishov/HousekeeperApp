using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HousekeeperApp.Data.Migrations
{
    public partial class UpdateRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Requests");
        }
    }
}
