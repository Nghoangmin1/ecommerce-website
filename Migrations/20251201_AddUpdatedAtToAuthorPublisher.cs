using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fahasa.Migrations
{
    public partial class AddUpdatedAtToAuthorPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()"
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Publishers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Authors"
            );

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Publishers"
            );
        }
    }
}