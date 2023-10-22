using Microsoft.AspNetCore.Mvc;
using Moq;
using MyCards.API.Controllers;
using MyCards.API.Model;
using MyCards.API.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCards.API.Test.Controllers
{
    internal class CardControllerTest
    {
        
        Mock<ICardRepository> _cardRepositoryMock;
        CardController _controller;
        [SetUp] 
        public void SetUp() 
        {
            _cardRepositoryMock = new Mock<ICardRepository>();
            
            _controller = new CardController(_cardRepositoryMock.Object);
        }

        [Test]
        public async Task Get_EmptyCardList_Pass()
        {
            //Arrange

            //Act
            var result = await _controller.Get();
            var okResult = result as ObjectResult;
            //var okResult = Assert.IsType<OkObjectResult>(result);
            
            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            
        }

        [Test]
        public async Task Post_NewCard_Pass()
        {
            //Arrange
            Card c = new Card(1, "Card1", "cardfile1", DateTime.Now);
           
            //Act
            var result = await _controller.Post(c);
            var okResult = result as ObjectResult;
            var cvalues = okResult?.Value as Card;
            
            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
           // Assert.That(cvalues, Has.Property("Title").EqualTo(c.Title)
             //             & Has.Property("FileReference").EqualTo(c.FileReference)
               //           & Has.Property("CreatedAt").EqualTo(c.CreatedAt));
               
        }
    }
}
