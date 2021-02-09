using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Library_Iterator
{
    public class Library : IEnumerable<Book>
    {
        public List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }
        
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Book book)
        {
            this.books.Add(book);
        }

        class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = new List<Book>(books);
            }
            
            public bool MoveNext() => ++currentIndex < books.Count;

            public void Reset()
            {
                currentIndex = -1;
            }

            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
    }
}