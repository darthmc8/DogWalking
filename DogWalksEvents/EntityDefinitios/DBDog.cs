namespace DogWalksEvents.EntityDefinitios
{
    /// <summary>
    /// Represents Dog Database Entity
    /// </summary>
    public class DBDog
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Age { get; set; }
        public ICollection<DBWalkEvent> Events { get; set; }
    }
}