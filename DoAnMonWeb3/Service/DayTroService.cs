using DoAnMonWeb3.Models;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DoAnMonWeb3.Service
{
    public class DayTroService
    {
        private ApplicationDbContext _context;

        public DayTroService(ApplicationDbContext context)
        {
            _context = context;
        }   
        
        public DayTro AddDayTro(DayTroVM dayTroVM)
        {
            var _DayTro = new DayTro()
            {
                tenDayTro = dayTroVM.tenDayTro,
                soLuongPhong = dayTroVM.soLuongPhong
            };
            _context.dayTro.Add(_DayTro);
            _context.SaveChanges();

            return _DayTro;
           
        }

        public List<DayTro> GetDayTros() => _context.dayTro.ToList();
        public DayTro GetDayTros(int id) => _context.dayTro.FirstOrDefault(n => n.Id == id);
        
        public DayTro UpdateDayTroId(int daytroId, DayTroVM dayTroVM)
        {
            
            
                var _daytro = _context.dayTro.FirstOrDefault(n => n.Id == daytroId);
                if (_daytro != null)
                {
                    _daytro.tenDayTro = dayTroVM.tenDayTro;
                    _daytro.soLuongPhong = dayTroVM.soLuongPhong;

                    _context.SaveChanges();
                }
                return _daytro;
            
        }

        public void DeleteDaTroId(int dayTros)
        {
            var _daytro = _context.dayTro.FirstOrDefault(n => n.Id == dayTros);
            if (_daytro != null)
            {
                _context.dayTro.Remove(_daytro);
                _context.SaveChanges();
            }
        }
    }
}
