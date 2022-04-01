using Microsoft.EntityFrameworkCore.Migrations;

namespace Tidea.Infrastructure.Migrations
{
    public partial class ChangeDonationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donations",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Donations");

            migrationBuilder.AlterColumn<string>(
                name: "DonorEmail",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DonationId",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donations",
                table: "Donations",
                column: "DonationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donations",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "DonationId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Donations");

            migrationBuilder.AlterColumn<string>(
                name: "DonorEmail",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donations",
                table: "Donations",
                column: "Id");
        }
    }
}
