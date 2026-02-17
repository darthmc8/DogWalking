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

            CreateLogFolder();
            ApplicationConfiguration.Initialize();
            Application.Run(new EventsManager());
        }

        private static void CreateLogFolder()
        {
            try
            {
                var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                // This single line creates the directory (and any necessary parent directories) if they don't exist.
                DirectoryInfo di = Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Ensured directory exists: {di.FullName}");
            }
            catch (Exception ex)
            {
                // Handle potential exceptions like permission errors, invalid path, etc.
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}