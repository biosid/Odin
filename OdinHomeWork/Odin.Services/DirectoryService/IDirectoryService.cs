using Odin.DataContract;
using System.Collections.Generic;

namespace Odin.Services.DirectoryService
{
    public interface IDirectoryService
    {
        List<DirectoryDto> GetList(string path);
    }
}
