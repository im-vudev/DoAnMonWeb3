using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DienNuocController : ControllerBase
    {
        private DienNuocService _dienNuocService;

        public DienNuocController(DienNuocService dienNuocService)
        {
            _dienNuocService = dienNuocService;
        }

        [HttpPost("add-diennuoc")]
        public async Task<IActionResult> CreateDienNuoc([FromBody] DienNuocVM dienNuocVM)
        {
            try
            {
                var _diennuoc = _dienNuocService.AddDienNuocId(dienNuocVM);
                if (_diennuoc != null)
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

        [HttpGet("get-all-diennuoc-phong")]
        public IActionResult GetAllDiennuoc()
        {
            var _phong = _dienNuocService.GetAllNamePhong();
            return Ok(_phong);
        }

        [HttpGet("get-diennuoc")]
        public IActionResult GetDienNuoc()
        {
            var _diennuoc = _dienNuocService.GetDienNuoc();
            return Ok(_diennuoc);
        }

        [HttpPut("update-diennuoc-id")]
        public async Task<IActionResult> UpdateDienNuocId(int diennuocId,[FromBody] DienNuocVM dienNuocVM)
        {
            try
            {
                var _diennuoc = _dienNuocService.UpdateDienNuocId(diennuocId, dienNuocVM);
                if(_diennuoc != null)
                {
                    return Ok(_diennuoc);
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

        [HttpDelete("delete-diennuoc-id/{id}")]
        public async Task<IActionResult> DeleteDienNuocId(int id)
        {
            try
            {
                var _diennuoc = _dienNuocService.DeleteDienNuocId(id);
                if (_diennuoc != null)
                {
                    return Ok("xóa Thành Công");
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
