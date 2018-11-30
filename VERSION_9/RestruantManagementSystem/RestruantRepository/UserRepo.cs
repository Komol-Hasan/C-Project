using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestruantRepository
{
    public class UserRepo
    {
        public bool Insert(User user)
        {
            try
            {
                string query = "INSERT into UserInfo VALUES ('" + user.UserId + "', '" + user.UserName + "'," +
                               " '" + user.DateOfBirth + "','" + user.Password + "','" + user.Designation + "'," +
                                " " + user.Salary + ",'" + user.UserType + "','" + DateTime.Now + "','" + user.Salary + "')";
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
        public List<User> GetAllUser()
        {
            string query = "SELECT * from UserInfo";
            List<User> userList = new List<User>();

            DataBaseConnectionClass dcc = new DataBaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                User user = new User();
                user.UserId = sdr["UserId"].ToString();
                user.DateOfBirth = Convert.ToDateTime(sdr["DateOfBirth"]);
                user.UserName = sdr["UserName"].ToString();
                user.Password = sdr["Password"].ToString();
                user.Designation = sdr["Designation"].ToString();
                user.Salary = Convert.ToDouble(sdr["Salary"]);
                user.UserType = sdr["UserType"].ToString();
                user.DateOfJoing = Convert.ToDateTime(sdr["DateOfJoing"]);
                user.ContactNo = sdr["ContactNo"].ToString();
                userList.Add(user);
            }
            dcc.CloseConnection();
            return userList;
        }
        public List<User> GetUser(string userS)
        {
            string query = "SELECT * From UserInfo WHERE (userId LIKE '%" + userS + "%' OR userId LIKE '" + userS + "%_%') OR (userName LIKE '%" + userS + "%' ) OR (userType LIKE '%" + userS + "%' )  ";
            User user = null;
            List<User> userList = new List<User>();

            DataBaseConnectionClass dcc = new DataBaseConnectionClass();
            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                user = new User();
                user.UserId = sdr["UserId"].ToString();
                user.DateOfBirth = Convert.ToDateTime(sdr["DateOfBirth"]);
                user.UserName = sdr["UserName"].ToString();
                user.Password = sdr["Password"].ToString();
                user.Designation = sdr["Designation"].ToString();
                user.Salary = Convert.ToDouble(sdr["Salary"]);
                user.UserType = sdr["UserType"].ToString();
                user.DateOfJoing = Convert.ToDateTime(sdr["DateOfJoing"]);
                user.ContactNo = sdr["ContactNo"].ToString();
                userList.Add(user);
            }
            dcc.CloseConnection();
            return userList;

        }
        public bool Delete(string userId)
        {
            try
            {
                string query = "DELETE From UserInfo WHERE userId = '" + userId + "' ";
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

        public bool Update(User user)
        {
            try
            {
                string query = "UPDATE UserInfo SET userName = '" + user.UserName + "' , Password = '" + user.Password + "', Designation = '" + user.Designation + "',Salary = "+user.Salary+" , UserType = '"+user.UserType+"', ContactNo = '"+user.ContactNo+"' WHERE userId = '" + user.UserId + "'";
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
