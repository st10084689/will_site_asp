using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testing_site_wil.Migrations
{
    /// <inheritdoc />
    public partial class addedPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Shopping",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Shopping");
        }
    }
}
