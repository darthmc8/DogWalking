using DogWalksEvents.Data;
using DogWalksEvents.EntityDefinitios;
using Microsoft.EntityFrameworkCore;

namespace DogWalksEvents.Repository.Commands
{
    /// <summary>
    /// Executes and Upsert process into Client table
    /// </summary>
    public class UpsertClientCommandHandler
    {
        private static DatabaseContext _dbContext;

        public UpsertClientCommandHandler()
        {
            _dbContext = new DatabaseContext();
        }

        /// <summary>
        /// Executes the upsert process.
        /// If the Id value is emtpy, then a new record will be crated.
        /// If the record already exists (id not empty), data will be updated
        /// </summary>
        /// <param name="dbClient"></param>
        /// <returns>Id value from the upserted record</returns>
        public async Task<string> RunUpsert(DBClient dbClient)
        {
            var id = string.IsNullOrEmpty(dbClient.Id) ? Guid.NewGuid().ToString() : dbClient.Id;

            var clientModel = await _dbContext.Clients
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (clientModel == null)
            {
                clientModel = new DBClient { Id = id };
                _dbContext.Clients.Add(clientModel);
            }

            clientModel.FirstName = dbClient.FirstName;
            clientModel.LastName = dbClient.LastName;
            clientModel.PhoneNumber = dbClient.PhoneNumber;

            await _dbContext.SaveChangesAsync();

            return id;
        }
    }
}
