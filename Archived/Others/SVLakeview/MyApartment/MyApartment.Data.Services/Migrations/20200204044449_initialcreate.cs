using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApartment.Data.Services.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<Guid>(nullable: false),
                    ExpenseDescription = table.Column<string>(maxLength: 1000, nullable: false),
                    ExpenseAmount = table.Column<double>(nullable: false),
                    ExpenseType = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Payee = table.Column<string>(nullable: false),
                    Payer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
