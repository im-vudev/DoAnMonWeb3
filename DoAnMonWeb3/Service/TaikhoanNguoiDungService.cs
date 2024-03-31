using DoAnMonWeb3.Models;
using DoAnMonWeb3.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DoAnMonWeb3.Service
{
    public class TaikhoanNguoiDungService
    {
        private ApplicationDbContext _context;

        public TaikhoanNguoiDungService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTaiKhoanNguoiDung(TaiKhoanNguoiDungVM taiKhoanNguoiDungVM)
        {
            var _taikhoannguoidung = _context.nguoiThue.FirstOrDefault(n => n.CMND_CCCD == taiKhoanNguoiDungVM.CMND_CCCD);
            if(_taikhoannguoidung != null)
            {
                var newTaiKhoan = new TaikhoanNguoiDung
                {
                    CMND_CCCD = _taikhoannguoidung.CMND_CCCD,
                    matKhau = taiKhoanNguoiDungVM.matKhau
                    //Thêm các thuộc tính khác nếu cần
                };
                _context.taikhoanNguoiDung.Add(newTaiKhoan);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Không tìm thấy thông tin nguoiThue");
            }
        }
        public async Task<TaikhoanNguoiDung> Login(string taiKhoan, string matKhau)
        {
            // Logic kiểm tra đăng nhập
            var _user = await _context.taikhoanNguoiDung
                .FirstOrDefaultAsync(u => (u.CMND_CCCD == taiKhoan || u.CMND_CCCD == taiKhoan) && u.matKhau == matKhau);
            return _user;
        }
        public IEnumerable<NguoithueGetVM> GetAllNguoiThue()
        {
            var _nguoithue = _context.nguoiThue.ToList().Select(n => new NguoithueGetVM
            {
                Id = n.Id,
                hoTen = n.hoTen,
                CMND_CCCD = n.CMND_CCCD,
            });
            return _nguoithue;
        }

        public List<TaikhoanNguoiDung> GetTaikhoanNguoiDungs() => _context.taikhoanNguoiDung.ToList();
        public TaikhoanNguoiDung GetTaikhoanNguoiDungId(int id) => _context.taikhoanNguoiDung.FirstOrDefault(n => n.Id == id);

        public TaikhoanNguoiDung UpdateTaiKhoanNguoiDungId(int TaiKhoanNguoiDungId, TaiKhoanNguoiDungVM taiKhoanNguoiDungVM)
        {
            var _taikhoannguoidung = _context.taikhoanNguoiDung.FirstOrDefault(n => n.Id == TaiKhoanNguoiDungId);
            if(_taikhoannguoidung != null)
            {
                _taikhoannguoidung.CMND_CCCD = taiKhoanNguoiDungVM.CMND_CCCD;
                _taikhoannguoidung.matKhau = taiKhoanNguoiDungVM.matKhau;

                _context.SaveChanges();
            }
            return _taikhoannguoidung;
        }

        public TaikhoanNguoiDung DeleteTaiKhoanNguoidungId(int id)
        {
            var TKND = _context.taikhoanNguoiDung.FirstOrDefault(n => n.Id == id);
            if(TKND != null)
            {
                _context.taikhoanNguoiDung.Remove(TKND);
                _context.SaveChanges() ;
            }
            return TKND;
        }
    }
}
