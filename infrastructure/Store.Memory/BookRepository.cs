using System;
using System.Linq;

namespace Store.Memory
{
	public class BookRepository : IBookRepository
	{
		private readonly Book[] books = new[]
		{
		new Book(1, "ISBN 12312-31231","D. Knuth", "Art of Programming", "описание", 12.21m),
		new Book(2, "ISBN 12312-31232","M. Fowler","Refactoring", "описание", 11.21m),
		new Book(3, "ISBN 12312-31233", "B. Kernighan, D. Ritchie", "C Programming Language", "описание", 7.21m),
		};

		public Book[] GetAllByIsbn(string isbn) //Linq запрос
		{
			return books.Where(book => book.Isbn == isbn)
				        .ToArray();
		}

		public Book[] GetAllByTitleOrAuthor(string query)
		{
			return books.Where(book => book.Author.Contains(query) //Лямбда-выражение
				                    ||book.Title.Contains(query))
						.ToArray();
		}

		public Book[] GetAllByTitle(string titlePart) //Возможно это надо удалить??
		{
			return books.Where(book => book.Title.Contains(titlePart)) //Лямбда-выражение
						.ToArray();
		}

		public Book GetById(int id)
		{
			return books.Single(book => book.Id == id); //LINQ
		}
	}
}
