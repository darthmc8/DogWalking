using DogWalksEvents.Repository.Validations;

namespace DogWalksEvents.UIProcessor
{
    /// <summary>
    /// Provides functionality for processing user interface elements and interactions.
    /// </summary>
    /// <remarks>This class serves as a central point for managing UI-related operations, including event
    /// handling and rendering. It is designed to be extended for specific UI implementations.</remarks>
    public class UIProcessor
    {
        public bool IsCompleted { get; set; }
        public bool IsValidated { get; set; }
        public List<WalkEventValidationResult> ValidationResults { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
