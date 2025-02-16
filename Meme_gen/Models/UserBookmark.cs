namespace meme_gen.Models
{
    public class UserBookmark
    {
        public int Id { get; set; }                    // Unique identifier for each bookmark
        public string? UserId { get; set; }             // ID of the user who made the bookmark
        public ApplicationUser? User { get; set; }      // Navigation property to the user
        public int? MemeTemplateId { get; set; }        // ID of the bookmarked template
        public MemeTemplate? MemeTemplate { get; set; } // Navigation property to the template
        public DateTime BookmarkedDate { get; set; }   // When the bookmark was created 
    }
}
