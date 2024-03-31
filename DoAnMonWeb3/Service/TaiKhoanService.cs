using DoAnMonWeb3.Models;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace DoAnMonWeb3.Service
{
    public class TaiKhoanService
    {
        private ApplicationDbContext _context;

        public TaiKhoanService(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddTaiKhoan(TaiKhoanVM taiKhoanVM)
        {
            var _TaiKhoan = new TaiKhoan()
            {
                taiKhoan = taiKhoanVM.taiKhoan,
                matKhau = taiKhoanVM.matKhau
            };
            _context.taiKhoan.Add(_TaiKhoan);
            _context.SaveChanges();
        }

        public bool CheckLogin(string TaiKhoan, string MatKhau)
        {
            var user = _context.taiKhoan
                .FirstOrDefault(u => u.taiKhoan == TaiKhoan && u.matKhau == MatKhau);

            return user != null;
        }
        public List<TaiKhoan> GetTaiKhoans() => _context.taiKhoan.ToList();

        public TaiKhoan GetTaiKhoanId(int id) => _context.taiKhoan.FirstOrDefault(n => n.Id == id);

        public TaiKhoan UpdateTaiKhoanId(int TaiKhoanid, TaiKhoanVM taiKhoanVM)
        {
            var _Taikhoan = _context.taiKhoan.FirstOrDefault(n => n.Id == TaiKhoanid);
            if(_Taikhoan != null)
            {
                _Taikhoan.taiKhoan = taiKhoanVM.taiKhoan;
                _Taikhoan.matKhau = taiKhoanVM.matKhau;

                _context.SaveChanges();
            }
            return _Taikhoan;
        }

        public TaiKhoan DeleteTaiKhoanId(int id)
        {
            var tk = _context.taiKhoan.FirstOrDefault(n => n.Id == id);
            if(tk != null)
            {
                _context.taiKhoan.Remove(tk);
                _context.SaveChanges();
            }

            return tk;
        }
    }
}
