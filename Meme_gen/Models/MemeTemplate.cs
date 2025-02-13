namespace meme_gen.Models
{
    public class MemeTemplate
    {
    public int Id { get; set; }                    // Unique identifier for each template
    public string? Title { get; set; }              // Name/title of the meme template
    public string? ImagePath { get; set; }          // Path to the original template image in wwwroot
    public DateTime DateAdded { get; set; }        // When the template was added to the system
    }
}
