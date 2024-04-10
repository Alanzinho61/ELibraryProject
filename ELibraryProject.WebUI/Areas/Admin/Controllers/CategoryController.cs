using ELibraryProject.Core.Service;
using ELibraryProject.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class CategoryController : Controller
    {
        private readonly IDbService<Category> _category;
        
        public CategoryController(IDbService<Category> category)
        {
            _category = category;
        }
        public IActionResult Index()
        {
            return View(_category.GetAll().ToList());
        }
        
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category c)
        {
            if (c != null)
            {
                _category.Add(c);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            return View(_category.find(id));
        }
        [HttpPost]
        public IActionResult Update(Category c)
        {
            if (c != null)
            {
                _category.Update(c);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var delete=_category.find(id);
            if (delete!=null)
            {
                _category.Delete(delete);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
