using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AvaloniaPortfolioManager.Migrations
{
    /// <inheritdoc />
    public partial class SeedDemoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Country", "CreatedAt", "FullName" },
                values: new object[,]
                {
                    { 1, "Malta", new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria Borg" },
                    { 2, "Malta", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karl Vella" },
                    { 3, "Malta", new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Josef Camilleri" },
                    { 4, "Malta", new DateTime(2026, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claire Zammit" },
                    { 5, "Malta", new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matthew Micallef" },
                    { 6, "Malta", new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah Grech" },
                    { 7, "Malta", new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Attard" },
                    { 8, "Malta", new DateTime(2026, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elena Galea" }
                });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "PortfolioId", "ClientId", "Currency", "Name" },
                values: new object[,]
                {
                    { 1, 1, "EUR", "Growth" },
                    { 2, 1, "EUR", "Income" },
                    { 3, 2, "EUR", "Retirement" },
                    { 4, 3, "EUR", "Growth" },
                    { 5, 4, "USD", "Trading" },
                    { 6, 5, "EUR", "Savings" },
                    { 7, 7, "EUR", "Balanced" }
                });

            migrationBuilder.InsertData(
                table: "Holdings",
                columns: new[] { "HoldingId", "Instrument", "MarketValue", "PortfolioId", "Quantity" },
                values: new object[,]
                {
                    { 1, "AAPL", 12500m, 1, 50m },
                    { 2, "ETF-World", 9200m, 1, 100m },
                    { 3, "Bond-MGS", 17000m, 2, 17m },
                    { 4, "ETF-Global", 25300m, 3, 220m },
                    { 5, "Bond-MGS", 10000m, 3, 10m },
                    { 6, "MSFT", 13800m, 4, 30m },
                    { 7, "ETF-Europe", 6400m, 4, 80m },
                    { 8, "TSLA", 6100m, 5, 25m },
                    { 9, "NVDA", 14700m, 5, 12m },
                    { 10, "Bond-MGS", 5000m, 6, 5m },
                    { 11, "ETF-World", 5500m, 7, 60m },
                    { 12, "AAPL", 2500m, 7, 10m }
                });

            migrationBuilder.InsertData(
                table: "PortfolioTransactions",
                columns: new[] { "PortfolioTransactionId", "Amount", "Date", "PortfolioId", "Type" },
                values: new object[,]
                {
                    { 1, 9500m, new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "BUY" },
                    { 2, 1500m, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "SELL" },
                    { 3, 17000m, new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "BUY" },
                    { 4, 20000m, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "BUY" },
                    { 5, 5300m, new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "BUY" },
                    { 6, 14500m, new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "BUY" },
                    { 7, 8200m, new DateTime(2026, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "BUY" },
                    { 8, 2100m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "SELL" },
                    { 9, 5000m, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "BUY" },
                    { 10, 8000m, new DateTime(2026, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "BUY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Holdings",
                keyColumn: "HoldingId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PortfolioTransactions",
                keyColumn: "PortfolioTransactionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PortfolioTransactions",
                keyColumn: "PortfolioTransactionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PortfolioTransactions",
                keyColumn: "PortfolioTransactionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PortfolioTransactions",
                keyColumn: "PortfolioTransactionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PortfolioTransactions",
                keyColumn: "PortfolioTransactionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PortfolioTransactions",
                keyColumn: "PortfolioTransactionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PortfolioTransactions",
                keyColumn: "PortfolioTransactionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PortfolioTransactions",
                keyColumn: "PortfolioTransactionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PortfolioTransactions",
                keyColumn: "PortfolioTransactionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PortfolioTransactions",
                keyColumn: "PortfolioTransactionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "PortfolioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "PortfolioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "PortfolioId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "PortfolioId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "PortfolioId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "PortfolioId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "PortfolioId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 7);
        }
    }
}
