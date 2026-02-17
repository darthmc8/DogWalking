namespace DogWalksEvents.Repository.Queries
{
    /// <summary>
    /// Dog query filter options
    /// </summary>
    public class DogQueryFilter
    {
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public int? Age { get; set; }
    }
}
