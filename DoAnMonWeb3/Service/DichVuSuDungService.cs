using DoAnMonWeb3.Models;
using DoAnMonWeb3.ViewModels;

namespace DoAnMonWeb3.Service
{
    public class DichVuSuDungService
    {
        private ApplicationDbContext _context;

        public DichVuSuDungService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GetPhongVM> GetAllDichVuPhong()
        {
            var _phong = _context.phong.ToList().Select(ph => new GetPhongVM
            {
                Id = ph.Id,
                tenPhong = ph.tenPhong
            });

            return _phong;
        }

        public IEnumerable<GetDichVuVM> GetAllDichVuVM()
        {
            var _dichvu = _context.dichVu.ToList().Select(dv => new GetDichVuVM
            {
                Id = dv.Id,
                tenDichVu = dv.tenDichVu
            });

            return _dichvu;
        }

        public IEnumerable<DichVuSuDungVM> GetDichVuSuDung()
        {
            var _dichvusudung = _context.dichVuSuDung.ToList().Select(dv => new DichVuSuDungVM()
            {
                IDDichVu = dv.IDDichVu,
                IDPhong = dv.IDPhong,
                tenDichVu = _context.dichVu.FirstOrDefault(d => d.Id == dv.IDDichVu).tenDichVu,
                tenPhong = _context.phong.FirstOrDefault(p => p.Id == dv.IDPhong).tenPhong
            });
            return _dichvusudung;
        }


        public DichVuSuDung AddDichVuSuDung(GetDichVuSuDungVM dichVuSuDungVM)
        {
            var _dichvusudung = new DichVuSuDung()
            {
                IDDichVu = dichVuSuDungVM.IDDichVu,
                IDPhong = dichVuSuDungVM.IDPhong
            };

            _context.dichVuSuDung.Add(_dichvusudung);
            _context.SaveChanges();

            return _dichvusudung;
        }

        public DichVuSuDung DeleteDichVuSuDungId(int idphong, int iddichvu)
        {
            var _delete = _context.dichVuSuDung.FirstOrDefault(n => n.IDDichVu == iddichvu && n.IDPhong == idphong);
            if (_delete != null)
            {
                _context.dichVuSuDung.Remove(_delete);
                _context.SaveChanges();
            }
            return _delete;
        }
    }
}
