namespace DogWalksEvents.Repository.Queries
{
    /// <summary>
    /// Dog walk event query strucuture
    /// </summary>
    public class DogWalkEventsQuery
    {
        public string Id { get; set; }
        public DateOnly WalkDate { get; set; }
        public int Duration { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string PhoneNumber { get; set; }
        public string DogName { get; set; }
        public string DogBrand { get; set; }
        public int DogAge { get; set; }
    }
}
