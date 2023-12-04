using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISFitnessCenter.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adresses",
                columns: table => new
                {
                    AdressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mainAdress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresses", x => x.AdressId);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIOclient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pool = table.Column<bool>(type: "bit", nullable: false),
                    Ring = table.Column<bool>(type: "bit", nullable: false),
                    Aerobic = table.Column<bool>(type: "bit", nullable: false),
                    Dance = table.Column<bool>(type: "bit", nullable: false),
                    trampoline = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "times",
                columns: table => new
                {
                    TimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shift = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_times", x => x.TimeId);
                });

            migrationBuilder.CreateTable(
                name: "weeks",
                columns: table => new
                {
                    weekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    weekName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weeks", x => x.weekId);
                });

            migrationBuilder.CreateTable(
                name: "zals",
                columns: table => new
                {
                    ZalsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZalsName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zals", x => x.ZalsId);
                });

            migrationBuilder.CreateTable(
                name: "treners",
                columns: table => new
                {
                    TrenerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIOtrener = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressTrenerAdressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treners", x => x.TrenerId);
                    table.ForeignKey(
                        name: "FK_treners_adresses_AdressTrenerAdressId",
                        column: x => x.AdressTrenerAdressId,
                        principalTable: "adresses",
                        principalColumn: "AdressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "specialtiys",
                columns: table => new
                {
                    specialtiyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specialityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gruppa = table.Column<int>(type: "int", nullable: false),
                    ZalsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialtiys", x => x.specialtiyId);
                    table.ForeignKey(
                        name: "FK_specialtiys_zals_ZalsId",
                        column: x => x.ZalsId,
                        principalTable: "zals",
                        principalColumn: "ZalsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenerId = table.Column<int>(type: "int", nullable: false),
                    Mondeay = table.Column<bool>(type: "bit", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    Ftiday = table.Column<bool>(type: "bit", nullable: false),
                    Saturday = table.Column<bool>(type: "bit", nullable: false),
                    Sunday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_schedules_treners_TrenerId",
                        column: x => x.TrenerId,
                        principalTable: "treners",
                        principalColumn: "TrenerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trener_Clients",
                columns: table => new
                {
                    trener_ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TrenerId = table.Column<int>(type: "int", nullable: false),
                    weekId = table.Column<int>(type: "int", nullable: false),
                    TimeId = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trener_Clients", x => x.trener_ClientId);
                    table.ForeignKey(
                        name: "FK_trener_Clients_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trener_Clients_times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "times",
                        principalColumn: "TimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trener_Clients_treners_TrenerId",
                        column: x => x.TrenerId,
                        principalTable: "treners",
                        principalColumn: "TrenerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trener_Clients_weeks_weekId",
                        column: x => x.weekId,
                        principalTable: "weeks",
                        principalColumn: "weekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "specialyty_Treners",
                columns: table => new
                {
                    Specialyty_TrenerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specialtiyId = table.Column<int>(type: "int", nullable: false),
                    TrenerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialyty_Treners", x => x.Specialyty_TrenerId);
                    table.ForeignKey(
                        name: "FK_specialyty_Treners_specialtiys_specialtiyId",
                        column: x => x.specialtiyId,
                        principalTable: "specialtiys",
                        principalColumn: "specialtiyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_specialyty_Treners_treners_TrenerId",
                        column: x => x.TrenerId,
                        principalTable: "treners",
                        principalColumn: "TrenerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_schedules_TrenerId",
                table: "schedules",
                column: "TrenerId");

            migrationBuilder.CreateIndex(
                name: "IX_specialtiys_ZalsId",
                table: "specialtiys",
                column: "ZalsId");

            migrationBuilder.CreateIndex(
                name: "IX_specialyty_Treners_specialtiyId",
                table: "specialyty_Treners",
                column: "specialtiyId");

            migrationBuilder.CreateIndex(
                name: "IX_specialyty_Treners_TrenerId",
                table: "specialyty_Treners",
                column: "TrenerId");

            migrationBuilder.CreateIndex(
                name: "IX_trener_Clients_ClientId",
                table: "trener_Clients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_trener_Clients_TimeId",
                table: "trener_Clients",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_trener_Clients_TrenerId",
                table: "trener_Clients",
                column: "TrenerId");

            migrationBuilder.CreateIndex(
                name: "IX_trener_Clients_weekId",
                table: "trener_Clients",
                column: "weekId");

            migrationBuilder.CreateIndex(
                name: "IX_treners_AdressTrenerAdressId",
                table: "treners",
                column: "AdressTrenerAdressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "specialyty_Treners");

            migrationBuilder.DropTable(
                name: "trener_Clients");

            migrationBuilder.DropTable(
                name: "specialtiys");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "times");

            migrationBuilder.DropTable(
                name: "treners");

            migrationBuilder.DropTable(
                name: "weeks");

            migrationBuilder.DropTable(
                name: "zals");

            migrationBuilder.DropTable(
                name: "adresses");
        }
    }
}
