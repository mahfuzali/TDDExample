using System;
using System.Linq;

namespace testapp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            char[] input = { 'a', 'a', 'b', 'b', 'c', 'c', 'd', 'e' , 'e', 'f'}; 
            var results = input.Select((x, i) => new { chr = x, index = i }).GroupBy(x => x.index % 2).Select(x => x.Select(y => y.chr).ToArray()).ToArray();

            Console.WriteLine(results[0]);
            Console.WriteLine(results[1]);
        }
    }
}