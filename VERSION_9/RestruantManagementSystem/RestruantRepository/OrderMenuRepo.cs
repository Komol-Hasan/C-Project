using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RestruantRepository
{
    public class OrderMenuRepo
    {
        public bool Insert(OrderMenu order)
        {

            try
            {
                string query = "INSERT into SelectedItem VALUES ('"+order.ItemName+"',"+order.ItemQuantity+","+ "(select ItemPrice from Inventroy where ItemName = '" + order.ItemName + "' )" + ") ";
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

        public List<OrderMenu> GetAllOrderMenu()
        {
            string query = "SELECT * from SelectedItem";
            List<OrderMenu> orderMenuList = new List<OrderMenu>();

            DataBaseConnectionClass dcc = new DataBaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                OrderMenu orderMenu = new OrderMenu();
                orderMenu.OrderNo =Convert.ToInt32(sdr["OrderNo"].ToString());
                orderMenu.ItemName = sdr["ItemName"].ToString();
                orderMenu.ItemQuantity = Convert.ToInt32(sdr["ItemQuantity"]);
                orderMenu.ItemPrice = Convert.ToDouble(sdr["ItemPrice"]);
                orderMenuList.Add(orderMenu);
            }
            dcc.CloseConnection();
            return orderMenuList;
        }
        public double GetPrice()
        {
            double Price = 0;
            double convertQantity = 0;
            string query = "SELECT * from SelectedItem";
            List<Inventory> inventoryList = new List<Inventory>();
            DataBaseConnectionClass dcc = new DataBaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);
            while (sdr.Read())
            {
                Inventory inventory = new Inventory();
              
                inventory.ItemQuantity = Convert.ToInt32(sdr["ItemQuantity"]);
                convertQantity = (double)inventory.ItemQuantity;
                inventory.ItemPrice = Convert.ToDouble(sdr["ItemPrice"]);
                Price = (inventory.ItemPrice * convertQantity)+Price;

                inventoryList.Add(inventory);
            }
            dcc.CloseConnection();
            return Price;

        }
        public int GetQuantity(string ItemName)
        {
            string query = "SELECT * From Inventroy WHERE ItemName = '" + ItemName + "' ";
            Inventory inventory = null;
            List<Inventory> inventoryList = new List<Inventory>();

            DataBaseConnectionClass dcc = new DataBaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                inventory = new Inventory();
                inventory.ItemId = sdr["ItemId"].ToString();
                inventory.ItemName = sdr["ItemName"].ToString();
                inventory.ItemQuantity = Convert.ToInt32(sdr["ItemQuantity"]);
                inventory.ItemPrice = Convert.ToDouble(sdr["ItemPrice"]);
                inventoryList.Add(inventory);


            }

            dcc.CloseConnection();
            return inventory.ItemQuantity;
        }
        public bool Delete(string ItemName)
        {
            try
            {
                string query = "DELETE From SelectedItem WHERE ItemName = '" + ItemName + "' ";
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
        public bool Update(int updateQuantity, string itemName)
        {
            try
            {
                string query = "UPDATE SelectedItem SET ItemQuantity = " + updateQuantity + " where ItemName = '" + itemName + "' ";
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
        public bool ResetSelectedItem()
        {
            
            try
            {
                string query = "DELETE From SelectedItem";
                DataBaseConnectionClass dcc = new DataBaseConnectionClass();
                dcc.ConnectWithDB();
                dcc.ExecuteSQL(query);

                dcc.CloseConnection();
                dcc.ConnectWithDB();

                dcc.ExecuteSQL("DBCC CHECKIDENT ('[SelectedItem]', RESEED, 0)");
                dcc.CloseConnection();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
