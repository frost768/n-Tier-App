using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VergiDaireleri",
                keyColumn: "DaireId",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SubeId1",
                table: "Yetkililer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirmaId1",
                table: "Subeler",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BilgisayarBaglantiConnectionId1",
                table: "Programlar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubeId1",
                table: "BilgisayarBaglantilari",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yetkililer_SubeId1",
                table: "Yetkililer",
                column: "SubeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Subeler_FirmaId1",
                table: "Subeler",
                column: "FirmaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Programlar_BilgisayarBaglantiConnectionId1",
                table: "Programlar",
                column: "BilgisayarBaglantiConnectionId1");

            migrationBuilder.CreateIndex(
                name: "IX_BilgisayarBaglantilari_SubeId1",
                table: "BilgisayarBaglantilari",
                column: "SubeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BilgisayarBaglantilari_Subeler_SubeId1",
                table: "BilgisayarBaglantilari",
                column: "SubeId1",
                principalTable: "Subeler",
                principalColumn: "SubeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programlar_BilgisayarBaglantilari_BilgisayarBaglantiConnectionId1",
                table: "Programlar",
                column: "BilgisayarBaglantiConnectionId1",
                principalTable: "BilgisayarBaglantilari",
                principalColumn: "ConnectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subeler_Firmalar_FirmaId1",
                table: "Subeler",
                column: "FirmaId1",
                principalTable: "Firmalar",
                principalColumn: "FirmaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yetkililer_Subeler_SubeId1",
                table: "Yetkililer",
                column: "SubeId1",
                principalTable: "Subeler",
                principalColumn: "SubeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BilgisayarBaglantilari_Subeler_SubeId1",
                table: "BilgisayarBaglantilari");

            migrationBuilder.DropForeignKey(
                name: "FK_Programlar_BilgisayarBaglantilari_BilgisayarBaglantiConnectionId1",
                table: "Programlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Subeler_Firmalar_FirmaId1",
                table: "Subeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Yetkililer_Subeler_SubeId1",
                table: "Yetkililer");

            migrationBuilder.DropIndex(
                name: "IX_Yetkililer_SubeId1",
                table: "Yetkililer");

            migrationBuilder.DropIndex(
                name: "IX_Subeler_FirmaId1",
                table: "Subeler");

            migrationBuilder.DropIndex(
                name: "IX_Programlar_BilgisayarBaglantiConnectionId1",
                table: "Programlar");

            migrationBuilder.DropIndex(
                name: "IX_BilgisayarBaglantilari_SubeId1",
                table: "BilgisayarBaglantilari");

            migrationBuilder.DropColumn(
                name: "SubeId1",
                table: "Yetkililer");

            migrationBuilder.DropColumn(
                name: "FirmaId1",
                table: "Subeler");

            migrationBuilder.DropColumn(
                name: "BilgisayarBaglantiConnectionId1",
                table: "Programlar");

            migrationBuilder.DropColumn(
                name: "SubeId1",
                table: "BilgisayarBaglantilari");

            migrationBuilder.InsertData(
                table: "VergiDaireleri",
                columns: new[] { "DaireId", "Ad", "Il", "Ilce", "Kod" },
                values: new object[] { 1, "Vergi dairesi 1", "Sakarya", "Serdivan", 43243432 });
        }
    }
}
