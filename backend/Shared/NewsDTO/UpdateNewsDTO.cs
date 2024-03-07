namespace Shared.NewsDTO
{
    public record UpdateNewsDTO : NewsBaseDTO
    {

        public DateTime UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
