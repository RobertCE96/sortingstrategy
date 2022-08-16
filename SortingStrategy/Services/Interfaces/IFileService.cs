namespace SortingStrategy.Services.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Loads file and returns contents as string
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string LoadFile(string fileName);

        /// <summary>
        /// Writes lines to a file based on file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        public Task WriteLinesToFileAsync(string fileName, string[] lines);
    }
}
