using DogWalksEvents.LogProcessor;
using DogWalksEvents.Repository.Commands;
using DogWalksEvents.Repository.DTOs;
using DogWalksEvents.Repository.Queries;
using DogWalksEvents.Repository.Validations;

namespace DogWalksEvents.UIProcessor
{
    /// <summary>
    /// Handles the processing of dog walk events, including creation and deletion operations, by validating input data
    /// and coordinating related actions.
    /// </summary>
    /// <remarks>This class is responsible for managing the lifecycle of dog walk events within the user
    /// interface layer. It validates event data before creation, manages logging for both successful and failed
    /// operations, and provides user feedback through message dialogs. The class implements IDisposable to release
    /// resources when processing is complete. Thread safety is not guaranteed; instances should not be shared across
    /// threads.</remarks>
    public class UIProcessorHandler : IDisposable
    {
        private DogWalkEventDTO _dogWalkEventDTO = default!;
        private readonly IMessageService _messageService;

        public UIProcessorHandler(DogWalkEventDTO dto) : this(dto, new MessageBoxMessageService())
        {
        }

        // Constructor overload that accepts a message service to allow tests to suppress UI interaction
        public UIProcessorHandler(DogWalkEventDTO dto, IMessageService messageService)
        {
            _dogWalkEventDTO = dto;
            _messageService = messageService ?? new MessageBoxMessageService();
        }

        /// <summary>
        /// Processes the creation of a dog walking event by validating input data and executing the create operation.
        /// </summary>
        /// <remarks>This method validates the provided dog walking event data and attempts to create a
        /// new event if validation succeeds. If validation fails, the returned UIProcessor includes details of the
        /// validation errors. In the event of an unexpected error, the method logs the error and returns a UIProcessor
        /// indicating the failure. The method also attempts to associate existing client and dog records based on the
        /// provided information before creating the event.</remarks>
        /// <returns>A UIProcessor instance containing the results of the create operation, including validation status,
        /// completion status, and any validation errors encountered.</returns>
        public UIProcessor ProcessCreate()
        {
            var processResults = new UIProcessor();

            try
            {
                using (var validator = new WalkEventValidator(_dogWalkEventDTO))
                {
                    var validationResults = validator.Validate();
                    if (validationResults.Count > 0)
                    {
                        // Validation failed, set the processor results accordingly
                        processResults.IsValidated = false;
                        processResults.IsCompleted = false;
                        processResults.ValidationResults = validationResults;

                        //Creates a log entry for each validation error
                        foreach (var validationResult in validationResults)
                        {
                            LogProcessorHandler.WriteLog("ValidationError", $"Validation failed for control: {validationResult.ControlName}, message: {validationResult.Message}");
                        }
                    }
                    else
                    {
                        // Validation succeeded, run the create command and set the processor results accordingly
                        processResults.IsValidated = true;

                        // Verify if Client data exists (wrapped in virtual methods to allow unit testing)
                        var potentialExistingClient = GetClientByPhone(_dogWalkEventDTO.ClientPhoneNumber).GetAwaiter().GetResult();
                        if (potentialExistingClient is not null)
                        {
                            _dogWalkEventDTO.ClientId = potentialExistingClient.Id;
                        }

                        // Verify if Dog data exists
                        var potentialExistingDog = GetDogByIdentifiers(_dogWalkEventDTO.DogName, _dogWalkEventDTO.DogBrand, _dogWalkEventDTO.DogAge).GetAwaiter().GetResult();
                        if (potentialExistingDog is not null)
                        {
                            _dogWalkEventDTO.DogId = potentialExistingDog.Id;
                        }

                        // Execute the create command
                        var createResult = RunUpsertWalkEvent(_dogWalkEventDTO).GetAwaiter().GetResult();

                        processResults.IsCompleted = true;
                        processResults.ValidationResults = new List<WalkEventValidationResult>();

                        // Log a success message
                        LogProcessorHandler.WriteLog("ProcessSuccess", "Create process succeeded for the provided DogWalkEventDTO.");
                    }
                }

                return processResults;
            }
            catch (Exception ex)
            {
                _messageService.ShowError("An unexpected error occurred during the create process. Please contact support and try again later.", "Error");
                // Handle any unexpected exceptions and log them
                processResults.IsCompleted = false;
                processResults.ValidationResults = new List<WalkEventValidationResult>();
                LogProcessorHandler.WriteLog("ProcessError", $"An unexpected error occurred during Create Process: {ex.Message}");

                return processResults;
            }
        }

        /// <summary>
        /// Processes the deletion of a dog walking event by sending selected data and executing the delete operation.
        /// </summary>
        /// <returns></returns>
        public async Task ProcessDelete()
        {
            try
            {
                await RunDeleteWalkEvent(_dogWalkEventDTO.Id);
                _messageService.ShowInfo("Walk Event deleted successfully.", "Success");
                LogProcessorHandler.WriteLog("ProcessSuccess", "Delete process succeeded for the provided DogWalkEventDTO.");
            }
            catch (Exception ex)
            {
                _messageService.ShowError("An error occurred while trying to delete the Walk Event. Please contact support and try again later.", "Error");
                LogProcessorHandler.WriteLog("ProcessError", $"An error occurred during Delete Process: {ex.Message}");
            }
        }

        // Protected virtual wrapper methods so unit tests can override behavior without touching static DB methods
        protected virtual Task<Repository.Queries.ClientsQuery?> GetClientByPhone(string phoneNumber)
        {
            return Repository.Queries.ClientsQueryHandler.GetClientByPhoneNumber(phoneNumber);
        }

        protected virtual Task<Repository.Queries.DogsQuery?> GetDogByIdentifiers(string name, string brand, int age)
        {
            return Repository.Queries.DogsQueryHandler.GetByIdentifiers(name, brand, age);
        }

        protected virtual Task<string> RunUpsertWalkEvent(Repository.DTOs.DogWalkEventDTO dto)
        {
            return new UpsertWalkEventCommandHandler().RunUpsert(dto);
        }

        protected virtual Task RunDeleteWalkEvent(string id)
        {
            return DeleteWalkEventCommandHandler.RunDelete(id);
        }

        /// <summary>
        /// Abstraction for showing messages. Default implementation uses MessageBox but tests can provide a no-op implementation.
        /// </summary>
        public interface IMessageService
        {
            void ShowInfo(string message, string title);
            void ShowError(string message, string title);
        }

        private class MessageBoxMessageService : IMessageService
        {
            public void ShowInfo(string message, string title)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public void ShowError(string message, string title)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Dispose()
        {
            _dogWalkEventDTO = default!;
        }
    }
}
