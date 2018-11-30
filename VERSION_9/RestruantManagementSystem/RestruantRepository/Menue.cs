using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestruantRepository
{
    public class Menue
    {
        private string menuId;
        private string menuName;
        private string menuCatagory;
        private string menuType;
        private bool menuAvilability;
        private double menuPrice;

        public string MenuId
        {
            get { return menuId; }
            set { menuId = value; }
        }

        public string MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }

        public string MenuCatagory
        {
            get { return menuCatagory; }
            set { menuCatagory = value; }
        }
        public string MenuType
        {
            get { return menuType; }
            set { menuType = value; }
        }
        public bool MenuAvilability
        {
            get { return menuAvilability; }
            set { menuAvilability = value; }
        }
        public double MenuPrice
        {
            get { return menuPrice; }
            set { menuPrice = value; }
        }
    }
}
