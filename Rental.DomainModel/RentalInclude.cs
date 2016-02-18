using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public class RentalInclude
    {
        private int _id;
        private Offer _offer;
        private int _number;

        public RentalInclude() { }

        public override string ToString()
        {
            return Offer.ToString() + "(" + Number + ")";
        }

        public RentalInclude(Offer offer, int number)
        {
            this._offer = offer;
            this._number = number;
        }

        public virtual Offer Offer
        {
            get
            {
                return _offer;
            }

            set
            {
                _offer = value;
            }
        }

        public virtual int Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
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
    }
}
