using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        private PhongService _phongService;


        public PhongController(PhongService phongService)
        {
            _phongService = phongService;
        }

        [HttpGet("get-all-loaiphong")]
        public IActionResult GetAllLoaiPhong()
        {
            var _loaiphong = _phongService.GetAllLoaiPhong();
            return Ok(_loaiphong);
        }

        [HttpGet("get-all-daytro")]
        public IActionResult GetAllDayTro()
        {
            var _daytro = _phongService.GetAllDayTro();
            return Ok(_daytro);
        }


        [HttpGet("get-phong-list")]
        public IActionResult GetPhong()
        {
            var _phong = _phongService.GetPhongs();
            return Ok(_phong);
        }

        [HttpPost("add-phong-id")]
        public IActionResult CreactPhong([FromBody] PhongVM phongVM)
        {
            var _phong = _phongService.AddPhong(phongVM);
            if (_phong != null)
            {
                return Ok(_phong);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("update-phong-id")]
        public async Task<IActionResult> UpdatePhongId(int phongId, [FromBody] PhongVM phongVM)
        {
            try
            {
                var _phong = _phongService.UpdatePhongId(phongId, phongVM);
                if(_phong != null)
                {
                    return Ok(_phong);
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
        [HttpDelete("delete-phong-id/{id}")]
        public IActionResult DeletePhongId(int id)
        {
            try
            {
                var _phong = _phongService.DeletePhongId(id);
                if(_phong != null)
                {
                    return Ok("Xóa thành Công");
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
