using Microsoft.AspNetCore.Mvc;
using Moq;
using MyCards.API.Controllers;
using MyCards.API.Data.Dtos;
using MyCards.API.Data.Entities;
using MyCards.API.Repositories;

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
            _cardRepositoryMock.Setup(x => x.Get()).ReturnsAsync(new List<CardEntity>());
            //Act
            var result = await _controller.Get();
            var okResult = result as ObjectResult;
            var list = okResult?.Value as List<CardEntity>;            
            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(list, Is.Null);            
        }

        [Test]
        public async Task Post_NewCard_Pass()
        {
            //Arrange
            CreateCardDto c = new CreateCardDto("Card1", "cardfile1");
            CardEntity resultCard = new CardEntity(1, c.Title, c.FileReference, DateTime.Now);
            _cardRepositoryMock.Setup(x => x.Create(It.IsAny<CardEntity>()))
                .ReturnsAsync(resultCard);           
            //Act
            var result = await _controller.Post(c);
            var okResult = result as ObjectResult;
            var cvalues = okResult?.Value as CardDto;
            
            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(cvalues, Has.Property("Title").EqualTo(c.Title)
                          & Has.Property("FileReference").EqualTo(c.FileReference)
                          );
               
        }
        [Test]
        public async Task Put_CardIsInTheList_Pass()
        {
            //Arrange
            CardEntity c = new CardEntity(3, "Card3", "cardfile3", DateTime.Now);
            //CardEntity newValuesCard = new CardEntity(3, "NewCard3", "cardfile3", DateTime.Now);
            //CardDto updatedValuesCardDto = new CardDto(newValuesCard.Id, newValuesCard.Title, newValuesCard.FileReference, newValuesCard.CreatedAt);
            UpdateCardDto newVauesCardDto = new UpdateCardDto(3, "NewCard3");
            _cardRepositoryMock.Setup(x => x.Update(It.IsAny<CardEntity>()))
                .ReturnsAsync(c);
            //Act
            var result = await _controller.Put(newVauesCardDto);
            var okRersult = result as ObjectResult;


            //Assert
            Assert.IsNotNull(okRersult);
            Assert.That(okRersult.StatusCode, Is.EqualTo(200));

        }
        [Test]
        public async Task Put_CardIsNotInTheList_Pass()
        {
            //Arrange

            UpdateCardDto newValuesCard = new UpdateCardDto(3, "NewCard3");
            _cardRepositoryMock.Setup(x => x.Update(It.IsAny<CardEntity>()))
                .ReturnsAsync((CardEntity?)null);
            //Act
            var result = await _controller.Put(newValuesCard);
            var notFoundResult = result as StatusCodeResult;
            

            //Assert
            Assert.IsNotNull(notFoundResult);
            Assert.That(notFoundResult?.StatusCode, Is.EqualTo(404));
           
        }

        [Test]
        public async Task Delete_CardIsNotInTheList_Pass()
        {
            //Arrange

            _cardRepositoryMock.Setup(x => x.Remove(It.IsAny<int>()))
              //  .ReturnsAsync((Card?)null);
              .Returns(Task.FromResult<CardEntity?>(null));
            //Act
            var result = await _controller.Delete(1);
            var notFoundResult = result as NotFoundResult;


            //Assert
            Assert.IsNotNull(notFoundResult);
            Assert.That(notFoundResult.StatusCode, Is.EqualTo(404));

        }
        [Test]
        public async Task Delete_CardIsInTheList_Pass()
        {
            //Arrange
            CardEntity c = new CardEntity(1, "Card1", "cardfile1", DateTime.Now);
            _cardRepositoryMock.Setup(x => x.Remove(It.IsAny<int>()))
                .ReturnsAsync(c);
            //Act
            var result = await _controller.Delete(1);
            var okResult = result as ObjectResult;


            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));

        }


    }
}
