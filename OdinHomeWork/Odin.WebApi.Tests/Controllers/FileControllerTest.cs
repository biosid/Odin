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
            catch (BusinessLogicException ex)
            {
                Assert.IsNotNull(ex);
                //По хорошему нужно выкидывавать типизированное исключение, для каждого класса ошибок.
                Assert.IsTrue(ex.Message == $"There are some errors while files listing, try latter. Error Info: Файл '{fakeFilePath.ToString()}' не найден.");
            }
            // Assert

        }

        [TestMethod]
        public void FileToLarge()
        {
            // Arrange
            var kernel = new StandardKernel(new UnitTestingNinjectModule());
            var controller = kernel.Get<FileController>();

            // Act
            //Должен быть путь на существующий файл
            var largeFilePath = "C:\\SomeLargeFile.txt";
            try
            {
                var result = controller.Content(largeFilePath);
            }
            catch (BusinessLogicException ex)
            {
                Assert.IsNotNull(ex);
                //По хорошему нужно выкидывавать типизированное исключение, для каждого класса ошибок.
                Assert.IsTrue(ex.Message == "File is too large");
            }
            // Assert

        }

    }
}
