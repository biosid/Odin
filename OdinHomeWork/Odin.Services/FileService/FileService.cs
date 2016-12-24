using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odin.DataContract;
using Odin.Services.LoggingService;
using System.IO;
using System.Linq.Expressions;
using Odin.Services.Exceptions;

namespace Odin.Services.FileService
{
    public class FileService : IFileService
    {

        #region fields

        private readonly string _rootDirectoryPath;

        private readonly ILogginingService _logginingService;

        private readonly long _maxFileSize;

        #endregion

        #region ctor

        public FileService(
            string rootDirectoryPath,
            long maxFileSize,
            ILogginingService logginingService)
        {
            _rootDirectoryPath = rootDirectoryPath;
            _logginingService = logginingService;
            _maxFileSize = maxFileSize;
        }

        #endregion

        #region utils

        private readonly Expression<Func<FileInfo, FileDto>> _mapFile = info => new FileDto()
        {
            Create = info.CreationTime.ToLongDateString(),
            Extension = info.Extension,
            Modify = info.LastWriteTime.ToLongDateString(),
            Name = info.Name,
            Path = info.FullName,
            Size = info.Length
        };

        #endregion

        public string GetContent(string filePath)
        {
            try
            {
                var file = new FileInfo(filePath);

                if (file == null)
                    throw new BusinessLogicException("File does not exist");

                if (file.Length > _maxFileSize)
                    throw new BusinessLogicException("File is too large");

                var content = File.ReadAllText(filePath);

                return content;
            }
            catch (BusinessLogicException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logginingService.LogError(ex, "Error in files listing");

                throw new BusinessLogicException("There are some errors while files listing, try latter", ex);
            }
        }

        public List<FileDto> GetList(string path = "")
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                var files = directory.GetFiles().AsQueryable().Select(_mapFile).ToList();
                return files;
            }
            catch (Exception ex)
            {
                _logginingService.LogError(ex, "Error in files listing");

                throw new BusinessLogicException("There are some errors while files listing, try latter", ex);
            }

        }
    }
}
