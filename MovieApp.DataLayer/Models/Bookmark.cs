namespace MovieApp.DataLayer.Models
{
    public class Bookmark
    {
        public int BookmarkId { get; set; } // Primary Key
        public int UserId { get; set; } // Bruger ID
        public string ItemType { get; set; } // Type (film, serie)
        public string ItemId { get; set; } // Film- eller serie-ID
        public string Annotation { get; set; } // Noter
    }
}
