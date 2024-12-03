namespace MovieApp.DataLayer.Models
{
    public class SearchHistory
    {
        public int SearchId { get; set; }
        public int UserId { get; set; }
        public string SearchTerm { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
