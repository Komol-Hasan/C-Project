using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestruantRepository;

namespace logIn
{
    public partial class ServiceProvider : Form
    {
        public ServiceProvider()
        {
            InitializeComponent();

            SercicetabControl1.Appearance = TabAppearance.FlatButtons;
            SercicetabControl1.ItemSize = new Size(0, 1);
            SercicetabControl1.SizeMode = TabSizeMode.Fixed;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void logoutService_bt_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.Show();
            this.Hide();
        }

        private void inventoryAdmin_bt_Click(object sender, EventArgs e)
        {
            SercicetabControl1.SelectedIndex = 0;
        }

        private void viewProductService_bt_Click(object sender, EventArgs e)
        {

            InventoryRepo inventoryRepo = new InventoryRepo();
            List<Inventory> inventoryList = inventoryRepo.GetAllInventory();
            this.dataGridViewInventoryService.DataSource = inventoryList;
        }

        private void inventorySearchService_bt_Click(object sender, EventArgs e)
        {
            string str = this.textBoxInvenService.Text;
            InventoryRepo inventoryRepo = new InventoryRepo();
            List<Inventory> inventoryList = inventoryRepo.GetInventory(str);
            this.dataGridViewInventoryService.DataSource = inventoryList;
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void viewForOrder_Click(object sender, EventArgs e)
        {
            string str = this.textBoxAvItems.Text;
            InventoryRepo inventoryRepo = new InventoryRepo();
            List<Inventory> inventoryList = inventoryRepo.GetInventory(str);
            this.dataGridViewInventoryItemService.DataSource = inventoryList;
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
                        this.dataGridViewInventoryItemService.DataSource = inventoryList;
                    }
                }
                else MessageBox.Show("Quantity Limit Exceed");

            }
            catch
            {

            }
        }

        private void buttonOrderDiscardService_Click(object sender, EventArgs e)
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
                this.dataGridViewInventoryItemService.DataSource = inventoryList;
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
            this.textBoxTotalservice.Text = orderMenuRepo.GetPrice().ToString();
            this.textBoxPaytotal.Text = orderMenuRepo.GetPrice().ToString();
            List<OrderMenu> orderMenuList = orderMenuRepo.GetAllOrderMenu();
            this.dataGridViewservicebill.DataSource = orderMenuList;
            SercicetabControl1.SelectedIndex = 3;
            orderMenuRepo.ResetSelectedItem();
        }

        private void serviceOdertMenu_bt_Click(object sender, EventArgs e)
        {
            SercicetabControl1.SelectedIndex = 1;
        }

        private void billManageService_bt_Click(object sender, EventArgs e)
        {
            SercicetabControl1.SelectedIndex = 3;
        }
    }
}
