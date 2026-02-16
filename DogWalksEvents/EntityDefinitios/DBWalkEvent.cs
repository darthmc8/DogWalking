namespace DogWalksEvents.EntityDefinitios
{
    /// <summary>
    /// Represents Walk Event database entity
    /// </summary>
    public class DBWalkEvent
    {
        public string Id { get; set; }
        public DateOnly WalkDate { get; set; }
        public int? Duration { get; set; }
        public string ClientId { get; set; }
        public string DogId { get; set; }
        public DBClient Client { get; set; }
        public DBDog Dog { get; set; }
    }
}
