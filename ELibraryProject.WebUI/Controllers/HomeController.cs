using ELibraryProject.Core.Service;
using ELibraryProject.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService<Book> _book;
        private readonly IDbService<Category> _category;
        private readonly IDbService<Author> _author;

        public HomeController(IDbService<Book> book, IDbService<Category> category, IDbService<Author> author)
        {
            _book=book;
            _category=category;
            _author=author;
        }
        public IActionResult Index()
        {
            var a =ViewBag.Category= _category.GetAll().ToList();
            var b = ViewBag.Author = _author.GetAll().ToList();
            return View(_book.GetAll().ToList());
        }
    }
}
