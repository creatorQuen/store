using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 0201038013", "D. Knuth", "Art of Programming", "This magnificent tour de force presents a comprehensive overview of a wide variety of " +
                "algorithms and the analysis of them. Now in its third edition, The Art of Computer Programming, Volume I: Fundamental Algorithms contains substantial " +
                "revisions by the author and includes numerous new exercises.", 7.19m),
            new Book(2, "ISBN 12312-31232", "M. Fowler", "Refactoring", "As the application of object technology--particularly thw Java programming.", 12.45m),
            new Book(3, "ISBN 12312-31233", "B. Kernighan, D. Ritchie", "C Programming Language", "Know as the bible of C, this classic bestseller introduces the C programming.", 12.48m),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)
                        .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query) 
                                    || book.Title.Contains(query))
                                    .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
