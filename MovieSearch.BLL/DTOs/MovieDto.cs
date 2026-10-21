namespace MovieSearch.BLL.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string? PosterPath { get; set; }
        public string? Description { get; set; }
    }
}
