using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayTroController : ControllerBase
    {
        private DayTroService _dayTroService;

        public DayTroController(DayTroService dayTroService)
        {
            _dayTroService = dayTroService;
        }

        [HttpPost("Add-DayTro")]
        public IActionResult AddDayTro([FromBody] DayTroVM dayTroVM)
        {
            try
            {
               var _daytro = _dayTroService.AddDayTro(dayTroVM);
               
                return Ok(_daytro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-daytro-list")]
        public IActionResult GetDayTro()
        {
            try
            {
                var _daytro = _dayTroService.GetDayTros();
                return Ok(_daytro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-daytro-id/{id}")]
        public IActionResult GetDaytroId(int id)
        {
            var _response = _dayTroService.GetDayTros(id);

            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("Update-daytro-id")]
        public async Task<IActionResult> UpdateDayTroId(int daytroId, [FromBody] DayTroVM dayTroVM)
        {
            try
            {
                var _daytro =  _dayTroService.UpdateDayTroId(daytroId, dayTroVM);
                
                if (_daytro != null)
                {
                    return Ok(_daytro);
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

        [HttpDelete("Delete-daytro-id/{id}")]
        public async Task<IActionResult> DeleteDayTroId(int id)
        {
            try
            {
                _dayTroService.DeleteDaTroId(id);
               
                return Ok("Đã Xóa");

            }
            catch (Exception ex)
            {
 
                return BadRequest(ex.Message);
            }
        }
    }
}
