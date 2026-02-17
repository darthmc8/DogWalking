using DogWalksEvents.Data;
using DogWalksEvents.EntityDefinitios;
using Microsoft.EntityFrameworkCore;

namespace DogWalksEvents.Repository.Commands
{
    /// <summary>
    /// Executes and Upsert process into Dog table
    /// </summary>
    public class UpsertDogCommandHandler
    {
        private static DatabaseContext _dbContext;

        public UpsertDogCommandHandler()
        {
            _dbContext = new DatabaseContext();
        }

        /// <summary>
        /// Executes the upsert process.
        /// If the Id value is emtpy, then a new record will be crated.
        /// If the record already exists (id not empty), data will be updated
        /// </summary>
        /// <param name="dbDog"></param>
        /// <returns>Id value from the upserted record</returns>
        public async Task<string> RunUpsert(DBDog dbDog)
        {
            var id = string.IsNullOrEmpty(dbDog.Id) ? Guid.NewGuid().ToString() : dbDog.Id;

            var dogModel = await _dbContext.Dogs
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (dogModel == null)
            {
                dogModel = new DBDog { Id = id };
                _dbContext.Dogs.Add(dogModel);
            }

            dogModel.Name = dbDog.Name;
            dogModel.Brand = dbDog.Brand;
            dogModel.Age = dbDog.Age;

            await _dbContext.SaveChangesAsync();

            return id;
        }
    }
}
