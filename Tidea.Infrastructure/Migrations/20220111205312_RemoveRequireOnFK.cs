using Microsoft.EntityFrameworkCore.Migrations;

namespace Tidea.Data.Migrations
{
    public partial class RemoveRequireOnFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Campaigns_CampaignId",
                table: "Medias");

            migrationBuilder.AlterColumn<int>(
                name: "CampaignId",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Campaigns_CampaignId",
                table: "Medias",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Campaigns_CampaignId",
                table: "Medias");

            migrationBuilder.AlterColumn<int>(
                name: "CampaignId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Campaigns_CampaignId",
                table: "Medias",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
