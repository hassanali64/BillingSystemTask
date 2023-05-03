using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BillingSystemTask.Models
{
    public class CustomerDbContext
    {
        string cs = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public List<Customers> GetCustomers()
        {
            List<Customers> CustomersList = new List<Customers>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetCustomers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Customers customers= new Customers();
                customers.Id = Convert.ToInt32(dr.GetValue(0).ToString());
                customers.CustomerName = dr.GetValue(1).ToString();
                customers.RegistrationDate = Convert.ToDateTime(dr.GetValue(2).ToString());
                customers.UserId = Convert.ToInt32(dr.GetValue(3).ToString());

                CustomersList.Add(customers);


            }
            con.Close();
            return CustomersList;
        }

        public bool AddCustomers(Customers customers)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddCustomers", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("CustomerName", customers.CustomerName);
            cmd.Parameters.AddWithValue("RegistrationDate", customers.RegistrationDate);
            cmd.Parameters.AddWithValue("UserId", customers.UserId);




            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateCustomers(Customers customers)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateCustomers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", customers.Id);
            cmd.Parameters.AddWithValue("CustomerName", customers.CustomerName);
            cmd.Parameters.AddWithValue("RegistrationDate", customers.RegistrationDate);
            cmd.Parameters.AddWithValue("UserId", customers.UserId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteItems(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteCustomers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", id);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}