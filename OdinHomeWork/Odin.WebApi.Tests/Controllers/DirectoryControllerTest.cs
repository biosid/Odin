using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Odin.WebApi;
using Odin.WebApi.Controllers;
using Ninject;
using Odin.WebApi.Tests.DependencyResolution;

namespace Odin.WebApi.Tests.Controllers
{
    [TestClass]
    public class DirectoryControllerTest
    {
        [TestMethod]
        public void ListWithDefaulValues()
        {
            // Arrange
            var kernel = new StandardKernel(new UnitTestingNinjectModule());
            var controller = kernel.Get<DirectoryController>();

            // Act
            var result = controller.List("");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
