using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        IFavoriteHouseSerivice _favoriteHouseSerivice;
        public FavoritesController(IFavoriteHouseSerivice favoriteHouseSerivice)
        {
            _favoriteHouseSerivice = favoriteHouseSerivice;
        }
        [HttpPost("")]
        public IActionResult AddOrDelete([FromForm] FavoriteHouse favoriteHouse)
        {
            var response = _favoriteHouseSerivice.AddOrDelete(favoriteHouse);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var responses = _favoriteHouseSerivice.GetAll();
            if (responses.Success)
            {
                return Ok(responses);
            }
            return BadRequest(responses);
        }
        [HttpGet("{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var responses = _favoriteHouseSerivice.GetByUserId(userId);
            if (responses.Success)
            {
                return Ok(responses);
            }
            return BadRequest(responses);
        }
    }
}
