using Microsoft.EntityFrameworkCore.Migrations;

namespace Tidea.Infrastructure.Migrations
{
    public partial class ChangeMediaRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Campaigns_CampaignId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_CampaignId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Medias");

            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "Campaigns",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_MediaId",
                table: "Campaigns",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Medias_MediaId",
                table: "Campaigns",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Medias_MediaId",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_MediaId",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Campaigns");

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_CampaignId",
                table: "Medias",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Campaigns_CampaignId",
                table: "Medias",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
