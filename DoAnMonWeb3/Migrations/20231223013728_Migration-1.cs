using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnMonWeb3.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dayTro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDayTro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    soLuongPhong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dayTro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dichVu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDichVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    giaDichVu = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dichVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiPhong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLoaiPhong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    soNguoi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiPhong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nguoiThue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gioiTinh = table.Column<int>(type: "int", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    queQuan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ngaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CMND_CCCD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    anhDaiDien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    matTruocCCCD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    matSauCMND = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoiThue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taiKhoan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    matKhau = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiKhoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taikhoanNguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMND_CCCD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    matKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taikhoanNguoiDung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "thongBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tieuDe = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ngayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenPhong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IDLoaiPhong = table.Column<int>(type: "int", nullable: false),
                    conPhong = table.Column<bool>(type: "bit", nullable: false),
                    IDDayTro = table.Column<int>(type: "int", nullable: false),
                    SoNguoiDangO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phong_DayTro",
                        column: x => x.IDDayTro,
                        principalTable: "dayTro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Phong_LoaiPhong",
                        column: x => x.IDLoaiPhong,
                        principalTable: "loaiPhong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dichVuSuDung",
                columns: table => new
                {
                    IDPhong = table.Column<int>(type: "int", nullable: false),
                    IDDichVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dichVuSuDung", x => new { x.IDDichVu, x.IDPhong });
                    table.ForeignKey(
                        name: "FK_DichVuSuDung_DichVu",
                        column: x => x.IDDichVu,
                        principalTable: "dichVu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DichVuSuDung_Phong",
                        column: x => x.IDPhong,
                        principalTable: "phong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dienNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPhong = table.Column<int>(type: "int", nullable: false),
                    thoiGianHoaDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dienTieuThu = table.Column<int>(type: "int", nullable: false),
                    giaDien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nuocTieuThu = table.Column<int>(type: "int", nullable: false),
                    giaNuoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dienNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DienNuoc_Phong",
                        column: x => x.IDPhong,
                        principalTable: "phong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "thuePhong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPhong = table.Column<int>(type: "int", nullable: false),
                    IDNguoiThue = table.Column<int>(type: "int", nullable: false),
                    ngayThue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tienCoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thuePhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThuePhong_NguoiThue",
                        column: x => x.IDNguoiThue,
                        principalTable: "nguoiThue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThuePhong_Phong",
                        column: x => x.IDPhong,
                        principalTable: "phong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "hoaDon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDThuePhong = table.Column<int>(type: "int", nullable: false),
                    ngayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    soTienThanhToan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    trangThai = table.Column<int>(type: "int", nullable: false),
                    CMND_CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loaiPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    giaPhong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dienTieuThu = table.Column<int>(type: "int", nullable: false),
                    giaDien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nuocTieuThu = table.Column<int>(type: "int", nullable: false),
                    giaNuoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DSdichVuSuDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DSGiaDichVuSuDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_ThuePhong",
                        column: x => x.IDThuePhong,
                        principalTable: "thuePhong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_dichVuSuDung_IDPhong",
                table: "dichVuSuDung",
                column: "IDPhong");

            migrationBuilder.CreateIndex(
                name: "IX_dienNuoc_IDPhong",
                table: "dienNuoc",
                column: "IDPhong");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDon_IDThuePhong",
                table: "hoaDon",
                column: "IDThuePhong");

            migrationBuilder.CreateIndex(
                name: "IX_phong_IDDayTro",
                table: "phong",
                column: "IDDayTro");

            migrationBuilder.CreateIndex(
                name: "IX_phong_IDLoaiPhong",
                table: "phong",
                column: "IDLoaiPhong");

            migrationBuilder.CreateIndex(
                name: "IX_thuePhong_IDNguoiThue",
                table: "thuePhong",
                column: "IDNguoiThue");

            migrationBuilder.CreateIndex(
                name: "IX_thuePhong_IDPhong",
                table: "thuePhong",
                column: "IDPhong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dichVuSuDung");

            migrationBuilder.DropTable(
                name: "dienNuoc");

            migrationBuilder.DropTable(
                name: "hoaDon");

            migrationBuilder.DropTable(
                name: "taiKhoan");

            migrationBuilder.DropTable(
                name: "taikhoanNguoiDung");

            migrationBuilder.DropTable(
                name: "thongBao");

            migrationBuilder.DropTable(
                name: "dichVu");

            migrationBuilder.DropTable(
                name: "thuePhong");

            migrationBuilder.DropTable(
                name: "nguoiThue");

            migrationBuilder.DropTable(
                name: "phong");

            migrationBuilder.DropTable(
                name: "dayTro");

            migrationBuilder.DropTable(
                name: "loaiPhong");
        }
    }
}
