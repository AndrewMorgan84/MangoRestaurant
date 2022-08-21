using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Services.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Mains", "Juicy Steak and Chunky Chips", "https://andrewmmango.blob.core.windows.net/mango/Steak.jpg", "Steak", 24.0 },
                    { 2, "Mains", "Bacon Double Cheese Burger Served with Fries or Chunky Chips", "https://andrewmmango.blob.core.windows.net/mango/BaconCheeseBurger.jpg", "Double Bacon Cheese Burger", 14.0 },
                    { 3, "Mains", "Taste of Italy", "https://andrewmmango.blob.core.windows.net/mango/lasagne.jpg", "Lasagne", 12.0 },
                    { 4, "Mains", "Traditional favourite", "https://andrewmmango.blob.core.windows.net/mango/CodChips.jpg", "Beer Battered Cod & Chips", 14.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
