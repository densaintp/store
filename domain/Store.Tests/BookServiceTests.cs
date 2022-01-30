using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Store.Tests
{
	public class BookServiceTests
	{

		//что такое Moq?

		[Fact]
		public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn() //Зачем void?
		{
			var bookRepositoryStub = new Mock<IBookRepository>(); //Что это такое в треугольныъ собках? напомнить себе... Заглушка к книжкому репозиторию
			bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
				.Returns(new[] { new Book(1, "", "", "","", 0m) });
			bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
				.Returns(new[] { new Book(2, "", "", "", "", 0m) });

			var bookService = new BookService(bookRepositoryStub.Object);
			var validIsbn = "ISBN 12345-67890";

			var actual = bookService.GetAllByQuery(validIsbn);

			Assert.Collection(actual, book => Assert.Equal(1, book.Id)); //Что Это?
		}

		[Fact]
		public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor() //Зачем void?
		{
			var bookRepositoryStub = new Mock<IBookRepository>(); //Что это такое в треугольныъ собках? напомнить себе... Заглушка к книжкому репозиторию
			bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
				.Returns(new[] { new Book(1, "", "", "", "", 0m) });
			bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
				.Returns(new[] { new Book(2, "", "", "", "", 0m) });

			var bookService = new BookService(bookRepositoryStub.Object);
			var validIsbn = "12345-67890";

			var actual = bookService.GetAllByQuery(validIsbn);

			Assert.Collection(actual, book => Assert.Equal(2, book.Id)); //Что Это?
		}
	}
}
