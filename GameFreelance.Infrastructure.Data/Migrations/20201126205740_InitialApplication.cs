using Microsoft.EntityFrameworkCore.Migrations;

namespace GameFreelance.Infrastructure.Data.Migrations
{
    public partial class InitialApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    ExperienceText = table.Column<string>(nullable: true),
                    Attainment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_Id",
                table: "Resumes",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resumes");
        }
    }
}
