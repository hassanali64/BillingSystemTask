using BillingSystemTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillingSystemTask.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        public ActionResult ItemsList()
        {
            ItemsDbContext db = new ItemsDbContext();
            List<Items> obj = db.GetItems();
            return View(obj);
        }
        
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public ActionResult Create(Items item)
        {
            if (ModelState.IsValid)
            {
                ItemsDbContext context = new ItemsDbContext();
                bool check = context.AddItems(item);
                if (check == true)
                {
                    TempData["InsertData"] = "Data has been inserted Successfully";
                    ModelState.Clear();
                    return RedirectToAction("ItemsList");
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            ItemsDbContext context = new ItemsDbContext();

            var row = context.GetItems().Find(model => model.ItemId == id);

            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id, Items item)
        {
            if (ModelState.IsValid)
            {
                ItemsDbContext context = new ItemsDbContext();
                bool check = context.UpdateItems(item);
                if (check == true)
                {
                    TempData["UpdateData"] = "Data has been updated Successfully";
                    ModelState.Clear();
                    return RedirectToAction("ItemsList");
                }
            }

            return View();
        }
        public ActionResult Details(int id)
        {
            ItemsDbContext context = new ItemsDbContext();
            var row = context.GetItems().Find(model => model.ItemId == id);

            return View(row);
        }
        public ActionResult Delete(int id)
        {
            ItemsDbContext context = new ItemsDbContext();
            var row = context.GetItems().Find(model => model.ItemId == id);

            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {

            ItemsDbContext context = new ItemsDbContext();
            bool check = context.DeleteItems(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "row has been deleted Successfully";

                return RedirectToAction("ItemsList");
            }
            return View();
        }
    }
}