using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tidea.Data.Migrations
{
    public partial class UpdatedCampaignEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Medias");

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Donations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountNeeded",
                table: "Campaigns",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CampaignIntroduction",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CampaignPurpose",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CategoryId",
                table: "Donations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CampaignId",
                table: "Category",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Category_CategoryId",
                table: "Donations",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Category_CategoryId",
                table: "Donations");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Donations_CategoryId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "AmountNeeded",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CampaignIntroduction",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CampaignPurpose",
                table: "Campaigns");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Medias",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");
        }
    }
}
