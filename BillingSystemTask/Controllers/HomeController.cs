using BillingSystemTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillingSystemTask.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult index()
        {
            return View();
        }
        //only registered user will access this
        [Authorize (Roles ="User , Admin")]
        public ActionResult UserArea()
        {
            return View();
        }

        //only admin will access this method
        //this will redirect the user to login page if it is not the authorized
        [Authorize(Roles = "Admin")]
        public ActionResult AdminArea()
        {
            UserDbContext db = new UserDbContext();
            List<User> obj = db.GetUsers();
            return View(obj);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                UserDbContext context = new UserDbContext();
                bool check = context.AddUsers(user);
                if (check == true)
                {
                    TempData["InsertData"] = "Data has been inserted Successfully";
                    ModelState.Clear();
                    return RedirectToAction("AdminArea");
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            UserDbContext context = new UserDbContext(); 
          
            var row = context.GetUsers().Find(model => model.Id == id);

            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                UserDbContext context = new UserDbContext();
                bool check = context.UpdateUsers(user);
                if (check == true)
                {
                    TempData["UpdateData"] = "Data has been updated Successfully";
                    ModelState.Clear();
                    return RedirectToAction("AdminArea");
                }
            }

            return View();
        }
        public ActionResult Details(int id)
        {
            UserDbContext context = new UserDbContext();
            var row = context.GetUsers().Find(model => model.Id == id);

            return View(row);
        }
        public ActionResult Delete(int id)
        {
            UserDbContext context = new UserDbContext();
            var row = context.GetUsers().Find(model => model.Id == id);

            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {

            UserDbContext context = new UserDbContext();
            bool check = context.DeleteUsers(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "row has been deleted Successfully";

                return RedirectToAction("AdminArea");
            }
            return View();
        }
    }
}