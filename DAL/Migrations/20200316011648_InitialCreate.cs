using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "RentalItems",
                columns: table => new
                {
                    RentalItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 128, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    RentalItemType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalItems", x => x.RentalItemId);
                });

            migrationBuilder.CreateTable(
                name: "CustomersRentalItems",
                columns: table => new
                {
                    CustomerRentalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalItemId = table.Column<int>(nullable: false),
                    Discount = table.Column<short>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersRentalItems", x => x.CustomerRentalId);
                    table.ForeignKey(
                        name: "FK_CustomersRentalItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersRentalItems_RentalItems_RentalItemId",
                        column: x => x.RentalItemId,
                        principalTable: "RentalItems",
                        principalColumn: "RentalItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerType", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Josef", "Gabrielsson" },
                    { 2, 0, "Kalle", "Anka" },
                    { 3, 0, "Bill", "Gates" }
                });

            migrationBuilder.InsertData(
                table: "RentalItems",
                columns: new[] { "RentalItemId", "ImageUrl", "Price", "RentalItemType", "Title" },
                values: new object[,]
                {
                    { 1, "https://m.media-amazon.com/images/M/MV5BNzQzMzJhZTEtOWM4NS00MTdhLTg0YjgtMjM4MDRkZjUwZDBlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg", 30m, 0, "Blade Runner" },
                    { 2, "https://m.media-amazon.com/images/M/MV5BMmQ2MmU3NzktZjAxOC00ZDZhLTk4YzEtMDMyMzcxY2IwMDAyXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg", 30m, 0, "Alien" },
                    { 3, "https://m.media-amazon.com/images/M/MV5BYTViNzMxZjEtZGEwNy00MDNiLWIzNGQtZDY2MjQ1OWViZjFmXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg", 30m, 0, "The Terminator" },
                    { 4, "https://m.media-amazon.com/images/M/MV5BMTg5NTA3NTg4NF5BMl5BanBnXkFtZTcwNTA0NDYzOA@@._V1_UX182_CR0,0,182,268_AL_.jpg", 30m, 0, "Looper" },
                    { 5, "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_UX182_CR0,0,182,268_AL_.jpg", 30m, 0, "Titanic" },
                    { 6, "https://m.media-amazon.com/images/M/MV5BMDljNTQ5ODItZmQwMy00M2ExLTljOTQtZTVjNGE2NTg0NGIxXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_UX182_CR0,0,182,268_AL_.jpg", 90m, 1, "Star Wars: The Rise of Skywalker" },
                    { 7, "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_UX182_CR0,0,182,268_AL_.jpg", 50m, 1, "Avatar" },
                    { 8, "https://m.media-amazon.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_UX182_CR0,0,182,268_AL_.jpg", 80m, 1, "Avengers: End Game" }
                });

            migrationBuilder.InsertData(
                table: "CustomersRentalItems",
                columns: new[] { "CustomerRentalId", "CustomerId", "Discount", "RentalItemId" },
                values: new object[,]
                {
                    { 7, 2, (short)0, 1 },
                    { 5, 1, (short)10, 2 },
                    { 3, 1, (short)10, 3 },
                    { 4, 1, (short)10, 4 },
                    { 8, 2, (short)0, 5 },
                    { 6, 2, (short)0, 6 },
                    { 1, 1, (short)15, 7 },
                    { 2, 1, (short)15, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersRentalItems_CustomerId",
                table: "CustomersRentalItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersRentalItems_RentalItemId",
                table: "CustomersRentalItems",
                column: "RentalItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalItems_RentalItemId",
                table: "RentalItems",
                column: "RentalItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersRentalItems");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RentalItems");
        }
    }
}
