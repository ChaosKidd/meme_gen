using System.Diagnostics;
using meme_gen.Data;
using meme_gen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace meme_gen.Controllers
{
    public class MemeController : Controller
    {
         private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public MemeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

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

        [HttpGet]
        public async Task<IActionResult> MyBookmarks()
        {
            if (User?.Identity == null || !User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account"); // Redirect if user is not logged in
            }

            var userId = _userManager.GetUserId(User);

            var bookmarks = await _context.UserBookmarks
                .Where(b => b.UserId == userId)
                .Include(b => b.MemeTemplate) // Load related meme data
                .ToListAsync();

            return View(bookmarks);
        }


        // Toggle bookmark: adds or removes a bookmark for the current user
        [HttpPost]
        public async Task<IActionResult> ToggleBookmark([FromBody] BookmarkRequest request)
        {
            if (User?.Identity == null || !User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "User not logged in." });
            }

            var userId = _userManager.GetUserId(User);
            var meme = await _context.Memes.FindAsync(request.MemeId);
            if (meme == null)
            {
                return Json(new { success = false, message = "Meme not found." });
            }

            var existingBookmark = await _context.UserBookmarks
                .FirstOrDefaultAsync(b => b.UserId == userId && b.MemeTemplateId == request.MemeId);

            if (existingBookmark != null)
            {
                // Remove bookmark
                _context.UserBookmarks.Remove(existingBookmark);
                await _context.SaveChangesAsync();
                return Json(new { success = true, bookmarked = false, message = "Bookmark removed!" });
            }
            else
            {
                // Add new bookmark
                var bookmark = new UserBookmark
                {
                    UserId = userId,
                    MemeTemplateId = request.MemeId,
                    BookmarkedDate = DateTime.Now
                };
                _context.UserBookmarks.Add(bookmark);
                await _context.SaveChangesAsync();
                return Json(new { success = true, bookmarked = true, message = "Meme bookmarked!" });
            }
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