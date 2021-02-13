using Microsoft.EntityFrameworkCore.Migrations;

namespace WTHRstat.APP.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Emission_Id",
                table: "Sources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Source_Id",
                table: "Emissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sources_Emission_Id",
                table: "Sources",
                column: "Emission_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sources_Emissions_Emission_Id",
                table: "Sources",
                column: "Emission_Id",
                principalTable: "Emissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sources_Emissions_Emission_Id",
                table: "Sources");

            migrationBuilder.DropIndex(
                name: "IX_Sources_Emission_Id",
                table: "Sources");

            migrationBuilder.DropColumn(
                name: "Emission_Id",
                table: "Sources");

            migrationBuilder.DropColumn(
                name: "Source_Id",
                table: "Emissions");
        }
    }
}
