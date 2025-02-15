using meme_gen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace meme_gen.Data
{
    public static class DbSeeder
    {
        public static void SeedMemes(ApplicationDbContext context)
        {
            if (!context.Memes.Any())  // Only seed if database is empty
            {
                context.Memes.AddRange(
                    new MemeTemplate
                    {
                        ImagePath = "/images/meme_1.jpeg",
                        DateAdded = DateTime.Now
                    },
                    new MemeTemplate
                    {
                        ImagePath = "/images/meme_2.jpeg",
                        DateAdded = DateTime.Now
                    },
                    new MemeTemplate
                    {
                        ImagePath = "/images/meme_3.jpg",
                        DateAdded = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }

}