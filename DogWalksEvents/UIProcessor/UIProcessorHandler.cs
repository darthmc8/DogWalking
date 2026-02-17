using DogWalksEvents.LogProcessor;
using DogWalksEvents.Repository.Commands;
using DogWalksEvents.Repository.DTOs;
using DogWalksEvents.Repository.Queries;
using DogWalksEvents.Repository.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalksEvents.UIProcessor
{
    public class UIProcessorHandler : IDisposable
    {
        private DogWalkEventDTO _dogWalkEventDTO = default!;

        public UIProcessorHandler(DogWalkEventDTO dto)
        {
            _dogWalkEventDTO = dto;
        }

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
                        // Verify if Client data exists
                        var potentialExistingClient = ClientsQueryHandler.GetClientByPhoneNumber(_dogWalkEventDTO.ClientPhoneNumber).GetAwaiter().GetResult();
                        if (potentialExistingClient is not null)
                        {
                            _dogWalkEventDTO.ClientId = potentialExistingClient.Id;
                        }

                        // Verify if Dog data exists
                        var potentialExistingDog = DogsQueryHandler.GetByIdentifiers(_dogWalkEventDTO.DogName, _dogWalkEventDTO.DogBrand, _dogWalkEventDTO.DogAge).GetAwaiter().GetResult();
                        if (potentialExistingDog is not null)
                        {
                            _dogWalkEventDTO.DogId = potentialExistingDog.Id;
                        }

                        // Execute the create command
                        var createCommand = new UpsertWalkEventCommandHandler();
                        var createResult = createCommand.RunUpsert(_dogWalkEventDTO).GetAwaiter().GetResult();

                        processResults.IsValidated = true;
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
                MessageBox.Show("An unexpected error occurred during the create process. Please contact support and try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Handle any unexpected exceptions and log them
                processResults.IsValidated = false;
                processResults.IsCompleted = false;
                processResults.ValidationResults = new List<WalkEventValidationResult>();
                LogProcessorHandler.WriteLog("ProcessError", $"An unexpected error occurred during Create Process: {ex.Message}");

                return processResults;
            }
        }

        public void Dispose()
        {
            _dogWalkEventDTO = default!;
        }
    }
}
