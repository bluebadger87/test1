using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShopProject.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Countryname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DetailNo = table.Column<int>(nullable: false),
                    ProductImageName = table.Column<string>(nullable: true),
                    ProductImageNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserAddress1 = table.Column<int>(nullable: false),
                    UserAddress2 = table.Column<int>(nullable: false),
                    UserAddress3 = table.Column<int>(nullable: false),
                    UserAuthority = table.Column<string>(nullable: true),
                    UserDel = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    UserInp = table.Column<DateTime>(nullable: false),
                    UserMail = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    UserPassword1 = table.Column<string>(nullable: false),
                    UserPassword2 = table.Column<string>(nullable: false),
                    UserTel = table.Column<string>(nullable: false),
                    UserUpd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserNo);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    Statename = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductCategory = table.Column<int>(nullable: false),
                    ProductDel = table.Column<string>(nullable: true),
                    ProductImage = table.Column<int>(nullable: false),
                    ProductInp = table.Column<DateTime>(nullable: false),
                    ProductMainImage = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: false),
                    ProductPrice = table.Column<int>(nullable: false),
                    ProductRemark = table.Column<string>(nullable: true),
                    ProductStock = table.Column<int>(nullable: false),
                    ProductUpd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductNo);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategoryList_ProductCategory",
                        column: x => x.ProductCategory,
                        principalTable: "ProductCategoryList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductImages_ProductImage",
                        column: x => x.ProductImage,
                        principalTable: "ProductImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDelivery = table.Column<string>(nullable: true),
                    OrderInp = table.Column<DateTime>(nullable: false),
                    OrderTotalPrice = table.Column<int>(nullable: false),
                    OrderUserNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderNo);
                    table.ForeignKey(
                        name: "FK_Order_User_OrderUserNo",
                        column: x => x.OrderUserNo,
                        principalTable: "User",
                        principalColumn: "UserNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cityname = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComment",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentDel = table.Column<string>(nullable: true),
                    CommentInpDate = table.Column<DateTime>(nullable: false),
                    CommentProductNo = table.Column<int>(nullable: false),
                    CommentUpdDate = table.Column<DateTime>(nullable: false),
                    CommentUserNo = table.Column<int>(nullable: false),
                    CommnetContent = table.Column<string>(nullable: true),
                    CommnetScore = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_ProductComment_Product_CommentProductNo",
                        column: x => x.CommentProductNo,
                        principalTable: "Product",
                        principalColumn: "ProductNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComment_User_CommentUserNo",
                        column: x => x.CommentUserNo,
                        principalTable: "User",
                        principalColumn: "UserNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDetailInp = table.Column<DateTime>(nullable: false),
                    OrderDetailOrderNo = table.Column<int>(nullable: false),
                    OrderDetailProductNo = table.Column<int>(nullable: false),
                    OrderDetailQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailNo);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderDetailOrderNo",
                        column: x => x.OrderDetailOrderNo,
                        principalTable: "Order",
                        principalColumn: "OrderNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_OrderDetailProductNo",
                        column: x => x.OrderDetailProductNo,
                        principalTable: "Product",
                        principalColumn: "ProductNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderUserNo",
                table: "Order",
                column: "OrderUserNo");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderDetailOrderNo",
                table: "OrderDetail",
                column: "OrderDetailOrderNo");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderDetailProductNo",
                table: "OrderDetail",
                column: "OrderDetailProductNo");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategory",
                table: "Product",
                column: "ProductCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductImage",
                table: "Product",
                column: "ProductImage");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_CommentProductNo",
                table: "ProductComment",
                column: "CommentProductNo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_CommentUserNo",
                table: "ProductComment",
                column: "CommentUserNo");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ProductComment");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ProductCategoryList");

            migrationBuilder.DropTable(
                name: "ProductImages");
        }
    }
}
