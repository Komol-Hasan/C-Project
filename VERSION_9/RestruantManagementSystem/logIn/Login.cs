using System;
using RestruantRepository;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logIn
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void logIn_bt_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserId = this.textBoxUserId.Text;
            user.Password = this.textBoxPassword.Text;
           

            UserRepo userRepo = new UserRepo();
            List<User> userList = userRepo.GetUser(user.UserId);

            Admin admin = new Admin();
            admin.Show();

            this.Hide();

         /*   try
                {
                    if (userList[0].Password == user.Password)
                    {
                        if (userList[0].UserType.ToString() == "Admin")
                        {
                            Admin admin = new Admin();
                            admin.Show();

                            this.Hide();
                        }
                        else if (userList[0].UserType.ToString() == "Manager")
                        {
                            Manager m = new Manager();
                            m.Show();
                            this.Hide();
                        }
                        else if (userList[0].UserType.ToString() == "Employee")
                        {
                            ServiceProvider s = new ServiceProvider();
                            s.Show();
                            this.Hide();
                        }
                    }
                       else
                       {
                           MessageBox.Show("Invalid Password or User Id");
                           this.textBoxUserId.Text = "";
                           this.textBoxPassword.Text = "";
                       }
                }
                catch
                {
                    MessageBox.Show("Invalid Password or User Id");
                    this.textBoxUserId.Text = "";
                    this.textBoxPassword.Text = "";
                } */



        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
