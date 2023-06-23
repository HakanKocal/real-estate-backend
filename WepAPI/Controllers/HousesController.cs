using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        IHouseService _houseService;
        public HousesController(IHouseService houseService)
        {
            _houseService = houseService;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var result = _houseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("")]
        public IActionResult Add(List<IFormFile> file,[FromForm]House house)
        {
            var result=_houseService.Add(file,house);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(House house)
        {
            var result = _houseService.Delete(house);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("")]
        public IActionResult Update([FromForm] House house)
        {
            var result = _houseService.Update(house);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("{id}")]
        public IActionResult ApproveHouse(Guid id)
        {
            var result = _houseService.ApproveHouse(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _houseService.GetByHouseId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(int UserId)
        {
            var result = _houseService.GetByUserId(UserId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("filter")]
        public IActionResult GetByFilter(int minPrice,int maxPrice,Guid categoryId,int minSize,int maxSize, int floor, int room, int cityId, int districtId)
        {
            var result = _houseService.GetByFilterHouse(minPrice, maxPrice, categoryId, minSize,maxSize, floor, room, cityId, districtId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("search")]
        public IActionResult Search(string q)
        {
            var result = _houseService.Search(q);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("favorite")]
        public IActionResult GetFavoriteListByUserId(int userId)
        {
            var result = _houseService.GetFavoriteListByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
