using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using testapp;

namespace DiscountTest
{
    public class ISBNTests
    {
        private ISBNService ISBNService;

        [SetUp]
        public void Setup()
        {
            ISBNService = new ISBNService();
        }

        [Test]
        public void Check_Given_String_Is_A_Valid_ISBN10WithoutSpace()
        {
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.ISBN10WithoutSpace));
        }

        [Test]
        public void Check_Given_String_Is_A_Valid_ISBN10WithSpaces()
        {
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.ISBN10WithSpaces));
        }

        [Test]
        public void Check_Given_String_Is_A_Valid_ISBN10WithHypens()
        {
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.FirstISBN10WithHypens));
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.SecondISBN10WithHypens));
        }


        [Test]
        public void Check_Given_String_Is_A_Valid_ISBN13WithoutSpace()
        {
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.ISBN13WithoutSpace));
        }

        [Test]
        public void Check_Given_String_Is_A_Valid_ISBN13WithSpaces()
        {
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.ISBN13WithSpaces));
        }

        [Test]
        public void Check_Given_String_Is_A_Valid_ISBN13WithHypen()
        {
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.FirstISBN13WithOneHypen));
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.FirstISBN13WithHypens));
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.SecondISBN13WithHypens));
        }

        [Test]
        public void Check_Given_String_Is_A_Valid_ISBN10_Correct_Check_Digit()
        {
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.ISBN10WithoutSpace));
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.ISBN10WithSpaces));
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.FirstISBN10WithHypens));
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.SecondISBN10WithHypens));
        }

        [Test]
        public void Check_Given_String_Is_A_Valid_ISBN13_Correct_Check_Digit()
        {
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.ISBN13WithoutSpace));
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.ISBN13WithSpaces));
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.FirstISBN13WithOneHypen));
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.FirstISBN13WithHypens));
            Assert.AreEqual(true, ISBNService.IsValidISBN(ISBNService.SecondISBN13WithHypens));
        }

    }
}