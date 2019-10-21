using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using testapp;

namespace NUnitTestProject1
{
    public class SortingServiceTest
    {
        private SortingService SortingService;

        [SetUp]
        public void Setup()
        {
            SortingService = new SortingService();
        }

        [Test]
        public void Sort_A_List_Of_Books_Alphabetically()
        {

            var books = new string[] { 
                    "IWN13 Einstein: His Life and Universe", 
                    "IWN83 The Innovators: How a Group of Hackers, Geniuses, and Geeks Created the Digital Revolution", 
                    "JKF022 Harry Potter and the Goblet of Fire", 
                    "JKF153 Harry Potter and the Sorcerer's Stone", 
                    "JKF264 Harry Potter and the Chamber of Secrets", 
                    "JKF857 Harry Potter and the Prisoner of Azkaban", 
                    "LCF274 Persuader", 
                    "LCF757 Killing Floor", 
                    "MN32 Design Patterns: Elements of Reusable Object-Oriented Software", 
                    "RMN12 Clean Code: A Handbook of Agile Software Craftsmanship", 
                    "RMN77 Clean Architecture: A Craftsman's Guide to Software Structure and Design", 
                    "SHN48 A Brief History of Time"
                };

            Assert.AreEqual(books, SortingService.SortBooks(
                SortingService.FictionBook1,
                SortingService.FictionBook2,
                SortingService.FictionBook3,
                SortingService.FictionBook4, 
                SortingService.FictionBook5, 
                SortingService.FictionBook6,

                SortingService.NonFictionBook1,
                SortingService.NonFictionBook2,
                SortingService.NonFictionBook3,
                SortingService.NonFictionBook4,
                SortingService.NonFictionBook5,
                SortingService.NonFictionBook6
            ));
        }

        [Test]
        public void Sort_A_List_Of_Books_Alphabetically_By_Genre()
        {
            var books = new string[] {
                    "JKF022 Harry Potter and the Goblet of Fire",
                    "JKF153 Harry Potter and the Sorcerer's Stone",
                    "JKF264 Harry Potter and the Chamber of Secrets",
                    "JKF857 Harry Potter and the Prisoner of Azkaban",
                    "LCF274 Persuader",
                    "LCF757 Killing Floor",
                    "IWN13 Einstein: His Life and Universe",
                    "IWN83 The Innovators: How a Group of Hackers, Geniuses, and Geeks Created the Digital Revolution",
                    "MN32 Design Patterns: Elements of Reusable Object-Oriented Software",
                    "RMN12 Clean Code: A Handbook of Agile Software Craftsmanship",
                    "RMN77 Clean Architecture: A Craftsman's Guide to Software Structure and Design",
                    "SHN48 A Brief History of Time"
                };

            Assert.AreEqual(books, SortingService.SortBooksByGenre(
                SortingService.FictionBook1,
                SortingService.FictionBook2,
                SortingService.NonFictionBook3,
                SortingService.NonFictionBook4,
                SortingService.FictionBook3,
                SortingService.FictionBook4,
                SortingService.FictionBook6,
                SortingService.NonFictionBook1,
                SortingService.NonFictionBook2,
                SortingService.FictionBook5,
                SortingService.NonFictionBook5,
                SortingService.NonFictionBook6
            ));
        }
    }
}
