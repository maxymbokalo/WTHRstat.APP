using Microsoft.EntityFrameworkCore.Migrations;

namespace WTHRstat.APP.Migrations
{
    public partial class _131 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Emissions");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Emissions",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Emissions",
                columns: new[] { "Id", "Count", "Date", "Name", "Source_Id" },
                values: new object[] { 1, 23, "23.23.2011", "Emiss-23", 1 });

            migrationBuilder.InsertData(
                table: "Emissions",
                columns: new[] { "Id", "Count", "Date", "Name", "Source_Id" },
                values: new object[] { 2, 25, "23.23.2011", "Coqwe-211", 2 });

            migrationBuilder.InsertData(
                table: "Emissions",
                columns: new[] { "Id", "Count", "Date", "Name", "Source_Id" },
                values: new object[] { 3, 51, "23.23.2011", "Rqeeq-214", 3 });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Address", "Emission_Id", "Name" },
                values: new object[] { 1, "Nrqr St.14 Ap.21", 1, "Emiss-23" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Address", "Emission_Id", "Name" },
                values: new object[] { 2, "Nragagag St.145 Ap.212", 2, "Coqwe-211" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "Address", "Emission_Id", "Name" },
                values: new object[] { 3, "Nrqexxx St.24 Ap.251", 3, "Rqeeq-214" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Emissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Emissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Emissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Emissions");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Emissions",
                type: "text",
                nullable: true);
        }
    }
}
