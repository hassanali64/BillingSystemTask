using BillingSystemTask.Migrations;
using BillingSystemTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using Billing = BillingSystemTask.Models.Billing;
using Customers = BillingSystemTask.Models.Customers;

namespace BillingSystemTask.Controllers
{
    public class BillingController : Controller
    {
        private readonly string connectionString = "Data Source=DESKTOP-8BOKR0M\\SQLEXPRESS;Initial Catalog=credentials;Integrated Security=true;";

        public ActionResult Create()
        {
            var customers = GetCustomers();
            var items = GetItems();
            var model = new Billing();
            ViewBag.Customers = new SelectList(customers, "CustomerId", "CustomerName");
            ViewBag.Items = new SelectList(items, "ItemId", "ItemName");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Billing model)
        {
            if (ModelState.IsValid)
            {
                model.Price = GetItemPrice(model.ItemId);
                model.TotalCost = model.Quantity * model.Price;
                SaveBill(model);
                return RedirectToAction("Index");
            }
            var customers = GetCustomers();
            var items = GetItems();
            ViewBag.Customers = new SelectList(customers, "CustomerId", "CustomerName");
            ViewBag.Items = new SelectList(items, "ItemId", "ItemName");
            return View(model);
        }

        public ActionResult Index()
        {
            var bills = GetBills();
            return View(bills);
        }



        private List<Customers> GetCustomers()
        {
            var customers = new List<Customers>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT Id, CustomerName FROM Customers";
                var command = new SqlCommand(query, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customers
                    {
                        Id = (int)reader["Id"],
                        CustomerName = (string)reader["CustomerName"]
                    });
                }
                reader.Close();
            }
            return customers;
        }

        private List<Items> GetItems()
        {
            var items = new List<Items>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT ItemId, ItemName FROM Items";
                var command = new SqlCommand(query, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(new Items
                    {
                        ItemId = (int)reader["ItemId"],
                        ItemName = (string)reader["ItemName"]
                    });
                }
                reader.Close();
            }
            return items;
        }

      
        private decimal GetItemPrice(int itemId)
        {
            decimal price = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT fee FROM Items WHERE ItemId = @ItemId";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId);
                connection.Open();
                var result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    price = Convert.ToDecimal(result);
                }
            }
            return price;
        }
        private void SaveBill(Billing model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Billings (CustomerId, ItemId, Quantity, Price, TotalCost) VALUES (@CustomerId, @ItemId, @Quantity, @Price, @TotalCost)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", model.CustomerId);
                command.Parameters.AddWithValue("@ItemId", model.ItemId);
                command.Parameters.AddWithValue("@Quantity", model.Quantity);
                command.Parameters.AddWithValue("@Price", model.Price);
                command.Parameters.AddWithValue("@TotalCost", model.TotalCost);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private List<Billing> GetBills()
        {
            using (var db = new DB())
            {
                var bills = db.billings.Include(b => b.customers).ToList();
                return bills;
            }
        }

    }
}