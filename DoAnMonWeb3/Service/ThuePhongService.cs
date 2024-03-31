using DoAnMonWeb3.Models;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnMonWeb3.Service
{
    public class ThuePhongService
    {
        private ApplicationDbContext _context;

        public ThuePhongService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GetPhongVM> GetAllPhongVM()
        {
            var _phong = _context.phong.ToList().Select(ph => new GetPhongVM
            {
                Id = ph.Id,
                tenPhong = ph.tenPhong
            });
            return _phong;
        }

        public IEnumerable<GetLoaiPhongVM> GetAllLoaiPhong()
        {
            var _loaiphong = _context.loaiPhong.ToList().Select(lp => new GetLoaiPhongVM
            {
                id = lp.Id,
                tenLoaiPhong = lp.tenLoaiPhong,
                giaPhong = lp.gia
            });
            return _loaiphong;
        }

        public IEnumerable<GetNguoiThueVM> GetAllNguoiThueVM()
        {
            var _nguoithue = _context.nguoiThue.ToList().Select(nt => new GetNguoiThueVM
            {
                Id = nt.Id,
                tenNguoithue = nt.hoTen
            });

            return _nguoithue;
        }

        public IEnumerable<GetDichVuSuDungVM> GetAllDichVuSuDungVM()
        {
            var _dichvu = _context.dichVu.ToList().Select(dv => new GetDichVuSuDungVM
            {
                IDDichVu = dv.Id,
                tenDichVu = dv.tenDichVu,
                giaDichVu = dv.giaDichVu,
            });
            return _dichvu;
        }

        public IEnumerable<GetdienNuocVM> GetAlldienNuocVM()
        {
            var _diennuoc = _context.dienNuoc.ToList().Select(dn => new GetdienNuocVM
            {
                Id = dn.Id,
                dienTieuThu = dn.dienTieuThu,
                giaDien = dn.giaDien,
                nuocTieuThu = dn.nuocTieuThu,
                giaNuoc = dn.giaNuoc,
            });
            return _diennuoc;
        }

        public IEnumerable<ThuePhongVM> GetThuePhongs()
        {
            var _thuephong = _context.thuePhong.ToList().Select(tp => new ThuePhongVM
            {
                Id = tp.Id,
                IDPhong = tp.IDPhong,
                IDNguoiThue = tp.IDNguoiThue,
                tenNguoithue = _context.nguoiThue.FirstOrDefault(n => n.Id == tp.IDNguoiThue).hoTen,
                tenPhong = _context.phong.FirstOrDefault(p => p.Id == tp.IDPhong).tenPhong,
                ngayThue = tp.ngayThue,
                ngayTra = tp.ngayTra,
                tienCoc = tp.tienCoc,

            });
            return _thuephong;
        }

        public ThuePhong AddThuePhong(ThuePhongVM thuePhongVM)
        {
            var _thuephong = new ThuePhong()
            {
                IDPhong = thuePhongVM.IDPhong,
                IDNguoiThue = thuePhongVM.IDNguoiThue,
                ngayThue = thuePhongVM.ngayThue,
                ngayTra = thuePhongVM.ngayTra,
                tienCoc = thuePhongVM.tienCoc
            };
            _context.thuePhong.Add(_thuephong);
            _context.SaveChanges();

            return _thuephong;
        }

        public ThuePhong UpdateThuePhongId(int thuephongId, ThuePhongVM thuePhongVM)
        {
            var _thuephong = _context.thuePhong.FirstOrDefault(n => n.Id == thuephongId);
            if(_thuephong != null)
            {
                _thuephong.IDPhong = thuePhongVM.IDPhong;
                _thuephong.IDNguoiThue = thuePhongVM.IDNguoiThue;
                _thuephong.ngayThue = thuePhongVM.ngayThue;
                _thuephong.ngayTra = thuePhongVM.ngayTra;
                _thuephong.tienCoc = thuePhongVM.tienCoc;

                _context.SaveChanges();
            };

            return _thuephong;
        }


        public async Task<decimal> TinhTongTien(int thuePhongId)
        {
            try
            {
               var _dichVuSuDung = await _context.dichVuSuDung
                    .Include(p => p.dichVu)
                    .Where(x => x.IDPhong == thuePhongId)
                    .ToListAsync();
                Console.WriteLine($"_dichVuSuDung: {_dichVuSuDung}");

                var _dienNuoc = await _context.dienNuoc
                    .Where(x => x.IDPhong == thuePhongId)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefaultAsync();
                Console.WriteLine($"_dienNuoc: {_dienNuoc}");

                var thuePhong = await _context.phong
                    .Include(tp => tp.loaiPhong)
                    .FirstOrDefaultAsync(tp => tp.Id == thuePhongId);
                Console.WriteLine($"thuePhong: {thuePhong}");


                if (_dichVuSuDung != null && _dichVuSuDung.Count > 0 && _dienNuoc != null && thuePhong != null)
                {
                    decimal tongDVDichVu = _dichVuSuDung.Sum(dvs => dvs.dichVu.giaDichVu);
                    decimal tongDien = _dienNuoc.giaDien * _dienNuoc.dienTieuThu;
                    decimal tongNuoc = _dienNuoc.giaNuoc * _dienNuoc.nuocTieuThu;
                    decimal tongDienNuoc = tongDien + tongNuoc;

                    // Lấy giá phòng từ thông tin phòng
                    decimal giaPhong = (decimal)thuePhong.loaiPhong.gia;

                    decimal tongF = tongDVDichVu + tongDienNuoc + giaPhong;

                    return tongF;
                }
                else
                {
                    // Xử lý khi dichVuSuDung, dienNuoc hoặc thuePhong là null hoặc rỗng
                    // Trả về một giá trị mặc định để phân biệt giữa trường hợp lỗi và trường hợp không có lỗi
                    return -1; // Hoặc giá trị mặc định khác
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và in thông tin chi tiết
                Console.Error.WriteLine($"Lỗi khi tính tổng tiền: {ex.Message}");
                return -1; // Hoặc giá trị mặc định khác
            }
        }
        public async Task<ThuePhong> DeleteThuePhongId(int id)
        {
            var _delete = await _context.thuePhong.FirstOrDefaultAsync(n => n.Id == id);
            if(_delete != null)
            {
                _context.thuePhong.Remove(_delete);
                _context.SaveChanges();
            }
            return _delete;
        }
    }
}
