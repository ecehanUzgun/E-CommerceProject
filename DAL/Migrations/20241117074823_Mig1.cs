using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MasterID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippedAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MasterID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitsInStock = table.Column<short>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MasterID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MasterID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "CreatedComputerName", "CreatedDate", "CreatedIpAddress", "Description", "MasterID", "Status", "UpdatedComputerName", "UpdatedDate", "UpdatedIpAddress" },
                values: new object[,]
                {
                    { 1, "Grocery", "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 33, DateTimeKind.Local).AddTicks(9015), "192.168.1.1", "maxime", "51a07c82-1546-4f8b-bd79-65d3cd5480d3", 0, null, null, null },
                    { 2, "Games", "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 33, DateTimeKind.Local).AddTicks(9226), "192.168.1.1", "ea", "a51c7d0f-4967-448e-9945-1ab35155d557", 0, null, null, null },
                    { 3, "Industrial", "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 33, DateTimeKind.Local).AddTicks(9330), "192.168.1.1", "voluptatem", "01190453-454e-46df-9fdb-6024faa722fe", 0, null, null, null },
                    { 4, "Music", "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 33, DateTimeKind.Local).AddTicks(9346), "192.168.1.1", "ipsa", "dcc2dfb9-5123-4c77-9e04-553af55b1e9e", 0, null, null, null },
                    { 5, "Clothing", "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 33, DateTimeKind.Local).AddTicks(9360), "192.168.1.1", "quod", "9808b07f-048b-4bb6-8c7d-4252b9c4c910", 0, null, null, null },
                    { 6, "Baby", "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 33, DateTimeKind.Local).AddTicks(9379), "192.168.1.1", "sit", "b6f16c68-d509-4d0e-93b4-2383f70b73be", 0, null, null, null },
                    { 7, "Electronics", "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 33, DateTimeKind.Local).AddTicks(9396), "192.168.1.1", "perspiciatis", "7f8b97c2-8cbb-4e5c-8d2a-777fbebe1871", 0, null, null, null },
                    { 8, "Computers", "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 33, DateTimeKind.Local).AddTicks(9420), "192.168.1.1", "et", "3f1a8db9-f307-4df7-8091-c31d76a5e1fa", 0, null, null, null },
                    { 9, "Kids", "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 33, DateTimeKind.Local).AddTicks(9448), "192.168.1.1", "ratione", "5b4f3927-d486-472c-aad5-eeede26655a3", 0, null, null, null },
                    { 10, "Garden", "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 33, DateTimeKind.Local).AddTicks(9503), "192.168.1.1", "recusandae", "0efc8ff6-56e9-49ee-8843-5b99558f012b", 0, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryId", "CreatedComputerName", "CreatedDate", "CreatedIpAddress", "Description", "ImageURL", "MasterID", "ProductName", "Status", "UnitPrice", "UnitsInStock", "UpdatedComputerName", "UpdatedDate", "UpdatedIpAddress" },
                values: new object[,]
                {
                    { 1, 1, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6253), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "adbf21b4-0e2c-4225-8904-3c3773c55b0b", "Gloves", 0, 87.96m, (short)10, null, null, null },
                    { 2, 1, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6489), "192.168.1.1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "609df859-342e-4ceb-903f-0b1a85630be8", "Fish", 0, 122.72m, (short)62, null, null, null },
                    { 3, 1, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6506), "192.168.1.1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "3e4944ba-7256-42ee-b7de-0e8daae61108", "Towels", 0, 336.60m, (short)10, null, null, null },
                    { 4, 1, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6521), "192.168.1.1", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "20f9970f-e587-4a73-89e5-d0841620a519", "Salad", 0, 564.12m, (short)97, null, null, null },
                    { 5, 1, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6578), "192.168.1.1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "37c922ce-19b2-42b6-ad27-7af428dca8d8", "Bacon", 0, 885.47m, (short)31, null, null, null },
                    { 6, 1, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6592), "192.168.1.1", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "8e23ba7e-7fb9-45db-9b22-0dc487a4e31d", "Pizza", 0, 667.13m, (short)10, null, null, null },
                    { 7, 1, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6622), "192.168.1.1", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "6c1f6669-cb20-4eff-a197-fa2cce37a956", "Hat", 0, 482.53m, (short)10, null, null, null },
                    { 8, 1, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6635), "192.168.1.1", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "02ed880e-67e0-4ba0-8bc1-c8192692f8e0", "Mouse", 0, 769.05m, (short)58, null, null, null },
                    { 9, 1, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6647), "192.168.1.1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "8b8c9764-99be-45a6-9e3c-de14f874aaa6", "Towels", 0, 947.01m, (short)44, null, null, null },
                    { 10, 1, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6660), "192.168.1.1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "a9f7b84f-cf5f-42a4-a081-69e2b9a0a7c1", "Towels", 0, 138.38m, (short)91, null, null, null },
                    { 11, 2, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6672), "192.168.1.1", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "56a66af8-ed90-4851-af8e-de347b4f2f04", "Pants", 0, 925.78m, (short)78, null, null, null },
                    { 12, 2, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6724), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "5a523550-c2cb-45c5-be1c-1b60e8cdc916", "Salad", 0, 358.08m, (short)31, null, null, null },
                    { 13, 2, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6797), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "ebf13f64-cd75-43b4-9223-a1f4631507bd", "Hat", 0, 510.02m, (short)53, null, null, null },
                    { 14, 2, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6810), "192.168.1.1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "b0e7b01d-1a73-418e-bb7b-5d7ea1aee212", "Chips", 0, 717.60m, (short)69, null, null, null },
                    { 15, 2, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6824), "192.168.1.1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "a8a58c8a-7304-45bd-8895-73498347a164", "Chips", 0, 221.22m, (short)1, null, null, null },
                    { 16, 2, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6835), "192.168.1.1", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "bf1fc5df-9749-431e-a07d-227b5440b19f", "Sausages", 0, 60.07m, (short)10, null, null, null },
                    { 17, 2, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6847), "192.168.1.1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "1926f316-1396-47c2-8628-8249969436b6", "Tuna", 0, 583.19m, (short)95, null, null, null },
                    { 18, 2, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6859), "192.168.1.1", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "06d0eaa7-e045-43a5-8f62-a0c2d5963fbc", "Salad", 0, 20.93m, (short)50, null, null, null },
                    { 19, 2, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6905), "192.168.1.1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "d0d43ae1-47de-4b28-a9d3-fbd13a26c068", "Ball", 0, 741.79m, (short)100, null, null, null },
                    { 20, 2, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6918), "192.168.1.1", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "1504a19c-b42b-4a6f-af2e-82b36711ea23", "Pants", 0, 65.93m, (short)77, null, null, null },
                    { 21, 3, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6930), "192.168.1.1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "dbe047a4-850c-47b8-a31f-7fac2d01a094", "Computer", 0, 271.83m, (short)58, null, null, null },
                    { 22, 3, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6944), "192.168.1.1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "a29d675f-e3ff-4b4b-be50-8a86208d8513", "Sausages", 0, 436.23m, (short)96, null, null, null },
                    { 23, 3, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6957), "192.168.1.1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "9d5fb68c-c7ef-4706-97d2-0242204d6602", "Table", 0, 366.08m, (short)77, null, null, null },
                    { 24, 3, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6968), "192.168.1.1", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "ee043e90-7aba-4a7b-b567-9e1b9d36c720", "Tuna", 0, 26.45m, (short)79, null, null, null },
                    { 25, 3, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(6979), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "845cbd29-fa83-4eb3-9727-b35687923071", "Ball", 0, 500.68m, (short)34, null, null, null },
                    { 26, 3, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7029), "192.168.1.1", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "bc8983f5-c22f-4f2f-9f4a-02f3dc39db7c", "Hat", 0, 190.54m, (short)93, null, null, null },
                    { 27, 3, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7041), "192.168.1.1", "The Football Is Good For Training And Recreational Purposes", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "73bfa244-abd8-4d04-9567-81cf04c3d5b1", "Soap", 0, 773.24m, (short)68, null, null, null },
                    { 28, 3, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7053), "192.168.1.1", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "f13842bf-ec76-4602-96ba-069069bb5f70", "Salad", 0, 472.74m, (short)31, null, null, null },
                    { 29, 3, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7064), "192.168.1.1", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "3265a670-4b36-49f8-b861-582706064aa9", "Sausages", 0, 424.19m, (short)100, null, null, null },
                    { 30, 3, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7075), "192.168.1.1", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "e082bee4-a2a1-4edb-be9c-46e3843ceef1", "Pizza", 0, 542.29m, (short)78, null, null, null },
                    { 31, 4, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7088), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "0bc2f88b-5839-4359-b4b4-9258f5526745", "Cheese", 0, 622.05m, (short)10, null, null, null },
                    { 32, 4, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7101), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "31f6e7b9-e685-46f9-a0fa-b699a8b094a6", "Car", 0, 940.12m, (short)44, null, null, null },
                    { 33, 4, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7148), "192.168.1.1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "57d862b2-bc7f-4ad3-82b2-6f86fa88dcc8", "Chips", 0, 420.68m, (short)48, null, null, null },
                    { 34, 4, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7162), "192.168.1.1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "2fa86bcf-daa2-42e9-87fb-700eb39476c9", "Ball", 0, 536.76m, (short)96, null, null, null },
                    { 35, 4, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7173), "192.168.1.1", "The Football Is Good For Training And Recreational Purposes", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "847fd646-4f91-462b-98c8-38630382d414", "Ball", 0, 629.18m, (short)39, null, null, null },
                    { 36, 4, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7184), "192.168.1.1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "d7852a5c-b527-426b-899e-881fe964c1f3", "Mouse", 0, 694.27m, (short)84, null, null, null },
                    { 37, 4, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7196), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "1b741087-2584-42f1-bf50-2c65a2815ed4", "Towels", 0, 942.83m, (short)59, null, null, null },
                    { 38, 4, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7206), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "ce60f994-fe2b-4db1-8d27-7e9f719ca195", "Pants", 0, 294.02m, (short)36, null, null, null },
                    { 39, 4, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7219), "192.168.1.1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "d3e49ea6-f2ae-4dc6-8136-59adbecd719b", "Sausages", 0, 514.16m, (short)82, null, null, null },
                    { 40, 4, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7266), "192.168.1.1", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "07b9efe4-4456-4df1-81d0-c4858df691cb", "Chips", 0, 632.33m, (short)64, null, null, null },
                    { 41, 5, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7278), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "3a74de42-a4cc-45e5-acdb-eec9c797011a", "Shoes", 0, 850.64m, (short)100, null, null, null },
                    { 42, 5, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7291), "192.168.1.1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "2448a252-2322-4181-ab31-2c077cd84a97", "Chair", 0, 963.55m, (short)69, null, null, null },
                    { 43, 5, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7303), "192.168.1.1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "ff076faa-7b60-4ce0-baeb-1cc7728fdbd7", "Soap", 0, 845.29m, (short)6, null, null, null },
                    { 44, 5, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7314), "192.168.1.1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "f76496b2-d8f9-4e14-98c5-c6f8c2ca622a", "Ball", 0, 920.47m, (short)18, null, null, null },
                    { 45, 5, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7326), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "0e8f1fbc-65c9-40eb-8254-afe32440586a", "Chicken", 0, 111.33m, (short)92, null, null, null },
                    { 46, 5, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7337), "192.168.1.1", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "02a9d4b0-61c3-4441-8b9f-14702ecb8ed9", "Chicken", 0, 755.20m, (short)64, null, null, null },
                    { 47, 5, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7350), "192.168.1.1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "873eef14-ae7b-450d-810f-4130d843bbc2", "Keyboard", 0, 828.31m, (short)53, null, null, null },
                    { 48, 5, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7415), "192.168.1.1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "43abe8aa-8d2b-4d94-8b74-fcf7f628edb3", "Chair", 0, 315.91m, (short)13, null, null, null },
                    { 49, 5, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7426), "192.168.1.1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "58006dd5-7782-4bad-8613-e5744d8b6744", "Pizza", 0, 628.14m, (short)24, null, null, null },
                    { 50, 5, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7437), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "46177412-de02-4d3e-a64b-58c6788e7f5b", "Ball", 0, 586.20m, (short)91, null, null, null },
                    { 51, 6, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7448), "192.168.1.1", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "aad094c5-985e-4adb-945e-cc83d7456fa2", "Salad", 0, 159.98m, (short)71, null, null, null },
                    { 52, 6, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7459), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "c45a4c73-6a00-4b66-911f-37c95c42a875", "Mouse", 0, 103.48m, (short)94, null, null, null },
                    { 53, 6, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7471), "192.168.1.1", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "07f5bd55-52e4-4d3d-ac06-00492ad8cb01", "Shoes", 0, 50.51m, (short)42, null, null, null },
                    { 54, 6, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7482), "192.168.1.1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "3c457164-ae2e-4341-9c50-72b9f7c650b2", "Gloves", 0, 135.48m, (short)33, null, null, null },
                    { 55, 6, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7535), "192.168.1.1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "dda2dfdb-ab91-400d-abff-939a47dec4d0", "Pants", 0, 325.05m, (short)81, null, null, null },
                    { 56, 6, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7547), "192.168.1.1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "f9736b0c-e3dd-4b37-9d5d-45994d3bcfba", "Shoes", 0, 687.46m, (short)7, null, null, null },
                    { 57, 6, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7559), "192.168.1.1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "05d10a29-aaf6-48d9-85d9-f7c422b08443", "Cheese", 0, 473.60m, (short)30, null, null, null },
                    { 58, 6, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7570), "192.168.1.1", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "4d87699d-f4d5-419d-86c8-24a40df84e74", "Fish", 0, 169.52m, (short)74, null, null, null },
                    { 59, 6, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7580), "192.168.1.1", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "a9f897e0-a621-47b2-9216-7726f8766276", "Pants", 0, 363.71m, (short)66, null, null, null },
                    { 60, 6, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7592), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "2263482b-97f3-4d61-b9a6-eeb54c58ba4c", "Salad", 0, 610.32m, (short)63, null, null, null },
                    { 61, 7, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7603), "192.168.1.1", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "ea3d7e80-4d0d-401c-9838-910c1e058489", "Pants", 0, 803.18m, (short)31, null, null, null },
                    { 62, 7, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7659), "192.168.1.1", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "8a620c65-ee1d-4eec-b83a-68ad4aa1f824", "Chicken", 0, 57.74m, (short)15, null, null, null },
                    { 63, 7, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7673), "192.168.1.1", "The Football Is Good For Training And Recreational Purposes", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "e740b9d8-f25d-4003-a015-23fe6d20d7e8", "Soap", 0, 637.61m, (short)75, null, null, null },
                    { 64, 7, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7685), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "506dd130-0328-4eea-af8c-9684f14a8c12", "Bike", 0, 285.82m, (short)34, null, null, null },
                    { 65, 7, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7696), "192.168.1.1", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "50c1d376-0d4c-4d23-9453-5b9978883096", "Gloves", 0, 804.34m, (short)89, null, null, null },
                    { 66, 7, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7709), "192.168.1.1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "1fc18fff-f029-4bc4-8502-eef9177b4a4a", "Table", 0, 691.69m, (short)89, null, null, null },
                    { 67, 7, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7720), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "0c03b3db-04ce-4e37-b833-a828079b64d7", "Towels", 0, 489.41m, (short)96, null, null, null },
                    { 68, 7, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7731), "192.168.1.1", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "70db8003-dbec-40f6-addf-1f7459b6ff6d", "Sausages", 0, 250.75m, (short)24, null, null, null },
                    { 69, 7, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7784), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "5a6ddffd-9c6f-40b4-ae39-b80cde3449b8", "Fish", 0, 445.43m, (short)12, null, null, null },
                    { 70, 7, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7794), "192.168.1.1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "e361eed0-9d9b-4a93-883e-bf5ca5750135", "Bike", 0, 803.19m, (short)43, null, null, null },
                    { 71, 8, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7807), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "bddb8f7f-43bd-4643-adc2-ddc826fc1360", "Shoes", 0, 251.55m, (short)71, null, null, null },
                    { 72, 8, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7818), "192.168.1.1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "b5e48868-001b-4036-92da-bcc5868b8216", "Cheese", 0, 294.40m, (short)38, null, null, null },
                    { 73, 8, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7829), "192.168.1.1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "6387a964-5633-4742-8ac3-c5a9652d4136", "Salad", 0, 908.58m, (short)12, null, null, null },
                    { 74, 8, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7840), "192.168.1.1", "The Football Is Good For Training And Recreational Purposes", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "b3aa1c99-0347-4ccf-8dff-8db6ad0431ff", "Ball", 0, 644.31m, (short)88, null, null, null },
                    { 75, 8, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7851), "192.168.1.1", "The Football Is Good For Training And Recreational Purposes", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "c7d938c8-b1d7-45ed-a94c-7b9c7042f1a4", "Chips", 0, 881.05m, (short)25, null, null, null },
                    { 76, 8, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7900), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "2718485e-ed1d-48c4-9cbd-9aee05c2e8d3", "Shirt", 0, 460.47m, (short)40, null, null, null },
                    { 77, 8, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7911), "192.168.1.1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "04770e77-3b39-4524-aa9d-5ce06032caf5", "Tuna", 0, 361.19m, (short)23, null, null, null },
                    { 78, 8, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7922), "192.168.1.1", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "eccedc27-6db3-4acf-9088-195da726d89b", "Keyboard", 0, 481.24m, (short)46, null, null, null },
                    { 79, 8, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7935), "192.168.1.1", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "1c66c2c7-b20c-444d-bc68-d5f37a07a733", "Computer", 0, 406.42m, (short)41, null, null, null },
                    { 80, 8, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7946), "192.168.1.1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "013bb85f-0c62-480c-b0bd-a83bfeb7dfd2", "Chips", 0, 820.43m, (short)34, null, null, null },
                    { 81, 9, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7958), "192.168.1.1", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "5ed551be-285f-4f13-bd30-2452bc4fd6ea", "Bacon", 0, 336.39m, (short)95, null, null, null },
                    { 82, 9, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7969), "192.168.1.1", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "738b334c-e709-44e2-9c1b-be1fed1da235", "Cheese", 0, 545.59m, (short)64, null, null, null },
                    { 83, 9, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(7980), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "a897945e-5d7f-423f-8b5c-f3d0e0ac445e", "Towels", 0, 909.92m, (short)38, null, null, null },
                    { 84, 9, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8032), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "a4bb0935-2b94-495d-914d-8325979fbdf4", "Shoes", 0, 293.44m, (short)29, null, null, null },
                    { 85, 9, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8043), "192.168.1.1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "5b63bad3-e9e3-476a-bab9-093b8664651e", "Sausages", 0, 753.62m, (short)25, null, null, null },
                    { 86, 9, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8054), "192.168.1.1", "The Football Is Good For Training And Recreational Purposes", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "9ab3ff92-617a-461f-a350-22f661757c49", "Chair", 0, 448.74m, (short)37, null, null, null },
                    { 87, 9, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8067), "192.168.1.1", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "680a479d-cf49-4a40-8616-356eec67a29a", "Table", 0, 800.66m, (short)63, null, null, null },
                    { 88, 9, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8078), "192.168.1.1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "d41b6bc7-cf54-470e-b5ee-76c0e72edc77", "Soap", 0, 759.54m, (short)37, null, null, null },
                    { 89, 9, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8089), "192.168.1.1", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "05dd9231-3520-48f3-aaf2-b5de00502d28", "Shoes", 0, 971.55m, (short)68, null, null, null },
                    { 90, 9, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8100), "192.168.1.1", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "b780d69d-2dbc-4be8-b367-83fe0b71dc3a", "Chicken", 0, 225.09m, (short)100, null, null, null },
                    { 91, 10, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8150), "192.168.1.1", "The Football Is Good For Training And Recreational Purposes", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "1766287c-c519-4554-8e0b-0c30f84556d3", "Shoes", 0, 528.04m, (short)90, null, null, null },
                    { 92, 10, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8162), "192.168.1.1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "45ef7364-d0cf-43e6-a56f-f6577f103766", "Shirt", 0, 187.61m, (short)48, null, null, null },
                    { 93, 10, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8172), "192.168.1.1", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "5e9246a4-26c4-48ed-a44f-b10019db3a05", "Chicken", 0, 421.81m, (short)29, null, null, null },
                    { 94, 10, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8183), "192.168.1.1", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "5072717d-db51-4437-a3e7-d1fa508e13e0", "Salad", 0, 564.59m, (short)91, null, null, null },
                    { 95, 10, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8196), "192.168.1.1", "The Football Is Good For Training And Recreational Purposes", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "4273391e-f9ae-4a11-a03e-75cea88cb02f", "Ball", 0, 139.93m, (short)85, null, null, null },
                    { 96, 10, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8207), "192.168.1.1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "8d41ff73-0dc3-4a3b-98db-d40f189246b9", "Shirt", 0, 817.73m, (short)28, null, null, null },
                    { 97, 10, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8218), "192.168.1.1", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "7d48dd38-b7c0-451e-9b9b-e7dda09eddc6", "Ball", 0, 247.21m, (short)25, null, null, null },
                    { 98, 10, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8276), "192.168.1.1", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "87c9f3c9-476a-4fae-9bd1-a1f0431cd7de", "Fish", 0, 668.61m, (short)61, null, null, null },
                    { 99, 10, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8288), "192.168.1.1", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "81cd33fe-04e3-4775-b724-56325d61fddd", "Towels", 0, 370.63m, (short)56, null, null, null },
                    { 100, 10, "WX01", new DateTime(2024, 11, 17, 10, 48, 23, 35, DateTimeKind.Local).AddTicks(8299), "192.168.1.1", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "https://via.placeholder.com/500x500/cccccc/9c9c9c.png", "26db961c-60f6-4c08-9804-bcc103c9b310", "Car", 0, 461.23m, (short)78, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
