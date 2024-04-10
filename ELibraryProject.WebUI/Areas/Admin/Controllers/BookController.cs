using ELibraryProject.Core.Service;
using ELibraryProject.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ELibraryProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class BookController : Controller
    {
        private readonly IDbService<Book> _book;
        private readonly IDbService<Author> _author;
        private readonly IDbService<Category> _category;
        private readonly IDbService<User> _user;
        public BookController(IDbService<Book> book, IDbService<Author> author, IDbService<Category> category, IDbService<User> user)
        {
            _book = book;
            _author = author;
            _category = category;
            _user = user;
        }
        public IActionResult Index()
        {
            return View(_book.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.Author=_author.GetAll();
            ViewBag.Category=_category.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book b)
        {
            if (b!=null) 
            {
                _book.Add(b);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id) 
        {
            ViewBag.Author = _author.GetAll();
            ViewBag.Category = _category.GetAll();
            var a = _book.find(id);
            return View(a);
        }

        [HttpPost]
        public IActionResult Update(Book b, int id)
        {
            if (b != null)
            {
                var a = _book.find(id);

                
                a.CategoryId = b.CategoryId;
                //a.AuthorId = b.AuthorId;
                a.BookName = b.BookName;
                a.Page = b.Page;
                a.BookStock = b.BookStock;
                

                //_book.Update(b);
                _book.save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var delete=_book.find(id);
            if (delete!=null)
            {
                _book.Delete(delete);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
