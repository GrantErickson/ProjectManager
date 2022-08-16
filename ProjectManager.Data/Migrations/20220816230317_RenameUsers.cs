using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Data.Migrations
{
    public partial class RenameUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_OrganizationUsers_OrganizationUserId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRoles_OrganizationUsers_OrganizationUserId",
                table: "ProjectRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_OrganizationUsers_LeadId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_OrganizationUsers_OrganizationUserId",
                table: "TimeEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_OrganizationUsers_OrganizationUserId",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationUsers_ApplicationUsers_AppUserId",
                table: "OrganizationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationUsers_Organizations_OrganizationId",
                table: "OrganizationUsers");

            // Replaced create table with renamed
            migrationBuilder.RenameTable(
                name: "OrganizationUsers", newName: "Users");

            migrationBuilder.RenameColumn(
                name: "OrganizationUserId",
                table: "UserSkills",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkills_OrganizationUserId",
                table: "UserSkills",
                newName: "IX_UserSkills_UserId");

            migrationBuilder.RenameColumn(
                name: "OrganizationUserId",
                table: "TimeEntries",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeEntries_OrganizationUserId",
                table: "TimeEntries",
                newName: "IX_TimeEntries_UserId");

            migrationBuilder.RenameColumn(
                name: "OrganizationUserId",
                table: "ProjectRoles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectRoles_OrganizationUserId",
                table: "ProjectRoles",
                newName: "IX_ProjectRoles_UserId");

            migrationBuilder.RenameColumn(
                name: "OrganizationUserId",
                table: "Assignments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_OrganizationUserId",
                table: "Assignments",
                newName: "IX_Assignments_UserId");

            migrationBuilder.RenameColumn(
                name: "OrganizationUserId",
                table: "Users",
                newName: "UserId");


            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        OrganizationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        DefaultRate = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        IsOrganizationAdmin = table.Column<bool>(type: "bit", nullable: false),
            //        EmploymentStatus = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.UserId);
            //        table.ForeignKey(
            //            name: "FK_Users_ApplicationUsers_AppUserId",
            //            column: x => x.AppUserId,
            //            principalTable: "ApplicationUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Users_Organizations_OrganizationId",
            //            column: x => x.OrganizationId,
            //            principalTable: "Organizations",
            //            principalColumn: "OrganizationId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            // Instead of recreating the table we are just adding back the foreign keys to the renamed table
            migrationBuilder.AddForeignKey(
                table: "Users",
                name: "FK_Users_ApplicationUsers_AppUserId",
                column: "AppUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                table: "Users",
                name: "FK_Users_Organizations_OrganizationId",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AppUserId",
                table: "Users",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Users_UserId",
                table: "Assignments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRoles_Users_UserId",
                table: "ProjectRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_LeadId",
                table: "Projects",
                column: "LeadId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_Users_UserId",
                table: "TimeEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Users_UserId",
                table: "UserSkills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Users_UserId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRoles_Users_UserId",
                table: "ProjectRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_LeadId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeEntries_Users_UserId",
                table: "TimeEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Users_UserId",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ApplicationUsers_AppUserId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            // Replaced create table with renamed
            migrationBuilder.RenameTable(
                name: "Users", newName: "OrganizationUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserSkills",
                newName: "OrganizationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkills_UserId",
                table: "UserSkills",
                newName: "IX_UserSkills_OrganizationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TimeEntries",
                newName: "OrganizationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeEntries_UserId",
                table: "TimeEntries",
                newName: "IX_TimeEntries_OrganizationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProjectRoles",
                newName: "OrganizationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectRoles_UserId",
                table: "ProjectRoles",
                newName: "IX_ProjectRoles_OrganizationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Assignments",
                newName: "OrganizationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments",
                newName: "IX_Assignments_OrganizationUserId");

            //migrationBuilder.CreateTable(
            //    name: "OrganizationUsers",
            //    columns: table => new
            //    {
            //        OrganizationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        OrganizationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        DefaultRate = table.Column<decimal>(type: "decimal(13,4)", nullable: false),
            //        EmploymentStatus = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        IsOrganizationAdmin = table.Column<bool>(type: "bit", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrganizationUsers", x => x.OrganizationUserId);
            //        table.ForeignKey(
            //            name: "FK_OrganizationUsers_ApplicationUsers_AppUserId",
            //            column: x => x.AppUserId,
            //            principalTable: "ApplicationUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrganizationUsers_Organizations_OrganizationId",
            //            column: x => x.OrganizationId,
            //            principalTable: "Organizations",
            //            principalColumn: "OrganizationId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            // Instead of adding the table, just add the FKs since it was renamed above instead
            migrationBuilder.AddForeignKey(
                table: "ApplicationUsers",
                name: "FK_OrganizationUsers_Organizations_OrganizationId",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                table: "ApplicationUsers",
                name: "FK_OrganizationUsers_ApplicationUsers_AppUserId",
                column: "AppUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUsers_AppUserId",
                table: "OrganizationUsers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUsers_OrganizationId",
                table: "OrganizationUsers",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_OrganizationUsers_OrganizationUserId",
                table: "Assignments",
                column: "OrganizationUserId",
                principalTable: "OrganizationUsers",
                principalColumn: "OrganizationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRoles_OrganizationUsers_OrganizationUserId",
                table: "ProjectRoles",
                column: "OrganizationUserId",
                principalTable: "OrganizationUsers",
                principalColumn: "OrganizationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_OrganizationUsers_LeadId",
                table: "Projects",
                column: "LeadId",
                principalTable: "OrganizationUsers",
                principalColumn: "OrganizationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeEntries_OrganizationUsers_OrganizationUserId",
                table: "TimeEntries",
                column: "OrganizationUserId",
                principalTable: "OrganizationUsers",
                principalColumn: "OrganizationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_OrganizationUsers_OrganizationUserId",
                table: "UserSkills",
                column: "OrganizationUserId",
                principalTable: "OrganizationUsers",
                principalColumn: "OrganizationUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
