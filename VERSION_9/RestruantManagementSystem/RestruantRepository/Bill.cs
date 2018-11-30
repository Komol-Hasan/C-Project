using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestruantRepository
{
    public class Bill
    {

        private double total;
        private double vat;
        private double discount;
        private double payableTotal;

        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public double Vat
        {
            get { return vat; }
            set { vat = value; }
        }

        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public double PayableTotal

        {
            get { return payableTotal; }
            set { payableTotal = value; }
        }
    }
}
