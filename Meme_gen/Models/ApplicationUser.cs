using Microsoft.AspNetCore.Identity;

namespace meme_gen.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserBookmark>? Bookmarks { get; set; }    // List of all user's bookmarks

    }
}
