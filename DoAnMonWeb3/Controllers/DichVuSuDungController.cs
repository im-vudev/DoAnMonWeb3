using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuSuDungController : ControllerBase
    {
        private DichVuSuDungService _dichVuSuDungService;

        public DichVuSuDungController(DichVuSuDungService dichVuSuDungService)
        {
            _dichVuSuDungService = dichVuSuDungService;
        }

        [HttpGet("get-all-dichvusudung-phong")]
        public IActionResult GetAllPhong()
        {
            var _phong = _dichVuSuDungService.GetAllDichVuPhong();
            return Ok(_phong);
        }

        [HttpGet("get-all-dichvusudung-dichvu")]
        public IActionResult GetDichVu()
        {
            var _dichvu = _dichVuSuDungService.GetAllDichVuVM();
            return Ok(_dichvu);
        }


        [HttpGet("get-dichvusudung-list")]
        public IActionResult GetDichVuSuDung()
        {
            var _dichvusudung = _dichVuSuDungService.GetDichVuSuDung();
            return Ok(_dichvusudung);
        }

        [HttpPost("add-dichvusudung")]
        public IActionResult CreateDichVuSuDung([FromBody] GetDichVuSuDungVM dichVuSuDungVM)
        {
            var _dichvusudung = _dichVuSuDungService.AddDichVuSuDung(dichVuSuDungVM);
            if (_dichvusudung != null)
            {
                return Ok(_dichvusudung);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete-dichvusudung-id")]
        public async Task<IActionResult> DeleteDichVuSuDungId(int dichvuId, int phongId)
        {
            try
            {
                var _dichvu = _dichVuSuDungService.DeleteDichVuSuDungId(dichvuId, phongId);
                if(_dichvu != null)
                {
                    return Ok("xáo tHnahf Công");
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
