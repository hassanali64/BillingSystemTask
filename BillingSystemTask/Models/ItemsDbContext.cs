using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BillingSystemTask.Models
{
    public class ItemsDbContext
    {
        string cs = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public List<Items> GetItems()
        {
            List<Items> ItemsList = new List<Items>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetItems", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Items item = new Items();
                item.ItemId = Convert.ToInt32(dr.GetValue(0).ToString());
                item.ItemName = dr.GetValue(1).ToString();
                item.Description = dr.GetValue(2).ToString();
                item.fee = Convert.ToInt32(dr.GetValue(3).ToString());
                item.UserId = Convert.ToInt32(dr.GetValue(3).ToString());

                ItemsList.Add(item);


            }
            con.Close();
            return ItemsList;
        }
        
        public bool AddItems(Items item)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddItems", con);
            cmd.CommandType = CommandType.StoredProcedure;

          
            cmd.Parameters.AddWithValue("ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("Description", item.Description);
            cmd.Parameters.AddWithValue("fee", item.fee);
            cmd.Parameters.AddWithValue("UserId", item.UserId);




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
        public bool UpdateItems(Items item)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateitems", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ItemId", item.ItemId);
            cmd.Parameters.AddWithValue("ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("Description", item.Description);
            cmd.Parameters.AddWithValue("fee", item.fee);
            cmd.Parameters.AddWithValue("UserId", item.UserId);

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
            SqlCommand cmd = new SqlCommand("spDeleteItems", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ItemId", id);


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