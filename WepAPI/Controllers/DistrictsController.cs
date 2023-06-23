using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        IDistractService _distractService;
        public DistrictsController(IDistractService distractService)
        {
            _distractService = distractService;
        }
        [HttpGet("")]
        public IActionResult GetDistractByCityId(int cityId)
        {
            var response = _distractService.GetDistractByCityId(cityId);

            if(response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }
}
