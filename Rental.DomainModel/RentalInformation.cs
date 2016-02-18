using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Rental
{
    public class RentalInformation
    {
        private int _id;
        private Rental _rented;
        private DateTime _start, _end;
        private Double _dailyCost;

        public RentalInformation() { }

        public RentalInformation(Rental r, DateTime from, DateTime to, Double dailyCost)
        {
            this.Rented = r;
            this._start = from;
            this._end = to;
            this.DailyCost = dailyCost;
        }

        public virtual Rental Rented
        {
            get
            {
                return _rented;
            }

            set
            {
                _rented = value;
            }
        }

        public virtual DateTime Start
        {
            get
            {
                return _start;
            }

            set
            {
                _start = value;
            }
        }

        public virtual DateTime End
        {
            get
            {
                return _end;
            }

            set
            {
                _end = value;
            }
        }

        public virtual double DailyCost
        {
            get
            {
                return _dailyCost;
            }

            set
            {
                _dailyCost = value;
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
