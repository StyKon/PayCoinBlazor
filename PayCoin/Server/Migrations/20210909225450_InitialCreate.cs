using Microsoft.EntityFrameworkCore.Migrations;

namespace PayCoin.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Cin = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Community",
                columns: table => new
                {
                    CommunityId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Cin = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community", x => x.CommunityId);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    DeliveryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Logo = table.Column<string>(nullable: false),
                    Cin = table.Column<string>(nullable: true),
                    Mc = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.DeliveryId);
                });

            migrationBuilder.CreateTable(
                name: "Designer",
                columns: table => new
                {
                    DesignerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Cin = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designer", x => x.DesignerId);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ProviderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Phone2 = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    Logo = table.Column<string>(nullable: false),
                    Cin = table.Column<string>(nullable: true),
                    Mc = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Lat = table.Column<string>(nullable: false),
                    Long = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Shipping",
                columns: table => new
                {
                    ShippingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping", x => x.ShippingId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Cin = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ChildCategory",
                columns: table => new
                {
                    ChildCategoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategory", x => x.ChildCategoryId);
                    table.ForeignKey(
                        name: "FK_ChildCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProvider",
                columns: table => new
                {
                    CategoryProviderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProvider", x => x.CategoryProviderId);
                    table.ForeignKey(
                        name: "FK_CategoryProvider_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CategoryProvider_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    CouponId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    DateValidation = table.Column<string>(nullable: false),
                    DateExpired = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Nature = table.Column<string>(nullable: false),
                    Validation = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    ProviderId = table.Column<long>(nullable: false),
                    CommunityId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.CouponId);
                    table.ForeignKey(
                        name: "FK_Coupon_Community_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Community",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Coupon_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Coupon = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Adresse1 = table.Column<string>(nullable: false),
                    Adresse2 = table.Column<string>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: false),
                    PaymentStatus = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    ShippingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Shipping_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shipping",
                        principalColumn: "ShippingId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChildCategoryProvider",
                columns: table => new
                {
                    ChildCategoryProviderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<long>(nullable: false),
                    ChildCategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategoryProvider", x => x.ChildCategoryProviderId);
                    table.ForeignKey(
                        name: "FK_ChildCategoryProvider_ChildCategory_ChildCategoryId",
                        column: x => x.ChildCategoryId,
                        principalTable: "ChildCategory",
                        principalColumn: "ChildCategoryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ChildCategoryProvider_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SmallCategory",
                columns: table => new
                {
                    SmallCategoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    ChildCategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallCategory", x => x.SmallCategoryId);
                    table.ForeignKey(
                        name: "FK_SmallCategory_ChildCategory_ChildCategoryId",
                        column: x => x.ChildCategoryId,
                        principalTable: "ChildCategory",
                        principalColumn: "ChildCategoryId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Size = table.Column<string>(nullable: false),
                    Condiction = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    Photo = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false),
                    ChildCategoryId = table.Column<long>(nullable: false),
                    SmallCategoryId = table.Column<long>(nullable: false),
                    ProviderId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Product_ChildCategory_ChildCategoryId",
                        column: x => x.ChildCategoryId,
                        principalTable: "ChildCategory",
                        principalColumn: "ChildCategoryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Product_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Product_SmallCategory_SmallCategoryId",
                        column: x => x.SmallCategoryId,
                        principalTable: "SmallCategory",
                        principalColumn: "SmallCategoryId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    ProviderId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cart_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cart_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cart_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WhishList",
                columns: table => new
                {
                    WhishListId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    CartId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhishList", x => x.WhishListId);
                    table.ForeignKey(
                        name: "FK_WhishList_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WhishList_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WhishList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_OrderId",
                table: "Cart",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProviderId",
                table: "Cart",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProvider_CategoryId",
                table: "CategoryProvider",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProvider_ProviderId",
                table: "CategoryProvider",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategory_CategoryId",
                table: "ChildCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategoryProvider_ChildCategoryId",
                table: "ChildCategoryProvider",
                column: "ChildCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategoryProvider_ProviderId",
                table: "ChildCategoryProvider",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_CommunityId",
                table: "Coupon",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_ProviderId",
                table: "Coupon",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingId",
                table: "Order",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ChildCategoryId",
                table: "Product",
                column: "ChildCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProviderId",
                table: "Product",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SmallCategoryId",
                table: "Product",
                column: "SmallCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SmallCategory_ChildCategoryId",
                table: "SmallCategory",
                column: "ChildCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WhishList_CartId",
                table: "WhishList",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_WhishList_ProductId",
                table: "WhishList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WhishList_UserId",
                table: "WhishList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CategoryProvider");

            migrationBuilder.DropTable(
                name: "ChildCategoryProvider");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Designer");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "WhishList");

            migrationBuilder.DropTable(
                name: "Community");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Shipping");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "SmallCategory");

            migrationBuilder.DropTable(
                name: "ChildCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
