using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mobile.al.Migrations
{
    public partial class DbSetCarPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPhoto_Cars_CarId",
                table: "CarPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPhoto",
                table: "CarPhoto");

            migrationBuilder.RenameTable(
                name: "CarPhoto",
                newName: "CarPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_CarPhoto_CarId",
                table: "CarPhotos",
                newName: "IX_CarPhotos_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPhotos",
                table: "CarPhotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPhotos_Cars_CarId",
                table: "CarPhotos",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPhotos_Cars_CarId",
                table: "CarPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPhotos",
                table: "CarPhotos");

            migrationBuilder.RenameTable(
                name: "CarPhotos",
                newName: "CarPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_CarPhotos_CarId",
                table: "CarPhoto",
                newName: "IX_CarPhoto_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPhoto",
                table: "CarPhoto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPhoto_Cars_CarId",
                table: "CarPhoto",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
