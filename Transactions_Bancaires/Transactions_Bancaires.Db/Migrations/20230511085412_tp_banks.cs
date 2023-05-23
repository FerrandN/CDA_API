using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transactions_Bancaires.Db.Migrations
{
    /// <inheritdoc />
    public partial class tp_banks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    transaction_from = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    transaction_to = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    transaction_amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.transaction_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
