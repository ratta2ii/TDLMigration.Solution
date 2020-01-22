using Microsoft.AspNetCore.Mvc;
using TDLMigration.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TDLMigration.Controllers
{
    public class ItemsController : Controller
    {
        private readonly TDLMigrationContext _db;

        public ItemsController(TDLMigrationContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.ItemsTable.ToList());
        }

        public ActionResult Details(int id)
        {
            var thisItem = _db.ItemsTable
                .Include(item => item.CategoriesList)
                .ThenInclude(join => join.Category)
                .FirstOrDefault(item => item.ItemId == id);
            return View(thisItem);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.CategoriesTable, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item item, int CategoryId)
        {
            _db.ItemsTable.Add(item);
            if (CategoryId != 0)
            {
                _db.CategoryItemJoinedTable.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var thisItem = _db.ItemsTable.FirstOrDefault(items => items.ItemId == id);
            ViewBag.CategoryId = new SelectList(_db.CategoriesTable, "CategoryId", "Name");
            return View(thisItem);
        }

        [HttpPost]
        public ActionResult Edit(Item item, int CategoryId)
        {
            if (CategoryId != 0)
            {
                _db.CategoryItemJoinedTable.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
            }
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddCategory(int id)
        {
            var thisItem = _db.ItemsTable.FirstOrDefault(items => items.ItemId == id);
            ViewBag.CategoryId = new SelectList(_db.CategoriesTable, "CategoryId", "Name");
            return View(thisItem);
        }

        [HttpPost]
        public ActionResult AddCategory(Item item, int CategoryId)
        {
            if (CategoryId != 0)
            {
                _db.CategoryItemJoinedTable.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisItem = _db.ItemsTable.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisItem = _db.ItemsTable.FirstOrDefault(items => items.ItemId == id);
            _db.ItemsTable.Remove(thisItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteCategory(int joinId)
        {
            var joinEntry = _db.CategoryItemJoinedTable.FirstOrDefault(entry => entry.CategoryItemId == joinId);
            _db.CategoryItemJoinedTable.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}









