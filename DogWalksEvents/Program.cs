using DogWalksEvents.Data;
using Microsoft.EntityFrameworkCore;

namespace DogWalksEvents
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            using (var context = new DatabaseContext())
            {
                // Ensure the database is created
                context.Database.EnsureCreated();
            }

                ApplicationConfiguration.Initialize();
            Application.Run(new EventsManager());
        }
    }
}