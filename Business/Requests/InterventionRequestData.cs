namespace Business.Requests
{
    public class InterventionRequestData
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string InterventionTypeName { get; set; }
        public required DateTime DateTime { get; set; }
    }
}
