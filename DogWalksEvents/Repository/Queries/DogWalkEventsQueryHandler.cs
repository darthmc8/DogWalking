using DogWalksEvents.Data;
using Microsoft.EntityFrameworkCore;

namespace DogWalksEvents.Repository.Queries
{
    /// <summary>
    /// Handler to execute queries ad retrieve DOg walk events information
    /// </summary>
    public class DogWalkEventsQueryHandler : IDisposable
    {
        private DatabaseContext _dbContext;

        public DogWalkEventsQueryHandler()
        {
            _dbContext = new DatabaseContext(); 
        }

        /// <summary>
        /// Executes the query asynchronously
        /// </summary>
        /// <param name="filter">DogWalkEventQueryFilter options</param>
        /// <returns>List of DogWalkEventsQuery objects with the corresponding data</returns>
        public async Task<List<DogWalkEventsQuery>> RunQuery(DogWalkEventQueryFilter filter)
        {
            return await _dbContext.WalkEvents
                .Where(x => filter.WalkDate.Equals(null) || x.WalkDate.Equals(filter.WalkDate))
                .Where(x => string.IsNullOrEmpty(filter.ClientFirstName) || x.Client.FirstName.ToUpper().StartsWith(filter.ClientFirstName.ToUpper()))
                .Where(x => string.IsNullOrEmpty(filter.ClientLastName) || x.Client.LastName.ToUpper().StartsWith(filter.ClientLastName.ToUpper()))
                .Where(x => string.IsNullOrEmpty(filter.DogName) || x.Dog.Name.ToUpper().Equals(filter.DogName.ToUpper()))
                .Where(x => string.IsNullOrEmpty(filter.DogBrand) || x.Dog.Brand.ToUpper().Equals(filter.DogBrand.ToUpper()))
                .Where(x => filter.DogAge.Equals(null) || x.Dog.Age.Equals(filter.DogAge))
                .Select(x => new DogWalkEventsQuery
                {
                    Id = x.Id,
                    WalkDate = x.WalkDate,
                    Duration = x.Duration,
                    ClientId = x.ClientId,
                    ClientFirstName = x.Client.FirstName,
                    ClientLastName = x.Client.LastName,
                    PhoneNumber = x.Client.PhoneNumber,
                    DogId = x.DogId,
                    DogName = x.Dog.Name,
                    DogBrand = x.Dog.Brand,
                    DogAge = x.Dog.Age,
                })
                .ToListAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
