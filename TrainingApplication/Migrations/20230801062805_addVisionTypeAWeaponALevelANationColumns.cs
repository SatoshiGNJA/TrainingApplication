using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingApplication.Migrations
{
    public partial class addVisionTypeAWeaponALevelANationColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nation",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisionType",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weapon",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Nation",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "VisionType",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Weapon",
                table: "Characters");
        }
    }
}
