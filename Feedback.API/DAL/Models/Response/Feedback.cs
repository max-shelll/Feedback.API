namespace Feedback.API.DAL.Models.Response
{
    public class Feedback
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Author { get; set; }

        public string? Organisation { get; set; }

        public string Description { get; set; }

        public int Rate { get; set; }
    }
}
