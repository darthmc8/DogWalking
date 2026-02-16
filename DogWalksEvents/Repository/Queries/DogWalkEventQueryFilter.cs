namespace DogWalksEvents.Repository.Queries
{
    /// <summary>
    /// Dog walk events query filter options
    /// </summary>
    public class DogWalkEventQueryFilter
    {
        public DateOnly? WalkDate { get; set; }
        public string? ClientFirstAndLastName { get; set; }
        public string? DogName { get; set; }
        public string? DogBrand { get; set; }
        public int? DogAge { get; set; }
    }
}
