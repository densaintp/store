using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
	public class SearchController : Controller
	{
		private readonly IBookRepository bookRepository; //Констрактор-Инжекшн

		public SearchController(IBookRepository bookRepository) //Констрактор-Инжекшн
		{
			this.bookRepository = bookRepository;
		}
		public IActionResult Index(string query)
		{
			var books = bookRepository.GetAllByTitle(query);
			return View(books);
		}
	}
}
