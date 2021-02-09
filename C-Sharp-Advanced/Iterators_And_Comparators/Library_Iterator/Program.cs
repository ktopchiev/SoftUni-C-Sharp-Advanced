using System;

namespace Library_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Library newLibrary =
                new Library(new Book("21 lessons for 21th century", 2018, "Juval Noah Hararry"));
            Console.WriteLine(newLibrary.books.Count);
            newLibrary.Add(new Book("Tom Sawyer",1893,"Mark Twain"));

            foreach (var book in newLibrary)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}