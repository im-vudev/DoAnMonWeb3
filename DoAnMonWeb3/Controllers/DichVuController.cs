using DoAnMonWeb3.Models;
using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuController : ControllerBase
    {
        private DichVuService _dichVuService;


        public DichVuController(DichVuService dichVuService)
        {
            _dichVuService = dichVuService;
        }


        [HttpPost("Create-dichvu")]
        public IActionResult CreateDichVu([FromBody] DichVuVM dichVuVM)
        {
            try
            {
                _dichVuService.AddDichVu(dichVuVM);
                return Ok("Thêm Thành Công");
            }
            catch (Exception exx)
            {

                return BadRequest(exx.Message);
            }
        }

        [HttpGet("get-dichvu-list")]
        public IActionResult GetDichVu()
        {
            try
            {
                var _dichvu = _dichVuService.GetDichVus();
                return Ok(_dichvu);
            }
            catch (Exception exx)
            {

                return BadRequest(exx.Message);
            }
        }

        [HttpGet("get-dichvu-id/{id}")]
        public IActionResult GetDichVuId(int id)
        {
            try
            {
                var _response = _dichVuService.GetDichVuId(id);
                return Ok(_response);
            }
            catch (Exception exx)
            {

                return BadRequest(exx.Message);
            }
        }


        [HttpPut("Update-dichvu-id")]
        public async Task<IActionResult> UpdateDichVuId(int dichvuid, [FromBody] DichVuVM dichVuVM)
        {
            try
            {
                var _dichvu = _dichVuService.UpdateDichVuId(dichvuid, dichVuVM);
                if(_dichvu != null)
                {
                    return Ok(_dichvu);
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

        [HttpDelete("Delete-dichvu-id/{id}")]
        public IActionResult DeleteDichvuId(int id)
        {
            try
            {
                var _dichvu = _dichVuService.DeleteDichvuId(id);
                if(_dichvu != null)
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
