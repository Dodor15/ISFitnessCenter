using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISFitnessCenter.Migrations
{
    /// <inheritdoc />
    public partial class End : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "specialtiyId1",
                table: "trener_Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_trener_Clients_specialtiyId1",
                table: "trener_Clients",
                column: "specialtiyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_trener_Clients_specialtiys_specialtiyId1",
                table: "trener_Clients",
                column: "specialtiyId1",
                principalTable: "specialtiys",
                principalColumn: "specialtiyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trener_Clients_specialtiys_specialtiyId1",
                table: "trener_Clients");

            migrationBuilder.DropIndex(
                name: "IX_trener_Clients_specialtiyId1",
                table: "trener_Clients");

            migrationBuilder.DropColumn(
                name: "specialtiyId1",
                table: "trener_Clients");
        }
    }
}
