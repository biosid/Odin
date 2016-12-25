using Odin.DataContract;
using Odin.Services.Exceptions;
using Odin.Services.LoggingService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Odin.Services.DirectoryService
{
    public class DirectoryService : IDirectoryService
    {
        #region fields

        private readonly string _rootDirectoryPath;

        private readonly ILogginingService _logginingService;

        #endregion

        #region ctor
        public DirectoryService(string rootDirectoryPath, ILogginingService logginingService)
        {
            _rootDirectoryPath = rootDirectoryPath;
            _logginingService = logginingService;
        }
        #endregion

        #region utils
        private DirectoryDto toDto(string parentPath, string fullPath)
        {
            return new DirectoryDto() { ParentPath = parentPath, Path = fullPath };
        }
        #endregion

        public List<DirectoryDto> GetList(string path = "")
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                    path = _rootDirectoryPath;

                var directories = Directory.GetDirectories(path);

                return directories.Select(d => toDto(path, d)).ToList();

            }
            catch (Exception ex)
            {
                _logginingService.LogError(ex, "Error in directory listing");

                throw new BusinessLogicException($"There are some errors while directory listing, try latter. Error Info: {ex.Message}", ex);
            }
        }
    }
}
