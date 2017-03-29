using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace MyMissionaryMail.Migrations
{
    public partial class newMyMissionaryMail5 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AddColumn(
                name: "MissionaryId",
                table: "Email",
                type: "int",
                nullable: true);
            migration.AddColumn(
                name: "UserId",
                table: "Email",
                type: "nvarchar(max)",
                nullable: true);
            migration.AddColumn(
                name: "DateOfBirth",
                table: "Missionary",
                type: "datetime2",
                nullable: false);
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropColumn(name: "MissionaryId", table: "Email");
            migration.DropColumn(name: "UserId", table: "Email");
            migration.DropColumn(name: "DateOfBirth", table: "Missionary");
        }
    }
}
