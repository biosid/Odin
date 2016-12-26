using Odin.DataContract;
using System.Collections.Generic;

namespace Odin.Services.DirectoryService
{
    /// <summary>
    /// Service for working with directories
    /// </summary>
    public interface IDirectoryService
    {
        /// <summary>
        /// Gets a list of directories in the current path
        /// </summary>
        /// <param name="path">The file path, if no path is specified the default value is taken</param>
        /// <returns></returns>
        List<DirectoryDto> GetList(string path);
    }
}
