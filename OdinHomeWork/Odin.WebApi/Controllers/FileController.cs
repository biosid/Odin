using Odin.DataContract;
using Odin.Services.FileService;
using Odin.WebApi.Filters;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Odin.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        public FileContentDto Content(string filePath)
        {
            return _fileService.GetContent(filePath);
        }
    }
}
