using Ninject.Modules;
using Odin.Services.Configuration;
using Odin.Services.DirectoryService;
using Odin.Services.FileService;
using Odin.Services.LoggingService;

namespace Odin.Infrastructure.DependencyResolution
{
    public class CommonNinjectModule : NinjectModule
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
        }
    }
}