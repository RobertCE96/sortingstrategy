using SortingStrategy.Services.Interfaces;

namespace SortingStrategy.Services
{
    public class FileService : IFileService
    {
        public async Task WriteLinesToFileAsync(string fileName, string[] lines)
        {
            await File.WriteAllLinesAsync("result.txt", lines);
        }

        public string LoadFile(string fileName)
        {
            try
            {
                string contents = File.ReadAllText("result.txt");
                return contents;

            }
            catch (Exception)
            {
                Console.WriteLine("Failed to open file");
            }

            return "";
        }
    }
}
