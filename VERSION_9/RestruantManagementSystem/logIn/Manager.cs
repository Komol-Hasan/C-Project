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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();

            managerTabControl.Appearance = TabAppearance.FlatButtons;
            managerTabControl.ItemSize = new Size(0, 1);
            managerTabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void userEdit_bt_Click(object sender, EventArgs e)
        {

        }

        private void userCreate_Click(object sender, EventArgs e)
        {

        }

        private void userBack_bt_Click(object sender, EventArgs e)
        {

        }

        private void userSave_bt_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void userSaveManager_bt_Click(object sender, EventArgs e)
        {
            
            User user = new User();
         //  user.UserId = this.textBoxUserId.Text;
         // user.UserName = this.textBoxUserName.Text;
          //  user.Password = this.textBoxPassword.Text;
         //   user.Designation = this.textBoxDesignation.Text;
          //  user.Salary = Convert.ToDouble(this.textBoxSalary.Text);
          //  user.UserType = this.comboBoxUserType.Text;
           // user.ContactNo = this.textBoxContactNumber.Text;

            UserRepo userRepo = new UserRepo();
            if (userRepo.Insert(user))
            {
                List<User> userList = userRepo.GetAllUser();
                managerTabControl.SelectedIndex = 0;
             //   this.dataGridViewUser.DataSource = userList;
            }
            else MessageBox.Show("Not Inserted");
            
        }

        private void userDeleteManager_bt_Click(object sender, EventArgs e)
        {
            User user = new User();
         //   user.UserId = this.textboxUserSearch.Text;
            MessageBox.Show(user.UserId);
            UserRepo userRepo = new UserRepo();

            if (userRepo.Delete(user.UserId))
            {
                MessageBox.Show(" Perfectly Deleted");
            }
            else MessageBox.Show(" can not be deleted ");
        }

        private void userManager_view_bt_Click(object sender, EventArgs e)
        {
            UserRepo userRepo = new UserRepo();
            List<User> userList = userRepo.GetAllUser();
           // this.dataGridViewUser.DataSource = userList;
        }

        private void userBackManager_bt_Click(object sender, EventArgs e)
        {
            managerTabControl.SelectedIndex = 0;
        }

        private void userEditManager_bt_Click(object sender, EventArgs e)
        {
      //      string str = this.textboxUserSearch.Text;
            UserRepo userRepo = new UserRepo();
        //    List<User> userList = userRepo.GetUser(str);
            //  this.dataGridViewUser.DataSource = userList;

        /*   this.textBoxUserName.Text = userList[0].UserName.ToString();
            this.dateTimePickerDoB.Text = userList[0].DateOfBirth.ToString();
            this.textBoxPassword.Text = userList[0].Password.ToString();
            this.textBoxDesignation.Text = userList[0].Designation.ToString();
            this.textBoxSalary.Text = userList[0].Salary + "";
            this.dateTimePickerDoJ.Text = userList[0].DateOfJoing.ToString();
            this.comboBoxUserType.Text = userList[0].UserType.ToString();
            this.textBoxContactNumber.Text = userList[0].ContactNo + "";*/

          //  managerTabControl.SelectedIndex = 1;
        }

       

        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {

            OrderMenu orderMenu = new OrderMenu();
            orderMenu.OrderNo = Convert.ToInt32(this.textBoxTableNo.Text);
           // orderMenu.ItemQuantity = Convert.ToInt32(this.textBoxQuantity.Text);

            OrderMenuRepo orderMenuRepo = new OrderMenuRepo();
            if (orderMenuRepo.Insert(orderMenu))
            {
                List<OrderMenu> orderMenuList = orderMenuRepo.GetAllOrderMenu();
                managerTabControl.SelectedIndex = 2;
                //this.dataGridViewOrderMenu.DataSource = orderMenuList;
            }
            else MessageBox.Show("Not Inserted");
        }

        private void managerOdertMenu_bt_Click(object sender, EventArgs e)
        {
            managerTabControl.SelectedIndex = 2;
        }

        private void salesManager_bt_Click(object sender, EventArgs e)
        {
            managerTabControl.SelectedIndex = 5;
        }

        private void AnnualCalManager_bt_Click(object sender, EventArgs e)
        {
            managerTabControl.SelectedIndex = 6;
        }

        private void BAckManSales_bt_Click(object sender, EventArgs e)
        {
            managerTabControl.SelectedIndex = 5;
        }

        /*private void UserSearch_bt_Click(object sender, EventArgs e)
        {
            string str = this.textboxUserSearch.Text;
            UserRepo userRepo = new UserRepo();
            List<User> userList = userRepo.GetUser(str);
            this.dataGridViewUser.DataSource = userList;
        }

        private void inventoryManager_bt_Click(object sender, EventArgs e)
        {
            managerTabControl.SelectedIndex = 0;
        }

      /*  private void userManager_bt_Click(object sender, EventArgs e)
        {
            managerTabControl.SelectedIndex = 0;
        }*/

        private void logoutManager_bt_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.Show();
            this.Hide();
        }

        private void EditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.textBoxInventorySearch.Text;
                InventoryRepo inventoryRepo = new InventoryRepo();
                List<Inventory> inventoryList = inventoryRepo.GetInventory(str);
                this.textBoxItemName.Text = inventoryList[0].ItemName;
                this.textBoxQuantityInventory.Text = inventoryList[0].ItemQuantity + "";
                this.textBoxItemPrice.Text = inventoryList[0].ItemPrice + "";
                this.txtboxItemId.Text = inventoryList[0].ItemId;

            }
            catch
            {

            }
            managerTabControl.SelectedIndex = 1;
        }

        private void inventorySearch_Click(object sender, EventArgs e)
        {
            string str = this.textBoxInventorySearch.Text;
            InventoryRepo inventoryRepo = new InventoryRepo();
            List<Inventory> inventoryList = inventoryRepo.GetInventory(str);
            this.dataGridViewManagerInventory.DataSource = inventoryList;
        }

        private void ButtonViewInventoryMAnager_Click(object sender, EventArgs e)
        {

            InventoryRepo inventoryRepo = new InventoryRepo();
            List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
            this.dataGridViewManagerInventory.DataSource = inventoryList;
        }

        private void deleteInventoryManager_bt_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.ItemId = this.textBoxInventorySearch.Text;
            InventoryRepo inventoryRepo = new InventoryRepo();
            if (inventoryRepo.Delete(inventory.ItemId))
            {
                MessageBox.Show("Perfectly Deleted");
            }
            else MessageBox.Show("Not Deleted");
        }

        private void productExit_bt_Click(object sender, EventArgs e)
        {

        }

        private void productSave_bt_Click(object sender, EventArgs e)
        {

        }

        private void productExitManager_bt_Click(object sender, EventArgs e)
        {
            managerTabControl.SelectedIndex = 0;
        }

        private void productSaveManager_bt_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            InventoryRepo inventoryRepo = new InventoryRepo();
            inventory.ItemId = this.txtboxItemId.Text;
            if (inventory.ItemId == this.textBoxInventorySearch.Text)
            {
                inventory.ItemName = this.textBoxItemName.Text;
                inventory.ItemQuantity = Convert.ToInt32(this.textBoxQuantityInventory.Text);
                inventory.ItemPrice = Convert.ToDouble(this.textBoxItemPrice.Text);


                if (inventoryRepo.ItemUpdate(inventory))
                {
                    List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
                    managerTabControl.SelectedIndex = 0;
                    this.dataGridViewManagerInventory.DataSource = inventoryList;
                }
                else MessageBox.Show("Not Updated");
                return;
            }
            inventory.ItemName = this.textBoxItemName.Text;
            inventory.ItemQuantity = Convert.ToInt32(this.textBoxQuantityInventory.Text);

            inventory.ItemPrice = Convert.ToDouble(this.textBoxItemPrice.Text);

            if (inventoryRepo.Insert(inventory))
            {
                List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
                managerTabControl.SelectedIndex = 0;
                this.dataGridViewManagerInventory.DataSource = inventoryList;
            }
            else MessageBox.Show("Not Inserted");
        }

        private void buttonOrderAddMan_Click(object sender, EventArgs e)
        {

            try
            {
                OrderMenu orderMenu = new OrderMenu();
                //    orderMenu.OrderNo = Convert.ToInt32(this.textBoxOrderNo.Text);
                orderMenu.ItemName = this.textBoxOdrItemNameMan_bt.Text;
                orderMenu.ItemQuantity = Convert.ToInt32(this.textBoxOrderQuantityMan.Text);


                OrderMenuRepo orderMenuRepo = new OrderMenuRepo();
                if (orderMenu.ItemQuantity <= orderMenuRepo.GetQuantity(orderMenu.ItemName))
                {
                    if (orderMenuRepo.Insert(orderMenu))
                    {
                        List<OrderMenu> orderMenuList = orderMenuRepo.GetAllOrderMenu();
                        this.dataGridViewOrderedItmManagwe2.DataSource = orderMenuList;
                        InventoryRepo inventoryRepo = new InventoryRepo();
                        inventoryRepo.Update(orderMenuRepo.GetQuantity(orderMenu.ItemName) - orderMenu.ItemQuantity, orderMenu.ItemName);

                        List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
                        this.dataGridOrderMenuItemMan1.DataSource = inventoryList;
                    }
                }
                else MessageBox.Show("Quantity Limit Exceed");

            }
            catch
            {

            }
        }

        private void viewForOrderMan_Click(object sender, EventArgs e)
        {
            string str = this.textBoxAvItemsMan.Text;
            InventoryRepo inventoryRepo = new InventoryRepo();
            List<Inventory> inventoryList = inventoryRepo.GetInventory(str);
            this.dataGridOrderMenuItemMan1.DataSource = inventoryList;
        }

        private void buttonOrderDiscardMan_Click(object sender, EventArgs e)
        {
            try
            {
                OrderMenu orderMenu = new OrderMenu();

                //   orderMenu.OrderNo = Convert.ToInt32(this.textBoxOrderNo.Text);
                orderMenu.ItemName = this.textBoxOdrItemNameMan_bt.Text;
                orderMenu.ItemQuantity = Convert.ToInt32(this.textBoxOrderQuantityMan.Text);



                InventoryRepo inventoryRepo = new InventoryRepo();
                OrderMenuRepo orderMenuRepo = new OrderMenuRepo();

                inventoryRepo.Update(orderMenuRepo.GetQuantity(orderMenu.ItemName) + orderMenu.ItemQuantity, orderMenu.ItemName);
                orderMenuRepo.Delete(orderMenu.ItemName);
                //  orderMenuRepo.Update(, orderMenu.ItemName);

                List<OrderMenu> orderMenuList = orderMenuRepo.GetAllOrderMenu();
                this.dataGridViewOrderedItmManagwe2.DataSource = orderMenuList;
                List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
                this.dataGridOrderMenuItemMan1.DataSource = inventoryList;
                this.textBoxOdrItemNameMan_bt.Text = "";
                this.textBoxOrderQuantityMan.Text = "";
            }
            catch
            {

            }
        }

        private void textBoxOdrItemNameMan_bt_TextChanged(object sender, EventArgs e)
        {

        }

        private void placeManagerOrder_bt_Click(object sender, EventArgs e)
        {
            OrderMenuRepo orderMenuRepo = new OrderMenuRepo();
            this.textBoxTotal.Text = orderMenuRepo.GetPrice().ToString();
            this.textBoxPayableTotalMan.Text = orderMenuRepo.GetPrice().ToString();
            List<OrderMenu> orderMenuList = orderMenuRepo.GetAllOrderMenu();
            this.dataGridViewManagerBill.DataSource = orderMenuList;
            managerTabControl.SelectedIndex = 4;
            orderMenuRepo.ResetSelectedItem();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            managerTabControl.SelectedIndex = 2;
        }

        private void inventoryManager_bt_Click(object sender, EventArgs e)
        {

        }

        private void manager_billManage_bt_Click(object sender, EventArgs e)
        {
            managerTabControl.SelectedIndex = 4;
        }



        /*  private void menuSearch_bt_Click(object sender, EventArgs e)
          {
              string str = this.textBoxMenuSearch.Text;
              MenuRepo menuRepo = new MenuRepo();
              List<Menue> menuList = menuRepo.GetItem(str);
              this.dataGridViewMenu.DataSource = menuList;

          }*/
    }
}
