using Ninject.Modules;
using Odin.Services.Configuration;
using Odin.Services.DirectoryService;
using Odin.Services.FileService;
using Odin.Services.LoggingService;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Odin.WebApi;
using Odin.WebApi.Controllers;

namespace Odin.WebApi.Tests.DependencyResolution
{
    public class UnitTestingNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogginingService>()
    .To<LogginingService>()
    .InSingletonScope();

            Bind<IDirectoryService>()
    .To<DirectoryService>()
    .InSingletonScope().WithConstructorArgument("rootDirectoryPath", AppSettings.Instance.RootDirectoryPath);


            Bind<IFileService>()
                .To<FileService>()
                .InSingletonScope()
                .WithConstructorArgument("maxFileSize", AppSettings.Instance.MaxFileSize)
                .WithConstructorArgument("rootDirectoryPath", AppSettings.Instance.RootDirectoryPath);

            Bind<DirectoryController>().ToSelf();

            Bind<FileController>().ToSelf();

        }
    }
}