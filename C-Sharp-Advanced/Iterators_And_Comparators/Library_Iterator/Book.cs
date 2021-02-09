using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Iterator
{
    public class Book
    {
        public string Title { get; private set; }
        public int Year { get; private set; }
        public List<string> Authors { get; private set; }

        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Title} - ");
            foreach (var author in Authors)
            {
                sb.Append($"{author}");

                if (Authors.Count > 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append($"; {Year}");

            return sb.ToString();
        }
    }
}