using DoAnMonWeb3.Models;
using DoAnMonWeb3.ViewModels;

namespace DoAnMonWeb3.Service
{
    public class ThongBaoService
    {
        private ApplicationDbContext _context;


        public ThongBaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ThongBao CreateThongBaoAsync(ThongBaoVM thongBaoVM)
        {
            var _thongbao = new ThongBao()
            {
                ngayDang = DateTime.Now,
                tieuDe = thongBaoVM.tieuDe,
                moTa = thongBaoVM.moTa,
            };
            _context.Add(_thongbao);
            _context.SaveChanges();
            return _thongbao;
        }

        public List<ThongBao> GetallThongBao() => _context.thongBao.ToList();
        public ThongBao GetThongBaoAsync(int id) => _context.thongBao.FirstOrDefault(n => n.Id == id);


        public ThongBao UpdateThongBaoAsync(int id, ThongBaoVM thongBaoVM)
        {
            var _thongbao = _context.thongBao.FirstOrDefault(n => n.Id == id);
            if(_thongbao != null)
            {
                _thongbao.ngayDang = DateTime.Now;
                _thongbao.tieuDe = thongBaoVM.tieuDe;
                _thongbao.moTa = thongBaoVM.moTa;

                _context.SaveChanges();
            }
            return _thongbao;
        }

        public ThongBao DeleteThongBaoAsync(int id)
        {
            var thongBao =  _context.thongBao.FirstOrDefault(n => n.Id ==  id);
            if(thongBao != null)
            {
                _context.thongBao.Remove(thongBao);
                _context.SaveChanges();
            }
            return thongBao;
        }
    }
}
