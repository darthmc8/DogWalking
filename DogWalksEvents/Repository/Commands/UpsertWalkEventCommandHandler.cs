using DogWalksEvents.Data;
using DogWalksEvents.EntityDefinitios;
using DogWalksEvents.Repository.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DogWalksEvents.Repository.Commands
{
    /// <summary>
    /// Executes and Upsert process into Walk Events table
    /// </summary>
    public class UpsertWalkEventCommandHandler
    {
        private static DatabaseContext _dbContext;
        private static UpsertClientCommandHandler _upsertClientCommand;
        private static UpsertDogCommandHandler _upsertDogCommandHandler;

        public UpsertWalkEventCommandHandler()
        {
            _dbContext = new DatabaseContext();
            _upsertClientCommand = new UpsertClientCommandHandler();
            _upsertDogCommandHandler = new UpsertDogCommandHandler();
        }

        /// <summary>
        /// Executes the upsert process.
        /// If the Id value is emtpy, then a new record will be crated.
        /// If the record already exists (id not empty), data will be updated
        /// </summary>
        /// <param name="dbDog"></param>
        /// <returns>Id value from the upserted record</returns>
        public async Task<string> RunUpsert(DogWalkEventDTO dto)
        {
            var clientData = new DBClient
            {
                Id = dto.ClientId,
                FirstName = dto.ClientFirstName,
                LastName = dto.ClientLastName,
                PhoneNumber = dto.ClientPhoneNumber,
            };

            var dogData = new DBDog
            {
                Id = dto.DogId,
                Name = dto.DogName,
                Brand = dto.DogBrand,
                Age = dto.DogAge,
            };

            var clientId = SaveClientData(clientData).Result;
            var dogId = SaveDogData(dogData).Result;

            var id = string.IsNullOrEmpty(dto.Id) ? Guid.NewGuid().ToString() : dto.Id;

            var eventModel = await _dbContext.WalkEvents
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (eventModel == null)
            {
                eventModel = new DBWalkEvent { Id = id };
                _dbContext.WalkEvents.Add(eventModel);
            }

            eventModel.WalkDate = dto.WalkDate;
            eventModel.Duration = dto.Duration;
            eventModel.ClientId = clientId;
            eventModel.DogId = dogId;

            await _dbContext.SaveChangesAsync();

            return id;
        }

        private async Task<string> SaveClientData(DBClient dbClient)
        {
            return await _upsertClientCommand.RunUpsert(dbClient);
        }

        private async Task<string> SaveDogData(DBDog dBDog)
        {
            return await _upsertDogCommandHandler.RunUpsert(dBDog);
        }
    }
}
