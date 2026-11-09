using Microsoft.EntityFrameworkCore;
using AdsApi.Models;

namespace AdsApi.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }
        private void SeedData()
        {            
            if (_dbContext.Ads.Any())
            {
                return;
            }

            _dbContext.Ads.AddRange(
                new Ad
                {
                    CreateDate = DateTime.Now.AddDays(-12),
                    Title = "PlayStation 5 with two controllers",
                    Category = "Consoles",
                    Price = 4500,
                    Description = "Disc edition, barely used. Comes with original box, two DualSense controllers and HDMI cable.",
                    Email = "magnus.callenholm@example.com",
                    Telephone = "070-174 06 05"
                },
                new Ad
                {
                    CreateDate = DateTime.Now.AddDays(-7),
                    Title = "Nintendo Switch OLED",
                    Category = "Consoles",
                    Price = 2800,
                    Description = "White model in great condition. Screen protector applied since day one. Includes dock and charger.",
                    Email = "robert.johansson@example.com",
                    Telephone = null
                },
                new Ad
                {
                    CreateDate = DateTime.Now.AddDays(-3),
                    Title = "The Legend of Zelda: Tears of the Kingdom",
                    Category = "Games",
                    Price = 350,
                    Description = "Nintendo Switch game, complete with case. Played through once.",
                    Email = "henry.brandt@example.com",
                    Telephone = "070-174 06 12"
                },
                new Ad
                {
                    CreateDate = DateTime.Now.AddDays(-1),
                    Title = "Mechanical gaming keyboard",
                    Category = "Accessories",
                    Price = 600,
                    Description = "Full-size keyboard with red switches and RGB lighting. All keys work perfectly.",
                    Email = "mikael.strom@example.com",
                    Telephone = null
                },
                new Ad
                {
                    CreateDate = DateTime.Now,
                    Title = "Two Xbox 360 controllers - free",
                    Category = "Accessories",
                    Price = 0,
                    Description = "Two wired controllers, still working. Free to anyone who picks them up.",
                    Email = "anna.holm@example.com",
                    Telephone = "070-174 06 25"
                }
            );
        }
    }
}