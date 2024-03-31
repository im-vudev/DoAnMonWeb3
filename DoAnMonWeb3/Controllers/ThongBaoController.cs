using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        private readonly ThongBaoService _thongBaoService;

        public ThongBaoController(ThongBaoService thongBaoService)
        {
            _thongBaoService = thongBaoService;
        }

        [HttpPost("create-thongbao-id")]
        public IActionResult CreateAdd([FromBody] ThongBaoVM thongBaoVM)
        {
            try
            {
                var result = _thongBaoService.CreateThongBaoAsync(thongBaoVM);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-thongbao-all")]
        public IActionResult GetAllThongBao()
        {
            var thongBao = _thongBaoService.GetallThongBao();
            return Ok(thongBao);
        }

        [HttpGet("get-thongbao-id/{id}")]
        public IActionResult GetThongBaoId(int id)
        {
            var thongBao = _thongBaoService.GetThongBaoAsync(id);

            return Ok(thongBao);
        }

        [HttpPut("update-thongbao-id/{id}")]
        public IActionResult Update(int id, [FromBody] ThongBaoVM thongBaoVM)
        {
            try
            {
                var result = _thongBaoService.UpdateThongBaoAsync(id, thongBaoVM);
                if (result != null)
                {
                    return Ok(result);
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

        [HttpDelete("delete-thongbao-id/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _thongBaoService.DeleteThongBaoAsync(id);
                if (result != null)
                {
                    return Ok(result);
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
