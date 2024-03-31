using DoAnMonWeb3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using DoAnMonWeb3.ViewModels;

namespace DoAnMonWeb3.Service
{
    public class DienNuocService
    {
        private ApplicationDbContext _context;


        public DienNuocService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<GetPhongVM> GetAllNamePhong()
        {
            var lst = _context.phong.ToList().Select(x => new GetPhongVM
            {
                tenPhong = x.tenPhong,
                Id = x.Id
            });
            return lst;
        }
        public DienNuoc AddDienNuocId( DienNuocVM dienNuocVM)
        {
            var _diennuoc = new DienNuoc()
            {
                IDPhong = dienNuocVM.IDPhong,
                thoiGianHoaDon = dienNuocVM.thoiGianHoaDon,
                dienTieuThu = dienNuocVM.dienTieuThu,
                giaDien = dienNuocVM.giaDien,
                nuocTieuThu = dienNuocVM.nuocTieuThu,
                giaNuoc = dienNuocVM.giaNuoc
            };
            _context.dienNuoc.Add(_diennuoc);
            _context.SaveChanges();

            return _diennuoc;
        }
        public IEnumerable<DienNuocVM> GetDienNuoc() 
        {
            var lis = _context.dienNuoc.ToList().Select(n => new DienNuocVM()
            {
                Id = n.Id,
                IDPhong = n.IDPhong,
                tenPhong = _context.phong.FirstOrDefault(m => m.Id == n.IDPhong).tenPhong,
                thoiGianHoaDon = n.thoiGianHoaDon,
                dienTieuThu = n.dienTieuThu,
                giaDien = n.giaDien,
                nuocTieuThu = n.nuocTieuThu,
                giaNuoc = n.giaNuoc
            });

            return lis;
        } 

        public DienNuoc GetDienNuocId(int id) => _context.dienNuoc.FirstOrDefault(n => n.Id == id);    
       
        public DienNuoc UpdateDienNuocId(int dienNuocId, DienNuocVM dienNuocVM)
        {
            var _diennuoc = _context.dienNuoc.FirstOrDefault(n => n.Id == dienNuocId);
            if (_diennuoc != null)
            {
                _diennuoc.IDPhong = dienNuocVM.IDPhong;
                _diennuoc.thoiGianHoaDon = dienNuocVM.thoiGianHoaDon;
                _diennuoc.dienTieuThu = dienNuocVM.dienTieuThu;
                _diennuoc.giaNuoc = dienNuocVM.giaNuoc;
                _diennuoc.giaDien = dienNuocVM.giaDien;
                _diennuoc.nuocTieuThu = dienNuocVM.nuocTieuThu;

                _context.SaveChanges();
            }

            return _diennuoc;
        }
        
        public DienNuoc DeleteDienNuocId(int id)
        {
            var _diennuoc = _context.dienNuoc.FirstOrDefault(_n => _n.Id == id);
            if(_diennuoc != null)
            {
                _context.dienNuoc.Remove(_diennuoc);
                _context.SaveChanges();
            }
            return _diennuoc;
        }
    }
}
