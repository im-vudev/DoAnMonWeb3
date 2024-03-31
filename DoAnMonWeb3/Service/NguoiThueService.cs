using DoAnMonWeb3.Models;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace DoAnMonWeb3.Service
{
    public class NguoiThueService
    {
        private ApplicationDbContext _context;

        public NguoiThueService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NguoiThueVM> CreateNguoiThue(NguoiThueVM nguoiThueVM, IFormFile anhDaiDien, IFormFile matTruocCCCD, IFormFile matSauCMND)
        {
            try
            {
                var taikhoan = await _context.taikhoanNguoiDung.Where(x => x.CMND_CCCD == nguoiThueVM.CMND_CCCD).FirstOrDefaultAsync();

                if (taikhoan == null)
                {
                    taikhoan = new TaikhoanNguoiDung
                    {
                        CMND_CCCD = nguoiThueVM.CMND_CCCD,
                        matKhau = nguoiThueVM.CMND_CCCD
                    };

                    _context.Add(taikhoan);
                    await _context.SaveChangesAsync();
                }

                var _nguoiThue = new NguoiThue()
                {
                    hoTen = nguoiThueVM.hoTen,
                    gioiTinh = nguoiThueVM.gioiTinh,
                    SDT = nguoiThueVM.SDT,
                    queQuan = nguoiThueVM.queQuan,
                    ngaySinh = nguoiThueVM.ngaySinh,
                    CMND_CCCD = nguoiThueVM.CMND_CCCD,
                    Email = nguoiThueVM.Email,
                    anhDaiDien = anhDaiDien != null ? Path.GetFileName(anhDaiDien.FileName) : null,
                    matTruocCCCD = matTruocCCCD != null ? Path.GetFileName(matTruocCCCD.FileName) : null,
                    matSauCMND = matSauCMND != null ? Path.GetFileName(matSauCMND.FileName) : null
                };

                Console.WriteLine(anhDaiDien);

                if (anhDaiDien != null && anhDaiDien.Length > 0)
                {
                    string path = Path.GetFullPath("D:\\Lap Trinh Web 3 API\\KTM-API\\KTM-API\\Reactjs\\daytro\\src\\Upload");
                    using (var filestream = new FileStream(Path.Combine(path, _nguoiThue.anhDaiDien), FileMode.Create))
                    {
                        await anhDaiDien.CopyToAsync(filestream);
                    }
                }

                if (matTruocCCCD != null && matTruocCCCD.Length > 0)
                {
                    string pathh = Path.GetFullPath("D:\\Lap Trinh Web 3 API\\KTM-API\\KTM-API\\Reactjs\\daytro\\src\\Upload");
                    using (var filestream = new FileStream(Path.Combine(pathh, _nguoiThue.matTruocCCCD), FileMode.Create))
                    {
                        await matTruocCCCD.CopyToAsync(filestream);
                    }
                }

                if (matSauCMND != null && matSauCMND.Length > 0 )
                {
                    string pathhh = Path.GetFullPath("D:\\Lap Trinh Web 3 API\\KTM-API\\KTM-API\\Reactjs\\daytro\\src\\Upload");
                    using (var filestream = new FileStream(Path.Combine(pathhh, _nguoiThue.matSauCMND), FileMode.Create))
                    {
                        await matSauCMND.CopyToAsync(filestream);
                    }
                }

                _context.nguoiThue.Add(_nguoiThue);
                _context.SaveChanges();

                return nguoiThueVM;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần thiết
                throw new Exception($"Error creating NguoiThue: {ex.Message}");
            }
        }

        public async Task<NguoiThueVM> UpdateNguoiThue(int id, NguoiThueVM updatedNguoiThueVM, IFormFile anhDaiDien, IFormFile matTruocCCCD, IFormFile matSauCMND)
        {
            var _nguoiThue = await _context.nguoiThue.FirstOrDefaultAsync(x => x.Id == id);

            var taikhoan = await _context.taikhoanNguoiDung.Where(x => x.CMND_CCCD == updatedNguoiThueVM.CMND_CCCD).FirstOrDefaultAsync();
            if (taikhoan != null)
            {
                taikhoan.CMND_CCCD = updatedNguoiThueVM.CMND_CCCD;
                taikhoan.matKhau = updatedNguoiThueVM.CMND_CCCD;
                _context.Update(taikhoan);
                await _context.SaveChangesAsync();
            }

            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Static"));

            if (anhDaiDien != null && anhDaiDien.Length > 0)
            {
                _nguoiThue.anhDaiDien = Path.GetFileName(anhDaiDien.FileName);
                using (var filestream = new FileStream(Path.Combine(path, _nguoiThue.anhDaiDien), FileMode.Create))
                {
                    await anhDaiDien.CopyToAsync(filestream);
                }
            }

            if (matTruocCCCD != null && matTruocCCCD.Length > 0)
            {
                _nguoiThue.matTruocCCCD = Path.GetFileName(matTruocCCCD.FileName);
                using (var filestream = new FileStream(Path.Combine(path, _nguoiThue.matTruocCCCD), FileMode.Create))
                {
                    await matTruocCCCD.CopyToAsync(filestream);
                }
            }

            if (matSauCMND != null && matSauCMND.Length > 0)
            {
                _nguoiThue.matSauCMND = Path.GetFileName(matSauCMND.FileName);
                using (var filestream = new FileStream(Path.Combine(path, _nguoiThue.matSauCMND), FileMode.Create))
                {
                    await matSauCMND.CopyToAsync(filestream);
                }
            }

            // Cập nhật thông tin khác của người thuê

            _context.nguoiThue.Update(_nguoiThue);
            await _context.SaveChangesAsync();

            return updatedNguoiThueVM;
        }

        public void DeleteNguoiThue(int id)
        {
            var _nguoiThue = _context.nguoiThue.FirstOrDefault(n => n.Id == id);
            if (_nguoiThue != null)
            {
                _context.nguoiThue.Remove(_nguoiThue);
                _context.SaveChanges();
            }

            // Các bước xóa tài khoản cũng có thể được thực hiện ở đây

        }

        public List<NguoiThue> GetAllNguoiThue() => _context.nguoiThue.ToList();

        
    }
}

