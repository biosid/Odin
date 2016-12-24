using Odin.DataContract;
using Odin.Services.DirectoryService;
using Odin.Services.LoggingService;
using Odin.WebApi.Filters;
using System.Collections.Generic;
using System.Web.Http;
namespace Odin.WebApi.Controllers
{
    using System.Web.Http.Cors;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DirectoryController : ApiController
    {

        #region fields

        private readonly IDirectoryService _directoryService;


        #endregion

        #region ctor

        public DirectoryController(
            IDirectoryService directoryService
            )
        {
            _directoryService = directoryService;
        }

        #endregion

        [HttpGet]
        [Route("Directory/List")]
        [BusinessLogicExceptionFilter]
        public List<DirectoryDto> List(string path = "")
        {
            return _directoryService.GetList(path);
        }
    }
}
