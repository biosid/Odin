using Odin.DataContract;
using System.Collections.Generic;

namespace Odin.Services.FileService
{
    /// <summary>
    /// File service
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Getting a list of files
        /// </summary>
        /// <param name="path">The path to the directory, if the value is not specified, the value of the path taken by default</param>
        /// <returns></returns>
        List<FileDto> GetList(string path);

        /// <summary>
        /// Getting the contents of a file, put a limit on the size of the file is stored in the config app
        /// </summary>
        /// <param name="filePath">The path to the file</param>
        /// <returns></returns>
        FileContentDto GetContent(string filePath);

    }
}
