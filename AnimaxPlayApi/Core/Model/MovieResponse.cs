namespace AnimaxPlayApi.Core.Model
{
    public class MovieResponse
    {
        public int Page { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
        public List<Movie> Results { get; set; } = new();
    }
}
