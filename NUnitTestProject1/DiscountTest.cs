using NUnit.Framework;
using testapp;

namespace DiscountTest
{
    public class Tests
    {
        private BookService BookService;

        [SetUp]
        public void Setup()
        {
            BookService = new BookService();
        }

        [Test]
        public void GetPrice_ForOneHPBook_Returns8eurosForPrice()
        {
            Assert.AreEqual(8, BookService.GetPrice(BookService.HarryPotter1ISBN));
        }

        [Test]
        public void GetPrice_ForTwoDifferentBooks_Returns15_2EurosForPrice()
        {
            var isbns = new[] { BookService.HarryPotter1ISBN, BookService.HarryPotter2ISBN };
            Assert.AreEqual(15.2M, BookService.GetPrice(isbns));
        }

        [Test]
        public void GetPrice_WithoutSpecifyingAnISBN_ShouldReturnZero()
        {
            Assert.AreEqual(0, BookService.GetPrice(null));
        }

        [Test]
        public void GetPrice_ForTheSameBookTwice_ShouldReturn16euros()
        {
            var isbns = new[] { BookService.HarryPotter1ISBN, BookService.HarryPotter1ISBN };
            Assert.AreEqual(16, BookService.GetPrice(isbns));
        }

        [Test]
        public void GetPrice_ForThreeDifferentBook_ShouldReturn21_6euros()
        {
            var isbns = new[] { BookService.HarryPotter1ISBN, BookService.HarryPotter2ISBN, BookService.HarryPotter3ISBN };
            Assert.AreEqual(21.6M, BookService.GetPrice(isbns));
        }

        [Test]
        public void GetPrice_ForTwoEqualsAndOneDifferentHPBooks_Returns23_2Euros()
        {
            Assert.AreEqual(23.2M, BookService.GetPrice(BookService.HarryPotter1ISBN, BookService.HarryPotter2ISBN, BookService.HarryPotter1ISBN));
        }

        [Test]
        public void GetPrice_ForFiveDifferentBooksWithThreeContainingDuplicates_Returns51_60Euros()
        {
            Assert.AreEqual(51.6M, BookService.GetPrice(
                BookService.HarryPotter1ISBN,
                BookService.HarryPotter1ISBN,
                BookService.HarryPotter2ISBN,
                BookService.HarryPotter2ISBN,
                BookService.HarryPotter3ISBN,
                BookService.HarryPotter3ISBN,
                BookService.HarryPotter4ISBN,
                BookService.HarryPotter5ISBN
           ));
        }

        [Test]
        public void GetBetterPrice_ForFiveDifferentBooksWithThreeContainingDuplicates_Returns51_60Euros()
        {
            Assert.AreEqual(51.2M, BookService.GetBetterPrice(
                BookService.HarryPotter1ISBN,
                BookService.HarryPotter1ISBN,
                BookService.HarryPotter2ISBN,
                BookService.HarryPotter2ISBN,
                BookService.HarryPotter3ISBN,
                BookService.HarryPotter3ISBN,
                BookService.HarryPotter4ISBN,
                BookService.HarryPotter5ISBN
           ));
        }
    }
}