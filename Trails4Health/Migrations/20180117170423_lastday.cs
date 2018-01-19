using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trails4Health.Migrations
{
    public partial class lastday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdGuide",
                table: "Guide",
                newName: "GuideId");

            migrationBuilder.AddColumn<string>(
                name: "NIF",
                table: "Guide",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    DifficultyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.DifficultyID);
                });

            migrationBuilder.CreateTable(
                name: "Trail",
                columns: table => new
                {
                    TrailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DifficultyId = table.Column<int>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trail", x => x.TrailsId);
                    table.ForeignKey(
                        name: "FK_Trail_Difficulty_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulty",
                        principalColumn: "DifficultyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuideTrail",
                columns: table => new
                {
                    GuideId = table.Column<int>(nullable: false),
                    TrailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideTrail", x => new { x.GuideId, x.TrailId });
                    table.ForeignKey(
                        name: "FK_GuideTrail_Guide_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Guide",
                        principalColumn: "GuideId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuideTrail_Trail_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trail",
                        principalColumn: "TrailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuideTrail_TrailId",
                table: "GuideTrail",
                column: "TrailId");

            migrationBuilder.CreateIndex(
                name: "IX_Trail_DifficultyId",
                table: "Trail",
                column: "DifficultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuideTrail");

            migrationBuilder.DropTable(
                name: "Trail");

            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropColumn(
                name: "NIF",
                table: "Guide");

            migrationBuilder.RenameColumn(
                name: "GuideId",
                table: "Guide",
                newName: "IdGuide");
        }
    }
}
