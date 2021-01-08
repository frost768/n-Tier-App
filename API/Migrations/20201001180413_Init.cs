using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VergiDaireleri",
                columns: table => new
                {
                    DaireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(nullable: true),
                    Il = table.Column<string>(maxLength: 50, nullable: true),
                    Ilce = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VergiDaireleri", x => x.DaireId);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    UrunId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(nullable: false),
                    Urun_adi = table.Column<string>(maxLength: 100, nullable: true),
                    Urun_aciklama = table.Column<string>(maxLength: 500, nullable: true),
                    Fiyat = table.Column<decimal>(nullable: false),
                    Para_birimi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.UrunId);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<string>(nullable: false),
                    JwtId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Used = table.Column<bool>(nullable: false),
                    Invalidated = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Kullanicilar_UserId",
                        column: x => x.UserId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Firmalar",
                columns: table => new
                {
                    FirmaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(maxLength: 100, nullable: true),
                    VD_Id = table.Column<int>(nullable: false),
                    Vergi_no = table.Column<string>(maxLength: 10, nullable: false),
                    Il = table.Column<string>(maxLength: 50, nullable: true),
                    Ilce = table.Column<string>(maxLength: 150, nullable: true),
                    Telefon = table.Column<string>(maxLength: 11, nullable: true),
                    E_posta = table.Column<string>(maxLength: 100, nullable: true),
                    Musteri_tipi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalar", x => x.FirmaId);
                    table.ForeignKey(
                        name: "FK_Firmalar_VergiDaireleri_VD_Id",
                        column: x => x.VD_Id,
                        principalTable: "VergiDaireleri",
                        principalColumn: "DaireId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Subeler",
                columns: table => new
                {
                    SubeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 100, nullable: false),
                    Il = table.Column<string>(maxLength: 50, nullable: true),
                    Ilce = table.Column<string>(maxLength: 150, nullable: true),
                    Telefon = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subeler", x => x.SubeId);
                    table.ForeignKey(
                        name: "FK_Subeler_Firmalar_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalar",
                        principalColumn: "FirmaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BilgisayarBaglantilari",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubeId = table.Column<int>(nullable: false),
                    FirmaId = table.Column<int>(nullable: false),
                    Aciklama = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilgisayarBaglantilari", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_BilgisayarBaglantilari_Firmalar_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalar",
                        principalColumn: "FirmaId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BilgisayarBaglantilari_Subeler_SubeId",
                        column: x => x.SubeId,
                        principalTable: "Subeler",
                        principalColumn: "SubeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Yetkililer",
                columns: table => new
                {
                    YetkiliId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaId = table.Column<int>(nullable: false),
                    SubeId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(maxLength: 100, nullable: true),
                    Soyad = table.Column<string>(maxLength: 100, nullable: true),
                    Gorev = table.Column<int>(nullable: false),
                    Telefon = table.Column<string>(maxLength: 11, nullable: false),
                    E_Posta = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetkililer", x => x.YetkiliId);
                    table.ForeignKey(
                        name: "FK_Yetkililer_Firmalar_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalar",
                        principalColumn: "FirmaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yetkililer_Subeler_SubeId",
                        column: x => x.SubeId,
                        principalTable: "Subeler",
                        principalColumn: "SubeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Programlar",
                columns: table => new
                {
                    ProgramId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(maxLength: 100, nullable: false),
                    BilgisayarBaglantiConnectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programlar", x => x.ProgramId);
                    table.ForeignKey(
                        name: "FK_Programlar_BilgisayarBaglantilari_BilgisayarBaglantiConnectionId",
                        column: x => x.BilgisayarBaglantiConnectionId,
                        principalTable: "BilgisayarBaglantilari",
                        principalColumn: "ConnectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RemoteCred",
                columns: table => new
                {
                    RemotePK = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemoteID = table.Column<string>(maxLength: 15, nullable: false),
                    Pass = table.Column<string>(maxLength: 30, nullable: true),
                    RemoteType = table.Column<int>(nullable: false),
                    BilgisayarBaglantiConnectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemoteCred", x => x.RemotePK);
                    table.ForeignKey(
                        name: "FK_RemoteCred_BilgisayarBaglantilari_BilgisayarBaglantiConnectionId",
                        column: x => x.BilgisayarBaglantiConnectionId,
                        principalTable: "BilgisayarBaglantilari",
                        principalColumn: "ConnectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "VergiDaireleri",
                columns: new[] { "DaireId", "Ad", "Il", "Ilce", "Kod" },
                values: new object[] { 1, "Vergi dairesi 1", "Sakarya", "Serdivan", 43243432 });

            migrationBuilder.CreateIndex(
                name: "IX_BilgisayarBaglantilari_FirmaId",
                table: "BilgisayarBaglantilari",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_BilgisayarBaglantilari_SubeId",
                table: "BilgisayarBaglantilari",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Firmalar_VD_Id",
                table: "Firmalar",
                column: "VD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Programlar_BilgisayarBaglantiConnectionId",
                table: "Programlar",
                column: "BilgisayarBaglantiConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteCred_BilgisayarBaglantiConnectionId",
                table: "RemoteCred",
                column: "BilgisayarBaglantiConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subeler_FirmaId",
                table: "Subeler",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Yetkililer_FirmaId",
                table: "Yetkililer",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Yetkililer_SubeId",
                table: "Yetkililer",
                column: "SubeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programlar");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RemoteCred");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Yetkililer");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "BilgisayarBaglantilari");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Subeler");

            migrationBuilder.DropTable(
                name: "Firmalar");

            migrationBuilder.DropTable(
                name: "VergiDaireleri");
        }
    }
}
