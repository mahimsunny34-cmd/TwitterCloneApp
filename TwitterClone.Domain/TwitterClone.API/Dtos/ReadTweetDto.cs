namespace TwitterClone.API.Dtos
{
    public class ReadTweetDto
    {
        public Guid AuthorId { get; set; }
        public string? Content { get; set; }
    }
}
