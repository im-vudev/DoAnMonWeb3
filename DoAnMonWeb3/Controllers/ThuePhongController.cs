using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuePhongController : ControllerBase
    {
        private ThuePhongService _thuePhongService;


        public ThuePhongController(ThuePhongService thuePhongService)
        {
            _thuePhongService = thuePhongService;
        }


        [HttpGet("get-all-thuephong-phong")]
        public IActionResult GetAllPhongThue()
        {
            var _phong = _thuePhongService.GetAllPhongVM();
            return Ok(_phong);
        }

        [HttpGet("get-all-thuephong-nguoithue")]
        public IActionResult GetAllNguoiThue()
        {
            var _nguoithue = _thuePhongService.GetAllNguoiThueVM();
            return Ok(_nguoithue);
        }

        [HttpGet("get-all-thuephong-loaiphong")]
        public IActionResult GetAllLoaiPhong()
        {
            var _loaiphong = _thuePhongService.GetAllLoaiPhong();
            return Ok(_loaiphong);
        }

        [HttpGet("get-thuephong-list")]
        public IActionResult GetThuePhong()
        {
            var _thuephong = _thuePhongService.GetThuePhongs();
            return Ok(_thuephong);
        }
        [HttpGet("get-all-thuephong-diennuoc")]
        public IActionResult GetAllDienNuoc()
        {
            var _diennuoc = _thuePhongService.GetAlldienNuocVM();
            return Ok(_diennuoc);
        }
        [HttpGet("get-all-thuephong-dichvu")]
        public IActionResult GetAllDichVu()
        {
            var _dichvu = _thuePhongService.GetAllDichVuSuDungVM();
            return Ok(_dichvu);
        }
        [HttpGet("tinh-tong-tien/{thuePhongId}")]
        public async Task<ActionResult<decimal>> TinhTongTien(int thuePhongId)
        {
            try
            {
                var tongTien = await _thuePhongService.TinhTongTien(thuePhongId);
                return Ok(tongTien);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi tính tổng tiền: {ex.Message}");
            }
        }

        [HttpPost("add-thuephong")]
        public IActionResult CreateThuePhong([FromBody] ThuePhongVM thuePhongVM)
        {
            try
            {
                var _thuephong = _thuePhongService.AddThuePhong(thuePhongVM);
                if(_thuephong != null)
                {
                    return Ok(_thuephong);
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

        [HttpPut("update-thuephong-id")]
        public async Task<IActionResult> UpdateThuePhongId(int thuephongId, [FromBody] ThuePhongVM thuePhongVM)
        {
            try
            {
                var _thuephong = _thuePhongService.UpdateThuePhongId(thuephongId, thuePhongVM);
                if(_thuephong != null)
                {
                    return Ok(_thuephong);
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

        [HttpDelete("delete-thuephong-id")]
        public async Task<IActionResult> DeleteThuePhongId(int id)
        {
            _thuePhongService.DeleteThuePhongId(id);
            return Ok("Xóa Thành Công");
        }
    }
}
