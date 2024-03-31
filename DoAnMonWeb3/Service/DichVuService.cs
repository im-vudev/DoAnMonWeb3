using DoAnMonWeb3.Models;
using DoAnMonWeb3.ViewModels;

namespace DoAnMonWeb3.Service
{
    public class DichVuService
    {
        private ApplicationDbContext _context;

        public DichVuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddDichVu(DichVuVM dichVuVM)
        {
            var _DichVu = new DichVu()
            {
                tenDichVu = dichVuVM.tenDichVu,
                giaDichVu = dichVuVM.giaDichVu
            };
            _context.dichVu.Add(_DichVu);
            _context.SaveChanges();
        }

        public List<DichVu> GetDichVus() => _context.dichVu.ToList();

        public DichVu GetDichVuId(int id) => _context.dichVu.FirstOrDefault(n => n.Id == id);


        public DichVu UpdateDichVuId(int dichvuid,DichVuVM dichVuVM)
        {
            var _dichVu = _context.dichVu.FirstOrDefault(n => n.Id == dichvuid);
            if(_dichVu != null)
            {
                _dichVu.tenDichVu = dichVuVM.tenDichVu;
                _dichVu.giaDichVu = dichVuVM.giaDichVu;
                _context.SaveChanges();
            }
            return _dichVu;
        }


        public DichVu DeleteDichvuId(int id)
        {
            var _response = _context.dichVu.FirstOrDefault(n => n.Id == id);
            if(_response != null)
            {
                _context.dichVu.Remove(_response);
                _context.SaveChanges();
            }
            return _response;
        }
    }
}
