using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public abstract class Rental
    {
        private int _id;
        private Client _owner;
        private String _name;
        private String _description;
        private Double _dailyPrice;

        public Rental() { }

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual Client Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public virtual String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public virtual Double DailyPrice
        {
            get { return _dailyPrice; }
            set { _dailyPrice = value; }
        }
    }
}
