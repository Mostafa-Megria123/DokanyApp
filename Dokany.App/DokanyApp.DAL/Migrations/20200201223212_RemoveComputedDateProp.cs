using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DokanyApp.DAL.Migrations
{
    public partial class RemoveComputedDateProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInfo",
                columns: table => new
                {
                    ShippingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShippingType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ShippingCost = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingInfo", x => x.ShippingId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 101, nullable: false, computedColumnSql: "(([FirstName]+' ')+[LastName])"),
                    UserType = table.Column<string>(maxLength: 50, nullable: false),
                    UserStatus = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    BrandName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(unicode: false, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    ImageUrl = table.Column<string>(unicode: false, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductAppreciate = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    ShoppingCartId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_User",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ShippingId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: false),
                    CartItemIId = table.Column<int>(nullable: false),
                    OrderingStatus = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_CartItem",
                        column: x => x.CartItemIId,
                        principalTable: "CartItem",
                        principalColumn: "CartItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_ShippingInfo",
                        column: x => x.ShippingId,
                        principalTable: "ShippingInfo",
                        principalColumn: "ShippingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailsId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order",
                        column: x => x.OrderDetailsId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product",
                        column: x => x.OrderDetailsId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CustomerId",
                table: "CartItem",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ShoppingCartId",
                table: "CartItem",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShoppingCartIId",
                table: "Order",
                column: "CartItemIId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingId",
                table: "Order",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "ShippingInfo");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
