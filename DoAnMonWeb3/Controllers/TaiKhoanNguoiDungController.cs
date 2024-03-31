using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanNguoiDungController : ControllerBase
    {
        private TaikhoanNguoiDungService _taikhoannguoidungservice;


        public TaiKhoanNguoiDungController(TaikhoanNguoiDungService taikhoannguoidungservice)
        {
            _taikhoannguoidungservice = taikhoannguoidungservice;
        }

        [HttpPost("Add-taikhoanguoidung")]
        public async Task<IActionResult> CreateTaiKhoanNguoiDung(TaiKhoanNguoiDungVM taiKhoanNguoiDungVM)
        {
            try
            {
                _taikhoannguoidungservice.AddTaiKhoanNguoiDung(taiKhoanNguoiDungVM);
                return Ok("Thêm Thành Công");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login-nguoidung")]
        public async Task<IActionResult> Login([FromBody] TaiKhoanNguoiDungVM loginDto)
        {
            var taiKhoan = loginDto.CMND_CCCD;
            var matKhau = loginDto.matKhau;

            var user = await _taikhoannguoidungservice.Login(taiKhoan, matKhau);

            if (user != null)
            {
                // Đăng nhập thành công
                return Ok(new { Success = true, Message = "Login successful" });
            }

            // Đăng nhập thất bại
            return BadRequest(new { Success = false, Message = "Invalid username or password" });
        }


        [HttpGet("get-taikhoannguoidung")]
        public IActionResult GetTaikhoannguoidung()
        {
            var _response = _taikhoannguoidungservice.GetTaikhoanNguoiDungs();
            return Ok(_response);

        }

        [HttpGet("get-all-taikhoannguoidung-nguoithue")]
        public IActionResult GetTaiKhoanNguoiThue()
        {
            var _nguoithue = _taikhoannguoidungservice.GetAllNguoiThue();
            return Ok(_nguoithue);
        }

        [HttpGet("get-taikhaonnguoidung-id/{id}")]
        public async Task<IActionResult> GetTaiKhoanNguoiDungId(int id)
        {
            try
            {
                var _reponse = _taikhoannguoidungservice.GetTaikhoanNguoiDungId(id);
                if(_reponse != null)
                {
                    return Ok(_reponse);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update-Taikhoannguoidung-id")]
        public async Task<IActionResult> UpdateTaikhoannguoidungId(int TId , [FromBody] TaiKhoanNguoiDungVM taiKhoanNguoiDungVM)
        {
            try
            {
                var _nguoidung = _taikhoannguoidungservice.UpdateTaiKhoanNguoiDungId(TId, taiKhoanNguoiDungVM);
                if(_nguoidung != null)
                {
                    return Ok(_nguoidung);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete-taikhoan-nguoidung-id/{id}")]
        public async Task<IActionResult> DeleteTaiKhoannguoidungId(int id)
        {
            try
            {
                var _delete = _taikhoannguoidungservice.DeleteTaiKhoanNguoidungId(id);
                if(_delete != null)
                {
                    return Ok("Xóa Thành công");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
