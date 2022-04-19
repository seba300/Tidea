using Microsoft.EntityFrameworkCore.Migrations;

namespace Tidea.Infrastructure.Migrations
{
    public partial class RemoveProvisionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_PaymentProvisions_PaymentProvisionId",
                table: "Donations");

            migrationBuilder.DropTable(
                name: "PaymentProvisions");

            migrationBuilder.DropIndex(
                name: "IX_Donations_PaymentProvisionId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "PaymentProvisionId",
                table: "Donations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentProvisionId",
                table: "Donations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentProvisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FixedFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provision = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProvisions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_PaymentProvisionId",
                table: "Donations",
                column: "PaymentProvisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_PaymentProvisions_PaymentProvisionId",
                table: "Donations",
                column: "PaymentProvisionId",
                principalTable: "PaymentProvisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
