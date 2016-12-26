using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Odin.WebApi;
using Odin.WebApi.Controllers;
using Ninject;
using Odin.WebApi.Tests.DependencyResolution;
using System;
using Odin.Services.Exceptions;

namespace Odin.WebApi.Tests.Controllers
{
    [TestClass]
    public class FileControllerTest
    {
        [TestMethod]
        public void ListWithDefaulValues()
        {
            // Arrange
            var kernel = new StandardKernel(new UnitTestingNinjectModule());
            var controller = kernel.Get<FileController>();

            // Act
            var result = controller.List("");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void FileNotFound()
        {
            // Arrange
            var kernel = new StandardKernel(new UnitTestingNinjectModule());
            var controller = kernel.Get<FileController>();

            // Act
            var fakeFilePath = Guid.NewGuid();
            try
            {
                var result = controller.Content(fakeFilePath.ToString());
            }
            catch (FileNotFoundException ex)
            {
                // Assert
                Assert.IsNotNull(ex);
            }        
        }

        [TestMethod]
        public void FileToLarge()
        {
            // Arrange
            var kernel = new StandardKernel(new UnitTestingNinjectModule());
            var controller = kernel.Get<FileController>();

            // Act
            //Need some existing file
            var largeFilePath = "C:\\SomeLargeFile.txt";
            try
            {
                var result = controller.Content(largeFilePath);
            }
            catch (FileSizeException ex)
            {
                // Assert
                Assert.IsNotNull(ex);
            }
        }

    }
}
