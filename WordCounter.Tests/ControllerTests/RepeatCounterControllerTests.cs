using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WordCounter.Controllers;
using WordCounter.Models;


namespace WordCounter.Tests
{
    [TestClass]
    public class RepeatCounterControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            //Arrange
            RepeatCountersController controller = new RepeatCountersController();

            //Act
            ActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Search_ReturnsCorrectView_True()
        {
            //Arrange
            RepeatCountersController controller = new RepeatCountersController();

            //Act
            ActionResult indexView = controller.Search();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void History_ReturnsCorrectView_True()
        {
            //Arrange
            RepeatCountersController controller = new RepeatCountersController();

            //Act
            ActionResult indexView = controller.History();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void History_HasCorrectModelType_ItemList()
        {
            //Arrange
            RepeatCountersController controller = new RepeatCountersController();
            IActionResult actionResult = controller.History();
            ViewResult indexView = controller.History() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<RepeatCounter>));
        }
    }
}
