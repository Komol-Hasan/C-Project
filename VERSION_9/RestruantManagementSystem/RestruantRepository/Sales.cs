using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestruantRepository
{
    public class Sales
    {
        private DateTime dateOfView;
        private DateTime dateOfStarting;
        private DateTime dateOfEnding;
        private double sale;
        private double revenue;

        public DateTime DateOfview
        {
            get { return dateOfView; }
            set { dateOfView = value; }
        }

        public DateTime DateOfStarting
        {
            get { return dateOfStarting; }
            set { dateOfStarting = value; }
        }

        public DateTime DateOfEnding
        {
            get { return dateOfEnding; }
            set { dateOfEnding = value; }
        }

        public double Sale
        {
            get { return sale; }
            set { sale = value; }
        }

        public double Revenue
        {
            get { return revenue; }
            set { revenue = value; }
        }
    }
}
