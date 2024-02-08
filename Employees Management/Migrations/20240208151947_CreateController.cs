using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Employees_Management.Migrations
{
    /// <inheritdoc />
    public partial class CreateController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Couons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreateId = table.Column<string>(type: "text", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedById = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ctiy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ctiy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ctiy_Couons_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Couons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ctiy_CountryId",
                table: "Ctiy",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ctiy");

            migrationBuilder.DropTable(
                name: "Couons");
        }
    }
}
