using System;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookThree = new Book("The Documents in the Case", 1930);
            Book bookFour = new Book("A book", 2002, "K. Topchiev");
            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree, bookFour);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }
        }
    }
}