using ELibraryProject.Core.Service;
using ELibraryProject.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NuGet.Protocol;

namespace ELibraryProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class AuthorController : Controller
    {
        private readonly IDbService<Author> _author;
        public AuthorController(IDbService<Author> author)
        {
            _author = author;
        }
        public IActionResult Index()
        {
            return View(_author.GetAll().ToList());
        }
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Author a)
        {
            if (a!=null)
            {
                _author.Add(a);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            return View(_author.find(id));
        }
        [HttpPost]
        public IActionResult Update(Author a)
        {
            if (a!=null)
            {
                _author.Update(a);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var delete=_author.find(id);
            if (delete!=null)
            {
                _author.Delete(delete);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
