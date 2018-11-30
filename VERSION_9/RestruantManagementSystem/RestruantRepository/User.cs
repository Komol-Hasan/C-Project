using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestruantRepository
{
    public class User
    {
        private string userId;
        private string userName;
        private DateTime dateOfBirth;
        private string password;
        private string designation;
        private double salary;
        private string userType;
        private DateTime dateOfJoing;
        private string contactNo;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }


        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public DateTime DateOfJoing
        {
            get { return dateOfJoing; }
            set { dateOfJoing = value; }
        }

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }
    }
}
