namespace API.Models
{
    public class Activity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public string Venue { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
