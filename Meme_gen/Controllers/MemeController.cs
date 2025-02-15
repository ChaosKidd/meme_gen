using System.Diagnostics;
using meme_gen.Data;
using meme_gen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace meme_gen.Controllers
{
    public class MemeController : Controller
    {
         private readonly ApplicationDbContext _context;

        public MemeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Meme/Edit/5
        public IActionResult Edit(int id)
        {
            var meme = _context.Memes.FirstOrDefault(m => m.Id == id);
            if (meme == null)
            {
                return NotFound();
            }
            return View(meme);
        }

        // POST: /Meme/SaveEditedMeme
        // Expects JSON with memeId and imageData (base64 string)
        [HttpPost]
        public IActionResult SaveEditedMeme([FromBody] SaveMemeModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.ImageData))
            {
                return Json(new { success = false });
            }

            var meme = _context.Memes.FirstOrDefault(m => m.Id == model.MemeId);
            if (meme == null)
            {
                return NotFound();
            }

            // The imageData is expected to be in the format "data:image/png;base64,..."
            var base64Data = model.ImageData.Split(",")[1];
            var imageBytes = Convert.FromBase64String(base64Data);

            // Generate a unique file name
            var fileName = $"meme_{model.MemeId}_{DateTime.Now.Ticks}.png";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

            System.IO.File.WriteAllBytes(filePath, imageBytes);

            // Optionally update the meme record
            meme.ImagePath = $"/images/{fileName}";
            _context.SaveChanges();

            return Json(new { success = true, imageUrl = meme.ImagePath });
        }
    }    
}