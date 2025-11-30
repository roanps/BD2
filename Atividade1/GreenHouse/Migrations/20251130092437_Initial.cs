using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenHouse.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Plant_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sensor_Value = table.Column<float>(type: "real", nullable: true),
                    Sensor_Event = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Plant_Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
