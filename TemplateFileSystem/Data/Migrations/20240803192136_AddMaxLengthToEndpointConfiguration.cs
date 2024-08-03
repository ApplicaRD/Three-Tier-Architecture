using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateFileSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxLengthToEndpointConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Configurations",
                table: "Configurations");

            migrationBuilder.RenameTable(
                name: "Configurations",
                newName: "TblConfiguration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblConfiguration",
                table: "TblConfiguration",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblConfiguration",
                table: "TblConfiguration");

            migrationBuilder.RenameTable(
                name: "TblConfiguration",
                newName: "Configurations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configurations",
                table: "Configurations",
                column: "Id");
        }
    }
}
