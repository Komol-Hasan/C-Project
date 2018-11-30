using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestruantRepository
{
    public class InventoryRepo
    {
        public bool Insert(Inventory inventory)
        {
            try
            {

              string query = "Insert into Inventroy VALUES('" + inventory.ItemId + "','" + inventory.ItemName + "'," + inventory.ItemQuantity + "," + inventory.ItemPrice + ")";
              

                DataBaseConnectionClass dcc = new DataBaseConnectionClass();
                dcc.ConnectWithDB();
                int x = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch
           {
                return false;
            }
        }
        public List<Inventory> GetAllInventory()
        {
            string query = "SELECT * from Inventroy";
            List<Inventory> inventoryList = new List<Inventory>();
            DataBaseConnectionClass dcc = new DataBaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);
            while (sdr.Read())
            {
                Inventory inventory = new Inventory();
                inventory.ItemId = sdr["ItemId"].ToString();
                inventory.ItemName = sdr["ItemName"].ToString();
                inventory.ItemQuantity = Convert.ToInt32(sdr["ItemQuantity"]);
                inventory.ItemPrice = Convert.ToDouble(sdr["ItemPrice"]);
                
                inventoryList.Add(inventory);
            }
            dcc.CloseConnection();
            return inventoryList;

        }
      
        public bool Delete(string ItemId)
        {
            try
            {
                string query = "DELETE From Inventroy WHERE ItemId = '" + ItemId + "' ";
                DataBaseConnectionClass dcc = new DataBaseConnectionClass();
                dcc.ConnectWithDB();
                int x = dcc.ExecuteSQL(query);

                dcc.CloseConnection();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Inventory>GetInventory(string ItemId)
        {

             string query = "SELECT * From Inventroy WHERE (ItemId LIKE '%" + ItemId + "%' OR ItemId LIKE '"+ItemId+"%_%') OR (ItemName LIKE '%" + ItemId + "%' ) ";
         


            Inventory inventory = null;
            List<Inventory> inventoryList = new List<Inventory>();

            DataBaseConnectionClass dcc = new DataBaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while(sdr.Read())
            {
                inventory = new Inventory();
                inventory.ItemId = sdr["ItemId"].ToString();
                inventory.ItemName = sdr["ItemName"].ToString();
                inventory.ItemQuantity = Convert.ToInt32(sdr["ItemQuantity"]);
                inventory.ItemPrice = Convert.ToDouble(sdr["ItemPrice"]);
                inventoryList.Add(inventory);


            }

            dcc.CloseConnection();
            return inventoryList;

        }
        public bool Update(int updateQuantity,string itemName)
        {
            try
            {
                string query = "UPDATE Inventroy SET ItemQuantity = "+updateQuantity+" where ItemName = '"+itemName+"' ";
                DataBaseConnectionClass dcc = new DataBaseConnectionClass();
                dcc.ConnectWithDB();
                dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ItemUpdate(Inventory inventory)
        {
            string query = "UPDATE Inventroy SET ItemQuantity = " + inventory.ItemQuantity + " , ItemName = '" + inventory.ItemName + "' ,ItemPrice = " + inventory.ItemPrice + " where ItemId ='" + inventory.ItemId + "' ";
            DataBaseConnectionClass dcc = new DataBaseConnectionClass();
            dcc.ConnectWithDB();
            dcc.ExecuteSQL(query);
            dcc.CloseConnection();
            return true;
        /*    try
            {
                string query = "UPDATE Inventroy SET ItemQuantity = " + inventory.ItemQuantity + " , ItemName = '" + inventory.ItemName + "' ,ItemPrice = " + inventory.ItemPrice + " where ItemId ='" + inventory.ItemId + "' ";
                DataBaseConnectionClass dcc = new DataBaseConnectionClass();
                dcc.ConnectWithDB();
                dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }*/
        }

    }
}
