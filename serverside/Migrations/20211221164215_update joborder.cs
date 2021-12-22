using Microsoft.EntityFrameworkCore.Migrations;

namespace serverside.Migrations
{
    public partial class updatejoborder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentExpense",
                table: "Joborders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentExpense",
                table: "Joborders");
        }
    }
}
