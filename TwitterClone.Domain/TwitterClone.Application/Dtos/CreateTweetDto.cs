namespace TwitterClone.API.Dtos
{
    public class CreateTweetDto
    {
        public Guid AuthorId { get; set; }
        public string? Content { get; set; }
    }
}
