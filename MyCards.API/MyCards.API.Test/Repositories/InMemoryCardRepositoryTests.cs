using MyCards.API.Data.Entities;
using MyCards.API.Repositories;

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
            CardEntity c = new CardEntity(1,"Card1", "cardfile1", DateTime.Now, false);
            //Act
            var newCard =await _repository.Create(c);
            //Assert
            Assert.That(newCard, Has.Property("Id").EqualTo(1) & Has.Property("Title").EqualTo(c.Title)
                          & Has.Property("FileReference").EqualTo(c.FileReference)
                          & Has.Property("CreatedAt").EqualTo(c.CreatedAt));
            

        }

        [Test]
        public async Task Check_CardListNotEmpty_Pass()
        {
            //Arrange
            CardEntity c = new CardEntity(1, "Card1", "cardfile1", DateTime.Now, false);
            //Act
            var newCard = await _repository.Create(c);
            List<CardEntity> newList = await _repository.Get();
            //Assert
            Assert.That(newList.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task AddTwoCards_CardListHasTwoCards_Pass()
        {
            //Arrange
            CardEntity c1 = new CardEntity(1, "Card1", "cardfile1", DateTime.Now, false);
            CardEntity c2 = new CardEntity(2, "Card2", "cardfile2", DateTime.Now, false);
            //Act
            var newCard = await _repository.Create(c1);
            var newCard2 = await _repository.Create(c2);
            //Assert
            Assert.That((await _repository.Get()).Count, Is.EqualTo(2));
        }

        [Test]
        public async Task UpdateTitle_CardListEmpty_Pass()
        {
            //Arrange
            CardEntity c1 = new CardEntity(1, "Card1", "cardfile1", DateTime.Now, false);
            //Act
            CardEntity? updatedCard = await _repository.Update(c1);
            //Assert
            Assert.IsNull(updatedCard);
        }

        [Test]
        public async Task UpdateTitle_CardInTheList_Pass()
        {
            //Arrange
            CardEntity c1 = new CardEntity(1, "Card1", "cardfile1", DateTime.Now, false);
            CardEntity c2 = new CardEntity(2, "Card2", "cardfile2", DateTime.Now, false);
            CardEntity c3 = new CardEntity(3, "Card3", "cardfile3", DateTime.Now, false);
            CardEntity newValuesCard = new CardEntity(3, "NewCard3", "cardfile3", DateTime.Now, false);

            var newCard = await _repository.Create(c1);
            var newCard2 = await _repository.Create(c2);
            var newCard3 = await _repository.Create(c3);
            //Act
            CardEntity? updatedCard = await _repository.Update(newValuesCard);
            //Assert
            Assert.IsNotNull(updatedCard);
            Assert.That(updatedCard, Has.Property("Id").EqualTo(3) & Has.Property("Title").EqualTo(newValuesCard.Title));
        }

        [Test]
        public async Task UpdateTitle_CardNotInTheList_Pass()
        {
            //Arrange
            CardEntity c1 = new CardEntity(1, "Card1", "cardfile1", DateTime.Now, false);
            CardEntity c2 = new CardEntity(2, "Card2", "cardfile2", DateTime.Now, false);
            CardEntity c3 = new CardEntity(3, "Card3", "cardfile3", DateTime.Now, false);
            CardEntity newValuesCard = new CardEntity(5, "NewCard5", "cardfile5", DateTime.Now, false);

            var newCard = await _repository.Create(c1);
            var newCard2 = await _repository.Create(c2);
            var newCard3 = await _repository.Create(c3);
            //Act
            CardEntity? updatedCard = await _repository.Update(newValuesCard);
            //Assert
            Assert.IsNull(updatedCard);
            
        }

    }
}
