using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private TaiKhoanService _taiKhoanService;

        public TaiKhoanController(TaiKhoanService taiKhoanService)
        {
            _taiKhoanService = taiKhoanService;
        }


        [HttpPost("Add-taikhoan")]
        public async Task<IActionResult> CreateTaiKhoan( TaiKhoanVM taiKhoanVM)
        {
            try
            {
                _taiKhoanService.AddTaiKhoan(taiKhoanVM);
                return Ok("Thêm Thành Công");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-taikhoan-list")]
        public IActionResult GetTaiKhoan()
        {
            try
            {
                var _taikhoan = _taiKhoanService.GetTaiKhoans();
                return Ok(_taikhoan);
            } 
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-taikhoan-id/{id}")]
        public async Task<IActionResult> GetTaiKhoanId(int id)
        {
            var _response = _taiKhoanService.GetTaiKhoanId(id);
            if(_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] TaiKhoanVM request)
        {
            string TaiKhoan = request.taiKhoan;
            string MatKhau = request.matKhau;

            bool isValid = _taiKhoanService.CheckLogin(TaiKhoan, MatKhau);

            if (isValid)
            {
                return Ok(new { success = true });
            }
            else
            {
                return BadRequest(new { success = false, message = "Invalid username or password" });
            }
        }

        [HttpPut("Update-taikhoan-id")]
        public async Task<IActionResult> UpdateTaiKhoanId(int taikhoanId, [FromBody] TaiKhoanVM taiKhoanVM)
        {
            try
            {
                var _update = _taiKhoanService.UpdateTaiKhoanId(taikhoanId, taiKhoanVM);
                if(_update != null)
                {
                    return Ok(_update);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpDelete("Delete-taikhoan-id/{id}")]
        public async Task<IActionResult> DeleteTaikhoanId(int id)
        {
            try
            {
                var _delete = _taiKhoanService.DeleteTaiKhoanId(id);
                if(_delete != null)
                {
                    return Ok("Xóa Thành Công");
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
