using Odin.DataContract;
using System.Collections.Generic;

namespace Odin.Services.FileService
{
    public interface IFileService
    {
        List<FileDto> GetList(string path);

        string GetContent(string filePath);

    }
}
