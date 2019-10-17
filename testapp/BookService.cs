using System;
using System.Collections.Generic;
using System.Linq;

namespace testapp
{
    public class BookService
    {
        private const decimal PriceOfOneBook = 8M;
        private const decimal FivePercentDiscount = 0.05M;
        private const decimal TenPercentDiscount = 0.10M;

        private const decimal TwentyPercentDiscount = 0.20M;
        private const decimal TwentyFivePercentDiscount = 0.25M;

        public static string HarryPotter1ISBN = "9780545791427";
        public static string HarryPotter2ISBN = "9780545790352";
        public static string HarryPotter3ISBN = "9789722325332";
        public static string HarryPotter4ISBN = "9789722326018";
        public static string HarryPotter5ISBN = "9789722326803";

        public decimal GetPrice(params string[] isbns)
        {
            if (isbns == null)
                return 0;

            decimal total = 0M;
            var books = GetCollectionOfBooks(isbns);

            while (books.Count > 0)
            {
                decimal sum = 0M;
                int numberOfItems = 0;

                foreach (var book in books.ToList())
                {
                    if (book.Value > 1)
                    {
                        numberOfItems++;
                        books[book.Key] = book.Value - 1;
                    }
                    else if (book.Value == 1)
                    {
                        numberOfItems++;
                        books.Remove(book.Key);
                    }
                }

                if (numberOfItems == 2)
                {
                    sum = CalculateDiscount(numberOfItems, PriceOfOneBook, FivePercentDiscount);
                }
                else if (numberOfItems == 3)
                {
                    sum = CalculateDiscount(numberOfItems, PriceOfOneBook, TenPercentDiscount);
                }
                else if (numberOfItems == 4)
                {
                    sum = CalculateDiscount(numberOfItems, PriceOfOneBook, TwentyPercentDiscount);
                }
                else if (numberOfItems == 5)
                {
                    sum = CalculateDiscount(numberOfItems, PriceOfOneBook, TwentyFivePercentDiscount);
                }
                else
                {
                    sum = PriceOfOneBook;
                }

                total += sum;
            }

            return total;
        }

        public decimal GetBetterPrice(params string[] isbns)
        {
            if (isbns == null)
                return 0;

            decimal total = 0M;
            var books = GetCollectionOfBooks(isbns);

            while (books.Count > 0)
            {
                decimal sum = 0M;
                int numberOfItems = 0;

                foreach (var book in books.ToList())
                {
                    if (numberOfItems == 4)
                    {
                        break;
                    }

                    if (book.Value > 1)
                    {
                        numberOfItems++;
                        books[book.Key] = book.Value - 1;
                    }
                    else if (book.Value == 1)
                    {
                        numberOfItems++;
                        books.Remove(book.Key);
                    }
                }

                if (numberOfItems == 2)
                {
                    sum = CalculateDiscount(numberOfItems, PriceOfOneBook, FivePercentDiscount);
                }
                else if (numberOfItems == 3)
                {
                    sum = CalculateDiscount(numberOfItems, PriceOfOneBook, TenPercentDiscount);
                }
                else if (numberOfItems == 4)
                {
                    sum = CalculateDiscount(numberOfItems, PriceOfOneBook, TwentyPercentDiscount);
                }
                else
                {
                    sum = PriceOfOneBook;
                }
                total += sum;
            }

            return total;
        }

        private decimal CalculateDiscount(int numberOfItems, decimal bookPrice, decimal discountPercentage)
        {
            return Convert.ToDecimal(numberOfItems) * (bookPrice - (bookPrice * discountPercentage));
        }

        private IDictionary<string, int> GetCollectionOfBooks(params string[] isbns)
        {
            var groupedItems = isbns.GroupBy(isbn => isbn).Select(x => new { x.Key, Quantity = x.Count() });

            var result = new Dictionary<string, int>();

            foreach (var groupedItem in groupedItems)
            {
                result.Add(groupedItem.Key, groupedItem.Quantity);
            }

            return result;
        }
    }
}