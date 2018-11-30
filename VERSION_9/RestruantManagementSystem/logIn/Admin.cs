using System;
using System.Collections.Generic;
using RestruantRepository;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace logIn
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            /*tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;*/
            AdminTabControl.Appearance = TabAppearance.FlatButtons;
            AdminTabControl.ItemSize = new Size(0, 1);
            AdminTabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 0;
        }

        private void userCreate_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 1;
        }

        private void userEdit_bt_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.textBoxUserSearch.Text;
                UserRepo userRepo = new UserRepo();
                List<User> userList = userRepo.GetUser(str);
                //  this.dataGridViewUser.DataSource = userList;

                this.textBoxEditUserName.Text = userList[0].UserName.ToString();
                this.dateTimePickerEditUserDoB.Text = userList[0].DateOfBirth.ToString();
                this.textBoxEditUserPassword.Text = userList[0].Password.ToString();
                this.textBoxEditUserDesignation.Text = userList[0].Designation.ToString();
                this.textBoxEditUserSalary.Text = userList[0].Salary + "";
                this.dateTimePickerDoJ.Text = userList[0].DateOfJoing.ToString();
                this.comboBoxEditUserType.Text = userList[0].UserType.ToString();
                this.textBoxEditUserContactNumber.Text = userList[0].ContactNo + "";
                AdminTabControl.SelectedIndex = 7;
            }
            catch
            {

            }
           
            
        }

        private void userSave_bt_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserId = this.textBoxUserId.Text;
            user.UserName = this.textBoxUserName.Text;
            user.DateOfBirth = Convert.ToDateTime(this.dateTimePickerDoB.Text);
            user.Password = this.textBoxPassword.Text;
            user.Designation = this.textBoxDesignation.Text;
            user.Salary = Convert.ToDouble(this.textBoxSalary.Text);
            user.UserType = this.comboBoxUserType.Text;
            user.ContactNo = this.textBoxContactNumber.Text;

            UserRepo userRepo = new UserRepo();
            if (userRepo.Insert(user))
            {
                List<User> userList = userRepo.GetAllUser();
                AdminTabControl.SelectedIndex = 0;
                this.dataGridViewUser.DataSource = userList;
            }
            else MessageBox.Show("Not Inserted");

        }


        private void userBack_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 0;
        }

        private void menu_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 2;
        }

        private void AddMenu_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 3;
        }

        private void editMenu_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 3;
        }

        private void menuSave_bt_Click(object sender, EventArgs e)
        {
            Menue menu = new Menue();
        
            MenuRepo menuRepo = new MenuRepo();
            if (menuRepo.Insert(menu))
            {
                List<Menue> menuList = menuRepo.GetAllItem();
                AdminTabControl.SelectedIndex = 2;
        
            }
            else MessageBox.Show("NOt Inserted");
        }

        private void menuExit_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 2;
        }

       

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.Show();
            this.Hide();
        }

        private void inventoryAdmin_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 2;
        }

        private void invenAddMenu_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 3;
            this.textBoxSearchInventory.Text = "";
        }

        private void EditProduct_Click(object sender, EventArgs e)
        {


            try
            {
                string str = this.textBoxSearchInventory.Text;
                InventoryRepo inventoryRepo = new InventoryRepo();
                List<Inventory> inventoryList = inventoryRepo.GetInventory(str);
                this.textBoxItemName.Text = inventoryList[0].ItemName;
                this.textBoxQuantity.Text = inventoryList[0].ItemQuantity + "";
                this.textBoxItemPrice.Text = inventoryList[0].ItemPrice + "";
                this.txtboxItemId.Text = inventoryList[0].ItemId ;

            }
            catch
            {

            }



            AdminTabControl.SelectedIndex = 3;
        }

        private void productSave_bt_Click(object sender, EventArgs e)
        {
          
            Inventory inventory = new Inventory();
            InventoryRepo inventoryRepo = new InventoryRepo();
            inventory.ItemId = this.txtboxItemId.Text;
            if (inventory.ItemId == this.textBoxSearchInventory.Text)
            {
                inventory.ItemName = this.textBoxItemName.Text;
                inventory.ItemQuantity = Convert.ToInt32(this.textBoxQuantity.Text);
                inventory.ItemPrice = Convert.ToDouble(this.textBoxItemPrice.Text);

              
                if (inventoryRepo.ItemUpdate(inventory))
                {
                    List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
                    AdminTabControl.SelectedIndex = 2;
                    this.dataGridViewInventory.DataSource = inventoryList;
                }
                else MessageBox.Show("Not Updated");
                return;
            }
            inventory.ItemName = this.textBoxItemName.Text;
            inventory.ItemQuantity = Convert.ToInt32(this.textBoxQuantity.Text);
           
            inventory.ItemPrice = Convert.ToDouble(this.textBoxItemPrice.Text);

            if (inventoryRepo.Insert(inventory))
            {
                List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
                AdminTabControl.SelectedIndex = 2;
                this.dataGridViewInventory.DataSource = inventoryList;
            }
            else MessageBox.Show("Not Inserted");
           
        }

        private void productExit_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 2;
        }

        private void adminOdertMenu_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 4;
            InventoryRepo inventoryRepo = new InventoryRepo();
            List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
            this.dataGridViewInventoryItem.DataSource = inventoryList;
        }

        private void addOder_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 5;
        }

        private void billManage_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 5;
        }

        private void userInfoAdmin_bt(object sender, EventArgs e)
        {
            button1.BackColor = Color.Blue;
        }

        private void userinfoadmonMouseLeave_bt(object sender, EventArgs e)
        {
            button1.BackColor = Color.RoyalBlue;
                
        }

        

       

        private void InventoryAdmin_bt(object sender, EventArgs e)
        {
            inventoryAdmin_bt.BackColor = Color.Blue;
        }

        private void InventoryAdminL_bt(object sender, EventArgs e)
        {
            inventoryAdmin_bt.BackColor = Color.RoyalBlue;
        }

        private void adminOder_bt(object sender, EventArgs e)
        {
            adminOdertMenu_bt.BackColor = Color.Blue;
        }

        private void adminOrderL_bt(object sender, EventArgs e)
        {
            adminOdertMenu_bt.BackColor = Color.RoyalBlue;
        }

        private void billAdminE_bt(object sender, EventArgs e)
        {
            billManage_bt.BackColor = Color.Blue;
        }

        private void billManageL_bt(object sender, EventArgs e)
        {
            billManage_bt.BackColor = Color.RoyalBlue;
        }

        private void logoutM_bt(object sender, EventArgs e)
        {
            button7.BackColor = Color.Blue;
        }

        private void logoutL_bt(object sender, EventArgs e)
        {
            button7.BackColor = Color.RoyalBlue;
        }

        private void user_view_bt_Click(object sender, EventArgs e)
        {

            UserRepo userRepo = new UserRepo();
            List<User> userList = userRepo.GetAllUser();
            this.dataGridViewUser.DataSource = userList;
        }

        private void userDelete_bt_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserId = this.textBoxUserSearch.Text;
            MessageBox.Show(user.UserId);
            UserRepo userRepo = new UserRepo();

            if (userRepo.Delete(user.UserId))
            {
                MessageBox.Show(" Perfectly Deleted");
            }
            else MessageBox.Show(" can not be deleted ");
        }

        

        

        private void palacedOder_bt_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void salesAdmin_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 7;
        }

        private void AnnualCalAdmin_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 11;
        }

        private void backSalesAdmin_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 10;
        }

        private void UserSearch_bt_Click(object sender, EventArgs e)
        {
            string str = this.textBoxUserSearch.Text;
            UserRepo userRepo = new UserRepo();
            List<User> userList = userRepo.GetUser(str);
            this.dataGridViewUser.DataSource = userList;
        }

       

        private void saveUpdateAdmin_bt_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserId = this.textBoxUserSearch.Text;
            user.UserName = this.textBoxEditUserName.Text;
            user.DateOfBirth = Convert.ToDateTime(this.dateTimePickerEditUserDoB.Text);
            user.Password = this.textBoxEditUserPassword.Text;
            user.Designation = this.textBoxEditUserDesignation.Text;
            user.Salary = Convert.ToDouble(this.textBoxEditUserSalary.Text);
            user.UserType = this.comboBoxEditUserType.Text;
            user.ContactNo = this.textBoxEditUserContactNumber.Text;
           // user.DateOfJoing = Convert.ToDateTime(this.dateTimePickerDoJ.Text);

            UserRepo userRepo = new UserRepo();
            if (userRepo.Update(user))
            {
                List<User> userList = userRepo.GetAllUser();
                AdminTabControl.SelectedIndex = 0;
                this.dataGridViewUser.DataSource = userList;
            }
            else MessageBox.Show("Not Inserted");
        }

        private void viewProduct_bt_Click(object sender, EventArgs e)
        {
            

            InventoryRepo inventoryRepo = new InventoryRepo();
            List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
            this.dataGridViewInventory.DataSource = inventoryList;
        }

        private void deleteProduct_bt_Click(object sender, EventArgs e)
        {
            

            Inventory inventory = new Inventory();
            inventory.ItemId = this.textBoxSearchInventory.Text;
            InventoryRepo inventoryRepo = new InventoryRepo();
            if (inventoryRepo.Delete(inventory.ItemId))
            {
                MessageBox.Show("Perfectly Deleted");
            }
            else MessageBox.Show("Not Deleted");
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void viewForOrder_Click(object sender, EventArgs e)
        {
            string str = this.textBoxAvItems.Text;
            InventoryRepo inventoryRepo = new InventoryRepo();
            List<Inventory> inventoryList = inventoryRepo.GetInventory(str);
            this.dataGridViewInventoryItem.DataSource = inventoryList;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void inventorySearch_Click(object sender, EventArgs e)
        {
            string str = this.textBoxSearchInventory.Text;
            InventoryRepo inventoryRepo = new InventoryRepo();
            List<Inventory> inventoryList = inventoryRepo.GetInventory(str);
            this.dataGridViewInventory.DataSource = inventoryList;
        }

        private void buttonOrderAdd_Click(object sender, EventArgs e)
        {

            try
            {
                OrderMenu orderMenu = new OrderMenu();
                //    orderMenu.OrderNo = Convert.ToInt32(this.textBoxOrderNo.Text);
                orderMenu.ItemName = this.textBoxOdrItemName.Text;
                orderMenu.ItemQuantity = Convert.ToInt32(this.textBoxOrderQuantity.Text);


                OrderMenuRepo orderMenuRepo = new OrderMenuRepo();
                if (orderMenu.ItemQuantity <= orderMenuRepo.GetQuantity(orderMenu.ItemName))
                {
                    if (orderMenuRepo.Insert(orderMenu))
                    {
                        List<OrderMenu> orderMenuList = orderMenuRepo.GetAllOrderMenu();
                        this.dataGridViewOrderedItme.DataSource = orderMenuList;
                        InventoryRepo inventoryRepo = new InventoryRepo();
                        inventoryRepo.Update(orderMenuRepo.GetQuantity(orderMenu.ItemName) - orderMenu.ItemQuantity, orderMenu.ItemName);

                        List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
                        this.dataGridViewInventoryItem.DataSource = inventoryList;
                    }
                }
                else MessageBox.Show("Quantity Limit Exceed");

            }
            catch
            {

            }

        }

        private void buttonOrderDiscard_Click(object sender, EventArgs e)
        {

            try
            {
                OrderMenu orderMenu = new OrderMenu();

                //   orderMenu.OrderNo = Convert.ToInt32(this.textBoxOrderNo.Text);
                orderMenu.ItemName = this.textBoxOdrItemName.Text;
                orderMenu.ItemQuantity = Convert.ToInt32(this.textBoxOrderQuantity.Text);



                InventoryRepo inventoryRepo = new InventoryRepo();
                OrderMenuRepo orderMenuRepo = new OrderMenuRepo();

                inventoryRepo.Update(orderMenuRepo.GetQuantity(orderMenu.ItemName) + orderMenu.ItemQuantity, orderMenu.ItemName);
                orderMenuRepo.Delete(orderMenu.ItemName);
                //  orderMenuRepo.Update(, orderMenu.ItemName);

                List<OrderMenu> orderMenuList = orderMenuRepo.GetAllOrderMenu();
                this.dataGridViewOrderedItme.DataSource = orderMenuList;
                List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
                this.dataGridViewInventoryItem.DataSource = inventoryList;
                this.textBoxOdrItemName.Text = "";
                this.textBoxOrderQuantity.Text = "";
            }
            catch
            {

            }
        }

        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            OrderMenuRepo orderMenuRepo = new OrderMenuRepo();
            this.textBoxTotalPrice.Text = orderMenuRepo.GetPrice().ToString();
            this.textBoxPayableTotal.Text = orderMenuRepo.GetPrice().ToString();
            List<OrderMenu> orderMenuList = orderMenuRepo.GetAllOrderMenu();
            this.dataGridViewBilling.DataSource = orderMenuList;
            AdminTabControl.SelectedIndex = 5;
            orderMenuRepo.ResetSelectedItem();
        }

        private void saleEnterbt(object sender, EventArgs e)
        {
            salesAdmin_bt.BackColor = Color.Blue;

        }

        private void saleLeave_bt(object sender, EventArgs e)
        {
            salesAdmin_bt.BackColor = Color.RoyalBlue;
        }

        private void backAdminUI_bt_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminTabControl.SelectedIndex = 4;
        }

        

      /*private void PrintBill_bt_Click(object sender, PrintPageEventArgs e)
        {
            Font heading = new Font("lucida handwriting", 22);
            Font heading1 = new Font("Bradley Hand ITC", 28, FontStyle.Bold);

            Font letter = new Font("arial", 14);
            Font letter1 = new Font("arial", 14, FontStyle.Bold);

            e.Graphics.DrawString("WELCOME", heading, Brushes.DarkGreen, 330, 70);
            e.Graphics.DrawString("Restruant Management System", heading1, Brushes.Firebrick, 280, 120);
        }*/

        private void PrintBill_bt_Click(object sender, PrintPageEventArgs e)
        {
            Font heading = new Font("lucida handwriting", 22);
            Font heading1 = new Font("Bradley Hand ITC", 28, FontStyle.Bold);

            Font letter = new Font("arial", 14);
            Font letter1 = new Font("arial", 14, FontStyle.Bold);

            e.Graphics.DrawString("WELCOME", heading, Brushes.DarkGreen, 330, 70);
            e.Graphics.DrawString("Restruant Management System", heading1, Brushes.Firebrick, 280, 120);
        }
    }
}
