using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Data.Migrations
{
    public partial class ProjectLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeadId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LeadId",
                table: "Projects",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_OrganizationUsers_LeadId",
                table: "Projects",
                column: "LeadId",
                principalTable: "OrganizationUsers",
                principalColumn: "OrganizationUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_OrganizationUsers_LeadId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_LeadId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Projects");
        }
    }
}
