using Microsoft.EntityFrameworkCore.Migrations;

namespace serverside.Migrations
{
    public partial class remodeltrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joborders_Users_KoordinatorId",
                table: "Joborders");

            migrationBuilder.DropIndex(
                name: "IX_Joborders_KoordinatorId",
                table: "Joborders");

            migrationBuilder.DropColumn(
                name: "KoordinatorId",
                table: "Joborders");

            migrationBuilder.AddColumn<int>(
                name: "IdJoborder",
                table: "JobTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Nominal",
                table: "JobTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobTracks_IdJoborder",
                table: "JobTracks",
                column: "IdJoborder");

            migrationBuilder.CreateIndex(
                name: "IX_Joborders_IdKoordinator",
                table: "Joborders",
                column: "IdKoordinator");

            migrationBuilder.AddForeignKey(
                name: "FK_Joborders_Users_IdKoordinator",
                table: "Joborders",
                column: "IdKoordinator",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTracks_Joborders_IdJoborder",
                table: "JobTracks",
                column: "IdJoborder",
                principalTable: "Joborders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joborders_Users_IdKoordinator",
                table: "Joborders");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTracks_Joborders_IdJoborder",
                table: "JobTracks");

            migrationBuilder.DropIndex(
                name: "IX_JobTracks_IdJoborder",
                table: "JobTracks");

            migrationBuilder.DropIndex(
                name: "IX_Joborders_IdKoordinator",
                table: "Joborders");

            migrationBuilder.DropColumn(
                name: "IdJoborder",
                table: "JobTracks");

            migrationBuilder.DropColumn(
                name: "Nominal",
                table: "JobTracks");

            migrationBuilder.AddColumn<int>(
                name: "KoordinatorId",
                table: "Joborders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Joborders_KoordinatorId",
                table: "Joborders",
                column: "KoordinatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Joborders_Users_KoordinatorId",
                table: "Joborders",
                column: "KoordinatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
