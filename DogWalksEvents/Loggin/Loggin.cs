using System.IO;
using System.Reflection;

namespace DogWalksEvents.Loggin
{
    /// <summary>
    /// Class to write logs across the application
    /// </summary>
    public class Loggin
    {
        private static string _filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Logs/EventsLog.txt";

        /// <summary>
        /// Writes LogMessage string in a log file allocated in _filePath
        /// </summary>
        /// <param name="LogMessage">Message to be log</param>
        public static void WriteLog(string type, string logMessage)
        {
            try
            {
                // Pass the file path and optionally 'true' to append data (default is false, which overwrites)
                using (StreamWriter sw = new StreamWriter(_filePath, true))
                {
                    sw.WriteLine(string.Format("{0}|Type: {1}|Message: {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), type, logMessage));
                }
                Console.WriteLine($"{logMessage} written in Log file.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}
