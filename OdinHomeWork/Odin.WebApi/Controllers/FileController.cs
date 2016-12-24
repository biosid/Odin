using Odin.DataContract;
using Odin.Services.DirectoryService;
using Odin.Services.FileService;
using Odin.Services.LoggingService;
using Odin.WebApi.Filters;
using System.Collections.Generic;
using System.Web.Http;
namespace Odin.WebApi.Controllers
{
    [BusinessLogicExceptionFilter]
    public class FileController : ApiController
    {

        #region fields

        private readonly IFileService _fileService;


        #endregion

        #region ctor

        public FileController(IFileService fileService
            )
        {
            _fileService = fileService;
        }

        #endregion
        [HttpGet]
        [Route("File/List")]
        public List<FileDto> List(string path = "")
        {
            return _fileService.GetList(path);
        }

        [HttpGet]
        [Route("File/Content")]
        public string Content(string filePath)
        {
            return _fileService.GetContent(filePath);
        }
    }
}
