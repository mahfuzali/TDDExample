using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace testapp
{
    public class SortingService
    {
        public static string FictionBook1 = "JKF022 Harry Potter and the Goblet of Fire";
        public static string FictionBook2 = "JKF153 Harry Potter and the Sorcerer's Stone";
        public static string FictionBook3 = "JKF857 Harry Potter and the Prisoner of Azkaban";
        public static string FictionBook4 = "JKF264 Harry Potter and the Chamber of Secrets";
        public static string FictionBook5 = "LCF757 Killing Floor";
        public static string FictionBook6 = "LCF274 Persuader";

        public static string NonFictionBook1 = "RMN12 Clean Code: A Handbook of Agile Software Craftsmanship";
        public static string NonFictionBook2 = "RMN77 Clean Architecture: A Craftsman's Guide to Software Structure and Design";
        public static string NonFictionBook3 = "MN32 Design Patterns: Elements of Reusable Object-Oriented Software";
        public static string NonFictionBook4 = "IWN13 Einstein: His Life and Universe";
        public static string NonFictionBook5 = "IWN83 The Innovators: How a Group of Hackers, Geniuses, and Geeks Created the Digital Revolution";
        public static string NonFictionBook6 = "SHN48 A Brief History of Time";

        public string[] SortBooks(params string[] books)
        {
            if(books == null)
            {
                return null;
            }

            var result = from book in books
                         orderby book
                         select book;

            return result.ToArray();
        }

        public string[] SortBooksByGenre(params string[] books)
        {
            if (books == null)
            {
                return null;
            }

            int leftPointer = 0;
            int rightPointer = books.Length - 1;

            while (leftPointer < rightPointer)
            {
                if(CheckGenre(books[leftPointer]) == 'F' && CheckGenre(books[rightPointer]) == 'N')
                {
                    leftPointer++;
                    rightPointer--;
                }
                if (CheckGenre(books[leftPointer]) == 'N' && CheckGenre(books[rightPointer]) == 'F')
                {
                    string temp = books[leftPointer];
                    books[leftPointer] = books[rightPointer];
                    books[rightPointer] = temp;

                    leftPointer++;
                    rightPointer--;
                }
                if (CheckGenre(books[leftPointer]) == 'F' && CheckGenre(books[rightPointer]) == 'F')
                {
                    leftPointer++;
                }
                if (CheckGenre(books[leftPointer]) == 'N' && CheckGenre(books[rightPointer]) == 'N')
                {
                    rightPointer--;
                }

            }

            string[] fiction = Slice(books, 0, leftPointer + 1);
            string[] nonfiction = Slice(books, leftPointer + 1, books.Length);

            var fictionSort = from fic in fiction
                              orderby fic
                         select fic;
            var nonfictionSort = from nonfic in nonfiction
                                 orderby nonfic
                                 select nonfic;

            var newlyArrangedBookList = new List<string>();
            newlyArrangedBookList.AddRange(fictionSort.ToArray());
            newlyArrangedBookList.AddRange(nonfictionSort.ToArray());

            return newlyArrangedBookList.ToArray();
        }
        
        private char CheckGenre(string book)
        {
            string firstWord = book.Split(' ').First();
            Debug.WriteLine(firstWord);
            if (firstWord.Length == 6)
            {
                Debug.WriteLine(firstWord[2]);
                return firstWord[2];
            }
            else if (firstWord.Length == 5)
            {
                Debug.WriteLine(firstWord[2]);
                return firstWord[2];
            }
            else if(firstWord.Length == 4)
            {
                Debug.WriteLine(firstWord[1]);
                return firstWord[1];
            }

            return default;
        }

        /// <summary>
        /// Get the array slice between the two indexes.
        /// ... Inclusive for start index, exclusive for end index.
        /// </summary>
        
        private T[] Slice<T>(T[] source, int start, int end)
        {
            // Handles negative ends.
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            // Return new array.
            T[] res = new T[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }
        /**/
    }
}
