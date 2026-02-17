using DogWalksEvents.Data;
using Microsoft.EntityFrameworkCore;

namespace DogWalksEvents.Repository.Commands
{
    /// <summary>
    /// Delete Walk Event handler class
    /// </summary>
    public class DeleteWalkEventCommandHandler
    {
        /// <summary>
        /// Executes the Walk Event delete process.
        /// </summary>
        /// <param name="WalkEventId">Walk Event Id to be deleted</param>
        /// <returns></returns>
        /// <exception cref="Exception">Occurs when Id dos not exists in database</exception>
        public static async Task RunDelete(string WalkEventId)
        {
            using (var _dbContext = new DatabaseContext())
            {
                var eventToDelete = await _dbContext.WalkEvents
                    .Where(e => e.Id == WalkEventId)
                    .FirstOrDefaultAsync();

                if (eventToDelete is null)
                {
                    throw new Exception("Walk Event does not exitst.");
                }

                _dbContext.WalkEvents.Remove(eventToDelete);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
