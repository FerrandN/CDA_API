using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankTransactions.Database.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Transaction_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transaction_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Transaction_From = table.Column<long>(type: "bigint", nullable: false),
                    Transaction_To = table.Column<long>(type: "bigint", nullable: false),
                    Transaction_Amount = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Transaction_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
