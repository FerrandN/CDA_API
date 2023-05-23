using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transactions_Bancaires.Db.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "BankTransaction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankTransaction",
                table: "BankTransaction",
                column: "transaction_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BankTransaction",
                table: "BankTransaction");

            migrationBuilder.RenameTable(
                name: "BankTransaction",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "transaction_id");
        }
    }
}
