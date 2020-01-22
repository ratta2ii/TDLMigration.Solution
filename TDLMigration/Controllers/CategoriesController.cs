using Microsoft.AspNetCore.Mvc;
using TDLMigration.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TDLMigration.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly TDLMigrationContext _db;

        public CategoriesController(TDLMigrationContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Category> model = _db.CategoriesTable.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            _db.CategoriesTable.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisCategory = _db.CategoriesTable
                .Include(category => category.ItemsList)
                .ThenInclude(join => join.Item)
                .FirstOrDefault(category => category.CategoryId == id);
            return View(thisCategory);
        }

        public ActionResult Edit(int id)
        {
            var thisCategory = _db.CategoriesTable.FirstOrDefault(category => category.CategoryId == id);
            return View(thisCategory);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisCategory = _db.CategoriesTable.FirstOrDefault(category => category.CategoryId == id);
            return View(thisCategory);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisCategory = _db.CategoriesTable.FirstOrDefault(category => category.CategoryId == id);
            _db.CategoriesTable.Remove(thisCategory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}