using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestruantRepository
{
    public class Inventory
    {
        private string itemId;
        private string itemName;
        private int itemQuantity;
        private double itemPrice;
        private double prepareTotalPrice;
        private DateTime dateOfPrepare;


        public string ItemId
        {
            set { itemId = value; }
            get { return itemId; }
        }

        public string ItemName
        {
            set { itemName = value; }
            get { return itemName; }
        }
        public int ItemQuantity
        {
            get { return itemQuantity; }
            set { itemQuantity = value; }
        }

        public double ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }

       /* public double PrepareTotalPrice
        {
            get { return prepareTotalPrice; }
            set { prepareTotalPrice = value; }
        }*/

      /*  public DateTime DateOfPrepare
        {
            get { return dateOfPrepare; }
            set { dateOfPrepare = value; }
        }*/

       
    }
}
