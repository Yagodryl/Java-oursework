using Microsoft.EntityFrameworkCore.Migrations;

namespace JavaAndReact.Migrations
{
    public partial class Renametables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientOrders_Clients_ClientId",
                table: "ClientOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_Id",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhotos_Products_ProductId",
                table: "ProductPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_tblClientCards_ClientCardId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ClientOrders_ClientOrderId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SellerStorages_SellerStorageId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_tblTypeOfProducts_TypeOfProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_AspNetUsers_Id",
                table: "Sellers");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerStorages_Sellers_Id",
                table: "SellerStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_tblClientCards_Clients_Id",
                table: "tblClientCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellerStorages",
                table: "SellerStorages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPhotos",
                table: "ProductPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientOrders",
                table: "ClientOrders");

            migrationBuilder.RenameTable(
                name: "SellerStorages",
                newName: "tblSellerStoregies");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "tblSeller");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "tblProducts");

            migrationBuilder.RenameTable(
                name: "ProductPhotos",
                newName: "tblProductsPhotos");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "tblClients");

            migrationBuilder.RenameTable(
                name: "ClientOrders",
                newName: "tblClientOrders");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TypeOfProductId",
                table: "tblProducts",
                newName: "IX_tblProducts_TypeOfProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellerStorageId",
                table: "tblProducts",
                newName: "IX_tblProducts_SellerStorageId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ClientOrderId",
                table: "tblProducts",
                newName: "IX_tblProducts_ClientOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ClientCardId",
                table: "tblProducts",
                newName: "IX_tblProducts_ClientCardId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "tblProductsPhotos",
                newName: "IX_tblProductsPhotos_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientOrders_ClientId",
                table: "tblClientOrders",
                newName: "IX_tblClientOrders_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblSellerStoregies",
                table: "tblSellerStoregies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblSeller",
                table: "tblSeller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProducts",
                table: "tblProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProductsPhotos",
                table: "tblProductsPhotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblClients",
                table: "tblClients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblClientOrders",
                table: "tblClientOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblClientCards_tblClients_Id",
                table: "tblClientCards",
                column: "Id",
                principalTable: "tblClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblClientOrders_tblClients_ClientId",
                table: "tblClientOrders",
                column: "ClientId",
                principalTable: "tblClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblClients_AspNetUsers_Id",
                table: "tblClients",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProducts_tblClientCards_ClientCardId",
                table: "tblProducts",
                column: "ClientCardId",
                principalTable: "tblClientCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProducts_tblClientOrders_ClientOrderId",
                table: "tblProducts",
                column: "ClientOrderId",
                principalTable: "tblClientOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProducts_tblSellerStoregies_SellerStorageId",
                table: "tblProducts",
                column: "SellerStorageId",
                principalTable: "tblSellerStoregies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProducts_tblTypeOfProducts_TypeOfProductId",
                table: "tblProducts",
                column: "TypeOfProductId",
                principalTable: "tblTypeOfProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductsPhotos_tblProducts_ProductId",
                table: "tblProductsPhotos",
                column: "ProductId",
                principalTable: "tblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblSeller_AspNetUsers_Id",
                table: "tblSeller",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblSellerStoregies_tblSeller_Id",
                table: "tblSellerStoregies",
                column: "Id",
                principalTable: "tblSeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblClientCards_tblClients_Id",
                table: "tblClientCards");

            migrationBuilder.DropForeignKey(
                name: "FK_tblClientOrders_tblClients_ClientId",
                table: "tblClientOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_tblClients_AspNetUsers_Id",
                table: "tblClients");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProducts_tblClientCards_ClientCardId",
                table: "tblProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProducts_tblClientOrders_ClientOrderId",
                table: "tblProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProducts_tblSellerStoregies_SellerStorageId",
                table: "tblProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProducts_tblTypeOfProducts_TypeOfProductId",
                table: "tblProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductsPhotos_tblProducts_ProductId",
                table: "tblProductsPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_tblSeller_AspNetUsers_Id",
                table: "tblSeller");

            migrationBuilder.DropForeignKey(
                name: "FK_tblSellerStoregies_tblSeller_Id",
                table: "tblSellerStoregies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblSellerStoregies",
                table: "tblSellerStoregies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblSeller",
                table: "tblSeller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProductsPhotos",
                table: "tblProductsPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProducts",
                table: "tblProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblClients",
                table: "tblClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblClientOrders",
                table: "tblClientOrders");

            migrationBuilder.RenameTable(
                name: "tblSellerStoregies",
                newName: "SellerStorages");

            migrationBuilder.RenameTable(
                name: "tblSeller",
                newName: "Sellers");

            migrationBuilder.RenameTable(
                name: "tblProductsPhotos",
                newName: "ProductPhotos");

            migrationBuilder.RenameTable(
                name: "tblProducts",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "tblClients",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "tblClientOrders",
                newName: "ClientOrders");

            migrationBuilder.RenameIndex(
                name: "IX_tblProductsPhotos_ProductId",
                table: "ProductPhotos",
                newName: "IX_ProductPhotos_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_tblProducts_TypeOfProductId",
                table: "Products",
                newName: "IX_Products_TypeOfProductId");

            migrationBuilder.RenameIndex(
                name: "IX_tblProducts_SellerStorageId",
                table: "Products",
                newName: "IX_Products_SellerStorageId");

            migrationBuilder.RenameIndex(
                name: "IX_tblProducts_ClientOrderId",
                table: "Products",
                newName: "IX_Products_ClientOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_tblProducts_ClientCardId",
                table: "Products",
                newName: "IX_Products_ClientCardId");

            migrationBuilder.RenameIndex(
                name: "IX_tblClientOrders_ClientId",
                table: "ClientOrders",
                newName: "IX_ClientOrders_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellerStorages",
                table: "SellerStorages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPhotos",
                table: "ProductPhotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientOrders",
                table: "ClientOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientOrders_Clients_ClientId",
                table: "ClientOrders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_Id",
                table: "Clients",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhotos_Products_ProductId",
                table: "ProductPhotos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_tblClientCards_ClientCardId",
                table: "Products",
                column: "ClientCardId",
                principalTable: "tblClientCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ClientOrders_ClientOrderId",
                table: "Products",
                column: "ClientOrderId",
                principalTable: "ClientOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SellerStorages_SellerStorageId",
                table: "Products",
                column: "SellerStorageId",
                principalTable: "SellerStorages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_tblTypeOfProducts_TypeOfProductId",
                table: "Products",
                column: "TypeOfProductId",
                principalTable: "tblTypeOfProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_AspNetUsers_Id",
                table: "Sellers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerStorages_Sellers_Id",
                table: "SellerStorages",
                column: "Id",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblClientCards_Clients_Id",
                table: "tblClientCards",
                column: "Id",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
