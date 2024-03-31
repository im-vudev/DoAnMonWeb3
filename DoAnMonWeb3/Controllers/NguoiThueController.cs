using DoAnMonWeb3.Models;
using DoAnMonWeb3.Service;
using DoAnMonWeb3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonWeb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiThueController : ControllerBase
    {
        private NguoiThueService _nguoithueservice;

        public NguoiThueController(NguoiThueService nguoithueservice)
        {
            _nguoithueservice = nguoithueservice;
        }


        [HttpPost("create-nguoithue-id")]
        public async Task<IActionResult> CreateNguoiThue([FromForm] NguoiThueVM nguoiThueVM, [FromForm] ImageUploadModel imageModel)
        {
            try
            {
                var result = await _nguoithueservice.CreateNguoiThue(nguoiThueVM, imageModel.AnhDaiDien, imageModel.MatTruocCCCD, imageModel.MatSauCMND);
                if(result != null)
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
                     
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("get-all-nguoithue-list")]
        public IActionResult GetAllNguoiThue()
        {
            try
            {
                var _nguoiThue = _nguoithueservice.GetAllNguoiThue();
                if(_nguoiThue != null)
                {
                    return Ok(_nguoiThue);
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

        [HttpDelete("delete-nguoithue-id/{id}")]
        public IActionResult DeleteNguoiThue(int id)
        {
            _nguoithueservice.DeleteNguoiThue(id);
            return Ok();
        }

    }
}

