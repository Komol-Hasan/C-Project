using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestruantRepository
{
    public class OrderMenu
    {
        private int orderNo;
        private string itemName;
        private int itemQuantity;
        private double itemPrice;

        public int OrderNo
        {
            get { return orderNo; ; }
            set { orderNo = value; }
        }

        public string ItemName
        {
            set { itemName = value; }
            get { return itemName; }
        }
        public int ItemQuantity
        {
            set { itemQuantity = value; }
            get { return itemQuantity; }
        }
        public double ItemPrice
        {
            set { itemPrice = value; }
            get { return itemPrice; }
        }
       
    }
}
