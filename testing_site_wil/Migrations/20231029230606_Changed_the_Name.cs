using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testing_site_wil.Migrations
{
    /// <inheritdoc />
    public partial class Changed_the_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Events",
                newName: "EventTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventTime",
                table: "Events",
                newName: "DateTime");
        }
    }
}
