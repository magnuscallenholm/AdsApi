using AdsApi.Data;
using AdsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AdsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAll()
        {
            var ads = await _dbContext.Ads.ToListAsync();
            return Ok(ads); // Listan returneras som JSON som statuskod 200 OK
        }
    }
}