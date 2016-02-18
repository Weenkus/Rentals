using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public class SpecialFeatures
    {
        private int _id;
        private double _price;
        private String _description;

        public SpecialFeatures() { }

        public override string ToString()
        {
            return _description + " (" + Convert.ToInt32(Price) + "€)";
        }

        public SpecialFeatures(Double price, String description)
        {
            this._price = price;
            this._description = description;
        }

        public virtual int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public virtual double Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public virtual string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
    }
}
