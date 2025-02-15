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
                var memes = new List<MemeTemplate>();

                for (int i = 1; i <= 38; i++)
                {
                    memes.Add(new MemeTemplate
                    {
                        ImagePath = $"/images/meme_{i}.jpg",
                        DateAdded = DateTime.Now
                    });
                }

                context.Memes.AddRange(memes);
                context.SaveChanges();
            }
        }
    }
}
