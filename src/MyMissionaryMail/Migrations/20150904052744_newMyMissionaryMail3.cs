using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace MyMissionaryMail.Migrations
{
    public partial class newMyMissionaryMail3 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.DropPrimaryKey(name: "PK_Email", table: "Email");
            migration.CreateTable(
                name: "Missionary",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Email = table.Column(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missionary", x => x.Id);
                });
            migration.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    EndDate = table.Column(type: "datetime2", nullable: false),
                    MissionName = table.Column(type: "nvarchar(max)", nullable: true),
                    MissionaryId = table.Column(type: "int", nullable: false),
                    StartDate = table.Column(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mission_Missionary_MissionaryId",
                        columns: x => x.MissionaryId,
                        referencedTable: "Missionary",
                        referencedColumn: "Id");
                });
            migration.AddColumn(
                name: "MissionaryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_ApplicationUser_Missionary_MissionaryId",
                table: "AspNetUsers",
                column: "MissionaryId",
                referencedTable: "Missionary",
                referencedColumn: "Id");
            migration.AddColumn(
                name: "MissionId",
                table: "Email",
                type: "int",
                nullable: true);
            migration.AddPrimaryKey(
                name: "PK_Email",
                table: "Email",
                column: "Id");
            migration.AddForeignKey(
                name: "FK_Email_Mission_MissionId",
                table: "Email",
                column: "MissionId",
                referencedTable: "Mission",
                referencedColumn: "Id");
            migration.RenameColumn(
                name: "id",
                table: "Email",
                newName: "Id");
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_ApplicationUser_Missionary_MissionaryId", table: "AspNetUsers");
            migration.DropPrimaryKey(name: "PK_Email", table: "Email");
            migration.DropForeignKey(name: "FK_Email_Mission_MissionId", table: "Email");
            migration.DropColumn(name: "MissionaryId", table: "AspNetUsers");
            migration.DropColumn(name: "MissionId", table: "Email");
            migration.DropTable("Mission");
            migration.DropTable("Missionary");
            migration.AddPrimaryKey(
                name: "PK_Email",
                table: "Email",
                column: "id");
            migration.RenameColumn(
                name: "Id",
                table: "Email",
                newName: "id");
        }
    }
}
