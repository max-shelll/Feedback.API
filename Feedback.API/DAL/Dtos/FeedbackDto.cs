namespace Feedback.API.DAL.Dtos
{
    public class FeedbackDto
    {
        public string Author { get; set; }

        public string? Organisation { get; set; }

        public string Description { get; set; }

        public int Rate { get; set; }
    }
}
