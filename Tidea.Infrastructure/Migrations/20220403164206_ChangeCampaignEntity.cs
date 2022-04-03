using Microsoft.EntityFrameworkCore.Migrations;

namespace Tidea.Infrastructure.Migrations
{
    public partial class ChangeCampaignEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AvailableAmountCollected",
                table: "Campaigns",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableAmountCollected",
                table: "Campaigns");
        }
    }
}
