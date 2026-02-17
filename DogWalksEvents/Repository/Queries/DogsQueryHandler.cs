using DogWalksEvents.Data;
using Microsoft.EntityFrameworkCore;

namespace DogWalksEvents.Repository.Queries
{
    /// <summary>
    /// Handler to execute queries and retrieve Dog information
    /// </summary>
    public class DogsQueryHandler : IDisposable
    {
        private DatabaseContext _dbContext;

        public DogsQueryHandler()
        {
            _dbContext = new DatabaseContext();
        }

        /// <summary>
        /// Executes the query asynchronously
        /// </summary>
        /// <param name="filter">DogQueryFilter options</param>
        /// <returns>List of DogsQuery objects with the corresponding data</returns>
        public async Task<List<DogsQuery>> RunQuery(DogQueryFilter filter)
        {
            return await _dbContext.Dogs
                .Where(d => string.IsNullOrEmpty(filter.Name) || d.Name.ToUpper().StartsWith(filter.Name.ToUpper()))
                .Where(d => string.IsNullOrEmpty(filter.Brand) || d.Brand.ToUpper().StartsWith(filter.Brand.ToUpper()))
                .Where(d => filter.Age.Equals(null) || d.Age == filter.Age)
                .Select(d => new DogsQuery
                {
                    Id = d.Id,
                    Name = d.Name,
                    Brand = d.Brand,
                    Age = d.Age
                })
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a dog record by its unique combined identifier.
        /// </summary>
        /// <remarks>This method queries the database for a dog with the specified identifier. If no dog
        /// is found, the method returns null.</remarks>
        /// <param name="name">The name identifier of the dog to retrieve. This parameter cannot be null or empty.</param>
        /// /// <param name="brand">The brand identifier of the dog to retrieve. This parameter cannot be null or empty.</param>
        /// /// <param name="age">The age identifier of the dog to retrieve. This parameter cannot be null or empty.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="DogsQuery"/> object
        /// representing the dog if found; otherwise, null.</returns>
        public static async Task<DogsQuery?> GetByIdentifiers(string name, string brand, int age)
        {
            using (var context = new DatabaseContext())
            {
                return await context.Dogs
                    .Where(d => d.Name == name)
                    .Where(d => d.Brand == brand)
                    .Where(d => d.Age == age)
                    .Select(d => new DogsQuery
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Brand = d.Brand,
                        Age = d.Age
                    })
                    .FirstOrDefaultAsync();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
