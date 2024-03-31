using DoAnMonWeb3.Models;
using DoAnMonWeb3.ViewModels;

namespace DoAnMonWeb3.Service
{
    public class PhongService
    {
        private ApplicationDbContext _context;

        public PhongService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GetLoaiPhongVM> GetAllLoaiPhong()
        {
            var _loaiphong = _context.loaiPhong.ToList().Select(n => new GetLoaiPhongVM
            {
                tenLoaiPhong = n.tenLoaiPhong,
                soNguoi = n.soNguoi,
                id = n.Id
            });

            return _loaiphong;
        }

        public IEnumerable<GetDayTroVM> GetAllDayTro()
        {
            var _daytro = _context.dayTro.ToList().Select(n => new GetDayTroVM
            {
                tenDayTro = n.tenDayTro,
                id = n.Id
            });
            return _daytro;
        }

        public Phong AddPhong(PhongVM phongVM)
        {
            var _phong = new Phong()
            {
                IDLoaiPhong = phongVM.IDLoaiPhong,
                IDDayTro = phongVM.IDDayTro,
                tenPhong = phongVM.tenPhong,
                conPhong = true,
                SoNguoiDangO = 0
            };

            _context.phong.Add(_phong);
            _context.SaveChanges();

            return _phong;
        }

        public IEnumerable<PhongVM> GetPhongs()
        {
            var _phong = _context.phong.ToList().Select(ph => new PhongVM
            {
                id = ph.Id,
                IDDayTro = ph.IDDayTro,
                IDLoaiPhong = ph.IDLoaiPhong,
                soNguoi = _context.loaiPhong.FirstOrDefault(b => b.Id == ph.IDLoaiPhong).soNguoi,
                tenLoaiPhong = _context.loaiPhong.FirstOrDefault(n => n.Id == ph.IDLoaiPhong).tenLoaiPhong,
                tenDayTro = _context.dayTro.FirstOrDefault(m => m.Id == ph.IDDayTro).tenDayTro,
                tenPhong = ph.tenPhong,
                conPhong = ph.conPhong,
                SoNguoiDangO = ph.SoNguoiDangO
            });
            return _phong;
        }

        public Phong UpdatePhongId(int phongId, PhongVM phongVM)
        {
            var _phong = _context.phong.FirstOrDefault(n => n.Id == phongId);
            if(_phong != null)
            {
                _phong.IDLoaiPhong = phongVM.IDLoaiPhong;
                _phong.IDDayTro = phongVM.IDDayTro;
                _phong.tenPhong = phongVM.tenPhong; 
             

                _context.SaveChanges() ;
            }
            return _phong;
        }

        public Phong DeletePhongId(int id)
        {
            var _phong = _context.phong.FirstOrDefault(n => n.Id == id);
            if(_phong != null)
            {
                _context.phong.Remove(_phong);
                _context.SaveChanges();
            }
            return _phong;
        }
    }
}
