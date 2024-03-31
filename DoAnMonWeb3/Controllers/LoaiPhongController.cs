using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiPhongController : ControllerBase
    {
        private LoaiPhongService _loaiPhongService;

        public LoaiPhongController(LoaiPhongService loaiPhongService)
        {
            _loaiPhongService = loaiPhongService;
        }

        [HttpPost("add-loaiphong-id")]
        public async Task<IActionResult> CreactLoaiPhong([FromBody] LoaiPhongVM loaiPhongVM)
        {
            try
            {
                var _loaiphong = _loaiPhongService.AddLoaiPhong(loaiPhongVM);
                if(_loaiphong != null)
                {
                    return Ok("Thêm Thành Công");
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

        [HttpGet("get-loaiphong-list")]
        public IActionResult GetLoaiPhong()
        {
            var _loaiphong = _loaiPhongService.GetLoaiPhongs();
            return Ok(_loaiphong);
        }

        [HttpGet("get-loaiphong-id/{id}")]
        public async Task<IActionResult> GetLoaiPhongId(int id)
        {
            try
            {
                var _loaiphong = _loaiPhongService.GetLoaiPhongId(id);
                if(_loaiphong != null)
                {
                    return Ok(_loaiphong);
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

        [HttpPut("update-loaiphong-id")]
        public async Task<IActionResult> UpdateLoaiPhongId(int loaiphongid, [FromBody] LoaiPhongVM loaiPhongVM)
        {
            try
            {
                var _loaiphong = _loaiPhongService.UpdateLoaiPhongId(loaiphongid, loaiPhongVM);
                if(_loaiphong != null)
                {
                    return Ok(_loaiphong);
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

        [HttpDelete("delete-loaiphong-id/{id}")]
        public async Task<IActionResult> DeleteLoaiPhongId(int id)
        {
            try
            {
                var _loaiphong = _loaiPhongService.DeleteLoaiPhongId(id);
                if(_loaiphong != null)
                {
                    return Ok("Xóa Thành Công");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception exx)
            {

                return BadRequest(exx.Message);
            }
        }
    }
}
