using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Odin.WebApi;
using Odin.WebApi.Controllers;
using Ninject;
using Odin.WebApi.Tests.DependencyResolution;
using System.Linq;

namespace Odin.WebApi.Tests.Controllers
{
    [TestClass]
    public class ComplexControllersTets
    {
        /// <summary>
        /// Получаем список файлов по-умолчанию, у первой директории поднимаем список файлов, подразумевавем что они должны там быть,
        /// У первого попавшегося файла поднимаем содержимое. Кейс гипотетический, но предполагаем что такую ситуацию нам нужно проверять.
        /// </summary>
        [TestMethod]
        public void GetDefaultDirectoriesAndFiles()
        {
            // Arrange
            var kernel = new StandardKernel(new UnitTestingNinjectModule());
            var directoryController = kernel.Get<DirectoryController>();
            var fileController = kernel.Get<FileController>();


            // Act
            var directories = directoryController.List("");

            // Assert
            Assert.IsNotNull(directories);
            Assert.IsTrue(directories.Count > 0);

            var files = fileController.List(directories.FirstOrDefault().Path);


            Assert.IsNotNull(files);
            Assert.IsTrue(files.Count > 0);

            var fileContent = fileController.Content(files.FirstOrDefault().Path);

            Assert.IsNotNull(files);
            Assert.AreNotEqual(fileContent, "");
        }
    }
}
