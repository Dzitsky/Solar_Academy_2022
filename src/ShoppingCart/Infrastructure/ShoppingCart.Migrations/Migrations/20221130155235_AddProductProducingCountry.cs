using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShoppingCart.Migrations.Migrations
{
    public partial class AddProductProducingCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProducingCountryId",
                table: "Products",
                type: "uuid",
                nullable: true);
            
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducingCountryId",
                table: "Products",
                column: "ProducingCountryId");
            
            migrationBuilder.AddForeignKey(
                name: "FK_Products_Countries_ProducingCountryId",
                table: "Products",
                column: "ProducingCountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Countries_ProducingCountryId",
                table: "Products");
            
            migrationBuilder.DropTable(
                name: "Countries");
            
            migrationBuilder.DropIndex(
                name: "IX_Products_ProducingCountryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProducingCountryId",
                table: "Products");
        }
    }
}
