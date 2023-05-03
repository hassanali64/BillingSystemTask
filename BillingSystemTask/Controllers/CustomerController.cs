using BillingSystemTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillingSystemTask.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustomersList()
        {
            CustomerDbContext db = new CustomerDbContext();
            List<Customers> obj = db.GetCustomers();
            return View(obj);
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public ActionResult Create(Customers customers)
        {
            if (ModelState.IsValid)
            {
                CustomerDbContext context = new CustomerDbContext();
                bool check = context.AddCustomers(customers);
                if (check == true)
                {
                    TempData["InsertData"] = "Data has been inserted Successfully";
                    ModelState.Clear();
                    return RedirectToAction("CustomersList");
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            CustomerDbContext context = new CustomerDbContext();

            var row = context.GetCustomers().Find(model => model.Id == id);

            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id, Customers customers)
        {
            if (ModelState.IsValid)
            {
                CustomerDbContext context = new CustomerDbContext();
                bool check = context.UpdateCustomers(customers);
                if (check == true)
                {
                    TempData["UpdateData"] = "Data has been updated Successfully";
                    ModelState.Clear();
                    return RedirectToAction("CustomersList");
                }
            }

            return View();
        }
        public ActionResult Details(int id)
        {
            CustomerDbContext context = new CustomerDbContext();
            var row = context.GetCustomers().Find(model => model.Id == id);

            return View(row);
        }
        public ActionResult Delete(int id)
        {
            CustomerDbContext context = new CustomerDbContext();
            var row = context.GetCustomers().Find(model => model.Id == id);

            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(int id, Customers customers)
        {

            CustomerDbContext context = new CustomerDbContext();
            bool check = context.DeleteItems(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "row has been deleted Successfully";

                return RedirectToAction("CustomersList");
            }
            return View();
        }
    }
}