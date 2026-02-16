namespace DogWalksEvents.Repository.DTOs
{
    /// <summary>
    /// DTO to define data to be sent to Upsert Walk Events Handler
    /// </summary>
    public class DogWalkEventDTO
    {
        public string? Id { get; set; }
        public DateOnly WalkDate { get; set; }
        public int Duration { get; set; }
        public string? ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string? DogId { get; set; }
        public string DogName { get; set; }
        public string DogBrand { get; set; }
        public int DogAge { get; set; }
    }
}
