namespace DogWalksEvents.EntityDefinitios
{
    /// <summary>
    /// Represents Client Database Entity
    /// </summary>
    public class DBClient
    {
        public string? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<DBWalkEvent> Events { get; set; }
    }
}
