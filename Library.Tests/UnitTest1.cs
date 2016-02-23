using BLL.Services.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using DAL.Repositories.Interfaces;
using Library.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Library.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Delete_Valid_Books()
        {
            // Arrange - create a Product
            Book book = new Book
            {
                Name = "Reckoning : A Memoir",
                Author = "Magda Szubanski",
                Format = "hardback",
                ISBN = "9781925240436",
                Publisher = "Text Publishing Co",
                PublicationDate = new DateTime(2015, 9, 23, 0, 0, 0),
                Pages = 400,
                Quantity = 2,
                Language = "English",
                ImageMime = null,
                Image = null
            };
            // Arrange - create the mock repository
            Mock<ILibraryRepository> mock = new Mock<ILibraryRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>{
 new Book
            {
                Name = "Gotta Love This Country! : Great Stories from Around Australia to Lift Your Heart, Make You Laugh and Puff Out Your Chest",
                Author = "Peter Fitzsimons",
                Format = "paperback",
                ISBN = "9781760290481",
                Publisher = "Alien & Unwin",
                PublicationDate = new DateTime(2016, 3, 1, 0, 0, 0),
                Pages = 272,
                Quantity = 1,
                Language = "English",
                Image = null,
                ImageMime = null
            },
 book
 });

            Mock<ILibraryService> mockService = new Mock<ILibraryService>();
            // Arrange - create the controller
            BookController target = new BookController(mockService.Object);
            // Act - delete the product
            target.Delete(book.ISBN);
            // Assert - ensure that the repository delete method was
            // called with the correct Product
            mockService.Verify(m => m.Remove(book.ISBN));
        }
    }
}