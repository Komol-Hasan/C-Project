using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestruantRepository
{
    public class MenuRepo
    {
        public bool Insert(Menue menu)
        {
            
            try
            {
                string query = "INSERT into MenuInfo VALUES ('" + menu.MenuId + "', '" + menu.MenuName + "','" + menu.MenuCatagory + "','" + menu.MenuType + "') ";
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

        public List<Menue> GetAllItem()
        {
            string query = "SELECT * from MenuInfo";
            List<Menue> menuList = new List<Menue>();

            DataBaseConnectionClass dcc = new DataBaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {

                Menue menu = new Menue();
                menu.MenuId = sdr["MenuID"].ToString();
                menu.MenuName = sdr["MenuName"].ToString();
                menu.MenuCatagory = sdr["MenuCatagory"].ToString();
                menu.MenuType = sdr["MenuType"].ToString();
                menuList.Add(menu);
            }
            dcc.CloseConnection();
            return menuList;
        }

        public List<Menue> GetItem(string menuId)
        {
            string query = "SELECT * from MenuInfo where MenuID = '" + menuId + "'";
            List<Menue> menuList = new List<Menue>();

            DataBaseConnectionClass dcc = new DataBaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {

                Menue menu = new Menue();
                menu.MenuId = sdr["MenuID"].ToString();
                menu.MenuName = sdr["MenuName"].ToString();
                menu.MenuCatagory = sdr["MenuCatagory"].ToString();
                menu.MenuType = sdr["MenuType"].ToString();
                menuList.Add(menu);
            }
            dcc.CloseConnection();
            return menuList;
        }

        public bool Delete(string MenuId)
        {
            try
            {
                string query = "DELETE From MenuInfo WHERE MenuId = '" + MenuId + "' ";
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

    }
}
