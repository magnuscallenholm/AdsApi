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
            return Ok(ads);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ad>> GetById(int id)
        {
            var ad = await _dbContext.Ads.FirstOrDefaultAsync(a => a.Id == id);
            if (ad == null)
            {
                return NotFound();
            }
            return Ok(ad);
        }

        [HttpPost]
        public async Task<ActionResult<Ad>> Create(Ad ad)
        {
            Ad newAd = new Ad
            {
                CreateDate = DateTime.Now,
                Title = ad.Title,
                Category = ad.Category,
                Price = ad.Price,
                Description = ad.Description,
                Email = ad.Email,
                Telephone = ad.Telephone
            };

            _dbContext.Ads.Add(newAd);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newAd.Id }, newAd);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Ad ad)
        {
            var existingAd = await _dbContext.Ads.FirstOrDefaultAsync(a => a.Id == id);

            if (existingAd == null)

            {
                return NotFound();
            }

            existingAd.Title = ad.Title;
            existingAd.Category = ad.Category;
            existingAd.Price = ad.Price;
            existingAd.Description = ad.Description;
            existingAd.Email = ad.Email;
            existingAd.Telephone = ad.Telephone;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteAd = await _dbContext.Ads.FirstOrDefaultAsync(a => a.Id == id);

            if (deleteAd == null)
            {
                return NotFound();
            }

            _dbContext.Ads.Remove(deleteAd);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}