using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GalaxyArmies.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GalaxyArmiesModels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Address = table.Column<string>(maxLength: 80, nullable: false),
                    PhoneNumber = table.Column<long>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Armies = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalaxyArmiesModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalaxyArmiesModels");
        }
    }
}
