using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.DataLayer.Models
{
    [Table("user_ratings")] // Matcher tabellen i databasen
    public class UserRating
    {
        [Key]
        [Column("rating_id")]
        public int RatingId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("tconst")]
        public string Tconst { get; set; }

        [Column("rating")]
        public decimal Rating { get; set; }
    }
}
