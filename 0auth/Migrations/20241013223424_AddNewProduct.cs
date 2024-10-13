using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _0auth.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    idmanufacturer = table.Column<int>(name: "id_manufacturer", type: "int", nullable: false),
                    namemanufacturer = table.Column<string>(name: "name_manufacturer", type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idmanufacturer);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "order_statuses",
                columns: table => new
                {
                    idorderstatus = table.Column<int>(name: "id_order_status", type: "int", nullable: false),
                    nameorderstatus = table.Column<string>(name: "name_order_status", type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idorderstatus);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "points",
                columns: table => new
                {
                    idpoint = table.Column<int>(name: "id_point", type: "int", nullable: false),
                    postcode = table.Column<int>(name: "post_code", type: "int", nullable: true),
                    addresspoint = table.Column<string>(name: "address_point", type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idpoint);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "product_types",
                columns: table => new
                {
                    idproducttype = table.Column<int>(name: "id_product_type", type: "int", nullable: false),
                    nameproducttype = table.Column<string>(name: "name_product_type", type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idproducttype);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    idrole = table.Column<int>(name: "id_role", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    namerole = table.Column<string>(name: "name_role", type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idrole);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    idsupplier = table.Column<int>(name: "id_supplier", type: "int", nullable: false),
                    namesupplier = table.Column<string>(name: "name_supplier", type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idsupplier);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    iduser = table.Column<int>(name: "id_user", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    surnameuser = table.Column<string>(name: "surname_user", type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nameuser = table.Column<string>(name: "name_user", type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    patronymicuser = table.Column<string>(name: "patronymic_user", type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    loginuser = table.Column<string>(name: "login_user", type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    passworduser = table.Column<string>(name: "password_user", type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idrole = table.Column<int>(name: "id_role", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.iduser);
                    table.ForeignKey(
                        name: "role",
                        column: x => x.idrole,
                        principalTable: "roles",
                        principalColumn: "id_role");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productarticlenumber = table.Column<string>(name: "product_article_number", type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    nameproduct = table.Column<string>(name: "name_product", type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    measureproduct = table.Column<string>(name: "measure_product", type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    costproduct = table.Column<decimal>(name: "cost_product", type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    descriptionproduct = table.Column<string>(name: "description_product", type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idproducttype = table.Column<int>(name: "id_product_type", type: "int", nullable: false),
                    photoproduct = table.Column<string>(name: "photo_product", type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idsupplier = table.Column<int>(name: "id_supplier", type: "int", nullable: false),
                    maxdiscount = table.Column<int>(name: "max_discount", type: "int", nullable: true),
                    idmanufacturer = table.Column<int>(name: "id_manufacturer", type: "int", nullable: false),
                    currentdiscount = table.Column<int>(name: "current_discount", type: "int", nullable: true),
                    statusproduct = table.Column<string>(name: "status_product", type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantityinstock = table.Column<int>(name: "quantity_in_stock", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.productarticlenumber);
                    table.ForeignKey(
                        name: "manufac",
                        column: x => x.idmanufacturer,
                        principalTable: "manufacturers",
                        principalColumn: "id_manufacturer");
                    table.ForeignKey(
                        name: "productType",
                        column: x => x.idproducttype,
                        principalTable: "product_types",
                        principalColumn: "id_product_type");
                    table.ForeignKey(
                        name: "sup",
                        column: x => x.idsupplier,
                        principalTable: "suppliers",
                        principalColumn: "id_supplier");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    idorder = table.Column<int>(name: "id_order", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dispatchdate = table.Column<DateTime>(name: "dispatch_date", type: "datetime", nullable: true),
                    deliverydate = table.Column<DateTime>(name: "delivery_date", type: "datetime", nullable: false),
                    idpoint = table.Column<int>(name: "id_point", type: "int", nullable: false),
                    iduser = table.Column<int>(name: "id_user", type: "int", nullable: true),
                    codeorder = table.Column<int>(name: "code_order", type: "int", nullable: true),
                    idorderstatus = table.Column<int>(name: "id_order_status", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idorder);
                    table.ForeignKey(
                        name: "pointID",
                        column: x => x.idpoint,
                        principalTable: "points",
                        principalColumn: "id_point");
                    table.ForeignKey(
                        name: "status",
                        column: x => x.idorderstatus,
                        principalTable: "order_statuses",
                        principalColumn: "id_order_status");
                    table.ForeignKey(
                        name: "userID",
                        column: x => x.iduser,
                        principalTable: "users",
                        principalColumn: "id_user");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "order_products",
                columns: table => new
                {
                    idorderproduct = table.Column<string>(name: "id_order_product", type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idorder = table.Column<int>(name: "id_order", type: "int", nullable: false),
                    productarticlenumber = table.Column<string>(name: "product_article_number", type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idorderproduct);
                    table.ForeignKey(
                        name: "orderID",
                        column: x => x.idorder,
                        principalTable: "orders",
                        principalColumn: "id_order");
                    table.ForeignKey(
                        name: "productArticleNumber",
                        column: x => x.productarticlenumber,
                        principalTable: "products",
                        principalColumn: "product_article_number");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "orderID_idx",
                table: "order_products",
                column: "id_order");

            migrationBuilder.CreateIndex(
                name: "productArticleNumber_idx",
                table: "order_products",
                column: "product_article_number");

            migrationBuilder.CreateIndex(
                name: "pointID_idx",
                table: "orders",
                column: "id_point");

            migrationBuilder.CreateIndex(
                name: "status_idx",
                table: "orders",
                column: "id_order_status");

            migrationBuilder.CreateIndex(
                name: "userID_idx",
                table: "orders",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "manufac_idx",
                table: "products",
                column: "id_manufacturer");

            migrationBuilder.CreateIndex(
                name: "productType_idx",
                table: "products",
                column: "id_product_type");

            migrationBuilder.CreateIndex(
                name: "sup_idx",
                table: "products",
                column: "id_supplier");

            migrationBuilder.CreateIndex(
                name: "role_idx",
                table: "users",
                column: "id_role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_products");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "points");

            migrationBuilder.DropTable(
                name: "order_statuses");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "manufacturers");

            migrationBuilder.DropTable(
                name: "product_types");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
