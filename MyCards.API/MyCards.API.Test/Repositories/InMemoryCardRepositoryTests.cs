using MyCards.API.Model;
using MyCards.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyCards.API.Test.Repositories
{
    internal class InMemoryCardRepositoryTests
    {
        private InMemoryCardRepository _repository;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _repository = new InMemoryCardRepository();
        }

        [Test]
        public async Task Get_CardListEmpty_Pass()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsEmpty(await _repository.Get());
        }
        [Test]
        public async Task Add_Card_Pass()
        {
            //Arrange
            Card c = new Card(null,"Card1", "cardfile1", DateTime.Now);
            //Act
            Card newCard =await _repository.Create(c);
            //Assert
            Assert.That(newCard, Has.Property("Id").EqualTo(1) & Has.Property("Title").EqualTo(c.Title)
                          & Has.Property("FileReference").EqualTo(c.FileReference)
                          & Has.Property("CreatedAt").EqualTo(c.CreatedAt));
            

        }

        [Test]
        public async Task Check_CardListNotEmpty_Pass()
        {
            //Arrange
            Card c = new Card(null, "Card1", "cardfile1", DateTime.Now);
            //Act
            Card newCard = await _repository.Create(c);
            List<Card> newList = await _repository.Get();
            //Assert
            Assert.That(newList.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task AddTwoCards_CardListHasTwoCards_Pass()
        {
            //Arrange
            Card c1 = new Card(null, "Card1", "cardfile1", DateTime.Now);
            Card c2 = new Card(null, "Card2", "cardfile2", DateTime.Now);
            //Act
            Card newCard = await _repository.Create(c1);
            Card newCard2 = await _repository.Create(c2);
            //Assert
            Assert.That((await _repository.Get()).Count, Is.EqualTo(2));
        }

        [Test]
        public async Task UpdateTitle_CardListEmpty_Pass()
        {
            //Arrange
            Card c1 = new Card(null, "Card1", "cardfile1", DateTime.Now);
            //Act
            Card? updatedCard = await _repository.Update(1, c1);
            //Assert
            Assert.IsNull(updatedCard);
        }

        [Test]
        public async Task UpdateTitle_CardInTheList_Pass()
        {
            //Arrange
            Card c1 = new Card(null, "Card1", "cardfile1", DateTime.Now);
            Card c2 = new Card(null, "Card2", "cardfile2", DateTime.Now);
            Card c3 = new Card(null, "Card3", "cardfile3", DateTime.Now);
            Card newValuesCard = new Card(null, "NewCard3", "cardfile3", DateTime.Now);

            Card newCard = await _repository.Create(c1);
            Card newCard2 = await _repository.Create(c2);
            Card newCard3 = await _repository.Create(c3);
            //Act
            Card? updatedCard = await _repository.Update(3, newValuesCard);
            //Assert
            Assert.IsNotNull(updatedCard);
            Assert.That(updatedCard, Has.Property("Id").EqualTo(3) & Has.Property("Title").EqualTo(newValuesCard.Title));
        }

        [Test]
        public async Task UpdateTitle_CardNotInTheList_Pass()
        {
            //Arrange
            Card c1 = new Card(null, "Card1", "cardfile1", DateTime.Now);
            Card c2 = new Card(null, "Card2", "cardfile2", DateTime.Now);
            Card c3 = new Card(null, "Card3", "cardfile3", DateTime.Now);
            Card newValuesCard = new Card(null, "NewCard5", "cardfile5", DateTime.Now);

            Card newCard = await _repository.Create(c1);
            Card newCard2 = await _repository.Create(c2);
            Card newCard3 = await _repository.Create(c3);
            //Act
            Card? updatedCard = await _repository.Update(5, newValuesCard);
            //Assert
            Assert.IsNull(updatedCard);
            
        }

    }
}
