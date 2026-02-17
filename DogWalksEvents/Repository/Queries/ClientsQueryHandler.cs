using DogWalksEvents.Data;
using Microsoft.EntityFrameworkCore;

namespace DogWalksEvents.Repository.Queries
{
    /// <summary>
    /// Handler to execute queries and retrieve Client information
    /// </summary>
    public class ClientsQueryHandler : IDisposable
    {
        private DatabaseContext _dbContext;

        public ClientsQueryHandler()
        {
            _dbContext = new DatabaseContext();
        }

        /// <summary>
        /// Executes the query asynchronously
        /// </summary>
        /// <param name="filter">ClientQueryFilter options</param>
        /// <returns>List of ClientsQuery objects with the corresponding data</returns>
        public async Task<List<ClientsQuery>> RunQuery(ClientQueryFilter filter)
        {
            return await _dbContext.Clients
                .Where(c => string.IsNullOrEmpty(filter.FirstName) || c.FirstName.ToUpper().StartsWith(filter.FirstName.ToUpper()))
                .Where(c => string.IsNullOrEmpty(filter.LastName) || c.LastName.ToUpper().StartsWith(filter.LastName.ToUpper()))
                .Where(c => string.IsNullOrEmpty(filter.PhoneNumber) || c.PhoneNumber.ToUpper().StartsWith(filter.PhoneNumber.ToUpper()))
                .Select(c => new ClientsQuery
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber
                })
                .ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a client whose phone number matches the specified value.
        /// </summary>
        /// <remarks>This method queries the underlying data store for a client with the specified phone
        /// number and returns the first match, if any. If no client is found, the result is null.</remarks>
        /// <param name="phoneNumber">The phone number used to identify the client. Must be a valid phone number format.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ClientsQuery object with the
        /// client's details if a matching client is found; otherwise, null.</returns>
        public static async Task<ClientsQuery?> GetClientByPhoneNumber(string phoneNumber)
        {
            using (var context = new DatabaseContext())
            {
                return await context.Clients
                    .Where(c => c.PhoneNumber == phoneNumber)
                    .Select(c => new ClientsQuery
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        PhoneNumber = c.PhoneNumber
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
