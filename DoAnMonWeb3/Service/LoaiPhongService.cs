using DoAnMonWeb3.Models;
using DoAnMonWeb3.ViewModels;

namespace DoAnMonWeb3.Service
{
    public class LoaiPhongService
    {
        private ApplicationDbContext _context;

        public LoaiPhongService(ApplicationDbContext context)
        {
            _context = context;
        }

        public LoaiPhong AddLoaiPhong(LoaiPhongVM loaiPhongVM)
        {
            var _loaiphong = new LoaiPhong()
            {
                tenLoaiPhong = loaiPhongVM.tenLoaiPhong,
                gia = loaiPhongVM.gia,
                soNguoi = loaiPhongVM.soNguoi
            };
            _context.loaiPhong.Add(_loaiphong);
            _context.SaveChanges();

            return _loaiphong;
        }

        public List<LoaiPhong> GetLoaiPhongs() => _context.loaiPhong.ToList();

        public LoaiPhong GetLoaiPhongId(int id) => _context.loaiPhong.FirstOrDefault(n => n.Id == id);

        public LoaiPhong UpdateLoaiPhongId(int loaiphongId, LoaiPhongVM loaiPhongVM)
        {
            var _loaiphong = _context.loaiPhong.FirstOrDefault(n => n.Id == loaiphongId);
            if(_loaiphong != null)
            {
                _loaiphong.tenLoaiPhong = loaiPhongVM.tenLoaiPhong;
                _loaiphong.gia = loaiPhongVM.gia;
                _loaiphong.soNguoi = loaiPhongVM.soNguoi;

                _context.SaveChanges();
            }

            return _loaiphong;
        }

        public LoaiPhong DeleteLoaiPhongId(int id)
        {
            var _loaiphong = _context.loaiPhong.FirstOrDefault(n => n.Id == id);
            if(_loaiphong != null)
            {
                _context.loaiPhong.Remove(_loaiphong);
                _context.SaveChanges();
            }
            return _loaiphong;
        }
    }
}
