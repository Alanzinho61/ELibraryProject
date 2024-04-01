using ELibraryProject.Core.Service;
using ELibraryProject.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IDbService<Book> _book;
        
        public BookController(IDbService<Book> book)
        {
            _book = book;
        }
        public IActionResult Index()
        {
            return View(_book.GetAll());
        }
    }
}
